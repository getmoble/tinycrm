using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IAmenityRepository : IGenericRepository<Amenity>
    {
        IList<Amenity> GetAllAmenities();
        IList<Amenity> GetAllAmenitiesById(IList<long> amenityId);
        bool DeleteAmenity(long amenityId);

        //SearchResult<Amenity> SearchPortfolio(PortfolioSearchFilter searchargument, int pagesize, int count, long userId);
    }
}
