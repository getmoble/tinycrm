using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Unit;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitOwnerMapservice
    {
        long GetUnitIdByOwnerId(long ownerId);
        IList<long> GetAllOwnerIdByUnitId(long unitId);
        IList<Owner> GetAllOwnerByUnitId(long unitId);
        bool CreatePropertyOwnerMap(UnitOwnerMapModel unitOwnerMapModel);
        bool UpdatePropertyOwnerMap(UnitOwnerMapModel unitOwnerMapModel);
        bool Delete(long unitId);
    }
}