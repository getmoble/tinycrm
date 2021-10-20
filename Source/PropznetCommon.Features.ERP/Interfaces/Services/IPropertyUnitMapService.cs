using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyUnitMapService
    {
        long GetPropertyIdByUnitId(long unitId);
        IList<long> GetAllUnitIdByPropertyId(long propertyId);
        IList<Unit> GetAllUnitsByPropertyId(long propertyId);
        bool CreatePropertyUnitMap(PropertyUnitMapModel propertyUnitMapModel);
        bool UpdatePropertyOwnerMap(PropertyUnitMapModel propertyUnitMapModel);
        bool Delete(long propertyId);
    }
}