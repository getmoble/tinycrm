using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyChargeMapRepository
    {
        bool CreatePropertyChargeMap(PropertyChargeMap propertyChargeMap);
        IList<long> GetAllChargeIdByPropertyId(long propertyId);
        IList<PropertyChargeMap> GetAllPropertyChargeMapByPropertyId(long propertyId);
        long GetPropertyIdByChargeId(long chargeId);
        bool DeletePropertyChargeMap(long propertyId);
    }
}