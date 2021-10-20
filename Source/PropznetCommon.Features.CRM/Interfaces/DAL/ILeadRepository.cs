using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Home;
using PropznetCommon.Features.CRM.Model.Lead;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface ILeadRepository : IGenericRepository<Lead>
    {
        IList<Lead> GetAllLeadsByUserId(long userId, long agentId);
        Lead GetLead(long id);
        SearchResult<Lead> SearchLeads(LeadSearchFilter filter, int pageSize, int page);
        IList<PieChartModel> GetLeadStatusByUserId(long userId);
        int GetLeadCountByUser(long userId);
        IList<PieChartModel> GetAllLeadStatus();
        bool DeleteLead(long id);
    }
}
