using System.Web.Mvc;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.CommunicationDetail;
using PropznetCommon.Features.CRM.Model.Contact;
using CRMLite.Infrastructure.Enum;
using CRMLite.Infrastructure;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class ContactApiController : BaseApiController
    {
        readonly IContactService _contactService;
        readonly ICommunicationDetailService _communicationDetailService;
        readonly IAccountService _accountService;
        readonly IAgentService _agentService;
        readonly ILocationService _locationService;
        public ContactApiController(IContactService contactService, IAccountService accountService, IAgentService agentService,
            ICommunicationDetailService communicationDetailService, ILocationService locationService)
        {
            _contactService = contactService;
            _accountService = accountService;
            _agentService = agentService;
            _communicationDetailService = communicationDetailService;
            _locationService = locationService;
        }
        public ActionResult GetAllContacts()
        {
            return ExecuteIfValid(() =>
            {
                if (!RoleChecker.CheckRole(WebUser.RoleId, RoleIds.Admin))
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
                return Json(false, JsonRequestBehavior.AllowGet);
            },
            error =>
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            });
        }
        public ActionResult GetAllCountries()
        {
            var countries = _locationService.GetAllCountries();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllStates(long id)
        {
            var states = _locationService.GetAllStatesByCountry(id);
            return Json(states, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllCities(long id)
        {
            var cities = _locationService.GetAllCitiesByState(id);
            return Json(cities, JsonRequestBehavior.AllowGet);
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
                Phone = contactModel.Phone,

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