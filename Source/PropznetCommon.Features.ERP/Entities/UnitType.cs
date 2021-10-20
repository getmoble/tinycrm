using System.ComponentModel.DataAnnotations;

namespace PropznetCommon.Features.ERP.Entities
{
    public class UnitType
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}