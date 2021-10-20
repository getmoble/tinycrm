using Common.Data.Interfaces;
using PropznetCommon.Features.Common.Entities;
using PropznetCommon.Features.Common.Interfaces.DAL;
using PropznetCommon.Features.Common.Interfaces.Service;
using PropznetCommon.Features.Common.Model;
using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.Common.Services
{
    public class PotentialPropertyMapService : IPotentialPropertyMapService
    {
         readonly IPotentialPropertyMapRepository _potentialPropertyMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PotentialPropertyMapService(
            IPotentialPropertyMapRepository potentialPropertyMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _potentialPropertyMapRepository = potentialPropertyMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long GetPotentialIdByPropertyId(long PropertyId)
        {
            return _potentialPropertyMapRepository.GetPotentialIdByPropertyId(PropertyId);
        }

        public IList<long> GetAllPropertyIdByPotentialId(long potentialId)
        {
            return _potentialPropertyMapRepository.GetAllPropertyIdByPotentialId(potentialId);
        }

        public IList<ERPProperty> GetAllPropertyPotentialId(long potentialId)
        {
            IList<ERPProperty> amenities = null;
            var PropertyMap = _potentialPropertyMapRepository.GetAllPropertyMapByPotentialId(potentialId);
            if (PropertyMap != null)
            {
                amenities = new List<ERPProperty>();
                foreach (PotentialPropertyMap item in PropertyMap)
                {
                    amenities.Add(item.Property);
                }
            }
            return amenities;
        }

        public bool CreatePotentialPropertyMap(PotentialPropertyMapModel potentialPropertyMapModel)
        {
            foreach (long PropertyId in potentialPropertyMapModel.PropertyId)
            {
                var potentialPropertyMap = new PotentialPropertyMap
                {
                    PotentialId =  potentialPropertyMapModel.PotentialId,
                    PropertyId = PropertyId
                };
                _potentialPropertyMapRepository.CreatePotentialPropertyMap(potentialPropertyMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }

        public bool UpdatePotentialPropertyMap(PotentialPropertyMapModel potentialPropertyMapModel)
        {
            Delete(potentialPropertyMapModel.PotentialId);
            CreatePotentialPropertyMap(potentialPropertyMapModel);
            return true;
        }

        public bool Delete(long propertyId)
        {
            var result = _potentialPropertyMapRepository.DeletePotentialPropertyMap(propertyId);
            _iUnitOfWork.Commit();
            return result;
        }
    }
}