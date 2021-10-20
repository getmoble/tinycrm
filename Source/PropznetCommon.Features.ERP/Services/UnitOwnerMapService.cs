using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Unit;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class UnitOwnerMapService : IUnitOwnerMapservice
    {
        readonly IUnitOwnerMapRepository _unitOwnerMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public UnitOwnerMapService(
            IUnitOwnerMapRepository unitOwnerMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _unitOwnerMapRepository = unitOwnerMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long GetUnitIdByOwnerId(long ownerId)
        {
            return _unitOwnerMapRepository.GetUnitIdByOwnerId(ownerId);
        }

        public IList<long> GetAllOwnerIdByUnitId(long unitId)
        {
            return _unitOwnerMapRepository.GetAllOwnerIdByUnitId(unitId);
        }

        public bool CreatePropertyOwnerMap(UnitOwnerMapModel unitOwnerMapModel)
        {
            Delete(unitOwnerMapModel.UnitId);
            foreach (long ownerId in unitOwnerMapModel.OwnerId)
            {
                var unitOwnerMap = new UnitOwnerMap
                {
                    UnitId = unitOwnerMapModel.UnitId,
                    OwnerId = ownerId,
                    CreatedOn = DateTime.UtcNow
                };
                var PropertyUnitMap = _unitOwnerMapRepository.CreateUnitOwnerMap(unitOwnerMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }

        public bool UpdatePropertyOwnerMap(UnitOwnerMapModel unitOwnerMapModel)
        {
            this.Delete(unitOwnerMapModel.Id);
            this.CreatePropertyOwnerMap(unitOwnerMapModel);
            return true;
        }
        public bool Delete(long unitId)
        {
            var result = _unitOwnerMapRepository.DeleteUnitOwnerMap(unitId);
            _iUnitOfWork.Commit();
            return result;
        }
        public IList<Owner> GetAllOwnerByUnitId(long unitId)
        {
            IList<Owner> managers = null;
            var unitOwnerMap = _unitOwnerMapRepository.GetAllUnitOwnerMapByUnitId(unitId);
            if (unitOwnerMap != null)
            {
                managers = new List<Owner>();
                foreach (UnitOwnerMap item in unitOwnerMap)
                {
                    managers.Add(item.Owner);
                }
            }
            return managers;
        }
    }
}