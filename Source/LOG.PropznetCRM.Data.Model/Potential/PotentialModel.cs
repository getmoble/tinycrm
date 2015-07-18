using LOG.PropznetCRM.Data.Entities.Enum;
using System;

namespace LOG.PropznetCRM.Data.Model.Potential
{
   public class PotentialModel : ModelBase
    {
        public string PotentialName { get; set; }
        public long AccountId { get; set; }
        public long selectedAssignedTo { get; set; }
        public long selectedAgent { get; set; }
        public long SelectedContact { get; set; }
        public long SelectedSalesStage { get; set; }
        public long selectedState { get; set; }
        public long selectedLocation { get; set; }
        public short Floor { get; set; }
        public float Area { get; set; }
        public decimal BudgetFrom { get; set; }
        public decimal BudgetTo { get; set; }
        public string Account { get; set; }
        public string SalesStage { get; set; }
        public PropertyType selectedProperty { get; set; }
        public long selectedPropertyCategory { get; set; }
        public double PotentialAmount { get; set; }
        public DateTimeOffset ExpectedCloseDate { get; set; }
        public long SelectedLeadSource { get; set; }
        public string LeadSource { get; set; }
        public string Comments { get; set; }
        public long? PropertyId { get; set; }
        public long UserId { get; set; }
        public long CreatedBy { get; set; }
    }
}