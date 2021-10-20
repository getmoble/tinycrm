using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class AmenityRepository : GenericRepository<Amenity>, IAmenityRepository
    {
        readonly IERPDataContext _dataContext;
        public AmenityRepository(IERPDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<Amenity> GetAllAmenities()
        {
            var amenities = _dataContext.Amenities
                        .Where(i => !i.DeletedOn.HasValue)
                        .OrderByDescending(x => x.CreatedOn)
                        .Distinct().ToList();
            return amenities;
        }
        public IList<Amenity> GetAllAmenitiesById(IList<long> amenityId)
        {
            return _dataContext.Amenities
                .Where(i => amenityId.Contains(i.Id))
                .OrderByDescending(x => x.CreatedOn)
                .ToList();
        }
        public bool DeleteAmenity(long id)
        {
            var amenity = _dataContext.Amenities.FirstOrDefault(i => i.Id == id);
            amenity.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}