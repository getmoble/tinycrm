using System;
using Common.Data.Interfaces;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Potential;

namespace PropznetCommon.Features.CRM.Services
{
    public class PotentialPropertyInfoService : IPotentialPropertyInfoService
    {
        readonly IPotentialPropertyInfoRepository _potentialPropertyInfoRepository;
        readonly IUnitOfWork _unitOfWork;
        public PotentialPropertyInfoService(IPotentialPropertyInfoRepository potentialPropertyInfoRepository,
            IUnitOfWork unitOfWork)
        {
            _potentialPropertyInfoRepository = potentialPropertyInfoRepository;
            _unitOfWork = unitOfWork;
        }
        public PotentialPropertyInfo CreatePotentialPropertyInfo(PotentialPropertyInfoModel potentialPropertyInfoModel)
        {
            var potentialPropertyInfo = new PotentialPropertyInfo
            {
                CreatedOn = DateTime.UtcNow,
                ExpectedMoveInDate = potentialPropertyInfoModel.ExpectedMoveInDate,
                Area = potentialPropertyInfoModel.Area,
                Baths = potentialPropertyInfoModel.Baths,
                Beds = potentialPropertyInfoModel.Beds,
                BudgetFrom = potentialPropertyInfoModel.BudgetFrom,
                BudgetTo = potentialPropertyInfoModel.BudgetTo,
                City = potentialPropertyInfoModel.City,
                CountryId = potentialPropertyInfoModel.CountryId,
                Floor = potentialPropertyInfoModel.Floor,
                PropertyCategoryId = potentialPropertyInfoModel.selectedPropertyCategory,
                PropertyType = potentialPropertyInfoModel.selectedProperty,
                Region = potentialPropertyInfoModel.Region,
                State = potentialPropertyInfoModel.State
            };
            var createdPotentialPropertyInfo = _potentialPropertyInfoRepository.Create(potentialPropertyInfo);
            _unitOfWork.Commit();
            return createdPotentialPropertyInfo;
        }
        public bool UpdatePotentialPropertyInfo(PotentialPropertyInfoModel potentialPropertyInfoModel)
        {
            var potentialPropertyInfo = _potentialPropertyInfoRepository.Get(potentialPropertyInfoModel.Id);
                potentialPropertyInfo.CreatedOn = DateTime.UtcNow;
                potentialPropertyInfo.ExpectedMoveInDate = potentialPropertyInfoModel.ExpectedMoveInDate;
                potentialPropertyInfo.Area = potentialPropertyInfoModel.Area;
                potentialPropertyInfo.Baths = potentialPropertyInfoModel.Baths;
                potentialPropertyInfo.Beds = potentialPropertyInfoModel.Beds;
                potentialPropertyInfo.BudgetFrom = potentialPropertyInfoModel.BudgetFrom;
                potentialPropertyInfo.BudgetTo = potentialPropertyInfoModel.BudgetTo;
                potentialPropertyInfo.City = potentialPropertyInfoModel.City;
                potentialPropertyInfo.CountryId = potentialPropertyInfoModel.CountryId;
                potentialPropertyInfo.Floor = potentialPropertyInfoModel.Floor;
                potentialPropertyInfo.PropertyCategoryId = potentialPropertyInfoModel.selectedPropertyCategory;
                potentialPropertyInfo.PropertyType = potentialPropertyInfoModel.selectedProperty;
                potentialPropertyInfo.Region = potentialPropertyInfoModel.Region;
                potentialPropertyInfo.State = potentialPropertyInfoModel.State;
            _potentialPropertyInfoRepository.Update(potentialPropertyInfo);
                _unitOfWork.Commit();
            return true;
        }
        public bool DeletePotentialPropertyInfo(long id)
        {
            var result = _potentialPropertyInfoRepository.DeletePotentialPropertyInfo(id);
            _unitOfWork.Commit();
            return result;
        }
    }
}