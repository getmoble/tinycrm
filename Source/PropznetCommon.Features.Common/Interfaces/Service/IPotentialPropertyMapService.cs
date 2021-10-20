using PropznetCommon.Features.Common.Model;
using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.Common.Interfaces.Service
{
    public interface IPotentialPropertyMapService
    {
        long GetPotentialIdByPropertyId(long potentialId);
        IList<long> GetAllPropertyIdByPotentialId(long potentialId);
        IList<ERPProperty> GetAllPropertyPotentialId(long potentialId);
        bool CreatePotentialPropertyMap(PotentialPropertyMapModel potentialPropertyMapModel);
        bool UpdatePotentialPropertyMap(PotentialPropertyMapModel potentialPropertyMapModel);
        bool Delete(long potentialId);
    }
}
