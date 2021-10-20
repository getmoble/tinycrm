using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Model.LeadSource
{
    public class LeadSourceModel : ModelBase
    {
        public string Name { get; set; }
        public long CreatedByUserId { get; set; }
        public long UpdatedByUserId { get; set; }
    }
}
