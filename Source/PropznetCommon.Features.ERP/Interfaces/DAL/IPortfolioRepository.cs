using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Portfolio;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPortfolioRepository : IGenericRepository<Portfolio>
    {
        IList<Portfolio> GetAllPortfolios();
        IList<Portfolio> GetAllPortfoliosById(IList<long> portfolioId);
        bool DeletePortfolio(long portfolioId);
        SearchResult<Portfolio> SearchPortfolios(PortfolioSearchFilter searchFilter, int pagesize, int count, long userId);
    }
}
