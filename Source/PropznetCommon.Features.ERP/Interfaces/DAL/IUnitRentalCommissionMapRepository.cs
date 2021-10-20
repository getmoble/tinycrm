using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IUnitRentalCommissionMapRepository
    {
        bool CreateUnitRentalCommissionMap(UnitRentalCommissionMap unitRentalCommissionMap);
        IList<long> GetAllUnitRentalCommissionIdByUnitId(long unitId);
        IList<UnitRentalCommissionMap> GetAllUnitRentalCommissionMapByUnitId(long unitId);
        long GetUnitIdByUnitRentalCommissionId(long unitRentalCommissionId);
        bool DeleteUnitRentalCommissionMap(long unitId);
    }
}
