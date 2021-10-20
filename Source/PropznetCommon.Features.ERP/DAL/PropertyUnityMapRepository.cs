using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertyUnitMapRepository : IPropertyUnitMapRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertyUnitMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePropertyUnitMap(PropertyUnitMap propertyUnitMap)
        {
            _dataContext.PropertyUnitMaps.Add(propertyUnitMap);
            return true;
        }
        public IList<long> GetAllUnitIdByPropertyId(long propertyId)
        {
            return _dataContext.PropertyUnitMaps
                 .Where(i => i.PropertyId == propertyId)
                 .Select(i => i.UnitId).Distinct().ToList();
        }
        public long GetPropertyIdByUnitId(long unitId)
        {
            return _dataContext.PropertyUnitMaps
                .SingleOrDefault(i => i.UnitId == unitId).PropertyId;
        }
        public bool DeletePropertyUnityMap(long propertyId)
        {
            var propertyUnitMap = _dataContext.PropertyUnitMaps
                .Where(i => i.PropertyId == propertyId).ToList();
            foreach (PropertyUnitMap item in propertyUnitMap)
            {
                item.DeletedOn = DateTime.UtcNow;
            }
            return true;
        }
        public IList<PropertyUnitMap> GetAllPropertyUnitMap(long propertyId)
        {
            return _dataContext.PropertyUnitMaps
                .Where(i => i.PropertyId == propertyId)
                .Include(u => u.Unit).ToList();
        }
    }
}