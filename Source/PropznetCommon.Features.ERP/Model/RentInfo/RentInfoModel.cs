using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Model.RentInfo
{
    public class RentInfoModel
    {       
        //public long EntityId { get; set; }
        //public ERPEntityType EntityType { get; set; }
        //public double RentAmount { get; set; }
        //public double Deposit { get; set; }
        //public RentalTerm RentalTerm { get; set; } 
        public long Id { get; set; }
        public long ChargeId { get; set; }
        public int Month { get; set; }
        public double Amount { get; set; }
        public bool Supress { get; set; }
        public long CreatedBy { get; set; }
    }
}