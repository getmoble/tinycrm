using System;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class RentMarketingInformationRepository : GenericRepository<RentMarketingInformation>, IRentMarketingInformationRepository
    {
        IERPDataContext _dataContext;
        public RentMarketingInformationRepository(IERPDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public bool DeletetRentMarketingInformation(long id)
        {
            var marketingInformation = _dataContext.RentMarketingInformation
                .FirstOrDefault(i => i.Id == id);
            marketingInformation.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}
