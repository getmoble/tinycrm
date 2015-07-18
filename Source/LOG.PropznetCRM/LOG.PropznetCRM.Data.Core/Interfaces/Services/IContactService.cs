using System.Collections.Generic;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Contact;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IContactService
    {
        Contact CreateContact(ContactModel contact);
        bool UpdateContact(ContactModel contactmodel);
        Contact GetContact(long id);
        IList<Contact> GetAllContactsByUserId(long userId, IList<int> permissionCodes);
        IList<Contact> GetAllContacts();
        SearchResult<Contact> Search(ContactSearchFilter filters, int pageSize, int page);
        bool DeleteContact(long id);
    }
}
