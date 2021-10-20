using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Property;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class PropertyManagerMapService : IPropertyManagerMapService
    {
        readonly IPropertyManagerMapRepository _propertyManagerMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyManagerMapService(
            IPropertyManagerMapRepository propertyManagerMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _propertyManagerMapRepository = propertyManagerMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public bool CreatePropertyManagerMap(PropertyManagerMapModel propertyManagerMapModel)
        {
            Delete(propertyManagerMapModel.PropertyId);
            foreach (long managerId in propertyManagerMapModel.ManagerId)
            {
                var propertyManagerMap = new PropertyManagerMap
                {
                    PropertyId = propertyManagerMapModel.PropertyId,
                    ManagerId = managerId,
                    CreatedOn=DateTime.UtcNow
                };
                var createdPropertyManagerMap = _propertyManagerMapRepository.CreatePropertyManagerMap(propertyManagerMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }

        public IList<long> GetAllManagerIdByPropertyId(long propertyId)
        {
            return _propertyManagerMapRepository.GetAllManagerIdByPropertyId(propertyId);
        }

        public long GetPropertyIdByManagerId(long managerId)
        {
            return _propertyManagerMapRepository.GetPropertyIdByManagerId(managerId);
        }

        public bool Delete(long propertyId)
        {
            var result = _propertyManagerMapRepository.DeletePropertyManagerMap(propertyId);
            _iUnitOfWork.Commit();
            return result;
        }
        public bool UpdatePropertyManagerMap(PropertyManagerMapModel propertyManagerMapModel)
        {
            this.Delete(propertyManagerMapModel.Id);
            this.CreatePropertyManagerMap(propertyManagerMapModel);
            return true;
        }
        public IList<Manager> GetAllManagerByPropertyId(long propertyId)
        {
            IList<Manager> managers = null;
            var propertyManagerMap = _propertyManagerMapRepository.GetAllManagerMapByPropertyId(propertyId);
            if (propertyManagerMap != null)
            {
                managers = new List<Manager>();
                foreach (PropertyManagerMap item in propertyManagerMap)
                {
                    managers.Add(item.Manager);
                }
            }
            return managers;
        }
    }
}
