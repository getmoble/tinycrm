using System;
using System.ComponentModel.DataAnnotations;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class ERPMapBase
    {
        [Key]
        public long Id { get; set; }
        public long EntityId { get; set; }
        public ERPEntityType EntityType { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}