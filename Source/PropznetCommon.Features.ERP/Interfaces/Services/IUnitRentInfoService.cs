using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.RentInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitRentInfoService
    {
        UnitRentInfo GetRentInfo(long id);
        UnitRentInfo CreateRentInfo(RentInfoModel rentInfoModel);
        UnitRentInfo UpdateRentInfo(RentInfoModel rentInfoModel);
        bool DeleteAllRentInfoByUnitId(long propertyId);
        bool DeleteRentInfo(long id);
    }
}