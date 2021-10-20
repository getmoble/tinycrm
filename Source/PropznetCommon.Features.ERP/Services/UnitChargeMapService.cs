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
    public class UnitChargeMapService : IUnitChargeMapService
    {
        readonly IUnitChargeMapRepository _unitChargeMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public UnitChargeMapService(
            IUnitChargeMapRepository unitChargeMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _unitChargeMapRepository = unitChargeMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long GetUnitIdByChargeId(long chargeId)
        {
            var unitId = _unitChargeMapRepository.GetUnitIdByChargeId(chargeId);
            return unitId;
        }
        public IList<long> GetAllChargeIdByUnitId(long unitId)
        {
            var chargeIds = _unitChargeMapRepository.GetAllChargeIdByUnitId(unitId);
            return chargeIds;
        }
        public IList<Charge> GetAllChargesByUnitId(long unitId)
        {
            var unitChargeMap = _unitChargeMapRepository.GetAllUnitChargeMapByUnitId(unitId);
            IList<Charge> charges = null;
            if (unitChargeMap != null)
            {
                charges = new List<Charge>();
                foreach (UnitChargeMap item in unitChargeMap)
                {
                    charges.Add(item.Charge);
                }
            }
            return charges;
        }
        public bool CreateUnitChargeMap(UnitChargeMapModel unitChargeMapModel)
        {
            Delete(unitChargeMapModel.UnitId);
            foreach (long chargeId in unitChargeMapModel.ChargeId)
            {
                var UnitChargeMap = new UnitChargeMap
                {
                    UnitId = unitChargeMapModel.UnitId,
                    ChargeId = chargeId,
                    CreatedOn = DateTime.UtcNow
                };
                var unitUnitMap = _unitChargeMapRepository.CreateUnitChargeMap(UnitChargeMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdateUnitChargeMap(UnitChargeMapModel unitChargeMapModel)
        {
            Delete(unitChargeMapModel.Id);
            CreateUnitChargeMap(unitChargeMapModel);
            return true;
        }
        public bool Delete(long unitId)
        {
            var result = _unitChargeMapRepository.DeleteUnitChargeMap(unitId);
            _iUnitOfWork.Commit();
            return result;
        }
    }
}