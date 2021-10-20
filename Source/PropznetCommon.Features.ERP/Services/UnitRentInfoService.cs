using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.RentInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Services
{
    public class UnitRentInfoService : IUnitRentInfoService
    {
        readonly IUnitRentInfoRepository _rentInfoRepository;
        readonly IUnitRentInfoMapRepository _UnitRentInfoMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public UnitRentInfoService(IUnitRentInfoRepository rentInfoRepository,
            IUnitRentInfoMapRepository UnitRentInfoMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _rentInfoRepository = rentInfoRepository;
            _UnitRentInfoMapRepository = UnitRentInfoMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public UnitRentInfo CreateRentInfo(RentInfoModel rentInfoModel)
        {
            var rentInfo = new UnitRentInfo
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
        public UnitRentInfo UpdateRentInfo(RentInfoModel rentInfoModel)
        {
            var rentInfo = _rentInfoRepository.GetRentInfo(rentInfoModel.Id);
            rentInfo.Amount = rentInfoModel.Amount;
            rentInfo.ChargeId = rentInfoModel.ChargeId;
            rentInfo.CreatedBy = rentInfoModel.CreatedBy;
            rentInfo.UpdatedOn = DateTime.UtcNow;
            rentInfo.Month = rentInfoModel.Month;
            rentInfo.Supress = rentInfoModel.Supress;
            _rentInfoRepository.Update(rentInfo);
            _iUnitOfWork.Commit();
            return rentInfo;
        }
        public bool DeleteAllRentInfoByUnitId(long UnitId)
        {
            IList<long> rentInfoIds = _UnitRentInfoMapRepository.GetAllRentInfoIdByUnitId(UnitId);
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
        public UnitRentInfo GetRentInfo(long id)
        {
            return _rentInfoRepository.GetRentInfo(id);
        }
    }
}