using Common.Data;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Home;
using LOG.PropznetCRM.Data.Model.Lead;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class LeadRepository : GenericRepository<Lead>, ILeadRepository
    {
        readonly DataContext _dataContext;
        public LeadRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public SearchResult<Lead> SearchLeads(LeadSearchFilter filters, int pageSize, int page)
        {
            var result = new SearchResult<Lead>();
            var query = _dataContext.Leads
                                    .Include(p => p.Agent)
                                    .Include(p => p.CommunicationDetail)
                                    .Include(i=>i.LeadSource)
                                    .Include(i=>i.LeadStatus)
                                    .Where(p=>!p.DeletedOn.HasValue);

            if(filters.AgentId.HasValue)
                query=query.Where(p => p.AgentId==filters.AgentId);

            if (filters.LeadSourceId.HasValue)
                query = query.Where(p => p.LeadSourceId==filters.LeadSourceId);

            if (filters.LeadStatusId.HasValue)
                query = query.Where(p => p.LeadStatusId==filters.LeadStatusId);

            if (!String.IsNullOrEmpty(filters.Comments))
                query = query.Where(p => p.Comments.Contains(filters.Comments));

            if (!String.IsNullOrEmpty(filters.Email))
                query = query.Where(p => p.CommunicationDetail.Email.Contains(filters.Email));

            if (!String.IsNullOrEmpty(filters.Company))
                query = query.Where(p => p.Company.Contains(filters.Company));

            if (!String.IsNullOrEmpty(filters.FirstName))
                query = query.Where(p => p.FirstName.Contains(filters.FirstName));

            if (!String.IsNullOrEmpty(filters.LastName))
                query = query.Where(p => p.LastName.Contains(filters.LastName));

            if (!String.IsNullOrEmpty(filters.LeadSourceName))
                query = query.Where(p => p.LeadSourceName.Contains(filters.LeadSourceName));

            if (!String.IsNullOrEmpty(filters.LeadStatus))
                query = query.Where(p => p.LeadStatus.Equals(filters.LeadStatus));

            if (!String.IsNullOrEmpty(filters.Phone))
                query = query.Where(p => p.CommunicationDetail.Phone.Contains(filters.Phone));

            if (!String.IsNullOrEmpty(filters.Website))
                query=query.Where(p => p.CommunicationDetail.Website.Contains(filters.Website));
            if (filters.UserId.HasValue)
                query = query.Where(p => p.CreatedBy == filters.UserId);
            if (pageSize == 0 || page == 0)
            result.Items = query.OrderBy(p => p.FirstName).ToList();
            else
                result.Items = query.OrderBy(p => p.FirstName).
                 Skip(pageSize * page).Take(page).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());

            return result;
        }

        public IList<Lead> GetAllLeadsByUserId(long userId, long agentId)
        {
            return _dataContext.Leads.Include(l=>l.CommunicationDetail)
                                    .Include(l=>l.Agent)
                                    .Include(l=>l.LeadSource)
                                    .Include(l=>l.LeadStatus)
                                    .Where(i => i.DeletedOn == null)
                                    .Where(p => p.CreatedBy == userId||p.AgentId==agentId).ToList();
        }
        public IList<PieChartModel> GetLeadStatusByUserId(long userId)
        {
            var leadSourceStatuses = _dataContext.Leads
                .Include(p=>p.LeadSource)
                .Where(i=>i.CreatedBy==userId)
                .GroupBy(x => new { LeadStatuses = x.LeadStatus.Name})
                .Select(i =>new{Key= i.Key,Count = i.Count()});
            var pieChartModel = new List<PieChartModel>();
            foreach (var leadSourceStatus in leadSourceStatuses)
            {
                var model = new PieChartModel {
                    Count = leadSourceStatus.Count,
                    LeadStatusKey = leadSourceStatus.Key.LeadStatuses};
                pieChartModel.Add(model);
            }
            return pieChartModel;
        }
        public Lead GetLead(long id)
        {
            return _dataContext.Leads
                .Include(l => l.CommunicationDetail)
                                    .Include(l => l.Agent)
                                    .Include(l => l.LeadSource)
                                    .Include(l => l.LeadStatus)
                                    .SingleOrDefault(i => i.Id == id);
        }
        public int GetLeadCountByUser(long userId)
        {
            return _dataContext.Leads
                .Count(c => c.CreatedBy == userId);
        }


        public IList<PieChartModel> GetAllLeadStatus()
        {
            var leadSourceStatuses = _dataContext.Leads.Include(p => p.LeadSource)
                .GroupBy(x => new { LeadStatuses = x.LeadStatus.Name })
                .Select(i => new { Key = i.Key, Count = i.Count() });
            var pieChartModel = new List<PieChartModel>();
            foreach (var leadSourceStatus in leadSourceStatuses)
            {
                var model = new PieChartModel { 
                    Count = leadSourceStatus.Count, 
                    LeadStatusKey = leadSourceStatus.Key.LeadStatuses };
                pieChartModel.Add(model);
            }
            return pieChartModel;
        }
    }
}
