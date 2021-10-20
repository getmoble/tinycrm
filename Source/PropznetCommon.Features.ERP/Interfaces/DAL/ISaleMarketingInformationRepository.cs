using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface ISaleMarketingInformationRepository : IGenericRepository<SaleMarketingInformation>
    {
        bool DeletetSaleMarketingInformation(long id);
    }
}
