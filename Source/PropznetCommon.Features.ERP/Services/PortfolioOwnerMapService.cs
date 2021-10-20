using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Portfolio;

namespace PropznetCommon.Features.ERP.Services
{
    public class PortfolioOwnerMapService : IPortfolioOwnerMapService
    {
        readonly IPortfolioOwnerMapRepository _portfolioOwnerMapRepository;
        readonly IOwnerService _ownerService;
        readonly IUnitOfWork _iUnitOfWork;
        public PortfolioOwnerMapService(
            IPortfolioOwnerMapRepository portfolioOwnerMapRepository,
            IOwnerService ownerService,
            IUnitOfWork iUnitOfWork)
        {
            _portfolioOwnerMapRepository = portfolioOwnerMapRepository;
            _ownerService = ownerService;
            _iUnitOfWork = iUnitOfWork;
        }
        public bool CreatePortfolioOwnerMap(PortfolioOwnerMapModel portfolioOwnerMapModel)
        {
            foreach (long ownerid in portfolioOwnerMapModel.OwnerId)
            {
                var portfolioOwnerMap = new PortfolioOwnerMap
                {
                    EntityId = portfolioOwnerMapModel.EntityId,
                    EntityType = portfolioOwnerMapModel.EntityType,
                    CreatedBy = portfolioOwnerMapModel.CreatedBy,
                    OwnerId = ownerid
                };
                var createdportfolioOwnerMap = _portfolioOwnerMapRepository.CreatePortfolioOwnerMap(portfolioOwnerMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }
        public IList<long> GetPortfoliosByUserId(long ownerId)
        {
            return _portfolioOwnerMapRepository.GetPortfoliosByOwnerId(ownerId);
        }
        public IList<Owner> GetPortfolioOwnerssByPortfolioId(long portfolioId)
        {
            IList<long> ownersId = _portfolioOwnerMapRepository.GetPortfolioOwnersByPortfolioId(portfolioId);
            return _ownerService.GetAllOwnersById(ownersId);
        }
        public bool Delete(long portfolioId)
        {
            var result = _portfolioOwnerMapRepository.DeletePortfolioOwnerMap(portfolioId);
            _iUnitOfWork.Commit();
            return result;
        }
        public bool UpdatePortfolioOwnerMap(PortfolioOwnerMapModel portfolioOwnerMapModel)
        {
            Delete(portfolioOwnerMapModel.EntityId);
            CreatePortfolioOwnerMap(portfolioOwnerMapModel);
            return true;
        }
    }
}