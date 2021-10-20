using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyAmenityMapService
    {
        long GetPropertyIdByAmenityId(long unitId);
        IList<long> GetAllAmenityIdByPropertyId(long propertyId);
        IList<Amenity> GetAllAmenityPropertyId(long propertyId);
        bool CreatePropertyAmenityMap(PropertyAmenityMapModel propertyAmenityMapModel);
        bool UpdatePropertyAmenityMap(PropertyAmenityMapModel propertyAmenityMapModel);
        bool Delete(long propertyId);
    }
}
