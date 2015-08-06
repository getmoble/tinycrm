using System.Web.Mvc;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Account;
using PropznetCommon.Features.CRM.Model.CommunicationDetail;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Auth.SingleTenant.Models;

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
            return ExecuteIfValid(() =>
            {
                if (!WebUser.IsInRole("Admin"))
                {
                    var users = _userService.GetUserById(WebUser.Id);
                    var accounts = _accountService.GetAllAccountsByUserId(WebUser.Id, WebUser.PermissionCodes);
                    var returnData = new { Account = accounts, Agent = users };
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var agents = _userService.GetAllUsers();
                    var accounts = _accountService.GetAllAccounts();
                    var returnData = new { Account = accounts, Agent = agents };
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }
            },
             () =>
             {
                 return Json(false, JsonRequestBehavior.AllowGet);
             },
             error => {
                 return Json(false, JsonRequestBehavior.AllowGet);
             });
        }
        public ActionResult CreateAccount(AccountModel accountModel)
        {
            if (_accountService.CheckAccountExist(accountModel.AccountName))
            {
                return Json("Account with same name already exist, try another name", JsonRequestBehavior.AllowGet);
            }

            var personModel = new PersonModel
            {
                Address = accountModel.Address,
                Email = accountModel.Email,
                PhoneNo = accountModel.Phone,
                Website = accountModel.Website
            };
            var person = _personDetailService.CreatePerson(personModel);
            accountModel.PersonId = person.Id;
            accountModel.CreatedByUserId = WebUser.Id;
            _accountService.CreateAccount(accountModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAccount(long id)
        {
            var account = _accountService.GetAccount(id);
            return Json(account, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateAccount(AccountModel accountModel)
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
            _accountService.UpdateAccount(accountModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(AccountSearchFilter accountSearchFilter)
        {
            accountSearchFilter.UserId = WebUser.Id;
            var searchAccount = _accountService.Search(accountSearchFilter, 0, 0);
            return Json(searchAccount.Items, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteAccount(long id)
        {
            var deleteStatus = _accountService.DeleteAccount(id);
            return Json(deleteStatus, JsonRequestBehavior.AllowGet);
        }
    }
}