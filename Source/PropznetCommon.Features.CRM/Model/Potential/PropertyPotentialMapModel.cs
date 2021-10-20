using PropznetCommon.Features.CRM.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Model.Potential
{
    public class PropertyPotentialMapModel
    {//
        public long PotentialId { get; set; }
        public string PotentialName { get; set; }
        public long? AccountId { get; set; }
        public long selectedAssignedTo { get; set; }
        public long selectedAgent { get; set; }
        public long SelectedContact { get; set; }
        public long SelectedSalesStage { get; set; }
        public long selectedState { get; set; }
        public long CountryId { get; set; }
        public short Floor { get; set; }
        public float Area { get; set; }
        public decimal BudgetFrom { get; set; }
        public decimal BudgetTo { get; set; }
        public string Account { get; set; }
        public string SalesStage { get; set; }
        public CRMPropertyType selectedProperty { get; set; }
        public long selectedPropertyCategory { get; set; }
        public double PotentialAmount { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public long SelectedLeadSource { get; set; }
        public string LeadSource { get; set; }
        public string Comments { get; set; }
        public long? PropertyId { get; set; }
        public long UserId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime ExpectedMoveInDate { get; set; }
        public short Beds { get; set; }
        public short Baths { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
}
