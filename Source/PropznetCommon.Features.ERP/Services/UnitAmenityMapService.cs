using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Unit;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class UnitAmenityMapService : IUnitAmenityMapService
    {
        readonly IUnitAmenityMapRepository _unitAmenityMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public UnitAmenityMapService(
            IUnitAmenityMapRepository unitAmenityMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _unitAmenityMapRepository = unitAmenityMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long GetUnitIdByAmenityId(long amenityId)
        {
            return _unitAmenityMapRepository.GetUnitIdByAmenityId(amenityId);
        }
        public IList<long> GetAllAmenityIdByUnitId(long unitId)
        {
            return _unitAmenityMapRepository.GetAllAmenityIdByUnitId(unitId);
        }
        public bool CreateUnitAmenityMap(UnitAmenityMapModel unitAmenityMapModel)
        {
            Delete(unitAmenityMapModel.UnitId);
            foreach (long amenityId in unitAmenityMapModel.AmenityId)
            {
                var unitAmenityMap = new UnitAmenityMap
                {
                    UnitId = unitAmenityMapModel.UnitId,
                    AmenityId = amenityId,
                    CreatedOn = DateTime.UtcNow
                };
                var PropertyAmenityMap = _unitAmenityMapRepository.CreateUnitAmenityMap(unitAmenityMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdateUnitAmenityMap(UnitAmenityMapModel unitAmenityMapModel)
        {
            this.Delete(unitAmenityMapModel.UnitId);
            this.CreateUnitAmenityMap(unitAmenityMapModel);
            return true;
        }
        public bool Delete(long unitId)
        {
            var result = _unitAmenityMapRepository.DeleteUnitAmenityMap(unitId);
            _iUnitOfWork.Commit();
            return result;
        }
        public IList<Amenity> GetAllAmenityByUnitId(long unitId)
        {
            IList<Amenity> amenities = null;
            var unitAmenityMap = _unitAmenityMapRepository.GetAllAmenityMapByUnitId(unitId);
            if (unitAmenityMap != null)
            {
                amenities = new List<Amenity>();
                foreach (UnitAmenityMap item in unitAmenityMap)
                {
                    amenities.Add(item.Amenity);
                }
            }
            return amenities;
        }
    }
}