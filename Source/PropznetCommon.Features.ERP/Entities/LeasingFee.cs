using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.ERP.Entities
{
    public class LeasingFee : ERPEntityBase
    {
        public string Name { get; set; }
        public long LedgerId { get; set; }
        [ForeignKey("LedgerId")]
        public virtual Ledger Ledger { get; set; }
        public long FeeTypeId { get; set; }
        [ForeignKey("FeeTypeId")]
        public virtual FeeType FeeType { get; set; }
        public double Amount { get; set; }
    }
}
