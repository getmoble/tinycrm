using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Data.Interfaces;
using Common.Data.Models;
using Hangfire;
using LOG.PropznetCRM.Data.Core;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.ElasticSearch;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Infrastructure;
using LOG.PropznetCRM.Data.Model.Agent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.Services
{
    public class AgentService : IAgentService
    {
        readonly IAgentRepository _agentRepository;
        readonly IUnitOfWork _iUnitOfWork;
        readonly Common.Auth.SingleTenant.Interfaces.Services.IAccountService _accountService;
        readonly IRoleService _roleService;
        readonly ElasticSearchService _elasticSearchService;

        readonly IUserService _userService;
        public AgentService(IAgentRepository agentRepository,
            IUnitOfWork iUnitOfWork,
            Common.Auth.SingleTenant.Interfaces.Services.IAccountService accountService,
            IRoleService roleService,
            IUserService userService,
            IElasticSearchSettings elasticsearchsettings)
        {
            _agentRepository = agentRepository;
            _iUnitOfWork = iUnitOfWork;
            _accountService = accountService;
            _roleService = roleService;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _userService = userService;
        }
        public IList<Agent> GetAllAgentsByUserId(long userId, IList<int> permissionCodes)
        {
            if (PermissionChecker.CheckPermission(permissionCodes, Entities.Enum.PermissionCodes.ViewAgent))
                return _agentRepository.GetAllAgentsByUserId(userId);

            throw new UnauthorizedAccessException();
        }

        public IList<Agent> GetAllAgents()
        {
            return _agentRepository.GetAllAgents();
        }
        public Agent GetAgent(long id)
        {
            return _agentRepository.GetAgent(id);
        }
        public Agent GetAgentByUserId(long userId)
        {
            return _agentRepository.GetAgentByUserId(userId);
        }

        public bool CreateAgent(AgentModel agentmodel)
        {
            if (agentmodel.IsListingMember)
            {
                var password = Guid.NewGuid().ToString("N");
                var roles = _roleService.GetAllRoles().Where(p => p.Name == "User").ToArray();
                var roleIds = new long[roles.Count()];
                for (int i = 0; i < roles.Count(); i++)
                {
                    roleIds[i] = roles[i].Id;
                }
                var user = _userService.GetUserByUsername(agentmodel.Email);
                if (user == null)
                {
                    user = _accountService.CreateAccount(agentmodel.FirstName + " " + agentmodel.LastName, agentmodel.Email, password, roleIds);
                    BackgroundJob.Enqueue(() => EmailHelper.SendEmailForRegistration(agentmodel.FirstName + " " + agentmodel.LastName, agentmodel.Email, agentmodel.Phone, password));
                }
                agentmodel.UserId = user.Id;
            }
            agentmodel.CommunicationDetailID = agentmodel.CommunicationDetailID;
            var agentCount = _agentRepository.GetAgentCountByUser(agentmodel.CreatedBy);
            var agent = new Agent
            {
                CommunicationDetailId = agentmodel.CommunicationDetailID,
                DEDLicenseNumber = agentmodel.DEDLicenseNumber,
                FirstName = agentmodel.FirstName,
                LastName = agentmodel.LastName,
                Image = agentmodel.Image,
                IsListingMember = agentmodel.IsListingMember,
                RERARegistrationNumber = agentmodel.RERARegistrationNumber,
                UserId = agentmodel.UserId,
                CreatedBy = agentmodel.CreatedBy,
                RefId = "A" + (++agentCount),
                CreatedOn = DateTimeOffset.UtcNow
            };
            _agentRepository.Create(agent);
            _elasticSearchService.IndexAgent(agentmodel);
            _iUnitOfWork.Commit();
            return true;
        }
        public bool DeleteAgent(long id)
        {
            var agent = _agentRepository.GetAgent(id);
            if (agent.UserId.HasValue)
            {
                _accountService.DeleteAccount(agent.UserId.Value);
                _agentRepository.Delete(agent.UserId.Value);

            }
            var agentModel = new AgentModel
            {
                FirstName = agent.FirstName,
                LastName = agent.LastName,
                Address = agent.CommunicationDetail.Address,
                CommunicationDetailID = agent.CommunicationDetailId,
                CreatedBy = agent.CreatedBy,
                Email = agent.CommunicationDetail.Email,
                DEDLicenseNumber = agent.DEDLicenseNumber,
                Id = agent.Id,
                Image = agent.Image,
                Phone = agent.CommunicationDetail.Phone,
                IsListingMember = agent.IsListingMember,
                RERARegistrationNumber = agent.RERARegistrationNumber,
                UserId = agent.UserId
            };
            agent.DeletedOn = DateTimeOffset.UtcNow;
            _agentRepository.Update(agent);
            _elasticSearchService.DeleteAgent(agentModel);
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdateAgent(AgentModel agentmodel)
        {
            var agent = _agentRepository.GetBy(i => i.Id == agentmodel.Id);
            if (agent != null)
            {
                agent.CommunicationDetailId = agentmodel.CommunicationDetailID;
                agent.DEDLicenseNumber = agentmodel.DEDLicenseNumber;
                agent.FirstName = agentmodel.FirstName;
                agent.Image = agentmodel.Image;
                agent.IsListingMember = agentmodel.IsListingMember;
                agent.LastName = agentmodel.LastName;
                agent.RERARegistrationNumber = agentmodel.RERARegistrationNumber;
                _agentRepository.Update(agent);
                _elasticSearchService.UpdateAgent(agentmodel);
                _iUnitOfWork.Commit();
                return true;
            }

            return false;
        }

        public SearchResult<Agent> SearchAgent(AgentSearchFilter searchargument, int pagesize, int page)
        {
            return _agentRepository.SearchAgent(searchargument, pagesize, page);
        }
    }
}
