using System.Collections.Generic;
using PropznetCommon.Features.Common.Model;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;

namespace PropznetCommon.Features.Common.Interfaces.Service
{
    public interface IPotentialAmenityMapService
    {
        long GetPotentialIdByAmenityId(long potentialId);
        IList<long> GetAllAmenityIdByPotentialId(long potentialId);
        IList<Amenity> GetAllAmenityPotentialId(long potentialId);
        bool CreatePotentialAmenityMap(PotentialAmenityMapModel potentialAmenityMapModel);
        bool UpdatePotentialAmenityMap(PotentialAmenityMapModel potentialAmenityMapModel);
        bool Delete(long potentialId);
    }
}
