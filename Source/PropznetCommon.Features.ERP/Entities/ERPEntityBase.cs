using System;
using Common.Data.Entities;

namespace PropznetCommon.Features.ERP.Entities
{
    public class ERPEntityBase : EntityBase
    {
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public long DeletedBy { get; set; }
    }
}