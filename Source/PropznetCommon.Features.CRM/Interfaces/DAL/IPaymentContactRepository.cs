using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model;
using PropznetCommon.Features.CRM.Model.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface IPaymentContactRepository
    {
        bool CreatePropertyContact(PaymentContact propertyContact);
        PaymentContact GetPropertyContactByPropertyId(long propertyId);
        PaymentContact GetPropertyContactByContactId(long contactId); 
        bool DeletePropertyContact(long contactId);
        IList<PaymentContact> GetAllPaymentContactsByUserId(long userId);
        IList<PaymentContact> GetAllPaymentContacts();
        SearchResult<PaymentContact> SearchContact(PaymentContactSearchFilter filters, int pageSize, int page);

    }
}