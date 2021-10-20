using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PropznetCommon.Features.CRM.Model;

namespace PropznetCommon.Features.CRM.DAL
{
    public class PaymentContactRepository : IPaymentContactRepository
    {
        readonly ICRMDataContext _dataContext;
        public PaymentContactRepository(ICRMDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePropertyContact(PaymentContact propertyContact)
        {
            _dataContext.PaymentContact.Add(propertyContact);
            return true;
        }
        public PaymentContact GetPropertyContactByPropertyId(long propertyId)
        {
            return _dataContext.PaymentContact
                .Where(p => p.ContactPaymentInfoId == propertyId)
                .Include(i => i.Contact)
                .Include(u => u.ContactPaymentInfo).SingleOrDefault();
        }
        public PaymentContact GetPropertyContactByContactId(long contactId)
        {
            return _dataContext.PaymentContact
                .Where(p => p.ContactId == contactId)
                .Include(i => i.Contact)
                .Include(i=>i.Contact.Person)
                .Include(u => u.ContactPaymentInfo).SingleOrDefault();
        }
        public bool DeletePropertyContact(long contactId)
        {
            var propertyContact = _dataContext.PaymentContact.SingleOrDefault(i => i.Id == contactId);
            if (propertyContact != null)
            {
                propertyContact.DeletedOn = DateTime.UtcNow;
                return true;
            }
            else
                return false;
        }
        public IList<PaymentContact> GetAllPaymentContactsByUserId(long userId)
        {
            return _dataContext.PaymentContact
                .Where(p => (p.CreatedByUserId == userId || p.Contact.CreatedByUserId == userId) && !p.DeletedOn.HasValue)
                .Include(a => a.Contact.Person)
                .Include(c => c.Contact)
                .Include(l => l.ContactPaymentInfo)
                .Include(s => s.Contact.Person.Country).Where(i => !i.DeletedOn.HasValue).ToList();
        }
        public IList<PaymentContact> GetAllPaymentContacts()
        {
            return _dataContext.PaymentContact                        
                        .Include(a => a.Contact.Person)
                        .Include(c => c.Contact)
                        .Include(l => l.ContactPaymentInfo)
                        .Include(s => s.Contact.Person.Country).Where(i=>!i.DeletedOn.HasValue).ToList();
        }
        public SearchResult<PaymentContact> SearchContact(Model.Contact.PaymentContactSearchFilter filters, int pageSize, int page)
        {
            var result = new SearchResult<PaymentContact>();
            IQueryable<PaymentContact> query = _dataContext.PaymentContact
                .OrderByDescending(x => x.CreatedOn)
                .Include(a => a.Contact.Person)
                .Include(c => c.Contact)
                .Include(l => l.ContactPaymentInfo)
                .Include(s => s.Contact.Person.Country);


            if (!String.IsNullOrEmpty(filters.Address))
                query = query.Where(p => p.Contact.Person.Address.Contains(filters.Address));

            if (!String.IsNullOrEmpty(filters.Email))
                query = query.Where(p => p.Contact.Person.Email.Contains(filters.Email));

            if (!String.IsNullOrEmpty(filters.FirstName))
                query = query.Where(p => p.Contact.Person.FirstName.Contains(filters.FirstName));

            if (!String.IsNullOrEmpty(filters.LastName))
                query = query.Where(p => p.Contact.Person.LastName.Contains(filters.LastName));

            if (!String.IsNullOrEmpty(filters.Phone))
                query = query.Where(p => p.Contact.Person.PhoneNo.Contains(filters.Phone));

            if (!String.IsNullOrEmpty(filters.Title))
                query = query.Where(p => p.Contact.Person.Title.Contains(filters.Title));
            if (filters.UserId.HasValue)
                query = query.Where(p => p.CreatedByUserId == filters.UserId);
            if (pageSize == 0 || page == 0)
                result.Items = query.OrderBy(p => p.Contact.Person.FirstName).ToList();
            else
                result.Items = query
                    .OrderBy(p => p.Contact.Person.FirstName)
                    .Skip(pageSize * page)
                    .Take(page).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());
            return result;

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());
            return result;
        }
    }
}