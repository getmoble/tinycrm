
function Owner(owner) {
    var that = this;
    that.modelState = ko.validatedObservable();
    that.isValid = function () {
        return that.modelState.isValid();
    };
    that.showErrors = function () {

        that.modelState.errors.showAllMessages(true);
    };
    that.Id = ko.observable(owner.Id);
    that.UserId = ko.observable(owner.UserId);
    that.Individual = ko.observable();
    that.IsCompany = ko.observable('Individual');
    that.FirstName = ko.observable(owner.FirstName).extend({ required: { params: true, message: "Please Enter First Name" } });
    that.Email = ko.observable(owner.Email).extend({ required: { params: true, message: "Please Enter Email" }, email: { params: true, message: "Please Enter valid Email" } });
    that.LastName = ko.observable(owner.LastName);
    that.SecondaryEmail = ko.observable(owner.SecondaryEmail).extend({ email: { params: true, message: "Please Enter valid Email" } });
    that.Company = ko.observable(owner.Company);
    that.Phone = ko.observable(owner.Phone).extend({ required: { params: true, message: "Please Enter Phone Number" } });
    that.Address = ko.observable(owner.Address).extend({ required: { params: true, message: "Please Enter Address" } });
    that.OfficePhone = ko.observable(owner.OfficePhone);
    that.Mobile = ko.observable(owner.Mobile);
    that.CountryId = ko.observable(owner.CountryId).extend({ required: { params: true, message: "Please Select Country" } });
    that.StateId = ko.observable(owner.StateId).extend({ required: { params: true, message: "Please Select State" } });
    that.CityId = ko.observable(owner.CityId).extend({ required: { params: true, message: "Please Select City" } });
    that.Zip = ko.observable(owner.Zip);
    that.EnableOwnerPortal = ko.observable(owner.EnableOwnerPortal);
    that.TaxEligible = ko.observable(owner.TaxEligible);
    that.TaxId = ko.observable(owner.TaxId);
    that.TaxPayerName = ko.observable(owner.TaxPayerName);
    that.Ownership = ko.observable(owner.Ownership);
    that.EmailAlerts = ko.observable(owner.EmailAlerts);
    that.EmailStatements = ko.observable(owner.EmailStatements); 
    that.ChequePaymentMode = ko.observable(owner.ChequePaymentMode);
    that.CashPaymentMode = ko.observable(owner.CashPaymentMode);
    that.OnlinePaymentMode = ko.observable(owner.OnlinePaymentMode);
    that.BankAccountNumber = ko.observable(owner.BankAccountNumber);
    that.Bank = ko.observable(owner.Bank);
    that.Branch = ko.observable(owner.Branch);
    that.BankIFSC = ko.observable(owner.BankIFSC);
    that.Description = ko.observable(owner.Description);
    that.IsSelect = ko.observable();
    if (owner.City) {
        that.CityId(owner.City.Id);
        that.StateId(owner.City.State.Id);
        that.CountryId(owner.City.State.Country.Id);
    }
    if (ko.toJS(owner.OwnerType) == '0')
        that.IsCompany('Individual');
    if (ko.toJS(owner.OwnerType) == '1')
        that.IsCompany('Company');
    if (owner.User)
    {
        that.Email(owner.User.Username);
    }
    if (that.TaxEligible==false)
    {
        that.TaxId(null);
        that.TaxPayerName(null);
    }
    if (that.OnlinePaymentMode==false)
    {
        that.BankAccountNumber(null);
        that.Bank(null);
        that.Branch(null);
        that.BankIFSC(null);
        that.Description(null);
    }
    that.modelState = ko.validatedObservable(
   {
       FirstName: that.FirstName,
       Email: that.Email,
       Phone: that.Phone,
       Address: that.Address,
       CityId: that.CityId
   });
}