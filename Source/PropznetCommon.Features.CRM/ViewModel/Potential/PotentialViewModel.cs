using System;
using System.ComponentModel;
namespace PropznetCommon.Features.CRM.ViewModel.Potential
{
    public class PotentialViewModel
    {
        public long Id { get; set; }
        public string RefId { get; set; }
        [DisplayName("Potential Name")]
        public string Name { get; set; }
        public long PotentialId { get; set; }
         [DisplayName("Expected Amount")]
        public double? ExpectedAmount { get; set; }
        public string ExpectedCloseDate { get; set; }
          [DisplayName("Lead Source")]
        public string LeadSourceName { get; set; }
        [DisplayName("Related To Account")]
        public string AccountName { get; set; }
         [DisplayName("Sales Stage")]
        public string SalesStageName { get; set; }
        public string AgentName { get; set; }
        public decimal PropertyBudgetFrom { get; set; }
        public decimal PropertyBudgetTo { get; set; }
        public int PropertyFloor { get; set; }
        public float PropertyArea { get; set; }
        public string PropertyCategory { get; set; }
        public string PropertyType { get; set; }
        public long AgentId { get; set; }
        public string ContactName { get; set; }
          [DisplayName("Contact")]
        public string ContactNo { get; set; }
        public string AccountNo { get; set; }
        public string Industry { get; set; }
        public string ContactTitle { get; set; }
        public string AssignedTo { get; set; }
        public string ShowingDate{ get; set; }
        public long CityId { get; set; }
        public DateTime? EnquiredOn { get; set; }
        public long UserId { get; set; }
    }
}
