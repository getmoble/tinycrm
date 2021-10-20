using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class Invoice : AccountingEntityBase
    {
        public DateTimeOffset DateOfPay { get; set; }
        public string Referenace { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Party { get; set; }
        public long IncomeAccountId { get; set; }

        [ForeignKey("IncomeAccountId")]
        public virtual AccountHead IncomeAccount { get; set; }

        public long RecievingAccountId { get; set; }
        [ForeignKey("RecievingAccountId")]
        public virtual AccountHead PayingAccount { get; set; }
        public long TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }
        public string ChequeOrDDNo { get; set; }
        public DateTimeOffset? ChequeOrDDDate { get; set; }
        public bool IsSettled { get; set; }
    }
}
