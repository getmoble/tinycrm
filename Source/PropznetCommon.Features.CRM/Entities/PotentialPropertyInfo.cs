using System;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Data.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;

namespace PropznetCommon.Features.CRM.Entities
{
    public class PotentialPropertyInfo : CRMEntityBase
    {
        public CRMPropertyType PropertyType { get; set; }
        public decimal BudgetFrom { get; set; }
        public decimal BudgetTo { get; set; }
        public short? Floor { get; set; }
        public short? Beds { get; set; }
        public short? Baths { get; set; }
        public float Area { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime? ExpectedMoveInDate { get; set; }

        public long PropertyCategoryId { get; set; }
        [ForeignKey("PropertyCategoryId")]
        public virtual PropertyCategory PropertyCategory { get; set; }
        public long CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}