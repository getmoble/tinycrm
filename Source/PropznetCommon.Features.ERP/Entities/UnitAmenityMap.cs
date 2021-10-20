using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.ERP.Entities
{
    public class UnitAmenityMap:ERPEntityBase
    {
        public long AmenityId { get; set; }
        [ForeignKey("AmenityId")]
        public virtual Amenity Amenity {get;set; }
        public long UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
    }
}