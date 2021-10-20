using PropznetCommon.Features.ERP.DAL.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PropznetCommon.Features.ERP.Interfaces.Data;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertyRentInfoMapRepository : IPropertyRentInfoMapRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertyRentInfoMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePropertyRentInfoMap(PropertyRentInfoMap propertyRentInfoMap)
        {
            _dataContext.PropertyRentInfoMaps.Add(propertyRentInfoMap);
            return true;
        }

        public IList<long> GetAllRentInfoIdByPropertyId(long propertyId)
        {
            return _dataContext.PropertyRentInfoMaps
                .Where(i => i.PropertyId == propertyId)
                .Select(i => i.RentInfoId).Distinct().ToList();
        }

        public IList<PropertyRentInfoMap> GetAllPropertyRentInfoMapByPropertyId(long propertyId)
        {
            return _dataContext.PropertyRentInfoMaps
                    .Where(i => i.PropertyId == propertyId)
                    .Include(u => u.RentInfo).ToList();
        }

        public long GetPropertyIdByRentInfoId(long rentInfoId)
        {
            return _dataContext.PropertyRentInfoMaps
               .SingleOrDefault(i => i.RentInfoId == rentInfoId).PropertyId;
        }

        public bool DeletePropertyRentInfoMap(long propertyId)
        {
            var propertyRentInfoMap = _dataContext.PropertyRentInfoMaps
              .Where(i => i.PropertyId == propertyId).ToList();
            foreach (PropertyRentInfoMap item in propertyRentInfoMap)
            {
                _dataContext.PropertyRentInfoMaps.Remove(item);
            }
            return true;
        }
    }
}
