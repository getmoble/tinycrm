using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Agent : ERPEntityBase
    {
        public string AgentName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ERPCommissionType AgentCommissionType { get; set; }
        public long Commission { get; set; }
        public string Comment { get; set; }
    }
}