using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class UnitOwnerMapRepository : IUnitOwnerMapRepository
    {
        readonly IERPDataContext _dataContext;
        public UnitOwnerMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateUnitOwnerMap(UnitOwnerMap unitOwnerMap)
        {
            _dataContext.UnitOwnerMaps.Add(unitOwnerMap);
            return true;
        }
        public IList<long> GetAllOwnerIdByUnitId(long unitId)
        {
            return _dataContext.UnitOwnerMaps
                .Where(i => i.UnitId == unitId)
                .Select(i => i.UnitId).Distinct().ToList();
        }
        public long GetUnitIdByOwnerId(long ownerId)
        {
            return _dataContext.UnitOwnerMaps
               .SingleOrDefault(i => i.UnitId == ownerId).UnitId;
        }
        public bool DeleteUnitOwnerMap(long unitId)
        {
            var unitOwnerMap = _dataContext.UnitOwnerMaps
               .Where(i => i.UnitId == unitId).ToList();
            foreach (UnitOwnerMap item in unitOwnerMap)
            {
                _dataContext.UnitOwnerMaps.Remove(item);
            }
            return true;
        }
        public IList<UnitOwnerMap> GetAllUnitOwnerMapByUnitId(long unitId)
        {
            return _dataContext.UnitOwnerMaps
                    .Where(u => u.UnitId == unitId)
                    .Include(p => p.Owner).ToList();
        }
    }
}