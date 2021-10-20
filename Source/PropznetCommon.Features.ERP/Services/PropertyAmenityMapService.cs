using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Property;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class PropertyAmenityMapService : IPropertyAmenityMapService
    {
        readonly IPropertyAmenityMapRepository _propertyAmenityMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyAmenityMapService(
            IPropertyAmenityMapRepository propertyAmenityMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _propertyAmenityMapRepository = propertyAmenityMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long GetPropertyIdByAmenityId(long amenityId)
        {
            return _propertyAmenityMapRepository.GetPropertyIdByAmenityId(amenityId);
        }
        public IList<long> GetAllAmenityIdByPropertyId(long propertyId)
        {
            return _propertyAmenityMapRepository.GetAllAmenityIdByPropertyId(propertyId);
        }
        public bool CreatePropertyAmenityMap(PropertyAmenityMapModel propertyAmenityMapModel)
        {
            Delete(propertyAmenityMapModel.PropertyId);
            foreach (long amenityId in propertyAmenityMapModel.AmenityId)
            {
                var propertyAmenityMap = new PropertyAmenityMap
                {
                    PropertyId = propertyAmenityMapModel.PropertyId,
                    AmenityId = amenityId,
                    CreatedOn = DateTime.UtcNow
                };
                _propertyAmenityMapRepository.CreatePropertyAmenityMap(propertyAmenityMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdatePropertyAmenityMap(PropertyAmenityMapModel propertyAmenityMapModel)
        {
            this.Delete(propertyAmenityMapModel.PropertyId);
            this.CreatePropertyAmenityMap(propertyAmenityMapModel);
            return true;
        }
        public bool Delete(long propertyId)
        {
            var result = _propertyAmenityMapRepository.DeletePropertyAmenityMap(propertyId);
            _iUnitOfWork.Commit();
            return result;
        }
        public IList<Amenity> GetAllAmenityPropertyId(long propertyId)
        {
            IList<Amenity> amenities = null;
            var amenityMap = _propertyAmenityMapRepository.GetAllAmenityMapByPropertyId(propertyId);
            if (amenityMap != null)
            {
                amenities = new List<Amenity>();
                foreach (PropertyAmenityMap item in amenityMap)
                {
                    amenities.Add(item.Amenity);
                }
            }
            return amenities;
        }
    }
}