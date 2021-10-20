using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IUnitOwnerMapRepository
    {
        bool CreateUnitOwnerMap(UnitOwnerMap unitOwnerMap);
        IList<long> GetAllOwnerIdByUnitId(long unitId);
        IList<UnitOwnerMap> GetAllUnitOwnerMapByUnitId(long unitId);
        long GetUnitIdByOwnerId(long ownerId);
        bool DeleteUnitOwnerMap(long unitId);
    }
}