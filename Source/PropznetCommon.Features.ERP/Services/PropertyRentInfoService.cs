using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.RentInfo;
using System;
using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.Services
{
    public class PropertyRentInfoService : IPropertyRentInfoService
    {
        readonly IPropertyRentInfoRepository _rentInfoRepository;
        readonly IPropertyRentInfoMapRepository _propertyRentInfoMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyRentInfoService(IPropertyRentInfoRepository rentInfoRepository,
            IPropertyRentInfoMapRepository propertyRentInfoMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _rentInfoRepository = rentInfoRepository;
            _propertyRentInfoMapRepository = propertyRentInfoMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public PropertyRentInfo CreateRentInfo(RentInfoModel rentInfoModel)
        {
            var rentInfo = new PropertyRentInfo
            {
                Amount = rentInfoModel.Amount,
                ChargeId = rentInfoModel.ChargeId,
                CreatedBy = rentInfoModel.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                Month = rentInfoModel.Month,
                Supress = rentInfoModel.Supress,
            };
            var createdRentInfo = _rentInfoRepository.Create(rentInfo);
            _iUnitOfWork.Commit();
            return createdRentInfo;
        }
        public PropertyRentInfo UpdateRentInfo(RentInfoModel rentInfoModel)
        {
            var rentInfo = _rentInfoRepository.GetRentInfo(rentInfoModel.Id);
            rentInfo.Amount = rentInfoModel.Amount;
            rentInfo.ChargeId = rentInfoModel.ChargeId;
            rentInfo.CreatedBy = rentInfoModel.CreatedBy;
            rentInfo.CreatedOn = DateTime.UtcNow;
            rentInfo.Month = rentInfoModel.Month;
            rentInfo.Supress = rentInfoModel.Supress;
            _rentInfoRepository.Update(rentInfo);
            _iUnitOfWork.Commit();
            return rentInfo;
        }
        public bool DeleteAllRentInfoByPropertyId(long propertyId)
        {
            IList<long> rentInfoIds = _propertyRentInfoMapRepository.GetAllRentInfoIdByPropertyId(propertyId);
            foreach (long rentInfoId in rentInfoIds)
            {
                DeleteRentInfo(rentInfoId);
            }
            return true;
        }
        public bool DeleteRentInfo(long id)
        {
            var result = _rentInfoRepository.DeleteRentInfo(id);

            return result;
        }
        public PropertyRentInfo GetRentInfo(long id)
        {
            return _rentInfoRepository.GetRentInfo(id);
        }
    }
}