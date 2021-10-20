using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Ledger : ERPEntityBase
    {
        public long GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        public string Name { get; set; }
    }
}
