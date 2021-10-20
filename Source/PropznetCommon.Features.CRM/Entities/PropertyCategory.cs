using System.ComponentModel.DataAnnotations;

namespace PropznetCommon.Features.CRM.Entities
{
    public class PropertyCategory 
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
