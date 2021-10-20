using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Contact;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        IList<Contact> GetAllContactsByUserId(long userId);
        IList<Contact> GetAllContacts();
        Contact GetContact(long id);
        SearchResult<Contact> SearchContacts(ContactSearchFilter filter, int pageSize, int page);
        int GetContactCountByUser(long userId);
        bool DeleteContact(long id);
    }
}