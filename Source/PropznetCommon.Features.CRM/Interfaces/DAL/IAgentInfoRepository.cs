using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Agent;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface IAgentInfoRepository:IGenericRepository<AgentInfo>
    {
        IList<AgentInfo> GetAllAgentInfoByUserId(long userId);
        IList<AgentInfo> GetAllAgentInfo();
        AgentInfo GetAgentInfo(long id);
        AgentInfo GetAgentInfoByUserId(long userId);
        int GetAgentInfoCountByUser(long userId);
        SearchResult<AgentInfo> SearchAgentInfo(AgentSearchFilter searchargument, int pagesize, int count);
        bool DeleteAgentInfo(long id);
    }
}