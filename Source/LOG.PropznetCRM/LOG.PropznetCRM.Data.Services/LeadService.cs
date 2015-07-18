using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Core;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.ElasticSearch;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Entities.Enum;
using LOG.PropznetCRM.Data.Model.Lead;
using System;
using System.Collections.Generic;

namespace LOG.PropznetCRM.Data.Services
{
    public class LeadService : ILeadService
    {
        readonly ILeadRepository _leadRepository;
        readonly IUnitOfWork _iUnitOfWork;
        readonly ElasticSearchService _elasticSearchService;
        readonly IAgentService _agentService;
        public LeadService(ILeadRepository leadRepository, IUnitOfWork iUnitOfWork, IElasticSearchSettings elasticsearchsettings, IAgentService agentService)
        {
            _leadRepository = leadRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _iUnitOfWork = iUnitOfWork;
            _agentService = agentService;
        }
        public IList<Lead> GetAllLeadsByUserId(long userId, IList<int> permissionCodes)
        {
            if (PermissionChecker.CheckPermission(permissionCodes, PermissionCodes.ViewLead))
            {
                var agent = _agentService.GetAgentByUserId(userId);
                return _leadRepository.GetAllLeadsByUserId(userId, agent.Id);
            }

            throw new UnauthorizedAccessException();
        }

        public bool CreateLead(LeadModel leadModel)
        {
            if (leadModel != null)
            {
                var leadCount = _leadRepository.GetLeadCountByUser(leadModel.CreatedBy);
                var lead = new Lead
                {
                    AgentId = leadModel.SelectedAssignedTo,
                    Comments = leadModel.Comment,
                    Company = leadModel.Company,
                    CommunicationDetailId = leadModel.CommunicationDetailID,
                    FirstName = leadModel.FirstName,
                    LastName = leadModel.LastName,
                    LeadSourceId = leadModel.SelectedLeadSource,
                    LeadSourceName = leadModel.LeadSourceName,
                    LeadStatusId = leadModel.SelectedLeadStatus,
                    RefId = "L" + (++leadCount),
                    CreatedBy = leadModel.CreatedBy,
                    CreatedOn = DateTimeOffset.UtcNow
                };
                _leadRepository.Create(lead);
                _iUnitOfWork.Commit();
                _elasticSearchService.IndexLead(leadModel);
                return true;
            }

            return false;
        }

        public bool UpdateLead(LeadModel leadModel)
        {
            var lead = _leadRepository.GetBy(i => i.Id == leadModel.Id);
            if (lead != null)
            {
                lead.CommunicationDetailId = leadModel.CommunicationDetailID;
                lead.FirstName = leadModel.FirstName;
                lead.LastName = leadModel.LastName;
                lead.AgentId = leadModel.SelectedAssignedTo;
                lead.Comments = leadModel.Comment;
                lead.Company = leadModel.Company;
                lead.LeadSourceId = leadModel.SelectedLeadSource;
                lead.LeadSourceName = leadModel.LeadSourceName;
                lead.LeadStatusId = leadModel.SelectedLeadStatus;
                lead.RefId = leadModel.RefId;
                _leadRepository.Update(lead);
                _elasticSearchService.UpdateLead(leadModel);
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
            {
                lead.DeletedOn = DateTime.Now;
            }

            var leadModel = new LeadModel
            {
                Assignedto = lead.Agent.Id,
                Comment = lead.Comments,
                CommunicationDetailID = lead.CommunicationDetailId,
                Company = lead.Company,
                CreatedBy = lead.CreatedBy,
                Email = lead.CommunicationDetail.Email,
                Enitytype = EntityType.Lead,
                FirstName = lead.FirstName,
                Id = lead.Id,
                LastName = lead.LastName,
                LeadSource = lead.LeadSource.Name,
                LeadSourceName = lead.LeadSourceName,
                LeadStatus = lead.LeadStatus.Name,
                Phone = lead.CommunicationDetail.Phone,
                RefId = lead.RefId,
                SelectedAssignedTo = lead.Agent.Id,
                SelectedLeadSource = lead.LeadSourceId,
                SelectedLeadStatus = lead.LeadStatusId,
                Website = lead.CommunicationDetail.Website
            };
            _elasticSearchService.DeleteLead(leadModel);
            _iUnitOfWork.Commit();
            return true;
        }

        public Lead GetLead(long id)
        {
            return _leadRepository.GetLead(id);
        }
    }
}
