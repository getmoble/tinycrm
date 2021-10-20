using System.ComponentModel.DataAnnotations;

namespace PropznetCommon.Features.ERP.Entities
{
    public class WorkOrderType
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}