using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Data.Entities;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Area
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}