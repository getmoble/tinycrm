using Common.Auth.SingleTenant.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Entities
{
    public class PropertyAgentMap : ERPMapBase
    {
        public long AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual User Agent { get; set; }

        public long PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual ERPProperty Property { get; set; }
    }
}
