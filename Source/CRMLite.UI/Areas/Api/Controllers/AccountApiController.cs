using System.Web.Mvc;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Account;
using PropznetCommon.Features.CRM.Model.CommunicationDetail;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Auth.SingleTenant.Models;
using CRMLite.Core.Models;
using System.Linq;
using System;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class AccountApiController : BaseApiController
    {
        readonly PropznetCommon.Features.CRM.Interfaces.Services.IAccountService _accountService;
        readonly IUserService _userService;
        readonly IPersonService _personDetailService;
        public AccountApiController(PropznetCommon.Features.CRM.Interfaces.Services.IAccountService accountService, IUserService userService, IPersonService personService)
        {
            _accountService = accountService;
            _userService = userService;
            _personDetailService = personService;
        }
        public ActionResult GetAllAccounts()
        {
            return ThrowIfNotLoggedIn(() => TryExecute(() =>
            {
                if (!WebUser.IsInRole("Admin"))
                {
                    var users = _userService.GetAllUserByCreatedUserId(WebUser.Id);
                    var accounts = _accountService.GetAllAccountsByUserId(WebUser.Id, WebUser.PermissionCodes);

                    var result = new AccountResult { Account = accounts, User = users };
                    return result;
                }
                else
                {
                    var Users = _userService.GetAllUsers().ToList();
                    var accounts = _accountService.GetAllAccounts();
                    var result = new AccountResult { Account = accounts, User = Users };
                    return result;
                }
            }));

        }
        public ActionResult CreateAccount(AccountModel accountModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecute(() =>
            {
                if (_accountService.CheckAccountExist(accountModel.AccountName))
                {
                    throw new Exception("Account with same name already exist, try another name");
                }
                accountModel.CreatedByUserId = WebUser.Id;
                var result = _accountService.CreateAccount(accountModel);
                return result;
            }));
        }
        public ActionResult GetAccount(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecute(() =>
            {
                var result = _accountService.GetAccount(id);
                return result;
            }));
        }
        public ActionResult UpdateAccount(AccountModel accountModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecute(() =>
            {
                var personModel = new PersonModel
                {
                    Id = accountModel.PersonId,
                    Address = accountModel.Address,
                    Email = accountModel.Email,
                    PhoneNo = accountModel.Phone,
                    Website = accountModel.Website
                };
                _personDetailService.UpdatePerson(personModel);
                var result = _accountService.UpdateAccount(accountModel);
                return result;
            }));
        }
        public ActionResult Search(AccountSearchFilter accountSearchFilter)
        {
            return ThrowIfNotLoggedIn(() => TryExecute(() =>
           {
               accountSearchFilter.UserId = WebUser.Id;
               var result = _accountService.Search(accountSearchFilter, 0, 0);
               return result.Items ;
           }));
        }
        public ActionResult DeleteAccount(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecute(() =>
            {
                var deleteStatus = _accountService.DeleteAccount(id);
                return deleteStatus ;
            }));
        }
    }
}