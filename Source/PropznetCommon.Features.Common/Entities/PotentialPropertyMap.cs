using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.ERP.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.Common.Entities
{
    public class PotentialPropertyMap : ERPEntityBase
    {
        public long PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual ERPProperty Property { get; set; }
        public long PotentialId { get; set; }
        [ForeignKey("PotentialId")]
        public virtual Potential Potential { get; set; }
    }
}
