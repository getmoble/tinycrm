using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Common.Entities;
using PropznetCommon.Features.Common.Interfaces.DAL;
using PropznetCommon.Features.Common.Interfaces.Service;
using PropznetCommon.Features.Common.Model;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.Common.Services
{
    public class PotentialAmenityMapService : IPotentialAmenityMapService
    {
        readonly IPotentialAmenityMapRepository _potentialAmenityMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PotentialAmenityMapService(
            IPotentialAmenityMapRepository potentialAmenityMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _potentialAmenityMapRepository = potentialAmenityMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long GetPotentialIdByAmenityId(long amenityId)
        {
            return _potentialAmenityMapRepository.GetPotentialIdByAmenityId(amenityId);
        }

        public IList<long> GetAllAmenityIdByPotentialId(long potentialId)
        {
            return _potentialAmenityMapRepository.GetAllAmenityIdByPotentialId(potentialId);
        }

        public IList<Amenity> GetAllAmenityPotentialId(long potentialId)
        {
            IList<Amenity> amenities = null;
            var amenityMap = _potentialAmenityMapRepository.GetAllAmenityMapByPotentialId(potentialId);
            if (amenityMap != null)
            {
                amenities = new List<Amenity>();
                foreach (PotentialAmenityMap item in amenityMap)
                {
                    amenities.Add(item.Amenity);
                }
            }
            return amenities;
        }

        public bool CreatePotentialAmenityMap(PotentialAmenityMapModel potentialAmenityMapModel)
        {
            foreach (long amenityId in potentialAmenityMapModel.AmenityId)
            {
                var potentialAmenityMap = new PotentialAmenityMap
                {
                    PotentialId =  potentialAmenityMapModel.PotentialId,
                    AmenityId = amenityId
                };
                _potentialAmenityMapRepository.CreatePotentialAmenityMap(potentialAmenityMap);
            }
            _iUnitOfWork.Commit();
            return true;
        }

        public bool UpdatePotentialAmenityMap(PotentialAmenityMapModel potentialAmenityMapModel)
        {
            Delete(potentialAmenityMapModel.PotentialId);
            CreatePotentialAmenityMap(potentialAmenityMapModel);
            return true;
        }

        public bool Delete(long propertyId)
        {
            var result = _potentialAmenityMapRepository.DeletePotentialAmenityMap(propertyId);
            _iUnitOfWork.Commit();
            return result;
        }
    }
}
