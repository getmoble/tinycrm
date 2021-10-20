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
using PropznetCommon.Features.CRM.Model.Potential;

namespace PropznetCommon.Features.CRM.DAL
{
    public class PotentialRepository : GenericRepository<Potential>, IPotentialRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public PotentialRepository(ICRMLiteDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<Potential> GetAllPotentials(long userId, long assignedToUserId)
        {
            return _dataContext.Potentials
                .Where(p => (p.CreatedByUserId == userId || p.AssignedToUserId == assignedToUserId) && !p.DeletedOn.HasValue)
                .Include(a => a.AssignedToUser)
                .Include(a => a.Account)
                .Include(a => a.Account.Person)
                .Include(c => c.Contact)
                .Include(l => l.LeadSource)
                .Include(l => l.Person)
                .Include(s => s.SalesStage)
                .Include(a => a.AssignedToUser.Person)
                .OrderByDescending(x => x.CreatedOn)
                .ToList();
        }
        public IList<Potential> GetAllPotentials()
        {
            return _dataContext.Potentials
                .Where(p => !p.DeletedOn.HasValue)
                .OrderByDescending(x => x.CreatedOn)
                .Include(a => a.AssignedToUser)
                .Include(a => a.Account)
                .Include(a => a.Account.Person)
                .Include(c => c.Contact)
                .Include(l => l.LeadSource)
                .Include(l => l.Person)
                .Include(s => s.SalesStage)
                .Include(a => a.AssignedToUser.Person)
                .ToList();
        }
        public Potential GetPotential(long id)
        {
            return _dataContext.Potentials
                .Include(a => a.AssignedToUser)
                                         .Include(a => a.Account)
                                         .Include(a => a.Account.Person)
                                         .Include(c => c.Contact)
                                         .Include(l => l.LeadSource)
                                         .Include(l => l.Person)
                                         .Include(s => s.SalesStage)
                                         .Include(s => s.Contact.Person)
                                         .Include(s => s.Account.Person)
                                         .SingleOrDefault(p => p.Id == id && !p.DeletedOn.HasValue);
        }
        public SearchResult<Potential> SearchPotential(PotentialSearchFilter filters, int pageSize, int page)
        {
            var result = new SearchResult<Potential>();
            IQueryable<Potential> query = _dataContext.Potentials
                .OrderByDescending(x => x.CreatedOn)
                .Include(p => p.AssignedToUser)
                 .Include(p => p.AssignedToUser.Person)
                .Include(p => p.Account)
                .Include(a => a.Account.Person)
                .Include(p => p.Contact)
                .Include(p => p.LeadSource)
               .Include(l => l.Person)
                .Include(p => p.SalesStage);

            if (filters.LeadSourceId.HasValue)
                query = query.Where(p => p.LeadSourceId == (filters.LeadSourceId));

            if (filters.SalesStageId.HasValue)
                query = query.Where(p => p.SalesStageId == (filters.SalesStageId));

            if (filters.AgentId.HasValue)
                query = query.Where(p => p.AssignedToUserId == (filters.AgentId));

            if (!String.IsNullOrEmpty(filters.Account))
                query = query.Where(p => p.Account.Person.FirstName.Contains(filters.Account));

            if (!String.IsNullOrEmpty(filters.Comments))
                query = query.Where(p => p.Description.Contains(filters.Comments));

            if (filters.ExpectedAmount > 0)
                query = query.Where(p => p.ExpectedAmount == (filters.ExpectedAmount));

            if (!String.IsNullOrEmpty(filters.LeadSource))
                query = query.Where(p => p.LeadSourceName.Contains(filters.LeadSource));

            if (!String.IsNullOrEmpty(filters.Name))
                query = query.Where(p => p.Person.FirstName.Contains(filters.Name));

            if (!String.IsNullOrEmpty(filters.SalesStage))
                query = query.Where(p => p.SalesStage.Equals(filters.SalesStage));
            if (filters.UserId.HasValue)
                query = query.Where(p => p.CreatedByUserId == filters.UserId);

            if (filters.AssignedToUserId.HasValue)
                  query = query.Where(p => p.AssignedToUserId == filters.AssignedToUserId);

            if (page == 0 || pageSize == 0)
                result.Items = query.OrderBy(p => p.Person.FirstName).ToList();
            else
                result.Items = query.OrderBy(p => p.Person.FirstName)
               .Skip(pageSize * page)
               .Take(page).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());
            return result;

        }
        public IList<BarChartModel> GetSalesByUserId(long userId)
        {
            var salesStages = (_dataContext.Potentials
                .Where(i => i.CreatedByUserId == userId && i.SalesStageId == 4 && !i.DeletedOn.HasValue)
                .GroupBy(i => new { i.UpdatedOn })
                .Select(i => new { i.Key, Count = i.Count() }))
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
            return _dataContext.Potentials.Count(c => c.CreatedByUserId == userId);
        }
        public IList<BarChartModel> GetAllSales()
        {
            var salesStages = (_dataContext.Potentials
                .Where(i => i.SalesStageId == 4 && !i.DeletedOn.HasValue)
                .GroupBy(i => new { i.UpdatedOn })
                .Select(i => new { i.Key, Count = i.Count() }))
                .OrderByDescending(i => i.Key.UpdatedOn).Take(4);

            var barChartList = new List<BarChartModel>();
            foreach (var salesStage in salesStages)
            {
                if (salesStage.Key.UpdatedOn != null)
                {
                    var model = new BarChartModel { Count = salesStage.Count, Month = salesStage.Key.UpdatedOn.Value.ToString("MMM") };
                    barChartList.Add(model);
                }
            }
            return barChartList;
        }
        public bool DeletePotential(long id)
        {
            var potential = _dataContext.Potentials
                            .FirstOrDefault(i => i.Id == id);
            if (potential != null) potential.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}