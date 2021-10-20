using System;

namespace PropznetCommon.Features.CRM.ViewModel
{
   public class PotentialModel : ModelBase
    {//
        public string Name { get; set; }
        public string Account { get; set; }
        public string SalesStage { get; set; }
        public string PropertyType { get; set; }
        public double ExpectedAmount { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public string LeadSource { get; set; }
        public string Comments { get; set; }
        public DateTime ExpectedMoveInDate { get; set; }
        public short Beds { get; set; }
        public short Baths { get; set; }
    }
}
