using LOG.PropznetCRM.Data.Entities.Enum;

namespace LOG.PropznetCRM.Data.Model.Property
{
    public class PropertyModel
    {
        public long Id { get; set; }
        public PropertyType PropertyType { get; set; }
        public decimal BudgetFrom { get; set; }
        public decimal BudgetTo { get; set; }
        public short Floor { get; set; }
        public float Area { get; set; }
        public long PropertyCategoryId { get; set; }
        public long StateId { get; set; }
        public long LocationId { get; set; }
    }
}
