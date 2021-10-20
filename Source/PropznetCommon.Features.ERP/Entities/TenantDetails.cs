using System;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Auth.SingleTenant.Entities;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Tenant : ERPEntityBase
    {
        public string TenantName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
