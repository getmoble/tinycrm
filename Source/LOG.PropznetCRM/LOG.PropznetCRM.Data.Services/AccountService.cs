using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Core;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.ElasticSearch;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Entities.Enum;
using LOG.PropznetCRM.Data.Model.Account;
using System;
using System.Collections.Generic;

namespace LOG.PropznetCRM.Data.Services
{
    public class AccountService : IAccountService
    {
        readonly IAccountRepository _accountRepository;
        readonly IUnitOfWork _iUnitOfWork;
        readonly ElasticSearchService _elasticSearchService;
        readonly IAgentService _agentService;
        public AccountService(IAccountRepository accountRepository, IUnitOfWork iUnitOfWork, IElasticSearchSettings elasticsearchsettings, IAgentService agentService)
        {
            _accountRepository = accountRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _iUnitOfWork = iUnitOfWork;
            _agentService = agentService;
        }
        public Account CreateAccount(AccountModel accountmodel)
        {
            if (accountmodel != null)
            {
                var accountCount = _accountRepository.GetAccountCountByUser(accountmodel.CreatedBy);
                var account = new Account
                {
                    AgentId = accountmodel.SelectedAssignedto,
                    CommunicationDetailId = accountmodel.CommunicationDetailId,
                    Name = accountmodel.AccountName,
                    Comments = accountmodel.Comment,
                    Industry = accountmodel.Industry,
                    CreatedBy = accountmodel.CreatedBy,
                    RefId = "Ac" + (++accountCount),
                    CreatedOn = DateTimeOffset.UtcNow
                };
                var accountResult = _accountRepository.Create(account);
                _iUnitOfWork.Commit();
                accountmodel.Id = accountResult.Id;
                _elasticSearchService.IndexAccount(accountmodel);
                return accountResult;
            }
            
            return null;
        }

        public bool UpdateAccount(AccountModel accountmodel)
        {
            if (accountmodel != null)
            {
                var account = _accountRepository.Get(accountmodel.Id);
                if (account != null)
                {
                    account.AgentId = accountmodel.SelectedAssignedto;
                    account.CommunicationDetailId = accountmodel.CommunicationDetailId;
                    account.Name = accountmodel.AccountName;
                    account.Comments = accountmodel.Comment;
                    account.Industry = accountmodel.Industry;
                    _accountRepository.Update(account);

                    _elasticSearchService.UpdateAccount(accountmodel);
                    _iUnitOfWork.Commit();
                    return true;
                }
                
                return false;
            }
            
            return false;
        }

        public Account GetAccount(long id)
        {
            var account = _accountRepository.GetAccount(id);
            return account;
        }
        public IList<Account> GetAllAccountsByUserId(long userId, IList<int> permissionCodes)
        {
            if (PermissionChecker.CheckPermission(permissionCodes, PermissionCodes.ViewAccount))
            {
                var agent = _agentService.GetAgentByUserId(userId);
                return _accountRepository.GetAllAccountsByUserId(userId, agent.Id);
            }
            
            throw new UnauthorizedAccessException();
        }

        public IList<Account> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts();
        }
        public SearchResult<Account> Search(AccountSearchFilter searchargument, int pagesize, int count)
        {
            return _accountRepository.SearchAccount(searchargument, pagesize, count);
        }
        public bool DeleteAccount(long id)
        {
            var account = _accountRepository.GetAccount(id);
            {
                account.DeletedOn = DateTime.Now;
            }

            var accountModel = new AccountModel
            {
                AccountName = account.Name,
                Address = account.CommunicationDetail.Address,
                Comment = account.Comments,
                CommunicationDetailId = account.CommunicationDetailId,
                CreatedBy = account.CreatedBy,
                Email = account.CommunicationDetail.Email,
                Enitytype = EntityType.Account,
                Id = account.Id,
                Industry = account.Industry,
                Phone = account.CommunicationDetail.Phone,
                SelectedAssignedto = account.Agent.Id,
                Website = account.CommunicationDetail.Website
            };
            _accountRepository.Update(account);
            _iUnitOfWork.Commit();
            _elasticSearchService.DeleteAccount(accountModel);
            return true;
        }

        public bool CheckAccountExist(string accountname)
        {
            return _accountRepository.CheckAccountExist(accountname);
        }
    }
}