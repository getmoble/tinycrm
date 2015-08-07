function Account(account) {
    var self = this;
    self.RefId = ko.observable(account.RefId || '');
    self.Id = ko.observable(account.Id || 0);
    self.CommunicationDetailId = ko.observable(account.CommunicationDetailId || 0);
    self.AccountName = ko.observable(account.Name || '').extend({ required: { params: true, message: "Please select Account Name" } });
    self.Industry = ko.observable(account.Industry || '').extend({ required: { params: true, message: "Please select Industry" } });
    self.SelectedAssignedto = ko.observable(account.UserId || 0).extend({ required: { params: true, message: "Please select User" } });
    self.Comment = ko.observable(account.Comments || '');
    if (account.CommunicationDetail) {
        self.Website = ko.observable(account.CommunicationDetail.Website || '');
        self.Phone = ko.observable(account.CommunicationDetail.Phone || '').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.Email = ko.observable(account.CommunicationDetail.Email || '').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Address = ko.observable(account.CommunicationDetail.Address || '').extend({ required: { params: true, message: "Please enter Address" } });
    }
    else {
        self.Website = ko.observable('');
        self.Phone = ko.observable('').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.Email = ko.observable('').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Address = ko.observable('').extend({ required: { params: true, message: "Please enter Address" } });
    }
    if (account.User) {
        self.Assignedto = ko.observable(account.User.FirstName || '');
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