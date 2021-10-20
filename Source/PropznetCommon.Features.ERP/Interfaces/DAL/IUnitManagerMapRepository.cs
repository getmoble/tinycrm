using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IUnitManagerMapRepository
    {
        bool CreateUnitManagerMap(UnitManagerMap unitManagerMap);
        IList<long> GetAllManagerIdByUnitId(long unitId);
        IList<UnitManagerMap> GetAllUnitManagerMapByUnitId(long unitId);
        long GetUnitIdByManagerId(long managerId);
        bool DeleteUnitManagerMap(long unitId);
    }
}
