using System.Collections.Generic;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Agent;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IAgentInfoService
    {
        IList<AgentInfo> GetAllAgentInfosByUserId(long userId, IList<int> permissionCodes);
        IList<AgentInfo> GetAllAgentInfos();
        AgentInfo GetAgentInfo(long id);
        bool CreateAgentInfo(AgentInfoModel agentModel);
        bool DeleteAgentInfo(long id);
        bool UpdateAgentInfo(AgentInfoModel agentmodel);
        AgentInfo GetAgentInfoByUserId(long userId);
        SearchResult<AgentInfo> SearchAgentInfo(AgentSearchFilter searchargument, int pagesize, int count);
    }
}
