using Common.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using LOG.PropznetCRM.Data.Entities.Enum;

namespace LOG.PropznetCRM.Data.Entities
{
    public class Property : CRMEntityBase
    {
        public PropertyType PropertyType { get; set; }
        public decimal BudgetFrom { get; set; }
        public decimal BudgetTo { get; set; }
        public short Floor { get; set; }
        public float Area { get; set; }
        public long PropertyCategoryId { get; set; }
        [ForeignKey("PropertyCategoryId")]
        public virtual PropertyCategory PropertyCategory { get; set; }
        public long StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }
        public long LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
    }
}
