using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyRentalCommissionMapRepository
    {
        bool CreatePropertyRentalCommissionMap(PropertyRentalCommissionMap propertyRentalCommissionMap);
        IList<long> GetAllPropertyRentalCommissionIdByPropertyId(long propertyId);
        IList<PropertyRentalCommissionMap> GetAllPropertyRentalCommissionMapByPropertyId(long propertyId);
        long GetPropertyIdByPropertyRentalCommissionId(long propertyRentalCommissionId);
        bool DeletePropertyRentalCommissionMap(long propertyId);
    }
}