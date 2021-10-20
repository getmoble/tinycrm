using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Services
{
    public class PropertyRentInfoMapService : IPropertyRentInfoMapService
    {
        readonly IPropertyRentInfoMapRepository _propertyRentInfoMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyRentInfoMapService(
            IPropertyRentInfoMapRepository propertyRentInfoMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _propertyRentInfoMapRepository = propertyRentInfoMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long GetPropertyIdByRentInfoId(long rentInfoId)
        {
            return _propertyRentInfoMapRepository.GetPropertyIdByRentInfoId(rentInfoId);
        }
        public IList<long> GetAllRentInfoIdByPropertyId(long propertyId)
        {
            return _propertyRentInfoMapRepository.GetAllRentInfoIdByPropertyId(propertyId);
        }
        public IList<PropertyRentInfo> GetAllRentInfosByPropertyId(long propertyId)
        {
            var propertyRentInfoMap = _propertyRentInfoMapRepository.GetAllPropertyRentInfoMapByPropertyId(propertyId);
            IList<PropertyRentInfo> propertyRentInfo = null;
            if (propertyRentInfoMap != null)
            {
                propertyRentInfo = new List<PropertyRentInfo>();
                foreach (PropertyRentInfoMap item in propertyRentInfoMap)
                {
                    propertyRentInfo.Add(item.RentInfo);
                }
            }
            return propertyRentInfo;
        }
        public bool CreatePropertyRentInfoMap(PropertyRentInfoMapModel propertyRentInfoMapModel)
        {
            Delete(propertyRentInfoMapModel.PropertyId);
            foreach (long rentInfoId in propertyRentInfoMapModel.RentInfoIds)
            {
                var propertyRentInfoMap = new PropertyRentInfoMap
                {
                    PropertyId = propertyRentInfoMapModel.PropertyId,
                    RentInfoId = rentInfoId,
                    CreatedOn=DateTime.UtcNow
                };
                var PropertyUnitMap = _propertyRentInfoMapRepository.CreatePropertyRentInfoMap(propertyRentInfoMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdatePropertyRentInfoMap(Model.Property.PropertyRentInfoMapModel propertyRentInfoMapModel)
        {
            Delete(propertyRentInfoMapModel.Id);
            CreatePropertyRentInfoMap(propertyRentInfoMapModel);
            return true;
        }
        public bool Delete(long propertyId)
        {
            var result = _propertyRentInfoMapRepository.DeletePropertyRentInfoMap(propertyId);
            _iUnitOfWork.Commit();
            return result;
        }
    }
}