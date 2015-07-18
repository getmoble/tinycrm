using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Core;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.ElasticSearch;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Entities.Enum;
using LOG.PropznetCRM.Data.Infrastructure;
using LOG.PropznetCRM.Data.Model.Potential;
using System;
using System.Collections.Generic;

namespace LOG.PropznetCRM.Data.Services
{
    public class PotentialService : IPotentialService
    {
        readonly IPotentialRepository _potentialRepository;
        readonly IUnitOfWork _iUnitOfWork;
        readonly ElasticSearchService _elasticSearchService;
        readonly IAgentService _agentService;

        public PotentialService(IPotentialRepository potentialRepository, IUnitOfWork iUnitOfWork, IElasticSearchSettings elasticsearchsettings, IAgentService agentService)
        {
            _potentialRepository = potentialRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _iUnitOfWork = iUnitOfWork;
            _agentService = agentService;
        }
        public Potential CreatePotential(PotentialModel potentialmodel)
        {
            if (potentialmodel != null)
            {
                var potentialCount = _potentialRepository.GetPotentialCountByUser(potentialmodel.UserId);
                var potential = new Potential
                {
                    Name = potentialmodel.PotentialName,
                    ExpectedAmount = potentialmodel.PotentialAmount,
                    ExpectedCloseDate = potentialmodel.ExpectedCloseDate,
                    LeadSourceId = potentialmodel.SelectedLeadSource,
                    LeadSourceName = potentialmodel.LeadSource,
                    AccountId = potentialmodel.AccountId,
                    PropertyId = potentialmodel.PropertyId,
                    AgentId = potentialmodel.selectedAssignedTo,
                    SalesStageId = potentialmodel.SelectedSalesStage,
                    Comments = potentialmodel.Comments,
                    ContactId = potentialmodel.SelectedContact,
                    RefId = AppConfigaration.GetPotentialPrefix() + (++potentialCount),
                    CreatedBy = potentialmodel.CreatedBy,
                    CreatedOn = DateTimeOffset.UtcNow
                };

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
                potential.Name = potentialmodel.PotentialName;
                potential.ExpectedAmount = potentialmodel.PotentialAmount;
                potential.ExpectedCloseDate = potentialmodel.ExpectedCloseDate;
                potential.LeadSourceName = potentialmodel.LeadSource;
                potential.AccountId = potentialmodel.AccountId;
                potential.PropertyId = potentialmodel.PropertyId;
                potential.AgentId = potentialmodel.selectedAssignedTo;
                potential.SalesStageId = potentialmodel.SelectedSalesStage;
                potential.ContactId = potentialmodel.SelectedContact;
                potential.LeadSourceId = potentialmodel.SelectedLeadSource;
                _potentialRepository.Update(potential);
                _elasticSearchService.UpdatePotential(potentialmodel);
                _iUnitOfWork.Commit();
                return true;

            }

            return false;
        }

        public IList<Potential> GetAllPotentials(long userId, IList<int> permissionCodes)
        {
            if (PermissionChecker.CheckPermission(permissionCodes, PermissionCodes.ViewPotential))
            {
                var agent = _agentService.GetAgentByUserId(userId);
                return _potentialRepository.GetAllPotentials(userId, agent.Id);
            }

            throw new UnauthorizedAccessException();
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
            {
                potential.DeletedOn = DateTime.Now;
            }

            var potentialModel = new PotentialModel
            {
                Account = potential.Account.Name,
                AccountId = potential.AccountId,
                Area = potential.Property.Area,
                BudgetFrom = potential.Property.BudgetFrom,
                BudgetTo = potential.Property.BudgetTo,
                Comments = potential.Comments,
                CreatedBy = potential.CreatedBy,
                Enitytype = EntityType.Potential,
                ExpectedCloseDate = potential.ExpectedCloseDate,
                Floor = potential.Property.Floor,
                Id = potential.Id,
                LeadSource = potential.LeadSourceName,
                PotentialAmount = potential.ExpectedAmount,
                PotentialName = potential.Name,
                PropertyId = potential.Property.Id,
                SalesStage = potential.SalesStage.Name,
                selectedAgent = potential.AgentId,
                selectedAssignedTo = potential.AgentId,
                SelectedContact = potential.ContactId.Value,
                SelectedLeadSource = potential.LeadSourceId,
                selectedLocation = potential.Property.LocationId,
                selectedProperty = potential.Property.PropertyType,
                selectedPropertyCategory = potential.Property.PropertyCategoryId,
                SelectedSalesStage = potential.SalesStageId,
                selectedState = potential.Property.StateId,
                UserId = potential.CreatedBy
            };
            _elasticSearchService.DeletePotential(potentialModel);
            _iUnitOfWork.Commit();
            return true;
        }
        public IList<Potential> GetAllPotentials(IList<int> permissionCodes)
        {
            if (PermissionChecker.CheckPermission(permissionCodes, PermissionCodes.ViewPotential))
            {
                return _potentialRepository.GetAllPotentials();
            }

            throw new UnauthorizedAccessException();
        }
    }
}