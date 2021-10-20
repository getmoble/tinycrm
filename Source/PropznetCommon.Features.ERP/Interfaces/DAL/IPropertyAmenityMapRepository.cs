using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyAmenityMapRepository
    {
        bool CreatePropertyAmenityMap(PropertyAmenityMap propertyAmenityMap);
        IList<long> GetAllAmenityIdByPropertyId(long propertyId);
        IList<PropertyAmenityMap> GetAllAmenityMapByPropertyId(long propertyId);
        long GetPropertyIdByAmenityId(long amenityId);
        bool DeletePropertyAmenityMap(long id);
    }
}