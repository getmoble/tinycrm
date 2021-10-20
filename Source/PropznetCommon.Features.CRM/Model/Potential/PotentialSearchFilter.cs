using System;
using PropznetCommon.Features.CRM.Entities.Enum;

namespace PropznetCommon.Features.CRM.Model.Potential
{
    public class PotentialSearchFilter
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string SalesStage { get; set; }
        public string PropertyType { get; set; }
        public double ExpectedAmount { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public string LeadSource { get; set; }
        public string Comments { get; set; }
        public long? SalesStageId { get; set; }
        public CRMPropertyType? PropertyTypeId { get; set; }
        public long? LeadSourceId { get; set; }
        public long? AgentId { get; set; }
        public long? UserId { get; set; }
        public long? AssignedToUserId { get; set; }
    }
}