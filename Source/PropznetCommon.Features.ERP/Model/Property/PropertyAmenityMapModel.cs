using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.Model.Property
{
    public class PropertyAmenityMapModel
    {
        public long Id { get; set; }
        public long PropertyId { get; set; }
        public IList<long> AmenityId { get; set; }
    }
}
