using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.Model.Property
{
    public class PropertyOwnerMapModel
    {
        public long Id { get; set; }
        public long PropertyId { get; set; }
        public IList<long> OwnerId { get; set; }
    }
}