using System;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Asset : ERPEntityBase
    {
        public string Name { get; set; }
        public string Vendor { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyDate { get; set; }
    }
}
