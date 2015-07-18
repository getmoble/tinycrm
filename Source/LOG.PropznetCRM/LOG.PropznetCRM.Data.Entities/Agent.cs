using System.ComponentModel.DataAnnotations.Schema;
using Common.Auth.SingleTenant.Entities;
using LOG.PropznetCRM.Data.Entities.Enum;

namespace LOG.PropznetCRM.Data.Entities
{
    public class Agent : CRMEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CommunicationDetailId { get; set; }
        [ForeignKey("CommunicationDetailId")]
        public virtual CommunicationDetail CommunicationDetail { get; set; }
        public bool IsListingMember { get; set; }
        public string DEDLicenseNumber { get; set; }
        public string RERARegistrationNumber { get; set; }
        public string Image { get; set; }
        public AgentType AgentType { get; set; }
        public CommisionType CommisionType { get; set; }
        public decimal Commission { get; set; }
        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public long? PropertyMapId { get; set; }
        [ForeignKey("PropertyMapId")]
        public virtual AgentPropertyMap AgentPropertyMap { get; set; }
    }
}