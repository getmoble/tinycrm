using System;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Model.MarketingInformation
{
    public class RentMarketingInformationModel
    {
        public long Id { get; set; }
        public ListingType PropertyFor { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double AdvertisingRent { get; set; }
        public bool DisplayAmenities { get; set; }
        public bool ShowMap { get; set; }
        public bool Featured { get; set; }
        public bool ShowRent { get; set; }
        public bool ShowSalePrice { get; set; }
        public bool DisplayImages { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public long DeletedBy { get; set; }
    }
}
