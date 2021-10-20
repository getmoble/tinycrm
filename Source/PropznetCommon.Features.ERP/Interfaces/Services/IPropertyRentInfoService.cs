using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.RentInfo;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IPropertyRentInfoService
    {
        PropertyRentInfo GetRentInfo(long id);
        PropertyRentInfo CreateRentInfo(RentInfoModel rentInfoModel);
        PropertyRentInfo UpdateRentInfo(RentInfoModel rentInfoModel);
        bool DeleteAllRentInfoByPropertyId(long propertyId);
        bool DeleteRentInfo(long id);
    }
}