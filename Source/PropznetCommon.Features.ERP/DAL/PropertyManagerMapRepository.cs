using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertyManagerMapRepository : IPropertyManagerMapRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertyManagerMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePropertyManagerMap(PropertyManagerMap propertyManagerMap)
        {
            _dataContext.PropertyManagerMaps.Add(propertyManagerMap);
            return true;
        }
        public IList<long> GetAllManagerIdByPropertyId(long propertyId)
        {
            return _dataContext.PropertyManagerMaps
                .Where(i => i.PropertyId == propertyId)
                .Include(m=>m.Manager.ManagerRole)
                .Select(i => i.ManagerId).Distinct().ToList();
        }

        public long GetPropertyIdByManagerId(long managerId)
        {
            return _dataContext.PropertyManagerMaps
               .SingleOrDefault(i => i.ManagerId == managerId).PropertyId;
        }

        public bool DeletePropertyManagerMap(long propertyId)
        {
            var propertyManagerMap = _dataContext.PropertyManagerMaps
                        .Where(i => i.PropertyId == propertyId).ToList();
            foreach (PropertyManagerMap item in propertyManagerMap)
            {
                _dataContext.PropertyManagerMaps.Remove(item);
            }
            return true;
        }
        public IList<PropertyManagerMap> GetAllManagerMapByPropertyId(long propertyId)
        {
            return _dataContext.PropertyManagerMaps
                .Where(u => u.PropertyId == propertyId)
                .Include(i => i.Manager)
                .Include(p=>p.Manager.ManagerRole).ToList();
        }
    }
}