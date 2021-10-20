using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class PropertySaleInfo : ERPEntityBase
    {
        public long EntityId { get; set; }
        public double ExpectedPrice { get; set; }
        public MeasurementUnit PropertyMeasurementUnit { get; set; }
        public bool HasSaleCommission { get; set; }
        public string GLAccount { get; set; }
        public SalesCommissionType SalesCommissionType { get; set; }
        public double SaleCommissionAmount { get; set; }
        public ERPEntityType EntityType { get; set; }
        public string SalesTerms { get; set; }
    }
}