using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertySaleInfoRepository : IGenericRepository<PropertySaleInfo>
    {
        bool DeleteSaleInfo(long id);
        PropertySaleInfo GetSaleInfo(long id);
    }
}