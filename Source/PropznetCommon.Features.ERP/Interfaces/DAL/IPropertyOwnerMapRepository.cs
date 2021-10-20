using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyOwnerMapRepository
    {
        bool CreatePropertyOwnerMap(PropertyOwnerMap propertyOwnerMap);
        IList<long> GetAllOwnerIdByPropertyId(long propertyId);
        IList<PropertyOwnerMap> GetAllPropertyOwnerMapByPropertyId(long propertyId);
        long GetPropertyIdByOwnerId(long ownerId);
        bool DeletePropertyOwnerMap(long propertyId);
    }
}