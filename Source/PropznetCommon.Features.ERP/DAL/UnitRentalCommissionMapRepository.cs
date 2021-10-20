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
    public class UnitRentalCommissionMapRepository : IUnitRentalCommissionMapRepository
    {
        readonly IERPDataContext _dataContext;
        public UnitRentalCommissionMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateUnitRentalCommissionMap(UnitRentalCommissionMap unitRentalCommissionMap)
        {
            _dataContext.UnitRentalCommissionMaps.Add(unitRentalCommissionMap);
            return true;
        }
        public IList<long> GetAllUnitRentalCommissionIdByUnitId(long unitId)
        {
            return _dataContext.UnitRentalCommissionMaps
                            .Where(i => i.UnitId == unitId)
                            .Select(i => i.UnitRentalCommissionId).Distinct().ToList();
        }
        public IList<UnitRentalCommissionMap> GetAllUnitRentalCommissionMapByUnitId(long unitId)
        {
            return _dataContext.UnitRentalCommissionMaps
                                .Where(u => u.UnitId == unitId)
                                .Include(i => i.UnitRentalCommission).ToList();
        }
        public long GetUnitIdByUnitRentalCommissionId(long unitRentalCommissionId)
        {
            return _dataContext.UnitRentalCommissionMaps
               .SingleOrDefault(i => i.UnitRentalCommissionId == unitRentalCommissionId).UnitId;
        }
        public bool DeleteUnitRentalCommissionMap(long unitId)
        {
            var unitRentalCommissionMap = _dataContext.UnitRentalCommissionMaps
             .Where(i => i.UnitId == unitId).ToList();
            foreach (UnitRentalCommissionMap item in unitRentalCommissionMap)
            {
                _dataContext.UnitRentalCommissionMaps.Remove(item);
            }
            return true;
        }
    }
}
