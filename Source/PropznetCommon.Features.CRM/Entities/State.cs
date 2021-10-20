using Common.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.PropznetCRM.Data.Entities
{
    public class State : CRMEntityBase
    {
        public long CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Countries { get; set; }
        public string Name { get; set; }
    }
}
