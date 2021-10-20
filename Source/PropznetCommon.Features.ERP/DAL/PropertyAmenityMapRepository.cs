using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertyAmenityMapRepository : IPropertyAmenityMapRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertyAmenityMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePropertyAmenityMap(PropertyAmenityMap propertyAmenityMap)
        {
            _dataContext.PropertyAmenityMaps.Add(propertyAmenityMap);
            return true;
        }
        public IList<long> GetAllAmenityIdByPropertyId(long propertyId)
        {
            return _dataContext.PropertyAmenityMaps
                 .Where(i => i.PropertyId == propertyId)
                 .Select(i => i.AmenityId).Distinct().ToList();
        }
        public long GetPropertyIdByAmenityId(long amenityId)
        {
            return _dataContext.PropertyAmenityMaps
               .SingleOrDefault(i => i.AmenityId == amenityId).PropertyId;
        }
        public bool DeletePropertyAmenityMap(long id)
        {
            var propertyAmenityMap = _dataContext.PropertyAmenityMaps
                                    .Where(i => i.Id == id).ToList();
            foreach (PropertyAmenityMap item in propertyAmenityMap)
            {
                _dataContext.PropertyAmenityMaps.Remove(item);
            }
            return true;
        }
        public IList<PropertyAmenityMap> GetAllAmenityMapByPropertyId(long propertyId)
        {
            return _dataContext.PropertyAmenityMaps
                .Where(u => u.PropertyId == propertyId)
                .Include(i => i.Property)
                .Include(p => p.Amenity).ToList();
        }
    }
}