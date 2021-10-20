using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyManagerMapRepository
    {
        bool CreatePropertyManagerMap(PropertyManagerMap propertyManagerMap);
        IList<long> GetAllManagerIdByPropertyId(long propertyId);
        IList<PropertyManagerMap> GetAllManagerMapByPropertyId(long propertyId);
        long GetPropertyIdByManagerId(long managerId);
        bool DeletePropertyManagerMap(long propertyId);
    }
}
