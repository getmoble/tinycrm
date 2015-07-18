using System.ComponentModel.DataAnnotations;
using LOG.PropznetCRM.Data.Entities.Enum;

namespace LOG.PropznetCRM.Data.Entities
{
    public class SalesStage 
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public SaleStatus Status { get; set; }
    }
}
