using System;
using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class AmenityMapRepository : IAmenityMapRepository
    {
        readonly IERPDataContext _dataContext;
        public AmenityMapRepository(IERPDataContext context)
        {
            _dataContext = context;
        }
        public AmenitiesMap CreateAmenityMap(AmenitiesMap amenitiesMap)
        {
            return _dataContext.AmenitiesMaps.Add(amenitiesMap);
        }
        public IList<long> GetAmenitiesMapsByEntityIdAndType(long entityId, ERPEntityType EntityType)
        {
            return _dataContext.AmenitiesMaps
                 .Where(i => i.EntityId == entityId && i.EntityType == EntityType && !i.DeletedOn.HasValue)
                 .OrderByDescending(x=>x.CreatedOn)
                 .Select(i => i.Id).Distinct().ToList();
        }
        public bool DeleteAmenityMap(long id)
        {
            var amenitiesMap = _dataContext.AmenitiesMaps
                .FirstOrDefault(i => i.AmenityId == id);
            amenitiesMap.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}