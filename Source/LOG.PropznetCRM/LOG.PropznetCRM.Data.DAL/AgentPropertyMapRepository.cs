using Common.Data;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class AgentPropertyMapRepository : GenericRepository<AgentPropertyMap>, IAgentPropertyMapRepository
    {
        readonly DataContext _dataContext;
       public AgentPropertyMapRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public void Delete(long id)
        {
            var agentPropertyMap = _dataContext.AgentPropertyMaps
                .FirstOrDefault(i => i.Id == id);
            _dataContext.AgentPropertyMaps.Remove(agentPropertyMap);
        }
        public IList<AgentPropertyMap> GetAllAgentPropertyMapByUserId(long agentid)
        {
            return _dataContext.AgentPropertyMaps
                .Where(i => i.AgentId == agentid).ToList();
        }
        public AgentPropertyMap GetAgentPropertyMap(long id)
        {
            return _dataContext.AgentPropertyMaps.FirstOrDefault(i => i.Id == id);
        }
    }
}