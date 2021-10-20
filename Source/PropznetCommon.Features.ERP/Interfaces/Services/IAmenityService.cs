using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Amenity;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
   public interface IAmenityService
    {
       Amenity CreateAmenity(AmenityModel amenityModel);
       IList<Amenity> GetAllAmenities();
       IList<Amenity> GetAllAmenitiesById(IList<long> amenityId);
       bool DeleteAmenity(long id);
    }
}
