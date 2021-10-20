using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Entities
{
    public class PropertyRentalCommissionMap : ERPMapBase
    {
        public long PropertyRentalCommissionId { get; set; }
        [ForeignKey("PropertyRentalCommissionId")]
        public virtual PropertyRentalCommission PropertyRentalCommission { get; set; }

        public long PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual ERPProperty Property { get; set; }
    }
}