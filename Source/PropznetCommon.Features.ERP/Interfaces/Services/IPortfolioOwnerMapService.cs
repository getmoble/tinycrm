using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Portfolio;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPortfolioOwnerMapService
    {
        bool CreatePortfolioOwnerMap(PortfolioOwnerMapModel portfolioOwnerMapModel);
        IList<long> GetPortfoliosByUserId(long ownerId);
        IList<Owner> GetPortfolioOwnerssByPortfolioId(long portfolioId);
        //IList<ToDoMap> GetAllToDoMapsByEntityTypeAndUserId(EntityType entityType, long userId);
        bool UpdatePortfolioOwnerMap(PortfolioOwnerMapModel portfolioOwnerMapModel);
        bool Delete(long portfolioId);
    }
}
