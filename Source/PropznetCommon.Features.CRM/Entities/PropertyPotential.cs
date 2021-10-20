using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Entities
{
    public class PropertyPotential : CRMEntityBase
    {
        public long PotentialId { get; set; }
        [ForeignKey("PotentialId")]
        public virtual Potential Potential { get; set; }
        public long PotentialPropertyInfoId { get; set; }
        [ForeignKey("PotentialPropertyInfoId")]
        public virtual PotentialPropertyInfo PotentialPropertyInfo { get; set; }
    }
}