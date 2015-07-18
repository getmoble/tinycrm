function ModelBase() {
    var that = {};

    that.IsSelected = ko.observable(false);
    that.parseDateForEdit = function (date) {
        if (date) {
            return new Date(date.match(/\d+/)[0] * 1);
        } else {
            return '';
        }
    };
    that.parseDate = function (date) {
        if (date) {
            var myDate = new Date(parseFloat(/Date\(([^)]+)\)/.exec(date)[1]));
            return myDate.getDate() + '/' + (myDate.getMonth() + 1) + '/'
+ myDate.getFullYear() + '  ' + myDate.getHours() + ':' + myDate.getMinutes() + ':'
+ myDate.getSeconds();
        } else {
            return '';
        }
    };
    that.parseDateOnly = function (date) {
        if (date) {
            var myDate = new Date(parseFloat(/Date\(([^)]+)\)/.exec(date)[1]));
            return (myDate.getMonth() + 1) + '/' + myDate.getDate() + '/'
+ myDate.getFullYear();
        } else {
            return '';
        }
    };

    return that;
}
function Agent(agent) {
    var self = this;
    self.Id = ko.observable(agent.Id || 0);
    self.firstname = ko.observable(agent.FirstName || '').extend({ required: { params: true, message: "Please enter First Name" } });
    self.lastname = ko.observable(agent.LastName || '');
    if (agent.CommunicationDetail) {
        self.email = ko.observable(agent.CommunicationDetail.Email || '').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.phoneNumber = ko.observable(agent.CommunicationDetail.Phone || '').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.address = ko.observable(agent.CommunicationDetail.Address || '').extend({ required: { params: true, message: "Please enter address" } });
    } else {
        self.email = ko.observable('').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.phoneNumber = ko.observable('').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.address = ko.observable('').extend({ required: { params: true, message: "Please enter address" } });
    }
    self.image = ko.observable(agent.Image || '/Upload/Agent/Person-Dummy.jpg');
    self.DEDlicenseNumber = ko.observable(agent.DEDLicenseNumber || '');
    self.RERAregistrationNumber = ko.observable(agent.RERARegistrationNumber || '');
    self.islistingmember = ko.observable(agent.IsListingMember || '');
    self.refId = ko.observable(agent.RefId || '');
    self.contactdetailId = ko.observable(agent.CommunicationDetailId || 0);
    self.modelState = ko.validatedObservable(
   {
       firstname: self.firstname,
       email: self.email,
       address: self.address
   });
    self.resetValidation = function () {

        self.firstname.isModified(false);
        self.email.isModified(false);
        self.address.isModified(false);
    };

}
function Lead(lead) {
    var self = this;
    self.Id = ko.observable(lead.Id || 0);
    self.FirstName = ko.observable(lead.FirstName || '').extend({ required: { params: true, message: "Please enter First Name" } });
    self.LastName = ko.observable(lead.LastName || '').extend({ required: { params: true, message: "Please enter Last Name" } });
    if (lead.CommunicationDetail) {
        self.Email = ko.observable(lead.CommunicationDetail.Email || '').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Phone = ko.observable(lead.CommunicationDetail.Phone || '').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.Website = ko.observable(lead.CommunicationDetail.Website || '').extend({ required: { params: true, message: "Please enter Website" } });
    } else {
        self.Email = ko.observable('').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Phone = ko.observable('').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.Website = ko.observable('').extend({ required: { params: true, message: "Please enter Website" } });
    }
    self.RefId = ko.observable(lead.RefId || '');
    self.CommunicationDetailID = ko.observable(lead.CommunicationDetailId || 0);
    self.CreatedBy = ko.observable(lead.CreatedBy || 0);
    self.Company = ko.observable(lead.Company || '').extend({ required: { params: true, message: "Please enter Contact Name" } });
    self.Other = ko.observable(lead.LeadSourceName || '');
    if (lead.LeadStatus)
        self.LeadStatus = ko.observable(lead.LeadStatus.Name || '');
    else
        self.LeadStatus = ko.observable('');
    if (lead.LeadSource) {
        self.LeadSource = ko.observable(lead.LeadSource.Name || '');
        self.SelectedOptionalAgent = ko.observable(lead.LeadSource.Name || '');
    }
    else {
        self.LeadSource = ko.observable('');
        self.SelectedOptionalAgent = ko.observable('');
    }
    if (lead.Agent)
        self.Assignedto = ko.observable(lead.Agent.FirstName || '').extend({ required: { params: true, message: "Please select Agent" } });
    else
        self.Assignedto = ko.observable('').extend({ required: { params: true, message: "Please select Agent" } });
    self.Comment = ko.observable(lead.Comments);
    self.SelectedAssignedTo = ko.observable(lead.AgentId).extend({ required: { params: true, message: "Please select Agent" } });
    self.SelectedLeadStatus = ko.observable(lead.LeadStatusId).extend({ required: { params: true, message: "Please select Lead Status" } });
    self.SelectedSalesStage = ko.observable(lead.SalesStageId).extend({ required: { params: true, message: "Please select Sales Stage" } });
    self.SelectedLeadSource = ko.observable(lead.LeadSourceId).extend({ required: { params: true, message: "Please select Lead Source" } });
    self.IsDropdownVisbility = ko.observable(false);
    self.IsTextBox = ko.observable(false);
    //if (lead.LeadSourceId == 1) {
    //    self.IsDropdownVisbility = ko.observable(true);
    //    alert('In')
    //    self.IsTextBox = ko.observable(false);
    //} else if (lead.LeadSourceId == 5) {
    //    self.IsDropdownVisbility = ko.observable(false);
    //    self.IsTextBox = ko.observable(true);
    //} else {
    //    self.IsDropdownVisbility = ko.observable(false);
    //    self.IsTextBox = ko.observable(false);
    //}
    self.SelectedLeadSource.subscribe(function (newValue) {
        if (newValue == 1) {
            self.IsDropdownVisbility(true);
            self.IsTextBox(false);
        }
        else if (newValue == 5 ||newValue==4) {
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
       //SelectedSalesStage: self.SelectedSalesStage,
       SelectedLeadSource: self.SelectedLeadSource
       //LastName: self.LastName,
       //Email: self.Email,
       //Phone: self.Phone,
       //Company: self.Company

   });
    self.resetValidation = function () {
        self.FirstName.isModified(false);
        self.SelectedAssignedTo.isModified(false);
        self.SelectedLeadStatus.isModified(false);
        //self.SelectedSalesStage.isModified(false);
        self.SelectedLeadSource.isModified(false);
        //self.LastName.isModified(false);
        //self.Email.isModified(false);
        //self.Phone.isModified(false);
        //self.Company.isModified(false);
    };
}
function SelectAssignedTo(agent) {
    var self = this;
    self.Id = ko.observable(agent.Id);
    self.Name = ko.observable(agent.FirstName);
}
function SelectLeadStatus(leadstatus) {
    var self = this;
    self.Name = ko.observable(leadstatus.Name);
    self.Id = ko.observable(leadstatus.Id);
}
function SelectLeadSource(leadsource) {
    var self = this;
    self.Name = ko.observable(leadsource.Name);
    self.Id = ko.observable(leadsource.Id);
}
function SelectSalesStage(salesStage) {
    var self = this;
    self.Name = ko.observable(salesStage.Name);
    self.Id = ko.observable(salesStage.Id);
}
function SelectConvertLead(convertlead) {
    var self = this;
    self.Id = ko.observable(convertlead.Id || 0);
    self.AccountName = ko.observable(convertlead.Company || '');
    self.isChecked = ko.observable();
    self.PotentialName = ko.observable();
    self.PotentialAmount = ko.observable('');
    self.SelectedSalesStage = ko.observable(convertlead.SalesStageId || 0);
    self.SelectedAssignedTo = ko.observable(convertlead.AgentId || 0);
    self.ConvertAssignedTo = ko.observable(convertlead.AgentId || 0);
    self.SelectedLeadSource = ko.observable(convertlead.LeadSourceId || 0);
    self.FirstName = ko.observable(convertlead.FirstName || '');
    self.ExpectedDate = ko.observable(convertlead.ExpectedDate || '');
    self.LastName = ko.observable(convertlead.LastName || '');
    self.CommunicationDetailId = ko.observable(convertlead.CommunicationDetailId || '');
    self.isCheckedBox = ko.observable(true);
    self.isChecked.subscribe(function (val) {
        if (val == true) {
            self.isCheckedBox(false);
        }
        else if (val == false) {
            self.isCheckedBox(true);
        }
    });

    if (convertlead.CommunicationDetail) {
        self.Email = ko.observable(convertlead.CommunicationDetail.Email || '');
        self.Phone = ko.observable(convertlead.CommunicationDetail.Phone || '');
    }
    else {
        self.Email = ko.observable('');
        self.Phone = ko.observable('');
    }

}
function SelectAccount(account) {
    var self = this;
    self.Id = ko.observable(account.Id || 0);
    self.Name = ko.observable(account.Name || '');
}
function Potential(potential) {
    var self = this;
    self.Id = ko.observable(potential.Id || 0);
    self.locations = ko.observableArray();
    //    self.parseDateOnly = function (date) {
    //        //alert(date);
    //        if (date) {
    //            var myDate = new Date(parseFloat(/Date\(([^)]+)\)/.exec(date)[1]));
    //            return (myDate.getMonth() + 1) + '/' + myDate.getDate() + '/'
    //+ myDate.getFullYear();
    //        } else {
    //            return '';
    //        }
    //  };
    alert(JSON.stringify(potential))
    self.ShowingDate = ko.observable(potential.ShowingDate || '');
    self.RefId = ko.observable(potential.RefId || '');
    self.PropertyId = ko.observable(potential.PropertyId || 0);
    self.PotentialName = ko.observable(potential.Name || '').extend({ required: { params: true, message: "Please enter Name" } });
    self.PotentialAmount = ko.observable(potential.ExpectedAmount || '').extend({ required: { params: true, message: "Please enter Amount" } });
    if (potential.Account)
        self.AccountId = ko.observable(potential.Account.Id);
    else
        self.AccountId = ko.observable('').extend({ required: { params: true, message: "Please Select Account" } });
    if (potential.Property) {
        self.selectedState = ko.observable(potential.Property.StateId || 0);
        self.selectedLocation = ko.observable(potential.Property.LocationId || 0);
        self.selectedPropertyCategory = ko.observable(potential.Property.PropertyCategory.Id || 0).extend({ required: { params: true, message: "Please select Requirement" } });
        self.Floor = ko.observable(potential.Property.Floor || 0);
        self.Area = ko.observable(potential.Property.Area || 0);
        self.BudgetFrom = ko.observable(potential.Property.BudgetFrom || 0);
        self.BudgetTo = ko.observable(potential.Property.BudgetTo || 0);
    }
    else {
        self.selectedState = ko.observable('').extend({ required: { params: true, message: "Please select State" } });
        self.selectedLocation = ko.observable('').extend({ required: { params: true, message: "Please select Location" } });
        self.selectedPropertyCategory = ko.observable('').extend({ required: { params: true, message: "Please select Requirement" } });
        self.Floor = ko.observable('');
        self.Area = ko.observable('');
        self.BudgetFrom = ko.observable('');
        self.BudgetTo = ko.observable('');
    }
    //self.ExpectedCloseDate = ko.observable(potential.ExpectedCloseDate).extend({ required: { params: true, message: "Please select Date" } });
    if (potential.ExpectedCloseDate != null && potential.ExpectedCloseDate != 'undefined') {
        //self.ExpectedCloseDate = ko.observable(moment(potential.ExpectedCloseDate, 'MM/DD/YYYY').format('MMMM D')).extend({ required: { params: true, message: "Please select Date" } });
        self.ExpectedCloseDate = ko.observable(moment(potential.ExpectedCloseDate).format('DD/MM/YYYY')).extend({ required: { params: true, message: "Please select Date" } });
        
    }
    else {
        self.ExpectedCloseDate = ko.observable('');
    }

    self.selectedState.subscribe(function (newValue) {
        if (newValue != '' && newValue != null && newValue != 'undefined') {
            $.get('/Api/PotentialApi/GetLocations?id=' + newValue, function (data) {
                self.locations.removeAll();
                $.each(data, function (k, v) {
                    self.locations.push(new Location(v))
                });
            });
        }
    });
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
    self.AgentName = ko.observable(potential.AgentName || '');
    self.PropertyType = ko.observable(potential.PropertyType || '');
    self.selectedAssignedTo = ko.observable(potential.AgentId || 0).extend({ required: { params: true, message: "Please select Agent" } });
    self.SelectedContact = ko.observable(potential.ContactId || 0).extend({ required: { params: true, message: "Please select Contact" } });
    self.SelectedLeadStatus = ko.observable(potential.LeadStatusId).extend({ required: { params: true, message: "Please select Lead Status" } });
    self.SelectedSalesStage = ko.observable(potential.SalesStageId).extend({ required: { params: true, message: "Please select Sales Stage" } });
    self.SelectedLeadSource = ko.observable(potential.LeadSourceId).extend({ required: { params: true, message: "Please select Lead source" } });
    self.selectedAgent = ko.observable(potential.AgentId || 0);
    self.IsDropdownVisbility = ko.observable(false);
    if (potential.Property)
        self.selectedProperty = ko.observable(potential.Property.propertytype || '');
    else
        self.selectedProperty = ko.observable();
    self.Comments = ko.observable(potential.Comments || '');
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
      selectedPropertyCategory: self.selectedPropertyCategory,
      selectedLocation: self.selectedLocation,
      selectedState: self.selectedState,
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
        self.selectedPropertyCategory.isModified(false);
        self.selectedLocation.isModified(false);
        self.selectedState.isModified(false);
        self.AccountId.isModified(false);
        self.PotentialAmount.isModified(false);
        self.PotentialName.isModified(false);
        self.ExpectedCloseDate.isModified(false);
        self.selectedAssignedTo.isModified(false);
        self.SelectedContact.isModified(false);
        //self.SelectedLeadStatus.isModified(false);
        self.SelectedSalesStage.isModified(false);
        self.SelectedLeadSource.isModified(false);
    };
}
function Contact(contact) {
    var self = this;
    self.Id = ko.observable(contact.Id || 0);
    self.FirstName = ko.observable(contact.FirstName || '').extend({ required: { params: true, message: "Please Enter First Name" } });
    self.LastName = ko.observable(contact.LastName || '');
    self.RefId = ko.observable(contact.RefId || '');
    self.Title = ko.observable(contact.Title || '').extend({ required: { params: true, message: "Please Enter Title" } });
    self.AccountId = ko.observable(contact.AccountId || 0).extend({ required: { params: true, message: "Please select Account" } });
    self.AgentId = ko.observable(contact.AgentId || 0).extend({ required: { params: true, message: "Please select Agent" } });
    self.Comments = ko.observable(contact.Comments || '');
    self.CommunicationDetailId = ko.observable(contact.CommunicationDetailId || 0);
    if (contact.Account) {
        self.AccountName = ko.observable(contact.Account.Name || '');
    }
    else {
        self.AccountName = ko.observable('');
    }
    if (contact.CommunicationDetail) {
        self.Email = ko.observable(contact.CommunicationDetail.Email || '').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Website = ko.observable(contact.CommunicationDetail.Website || '');
        self.Address = ko.observable(contact.CommunicationDetail.Address || '');
        self.Phone = ko.observable(contact.CommunicationDetail.Phone || '').extend({ required: { params: true, message: "Please Enter Phone" } });
    }
    else {
        self.Email = ko.observable('').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Website = ko.observable('');
        self.Address = ko.observable('');
        self.Phone = ko.observable('').extend({ required: { params: true, message: "Please Enter Phone" } });
    }
    if (contact.Agent) {
        self.AssignedTo = ko.observable(contact.Agent.FirstName || '');
    } else {
        self.AssignedTo = ko.observable('');
    }
    self.modelState = ko.validatedObservable(
  {
      FirstName: self.FirstName,
      Title: self.Title,
      Email: self.Email,
      Phone: self.Phone,
      AgentId: self.AgentId,
      AccountId: self.AccountId
  });
    self.resetValidation = function () {

        self.FirstName.isModified(false);
        self.Title.isModified(false);
        self.Email.isModified(false);
        self.Phone.isModified(false);
        self.AgentId.isModified(false);
        self.AccountId.isModified(false);
    };
}
function PropertyType(propertytype) {
    var self = this;
    self.Id = ko.observable(propertytype.Value);
    self.Name = ko.observable(propertytype.Text);
}
function PropertyCategory(propertyCategory) {
    var self = this;
    self.Id = ko.observable(propertyCategory.Id);
    self.Name = ko.observable(propertyCategory.Name);
}
function State(state) {
    var self = this;
    self.Id = ko.observable(state.Id);
    self.Name = ko.observable(state.Name);
}
function Location(location) {
    var self = this;
    self.Id = ko.observable(location.Id);
    self.Name = ko.observable(location.Name);
}
function Account(account) {
    var self = this;
    self.RefId = ko.observable(account.RefId || '');
    self.Id = ko.observable(account.Id || 0);
    self.CommunicationDetailId = ko.observable(account.CommunicationDetailId || 0);
    self.AccountName = ko.observable(account.Name || '').extend({ required: { params: true, message: "Please select Account Name" } });
    self.Industry = ko.observable(account.Industry || '').extend({ required: { params: true, message: "Please select Industry" } });
    self.SelectedAssignedto = ko.observable(account.AgentId || 0).extend({ required: { params: true, message: "Please select Agent" } });
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
    if (account.Agent) {
        self.Assignedto = ko.observable(account.Agent.FirstName || '');
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
function BarChart(sales) {
    var self = this;
    self.y = sales.Month || '';
    self.a = parseInt(sales.Count) || 0;
}
function DoNutChart(leadSource) {
    var self = this;
    self.label = leadSource.LeadStatusKey || '';
    self.value = parseInt(leadSource.Count) || 0;
}
function ParseDate(date) {
    return new Date(parseFloat(/Date\(([^)]+)\)/.exec(date)[1]));
};
function Schedule(events) {
    var self = this;
    self.id = events.Id || 0;
    self.title = events.Title || '';
    self.time = events.Time || '';
    if (events.StartTime) {
        self.start = ParseDate(events.StartTime) || '';
    }
    else {
        self.start = new Date();
    }
    if (events.EndTime)
        self.end = ParseDate(events.EndTime) || '';
    else
        self.end = new Date();
    //self.IsUpdated = ko.observable(false);
}