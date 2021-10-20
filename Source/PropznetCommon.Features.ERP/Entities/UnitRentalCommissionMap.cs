using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Entities
{
    public class UnitRentalCommissionMap:ERPEntityBase
    {
        public long UnitRentalCommissionId { get; set; }
        [ForeignKey("UnitRentalCommissionId")]
        public virtual UnitRentalCommission UnitRentalCommission { get; set; }

        public long UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
    }
}