using System;
using System.Collections.Generic;
using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.DAL;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Auth.SingleTenant.Models;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.ElasticSearch;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Lead;

namespace PropznetCommon.Features.CRM.Services
{
    public class LeadService : ILeadService
    {
        readonly ILeadRepository _leadRepository;
        readonly IUnitOfWork _iUnitOfWork;
        readonly ElasticSearchService _elasticSearchService;
        readonly IUserService _userService;
        readonly IPersonService _personService;
        readonly IPersonRepository _personRepository;
        public LeadService(ILeadRepository leadRepository, IUnitOfWork iUnitOfWork, IElasticSearchSettings elasticsearchsettings,
            IUserService userService, IPersonRepository personRepository, IPersonService personService)
        {
            _leadRepository = leadRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _iUnitOfWork = iUnitOfWork;
            _userService = userService;
            _personRepository = personRepository;
            _personService = personService;
        }
        public IList<Lead> GetAllLeadsByUserId(long userId, IList<int> permissionCodes)
        {

            var user = _userService.GetUserById(userId);
            return _leadRepository.GetAllLeadsByUserId(userId, user.Id);

        }
        public Lead CreateLead(LeadModel leadModel)
        {
            if (leadModel != null)
            {
                var person = new Person
                {
                    FirstName = leadModel.FirstName,
                    LastName = leadModel.LastName,
                    Company = leadModel.Company,
                    Email = leadModel.Email,
                    PhoneNo = leadModel.Phone,
                    Website = leadModel.Website
                };
                var newPerson = _personRepository.Create(person);
                _iUnitOfWork.Commit();
                var leadCount = _leadRepository.GetLeadCountByUser(leadModel.CreatedBy);
                var lead = new Lead
                {
                    AssignedToUserId = leadModel.SelectedAssignedTo,
                    Description = leadModel.Comment,
                    LeadSourceId = leadModel.SelectedLeadSource,
                    LeadSourceName = leadModel.LeadSourceName,
                    LeadStatusId = leadModel.SelectedLeadStatus,
                    RefId = "L" + (++leadCount),
                    CreatedByUserId = leadModel.CreatedBy,
                    CreatedOn = DateTime.UtcNow,
                    PersonId = newPerson.Id
                };

                if(!String.IsNullOrEmpty(leadModel.Other))
                {
                    lead.Other = leadModel.Other;
                }
                if(leadModel.LeadSourceUserId.HasValue)
                {
                    lead.LeadSourceUserId = leadModel.LeadSourceUserId.Value;
                }
                if(leadModel.RecievedOn.HasValue)
                {
                    lead.RecievedOn = leadModel.RecievedOn.Value;
                }
                if (!String.IsNullOrEmpty(leadModel.Designation))
                {
                    lead.Designation = leadModel.Designation;
                }
                var newLead= _leadRepository.Create(lead);
                _iUnitOfWork.Commit();
                _elasticSearchService.IndexLead(leadModel);
                return newLead;
            }

            return null;
        }
        public bool UpdateLead(LeadModel leadModel)
        {
            var lead = _leadRepository.GetBy(i => i.Id == leadModel.Id);
            if (lead != null)
            {
                lead.AssignedToUserId = leadModel.SelectedAssignedTo;
                lead.Description = leadModel.Comment;
                lead.LeadSourceId = leadModel.SelectedLeadSource;
                lead.LeadSourceName = leadModel.LeadSourceName;
                lead.LeadStatusId = leadModel.SelectedLeadStatus;
                lead.RefId = leadModel.RefId;
                if (!String.IsNullOrEmpty(leadModel.Other))
                {
                    lead.Other = leadModel.Other;
                }
                if (leadModel.LeadSourceUserId.HasValue)
                {
                    lead.LeadSourceUserId = leadModel.LeadSourceUserId.Value;
                }
                if (leadModel.RecievedOn.HasValue)
                {
                    lead.RecievedOn = leadModel.RecievedOn.Value;
                }
                if (!String.IsNullOrEmpty(leadModel.Designation))
                {
                    lead.Designation = leadModel.Designation;
                }
                _leadRepository.Update(lead);
                _elasticSearchService.UpdateLead(leadModel);
                _iUnitOfWork.Commit();

                var person = _personService.GetPersonById(lead.PersonId);
                if (person != null)
                {
                    person.FirstName = leadModel.FirstName;
                    person.LastName = leadModel.LastName;
                    person.Company = leadModel.Company;
                    person.Email = leadModel.Email;
                    person.PhoneNo = leadModel.Phone;
                    person.Website = leadModel.Website;
                };
                _personRepository.Update(person);
                _iUnitOfWork.Commit();
                return true;
            }

            return false;
        }
        public SearchResult<Lead> SearchLeads(LeadSearchFilter searchargument, int pagesize, int count)
        {
            return _leadRepository.SearchLeads(searchargument, pagesize, count);
        }
        public bool DeleteLead(long id)
        {

            var lead = _leadRepository.GetLead(id);
            var person = _personRepository.GetBy(i => i.Id == lead.PersonId);
            bool result = false;

            try
            {
                if (lead != null)
                {
                    var leadModel = new LeadModel
                    {
                        Assignedto = lead.AssignedToUser.Id,
                        Comment = lead.Description,
                        Enitytype = CRMEntityType.Lead,
                        Id = lead.Id,
                        LeadSource = lead.LeadSource.Name,
                        LeadSourceName = lead.LeadSourceName,
                        LeadStatus = lead.LeadStatus.Name,
                        RefId = lead.RefId,
                        SelectedLeadSource = lead.LeadSourceId,
                        SelectedLeadStatus = lead.LeadStatusId,
                        FirstName = lead.Person.FirstName,
                        LastName = lead.Person.LastName,
                        Company = lead.Person.Company,
                        Website = lead.Person.Website,
                        Phone = lead.Person.PhoneNo,
                        Email = lead.Person.Email,
                        CreatedBy = lead.CreatedByUserId,
                    };
                    _elasticSearchService.DeleteLead(leadModel);
                }
            }
            catch (Exception ex)
            { }
            finally
            {
                if (lead != null)
                {
                    result = _leadRepository.DeleteLead(id);
                    _iUnitOfWork.Commit();
                    if (person != null)
                    {
                        result = _personService.DeletePerson(id);
                        _iUnitOfWork.Commit();
                    }
                }
            }
            return result;
        }
        public Lead GetLead(long id)
        {
            return _leadRepository.GetLead(id);
        }
    }
}