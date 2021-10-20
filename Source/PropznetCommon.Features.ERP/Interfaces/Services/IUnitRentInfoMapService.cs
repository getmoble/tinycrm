using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitRentInfoMapService
    {
        long GetUnitIdByRentInfoId(long rentInfoId);
        IList<long> GetAllRentInfoIdByUnitId(long unitId);
        IList<UnitRentInfo> GetAllRentInfosByUnitId(long unitId);
        bool CreateUnitRentInfoMap(UnitRentInfoMapModel unitRentInfoMapModel);
        bool UpdateUnitRentInfoMap(UnitRentInfoMapModel unitRentInfoMapModel);
        bool Delete(long unitId);
    }
}