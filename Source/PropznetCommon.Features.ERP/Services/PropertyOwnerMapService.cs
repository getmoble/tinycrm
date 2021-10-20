using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Property;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class PropertyOwnerMapService : IPropertyOwnerMapService
    {
        readonly IPropertyOwnerMapRepository _propertyOwnerMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyOwnerMapService(
            IPropertyOwnerMapRepository propertyOwnerMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _propertyOwnerMapRepository = propertyOwnerMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long GetPropertyIdByOwnerId(long ownerId)
        {
            return _propertyOwnerMapRepository.GetPropertyIdByOwnerId(ownerId);
        }
        public IList<long> GetAllOwnerIdByPropertyId(long propertyId)
        {
            return _propertyOwnerMapRepository.GetAllOwnerIdByPropertyId(propertyId);
        }
        public bool CreatePropertyOwnerMap(PropertyOwnerMapModel propertyOwnerMapModel)
        {
            Delete(propertyOwnerMapModel.PropertyId);
            foreach (long ownerId in propertyOwnerMapModel.OwnerId)
            {
                var propertyOwnerMap = new PropertyOwnerMap
                {
                    PropertyId = propertyOwnerMapModel.PropertyId,
                    OwnerId = ownerId,
                    CreatedOn=DateTime.UtcNow
                };
                var PropertyUnitMap = _propertyOwnerMapRepository.CreatePropertyOwnerMap(propertyOwnerMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdatePropertyOwnerMap(PropertyOwnerMapModel propertyOwnerMapModel)
        {
            Delete(propertyOwnerMapModel.Id);
            CreatePropertyOwnerMap(propertyOwnerMapModel);
            return true;
        }
        public bool Delete(long propertyId)
        {
            var result = _propertyOwnerMapRepository.DeletePropertyOwnerMap(propertyId);
            _iUnitOfWork.Commit();
            return result;
        }
        public IList<Owner> GetAllOwnersByPropertyId(long propertyId)
        {
            var propertyOwnerMap = _propertyOwnerMapRepository.GetAllPropertyOwnerMapByPropertyId(propertyId);
            IList<Owner> owners = null;
            if (propertyOwnerMap != null)
            {
                owners = new List<Owner>();
                foreach (PropertyOwnerMap item in propertyOwnerMap)
                {
                    owners.Add(item.Owner);
                }
            }
            return owners;
        }
    }
}