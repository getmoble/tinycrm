﻿function ModelBase() {
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
function User(user) {
    var self = this;
    self.Id = ko.observable(user.Id || 0);
    self.PersonId = ko.observable(user.PersonId || 0);
    self.firstname = ko.observable('').extend({ required: { params: true, message: "Please enter First Name" } });
    self.lastname = ko.observable(user.LastName || '');
    if (user.Person) {
        self.firstname(user.Person.FirstName);
        self.lastname(user.Person.LastName);
        self.email = ko.observable(user.Person.Email || '').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.phoneNumber = ko.observable(user.Person.PhoneNo || '').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.address = ko.observable(user.Person.Address || '').extend({ required: { params: true, message: "Please enter address" } });
    } else {
        self.email = ko.observable('').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.phoneNumber = ko.observable('').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.address = ko.observable('').extend({ required: { params: true, message: "Please enter address" } });
    }
    self.image = ko.observable(user.Image || '/Upload/User/Person-Dummy.jpg');
    self.DEDlicenseNumber = ko.observable(user.DEDLicenseNumber || '');
    self.RERAregistrationNumber = ko.observable(user.RERARegistrationNumber || '');
    self.islistingmember = ko.observable(user.IsListingMember || '');
    self.refId = ko.observable(user.RefId || '');
    self.contactdetailId = ko.observable(user.CommunicationDetailId || 0);
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
    self.FirstName = ko.observable('').extend({ required: { params: true, message: "Please enter First Name" } });
    self.LastName = ko.observable('').extend({ required: { params: true, message: "Please enter Last Name" } });
    self.Name = ko.observable('');
    self.Company = ko.observable('').extend({ required: { params: true, message: "Please enter Contact Name" } });
    if (lead.Person) {
        self.FirstName(lead.Person.FirstName);
        self.LastName(lead.Person.LastName);
        self.Company(lead.Person.Company);
        self.Email = ko.observable(lead.Person.Email || '').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Phone = ko.observable(lead.Person.PhoneNo || '').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.Website = ko.observable(lead.Person.Website || '').extend({ required: { params: true, message: "Please enter Website" } });
        self.Name = ko.pureComputed(function () {
            return self.FirstName() + " " + self.LastName();
        }, this);
    } else {
        self.Email = ko.observable('').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Phone = ko.observable('').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.Website = ko.observable('').extend({ required: { params: true, message: "Please enter Website" } });
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
        self.SelectedOptionalUser = ko.observable(lead.LeadSource.Name || '');
    }
    else {
        self.LeadSource = ko.observable('');
        self.SelectedOptionalUser = ko.observable('');
    }
    if (lead.AssignedToUser)
        self.Assignedto = ko.observable(lead.AssignedToUser.Name || '').extend({ required: { params: true, message: "Please select User" } });
    else
        self.Assignedto = ko.observable('').extend({ required: { params: true, message: "Please select User" } });
    self.Comments = ko.observable(lead.Description);
    self.SelectedAssignedTo = ko.observable(lead.AssignedToUserId).extend({ required: { params: true, message: "Please select User" } });
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
function SelectAssignedTo(User) {
    var self = this;
    self.Id = ko.observable(User.Id);
    self.Name = ko.observable(User.Name);
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
    self.SelectedAssignedTo = ko.observable(convertlead.AssignedToUserId || 0);
    self.ConvertAssignedTo = ko.observable(convertlead.AssignedToUserId || 0);
    self.SelectedLeadSource = ko.observable(convertlead.LeadSourceId || 0);
    self.Email = ko.observable('');
    self.Phone = ko.observable('');
    self.FirstName = ko.observable('');
    self.LastName = ko.observable('');
    if (convertlead.Person)
    {
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
function SelectAccount(account) {
    var self = this;
    self.Id = ko.observable(account.Id || 0);

    self.Name = ko.observable('');
    if (account.Person)
    {
        self.Name(account.Person.FirstName);
    }
}
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
    self.PotentialName = ko.observable(potential.Name||'').extend({ required: { params: true, message: "Please enter Name" } });
    if(potential.Person)
    {   
        self.PotentialName(potential.Person.FirstName);
    }
    
    self.PotentialAmount = ko.observable(potential.ExpectedAmount || '').extend({ required: { params: true, message: "Please enter Amount" } });
    if (potential.Account)
        self.AccountId = ko.observable(potential.Account.Id);
    else
        self.AccountId = ko.observable('').extend({ required: { params: true, message: "Please Select Account" } });
    //if (potential.Property) {
    //    self.selectedState = ko.observable(potential.Property.StateId || 0);
    //    self.selectedLocation = ko.observable(potential.Property.LocationId || 0);
    //}
    //else {
    //    self.selectedState = ko.observable('').extend({ required: { params: true, message: "Please select State" } });
    //    self.selectedLocation = ko.observable('').extend({ required: { params: true, message: "Please select Location" } });
    //}
    //self.ExpectedCloseDate = ko.observable(potential.ExpectedCloseDate).extend({ required: { params: true, message: "Please select Date" } });
    if (potential.ExpectedCloseDate != null && potential.ExpectedCloseDate !== 'undefined') {
        //self.ExpectedCloseDate = ko.observable(moment(potential.ExpectedCloseDate, 'MM/DD/YYYY').format('MMMM D')).extend({ required: { params: true, message: "Please select Date" } });
        self.ExpectedCloseDate = ko.observable(moment(potential.ExpectedCloseDate).format('DD/MM/YYYY')).extend({ required: { params: true, message: "Please select Date" } });

    }
    else {
        self.ExpectedCloseDate = ko.observable('');
    }
    //if (potential.Property) {
    //    if (potential.Property.City) {
    //        self.CountryId(potential.Property.City.State.CountryId);
    //        self.StateId(potential.Property.City.StateId);
    //        self.CityId(potential.Property.CityId);
    //    }
    //    }
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
        //self.SelectedLeadStatus.isModified(false);
        self.SelectedSalesStage.isModified(false);
        self.SelectedLeadSource.isModified(false);
    };
}
function Contact(contact) {
    var self = this;
    self.Individual = ko.observable();
    self.IsCompany = ko.observable('Individual');
    self.Id = ko.observable(contact.Id || 0);
    self.FirstName = ko.observable('').extend({ required: { params: true, message: "Please Enter First Name" } });
    self.LastName = ko.observable('');
    self.RefId = ko.observable(contact.RefId || '');
    self.Title = ko.observable('').extend({ required: { params: true, message: "Please Enter Title" } });
    self.Comapny = ko.observable( '').extend({ required: { params: true, message: "Please Enter Company Name" } });
    self.CountryId = ko.observable('');
    self.State = ko.observable(contact.State || '');
    self.City = ko.observable(contact.City || '');
    self.Region = ko.observable(contact.Region || '');
    self.Zip = ko.observable('');
    self.SecondaryEmail = ko.observable(contact.SecondaryEmail);
    self.OfficePhone = ko.observable(contact.OfficePhone);

    self.AccountId = ko.observable(contact.AccountId || 0).extend({ required: { params: true, message: "Please select Account" } });
    self.UserId = ko.observable(contact.UserId || 0).extend({ required: { params: true, message: "Please select User" } });
    self.Comments = ko.observable(contact.Description || '');
    self.CommunicationDetailId = ko.observable(contact.CommunicationDetailId || 0);
    if (contact.Account) {
        self.AccountName = ko.observable(contact.Account.Name || '');
    }
    else {
        self.AccountName = ko.observable('');
    }
    if (contact.Person) {
        self.FirstName(contact.Person.FirstName);
        self.LastName(contact.Person.LastName);
        self.CountryId(contact.Person.CountryId);
        self.Title(contact.Person.Title);
        self.Comapny(contact.Person.Company);
        self.Email = ko.observable(contact.Person.Email || '').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Website = ko.observable(contact.Person.Website || '');
        self.Address = ko.observable(contact.Person.Address || '');
        self.Zip = ko.observable(contact.Person.Zip);
        self.State(contact.Person.State);
        self.City(contact.Person.City);
        self.Region(contact.Person.Region);
        self.Phone = ko.observable(contact.Person.PhoneNo || '').extend({ required: { params: true, message: "Please Enter Phone" } });
    }
    else {
        self.Email = ko.observable('').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Website = ko.observable('');
        self.Address = ko.observable('');
        self.Phone = ko.observable('').extend({ required: { params: true, message: "Please Enter Phone" } });
    }
    if (contact.ContactType)
    {
        if(ko.toJS(contact.ContactType)='1')
        {
            self.IsCompany('Company');
        }

    }
    if (contact.User) {
        self.AssignedTo = ko.observable(contact.User.FirstName || '');
    } else {
        self.AssignedTo = ko.observable('');
    }
    self.modelState = ko.validatedObservable(
  {
      FirstName: self.FirstName,
      Title: self.Title,
      Email: self.Email,
      Phone: self.Phone,
      UserId: self.UserId,
      AccountId: self.AccountId
  });
    self.resetValidation = function () {

        self.FirstName.isModified(false);
        self.Title.isModified(false);
        self.Email.isModified(false);
        self.Phone.isModified(false);
        self.UserId.isModified(false);
        self.AccountId.isModified(false);
    };
}
function Account(account) {
    var self = this;
    self.RefId = ko.observable(account.RefId || '');
    self.Id = ko.observable(account.Id || 0);
    self.PersonId = ko.observable(account.PersonId || 0);
    self.CommunicationDetailId = ko.observable(account.CommunicationDetailId || 0);
    self.AccountName = ko.observable('').extend({ required: { params: true, message: "Please select Account Name" } });
    self.Industry = ko.observable(account.Industry || '').extend({ required: { params: true, message: "Please select Industry" } });
    self.SelectedAssignedto = ko.observable(account.AssignedToUserId || 0).extend({ required: { params: true, message: "Please select User" } });
    self.Comment = ko.observable(account.Description || '');
    if (account.Person) {
        self.AccountName(account.Person.FirstName);
        self.Website = ko.observable(account.Person.Website || '');
        self.Phone = ko.observable(account.Person.PhoneNo || '').extend({ required: { params: true, message: "Please enter Phone Number" } });
        self.Email = ko.observable(account.Person.Email || '').extend({ email: { params: true, message: "Invalid email" }, required: { params: true, message: "Please enter Email" } });
        self.Address = ko.observable(account.Person.Address || '').extend({ required: { params: true, message: "Please enter Address" } });
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
function Country(country) {
    var self = this;
    self.Id = ko.observable(country.Id);
    self.Name = ko.observable(country.Name);
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