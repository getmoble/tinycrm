using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Services
{
    public class UnitRentInfoMapService : IUnitRentInfoMapService
    {
        readonly IUnitRentInfoMapRepository _unitRentInfoMapRepository;
        readonly IUnitOfWork _unitOfWork;
        public UnitRentInfoMapService(
            IUnitRentInfoMapRepository unitRentInfoMapRepository,
            IUnitOfWork unitOfWork)
        {
            _unitRentInfoMapRepository = unitRentInfoMapRepository;
            _unitOfWork = unitOfWork;
        }
        public long GetUnitIdByRentInfoId(long rentInfoId)
        {
            return _unitRentInfoMapRepository.GetUnitIdByRentInfoId(rentInfoId);
        }
        public IList<long> GetAllRentInfoIdByUnitId(long unitId)
        {
            return _unitRentInfoMapRepository.GetAllRentInfoIdByUnitId(unitId);
        }
        public IList<UnitRentInfo> GetAllRentInfosByUnitId(long unitId)
        {
            var unitRentInfoMap = _unitRentInfoMapRepository.GetAllUnitRentInfoMapByUnitId(unitId);
            IList<UnitRentInfo> unitRentInfo = null;
            if (unitRentInfoMap != null)
            {
                unitRentInfo = new List<UnitRentInfo>();
                foreach (UnitRentInfoMap item in unitRentInfoMap)
                {
                    unitRentInfo.Add(item.RentInfo);
                }
            }
            return unitRentInfo;
        }
        public bool CreateUnitRentInfoMap(UnitRentInfoMapModel unitRentInfoMapModel)
        {
            Delete(unitRentInfoMapModel.UnitId);
            foreach (long rentInfoId in unitRentInfoMapModel.RentInfoIds)
            {
                var unitRentInfoMap = new UnitRentInfoMap
                {
                    UnitId = unitRentInfoMapModel.UnitId,
                    RentInfoId = rentInfoId,
                    CreatedOn = DateTime.UtcNow
                };
                var UnitUnitMap = _unitRentInfoMapRepository.CreateUnitRentInfoMap(unitRentInfoMap);
            }
            _unitOfWork.Commit();
            return true;
        }
        public bool UpdateUnitRentInfoMap(UnitRentInfoMapModel unitRentInfoMapModel)
        {
            Delete(unitRentInfoMapModel.Id);
            CreateUnitRentInfoMap(unitRentInfoMapModel);
            return true;
        }
        public bool Delete(long unitId)
        {
            var result = _unitRentInfoMapRepository.DeleteUnitRentInfoMap(unitId);
            _unitOfWork.Commit();
            return result;
        }
    }
}