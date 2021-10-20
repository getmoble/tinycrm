using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.Model.Unit
{
    public class UnitAmenityMapModel
    {
        public long Id { get; set; }
        public long UnitId { get; set; }
        public IList<long> AmenityId { get; set; }
    }
}