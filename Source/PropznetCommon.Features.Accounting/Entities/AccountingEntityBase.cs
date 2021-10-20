namespace PropznetCommon.Features.Accounting.Entities
{
    using System;
    using Common.Data.Entities;

    public class AccountingEntityBase : EntityBase
    {
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public long? UpdatedByUserId { get; set; }
        public long? DeletedByUserId { get; set; }
    }
}
