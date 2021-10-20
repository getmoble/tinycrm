
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.DAL;
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
    public class PropertyRentalCommissionMapService : IPropertyRentalCommissionMapService
    {
        readonly IPropertyRentalCommissionMapRepository _propertyRentalCommissionMapRepository;
        readonly IUnitOfWork _unitOfWork;
        public PropertyRentalCommissionMapService(IPropertyRentalCommissionMapRepository propertyRentalCommissionMapRepository,
            IUnitOfWork unitOfWork)
        {
            _propertyRentalCommissionMapRepository = propertyRentalCommissionMapRepository;
            _unitOfWork = unitOfWork;
        }
        public long GetPropertyIdByPropertyRentalCommissionId(long PropertyRentalCommissionId)
        {
            return _propertyRentalCommissionMapRepository.GetPropertyIdByPropertyRentalCommissionId(PropertyRentalCommissionId);
        }
        public IList<long> GetAllPropertyRentalCommissionIdByPropertyId(long propertyId)
        {
            return _propertyRentalCommissionMapRepository.GetAllPropertyRentalCommissionIdByPropertyId(propertyId);
        }
        public IList<PropertyRentalCommission> GetAllPropertyRentalCommissionsByPropertyId(long propertyId)
        {
            var propertyRentalCommissionMap = _propertyRentalCommissionMapRepository.GetAllPropertyRentalCommissionMapByPropertyId(propertyId);
            IList<PropertyRentalCommission> propertyRentalCommissions = null;
            if (propertyRentalCommissionMap != null)
            {
                propertyRentalCommissions = new List<PropertyRentalCommission>();
                foreach (PropertyRentalCommissionMap item in propertyRentalCommissionMap)
                {
                    propertyRentalCommissions.Add(item.PropertyRentalCommission);
                }
            }
            return propertyRentalCommissions;
        }
        public bool CreatePropertyRentalCommissionMap(PropertyRentalCommissionMapModel propertyRentalCommissionMapModel)
        {
            Delete(propertyRentalCommissionMapModel.PropertyId);
            foreach (long propertyRentalCommissionId in propertyRentalCommissionMapModel.PropertyRentalCommissionIds)
            {
                var propertyRentalCommissionMap = new PropertyRentalCommissionMap
                {
                    PropertyId = propertyRentalCommissionMapModel.PropertyId,
                    PropertyRentalCommissionId = propertyRentalCommissionId,
                    CreatedOn=DateTime.UtcNow
                };
                var PropertyUnitMap = _propertyRentalCommissionMapRepository.CreatePropertyRentalCommissionMap(propertyRentalCommissionMap);
            }
            _unitOfWork.Commit();
            return true;
        }
        public bool UpdatePropertyRentalCommissionMap(PropertyRentalCommissionMapModel propertyRentalCommissionMapModel)
        {
            Delete(propertyRentalCommissionMapModel.PropertyId);
            CreatePropertyRentalCommissionMap(propertyRentalCommissionMapModel);
            return true;
        }
        public bool Delete(long propertyId)
        {
            var result = _propertyRentalCommissionMapRepository.DeletePropertyRentalCommissionMap(propertyId);
            _unitOfWork.Commit();
            return result;
        }
    }
}