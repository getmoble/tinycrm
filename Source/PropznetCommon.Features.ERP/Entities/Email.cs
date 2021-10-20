using System;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Email : ERPEntityBase
    {
        public EmailType EmailType { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
    }
}
