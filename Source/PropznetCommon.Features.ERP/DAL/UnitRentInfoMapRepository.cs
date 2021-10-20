using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PropznetCommon.Features.ERP.DAL
{
    public class UnitRentInfoMapRepository : IUnitRentInfoMapRepository
    {
         readonly IERPDataContext _dataContext;
         public UnitRentInfoMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateUnitRentInfoMap(UnitRentInfoMap unitRentInfoMap)
        {
            _dataContext.UnitRentInfoMaps.Add(unitRentInfoMap);
            return true;
        }

        public IList<long> GetAllRentInfoIdByUnitId(long unitId)
        {
            return _dataContext.UnitRentInfoMaps
                .Where(i => i.UnitId == unitId)
                .Select(i => i.RentInfoId).Distinct().ToList();
        }

        public IList<UnitRentInfoMap> GetAllUnitRentInfoMapByUnitId(long unitId)
        {
            return _dataContext.UnitRentInfoMaps
                    .Where(i => i.UnitId == unitId)
                    .Include(u => u.RentInfo).ToList();
        }

        public long GetUnitIdByRentInfoId(long rentInfoId)
        {
            return _dataContext.UnitRentInfoMaps
               .SingleOrDefault(i => i.RentInfoId == rentInfoId).UnitId;
        }

        public bool DeleteUnitRentInfoMap(long unitId)
        {
            var unitRentInfoMap = _dataContext.UnitRentInfoMaps
              .Where(i => i.UnitId == unitId).ToList();
            foreach (UnitRentInfoMap item in unitRentInfoMap)
            {
                _dataContext.UnitRentInfoMaps.Remove(item);
            }
            return true;
        }
    }
}
