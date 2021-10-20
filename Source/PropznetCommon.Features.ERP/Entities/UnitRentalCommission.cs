using PropznetCommon.Features.ERP.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Entities
{
    public class UnitRentalCommission : ERPEntityBase
    {
        public string GLAccount { get; set; }
        public SalesCommissionType Type { get; set; }
        public long ChargeId { get; set; }
        [ForeignKey("ChargeId")]
        public Charge Charge { get; set; }
        public double Amount { get; set; }
        public int Month { get; set; }
    }
}