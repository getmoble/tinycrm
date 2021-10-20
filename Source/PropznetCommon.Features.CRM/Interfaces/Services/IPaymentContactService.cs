using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model;
using PropznetCommon.Features.CRM.Model.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IPaymentContactService
    {
        bool CreatePropertyContact(PaymentContactMapModel contactPropertyMapModel);
        PaymentContact GetPropertyContactByPropertyId(long contactPropertyInfoId);
        PaymentContact GetPropertyContactByContactId(long contactId);
        IList<PaymentContact> GetAllPaymentContactsByUserId(long userId);
        IList<PaymentContact> GetAllPaymentContacts();
        bool UpdatePropertyContact(PaymentContactMapModel contactPropertyMapModel);
        bool DeletePropertyContact(long contactId);
        SearchResult<PaymentContact> SearchContact(PaymentContactSearchFilter filters, int pageSize, int page);
    }
}