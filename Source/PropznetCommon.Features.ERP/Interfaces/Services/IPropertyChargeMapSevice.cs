using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyChargeMapSevice
    {
        long GetPropertyIdByChargeId(long chargeId);
        IList<long> GetAllChargeIdByPropertyId(long propertyId);
        IList<Charge> GetAllChargesByPropertyId(long propertyId);
        bool CreatePropertyChargeMap(PropertyChargeMapModel propertyChargeMapModel);
        bool UpdatePropertyChargeMap(PropertyChargeMapModel propertyChargeMapModel);
        bool Delete(long propertyId);
    }
}