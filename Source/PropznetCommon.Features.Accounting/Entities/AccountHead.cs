using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class AccountHead : AccountingEntityBase
    {
        public string Name { get; set; }
        public long AccountCategoryId { get; set; }
        
        [ForeignKey("AccountCategoryId")]
        public virtual AccountCategory AccountCategory { get; set; }

        public long? OpeningBalanceId { get; set; }

        [ForeignKey("OpeningBalanceId")]
        public virtual OpeningBalance OpeningBalance{ get; set; }
        public bool IsSystem { get; set; }
        public bool IsReadOnly { get; set; }
        public string Description { get; set; }
        public bool IsTransaction { get; set; }
    }
}
