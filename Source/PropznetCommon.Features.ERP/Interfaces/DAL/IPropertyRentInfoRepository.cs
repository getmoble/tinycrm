using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyRentInfoRepository : IGenericRepository<PropertyRentInfo>
    {
        bool DeleteRentInfo(long id);
        PropertyRentInfo GetRentInfo(long id);
    }
}
