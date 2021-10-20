using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitChargeMapService
    {
        long GetUnitIdByChargeId(long chargeId);
        IList<long> GetAllChargeIdByUnitId(long unitId);
        IList<Charge> GetAllChargesByUnitId(long unitId);
        bool CreateUnitChargeMap(UnitChargeMapModel unitChargeMapModel);
        bool UpdateUnitChargeMap(UnitChargeMapModel unitChargeMapModel);
        bool Delete(long unitId);
    }
}
