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
        readonly ICRMLiteContactService _contactService;
        readonly IPersonService _personService;
        readonly PropznetCommon.Features.CRM.Interfaces.Services.IAccountService _accountService;
        readonly IUserService _userService;
        readonly ICountryService _countryService;
        public ContactApiController(ICRMLiteContactService contactService, PropznetCommon.Features.CRM.Interfaces.Services.IAccountService accountService,
            IUserService userService,ICountryService countryService,IPersonService personService)
        {
            _contactService = contactService;
            _accountService = accountService;
            _userService = userService;
            _personService = personService;
            _countryService = countryService;
        }
        [HttpGet]
        public ActionResult GetAllContacts()
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
          {
                  if (!RoleChecker.CheckRole(WebUser.RoleId, RoleIds.Admin))
                  {
                      var contacts = _contactService.GetAllContacts();
                      var accounts = _accountService.GetAllAccounts();
                      var users = _userService.GetAllUsers();
                      var returnData = new { Contacts = contacts, Accounts = accounts, Users = users };
                      return returnData;

                  }
                  else
                  {
                      var contacts = _contactService.GetAllContactsByUserId(WebUser.Id, WebUser.PermissionCodes);
                      var accounts = _accountService.GetAllAccounts();
                      var users = _userService.GetAllUsers();
                      var returnData = new { Contacts = contacts, Accounts = accounts, Users = users };
                      return returnData;
                  }
          }));
        }
        [HttpGet]
        public ActionResult GetAllCountries()
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
          {
              var result = _countryService.GetAllCountries();
              return result;
          }));
        }
        [HttpPost]
        public ActionResult DeleteContact(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var contactStatus = _contactService.DeleteContact(id);
                return contactStatus;
            }));
        }
        [HttpGet]
        public ActionResult GetContact(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
          {
            var contact = _contactService.GetContact(id);
            return contact;
          }));
        }
        [HttpPost]
        public ActionResult CreateContact(ContactModel contactModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                contactModel.CreatedBy = WebUser.Id;
               var result= _contactService.CreateContact(contactModel);
               return result;
            }));
        }
        [HttpPost]
        public ActionResult UpdateContact(ContactModel contactModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
           {
               var result = _contactService.UpdateContact(contactModel);
               return result;
           }));
        }
        [HttpPost]
        public ActionResult Search(ContactSearchFilter contactSearchFilter)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
         {
             contactSearchFilter.UserId = WebUser.Id;
             var searchContact = _contactService.Search(contactSearchFilter, 0, 0);
             return searchContact.Items;
         }));
        }
    }
}