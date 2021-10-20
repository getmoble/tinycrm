using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.DAL;
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
    public class UnitRentalCommissionMapService : IUnitRentalCommissionMapService
    {
        readonly IUnitRentalCommissionMapRepository _unitRentalCommissionMapRepository;
        readonly IUnitOfWork _unitOfWork;
        public UnitRentalCommissionMapService(IUnitRentalCommissionMapRepository unitRentalCommissionMapRepository,
            IUnitOfWork unitOfWork)
        {
            _unitRentalCommissionMapRepository = unitRentalCommissionMapRepository;
            _unitOfWork = unitOfWork;
        }
        public long GetUnitIdByUnitRentalCommissionId(long unitRentalCommissionId)
        {
            return _unitRentalCommissionMapRepository.GetUnitIdByUnitRentalCommissionId(unitRentalCommissionId);
        }
        public IList<long> GetAllUnitRentalCommissionIdByUnitId(long unitId)
        {
            return _unitRentalCommissionMapRepository.GetAllUnitRentalCommissionIdByUnitId(unitId);
        }
        public IList<UnitRentalCommission> GetAllUnitRentalCommissionsByUnitId(long unitId)
        {
            var UnitRentalCommissionMap = _unitRentalCommissionMapRepository.GetAllUnitRentalCommissionMapByUnitId(unitId);
            IList<UnitRentalCommission> UnitRentalCommissions = null;
            if (UnitRentalCommissionMap != null)
            {
                UnitRentalCommissions = new List<UnitRentalCommission>();
                foreach (UnitRentalCommissionMap item in UnitRentalCommissionMap)
                {
                    UnitRentalCommissions.Add(item.UnitRentalCommission);
                }
            }
            return UnitRentalCommissions;
        }
        public bool CreateUnitRentalCommissionMap(UnitRentalCommissionMapModel unitRentalCommissionMapModel)
        {
            Delete(unitRentalCommissionMapModel.UnitId);
            foreach (long unitRentalCommissionId in unitRentalCommissionMapModel.UnitRentalCommissionIds)
            {
                var unitRentalCommissionMap = new UnitRentalCommissionMap
                {
                    UnitId = unitRentalCommissionMapModel.UnitId,
                    UnitRentalCommissionId = unitRentalCommissionId,
                    CreatedOn = DateTime.UtcNow
                };
                var UnitUnitMap = _unitRentalCommissionMapRepository.CreateUnitRentalCommissionMap(unitRentalCommissionMap);
            }
            _unitOfWork.Commit();
            return true;
        }
        public bool UpdateUnitRentalCommissionMap(UnitRentalCommissionMapModel unitRentalCommissionMapModel)
        {
            Delete(unitRentalCommissionMapModel.UnitId);
            CreateUnitRentalCommissionMap(unitRentalCommissionMapModel);
            return true;
        }
        public bool Delete(long unitId)
        {
            var result = _unitRentalCommissionMapRepository.DeleteUnitRentalCommissionMap(unitId);
            _unitOfWork.Commit();
            return result;
        }
    }
}