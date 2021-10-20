using PropznetCommon.Features.ERP.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Charge:ERPEntityBase
    {
        public string Name { get; set; }
        public ChargeType Type { get; set; }
    }
}