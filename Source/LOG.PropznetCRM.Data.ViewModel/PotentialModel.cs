using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.PropznetCRM.Data.Model
{
   public class PotentialModel : ModelBase
    {//
        public string Name { get; set; }
        public string Account { get; set; }
        public string SalesStage { get; set; }
        public string PropertyType { get; set; }
        public double ExpectedAmount { get; set; }
        public DateTimeOffset ExpectedCloseDate { get; set; }
        public string LeadSource { get; set; }
        public string Comments { get; set; }
    }
}
