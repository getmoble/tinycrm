using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IAmenityMapRepository
    {
        AmenitiesMap CreateAmenityMap(AmenitiesMap amenitiesMap);
        IList<long> GetAmenitiesMapsByEntityIdAndType(long entityId, ERPEntityType EntityType);
        bool DeleteAmenityMap(long id);
    }
}
