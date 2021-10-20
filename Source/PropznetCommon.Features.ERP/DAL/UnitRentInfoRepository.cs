using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.DAL
{
    public class UnitRentInfoRepository : GenericRepository<UnitRentInfo>, IUnitRentInfoRepository
    {
         readonly IERPDataContext _dataContext;
        public UnitRentInfoRepository(IERPDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public bool DeleteRentInfo(long id)
        {
            var rentInfo = _dataContext.UnitRentInfos
                .FirstOrDefault(i => i.Id == id);
            rentInfo.DeletedOn = DateTime.UtcNow;
            return true;
        }
        public UnitRentInfo GetRentInfo(long id)
        {
            return _dataContext.UnitRentInfos
                .FirstOrDefault(i => !i.DeletedOn.HasValue
                    && i.Id == id);
        }
    }
}