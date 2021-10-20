using System;
using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.ElasticSearch;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Account;
using Common.Auth.SingleTenant.Entities;

namespace PropznetCommon.Features.CRM.Services
{
    public class AccountService : IAccountService
    {
        readonly IAccountRepository _accountRepository;
        readonly IUnitOfWork _iUnitOfWork;
        readonly ElasticSearchService _elasticSearchService;
        readonly Common.Auth.SingleTenant.Interfaces.Services.IPersonService _personService;
        readonly Common.Auth.SingleTenant.Interfaces.DAL.IPersonRepository _personRepository;
        public AccountService(IAccountRepository accountRepository, IUnitOfWork iUnitOfWork,
            IElasticSearchSettings elasticsearchsettings, 
            Common.Auth.SingleTenant.Interfaces.Services.IPersonService personService,
            Common.Auth.SingleTenant.Interfaces.DAL.IPersonRepository personRepository)
        {
            _accountRepository = accountRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _iUnitOfWork = iUnitOfWork;
            _personService = personService;
            _personRepository = personRepository;
        }
        public Account CreateAccount(AccountModel accountmodel)
        {
            if (accountmodel != null)
            {
                var accountCount = _accountRepository.GetAccountCountByUser(accountmodel.CreatedByUserId);
                var person = new Person
                {
                    Address = accountmodel.Address,
                    CreatedByUserId = accountmodel.CreatedByUserId,
                    CreatedOn = DateTime.UtcNow,
                    Email = accountmodel.Email,
                    FirstName = accountmodel.AccountName,
                    PhoneNo = accountmodel.Phone,
                    Website = accountmodel.Website
                };
                var createdPerson = _personRepository.Create(person);
                _iUnitOfWork.Commit();

                var account = new Account
                {
                    AssignedToUserId = accountmodel.SelectedAssignedto,
                    PersonId = createdPerson.Id,
                    Description = accountmodel.Description,
                    Industry = accountmodel.Industry,
                    CreatedByUserId = accountmodel.CreatedByUserId,
                    RefId = "Ac" + (++accountCount),
                    CreatedOn = DateTime.UtcNow
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
                var account = _accountRepository.GetAccount(accountmodel.Id);
                var person = _personService.GetPersonById(account.PersonId);
                if (account != null)
                {
                    //account update
                    account.AssignedToUserId = accountmodel.SelectedAssignedto;
                    account.Description = accountmodel.Description;
                    account.Industry = accountmodel.Industry;
                    _accountRepository.Update(account);

                    //person update
                    person.Address = accountmodel.Address;
                    person.UpdatedByUserId = accountmodel.CreatedByUserId;
                    person.UpdatedOn = DateTime.UtcNow;
                    person.Email = accountmodel.Email;
                    person.FirstName = accountmodel.AccountName;
                    person.PhoneNo = accountmodel.Phone;
                    person.Website = accountmodel.Website;

                    _personRepository.Update(person);
                    _iUnitOfWork.Commit();

                    _elasticSearchService.UpdateAccount(accountmodel);
                    return true;
                }
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
            return _accountRepository.GetAllAccountsByUserId(userId);
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
            var result = false;
            try
            {
                var accountModel = new AccountModel
                {
                    AccountName = account.Person.FirstName,
                    Address = account.Person.Address,
                    Description = account.Description,
                    PersonId = account.PersonId,
                    CreatedByUserId = account.CreatedByUserId,
                    Email = account.Person.Email,
                    Enitytype = CRMEntityType.Account,
                    Id = account.Id,
                    Industry = account.Industry,
                    Phone = account.Person.PhoneNo,
                    SelectedAssignedto = account.AssignedToUserId,
                    Website = account.Person.Website
                };
                _elasticSearchService.DeleteAccount(accountModel);
            }
            catch (Exception ex)
            { }
            finally
            {
                result = _accountRepository.DeleteAccount(id);
                _iUnitOfWork.Commit();
            }
            return result;
        }
        public bool CheckAccountExist(string accountname)
        {
            return _accountRepository.CheckAccountExist(accountname);
        }
    }
}