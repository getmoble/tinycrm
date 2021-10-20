using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.MarketingInformation;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface ISaleMarketingInformationService
    {
        SaleMarketingInformation CreateSaleMarketingInformation(SaleMarketingInformationModel saleMarketingInformationModel);
        SaleMarketingInformation UpdateSaleMarketingInformation(SaleMarketingInformationModel saleMarketingInformationModel);
        bool Delete(long id);
    }
}
