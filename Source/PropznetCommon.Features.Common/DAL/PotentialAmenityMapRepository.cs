using System;
using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.Common.Entities;
using PropznetCommon.Features.Common.Interfaces.Data;
using PropznetCommon.Features.Common.Interfaces.DAL;
using System.Data.Entity;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.Common.DAL
{
    public class PotentialAmenityMapRepository:IPotentialAmenityMapRepository
    {
         readonly ICommonDataContext _dataContext;
         public PotentialAmenityMapRepository(ICommonDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePotentialAmenityMap(PotentialAmenityMap potentialAmenityMap)
        {
            _dataContext.PotentialAmenityMaps.Add(potentialAmenityMap);
            return true;
        }

        public IList<long> GetAllAmenityIdByPotentialId(long potentialId)
        {
            return _dataContext.PotentialAmenityMaps
                .Where(i => i.PotentialId == potentialId)
                .Select(i => i.AmenityId).Distinct().ToList();
        }

        public IList<PotentialAmenityMap> GetAllAmenityMapByPotentialId(long potentialId)
        {
            return _dataContext.PotentialAmenityMaps
              .Where(u => u.PotentialId == potentialId)
              .Include(i => i.Potential)
              .Include(p => p.Amenity).ToList();
        }

        public long GetPotentialIdByAmenityId(long amenityId)
        {
            var potentialAmenityMap = _dataContext.PotentialAmenityMaps
                .SingleOrDefault(i => i.AmenityId == amenityId);
                return potentialAmenityMap.PotentialId;
        }

        public bool DeletePotentialAmenityMap(long id)
        {
            var potentialAmenityMap = _dataContext.PotentialAmenityMaps
                                    .Where(i => i.Id == id).ToList();
            foreach (PotentialAmenityMap item in potentialAmenityMap)
            {
                _dataContext.PotentialAmenityMaps.Remove(item);
            }
            return true;
        }
    }
}
