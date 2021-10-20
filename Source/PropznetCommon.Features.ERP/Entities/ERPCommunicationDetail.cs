using System.ComponentModel.DataAnnotations.Schema;
using Common.Data.Entities;

namespace PropznetCommon.Features.ERP.Entities
{
    public class ERPCommunicationDetail : ERPEntityBase
    {
        public string Address { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public long Zip { get; set; }
        public float? Longitude { get; set; }
        public float? Latitude { get; set; }
    }
}