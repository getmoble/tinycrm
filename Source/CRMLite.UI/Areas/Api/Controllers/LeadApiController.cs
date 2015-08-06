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
        public ActionResult GetData()
        {
            var agent = _userService.GetAllUsers();
            var leadsource = _leadSourceService.GetAllLeadSources();
            var leadstatus = _leadStatusService.GetAllLeadStatuses();
            var salesstage = _salesStageService.GetAllSalesStages();
            var returnData = new { Agent = agent, LeadStatus = leadstatus, LeadSource = leadsource, SalesStage = salesstage };
            return Json(returnData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return ExecuteIfValid(() =>
            {
                var leadlist = _leadService.GetAllLeadsByUserId(WebUser.Id, WebUser.PermissionCodes);
                var output = JsonConvert.SerializeObject(leadlist);
                return Json(output, JsonRequestBehavior.AllowGet);
            },
           () =>
           {
               return Json(false, JsonRequestBehavior.AllowGet);
           },
            error =>
            {
                return Json(false, JsonRequestBehavior.AllowGet);                    
            });
        }
        public ActionResult DeleteLead(long id)
        {
            var deletelead = _leadService.DeleteLead(id);
            return Json(deletelead, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLead(long id)
        {
            var lead = _leadService.GetLead(id);
            return Json(lead, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(LeadModel leadModel)
        {
            var personModel = new PersonModel
            {
                Email = leadModel.Email,
                PhoneNo = leadModel.Phone,
                Website = leadModel.Website
            };
            var communicationDetailId = _personDetailService.CreatePerson(personModel);
            leadModel.CommunicationDetailID = communicationDetailId.Id;
            leadModel.CreatedBy = WebUser.Id;
            var lead = _leadService.CreateLead(leadModel);
            return Json(lead);
        }
        [HttpPost]
        public ActionResult Update(LeadModel leadModel)
        {
            var personModel = new PersonModel
            {
                Id = leadModel.CommunicationDetailID,
                Email = leadModel.Email,
                PhoneNo = leadModel.Phone,
                Website = leadModel.Website
            };
            var person = _personDetailService.UpdatePerson(personModel);
            leadModel.CommunicationDetailID = person.Id;
            _leadService.UpdateLead(leadModel);
            return Json(true);
        }
        [HttpPost]
        public ActionResult Search(LeadSearchFilter leadSearch)
        {
            leadSearch.UserId = WebUser.Id;
            var searchresult = _leadService.SearchLeads(leadSearch, 0, 0);
            return Json(JsonConvert.SerializeObject(searchresult.Items));
        }
        public ActionResult GetConvertLead(long id)
        {
            var leaddetail = _leadService.GetLead(id);
            return Json(leaddetail, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ConvertLead(ConvertLeadModel convertLeadModel)
        {
            if (_accountService.CheckAccountExist(convertLeadModel.AccountName))
            {
                return Json("Account with same name already exist, try another name", JsonRequestBehavior.AllowGet);
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
                //AgentId = convertLeadModel.selectedAssignedTo,
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
            _leadService.DeleteLead(convertLeadModel.Id);
            return Json(true);
        }
    }
}