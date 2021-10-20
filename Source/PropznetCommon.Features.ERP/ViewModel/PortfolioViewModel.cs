using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.ViewModel
{
    public class PortfolioViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<long> OwnersId { get; set; }
        public string UsageType { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
    }
}
