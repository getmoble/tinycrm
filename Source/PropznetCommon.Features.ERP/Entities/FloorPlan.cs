using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class FloorPlan : ERPEntityBase
    {
        public string FloorPlanName { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
