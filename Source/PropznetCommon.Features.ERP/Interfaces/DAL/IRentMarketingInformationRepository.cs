using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IRentMarketingInformationRepository : IGenericRepository<RentMarketingInformation>
    {
        bool DeletetRentMarketingInformation(long id);
    }
}
