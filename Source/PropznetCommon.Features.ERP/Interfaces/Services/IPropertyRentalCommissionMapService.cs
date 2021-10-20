using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyRentalCommissionMapService
    {
        long GetPropertyIdByPropertyRentalCommissionId(long PropertyRentalCommissionId);
        IList<long> GetAllPropertyRentalCommissionIdByPropertyId(long propertyId);
        IList<PropertyRentalCommission> GetAllPropertyRentalCommissionsByPropertyId(long propertyId);
        bool CreatePropertyRentalCommissionMap(PropertyRentalCommissionMapModel propertyRentalCommissionMapModel);
        bool UpdatePropertyRentalCommissionMap(PropertyRentalCommissionMapModel propertyRentalCommissionMapModel);
        bool Delete(long propertyId);
    }
}