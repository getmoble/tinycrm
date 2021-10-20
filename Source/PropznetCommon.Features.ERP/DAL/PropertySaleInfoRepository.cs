using System;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertySaleInfoRepository : GenericRepository<PropertySaleInfo>, IPropertySaleInfoRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertySaleInfoRepository(IERPDataContext dataContext)
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
        public PropertySaleInfo GetSaleInfo(long id)
        {
            return _dataContext.PropertySaleInfos
                .FirstOrDefault(i => !i.DeletedOn.HasValue
                    && i.Id == id);
        }
    }
}