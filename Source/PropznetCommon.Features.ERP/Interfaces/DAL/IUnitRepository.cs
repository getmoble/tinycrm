using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IUnitRepository : IGenericRepository<Unit>
    {
        Unit GetUnitById(long id);
        IList<Unit> GetAllUnits(IList<long> unitId);
        IList<Unit> GetAllUnits();
        bool DeleteUnit(long id);
    }
}