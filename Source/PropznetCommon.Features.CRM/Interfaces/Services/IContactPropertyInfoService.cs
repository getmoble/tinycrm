using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IContactPropertyInfoService
    {
        ContactPaymentInfo CreateContactPropertyInfo(ContactPaymentInfoModel contactPropertyInfomodel);
        bool UpdateContactPropertyInfo(ContactPaymentInfoModel contactPropertyInfomodel);
        bool DeleteContactPropertyInfo(long id);
    }
}