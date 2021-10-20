using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.Model.Unit
{
    public class UnitManagerMapModel
    {
        public long Id { get; set; }
        public long UnitId { get; set; }
        public IList<long> ManagerId { get; set; }
    }
}
