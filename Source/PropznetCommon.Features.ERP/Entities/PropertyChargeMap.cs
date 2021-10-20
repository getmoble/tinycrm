using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Entities
{
    public class PropertyChargeMap : ERPEntityBase
    {
        public long ChargeId { get; set; }
        [ForeignKey("ChargeId")]
        public virtual Charge Charge { get; set; }
        public long PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual ERPProperty Property { get; set; }
    }
}