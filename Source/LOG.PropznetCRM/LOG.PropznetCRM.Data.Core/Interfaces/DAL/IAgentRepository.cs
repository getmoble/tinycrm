using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Agent;

namespace LOG.PropznetCRM.Data.Core.Interfaces.DAL
{
    public interface IAgentRepository:IGenericRepository<Agent>
    {
        IList<Agent> GetAllAgentsByUserId(long userId);
        IList<Agent> GetAllAgents();
        Agent GetAgent(long id);
        Agent GetAgentByUserId(long userId);
        int GetAgentCountByUser(long userId);
        SearchResult<Agent> SearchAgent(AgentSearchFilter searchargument, int pagesize, int count);
    }
}