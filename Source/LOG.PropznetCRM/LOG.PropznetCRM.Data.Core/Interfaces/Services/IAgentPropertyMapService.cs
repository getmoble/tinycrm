using System.Collections.Generic;
using LOG.PropznetCRM.Data.Entities;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IAgentPropertyMapService
    {
        IList<AgentPropertyMap> GetAllAgentPropertyMap();
        IList<AgentPropertyMap> GetAllAgentPropertyMapByUserId(long userId);
        AgentPropertyMap GetAgentPropertyMap(long id);
        AgentPropertyMap CreateAgentPropertyMap(long agentId, long propertyId);
        bool UpdateAgentPropertyMap(long agentId, long propertyId, long agentPropertyMapId);
        bool DeleteAgentPropertyMap(long agentPropertyMapId);
    }
}
