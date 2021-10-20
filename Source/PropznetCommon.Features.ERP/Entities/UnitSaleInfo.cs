using PropznetCommon.Features.ERP.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Entities
{
    public class UnitSaleInfo : ERPEntityBase
    {
        public long EntityId { get; set; }
        public double ExpectedPrice { get; set; }
        public MeasurementUnit UnitMeasurementUnit { get; set; }
        public bool HasSaleCommission { get; set; }
        public string GLAccount { get; set; }
        public SalesCommissionType SalesCommissionType { get; set; }
        public double SaleCommissionAmount { get; set; }
        public ERPEntityType EntityType { get; set; }
        public string SalesTerms { get; set; }
    }
}
