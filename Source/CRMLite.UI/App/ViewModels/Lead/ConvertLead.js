function SelectConvertLead(convertlead) {
    var self = this;
    self.Id = ko.observable(convertlead.Id || 0);
    self.AccountName = ko.observable(convertlead.Company || '');
    self.isChecked = ko.observable();
    self.PotentialName = ko.observable();
    self.PotentialAmount = ko.observable('');
    self.SelectedSalesStage = ko.observable(convertlead.SalesStageId || 0);
    self.SelectedAssignedTo = ko.observable(convertlead.AssignedToUserId || 0);
    self.ConvertAssignedTo = ko.observable(convertlead.AssignedToUserId || 0);
    self.SelectedLeadSource = ko.observable(convertlead.LeadSourceId || 0);
    self.Email = ko.observable('');
    self.Phone = ko.observable('');
    self.FirstName = ko.observable('');
    self.LastName = ko.observable('');
    if (convertlead.Person) {
        self.FirstName(convertlead.Person.FirstName);
        self.LastName(convertlead.Person.LastName);
        self.Email(convertlead.Person.Email);
        self.Phone(convertlead.Person.PhoneNo);
    }

    self.ExpectedDate = ko.observable(convertlead.ExpectedDate || '');
    self.CommunicationDetailId = ko.observable(convertlead.CommunicationDetailId || '');
    self.isCheckedBox = ko.observable(true);
    self.isChecked.subscribe(function (val) {
        if (val === true) {
            self.isCheckedBox(false);
        }
        else if (val === false) {
            self.isCheckedBox(true);
        }
    });


}