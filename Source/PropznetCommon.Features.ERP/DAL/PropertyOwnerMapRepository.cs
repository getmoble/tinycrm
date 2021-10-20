using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertyOwnerMapRepository : IPropertyOwnerMapRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertyOwnerMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePropertyOwnerMap(PropertyOwnerMap propertyOwnerMap)
        {
            _dataContext.PropertyOwnerMaps.Add(propertyOwnerMap);
            return true;
        }
        public IList<long> GetAllOwnerIdByPropertyId(long propertyId)
        {
            return _dataContext.PropertyOwnerMaps
                .Where(i => i.PropertyId == propertyId)
                .Select(i => i.OwnerId).Distinct().ToList();
        }
        public long GetPropertyIdByOwnerId(long ownerId)
        {
            return _dataContext.PropertyOwnerMaps
               .SingleOrDefault(i => i.OwnerId == ownerId).PropertyId;
        }
        public bool DeletePropertyOwnerMap(long propertyId)
        {
            var propertyOwnerMap = _dataContext.PropertyOwnerMaps
               .Where(i => i.PropertyId == propertyId).ToList();
            foreach (PropertyOwnerMap item in propertyOwnerMap)
            {
                _dataContext.PropertyOwnerMaps.Remove(item);
            }
            return true;
        }
        public IList<PropertyOwnerMap> GetAllPropertyOwnerMapByPropertyId(long propertyId)
        {
            return _dataContext.PropertyOwnerMaps
                .Where(i => i.PropertyId == propertyId)
                .Include(u => u.Owner).ToList();
        }
    }
}