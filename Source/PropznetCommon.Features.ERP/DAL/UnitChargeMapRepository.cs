using PropznetCommon.Features.ERP.DAL.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PropznetCommon.Features.ERP.DAL
{
    public class UnitChargeMapRepository : IUnitChargeMapRepository
    {
        readonly ERPDataContext _dataContext;
        public UnitChargeMapRepository(ERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateUnitChargeMap(UnitChargeMap unitChargeMap)
        {
            _dataContext.UnitChargeMaps.Add(unitChargeMap);
            return true;
        }
        public IList<long> GetAllChargeIdByUnitId(long unitId)
        {
            return _dataContext.UnitChargeMaps
               .Where(i => i.UnitId == unitId)
               .Select(i => i.ChargeId).Distinct().ToList();
        }
        public IList<UnitChargeMap> GetAllUnitChargeMapByUnitId(long unitId)
        {
            return _dataContext.UnitChargeMaps
                    .Where(i => i.UnitId == unitId)
                    .Include(u => u.Charge).ToList();
        }
        public long GetUnitIdByChargeId(long chargeId)
        {
            return _dataContext.UnitChargeMaps
               .FirstOrDefault(i => i.ChargeId == chargeId).UnitId;
        }
        public bool DeleteUnitChargeMap(long unitId)
        {
            var unitChargeMap = _dataContext.UnitChargeMaps
                                   .Where(i => i.UnitId == unitId).ToList();
            foreach (UnitChargeMap item in unitChargeMap)
            {
                _dataContext.UnitChargeMaps.Remove(item);
            }
            return true;
        }
    }
}