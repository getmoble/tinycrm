using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOG.PropznetCRM.Data.Entities
{
    public class Potential : CRMEntityBase
    {
        public string Name { get; set; }
        public double ExpectedAmount { get; set; }
        public DateTimeOffset ExpectedCloseDate { get; set; }
        public long LeadSourceId { get; set; }
        [ForeignKey("LeadSourceId")]
        public virtual LeadSource LeadSource { get; set; }
        public string LeadSourceName { get; set; }
        public long? PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
        public string Comments { get; set; }
        public long AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public long SalesStageId { get; set; }
        [ForeignKey("SalesStageId")]
        public virtual SalesStage SalesStage { get; set; }
        public long AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }
        public long? ContactId { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }
    }
}