using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Model.Contact
{
    public class PaymentContactSearchFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public long? AccountId { get; set; }
        public long? SalesStageId { get; set; }
        public long? PropertyTypeId { get; set; }
        public long? LeadSourceId { get; set; }
        public long? AgentId { get; set; }
        public long? UserId { get; set; }
    }
}
