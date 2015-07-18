using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Infrastructure;
using LOG.PropznetCRM.Data.Model.Account;
using LOG.PropznetCRM.Data.Model.CommunicationDetail;
using LOG.PropznetCRM.Data.Model.Contact;
using LOG.PropznetCRM.Data.Model.Lead;
using LOG.PropznetCRM.Data.Model.Potential;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.UI.Areas.Api.Controllers
{
    public class LeadApiController : CRMBaseController
    {
        readonly ILeadService _leadService;
        readonly ICommunicationDetailService _communicationDetailService;
        readonly IAgentService _agentService;
        readonly ILeadSourceService _leadSourceService;
        readonly ILeadStatusService _leadStatusService;
        readonly ISalesStageService _salesStageService;
        readonly IAccountService _accountService;
        readonly IContactService _contactServise;
        readonly IPotentialService _potentialService;
        public LeadApiController(ILeadService leadService,
            ICommunicationDetailService communicationDetailService, IAgentService agentService
            , ILeadSourceService leadSourceService, ILeadStatusService leadStatusService,
            ISalesStageService salesStageService, IAccountService accountService, IContactService contactService,
            IPotentialService potentialService)
        {
            _leadService = leadService;
            _communicationDetailService = communicationDetailService;
            _agentService = agentService;
            _leadSourceService = leadSourceService;
            _leadStatusService = leadStatusService;
            _salesStageService = salesStageService;
            _accountService = accountService;
            _contactServise = contactService;
            _potentialService = potentialService;
        }
        public ActionResult GetData()
        {
            var agent = _agentService.GetAllAgents();
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
               return View();
           },
           error => View());
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
            var communicationDetailModel = new CommunicationDetailModel
            {
                Email = leadModel.Email,
                Phone = leadModel.Phone,
                Website = leadModel.Website
            };
            var communicationDetailId = _communicationDetailService.CreateCommunicationDetail(communicationDetailModel);
            leadModel.CommunicationDetailID = communicationDetailId;
            leadModel.CreatedBy = WebUser.Id;
            var lead = _leadService.CreateLead(leadModel);
            return Json(lead);
        }
        [HttpPost]
        public ActionResult Update(LeadModel leadModel)
        {
            var communicationDetailModel = new CommunicationDetailModel
            {
                Id = leadModel.CommunicationDetailID,
                Email = leadModel.Email,
                Phone = leadModel.Phone,
                Website = leadModel.Website
            };
            var communicationDetailId = _communicationDetailService.UpdateCommunicationDetail(communicationDetailModel);
            leadModel.CommunicationDetailID = communicationDetailId;
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
                CommunicationDetailId = convertLeadModel.CommunicationDetailId,
                AccountName = convertLeadModel.AccountName
            };
            var createAccount = _accountService.CreateAccount(account);
            var contact = new ContactModel
            {
                AccountId = createAccount.Id,
                AgentId = convertLeadModel.selectedAssignedTo,
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
                _potentialService.CreatePotential(potential);
            }
            _leadService.DeleteLead(convertLeadModel.Id);
            return Json(true);
        }

    }
}