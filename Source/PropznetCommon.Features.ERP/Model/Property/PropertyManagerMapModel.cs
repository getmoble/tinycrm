using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.Model.Property
{
    public class PropertyManagerMapModel
    {
        public long Id { get; set; }
        public long PropertyId { get; set; }
        public IList<long> ManagerId { get; set; }
    }
}