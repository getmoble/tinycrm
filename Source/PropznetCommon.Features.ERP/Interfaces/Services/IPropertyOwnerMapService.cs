using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyOwnerMapService
    {
        long GetPropertyIdByOwnerId(long ownerId);
        IList<long> GetAllOwnerIdByPropertyId(long propertyId);
        IList<Owner> GetAllOwnersByPropertyId(long propertyId);
        bool CreatePropertyOwnerMap(PropertyOwnerMapModel propertyOwnerMapModel);
        bool UpdatePropertyOwnerMap(PropertyOwnerMapModel propertyOwnerMapModel);
        bool Delete(long propertyId);
    }
}
