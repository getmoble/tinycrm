using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Model.Property
{
    public class PropertyAgentMapModel
    {
        public long Id { get; set; }
        public long PropertyId { get; set; }
        public IList<long> AgentId { get; set; }
    }
}
