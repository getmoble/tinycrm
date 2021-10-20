using System;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Auth.SingleTenant.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class WorkOrder : ERPEntityBase
    {
        public string OrderNo { get; set; }
        public string Vendor { get; set; }
        public long WorkOrderTypeId { get; set; }
        [ForeignKey("WorkOrderTypeId")]
        public virtual WorkOrderType MaintenanceType { get; set; }
        public long RequestedBy { get; set; }
        [ForeignKey("RequestedBy")]
        public virtual User User { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public PaymentStatus Payment { get; set; }
    }
}
