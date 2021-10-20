using System.Collections.Generic;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Contact;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface ICRMLiteContactService
    {
        Contact CreateContact(ContactModel contact);
        bool UpdateContact(ContactModel contactmodel);
        Contact GetContact(long id);
        IList<Contact> GetAllContacts();
        SearchResult<Contact> Search(ContactSearchFilter filters, int pageSize, int page);
        IList<Contact> GetAllContactsByUserId(long userId, IList<int> permissionCodes);
        bool DeleteContact(long id);
    }
}
