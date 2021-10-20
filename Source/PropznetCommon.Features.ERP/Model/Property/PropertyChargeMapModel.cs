using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Model.Property
{
    public class PropertyChargeMapModel
    {
        public long Id { get; set; }
        public long PropertyId { get; set; }
        public IList<long> ChargeId { get; set; }
    }
}