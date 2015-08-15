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
        [HttpGet]
        public JsonResult GetAllAccounts()
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                if (!WebUser.IsInRole("Admin"))
                {
                    var users = _userService.GetAllUserByCreatedUserId(WebUser.Id).ToList();
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
        [HttpPost]
        public JsonResult CreateAccount(AccountModel accountModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
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
          [HttpGet]
        public JsonResult GetAccount(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var result = _accountService.GetAccount(id);
                return result;
            }));
        }
          [HttpPost]
          public JsonResult UpdateAccount(AccountModel accountModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var result = _accountService.UpdateAccount(accountModel);
                return result;
            }));
        }
        [HttpPost]
          public JsonResult Search(AccountSearchFilter accountSearchFilter)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
           {
               accountSearchFilter.UserId = WebUser.Id;
               var result = _accountService.Search(accountSearchFilter, 0, 0);
               return result.Items ;
           }));
        }
        [HttpPost]
        public JsonResult DeleteAccount(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var deleteStatus = _accountService.DeleteAccount(id);
                return deleteStatus ;
            }));
        }
    }
}