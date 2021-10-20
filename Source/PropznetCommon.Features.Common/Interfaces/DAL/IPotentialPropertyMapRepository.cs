using PropznetCommon.Features.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.Common.Interfaces.DAL
{
    public interface IPotentialPropertyMapRepository
    {
        bool CreatePotentialPropertyMap(PotentialPropertyMap potentialPropertyMap);
        IList<long> GetAllPropertyIdByPotentialId(long potentialId);
        IList<PotentialPropertyMap> GetAllPropertyMapByPotentialId(long potentialId);
        long GetPotentialIdByPropertyId(long propertyId);
        bool DeletePotentialPropertyMap(long id);
    }
}