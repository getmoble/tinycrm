using System;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class SaleMarketingInformationRepository : GenericRepository<SaleMarketingInformation>, ISaleMarketingInformationRepository
    {
        IERPDataContext _dataContext;
        public SaleMarketingInformationRepository(IERPDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public bool DeletetSaleMarketingInformation(long id)
        {
            var saleMarketingInformation = _dataContext.SaleMarketingInformation
                   .FirstOrDefault(i => i.Id == id);
            saleMarketingInformation.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}