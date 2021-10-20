using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Property;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class PropertyUnitMapService : IPropertyUnitMapService
    {
        readonly IPropertyUnitMapRepository _propertyUnitMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyUnitMapService(
            IPropertyUnitMapRepository propertyUnitMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _propertyUnitMapRepository = propertyUnitMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long GetPropertyIdByUnitId(long unitId)
        {
            return _propertyUnitMapRepository.GetPropertyIdByUnitId(unitId);
        }
        public IList<long> GetAllUnitIdByPropertyId(long propertyId)
        {
            return _propertyUnitMapRepository.GetAllUnitIdByPropertyId(propertyId);
        }
        public bool CreatePropertyUnitMap(PropertyUnitMapModel propertyUnitMapModel)
        {
            Delete(propertyUnitMapModel.PropertyId);
            foreach (long unitId in propertyUnitMapModel.UnitId)
            {
                var propertyUnitMap = new PropertyUnitMap
                {
                    PropertyId = propertyUnitMapModel.PropertyId,
                    UnitId = unitId,
                    CreatedOn = DateTime.UtcNow
                };
                var PropertyUnitMap = _propertyUnitMapRepository.CreatePropertyUnitMap(propertyUnitMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdatePropertyOwnerMap(PropertyUnitMapModel propertyUnitMapModel)
        {
            this.Delete(propertyUnitMapModel.Id);
            this.CreatePropertyUnitMap(propertyUnitMapModel);
            return true;
        }
        public bool Delete(long propertyId)
        {
            var result = _propertyUnitMapRepository.DeletePropertyUnityMap(propertyId);
            _iUnitOfWork.Commit();
            return result;
        }
        public IList<Unit> GetAllUnitsByPropertyId(long propertyId)
        {
            var propertyUnitMap = _propertyUnitMapRepository.GetAllPropertyUnitMap(propertyId);
            IList<Unit> units = null;
            if (propertyUnitMap != null)
            {
                units = new List<Unit>();
                foreach (PropertyUnitMap item in propertyUnitMap)
                {
                    units.Add(item.Unit);
                }
            }
            return units;
        }
    }
}