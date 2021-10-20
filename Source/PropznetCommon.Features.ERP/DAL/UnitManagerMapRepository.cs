using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class UnitManagerMapRepository : IUnitManagerMapRepository
    {
        readonly IERPDataContext _dataContext;
        public UnitManagerMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateUnitManagerMap(UnitManagerMap unitManagerMap)
        {
            _dataContext.UnitManagerMaps.Add(unitManagerMap);
            return true;
        }
        public IList<long> GetAllManagerIdByUnitId(long unitId)
        {
            return _dataContext.UnitManagerMaps
                 .Where(i => i.UnitId == unitId)
                 .Select(i => i.UnitId).Distinct().ToList();
        }
        public long GetUnitIdByManagerId(long managerId)
        {
            return _dataContext.UnitManagerMaps
               .SingleOrDefault(i => i.UnitId == managerId).UnitId;
        }
        public bool DeleteUnitManagerMap(long unitId)
        {
            var unitManagerMap = _dataContext.UnitManagerMaps
                         .Where(i => i.UnitId == unitId).ToList();
            foreach (UnitManagerMap item in unitManagerMap)
            {
                _dataContext.UnitManagerMaps.Remove(item);
            }
            return true;
        }
        public IList<UnitManagerMap> GetAllUnitManagerMapByUnitId(long unitId)
        {
            return _dataContext.UnitManagerMaps
                    .Where(u => u.UnitId == unitId)
                    .OrderByDescending(x => x.CreatedOn)
                    .Include(p => p.Manager)
                    .Include(i=>i.Manager.ManagerRole).ToList();
        }
    }
}