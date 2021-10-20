using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PropznetCommon.Features.ERP.Model.SaleInfo;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class UnitSaleInfoRepository : GenericRepository<UnitSaleInfo>, IUnitSaleInfoRepository
    {
        readonly IERPDataContext _dataContext;
        public UnitSaleInfoRepository(IERPDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public bool DeleteSaleInfo(long id)
        {
            var rentInfo = _dataContext.UnitSaleInfos
                .FirstOrDefault(i => i.Id == id);
            rentInfo.DeletedOn = DateTime.UtcNow;
            return true;
        }
        public UnitSaleInfo GetSaleInfo(long id)
        {
            return _dataContext.UnitSaleInfos
                .FirstOrDefault(i => !i.DeletedOn.HasValue
                    && i.Id == id);
        }
    }
}
