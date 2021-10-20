using System.ComponentModel.DataAnnotations.Schema;
using Common.Auth.SingleTenant.Entities;
using Common.Data.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Owner : ERPEntityBase
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string SecondaryEmail { get; set; }
        //public string Company { get; set; }
        //public string Phone { get; set; }
        public string OfficePhone { get; set; }
        //public string Address { get; set; }
        public string Mobile { get; set; }
        public bool TaxEligible { get; set; }
        //public long Zip { get; set; }
        public string TaxId { get; set; }
        public string TaxPayerName { get; set; }
        public double Ownership { get; set; }
        public bool EmailAlerts { get; set; }
        public bool EmailStatements { get; set; }
        public bool CashPaymentMode { get; set; }
        public bool ChequePaymentMode { get; set; }
        public bool OnlinePaymentMode { get; set; }
        public long BankAccountNumber { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string BankIFSC { get; set; }
        public string Description { get; set; }
        public OwnerType OwnerType { get; set; }
        //public bool EnableOwnerPortal { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
