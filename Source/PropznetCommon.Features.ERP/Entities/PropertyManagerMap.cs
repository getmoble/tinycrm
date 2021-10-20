using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.ERP.Entities
{
    public class PropertyManagerMap : ERPEntityBase
    {
        public long ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Manager Manager { get; set; }
        public long PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual ERPProperty Property { get; set; }
    }
}