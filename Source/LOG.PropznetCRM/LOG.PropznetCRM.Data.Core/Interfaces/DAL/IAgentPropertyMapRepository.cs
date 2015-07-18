using System.Collections.Generic;
using Common.Data.Interfaces;
using LOG.PropznetCRM.Data.Entities;

namespace LOG.PropznetCRM.Data.Core.Interfaces.DAL
{
    public interface IAgentPropertyMapRepository : IGenericRepository<AgentPropertyMap>
    {
        void Delete(long id);
        IList<AgentPropertyMap> GetAllAgentPropertyMapByUserId(long userId);
        AgentPropertyMap GetAgentPropertyMap(long id);
    }
}
