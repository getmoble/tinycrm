using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Model.Unit
{
    public class UnitRentalCommissionMapModel
    {
        public long Id { get; set; }
        public long UnitId { get; set; }
        public IList<long> UnitRentalCommissionIds { get; set; }
    }
}
