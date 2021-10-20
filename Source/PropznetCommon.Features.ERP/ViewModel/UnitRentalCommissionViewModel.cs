using PropznetCommon.Features.ERP.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.ViewModel
{
    public class UnitRentalCommissionViewModel
    {
        public long Id { get; set; }
        public string GLAccount { get; set; }
        public SalesCommissionType Type { get; set; }
        public long ChargeId { get; set; }
        public double Amount { get; set; }
        public int Month { get; set; }
    }
}
