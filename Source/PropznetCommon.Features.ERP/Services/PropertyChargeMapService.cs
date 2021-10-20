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
    public class PropertyChargeMapService : IPropertyChargeMapSevice
    {
        readonly IPropertyChargeMapRepository _propertyChargeMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyChargeMapService(
            IPropertyChargeMapRepository propertyChargeMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _propertyChargeMapRepository = propertyChargeMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }

        public long GetPropertyIdByChargeId(long chargeId)
        {
            var propertyId = _propertyChargeMapRepository.GetPropertyIdByChargeId(chargeId);
            return propertyId;
        }
        public IList<long> GetAllChargeIdByPropertyId(long propertyId)
        {
            var chargeIds = _propertyChargeMapRepository.GetAllChargeIdByPropertyId(propertyId);
            return chargeIds;
        }
        public IList<Charge> GetAllChargesByPropertyId(long propertyId)
        {
            var propertyChargeMap = _propertyChargeMapRepository.GetAllPropertyChargeMapByPropertyId(propertyId);
            IList<Charge> charges = null;
            if (propertyChargeMap != null)
            {
                charges = new List<Charge>();
                foreach (PropertyChargeMap item in propertyChargeMap)
                {
                    charges.Add(item.Charge);
                }
            }
            return charges;
        }
        public bool CreatePropertyChargeMap(PropertyChargeMapModel propertyChargeMapModel)
        {
            Delete(propertyChargeMapModel.PropertyId);
            foreach (long chargeId in propertyChargeMapModel.ChargeId)
            {
                var propertyChargeMap = new PropertyChargeMap
                {
                    PropertyId = propertyChargeMapModel.PropertyId,
                    ChargeId = chargeId,
                    CreatedOn=DateTime.UtcNow
                };
                var PropertyUnitMap = _propertyChargeMapRepository.CreatePropertyChargeMap(propertyChargeMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdatePropertyChargeMap(PropertyChargeMapModel propertyChargeMapModel)
        {
            Delete(propertyChargeMapModel.Id);
            CreatePropertyChargeMap(propertyChargeMapModel);
            return true;
        }
        public bool Delete(long propertyId)
        {
            var result = _propertyChargeMapRepository.DeletePropertyChargeMap(propertyId);
            _iUnitOfWork.Commit();
            return result;
        }
    }
}