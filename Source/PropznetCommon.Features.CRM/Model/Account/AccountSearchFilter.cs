namespace PropznetCommon.Features.CRM.Model.Account
{
    public class AccountSearchFilter
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
        public long? SalesStageId { get; set; }
        public long? PropertyTypeId { get; set; }
        public long? LeadSourceId { get; set; }
        public long? AgentId { get; set; }
        public long? UserId { get; set; }
    }
}
