using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.Model.Unit
{
    public class UnitOwnerMapModel
    {
        public long Id { get; set; }
        public long UnitId { get; set; }
        public IList<long> OwnerId { get; set; }
    }
}
