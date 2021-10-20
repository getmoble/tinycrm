using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertyRentalCommissionMapRepository : IPropertyRentalCommissionMapRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertyRentalCommissionMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePropertyRentalCommissionMap(PropertyRentalCommissionMap propertyRentalCommissionMap)
        {
            _dataContext.PropertyRentalCommissionMaps.Add(propertyRentalCommissionMap);
            return true;
        }
        public IList<long> GetAllPropertyRentalCommissionIdByPropertyId(long propertyId)
        {
            return _dataContext.PropertyRentalCommissionMaps
                            .Where(i => i.PropertyId == propertyId)
                            .Select(i => i.PropertyRentalCommissionId).Distinct().ToList();
        }
        public IList<PropertyRentalCommissionMap> GetAllPropertyRentalCommissionMapByPropertyId(long propertyId)
        {
            return _dataContext.PropertyRentalCommissionMaps
                                .Where(u => u.PropertyId == propertyId)
                                .Include(i => i.PropertyRentalCommission).ToList();
        }
        public long GetPropertyIdByPropertyRentalCommissionId(long propertyRentalCommissionId)
        {
            return _dataContext.PropertyRentalCommissionMaps
               .SingleOrDefault(i => i.PropertyRentalCommissionId == propertyRentalCommissionId).PropertyId;
        }
        public bool DeletePropertyRentalCommissionMap(long propertyId)
        {
            var propertyRentalCommissionMap = _dataContext.PropertyRentalCommissionMaps
             .Where(i => i.PropertyId == propertyId).ToList();
            foreach (PropertyRentalCommissionMap item in propertyRentalCommissionMap)
            {
                _dataContext.PropertyRentalCommissionMaps.Remove(item);
            }
            return true;
        }
    }
}