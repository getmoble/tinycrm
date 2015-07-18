using Common.Data.Entities;
using System;

namespace LOG.PropznetCRM.Data.Entities
{
    public class CRMEntityBase : EntityBase
    {
        public DateTimeOffset? DeletedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public long DeletedBy { get; set; }
    }
}
