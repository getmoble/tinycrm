using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class CashOrBankTransfer : AccountingEntityBase
    {
        public DateTimeOffset Date { get; set; }

        public long FromAccountId { get; set; }
        [ForeignKey("FromAccountId")]
        public virtual AccountHead FromAccount { get; set; }

        public long ToAccountId { get; set; }
        [ForeignKey("ToAccountId")]
        public virtual AccountHead ToAccount { get; set; }

        public string Reference { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }
    }
}
