using System.Collections.Generic;
using System.Linq;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Portfolio;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class PortfolioService : IPortfolioService
    {

        readonly IPortfolioRepository _portfolioRepository;
        readonly IPortfolioOwnerMapService _portfolioOwnerMapService;
        readonly IUnitOfWork _iUnitOfWork;
        public PortfolioService(
            IPortfolioRepository portfolioRepository,
            IPortfolioOwnerMapService portfolioOwnerMapService,
            IUnitOfWork UnitOfWork)
        {
            _portfolioRepository = portfolioRepository;
            _portfolioOwnerMapService = portfolioOwnerMapService;
            _iUnitOfWork = UnitOfWork;
        }
        public IList<Portfolio> GetAllPortfolios()
        {
            return _portfolioRepository.GetAllPortfolios().ToList();
        }
        public IList<Portfolio> GetAllPortfoliosByOwner(long userId)
        {
            var portfolioIdList = _portfolioOwnerMapService.GetPortfoliosByUserId(userId);
            return _portfolioRepository.GetAllPortfoliosById(portfolioIdList);
        }
        public Portfolio CreatePortfolio(PortfolioModel portfolioModel)
        {
            var portfolio = new Portfolio()
            {
                CreatedBy = portfolioModel.CreatedBy,
                Name = portfolioModel.PortfolioName,
                UsageType = portfolioModel.UsageType,
                Description = portfolioModel.Description
            };
            var newPortfolio = _portfolioRepository.Create(portfolio);
            _iUnitOfWork.Commit();
            if (portfolioModel.OwnerId != null)
            {

                var portfolioOwnerMapModel = new PortfolioOwnerMapModel
                {
                    CreatedBy = portfolioModel.CreatedBy,
                    EntityId = newPortfolio.Id,
                    OwnerId = portfolioModel.OwnerId
                };
                var portfolioOwnerMap = _portfolioOwnerMapService.CreatePortfolioOwnerMap(portfolioOwnerMapModel);
                _iUnitOfWork.Commit();
            }
            return newPortfolio;
        }
        public Portfolio UpdatePortfolio(PortfolioModel portfolioModel)
        {
            var portfolio = _portfolioRepository.Get(portfolioModel.Id);
            portfolio.Name = portfolioModel.PortfolioName;
            portfolio.UsageType = portfolioModel.UsageType;
            portfolio.Description = portfolioModel.Description;
            _portfolioRepository.Update(portfolio);
            _iUnitOfWork.Commit();
            if (portfolioModel.OwnerId != null)
            {
                var portfolioOwnerMapModel = new PortfolioOwnerMapModel
                {
                    EntityId = portfolioModel.Id,
                    EntityType = ERPEntityType.Portfolio,
                    OwnerId = portfolioModel.OwnerId,
                    PortfolioId = portfolioModel.Id
                };
                _portfolioOwnerMapService.UpdatePortfolioOwnerMap(portfolioOwnerMapModel);
            }
            else
            {
                try
                {
                    _portfolioOwnerMapService.Delete(portfolio.Id);
                }
                catch (Exception ex)
                { }
            }
            return portfolio;
        }
        public bool DeletePortfolio(long portfolioId)
        {
            var result = _portfolioRepository.DeletePortfolio(portfolioId);
            _portfolioOwnerMapService.Delete(portfolioId);
            _iUnitOfWork.Commit();
            return result;
        }
        public SearchResult<Portfolio> SearchPortfolio(PortfolioSearchFilter searchargument, int pagesize, int count, long userId)
        {
            return _portfolioRepository.SearchPortfolios(searchargument, pagesize, count, userId);
        }
        public Portfolio GetPortfolioById(long portfolioId)
        {
            return _portfolioRepository.Get(portfolioId);
        }
        public bool CheckPortfolioExists(string name)
        {
            var existingPortfolio = _portfolioRepository.GetBy(i => i.Name == name);
            if (existingPortfolio != null)
                return true;
            else
                return false;
        }
    }
}