using Common.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOG.PropznetCRM.Data.Entities
{
    public class Location : CRMEntityBase
    {
        public long StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }
        public string Name { get; set; }
    }
}