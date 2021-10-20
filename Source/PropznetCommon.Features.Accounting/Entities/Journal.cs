using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class Journal : AccountingEntityBase
    {
        public DateTimeOffset DateOfTransaction { get; set; }
        public long FromAccountId { get; set; }
        public string Description { get; set; }
        public string Referennce { get; set; }
        [ForeignKey("FromAccountId")]
        public virtual AccountHead FromAccount { get; set; }
        public long ToAccountId { get; set; }
        [ForeignKey("ToAccountId")]
        public virtual AccountHead ToAccount { get; set; }
        public long TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }
        public double Amount { get; set; }
    }
}

