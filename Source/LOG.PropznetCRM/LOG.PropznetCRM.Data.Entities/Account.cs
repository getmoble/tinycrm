using System.ComponentModel.DataAnnotations.Schema;

namespace LOG.PropznetCRM.Data.Entities
{
    public class Account : CRMEntityBase
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public long CommunicationDetailId { get; set; }
        [ForeignKey("CommunicationDetailId")]
        public virtual CommunicationDetail CommunicationDetail { get; set; }
        public long AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }
        public string Comments { get; set; }
    }
}