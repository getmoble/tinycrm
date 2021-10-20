using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Unit;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class UnitManagerMapService : IUnitManagerMapService
    {
        readonly IUnitManagerMapRepository _unitManagerMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public UnitManagerMapService(
            IUnitManagerMapRepository unitManagerMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _unitManagerMapRepository = unitManagerMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public bool CreateUnitManagerMap(UnitManagerMapModel unitManagerMapModel)
        {
            Delete(unitManagerMapModel.UnitId);
            foreach (long managerId in unitManagerMapModel.ManagerId)
            {
                var unitManagerMap = new UnitManagerMap
                {
                    UnitId = unitManagerMapModel.UnitId,
                    ManagerId = managerId,
                    CreatedOn = DateTime.UtcNow
                };
                var createdUnitManagerMap = _unitManagerMapRepository.CreateUnitManagerMap(unitManagerMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }
        public IList<long> GetAllManagerIdByUnitId(long unitId)
        {
            return _unitManagerMapRepository.GetAllManagerIdByUnitId(unitId);
        }
        public long GetUnitIdByManagerId(long managerId)
        {
            return _unitManagerMapRepository.GetUnitIdByManagerId(managerId);
        }
        public bool UpdateUnitManagerMap(UnitManagerMapModel unitManagerMapModel)
        {
            this.Delete(unitManagerMapModel.Id);
            this.CreateUnitManagerMap(unitManagerMapModel);
            return true;
        }
        public bool Delete(long unitId)
        {
            var result = _unitManagerMapRepository.DeleteUnitManagerMap(unitId);
            _iUnitOfWork.Commit();
            return result;
        }
        public IList<Manager> GetAllManagerByUnitId(long unitId)
        {
            IList<Manager> managers = null;
            var unitManagerMap = _unitManagerMapRepository.GetAllUnitManagerMapByUnitId(unitId);
            if (unitManagerMap != null)
            {
                managers = new List<Manager>();
                foreach (UnitManagerMap item in unitManagerMap)
                {
                    managers.Add(item.Manager);
                }
            }
            return managers;
        }
    }
}