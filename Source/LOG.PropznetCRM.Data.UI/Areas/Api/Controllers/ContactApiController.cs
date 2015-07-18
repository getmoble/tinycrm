using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Infrastructure;
using LOG.PropznetCRM.Data.Model.CommunicationDetail;
using LOG.PropznetCRM.Data.Model.Contact;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.UI.Areas.Api.Controllers
{
    public class ContactApiController : CRMBaseController
    {
        readonly IContactService _contactService;
        readonly ICommunicationDetailService _communicationDetailService;
        readonly IAccountService _accountService;
        readonly IAgentService _agentService;
        public ContactApiController(IContactService contactService, IAccountService accountService, IAgentService agentService,
            ICommunicationDetailService communicationDetailService)
        {
            _contactService = contactService;
            _accountService = accountService;
            _agentService = agentService;
            _communicationDetailService = communicationDetailService;
        }
        public ActionResult GetAllContacts()
        {
            return ExecuteIfValid(() =>
            {
                if (!WebUser.IsInRole("Admin"))
                {
                    var contacts = _contactService.GetAllContactsByUserId(WebUser.Id, WebUser.PermissionCodes);
                    var accounts = _accountService.GetAllAccounts();
                    var agents = _agentService.GetAllAgents();
                    var returnData = new { Contacts = contacts, Accounts = accounts, Agents = agents };
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var contacts = _contactService.GetAllContactsByUserId(WebUser.Id, WebUser.PermissionCodes);
                    var accounts = _accountService.GetAllAccounts();
                    var agents = _agentService.GetAllAgents();
                    var returnData = new { Contacts = contacts, Accounts = accounts, Agents = agents };
                    return Json(returnData, JsonRequestBehavior.AllowGet);

                }
            },
            () =>
            {
                return View();
            },
            error =>
            {
                return View();
            });
        }
        public ActionResult DeleteContact(long id)
        {
            var contactStatus = _contactService.DeleteContact(id);
            return Json(contactStatus, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetContact(long id)
        {
            var contact = _contactService.GetContact(id);
            return Json(contact, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateContact(ContactModel contactModel)
        {
            var communicationDetail = new CommunicationDetailModel
            {
                Address = contactModel.Address,
                Email = contactModel.Email,
                Phone = contactModel.Phone
            };
            var createCommunicationDetails = _communicationDetailService.CreateCommunicationDetail(communicationDetail);
            contactModel.CommunicationDetailId = createCommunicationDetails;
            contactModel.CreatedBy = WebUser.Id;
            _contactService.CreateContact(contactModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateContact(ContactModel contactModel)
        {
            var communicationDetail = new CommunicationDetailModel
            {
                Id = contactModel.CommunicationDetailId,
                Address = contactModel.Address,
                Email = contactModel.Email,
                Phone = contactModel.Phone
            };
            _communicationDetailService.UpdateCommunicationDetail(communicationDetail);
            _contactService.UpdateContact(contactModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(ContactSearchFilter contactSearchFilter)
        {
            contactSearchFilter.UserId = WebUser.Id;
            var searchContact = _contactService.Search(contactSearchFilter, 0, 0);
            return Json(searchContact.Items, JsonRequestBehavior.AllowGet);
        }
    }
}