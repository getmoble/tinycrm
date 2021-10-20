using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Model.Property
{
    public class SalesCommissionModel
    {
        public long PropertyId { get; set; }
        public double? SalesCommission { get; set; }
        public ERPCommissionType CommissionType { get; set; }
    }
}