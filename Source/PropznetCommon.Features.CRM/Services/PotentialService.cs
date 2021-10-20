using System;
using System.Collections.Generic;
using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.DAL;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.ElasticSearch;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Potential;

namespace PropznetCommon.Features.CRM.Services
{
    public class PotentialService : IPotentialService
    {
        readonly IPotentialRepository _potentialRepository;
        readonly IPersonRepository _personRepository;
        readonly IPersonService _personService;
        readonly IUnitOfWork _iUnitOfWork;
        readonly ElasticSearchService _elasticSearchService;
        readonly IUserService _userService;

        public PotentialService(IPotentialRepository potentialRepository, IUnitOfWork iUnitOfWork, 
            IElasticSearchSettings elasticsearchsettings,
            IPersonService personService,
            IUserService userService, IPersonRepository personRepository)
        {
            _potentialRepository = potentialRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _iUnitOfWork = iUnitOfWork;
            _userService = userService;
            _personService = personService;
            _personRepository = personRepository;
        }
        public Potential CreatePotential(PotentialModel potentialmodel, string potentialPrefix)
        {
            if (potentialmodel != null)
            {
                var person = new Person
                {
                    FirstName = potentialmodel.PotentialName
                };
                var newPerson = _personRepository.Create(person);
                _iUnitOfWork.Commit();
                var potentialCount = _potentialRepository.GetPotentialCountByUser(potentialmodel.UserId);
                var potential = new Potential
                {
                    ExpectedAmount = potentialmodel.PotentialAmount,
                    ExpectedCloseDate = potentialmodel.ExpectedCloseDate,
                    //ExpectedMoveInDate = potentialmodel.ExpectedMoveInDate,
                    LeadSourceId = potentialmodel.SelectedLeadSource,
                    LeadSourceName = potentialmodel.LeadSource,
                    AccountId = potentialmodel.AccountId,
                    //PropertyId = potentialmodel.PropertyId,
                    AssignedToUserId = potentialmodel.selectedAssignedTo,
                    SalesStageId = potentialmodel.SelectedSalesStage,
                    Description = potentialmodel.Comments,
                    ContactId = potentialmodel.SelectedContact,
                    RefId = potentialPrefix + (++potentialCount),
                    CreatedByUserId = potentialmodel.CreatedBy,
                    CreatedOn = DateTime.UtcNow,
                    PersonId = newPerson.Id
                };
                if(potentialmodel.EnquiredOn.HasValue)
                {
                    potential.EnquiredOn = potentialmodel.EnquiredOn.Value;
                }
                _potentialRepository.Create(potential);
                _elasticSearchService.IndexPotential(potentialmodel);
                _iUnitOfWork.Commit();
                return potential;
            }

            return null;
        }
        public bool UpdatePotential(PotentialModel potentialmodel)
        {
            if (potentialmodel != null)
            {
                var potential = GetPotential(potentialmodel.Id);
                potential.ExpectedAmount = potentialmodel.PotentialAmount;
                potential.ExpectedCloseDate = potentialmodel.ExpectedCloseDate;
                //potential.ExpectedMoveInDate = potentialmodel.ExpectedMoveInDate;
                potential.LeadSourceName = potentialmodel.LeadSource;
                potential.AccountId = potentialmodel.AccountId;
                //if (potentialmodel.PropertyId > 0)
                //    potential.PropertyId = potentialmodel.PropertyId;
                potential.AssignedToUserId = potentialmodel.selectedAssignedTo;
                potential.SalesStageId = potentialmodel.SelectedSalesStage;
                potential.ContactId = potentialmodel.SelectedContact;
                potential.LeadSourceId = potentialmodel.SelectedLeadSource;
                if (potentialmodel.EnquiredOn.HasValue)
                {
                    potential.EnquiredOn = potentialmodel.EnquiredOn.Value;
                }
                _potentialRepository.Update(potential);
                _elasticSearchService.UpdatePotential(potentialmodel);
                _iUnitOfWork.Commit();
                var person = _personService.GetPersonById(potential.PersonId);
                if (person != null)
                {
                    person.FirstName = potentialmodel.PotentialName;
                };
                _personRepository.Update(person);
                _iUnitOfWork.Commit();
                return true;
            }

            return false;
        }
        public IList<Potential> GetAllPotentials(long userId, IList<int> permissionCodes)
        {

            var user = _userService.GetUserById(userId);
            return _potentialRepository.GetAllPotentials(userId, user.Id);
        }
        public SearchResult<Potential> Search(PotentialSearchFilter searchargument, int pagesize, int count)
        {
            return _potentialRepository.SearchPotential(searchargument, pagesize, count);
        }
        public Potential GetPotential(long id)
        {
            return _potentialRepository.GetPotential(id);
        }
        public bool DeletePotential(long id)
        {
            var potential = _potentialRepository.GetPotential(id);
            bool result = false;
            try
            {
                {
                    var potentialModel = new PotentialModel
                    {
                        Account = potential.Account.Person.FirstName,
                        AccountId = potential.AccountId,
                        //Area = potential.Property.Area,
                        //BudgetFrom = potential.Property.BudgetFrom,
                        // BudgetTo = potential.Property.BudgetTo,
                        //Beds = potential.Property.Beds,
                        //Baths = potential.Property.Baths,
                        //ExpectedMoveInDate = potential.ExpectedMoveInDate,
                        Comments = potential.Description,
                        CreatedBy = potential.CreatedByUserId,
                        Enitytype = CRMEntityType.Potential,
                        //ExpectedCloseDate = potential.ExpectedCloseDate,
                        // Floor = potential.Property.Floor,
                        Id = potential.Id,
                        LeadSource = potential.LeadSourceName,
                        //PotentialAmount = potential.ExpectedAmount,
                        PotentialName = potential.Person.FirstName,
                        //PropertyId = potential.Property.Id,
                        SalesStage = potential.SalesStage.Name,
                        selectedAgent = potential.AssignedToUserId,
                        selectedAssignedTo = potential.AssignedToUserId,
                        SelectedContact = potential.ContactId,
                        SelectedLeadSource = potential.LeadSourceId,
                        //CityId = potential.Property.CityId,
                        //selectedProperty = potential.Property.PropertyType,
                        //selectedPropertyCategory = potential.Property.PropertyCategoryId,
                        SelectedSalesStage = potential.SalesStageId,
                        UserId = potential.CreatedByUserId
                    };
                    _elasticSearchService.DeletePotential(potentialModel);
                }
            }
            catch (Exception ex) { }
           
            finally
            {
                if (potential != null)
                {
                    result = _potentialRepository.DeletePotential(id);
                    _iUnitOfWork.Commit();
                }
            }
            return result;
        }
        public IList<Potential> GetAllPotentials(IList<int> permissionCodes)
        {

            return _potentialRepository.GetAllPotentials();

        }
    }
}