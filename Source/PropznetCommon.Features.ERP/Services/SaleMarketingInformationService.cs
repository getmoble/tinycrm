using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.MarketingInformation;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class SaleMarketingInformationService : ISaleMarketingInformationService
    {
        readonly ISaleMarketingInformationRepository _saleMarketingInformationRepository;
        readonly IUnitOfWork _unitOfWork;
        public SaleMarketingInformationService(ISaleMarketingInformationRepository saleMarketingInformationRepository,
            IUnitOfWork iUnitOfWork)
        {
            _saleMarketingInformationRepository = saleMarketingInformationRepository;
            _unitOfWork = iUnitOfWork;
        }
        public SaleMarketingInformation CreateSaleMarketingInformation(SaleMarketingInformationModel saleMarketingInformationModel)
        {
            var saleMarketingInformation = new SaleMarketingInformation
            {
                AdvertisingCost = saleMarketingInformationModel.SaleAdvertisingCost,
                Description = saleMarketingInformationModel.Description,
                DisplayAmenities = saleMarketingInformationModel.DisplayAmenities,
                DisplayImages = saleMarketingInformationModel.DisplayImages,
                Featured = saleMarketingInformationModel.Featured,
                PropertyFor = saleMarketingInformationModel.PropertyFor,
                ShowMap = saleMarketingInformationModel.ShowMap,
                ShowSalePrice = saleMarketingInformationModel.ShowSalePrice,
                Title = saleMarketingInformationModel.Title,
                CreatedOn = DateTime.UtcNow
            };
            var createdMarketingInformation = _saleMarketingInformationRepository.Create(saleMarketingInformation);
            _unitOfWork.Commit();
            return createdMarketingInformation;
        }
        public SaleMarketingInformation UpdateSaleMarketingInformation(SaleMarketingInformationModel saleMarketingInformationModel)
        {
            var saleMarketingInformation = _saleMarketingInformationRepository.Get(saleMarketingInformationModel.Id);
            saleMarketingInformation.AdvertisingCost = saleMarketingInformation.AdvertisingCost;
            saleMarketingInformation.UpdatedBy = saleMarketingInformationModel.UpdatedBy;
            saleMarketingInformation.Description = saleMarketingInformationModel.Description;
            saleMarketingInformation.DisplayAmenities = saleMarketingInformationModel.DisplayAmenities;
            saleMarketingInformation.DisplayImages = saleMarketingInformationModel.DisplayImages;
            saleMarketingInformation.Featured = saleMarketingInformationModel.Featured;
            saleMarketingInformation.PropertyFor = saleMarketingInformationModel.PropertyFor;
            saleMarketingInformation.ShowMap = saleMarketingInformationModel.ShowMap;
            saleMarketingInformation.ShowSalePrice = saleMarketingInformationModel.ShowSalePrice;
            saleMarketingInformation.Title = saleMarketingInformationModel.Title;

            _saleMarketingInformationRepository.Update(saleMarketingInformation);
            _unitOfWork.Commit();
            return saleMarketingInformation;
        }
        public bool Delete(long id)
        {
            var result = _saleMarketingInformationRepository.DeletetSaleMarketingInformation(id);
            _unitOfWork.Commit();
            return result;
        }
    }
}