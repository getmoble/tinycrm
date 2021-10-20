using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Amenity;

namespace PropznetCommon.Features.ERP.Services
{
    public class AmenityService : IAmenityService
    {
        readonly IAmenityRepository _amenityRepository;
        readonly IAmenityMapRepository _amenityMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public AmenityService(IAmenityRepository amenityRepository,
            IAmenityMapRepository amenityMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _amenityRepository = amenityRepository;
            _amenityMapRepository = amenityMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }

        public Amenity CreateAmenity(AmenityModel amenityModel)
        {
            var amenity = new Amenity
            {
                Name = amenityModel.Name,
                CreatedBy = amenityModel.CreatedBy
            };
            var createdAmenity = _amenityRepository.Create(amenity);
            _iUnitOfWork.Commit();
            return createdAmenity;
        }
        public IList<Amenity> GetAllAmenities()
        {
            return _amenityRepository.GetAllAmenities();
        }

        public IList<Amenity> GetAllAmenitiesById(IList<long> amenityId)
        {
            return _amenityRepository.GetAllAmenitiesById(amenityId);
        }
        public bool DeleteAmenity(long id)
        {
            var result= _amenityRepository.DeleteAmenity(id);
            _iUnitOfWork.Commit();
            return result;
        }
    }
}