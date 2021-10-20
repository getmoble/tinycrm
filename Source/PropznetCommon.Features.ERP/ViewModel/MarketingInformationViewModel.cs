namespace PropznetCommon.Features.ERP.ViewModel
{
    public class MarketingInformationViewModel
    {
        public long Id { get; set; }
        public bool IsRent{get;set;}
        public string RentTitle { get; set; }
        public string RentDescription { get; set; }
        public double RentAdvertisingCost { get; set; }
        public bool RentDisplayAmenities { get; set; }
        public bool RentShowMap { get; set; }
        public bool RentFeatured { get; set; }
        public bool RentShow { get; set; }
        public bool RentDisplayImages { get; set; }
        public bool IsSale{get;set;}
        public string SaleTitle { get; set; }
        public string SaleDescription { get; set; }
        public double SaleAdvertisingCost { get; set; }
        public bool SaleDisplayAmenities { get; set; }
        public bool SaleShowMap { get; set; }
        public bool SaleFeatured { get; set; }
        public bool ShowSales { get; set; }
        public bool SaleDisplayImages { get; set; }
    }
}
