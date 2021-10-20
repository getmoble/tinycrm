using Common.Data;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.DAL
{
    public class ContactPaymentInfoRepository : GenericRepository<ContactPaymentInfo>, IContactPaymentInfoRepository
    {
        readonly ICRMDataContext _dataContext;
        public ContactPaymentInfoRepository(ICRMDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public bool DeleteContactPropertyInfo(long id)
        {
            var contactPropertyInfo= _dataContext.ContactPaymentInfo.FirstOrDefault(i => i.Id == id);
            if (contactPropertyInfo != null)
            {
                contactPropertyInfo.DeletedOn = DateTime.UtcNow;
            }
            return true;
        }
    }
}