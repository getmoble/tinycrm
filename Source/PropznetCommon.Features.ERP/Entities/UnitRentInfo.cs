using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Entities
{
    public class UnitRentInfo:ERPEntityBase
    {
        public long ChargeId { get; set; }
        [ForeignKey("ChargeId")]
        public virtual Charge Charge { get; set; }
        public int Month { get; set; }
        public double Amount { get; set; }
        public bool Supress { get; set; }
    }
}
