using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyRentInfoMapRepository
    {
        bool CreatePropertyRentInfoMap(PropertyRentInfoMap propertyRentInfoMap);
        IList<long> GetAllRentInfoIdByPropertyId(long propertyId);
        IList<PropertyRentInfoMap> GetAllPropertyRentInfoMapByPropertyId(long propertyId);
        long GetPropertyIdByRentInfoId(long rentInfoId);
        bool DeletePropertyRentInfoMap(long propertyId);
    }
}