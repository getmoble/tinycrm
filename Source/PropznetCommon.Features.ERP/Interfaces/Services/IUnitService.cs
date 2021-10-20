using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Unit;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitService
    {
        Unit CreateUnit(UnitModel UnitModel);
        Unit GetUnitById(long id);
        IList<Unit> GetAllUnits(IList<long> id);
        IList<Unit> GetAllUnits();
        bool UpdateUnit(UnitModel unitModel);
        bool UpdateSalesCommissionDetails(SalesCommissionModel salesCommissionModel);
        bool DeleteUnit(long id);
    }
}