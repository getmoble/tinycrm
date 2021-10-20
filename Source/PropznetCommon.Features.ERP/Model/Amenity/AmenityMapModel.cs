using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Model.Amenity
{
    public class AmenityMapModel
    {
        public long Id { get; set; }
        public long EntityId { get; set; }
        public ERPEntityType EntityType { get; set; }
        public long CreatedBy { get; set; }
        public IList<long> AmenityId { get; set; }
    }
}
