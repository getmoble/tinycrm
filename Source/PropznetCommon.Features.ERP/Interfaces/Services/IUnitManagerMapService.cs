using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Unit;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitManagerMapService
    {
        bool CreateUnitManagerMap(UnitManagerMapModel unitManagerMapModel);
        IList<long> GetAllManagerIdByUnitId(long unitId);
        IList<Manager> GetAllManagerByUnitId(long unitId);
        long GetUnitIdByManagerId(long managerId);
        bool UpdateUnitManagerMap(UnitManagerMapModel unitManagerMapModel);
        bool Delete(long unitId);
    }
}
