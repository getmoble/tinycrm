using System;
using PropznetCommon.Features.CRM.Entities.Enum;

namespace PropznetCommon.Features.CRM.Model.Potential
{
   public class PotentialModel : ModelBase
    {
        public string PotentialName { get; set; }
        public long? AccountId { get; set; }
        public long selectedAssignedTo { get; set; }
        public long selectedAgent { get; set; }
        public long SelectedContact { get; set; }
        public long SelectedSalesStage { get; set; }

        public string Account { get; set; }
        public string SalesStage { get; set; }

        public double PotentialAmount { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public long SelectedLeadSource { get; set; }
        public string LeadSource { get; set; }
        public string Comments { get; set; }
        public long UserId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? EnquiredOn { get; set; }
    }
}