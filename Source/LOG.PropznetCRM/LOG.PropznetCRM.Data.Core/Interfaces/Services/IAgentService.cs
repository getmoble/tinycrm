using System.Collections.Generic;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Agent;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IAgentService
    {
        IList<Agent> GetAllAgentsByUserId(long userId, IList<int> permissionCodes);
        IList<Agent> GetAllAgents();
        Agent GetAgent(long id);
        bool CreateAgent(AgentModel agentModel);
        bool DeleteAgent(long id);
        bool UpdateAgent(AgentModel agentmodel);
        Agent GetAgentByUserId(long userId);
        SearchResult<Agent> SearchAgent(AgentSearchFilter searchargument, int pagesize, int count);
    }
}
