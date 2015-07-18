using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Contact;

namespace LOG.PropznetCRM.Data.Core.Interfaces.DAL
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        IList<Contact> GetAllContactsByUserId(long userId, long agentId);
        IList<Contact> GetAllContacts();
        Contact GetContact(long id);
        SearchResult<Contact> SearchContacts(ContactSearchFilter filter, int pageSize, int page);
        int GetContactCountByUser(long userId);
    }
}
