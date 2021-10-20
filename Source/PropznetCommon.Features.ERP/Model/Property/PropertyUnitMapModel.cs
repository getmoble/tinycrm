using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.Model.Property
{
    public class PropertyUnitMapModel
    {
        public long Id { get; set; }
        public long PropertyId { get; set; }
        public IList<long> UnitId { get; set; }
    }
}
