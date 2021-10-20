using System.ComponentModel.DataAnnotations;
using PropznetCommon.Features.CRM.Entities.Enum;

namespace PropznetCommon.Features.CRM.Entities
{
    public class SalesStage 
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public SaleStatus Status { get; set; }
    }
}
