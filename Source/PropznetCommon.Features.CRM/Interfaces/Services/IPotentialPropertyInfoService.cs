using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Potential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IPotentialPropertyInfoService
    {
        PotentialPropertyInfo CreatePotentialPropertyInfo(PotentialPropertyInfoModel potentialPropertyInfoModel);
        bool UpdatePotentialPropertyInfo(PotentialPropertyInfoModel potentialPropertyInfoModel);
        bool DeletePotentialPropertyInfo(long id);
    }
}