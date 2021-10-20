using System;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertyRentInfoRepository : GenericRepository<PropertyRentInfo>, IPropertyRentInfoRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertyRentInfoRepository(IERPDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public bool DeleteRentInfo(long id)
        {
            var rentInfo = _dataContext.PropertyRentInfos
                .FirstOrDefault(i => i.Id == id);
            rentInfo.DeletedOn = DateTime.UtcNow;
            return true;
        }

        public PropertyRentInfo GetRentInfo(long id)
        {
            return _dataContext.PropertyRentInfos
                .FirstOrDefault(i => !i.DeletedOn.HasValue
                    && i.Id == id);
        }
    }
}
