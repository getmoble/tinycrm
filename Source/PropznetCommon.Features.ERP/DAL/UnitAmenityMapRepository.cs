using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class UnitAmenityMapRepository : IUnitAmenityMapRepository
    {
        readonly IERPDataContext _dataContext;
        public UnitAmenityMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateUnitAmenityMap(UnitAmenityMap unitAmenityMap)
        {
            _dataContext.UnitAmenityMaps.Add(unitAmenityMap);
            return true;
        }
        public IList<long> GetAllAmenityIdByUnitId(long unitId)
        {
            return _dataContext.UnitAmenityMaps
                  .Where(i => i.UnitId == unitId)
                  .OrderByDescending(x => x.CreatedOn)
                  .Select(i => i.UnitId).Distinct().ToList();
        }
        public long GetUnitIdByAmenityId(long amenityId)
        {
            return _dataContext.UnitAmenityMaps
              .SingleOrDefault(i => i.UnitId == amenityId).UnitId;
        }
        public bool DeleteUnitAmenityMap(long id)
        {
            var unitAmenityMap = _dataContext.UnitAmenityMaps
                                     .Where(i => i.UnitId == id).ToList();
            foreach (UnitAmenityMap item in unitAmenityMap)
            {
                _dataContext.UnitAmenityMaps.Remove(item);
            }
            return true;
        }
        public IList<UnitAmenityMap> GetAllAmenityMapByUnitId(long unitId)
        {
            return _dataContext.UnitAmenityMaps
                .Where(u => u.UnitId == unitId)
                .OrderByDescending(x => x.CreatedOn)
                .Include(p => p.Amenity).ToList();
        }
    }
}