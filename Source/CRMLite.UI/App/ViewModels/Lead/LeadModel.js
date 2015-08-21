function Lead(lead) {
    var self = this;
    self.Id = ko.observable(lead.Id || 0);
    self.FirstName = ko.observable('').extend({ required: { params: true, message: "Please enter First Name" } });
    self.LastName = ko.observable('');
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
    if (lead.CreatedOn != null && lead.CreatedOn !== 'undefined') {
        self.CreatedOn = ko.observable(moment(lead.CreatedOn).format('DD/MM/YYYY'));
    }
    else {
        self.CreatedOn = ko.observable('');
    }
    if (lead.RecievedOn != null && lead.RecievedOn !== 'undefined') {
        self.RecievedOn = ko.observable(moment(lead.RecievedOn).format('DD/MM/YYYY'));
    }
    else {
        self.RecievedOn = ko.observable('');
    }
    self.Website = ko.observable('').extend({ url: true })
    self.Company = ko.observable('');
    self.Designation = ko.observable(lead.Designation || '');
    if (lead.Person) {
        self.FirstName(lead.Person.FirstName);
        self.LastName(lead.Person.LastName);
        self.Company(lead.Person.Company);
        self.Email = ko.observable(lead.Person.Email || '').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Phone = ko.observable(lead.Person.PhoneNo || '').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.Website(lead.Person.Website || '');
        if (self.Website() != null)
            self.Website(ko.toJS(self.Website).toLowerCase());
        if (self.Email() != null)
            self.Email(ko.toJS(self.Email).toLowerCase());
    } else {
        self.Email = ko.observable('').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Phone = ko.observable('').extend({ required: { params: true, message: "Please enter Phone Number" } });
    }
    self.RefId = ko.observable(lead.RefId || '');
    self.CommunicationDetailID = ko.observable(lead.PersonId || 0);
    self.CreatedBy = ko.observable(lead.CreatedBy || 0);
    self.Other = ko.observable(lead.LeadSourceName || '');
    if (lead.LeadStatus)
        self.LeadStatus = ko.observable(lead.LeadStatus.Name || '');
    else
        self.LeadStatus = ko.observable('');
    if (lead.LeadSource) {
        self.LeadSource = ko.observable(lead.LeadSource.Name || '');
        self.LeadSourceUserId = ko.observable(lead.LeadSourceUserId || '');
    }
    else {
        self.LeadSource = ko.observable('');
        self.LeadSourceUserId = ko.observable('');
    }
    self.LeadSourceName = ko.observable();
    self.LeadSourceNameVisible = ko.observable(false);
    if (lead.LeadSourceUser) {
        self.LeadSourceName(lead.LeadSourceUser.Name || '');
        self.LeadSourceNameVisible(true);
    }

    if (lead.AssignedToUser)
        self.Assignedto = ko.observable(lead.AssignedToUser.Name || '').extend({ required: { params: true, message: "Please select User" } });
    else
        self.Assignedto = ko.observable('').extend({ required: { params: true, message: "Please select User" } });
    self.Comment = ko.observable(lead.Description);
    self.SelectedAssignedTo = ko.observable(lead.AssignedToUserId).extend({ required: { params: true, message: "Please select User" } });
    self.SelectedLeadStatus = ko.observable(lead.LeadStatusId).extend({ required: { params: true, message: "Please select Lead Status" } });
    self.SelectedSalesStage = ko.observable(lead.SalesStageId).extend({ required: { params: true, message: "Please select Sales Stage" } });
    self.SelectedLeadSource = ko.observable(lead.LeadSourceId).extend({ required: { params: true, message: "Please select Lead Source" } });
    self.IsDropdownVisbility = ko.observable(false);
    self.IsTextBox = ko.observable(false);

    self.SelectedLeadSource.subscribe(function (newValue) {
        if (newValue == 1) {
            self.IsDropdownVisbility(true);
            self.IsTextBox(false);
        }
        else if (newValue == 5 || newValue == 4) {
            self.IsTextBox(true);
            self.IsDropdownVisbility(false);
        }
        else {
            self.IsDropdownVisbility(false);
            self.IsTextBox(false);
        }
    });
    self.modelState = ko.validatedObservable(
   {
       FirstName: self.FirstName,
       SelectedAssignedTo: self.SelectedAssignedTo,
       SelectedLeadStatus: self.SelectedLeadStatus,
       SelectedLeadSource: self.SelectedLeadSource

   });
    self.resetValidation = function () {
        self.FirstName.isModified(false);
        self.SelectedAssignedTo.isModified(false);
        self.SelectedLeadStatus.isModified(false);
        self.SelectedLeadSource.isModified(false);
        self.Website.isModified(false);
    };
}