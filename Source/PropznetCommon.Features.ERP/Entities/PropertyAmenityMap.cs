using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.ERP.Entities
{
    public class PropertyAmenityMap : ERPEntityBase
    {
        public long AmenityId { get; set; }
        [ForeignKey("AmenityId")]
        public virtual Amenity Amenity { get; set; }
        public long PropertyId { get; set; }
        public virtual ERPProperty Property { get; set; }
    }
}