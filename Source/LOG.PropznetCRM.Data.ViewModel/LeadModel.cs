using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.PropznetCRM.Data.Model
{
    public class LeadModel : ModelBase
    {//
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string LeadSourceName { get; set; }
        public string LeadStatus { get; set; }
        public string Comments { get; set; }
    }
}