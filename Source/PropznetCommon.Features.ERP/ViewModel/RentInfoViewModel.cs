namespace PropznetCommon.Features.ERP.ViewModel
{
    public class RentInfoViewModel
    {
        public long Id { get; set; }
        public long ChargeId { get; set; }
        public int Month { get; set; }
        public double Amount { get; set; }
        public bool Supress { get; set; }
        public long CreatedBy { get; set; }
    }
}
