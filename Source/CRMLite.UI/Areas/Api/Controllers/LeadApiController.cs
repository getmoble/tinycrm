using System.Web.Mvc;
using Newtonsoft.Json;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Account;
using PropznetCommon.Features.CRM.Model.CommunicationDetail;
using PropznetCommon.Features.CRM.Model.Contact;
using PropznetCommon.Features.CRM.Model.Lead;
using PropznetCommon.Features.CRM.Model.Potential;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Auth.SingleTenant.Models;
using CRMLite.Core.Models;
using System.Linq;
using System;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class LeadApiController : BaseApiController
    {
        readonly ILeadService _leadService;
        readonly IPersonService _personDetailService;
        readonly IUserService _userService;
        readonly ILeadSourceService _leadSourceService;
        readonly ILeadStatusService _leadStatusService;
        readonly ISalesStageService _salesStageService;
        readonly PropznetCommon.Features.CRM.Interfaces.Services.IAccountService _accountService;
        readonly ICRMLiteContactService _contactServise;
        readonly IPotentialService _potentialService;
        public LeadApiController(ILeadService leadService,
            IPersonService personDetailService, IUserService userService
            , ILeadSourceService leadSourceService, ILeadStatusService leadStatusService,
            ISalesStageService salesStageService, PropznetCommon.Features.CRM.Interfaces.Services.IAccountService accountService, ICRMLiteContactService contactService,
            IPotentialService potentialService)
        {
            _leadService = leadService;
            _personDetailService = personDetailService;
            _userService = userService;
            _leadSourceService = leadSourceService;
            _leadStatusService = leadStatusService;
            _salesStageService = salesStageService;
            _accountService = accountService;
            _contactServise = contactService;
            _potentialService = potentialService;
        }
        [HttpGet]
        public JsonResult GetData()
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
           {
               var User = _userService.GetAllUsers().ToList();
               var leadsource = _leadSourceService.GetAllLeadSources();
               var leadstatus = _leadStatusService.GetAllLeadStatuses();
               var salesstage = _salesStageService.GetAllSalesStages();
               var result = new LeadResult { User = User, LeadStatus = leadstatus, LeadSource = leadsource, SalesStage = salesstage };
               return result;
           }));
        }
        [HttpGet]
        public JsonResult Index()
        {
            return ThrowIfNotLoggedIn(() => TryExecute(() =>
            {
                 var leadlist = _leadService.GetAllLeadsByUserId(WebUser.Id, WebUser.PermissionCodes);
                 var output = JsonConvert.SerializeObject(leadlist, Formatting.None, new JsonSerializerSettings()
                 {
                     ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                 });
     
                var apiResult = new ApiResult<string>
                {
                    Status = true,
                    Message = "Success",
                    Result = output
                };
                return Json(apiResult, JsonRequestBehavior.AllowGet);

            },
            error =>{
                
                var apiResult = new ApiResult<string>
                {
                    Status = false,
                    Message = "Fail",
                    Result = ""
                };
                return Json(apiResult);

            }));
        }
        [HttpPost]
        public JsonResult DeleteLead(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var result = _leadService.DeleteLead(id);
                return result;
            }));
        }
        [HttpGet]
        public JsonResult GetLead(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var lead = _leadService.GetLead(id);
                return lead;
            }));
        }
        [HttpPost]
        public JsonResult Create(LeadModel leadModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                leadModel.CreatedBy = WebUser.Id;
                var lead = _leadService.CreateLead(leadModel);
                return lead;
            }));
        }
        [HttpPost]
        public JsonResult Update(LeadModel leadModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                _leadService.UpdateLead(leadModel);
                return Json(true);
            }));
        }
        [HttpPost]
        public JsonResult Search(LeadSearchFilter leadSearch)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var searchresult = _leadService.SearchLeads(leadSearch, 0, 0);
                return searchresult.Items;
            }));
        }
        [HttpGet]
        public JsonResult GetConvertLead(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var leaddetail = _leadService.GetLead(id);
                return leaddetail;
            }));
        }
        [HttpPost]
        public JsonResult ConvertLead(ConvertLeadModel convertLeadModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                if (_accountService.CheckAccountExist(convertLeadModel.AccountName))
                {
                    throw new Exception("Account with same name already exist, try another name");
                }
                var account = new AccountModel
                {
                    SelectedAssignedto = convertLeadModel.selectedAssignedTo,
                    PersonId = convertLeadModel.CommunicationDetailId,
                    AccountName = convertLeadModel.AccountName
                };
                var createAccount = _accountService.CreateAccount(account);
                var contact = new ContactModel
                {
                    //AccountId = createAccount.Id,
                    //UserId = convertLeadModel.selectedAssignedTo,
                    CommunicationDetailId = convertLeadModel.CommunicationDetailId,
                    FirstName = convertLeadModel.FirstName,
                    LastName = convertLeadModel.LastName
                };
                var createContact = _contactServise.CreateContact(contact);
                if (!convertLeadModel.IsChecked)
                {
                    var potential = new PotentialModel
                    {
                        PotentialName = convertLeadModel.PotentialName,
                        AccountId = createAccount.Id,
                        selectedAssignedTo = convertLeadModel.selectedAssignedTo,
                        ExpectedCloseDate = convertLeadModel.ExpectedDate,
                        PotentialAmount = convertLeadModel.PotentialAmount,
                        SelectedSalesStage = convertLeadModel.SelectedSalesStage,
                        SelectedContact = createContact.Id,
                        SelectedLeadSource = convertLeadModel.SelectedLeadSource
                    };
                    _potentialService.CreatePotential(potential, SiteSettings.Leadprefix);
                }
                var result=_leadService.DeleteLead(convertLeadModel.Id);
                return result;
            }));
        }
    }
}