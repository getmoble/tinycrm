using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class GeneralPayment : AccountingEntityBase
    {
        public DateTimeOffset Date { get; set; }

        public string Party { get; set; }

        public long ExpenseAccountId { get; set; }
        [ForeignKey("ExpenseAccountId")]
        public virtual AccountHead ExpenseAccount { get; set; }
      
        public long PayingAccountId { get; set; }
        [ForeignKey("PayingAccountId")]
        public virtual AccountHead PayingAccount { get; set; }

        public string Reference { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }
    }
}
