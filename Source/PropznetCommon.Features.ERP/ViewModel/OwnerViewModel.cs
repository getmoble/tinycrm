using System;
using Common.Auth.SingleTenant.Entities;
using Common.Data.Entities;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.ViewModel
{
    public class OwnerViewModel
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
        public bool EmailAlerts { get; set; }
        public bool EmailStatements { get; set; }
        public double Ownership { get; set; }
        public bool CashPaymentMode { get; set; }
        public bool ChequePaymentMode { get; set; }
        public bool OnlinePaymentMode { get; set; }
        public long BankAccountNumber { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string BankIFSC { get; set; }
        public string Description { get; set; }
        public string Individual { get; set; }
        public string IsCompany { get; set; }
        public User User { get; set; }
        public bool EnableOwnerPortal { get; set; }
        public long CreatedBy { get; set; }
        public long UserId { get; set; }
        public OwnerViewModel()
        {
        }
        public OwnerViewModel(Owner vm)
        {
            Id = vm.Id;
            FirstName = vm.User.Person.FirstName;
            LastName = vm.User.Person.LastName;
            SecondaryEmail = vm.SecondaryEmail;
            Company = vm.User.Person.Company;
            Phone = vm.User.Person.PhoneNo;
            OfficePhone = vm.OfficePhone;
            Address = vm.User.Person.Address;
            Mobile = vm.Mobile;
            TaxEligible = vm.TaxEligible;
            City = vm.User.Person.City;
            State=vm.User.Person.State;
            CountryId = User.Person.CountryId.Value;
            User = vm.User;
            User.Username=vm.User.Username;
            Email = vm.User.Username;
            if(vm.User.Person.Zip.HasValue)
            Zip = vm.User.Person.Zip.Value;
            TaxId = vm.TaxId;
            TaxPayerName = vm.TaxPayerName;
            EmailAlerts = vm.EmailAlerts;
            EmailStatements = vm.EmailStatements;
            Ownership = vm.Ownership;
            CashPaymentMode = vm.CashPaymentMode;
            ChequePaymentMode = vm.ChequePaymentMode;
            OnlinePaymentMode = vm.OnlinePaymentMode;
            BankAccountNumber = vm.BankAccountNumber;
            Bank = vm.Bank;
            Branch = vm.Branch;
            BankIFSC = vm.BankIFSC;
            Description = vm.Description;
            CreatedBy = vm.CreatedBy;
            UserId = vm.UserId;
            if (vm.OwnerType ==  OwnerType.Individual)
                Individual = Enum.GetName(typeof(OwnerType), OwnerType.Individual);
            if (vm.OwnerType == OwnerType.Company)
                IsCompany = Enum.GetName(typeof(OwnerType), OwnerType.Company);
            EnableOwnerPortal = vm.User.AccessRule.IsApproved;
        }
    }
}
