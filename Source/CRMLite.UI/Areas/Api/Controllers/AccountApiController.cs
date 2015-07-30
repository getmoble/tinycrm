using System.Web.Mvc;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Account;
using PropznetCommon.Features.CRM.Model.CommunicationDetail;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class AccountApiController : BaseApiController
    {
        readonly IAccountService _accountService;
        readonly IAgentService _agentService;
        readonly ICommunicationDetailService _communicationDetailService;
        public AccountApiController(IAccountService accountService, IAgentService agentService, ICommunicationDetailService communicationDetailService)
        {
            _accountService = accountService;
            _agentService = agentService;
            _communicationDetailService = communicationDetailService;
        }
        public ActionResult GetAllAccounts()
        {
            return ExecuteIfValid(() =>
            {
                if (!WebUser.IsInRole("Admin"))
                {
                    var agents = _agentService.GetAllAgentsByUserId(WebUser.Id, WebUser.PermissionCodes);
                    var accounts = _accountService.GetAllAccountsByUserId(WebUser.Id, WebUser.PermissionCodes);
                    var returnData = new { Account = accounts, Agent = agents };
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var agents = _agentService.GetAllAgents();
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

            var communicationDetailModel = new CommunicationDetailModel
            {
                Address = accountModel.Address,
                Email = accountModel.Email,
                Phone = accountModel.Phone,
                Website = accountModel.Website
            };
            var communicationDetailId = _communicationDetailService.CreateCommunicationDetail(communicationDetailModel);
            accountModel.CommunicationDetailId = communicationDetailId;
            accountModel.CreatedBy = WebUser.Id;
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
            var communicationDetailModel = new CommunicationDetailModel
            {
                Id = accountModel.CommunicationDetailId,
                Address = accountModel.Address,
                Email = accountModel.Email,
                Phone = accountModel.Phone,
                Website = accountModel.Website
            };
            _communicationDetailService.UpdateCommunicationDetail(communicationDetailModel);
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