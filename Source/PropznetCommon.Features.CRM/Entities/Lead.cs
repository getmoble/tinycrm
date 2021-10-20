using Common.Auth.SingleTenant.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.CRM.Entities
{
    public class Lead : CRMEntityBase
    {
        public string LeadSourceName { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public DateTime? RecievedOn { get; set; }
        public string Other { get; set; }//value comes when choose lead source as other.

        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        public long LeadSourceId { get; set; }
        [ForeignKey("LeadSourceId")]
        public virtual LeadSource LeadSource { get; set; }
        public long LeadStatusId { get; set; }
        [ForeignKey("LeadStatusId")]
        public virtual LeadStatus LeadStatus { get; set; }
        public long AssignedToUserId { get; set; }
        [ForeignKey("AssignedToUserId")]
        public virtual User AssignedToUser { get; set; }
        public long? LeadSourceUserId { get; set; }//id of user if lead source is user/staff.

        [ForeignKey("LeadSourceUserId")]
        public virtual User LeadSourceUser { get; set; }
    }
}