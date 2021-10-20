using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class SaleMarketingInformation:ERPEntityBase
    {
        public ListingType PropertyFor { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double AdvertisingCost { get; set; }
        public bool DisplayAmenities { get; set; }
        public bool ShowMap { get; set; }
        public bool Featured { get; set; }
        public bool ShowSalePrice { get; set; }
        public bool DisplayImages { get; set; }
    }
}
