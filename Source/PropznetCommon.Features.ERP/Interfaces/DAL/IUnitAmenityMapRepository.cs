using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IUnitAmenityMapRepository
    {
        bool CreateUnitAmenityMap(UnitAmenityMap unitAmenityMap);
        IList<long> GetAllAmenityIdByUnitId(long unitId);
        IList<UnitAmenityMap> GetAllAmenityMapByUnitId(long unitId);
        long GetUnitIdByAmenityId(long amenityId);
        bool DeleteUnitAmenityMap(long id);
    }
}
