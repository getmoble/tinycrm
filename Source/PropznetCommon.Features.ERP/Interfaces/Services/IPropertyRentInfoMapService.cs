using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyRentInfoMapService
    {
        long GetPropertyIdByRentInfoId(long rentInfoId);
        IList<long> GetAllRentInfoIdByPropertyId(long propertyId);
        IList<PropertyRentInfo> GetAllRentInfosByPropertyId(long propertyId);
        bool CreatePropertyRentInfoMap(PropertyRentInfoMapModel propertyRentInfoMapModel);
        bool UpdatePropertyRentInfoMap(PropertyRentInfoMapModel propertyRentInfoMapModel);
        bool Delete(long propertyId);
    }
}