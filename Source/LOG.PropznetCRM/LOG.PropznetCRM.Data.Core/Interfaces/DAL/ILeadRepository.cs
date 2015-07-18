using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Home;
using LOG.PropznetCRM.Data.Model.Lead;

namespace LOG.PropznetCRM.Data.Core.Interfaces.DAL
{
    public interface ILeadRepository : IGenericRepository<Lead>
    {
        IList<Lead> GetAllLeadsByUserId(long userId, long agentId);
        Lead GetLead(long id);
        SearchResult<Lead> SearchLeads(LeadSearchFilter filter, int pageSize, int page);
        IList<PieChartModel> GetLeadStatusByUserId(long userId);
        int GetLeadCountByUser(long userId);
        IList<PieChartModel> GetAllLeadStatus();
    }
}
