using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.ViewModel
{
    public class UnitAmenityMapViewModel
    {
        public long Id { get; set; }
        public long UnitId { get; set; }
        public IList<long> AmenityId { get; set; }
    }
}
