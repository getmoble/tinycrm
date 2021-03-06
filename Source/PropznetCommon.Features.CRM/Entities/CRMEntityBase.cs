using System;
using Common.Data.Entities;

namespace PropznetCommon.Features.CRM.Entities
{
    public class CRMEntityBase : EntityBase
    {
        public DateTime? DeletedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public long? UpdatedByUserId { get; set; }
        public long? DeletedByUserId { get; set; }
    }
}