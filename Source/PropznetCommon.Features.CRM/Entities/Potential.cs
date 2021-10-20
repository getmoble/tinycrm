using Common.Auth.SingleTenant.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.CRM.Entities
{
    public class Potential : CRMEntityBase
    {
        public double? ExpectedAmount { get; set; }
        public DateTime? ExpectedCloseDate { get; set; }
        public string LeadSourceName { get; set; }
        public string Description { get; set; }
        public DateTime? EnquiredOn { get; set; }

        public long? AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public long SalesStageId { get; set; }
        [ForeignKey("SalesStageId")]
        public virtual SalesStage SalesStage { get; set; }
        public long AssignedToUserId { get; set; }
        [ForeignKey("AssignedToUserId")]
        public virtual User AssignedToUser { get; set; }
        public long ContactId { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }
        public long LeadSourceId { get; set; }
        [ForeignKey("LeadSourceId")]
        public virtual LeadSource LeadSource { get; set; }
        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}