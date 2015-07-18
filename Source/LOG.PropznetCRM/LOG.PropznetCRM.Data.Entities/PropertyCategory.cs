using System.ComponentModel.DataAnnotations;

namespace LOG.PropznetCRM.Data.Entities
{
    public class PropertyCategory 
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
