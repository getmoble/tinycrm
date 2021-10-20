using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyUnitMapRepository
    {
        bool CreatePropertyUnitMap(PropertyUnitMap propertyUnitMap);
        IList<long> GetAllUnitIdByPropertyId(long propertyId);
        IList<PropertyUnitMap> GetAllPropertyUnitMap(long propertyId);
        long GetPropertyIdByUnitId(long unitId);
        bool DeletePropertyUnityMap(long id);
    }
}
