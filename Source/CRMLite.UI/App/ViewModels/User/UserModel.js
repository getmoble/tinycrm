function User(user) {
    var self = this;
    self.Id = ko.observable(user.Id || 0);
    self.PersonId = ko.observable(user.PersonId || 0);
    self.UserName = ko.observable(user.UserName || '');
    self.LastName = ko.observable(user.LastName || '');
    self.Image = ko.observable(user.Image || '/Upload/User/Person-Dummy.jpg');
    self.IsListingMember = ko.observable(user.IsListingMember || '');
    self.IsListingMemberDetail = ko.observable('');
    self.FirstName = ko.observable(user.FirstName || '').extend({ required: { params: true, message: "Please enter First Name" } });
    self.Email = ko.observable('').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
    self.PhoneNumber = ko.observable(user.Phone || '').extend({ required: { params: true, message: "Please enter Phone Number" } });
    self.Address = ko.observable(user.Address || '').extend({ required: { params: true, message: "Please enter address" } });
    self.Name = ko.pureComputed(function () {
        if ((self.FirstName() != "" && self.FirstName() != null) && (self.LastName() != "" && self.LastName() != null)) {
            return self.FirstName() + " " + self.LastName();
        }
        else if ((self.FirstName() != "" && self.FirstName() != null) && (self.LastName() == "" || self.LastName() == null)) {
            return self.FirstName();
        }
        else if ((self.FirstName() == "" || self.FirstName() == null) && (self.LastName() != "" || self.LastName() != null)) {
            return self.LastName();
        }
        else {
            return 'No name provided';
        }
    }, this);
    if (user.Person) {
        self.FirstName(user.Person.FirstName);
        self.LastName(user.Person.LastName);
    }
    if (user.Person) {
        self.Email(user.Person.Email);
        self.PhoneNumber(user.Person.PhoneNo);
        self.Address(user.Person.Address);
        if (self.Email() != null)
            self.Email(ko.toJS(self.Email).toLowerCase());
    } else {
        self.Email(user.Email);
        self.PhoneNumber(user.Phone);
        self.Address(user.Address);
        if (self.Email() != null)
            self.Email(ko.toJS(self.Email).toLowerCase());
    }

    if ((ko.toJS(user.IsListingMember)) == true)
        self.IsListingMemberDetail('Yes');
    else if ((ko.toJS(user.IsListingMember)) == false)
        self.IsListingMemberDetail('No');
    self.modelState = ko.validatedObservable(
   {
       FirstName: self.FirstName,
       Email: self.Email,
       Address: self.Address
   });
    self.resetValidation = function () {
        self.FirstName.isModified(false);
        self.Email.isModified(false);
        self.Address.isModified(false);
    };

}