function Account(account) {
    var self = this;
    self.RefId = ko.observable(account.RefId || '');
    self.Id = ko.observable(account.Id || 0);
    self.PersonId = ko.observable(account.PersonId || 0);
    self.CommunicationDetailId = ko.observable(account.CommunicationDetailId || 0);
    self.AccountName = ko.observable('').extend({ required: { params: true, message: "Please select Account Name" } });
    self.Industry = ko.observable(account.Industry || '').extend({ required: { params: true, message: "Please select Industry" } });
    self.SelectedAssignedto = ko.observable(account.AssignedToUserId || 0).extend({ required: { params: true, message: "Please select User" } });
    self.Assignedto = ko.observable(''); 
    self.Description = ko.observable(account.Description || '');
    self.Website = ko.observable('').extend({ url: true });
    self.Comment = ko.observable(account.Description || '');
    if (account.Person) {
        self.AccountName(account.Person.FirstName);
        self.Website(account.Person.Website || '');
        self.Phone = ko.observable(account.Person.PhoneNo || '').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.Email = ko.observable(account.Person.Email || '').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Address = ko.observable(account.Person.Address || '').extend({ required: { params: true, message: "Please enter Address" } });
        if (self.Email() != null)
            self.Email(ko.toJS(self.Email).toLowerCase());
        if (self.Website() != null)
            self.Website(ko.toJS(self.Website).toLowerCase());
    }
    else {
        self.Phone = ko.observable('').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.Email = ko.observable('').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Address = ko.observable('').extend({ required: { params: true, message: "Please enter Address" } });
    }
    if (account.AssignedToUser) {
        if (account.AssignedToUser.Person) {
            self.Assignedto = ko.observable(account.AssignedToUser.Person.FirstName || '');
        }
    }
    else {
        self.Assignedto = ko.observable('');
    }
    self.modelState = ko.validatedObservable(
  {
      AccountName: self.AccountName,
      Industry: self.Industry,
      Email: self.Email,
      Phone: self.Phone,
      Address: self.Address,
      SelectedAssignedto: self.SelectedAssignedto

  });
    self.resetValidation = function () {
        self.AccountName.isModified(false);
        self.Industry.isModified(false);
        self.Email.isModified(false);
        self.Phone.isModified(false);
        self.Address.isModified(false);
        self.SelectedAssignedto.isModified(false);
    };
}