function Potential(potential) {
    var self = this;
    self.Id = ko.observable(potential.Id || 0);
    self.CityId = ko.observable().extend({ required: { params: true, message: "Please Select City" } });
    self.StateId = ko.observable().extend({ required: { params: true, message: "Please Select State" } });
    self.CountryId = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    self.locations = ko.observableArray();
    self.ShowingDate = ko.observable(potential.ShowingDate || '');
    self.RefId = ko.observable(potential.RefId || '');
    self.PropertyId = ko.observable(potential.PropertyId || 0);
    self.PotentialName = ko.observable(potential.Name || '').extend({ required: { params: true, message: "Please enter Name" } });
    if (potential.Person) {
        self.PotentialName(potential.Person.FirstName);
    }

    self.PotentialAmount = ko.observable(potential.ExpectedAmount || '').extend({ required: { params: true, message: "Please enter Amount" } });
    if (potential.Account)
        self.AccountId = ko.observable(potential.Account.Id);
    else
        self.AccountId = ko.observable('').extend({ required: { params: true, message: "Please Select Account" } });
    if (potential.ExpectedCloseDate != null && potential.ExpectedCloseDate !== 'undefined') {

        self.ExpectedCloseDate = ko.observable(moment(potential.ExpectedCloseDate).format('DD/MM/YYYY')).extend({ required: { params: true, message: "Please select Date" } });

    }
    else {
        self.ExpectedCloseDate = ko.observable('');
    }
    if (potential.EnquiredOn != null && potential.EnquiredOn !== 'undefined') {

        self.EnquiredOn = ko.observable(moment(potential.EnquiredOn).format('DD/MM/YYYY'));

    }
    else {
        self.EnquiredOn = ko.observable('');
    }
    self.LeadSourceName = ko.observable(potential.LeadSourceName || '');
    self.ContactNo = ko.observable(potential.ContactNo || '');
    self.ContactName = ko.observable(potential.ContactName || '');
    self.AccountName = ko.observable(potential.AccountName || '');
    self.AccountNo = ko.observable(potential.AccountNo || '');
    self.Industry = ko.observable(potential.Industry || '');
    self.ContactTitle = ko.observable(potential.ContactTitle || '');
    self.PropertyArea = ko.observable(potential.PropertyArea || '');
    self.PropertyBudgetFrom = ko.observable(potential.PropertyBudgetFrom || '');
    self.PropertyBudgetTo = ko.observable(potential.PropertyBudgetTo || '');
    self.PropertyCategory = ko.observable(potential.PropertyCategory || '');
    self.PropertyFloor = ko.observable(potential.PropertyFloor || '');
    self.SalesStageName = ko.observable(potential.SalesStageName || '');
    self.UserName = ko.observable(potential.UserName || '');
    self.AssignedTo = ko.observable(potential.AssignedTo || '');
    self.PropertyType = ko.observable(potential.PropertyType || '');
    self.selectedAssignedTo = ko.observable(potential.AssignedToUserId || 0).extend({ required: { params: true, message: "Please select User" } });
    self.SelectedContact = ko.observable(potential.ContactId || 0).extend({ required: { params: true, message: "Please select Contact" } });
    self.SelectedLeadStatus = ko.observable(potential.LeadStatusId).extend({ required: { params: true, message: "Please select Lead Status" } });
    self.SelectedSalesStage = ko.observable(potential.SalesStageId).extend({ required: { params: true, message: "Please select Sales Stage" } });
    self.SelectedLeadSource = ko.observable(potential.LeadSourceId).extend({ required: { params: true, message: "Please select Lead source" } });
    self.selectedUser = ko.observable(potential.UserId || 0);
    self.IsDropdownVisbility = ko.observable(false);
    self.Comments = ko.observable(potential.Description || '');
    self.SelectedLeadSource.subscribe(function (newValue) {
        if (newValue == 1) {
            self.IsDropdownVisbility(true);
        }
        else {
            self.IsDropdownVisbility(false);
        }
    });
    self.modelState = ko.validatedObservable(
  {
      AccountId: self.AccountId,
      PotentialAmount: self.PotentialAmount,
      PotentialName: self.PotentialName,
      ExpectedCloseDate: self.ExpectedCloseDate,
      selectedAssignedTo: self.selectedAssignedTo,
      SelectedContact: self.SelectedContact,
      //SelectedLeadStatus: self.SelectedLeadStatus,
      SelectedSalesStage: self.SelectedSalesStage,
      SelectedLeadSource: self.SelectedLeadSource

  });
    self.resetValidation = function () {
        self.AccountId.isModified(false);
        self.PotentialAmount.isModified(false);
        self.PotentialName.isModified(false);
        self.ExpectedCloseDate.isModified(false);
        self.selectedAssignedTo.isModified(false);
        self.SelectedContact.isModified(false);
        self.SelectedSalesStage.isModified(false);
        self.SelectedLeadSource.isModified(false);
    };
}