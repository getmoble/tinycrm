using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class OpeningBalance : AccountingEntityBase
    {
        public string Description { get; set; }
        public long TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }
        public double Amount { get; set; }
    }
}
