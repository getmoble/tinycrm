using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.MarketingInformation;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IRentMarketingInformationService
    {
        RentMarketingInformation CreateRentMarketingInformation(RentMarketingInformationModel rentMarketingInformationModel);        
        RentMarketingInformation UpdateRentMarketingInformation(RentMarketingInformationModel rentMarketingInformationModel);
        bool Delete(long id);
    }
}
