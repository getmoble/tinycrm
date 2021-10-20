using PropznetCommon.Features.ERP.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.ERP.Entities
{
    public class PropertyRentInfo : ERPEntityBase
    {
        //public long EntityId { get; set; }
        //public ERPEntityType EntityType { get; set; }
        //public double RentAmount { get; set; }
        //public double Deposit { get; set; }
        //public RentalTerm RentalTerms { get; set; }
        public long ChargeId { get; set; }
        [ForeignKey("ChargeId")]
        public virtual Charge Charge { get; set; }
        public int Month { get; set; }
        public double Amount { get; set; }
        public bool Supress { get; set; }
    }
}