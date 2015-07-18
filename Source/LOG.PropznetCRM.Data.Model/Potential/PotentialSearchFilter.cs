using System;
using LOG.PropznetCRM.Data.Entities.Enum;

namespace LOG.PropznetCRM.Data.Model.Potential
{
    public class PotentialSearchFilter
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string SalesStage { get; set; }
        public string PropertyType { get; set; }
        public double ExpectedAmount { get; set; }
        public DateTimeOffset ExpectedCloseDate { get; set; }
        public string LeadSource { get; set; }
        public string Comments { get; set; }
        public long? SalesStageId { get; set; }
        public PropertyType? PropertyTypeId { get; set; }
        public long? LeadSourceId { get; set; }
        public long? AgentId { get; set; }
        public long? UserId { get; set; }
    }
}