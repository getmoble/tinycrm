using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Portfolio : ERPEntityBase
    {
        public string Name { get; set; }
        public ERPPropertyCategory UsageType { get; set; }
        public string Description { get; set; }
    }
}