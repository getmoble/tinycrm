using System.ComponentModel.DataAnnotations.Schema;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.Common.Entities
{
    public class PotentialAmenityMap : ERPEntityBase
    {
        public long AmenityId { get; set; }
        [ForeignKey("AmenityId")]
        public virtual Amenity Amenity { get; set; }
        public long PotentialId { get; set; }
        public virtual Potential Potential { get; set; }
    }
}
