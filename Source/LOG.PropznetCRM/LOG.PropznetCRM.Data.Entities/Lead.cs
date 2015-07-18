using System.ComponentModel.DataAnnotations.Schema;

namespace LOG.PropznetCRM.Data.Entities
{
    public class Lead : CRMEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public long CommunicationDetailId { get; set; }
        [ForeignKey("CommunicationDetailId")]
        public virtual CommunicationDetail CommunicationDetail { get; set; }
        public long LeadSourceId { get; set; }
        [ForeignKey("LeadSourceId")]
        public virtual LeadSource LeadSource { get; set; }
        public string LeadSourceName { get; set; }
        public long LeadStatusId { get; set; }
        [ForeignKey("LeadStatusId")]
        public virtual LeadStatus LeadStatus { get; set; }
        public long AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }
        public string Comments { get; set; }
    }
}
