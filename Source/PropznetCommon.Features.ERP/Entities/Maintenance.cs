using System;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Maintenance:ERPEntityBase
    {
        public string OrderNo { get; set; }
        public string Vendor { get; set; }
        public MaintananceType MaintananceType { get; set; }
        public string RequestedBy { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public Payment Payment { get; set; }
    }
}
