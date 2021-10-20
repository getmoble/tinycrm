using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Entities
{
    public class ContactPaymentInfo : CRMEntityBase
    {
        public bool? TaxEligible { get; set; }
        public string TaxId { get; set; }
        public string TaxPayerName { get; set; }
        public double? Ownership { get; set; }
        public bool? EmailAlerts { get; set; }
        public bool? EmailStatements { get; set; }
        public bool? CashPaymentMode { get; set; }
        public bool? ChequePaymentMode { get; set; }
        public bool? OnlinePaymentMode { get; set; }
        public long? BankAccountNumber { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string IFSC { get; set; }
        public string Description { get; set; }
    }
}