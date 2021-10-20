using System;
using System.Collections.Generic;
using System.Linq;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.ElasticSearch;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Agent;
using IAccountService = Common.Auth.SingleTenant.Interfaces.Services.IAccountService;
using Common.Auth.SingleTenant.Interfaces.DAL;

namespace PropznetCommon.Features.CRM.Services
{
    public class AgentInfoService : IAgentInfoService
    {
        readonly IAgentInfoRepository _agentInfoRepository;
        readonly IUnitOfWork _iUnitOfWork;
        readonly IAccountService _accountService;
        readonly IRoleService _roleService;
        readonly ElasticSearchService _elasticSearchService;
        readonly IPersonService _personService;
        readonly IPersonRepository _personRepository;

        readonly IUserService _userService;
        public AgentInfoService(IAgentInfoRepository agentRepository,
            IUnitOfWork iUnitOfWork,
            IAccountService accountService,
            IPersonService personService,
            IPersonRepository personRepository,
            IRoleService roleService,
            IUserService userService,
            IElasticSearchSettings elasticsearchsettings)
        {
            _agentInfoRepository = agentRepository;
            _iUnitOfWork = iUnitOfWork;
            _accountService = accountService;
            _roleService = roleService;
            _personService = personService;
            _personRepository = personRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _userService = userService;
        }
        public IList<AgentInfo> GetAllAgentInfosByUserId(long userId, IList<int> permissionCodes)
        {
            return _agentInfoRepository.GetAllAgentInfoByUserId(userId);
        }
        public IList<AgentInfo> GetAllAgentInfos()
        {
            return _agentInfoRepository.GetAllAgentInfo();
        }
        public AgentInfo GetAgentInfo(long id)
        {
            return _agentInfoRepository.GetAgentInfo(id);
        }
        public AgentInfo GetAgentInfoByUserId(long userId)
        {
            return _agentInfoRepository.GetAgentInfoByUserId(userId);
        }
        public bool CreateAgentInfo(AgentInfoModel agentmodel)
        {
            //if (agentmodel.IsListingMember)
            //{
                var password = Guid.NewGuid().ToString("N");
                var roleIds = new long[] { 2, 3 };
                var user = _userService.GetUserByUsername(agentmodel.Email);
                if (user == null)
                {
                    //user = _accountService.CreateAccount(agentmodel.FirstName + " " + agentmodel.LastName, agentmodel.Email, password, roleIds, agentmodel.IsListingMember);
                    user = _accountService.CreateAccount(agentmodel.FirstName, agentmodel.LastName, agentmodel.Email, password, roleIds, agentmodel.Phone, agentmodel.Address, agentmodel.Image, agentmodel.IsListingMember);
                    //BackgroundJob.Enqueue(() => EmailHelper.SendEmailForRegistration(agentmodel.FirstName + " " + agentmodel.LastName, agentmodel.Email, agentmodel.Phone, password));

                    //var person = _personService.GetPersonById(agentmodel.PersonId);
                    //person.FirstName = agentmodel.FirstName;
                    //person.LastName = agentmodel.LastName;
                    //person.Avatar = agentmodel.Image;
                    //_personRepository.Update(person);
                //}
                agentmodel.UserId = user.Id;
                agentmodel.PersonId = user.PersonId;
            }

            var agentCount = _agentInfoRepository.GetAgentInfoCountByUser(agentmodel.CreatedBy);
            var agentInfo = new AgentInfo
            {
                DEDLicenseNumber = agentmodel.DEDLicenseNumber,
                IsListingMember = agentmodel.IsListingMember,
                RERARegistrationNumber = agentmodel.RERARegistrationNumber,
                CreatedByUserId = agentmodel.CreatedBy,
                RefId = "A" + (++agentCount),
                CreatedOn = DateTime.UtcNow
            };
            if (agentmodel.UserId.HasValue)
            {
                agentInfo.UserId = agentmodel.UserId;
            }
            _agentInfoRepository.Create(agentInfo);
            _elasticSearchService.IndexAgent(agentmodel);
            _iUnitOfWork.Commit();
            return true;
        }
        public bool DeleteAgentInfo(long id)
        {
            var agentInfo = _agentInfoRepository.GetAgentInfo(id);
            bool result;
            try
            {
                if (agentInfo != null)
                {
                    var agentModel = new AgentInfoModel
                    {
                        FirstName = agentInfo.User.Person.FirstName,
                        LastName = agentInfo.User.Person.LastName,
                        Address = agentInfo.User.Person.Address,
                        PersonId = agentInfo.User.PersonId,
                        CreatedBy = agentInfo.CreatedByUserId,
                        Email = agentInfo.User.Person.Email,
                        DEDLicenseNumber = agentInfo.DEDLicenseNumber,
                        Id = agentInfo.Id,
                        Image = agentInfo.User.Person.Avatar,
                        Phone = agentInfo.User.Person.PhoneNo,
                        IsListingMember = agentInfo.IsListingMember,
                        RERARegistrationNumber = agentInfo.RERARegistrationNumber,
                        UserId = agentInfo.UserId
                    };
                    _elasticSearchService.DeleteAgent(agentModel);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (agentInfo.UserId.HasValue)
                {
                    _accountService.DeleteAccount(agentInfo.UserId.Value);
                }
                   result= _agentInfoRepository.DeleteAgentInfo(id);
                    _iUnitOfWork.Commit();
            }
            return result;
        }
        public bool UpdateAgentInfo(AgentInfoModel agentmodel)
        {
            var agent = _agentInfoRepository.GetBy(i => i.Id == agentmodel.Id);
            if (agent != null)
            {
                agent.DEDLicenseNumber = agentmodel.DEDLicenseNumber;
                agent.IsListingMember = agentmodel.IsListingMember;
                agent.RERARegistrationNumber = agentmodel.RERARegistrationNumber;
                _agentInfoRepository.Update(agent);
                _iUnitOfWork.Commit();
                _elasticSearchService.UpdateAgent(agentmodel);

                //var person = _personRepository.GetPersonById(agentmodel.PersonId);
                //person.FirstName = agentmodel.FirstName;
                //person.Avatar = agentmodel.Image;
                //person.LastName = agentmodel.LastName;
                //_personRepository.Update(person);
                _accountService.UpdateAccount(agentmodel.FirstName, agentmodel.LastName, agentmodel.Email, agentmodel.UserId.Value, agentmodel.Phone, agentmodel.Address, agentmodel.Image, agentmodel.IsListingMember);
                return true;
            }

            return false;
        }
        public SearchResult<AgentInfo> SearchAgentInfo(AgentSearchFilter searchargument, int pagesize, int page)
        {
            return _agentInfoRepository.SearchAgentInfo(searchargument, pagesize, page);
        }
    }
}