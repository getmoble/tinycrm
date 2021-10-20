using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Unit;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitAmenityMapService
    {
        long GetUnitIdByAmenityId(long amenityId);
        IList<long> GetAllAmenityIdByUnitId(long unitId);
        IList<Amenity> GetAllAmenityByUnitId(long unitId);
        bool CreateUnitAmenityMap(UnitAmenityMapModel unitAmenityMapModel);
        bool UpdateUnitAmenityMap(UnitAmenityMapModel unitAmenityMapModel);
        bool Delete(long unitId);
    }
}
