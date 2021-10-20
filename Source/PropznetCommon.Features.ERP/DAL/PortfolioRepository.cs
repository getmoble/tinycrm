using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Model.Portfolio;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        readonly IERPDataContext _dataContext;
        public PortfolioRepository(IERPDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<Portfolio> GetAllPortfolios()
        {
            //var portfolioIdList = _dataContext.PortfolioOwnerMaps
            //            .Where(i => !i.DeletedOn.HasValue)
            //            .Select(i => i.EntityId).Distinct().ToList();

            return _dataContext.Portfolios
                .Where(i =>!i.DeletedOn.HasValue)
                .OrderByDescending(x => x.CreatedOn)
                .Distinct().ToList();
        }
        public IList<Portfolio> GetAllPortfoliosById(IList<long> portfolioId)
        {
            return _dataContext.Portfolios
                .Where(i => portfolioId.Contains(i.Id))
                .OrderByDescending(x => x.CreatedOn)
                .ToList();
        }
        public bool DeletePortfolio(long id)
        {
            var owner = _dataContext.Portfolios.FirstOrDefault(i => i.Id == id);
            owner.DeletedOn = DateTime.UtcNow;
            return true;
        }
        public SearchResult<Portfolio> SearchPortfolios(PortfolioSearchFilter searchFilter, int pagesize, int count, long userId)
        {
            var result = new SearchResult<Portfolio>();

            var portfolioIdList = _dataContext.PortfolioOwnerMaps
                                    .Where(i => !i.DeletedOn.HasValue && i.CreatedBy == userId)
                                    .Select(i => i.EntityId).Distinct().ToList();

            IQueryable<Portfolio> query = _dataContext.Portfolios
                                    .OrderByDescending(x => x.CreatedOn)
                                    .Where(i => portfolioIdList.Contains(i.Id));



            if (String.IsNullOrEmpty(searchFilter.Name))
            {
                query = query.Where
                    (p => p.Name == searchFilter.Name);
            }

            if (searchFilter.UsageType != null)
            {
                query = query.Where
                    (p => p.UsageType == searchFilter.UsageType);
            }

            result.Items = query.OrderBy(p => p.Name)
             .Skip(pagesize * count).Take(count).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pagesize, count, query.Count());
            return result;
        }
    }
}