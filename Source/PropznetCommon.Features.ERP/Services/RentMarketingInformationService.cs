using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.MarketingInformation;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class RentMarketingInformationService : IRentMarketingInformationService
    {
        readonly IRentMarketingInformationRepository _marketingInformationRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public RentMarketingInformationService(IRentMarketingInformationRepository marketingInformationRepository,
            IUnitOfWork iUnitOfWork)
        {
            _marketingInformationRepository = marketingInformationRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public RentMarketingInformation CreateRentMarketingInformation(RentMarketingInformationModel marketingInformationModel)
        {
            var marketingInformation = new RentMarketingInformation
            {
                AdvertisingRent = marketingInformationModel.AdvertisingRent,
                CreatedBy = marketingInformationModel.CreatedBy,
                Description = marketingInformationModel.Description,
                DisplayAmenities = marketingInformationModel.DisplayAmenities,
                DisplayImages = marketingInformationModel.DisplayImages,
                Featured = marketingInformationModel.Featured,
                PropertyFor = marketingInformationModel.PropertyFor,
                ShowMap = marketingInformationModel.ShowMap,
                ShowRent = marketingInformationModel.ShowRent,
                Title = marketingInformationModel.Title,
                CreatedOn = DateTime.UtcNow
            };
            var createdMarketingInformation = _marketingInformationRepository.Create(marketingInformation);
            _iUnitOfWork.Commit();
            return createdMarketingInformation;
        }

        public RentMarketingInformation UpdateRentMarketingInformation(RentMarketingInformationModel marketingInformationModel)
        {
            var marketingInformation = _marketingInformationRepository.Get(marketingInformationModel.Id);
            marketingInformation.AdvertisingRent = marketingInformation.AdvertisingRent;
            marketingInformation.UpdatedBy = marketingInformationModel.UpdatedBy;
            marketingInformation.Description = marketingInformationModel.Description;
            marketingInformation.DisplayAmenities = marketingInformationModel.DisplayAmenities;
            marketingInformation.DisplayImages = marketingInformationModel.DisplayImages;
            marketingInformation.Featured = marketingInformationModel.Featured;
            marketingInformation.PropertyFor = marketingInformationModel.PropertyFor;
            marketingInformation.ShowMap = marketingInformationModel.ShowMap;
            marketingInformation.ShowRent = marketingInformationModel.ShowRent;
            marketingInformation.Title = marketingInformationModel.Title;

            _marketingInformationRepository.Update(marketingInformation);
            _iUnitOfWork.Commit();
            return marketingInformation;
        }
        public bool Delete(long id)
        {
            var result = _marketingInformationRepository.DeletetRentMarketingInformation(id);
            _iUnitOfWork.Commit();
            return result;
        }
    }
}
