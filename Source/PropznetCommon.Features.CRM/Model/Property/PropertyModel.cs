using PropznetCommon.Features.CRM.Entities.Enum;

namespace PropznetCommon.Features.CRM.Model.Property
{
    public class PropertyModel
    {
        public long Id { get; set; }
        public CRMPropertyType PropertyType { get; set; }
        public decimal BudgetFrom { get; set; }
        public decimal BudgetTo { get; set; }
        public short Floor { get; set; }
        public float Area { get; set; }
        public long PropertyCategoryId { get; set; }
        public long CityId { get; set; }
        public short Beds { get; set; }
        public short Baths { get; set; }
    }
}
