using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class GeneralExpense : AccountingEntityBase
    {
        public DateTimeOffset DateOfPay { get; set; }
        public string Party { get; set; }
        public string Referenace { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

        public long ExpenseAccountId { get; set; }

        [ForeignKey("ExpenseAccountId")]
        public virtual AccountHead ExpenseAccount { get; set; }

        public long PayingAccountId { get; set; }
        [ForeignKey("PayingAccountId")]
        public virtual AccountHead PayingAccount { get; set; }

        public long TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }

        public string ChequeOrDDNo { get; set; }
        public DateTimeOffset? ChequeOrDDDate { get; set; }
    }
}
