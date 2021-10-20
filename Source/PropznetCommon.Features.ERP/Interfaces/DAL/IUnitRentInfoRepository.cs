using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IUnitRentInfoRepository : IGenericRepository<UnitRentInfo>
    {
        bool DeleteRentInfo(long id);
        UnitRentInfo GetRentInfo(long id);
    }
}
