using System.Web.Mvc;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.CommunicationDetail;
using PropznetCommon.Features.CRM.Model.Contact;
using CRMLite.Infrastructure.Enum;
using CRMLite.Infrastructure;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Auth.SingleTenant.Models;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class ContactApiController : BaseApiController
    {
        readonly IContactService _contactService;
        readonly IPersonService _personService;
        readonly PropznetCommon.Features.CRM.Interfaces.Services.IAccountService _accountService;
        readonly IUserService _userService;
        //readonly ICountryService _locationService;
        public ContactApiController(IContactService contactService, PropznetCommon.Features.CRM.Interfaces.Services.IAccountService accountService, IUserService userService,
            IPersonService personService)
        {
            _contactService = contactService;
            _accountService = accountService;
            _userService = userService;
            _personService = personService;
            //_locationService = locationService;
        }
        public ActionResult GetAllContacts()
        {
            return ExecuteIfValid(() =>
            {
                if (!RoleChecker.CheckRole(WebUser.RoleId, RoleIds.Admin))
                {
                    var contacts = _contactService.GetAllContactsByUserId(WebUser.Id, WebUser.PermissionCodes);
                    var accounts = _accountService.GetAllAccounts();
                    var users = _userService.GetAllUsers();
                    var returnData = new { Contacts = contacts, Accounts = accounts, Users = users };
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var contacts = _contactService.GetAllContactsByUserId(WebUser.Id, WebUser.PermissionCodes);
                    var accounts = _accountService.GetAllAccounts();
                    var users = _userService.GetAllUsers();
                    var returnData = new { Contacts = contacts, Accounts = accounts, Users = users };
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
        //public ActionResult GetAllCountries()
        //{
        //    var countries = _locationService.GetAllCountries();
        //    return Json(countries, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult GetAllStates(long id)
        //{
        //    var states = _locationService.GetAllStatesByCountry(id);
        //    return Json(states, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult GetAllCities(long id)
        //{
        //    var cities = _locationService.GetAllCitiesByState(id);
        //    return Json(cities, JsonRequestBehavior.AllowGet);
        //}
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
            var person = new PersonModel
            {
                Address = contactModel.Address,
                Email = contactModel.Email,
                PhoneNo = contactModel.Phone

            };
            var newPerson = _personService.CreatePerson(person);
            contactModel.CommunicationDetailId = newPerson.Id;
            contactModel.CreatedBy = WebUser.Id;
            _contactService.CreateContact(contactModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateContact(ContactModel contactModel)
        {
            var person = new PersonModel
            {
                Id = contactModel.CommunicationDetailId,
                Address = contactModel.Address,
                Email = contactModel.Email,
                PhoneNo = contactModel.Phone
            };
            _personService.UpdatePerson(person);
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