using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.SaleInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IUnitSaleInfoService
    {
        UnitSaleInfo CreateUnitSaleInfo(UnitSaleInfoModel unitSaleInfoModel);
        UnitSaleInfo UpdateUnitSaleInfo(UnitSaleInfoModel unitSaleInfoModel);
        bool DeleteUnitSaleInfo(long id);
        UnitSaleInfo GetUnitSaleInfo(long id);
    }
}
