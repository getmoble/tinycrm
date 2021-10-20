using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyService
    {
        ERPProperty CreateProperty(PropertyModel PropertyModel);
        IList<ERPProperty> GetAllProperties();
        IList<ERPProperty> GetAllPropertiesById(IList<long> id);
        ERPProperty GetPropertyById(long id);
        bool UpdateProperty(PropertyModel propertyModel);
        bool DeleteProperty(long id);
        bool UpdateSalesCommissionDetails(SalesCommissionModel salesCommissionModel);
        bool UpdateRentMarketingInformation(long marketingInfoId, long propertyId);
        bool UpdateSaleMarketingInformation(long marketingInfoId, long propertyId);
    }
}