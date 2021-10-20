using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.ERP.Entities
{
    public class UnitManagerMap : ERPEntityBase
    {
        public long ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual Manager Manager { get; set; }
        public long UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
    }
}
