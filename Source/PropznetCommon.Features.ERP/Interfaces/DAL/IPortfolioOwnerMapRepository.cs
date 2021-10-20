using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPortfolioOwnerMapRepository
    {
        PortfolioOwnerMap CreatePortfolioOwnerMap(PortfolioOwnerMap portfolioOwnerMap);
        IList<long> GetPortfoliosByOwnerId(long ownerId);
        IList<long> GetPortfolioOwnersByPortfolioId(long portfolioId);
        bool DeletePortfolioOwnerMap(long id);
    }
}