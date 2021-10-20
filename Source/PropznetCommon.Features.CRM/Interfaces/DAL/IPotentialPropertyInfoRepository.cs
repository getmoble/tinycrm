using Common.Data.Interfaces;
using PropznetCommon.Features.CRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface IPotentialPropertyInfoRepository : IGenericRepository<PotentialPropertyInfo>
    {
        bool DeletePotentialPropertyInfo(long id);
    }
}