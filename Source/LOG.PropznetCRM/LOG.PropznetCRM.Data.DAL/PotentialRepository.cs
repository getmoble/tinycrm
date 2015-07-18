using Common.Data;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Home;
using LOG.PropznetCRM.Data.Model.Potential;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class PotentialRepository : GenericRepository<Potential>, IPotentialRepository
    {
        readonly DataContext _dataContext;
        public PotentialRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<Potential> GetAllPotentials(long userId, long agentId)
        {
            return _dataContext.Potentials
                .Where(p => !p.DeletedOn.HasValue)
                .Include(a => a.Agent)
                .Include(a => a.Account)
                .Include(c => c.Contact)
                .Include(l => l.LeadSource)
                .Include(l => l.Property)
                .Include(p => p.Property.Location)
                .Include(p => p.Property.PropertyCategory)
                .Include(s => s.SalesStage)
                .Include(s => s.Property.State)
                .Where(p => p.CreatedBy == userId || p.AgentId == agentId).ToList();
        }
        public IList<Potential> GetAllPotentials()
        {
            return _dataContext.Potentials
                .Where(p => !p.DeletedOn.HasValue)
                .Include(a => a.Agent)
                .Include(a => a.Account)
                .Include(c => c.Contact)
                .Include(l => l.LeadSource)
                .Include(l => l.Property)
                .Include(p => p.Property.Location)
                .Include(p => p.Property.PropertyCategory)
                .Include(s => s.SalesStage)
                .Include(s => s.Property.State)
                .ToList();
        }
        public Potential GetPotential(long id)
        {
            return _dataContext.Potentials
                .Include(a => a.Agent)
                                         .Include(a => a.Account)
                                         .Include(c => c.Contact)
                                         .Include(l => l.LeadSource)
                                         .Include(l => l.Property)
                                         .Include(p => p.Property.Location)
                                         .Include(p => p.Property.PropertyCategory)
                                         .Include(s => s.SalesStage)
                                         .Include(s => s.Property.State)
                                         .SingleOrDefault(p => p.Id == id && !p.DeletedOn.HasValue);
        }
        public SearchResult<Potential> SearchPotential(PotentialSearchFilter filters, int pageSize, int page)
        {
            var result = new SearchResult<Potential>();
            IQueryable<Potential> query = _dataContext.Potentials
                .Include(p => p.Agent)
                .Include(p => p.Account)
                .Include(p => p.Contact)
                .Include(p => p.LeadSource)
                .Include(p => p.Property)
                .Include(s => s.Property.State)
                .Include(p => p.Property.PropertyCategory)
                .Include(p => p.Property.Location)
                .Include(p => p.SalesStage);

            if (filters.LeadSourceId.HasValue)
                query = query.Where(p => p.LeadSourceId == (filters.LeadSourceId));

            if (filters.PropertyTypeId.HasValue)
                query = query.Where(p => p.Property.PropertyType == filters.PropertyTypeId);

            if (filters.SalesStageId.HasValue)
                query = query.Where(p => p.SalesStageId == (filters.SalesStageId));

            if (filters.AgentId.HasValue)
                query = query.Where(p => p.AgentId == (filters.AgentId));

            if (!String.IsNullOrEmpty(filters.Account))
                query = query.Where(p => p.Account.Name.Contains(filters.Account));

            if (!String.IsNullOrEmpty(filters.Comments))
                query = query.Where(p => p.Comments.Contains(filters.Comments));

            if (filters.ExpectedAmount > 0)
                query = query.Where(p => p.ExpectedAmount == (filters.ExpectedAmount));

            if (!String.IsNullOrEmpty(filters.LeadSource))
                query = query.Where(p => p.LeadSourceName.Contains(filters.LeadSource));

            if (!String.IsNullOrEmpty(filters.Name))
                query = query.Where(p => p.Name.Contains(filters.Name));

            if (!String.IsNullOrEmpty(filters.SalesStage))
                query = query.Where(p => p.SalesStage.Equals(filters.SalesStage));
            if (filters.UserId.HasValue)
                query = query.Where(p => p.CreatedBy == filters.UserId);

            if (page == 0 || pageSize == 0)
                result.Items = query.OrderBy(p => p.Name).ToList();
            else
                result.Items = query.OrderBy(p => p.Name)
               .Skip(pageSize * page)
               .Take(page).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());
            return result;

        }
        public IList<BarChartModel> GetSalesByUserId(long userId)
        {
            var salesStages = (_dataContext.Potentials
                .Where(i => i.CreatedBy == userId && i.SalesStageId == 4)
                .GroupBy(i => new { UpdatedOn = i.UpdatedOn })
                .Select(i => new { Key = i.Key, Count = i.Count() }))
                .OrderByDescending(i => i.Key.UpdatedOn).Take(4);

            var barChartList = new List<BarChartModel>();
            foreach (var salesStage in salesStages)
            {
                var model = new BarChartModel
                {
                    Count = salesStage.Count,
                    Month = salesStage.Key.UpdatedOn.Value.ToString("MMM")
                };
                barChartList.Add(model);
            }
            return barChartList;
        }
        public int GetPotentialCountByUser(long userId)
        {
            return _dataContext.Potentials.Count(c => c.CreatedBy == userId);
        }


        public IList<BarChartModel> GetAllSales()
        {
            var salesStages = (_dataContext.Potentials
                .Where(i => i.SalesStageId == 4)
                .GroupBy(i => new { UpdatedOn = i.UpdatedOn })
                .Select(i => new { Key = i.Key, Count = i.Count() }))
                .OrderByDescending(i => i.Key.UpdatedOn).Take(4);

            var barChartList = new List<BarChartModel>();
            foreach (var salesStage in salesStages)
            {
                var model = new BarChartModel { Count = salesStage.Count, Month = salesStage.Key.UpdatedOn.Value.ToString("MMM") };
                barChartList.Add(model);
            }
            return barChartList;
        }
    }
}