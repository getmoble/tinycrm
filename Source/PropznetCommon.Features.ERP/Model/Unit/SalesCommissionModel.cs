using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Model.Unit
{
    public class SalesCommissionModel
    {
        public long UnitId { get; set; }
        public double? SalesCommission { get; set; }
        public ERPCommissionType CommissionType { get; set; }
    }
}