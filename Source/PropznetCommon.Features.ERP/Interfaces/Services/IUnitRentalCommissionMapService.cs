using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitRentalCommissionMapService
    {
        long GetUnitIdByUnitRentalCommissionId(long unitRentalCommissionId);
        IList<long> GetAllUnitRentalCommissionIdByUnitId(long unitId);
        IList<UnitRentalCommission> GetAllUnitRentalCommissionsByUnitId(long unitId);
        bool CreateUnitRentalCommissionMap(UnitRentalCommissionMapModel unitRentalCommissionMapModel);
        bool UpdateUnitRentalCommissionMap(UnitRentalCommissionMapModel unitRentalCommissionMapModel);
        bool Delete(long unitId);
    }
}
