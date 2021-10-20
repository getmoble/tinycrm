using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertyAgentMapRepository : IPropertyAgentMapRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertyAgentMapRepository(IERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePropertyAgentMap(PropertyAgentMap propertyAgentMap)
        {
            _dataContext.PropertyAgentMaps.Add(propertyAgentMap);
            return true;
        }
        public IList<long> GetAllAgentIdByPropertyId(long propertyId)
        {
            return _dataContext.PropertyAgentMaps
                .Where(i => i.PropertyId == propertyId)
                .Select(i => i.AgentId).Distinct().ToList();
        }
        public long GetPropertyIdByAgentId(long agentId)
        {
            return _dataContext.PropertyAgentMaps
               .SingleOrDefault(i => i.AgentId == agentId).PropertyId;
        }
        public bool DeletePropertyAgentMap(long propertyId)
        {
            var propertyAgentMap = _dataContext.PropertyAgentMaps
               .Where(i => i.PropertyId == propertyId).ToList();
            foreach (PropertyAgentMap item in propertyAgentMap)
            {
                _dataContext.PropertyAgentMaps.Remove(item);
            }
            return true;
        }
        public IList<PropertyAgentMap> GetAllPropertyAgentMapByPropertyId(long propertyId)
        {
            return _dataContext.PropertyAgentMaps
                .Where(i => i.PropertyId == propertyId)
                .Include(a=>a.Agent)
                .Include(u => u.Property).ToList();
        }
    }
}