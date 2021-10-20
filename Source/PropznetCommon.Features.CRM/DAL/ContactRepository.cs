using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Data;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Model.Contact;

namespace PropznetCommon.Features.CRM.DAL
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public ContactRepository(ICRMLiteDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<Contact> GetAllContactsByUserId(long userId)
        {
            return _dataContext.Contacts
                                        .Where(c => !c.DeletedOn.HasValue && c.CreatedByUserId == userId)
                                        .Include(c => c.Person)
                                        .Include(c => c.Person.Country)
                                        .OrderByDescending(x => x.CreatedOn)
                                        .ToList();
        }
        public IList<Contact> GetAllContacts()
        {
            return _dataContext.Contacts
                                        .Where(c => !c.DeletedOn.HasValue)
                                        .Include(c => c.Person)
                                        .Include(c => c.Person.Country)
                                        .OrderByDescending(x => x.CreatedOn)
                                        .ToList();
        }
        public Contact GetContact(long id)
        {
            return _dataContext.Contacts
                .Include(c => c.Person)
                .Include(c => c.Person.Country)
                .SingleOrDefault(c => c.Id == id && !c.DeletedOn.HasValue);
        }
        public SearchResult<Contact> SearchContacts(ContactSearchFilter filters, int pageSize, int page)
        {
            var result = new SearchResult<Contact>();
            var query = _dataContext.Contacts
                        .Include(c => c.Person)
                        .Include(c => c.Person.Country);

            //if (filters.AccountId.HasValue)
            //    query = query.Where(p => p.AccountId == filters.AccountId);

            //if (filters.AgentId.HasValue)
            //    query = query.Where(p => p.AgentId == filters.AgentId);

            //if (!String.IsNullOrEmpty(filters.Account))
            //    query = query.Where(p => p.Account.Name.Contains(filters.Account));

            if (!String.IsNullOrEmpty(filters.Address))
                query = query.Where(p => p.Person.Address.Contains(filters.Address));

            if (!String.IsNullOrEmpty(filters.Email))
                query = query.Where(p => p.Person.Email.Contains(filters.Email));

            if (!String.IsNullOrEmpty(filters.FirstName))
                query = query.Where(p => p.Person.FirstName.Contains(filters.FirstName));

            if (!String.IsNullOrEmpty(filters.LastName))
                query = query.Where(p => p.Person.LastName.Contains(filters.LastName));

            if (!String.IsNullOrEmpty(filters.Phone))
                query = query.Where(p => p.Person.PhoneNo.Contains(filters.Phone));

            if (!String.IsNullOrEmpty(filters.Title))
                query = query.Where(p => p.Person.Title.Contains(filters.Title));
            if (filters.UserId.HasValue)
                query = query.Where(p => p.CreatedByUserId == filters.UserId);
            if (pageSize == 0 || page == 0)
                result.Items = query.OrderBy(p => p.Person.FirstName).ToList();
            else
                result.Items = query
                    .OrderBy(p => p.Person.FirstName)
                    .Skip(pageSize * page)
                    .Take(page).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());
            return result;
        }
        public int GetContactCountByUser(long userId)
        {
            return _dataContext.Contacts
                .Count(c => c.CreatedByUserId == userId);
        }
        public bool DeleteContact(long id)
        {
            var contact = _dataContext.Contacts
                                        .FirstOrDefault(i => i.Id == id);
            contact.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}
