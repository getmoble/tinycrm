using System.ComponentModel.DataAnnotations.Schema;
using PropznetCommon.Features.Accounting.Entities.Enums;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class TransactionLineItem : AccountingEntityBase
    {
        public long TransactionId { get; set; }

        [ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }
        public TransactionType TransactionType { get; set; }
        public long AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual AccountHead Account { get; set; }
        public double Credit { get; set; }
        public double Debit { get; set; }
        public CancelFlag CancelFlag { get; set; }

    }
}

