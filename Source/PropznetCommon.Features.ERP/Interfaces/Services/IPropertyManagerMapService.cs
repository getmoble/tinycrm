using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyManagerMapService
    {
        bool CreatePropertyManagerMap(PropertyManagerMapModel propertyManagerMapModel);
        IList<long> GetAllManagerIdByPropertyId(long propertyId);
        IList<Manager> GetAllManagerByPropertyId(long propertyId);
        long GetPropertyIdByManagerId(long managerId);
        bool UpdatePropertyManagerMap(PropertyManagerMapModel propertyManagerMapModel);
        bool Delete(long propertyId);
    }
}