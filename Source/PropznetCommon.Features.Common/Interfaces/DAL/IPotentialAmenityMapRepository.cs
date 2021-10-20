using System.Collections.Generic;
using PropznetCommon.Features.Common.Entities;

namespace PropznetCommon.Features.Common.Interfaces.DAL
{
    public interface IPotentialAmenityMapRepository
    {
        bool CreatePotentialAmenityMap(PotentialAmenityMap potentialAmenityMap);
        IList<long> GetAllAmenityIdByPotentialId(long potentialId);
        IList<PotentialAmenityMap> GetAllAmenityMapByPotentialId(long potentialId);
        long GetPotentialIdByAmenityId(long amenityId);
        bool DeletePotentialAmenityMap(long id);
    }
}
