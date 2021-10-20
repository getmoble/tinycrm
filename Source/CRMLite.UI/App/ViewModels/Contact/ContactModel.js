function Contact(contact) {
    var self = this;
    self.Individual = ko.observable();
    self.Id = ko.observable(contact.Id || 0);
    self.ContactId = ko.observable(contact.ContactId || 0)
    //self.CityId = ko.observable().extend({ required: { params: true, message: "Please Select City" } });
    //self.StateId = ko.observable().extend({ required: { params: true, message: "Please Select State" } });     
    self.AccountId = ko.observable(contact.AccountId || 0).extend({ required: { params: true, message: "Please select Account" } });
    self.AgentId = ko.observable(contact.AgentId || 0).extend({ required: { params: true, message: "Please select Agent" } });
    self.Comments = ko.observable('');
    self.Description = ko.observable('');
    self.CommunicationDetailId = ko.observable(contact.CommunicationDetailId || 0);
    if (contact.Account) {
        self.AccountName = ko.observable(contact.Account.Name || '');
    }
    else {
        self.AccountName = ko.observable('');
    }
    if (contact.ContactPaymentInfo) {
        self.TaxEligible = ko.observable(contact.ContactPaymentInfo.TaxEligible);
        self.TaxId = ko.observable(contact.ContactPaymentInfo.TaxId);
        self.TaxPayerName = ko.observable(contact.ContactPaymentInfo.TaxPayerName);
        self.Ownership = ko.observable(contact.ContactPaymentInfo.Ownership);
        self.EmailAlerts = ko.observable(contact.ContactPaymentInfo.EmailAlerts);
        self.EmailStatements = ko.observable(contact.ContactPaymentInfo.EmailStatements);
        self.ChequePaymentMode = ko.observable(contact.ContactPaymentInfo.ChequePaymentMode);
        self.CashPaymentMode = ko.observable(contact.ContactPaymentInfo.CashPaymentMode);
        self.OnlinePaymentMode = ko.observable(contact.ContactPaymentInfo.OnlinePaymentMode);
        self.BankAccountNumber = ko.observable(contact.ContactPaymentInfo.BankAccountNumber);
        self.Bank = ko.observable(contact.ContactPaymentInfo.Bank);
        self.Branch = ko.observable(contact.ContactPaymentInfo.Branch);
        self.BankIFSC = ko.observable(contact.ContactPaymentInfo.IFSC);

    }
    else {
        self.TaxEligible = ko.observable('');
        self.TaxId = ko.observable('');
        self.TaxPayerName = ko.observable('');
        self.Ownership = ko.observable('');
        self.EmailAlerts = ko.observable('');
        self.EmailStatements = ko.observable('');
        self.ChequePaymentMode = ko.observable('');
        self.CashPaymentMode = ko.observable('');
        self.OnlinePaymentMode = ko.observable('');
        self.BankAccountNumber = ko.observable('');
        self.Bank = ko.observable('');
        self.Branch = ko.observable('');
        self.BankIFSC = ko.observable('');
    }
    if (contact.Contact) {
        self.RefId = ko.observable(contact.Contact.RefId || '');
        if (ko.toJS(contact.Contact.ContactType) == '0') {
            self.IsCompany = ko.observable('Individual');
        }
        if (ko.toJS(contact.Contact.ContactType) == '1') {
            self.IsCompany = ko.observable('Company');
        }
        self.SecondaryEmail = ko.observable(contact.Contact.SecondaryEmail).extend({ email: { params: true, message: "Please enter valid email" } });
        self.Comments(contact.Contact.Description);
        self.OfficePhone = ko.observable(contact.Contact.OfficePhone);
        if (contact.Contact.Person) {
            self.CountryId = ko.observable(contact.Contact.Person.CountryId).extend({ required: { params: true, message: "Please Select Country" } });
            self.FirstName = ko.observable(contact.Contact.Person.FirstName || '').extend({ required: { params: true, message: "Please Enter First Name" } });
            self.LastName = ko.observable(contact.Contact.Person.LastName || '');
            self.Email = ko.observable(contact.Contact.Person.Email || '').extend({ email: { params: true, message: "Please enter valid email" } });
            //self.Website = ko.observable(contact.Contact.Person.Website || '').extend({ url: true });
            self.Address = ko.observable(contact.Contact.Person.Address || '');
            self.Phone = ko.observable(contact.Contact.Person.PhoneNo || '');
            self.City = ko.observable(contact.Contact.Person.City || '');
            self.State = ko.observable(contact.Contact.Person.State || '');
            self.Zip = ko.observable(contact.Contact.Person.Zip || 0);
            self.Region = ko.observable(contact.Contact.Person.Region);
            self.Title = ko.observable(contact.Contact.Person.Title || '').extend({ required: { params: true, message: "Please Enter Title" } });
            self.Comapny = ko.observable(contact.Contact.Person.Company || '').extend({ required: { params: true, message: "Please Enter Company Name" } });

        }
    }
    else {
        self.Region = ko.observable();
        self.CountryId = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
        self.SecondaryEmail = ko.observable('').extend({ email: { params: true, message: "Please enter valid email" } });
        self.Description = ko.observable('');
        self.OfficePhone = ko.observable('');
        self.IsCompany = ko.observable('Individual');
        self.Zip = ko.observable('');
        self.RefId = ko.observable('');
        self.FirstName = ko.observable('').extend({ required: { params: true, message: "Please Enter First Name" } });
        self.LastName = ko.observable('');
        self.Email = ko.observable('').extend({ email: { params: true, message: "Please enter valid email" } });
        //self.Website = ko.observable('').extend({ url: true });
        self.Address = ko.observable('');
        self.Phone = ko.observable('');
        self.City = ko.observable('');
        self.State = ko.observable('');
        self.Title = ko.observable('').extend({ required: { params: true, message: "Please Enter Title" } });
        self.Comapny = ko.observable('').extend({ required: { params: true, message: "Please Enter Company Name" } });
    }
    if (contact.Agent) {
        self.AssignedTo = ko.observable(contact.Agent.FirstName || '');
    } else {
        self.AssignedTo = ko.observable('');
    }
    if (contact.City) {
        self.CountryId(contact.City.State.CountryId);
        self.StateId(contact.City.StateId);
        self.CityId(contact.CityId);


    }

    self.modelState = ko.validatedObservable(
        {
            FirstName: self.FirstName,
            Title: self.Title,
            Email: self.Email,
            CountryId: self.CountryId,
            SecondaryEmail: self.SecondaryEmail
            //AgentId: self.AgentId,
            //AccountId: self.AccountId
        });
    self.resetValidation = function () {

        self.FirstName.isModified(false);
        self.Title.isModified(false);
        self.Email.isModified(false);
        self.CountryId.isModified(false);
        self.SecondaryEmail.isModified(false);
        //self.AgentId.isModified(false);
        //self.AccountId.isModified(false);
    };
}
