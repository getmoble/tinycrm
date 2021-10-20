namespace PropznetCommon.Features.CRM.Model.Lead
{
   public class LeadSearchFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string LeadSourceName { get; set; }
        public string LeadStatus { get; set; }
        public string Comments { get; set; }
        public long? LeadStatusId { get; set; }
        public long? LeadSourceId { get; set; }
        public long? AgentId { get; set; }
        public long? UserId { get; set; }
    }
}
