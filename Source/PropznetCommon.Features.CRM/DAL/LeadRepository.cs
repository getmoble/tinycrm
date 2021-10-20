using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Data;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Model.Home;
using PropznetCommon.Features.CRM.Model.Lead;

namespace PropznetCommon.Features.CRM.DAL
{
    public class LeadRepository : GenericRepository<Lead>, ILeadRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public LeadRepository(ICRMLiteDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public SearchResult<Lead> SearchLeads(LeadSearchFilter filters, int pageSize, int page)
        {
            var result = new SearchResult<Lead>();
            var query = _dataContext.Leads
                                    .Where(p => !p.DeletedOn.HasValue)
                                    .OrderByDescending(x => x.CreatedOn)
                                    .Include(p => p.AssignedToUser)
                                    .Include(u=>u.LeadSourceUser)
                                    .Include(p => p.Person)
                                    .Include(i => i.LeadSource)
                                    .Include(i => i.LeadStatus);

            if (filters.AgentId.HasValue)
                query = query.Where(p => p.AssignedToUserId == filters.AgentId);

            if (filters.LeadSourceId.HasValue)
                query = query.Where(p => p.LeadSourceId == filters.LeadSourceId);

            if (filters.LeadStatusId.HasValue)
                query = query.Where(p => p.LeadStatusId == filters.LeadStatusId);

            if (!String.IsNullOrEmpty(filters.Comments))
                query = query.Where(p => p.Description.Contains(filters.Comments));

            if (!String.IsNullOrEmpty(filters.Email))
                query = query.Where(p => p.Person.Email.Contains(filters.Email));

            if (!String.IsNullOrEmpty(filters.Company))
                query = query.Where(p => p.Person.Company.Contains(filters.Company));

            if (!String.IsNullOrEmpty(filters.FirstName))
                query = query.Where(p => p.Person.FirstName.Contains(filters.FirstName));

            if (!String.IsNullOrEmpty(filters.LastName))
                query = query.Where(p => p.Person.LastName.Contains(filters.LastName));

            if (!String.IsNullOrEmpty(filters.LeadSourceName))
                query = query.Where(p => p.LeadSourceName.Contains(filters.LeadSourceName));

            if (!String.IsNullOrEmpty(filters.LeadStatus))
                query = query.Where(p => p.LeadStatus.Equals(filters.LeadStatus));

            if (!String.IsNullOrEmpty(filters.Phone))
                query = query.Where(p => p.Person.PhoneNo.Contains(filters.Phone));

            if (!String.IsNullOrEmpty(filters.Website))
                query = query.Where(p => p.Person.Website.Contains(filters.Website));
            if (filters.UserId.HasValue)
                query = query.Where(p => p.AssignedToUserId == filters.UserId);
            if (pageSize == 0 || page == 0)
                result.Items = query.OrderBy(p => p.Person.FirstName).ToList();
            else
                result.Items = query.OrderBy(p => p.Person.FirstName).
                 Skip(pageSize * page).Take(page).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());

            return result;
        }
        public IList<Lead> GetAllLeadsByUserId(long userId, long agentId)
        {
            return _dataContext.Leads
                                     .Where(p => (p.CreatedByUserId == userId || p.AssignedToUserId == agentId) && !p.DeletedOn.HasValue)
                                     .Include(l => l.Person)
                                     .Include(l => l.AssignedToUser)
                                     .Include(u => u.LeadSourceUser)
                                     .Include(l => l.LeadSource)
                                     .Include(l => l.LeadStatus)
                                     .OrderByDescending(x => x.CreatedOn)
                                     .ToList();
        }
        public IList<PieChartModel> GetLeadStatusByUserId(long userId)
        {
            var leadSourceStatuses = _dataContext.Leads
                .Where(i => i.CreatedByUserId == userId&&!i.DeletedOn.HasValue)
                .Include(p => p.LeadSource)
                .Include(u => u.LeadSourceUser)
                .GroupBy(x => new { LeadStatuses = x.LeadStatus.Name })
                .Select(i => new {i.Key, Count = i.Count() });
            var pieChartModel = new List<PieChartModel>();
            foreach (var leadSourceStatus in leadSourceStatuses)
            {
                var model = new PieChartModel
                {
                    Count = leadSourceStatus.Count,
                    LeadStatusKey = leadSourceStatus.Key.LeadStatuses
                };
                pieChartModel.Add(model);
            }
            return pieChartModel;
        }
        public Lead GetLead(long id)
        {
            return _dataContext.Leads
                .Where(i => !i.DeletedOn.HasValue)
                .Include(l => l.Person)
                                    .Include(l => l.AssignedToUser)
                                    .Include(l => l.LeadSource)
                                    .Include(l => l.LeadStatus)
                                    .Include(u => u.LeadSourceUser)
                                    .SingleOrDefault(i => i.Id == id);
        }
        public int GetLeadCountByUser(long userId)
        {
            return _dataContext.Leads
                .Count(c => c.CreatedByUserId == userId);
        }
        public IList<PieChartModel> GetAllLeadStatus()
        {
            var leadSourceStatuses = _dataContext.Leads
                .Where(i => !i.DeletedOn.HasValue)
                .Include(p => p.LeadSource)
                .Include(u => u.LeadSourceUser)
                .GroupBy(x => new { LeadStatuses = x.LeadStatus.Name })
                .Select(i => new {i.Key, Count = i.Count() });
            var pieChartModel = new List<PieChartModel>();
            foreach (var leadSourceStatus in leadSourceStatuses)
            {
                var model = new PieChartModel
                {
                    Count = leadSourceStatus.Count,
                    LeadStatusKey = leadSourceStatus.Key.LeadStatuses
                };
                pieChartModel.Add(model);
            }
            return pieChartModel;
        }
        public bool DeleteLead(long id)
        {
            var lead = _dataContext.Leads
                       .FirstOrDefault(i => i.Id == id);
            lead.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}