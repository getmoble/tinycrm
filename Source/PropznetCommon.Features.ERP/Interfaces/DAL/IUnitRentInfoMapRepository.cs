using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IUnitRentInfoMapRepository
    {
        bool CreateUnitRentInfoMap(UnitRentInfoMap unitRentInfoMap);
        IList<long> GetAllRentInfoIdByUnitId(long unitId);
        IList<UnitRentInfoMap> GetAllUnitRentInfoMapByUnitId(long unitId);
        long GetUnitIdByRentInfoId(long rentInfoId);
        bool DeleteUnitRentInfoMap(long unitId);
    }
}
