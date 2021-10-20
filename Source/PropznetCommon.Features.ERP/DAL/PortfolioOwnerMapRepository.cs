using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PortfolioOwnerMapRepository : IPortfolioOwnerMapRepository
    {
        readonly IERPDataContext _dataContext;
        public PortfolioOwnerMapRepository(IERPDataContext context)
        {
            _dataContext = context;
        }
        public PortfolioOwnerMap CreatePortfolioOwnerMap(PortfolioOwnerMap portfolioOwnerMap)
        {
            var createdPortfolioOwnerMap = _dataContext.PortfolioOwnerMaps
                  .Add(portfolioOwnerMap);

            return createdPortfolioOwnerMap;
        }
        public IList<long> GetPortfoliosByOwnerId(long ownerId)
        {
            var portfolioOwnerMap = _dataContext.PortfolioOwnerMaps
                .Where(i => (i.CreatedBy == ownerId || i.OwnerId == ownerId) && !i.DeletedOn.HasValue)
                .Select(i => i.EntityId).Distinct().ToList();

            return portfolioOwnerMap;
        }
        public bool DeletePortfolioOwnerMap(long portfolioId)
        {
            var portfolioOwnerMap = _dataContext.PortfolioOwnerMaps
                .Where(i => i.EntityId == portfolioId).ToList();
            foreach (PortfolioOwnerMap item in portfolioOwnerMap)
            {
                _dataContext.PortfolioOwnerMaps.Remove(item);
            }
            return true;
        }
        public IList<long> GetPortfolioOwnersByPortfolioId(long portfolioId)
        {
            return _dataContext.PortfolioOwnerMaps
                 .Where(i => i.EntityId == portfolioId)
                 .Select(i => i.OwnerId).Distinct().ToList();
        }
    }
}