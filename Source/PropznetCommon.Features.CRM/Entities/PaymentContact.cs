using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Entities
{
    public class PaymentContact : CRMEntityBase
    {
        public long ContactId { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }
        public long ContactPaymentInfoId { get; set; }
        [ForeignKey("ContactPaymentInfoId")]
        public virtual ContactPaymentInfo ContactPaymentInfo { get; set; }
    }
}
