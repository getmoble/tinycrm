using System.ComponentModel.DataAnnotations.Schema;

namespace LOG.PropznetCRM.Data.Entities
{
    public class Contact : CRMEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
        public long AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public long CommunicationDetailId { get; set; }
        [ForeignKey("CommunicationDetailId")]
        public virtual CommunicationDetail CommunicationDetail { get; set; }
        public long AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }
    }
}
