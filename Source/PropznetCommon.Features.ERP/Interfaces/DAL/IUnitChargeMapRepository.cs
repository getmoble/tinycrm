using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IUnitChargeMapRepository
    {
        bool CreateUnitChargeMap(UnitChargeMap unitChargeMap);
        IList<long> GetAllChargeIdByUnitId(long unitId);
        IList<UnitChargeMap> GetAllUnitChargeMapByUnitId(long unitId);
        long GetUnitIdByChargeId(long chargeId);
        bool DeleteUnitChargeMap(long unitId);
    }
}