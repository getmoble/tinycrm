using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitRentalCommissionService
    {
        IList<UnitRentalCommission> GetAllUnitRentalCommissions();
        IList<UnitRentalCommission> GetAllUnitRentalCommissionById(IList<long> unitRentalCommissionsId);
        UnitRentalCommission CreateUnitRentalCommission(UnitRentalCommissionModel unitRentalCommissionModel);
        UnitRentalCommission UpdateUnitRentalCommission(UnitRentalCommissionModel unitRentalCommissionModel);
        bool DeleteUnitRentalCommission(long id);
        bool DeleteAllUnitRentalCommissionByUnitId(long unitId);
    }
}