using PropznetCommon.Features.Accounting.Entities.Enums;

namespace PropznetCommon.Features.Accounting.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class AccountCategory : AccountingEntityBase
    {
        public string Name { get; set; }

        public long? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual AccountCategory ParentAccount { get; set; }
        public AccountTypes AccountType { get; set; }
        public string Remarks { get; set; }
    }
}
