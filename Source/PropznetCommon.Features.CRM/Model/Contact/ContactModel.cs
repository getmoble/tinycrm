using PropznetCommon.Features.CRM.Entities.Enum;
namespace PropznetCommon.Features.CRM.Model.Contact
{
    public class ContactModel : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string IsCompany { get; set; }
        public ContactType ContactType { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
        public long CommunicationDetailId { get; set; }
        public long CreatedBy { get; set; }
        public string SecondaryEmail { get; set; }
        public string OfficePhone { get; set; }
        public string Comapny { get; set; }
        public long CountryId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public long Zip { get; set; }
       // public bool TaxEligible { get; set; }
       // public string TaxId { get; set; }
       // public string TaxPayerName { get; set; }
       // public double Ownership { get; set; }
       // public bool EmailAlerts { get; set; }
       // public bool EmailStatements { get; set; }
       // public bool CashPaymentMode { get; set; }
       // public bool ChequePaymentMode { get; set; }
       // public bool OnlinePaymentMode { get; set; }
       // public long BankAccountNumber { get; set; }
        //public string Bank { get; set; }
       // public string Branch { get; set; }
       // public string BankIFSC { get; set; }
        //public string Description { get; set; }
    }
}