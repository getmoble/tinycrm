using Common.Auth.SingleTenant.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.CRM.Entities
{
    public class Account : CRMEntityBase
    {
        public string Industry { get; set; }
        public string Description { get; set; }

        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        public long AssignedToUserId { get; set; }
        [ForeignKey("AssignedToUserId")]
        public virtual User AssignedToUser { get; set; }
    }
}