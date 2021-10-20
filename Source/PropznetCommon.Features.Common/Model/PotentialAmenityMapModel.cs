using System.Collections.Generic;

namespace PropznetCommon.Features.Common.Model
{
    public class PotentialAmenityMapModel
    {
        public long Id { get; set; }
        public long PotentialId { get; set; }
        public IList<long> AmenityId { get; set; }
    }
}
