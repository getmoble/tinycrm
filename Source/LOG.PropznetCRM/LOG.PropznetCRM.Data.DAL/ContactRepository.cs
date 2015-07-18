using Common.Data;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using LOG.PropznetCRM.Data.Model.Contact;
using Common.Data.Models;

namespace LOG.PropznetCRM.Data.DAL
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        readonly DataContext _dataContext;
        public ContactRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<Contact> GetAllContactsByUserId(long userId, long agentId)
        {
            return _dataContext.Contacts
                .Include(c => c.Account)
                                        .Include(c => c.Agent)
                                        .Include(c => c.CommunicationDetail)
                                        .Where(c => !c.DeletedOn.HasValue && c.CreatedBy == userId || c.AgentId == agentId).ToList();
        }
        public IList<Contact> GetAllContacts()
        {
            return _dataContext.Contacts
                    .Include(c => c.Account)
                                        .Include(c => c.Agent)
                                        .Include(c => c.CommunicationDetail)
                                        .Where(c => !c.DeletedOn.HasValue).ToList();
        }
        public Contact GetContact(long id)
        {
            return _dataContext.Contacts
                .Include(c => c.CommunicationDetail)
                .Include(c => c.Account)
                .Include(c => c.Agent)
                                        .SingleOrDefault(c => c.Id == id && !c.DeletedOn.HasValue);
        }
        public SearchResult<Contact> SearchContacts(ContactSearchFilter filters, int pageSize, int page)
        {
            var result = new SearchResult<Contact>();
            var query = _dataContext.Contacts
                                        .Include(p => p.Account).Include(p => p.Agent)
                                        .Include(p => p.CommunicationDetail);

            if (filters.AccountId.HasValue)
                query = query.Where(p => p.AccountId == filters.AccountId);

            if (filters.AgentId.HasValue)
                query = query.Where(p => p.AgentId == filters.AgentId);

            if (!String.IsNullOrEmpty(filters.Account))
                query = query.Where(p => p.Account.Name.Contains(filters.Account));

            if (!String.IsNullOrEmpty(filters.Address))
                query = query.Where(p => p.CommunicationDetail.Address.Contains(filters.Address));

            if (!String.IsNullOrEmpty(filters.Email))
                query = query.Where(p => p.CommunicationDetail.Email.Contains(filters.Email));

            if (!String.IsNullOrEmpty(filters.FirstName))
                query = query.Where(p => p.FirstName.Contains(filters.FirstName));

            if (!String.IsNullOrEmpty(filters.LastName))
                query = query.Where(p => p.LastName.Contains(filters.LastName));

            if (!String.IsNullOrEmpty(filters.Phone))
                query = query.Where(p => p.CommunicationDetail.Phone.Contains(filters.Phone));

            if (!String.IsNullOrEmpty(filters.Title))
                query = query.Where(p => p.Title.Contains(filters.Title));
            if (filters.UserId.HasValue)
                query = query.Where(p => p.CreatedBy == filters.UserId);
            if (pageSize == 0 || page == 0)
                result.Items = query.OrderBy(p => p.FirstName).ToList();
            else
                result.Items = query
                    .OrderBy(p => p.FirstName)
                    .Skip(pageSize * page)
                    .Take(page).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());
            return result;
        }
        public int GetContactCountByUser(long userId)
        {
            return _dataContext.Contacts
                .Count(c => c.CreatedBy == userId);
        }
    }
}
