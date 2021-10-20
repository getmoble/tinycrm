using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.SaleInfo;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertySaleInfoService
    {
        PropertySaleInfo CreatePropertySaleInfo(PropertySaleInfoModel saleInfoModel);
        PropertySaleInfo UpdatePropertySaleInfo(PropertySaleInfoModel saleInfoModel);
        bool DeleteSaleInfo(long id);
        PropertySaleInfo GetSaleInfo(long id);
    }
}
