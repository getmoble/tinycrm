using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyRentalCommissionService
    {
        IList<PropertyRentalCommission> GetAllPropertyRentalCommissions();
        IList<PropertyRentalCommission> GetAllPropertyRentalCommissionById(IList<long> propertyRentalCommissionsId);
        PropertyRentalCommission CreatePropertyRentalCommission(PropertyRentalCommissionModel propertyRentalCommissionModel);
        PropertyRentalCommission UpdatePropertyRentalCommission(PropertyRentalCommissionModel propertyRentalCommissionModel);
        bool DeletePropertyRentalCommission(long id);
        bool DeleteAllPropertyRentalCommissionByPropertyId(long propertyId);
    }
}