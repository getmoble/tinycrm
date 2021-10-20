using System;
using PropznetCommon.Features.ERP.Entities.Enum;
using PropznetCommon.Features.ERP.ViewModel;

namespace PropznetCommon.Features.ERP.Model.Owner
{
    public class OwnerModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SecondaryEmail { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string OfficePhone { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public bool TaxEligible { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long CountryId { get; set; }
        public long Zip { get; set; }
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
        public long UserId { get; set; }
        public bool EnableOwnerPortal { get; set; }
        public long CreatedBy { get; set; }
        public OwnerModel() { }
        public OwnerModel(OwnerViewModel vm)
        {
            Id =vm.Id;
            FirstName =vm.FirstName;
            LastName=vm.LastName;
            Email = vm.Email;
            SecondaryEmail =vm.SecondaryEmail;
            Company=vm.Company;
            Phone =vm.Phone;
            OfficePhone =vm.OfficePhone;
            Address =vm.Address;
            Mobile =vm.Mobile;
            TaxEligible =vm.TaxEligible;
            City =vm.City;
            State = vm.State;
            CountryId = vm.CountryId;
            Zip=vm.Zip;
            TaxId =vm.TaxId;
            TaxPayerName =vm.TaxPayerName;
            EmailAlerts =vm.EmailAlerts;
            EmailStatements =vm.EmailStatements;
            Ownership =vm.Ownership;
            CashPaymentMode =vm.CashPaymentMode;
            ChequePaymentMode =vm.ChequePaymentMode;
            OnlinePaymentMode =vm.OnlinePaymentMode;
            BankAccountNumber=vm.BankAccountNumber;
            Bank =vm.Bank;
            Branch=vm.Branch;
            BankIFSC =vm.BankIFSC;
            Description =vm.Description;
            CreatedBy = vm.CreatedBy;
            UserId = vm.UserId;
            if (vm.IsCompany == Enum.GetName(typeof(OwnerType), OwnerType.Individual))
                OwnerType = OwnerType.Individual;
            if (vm.IsCompany == Enum.GetName(typeof(OwnerType), OwnerType.Company))
                OwnerType = OwnerType.Company;
            EnableOwnerPortal = vm.EnableOwnerPortal;
        }
    }
}
