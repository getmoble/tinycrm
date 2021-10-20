using System.Collections.Generic;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Portfolio;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPortfolioService
    {
        IList<Portfolio> GetAllPortfolios();
        IList<Portfolio> GetAllPortfoliosByOwner(long ownerId);
        Portfolio GetPortfolioById(long portfolioId);
        bool CheckPortfolioExists(string name);
        Portfolio CreatePortfolio(PortfolioModel portfolioModel);
        Portfolio UpdatePortfolio(PortfolioModel portfolioModel);
        bool DeletePortfolio(long portfolioId);
        SearchResult<Portfolio> SearchPortfolio(PortfolioSearchFilter searchargument, int pagesize, int count, long userId);
    }
}