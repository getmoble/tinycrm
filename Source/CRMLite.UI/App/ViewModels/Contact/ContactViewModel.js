function ContactViewModel() {
    var self = this;
    self.url = urls.CRM;
    var editedState = '';
    var editedCity = '';
    self.DisplayTitle = ko.observable();
    self.busy = ko.observable();
    self.Account = ko.observableArray();
    self.User = ko.observableArray();
    self.ContactLists = ko.observableArray();
    self.SearchTitle = ko.observable();
    self.SearchUser = ko.observable();
    self.SearchAccount = ko.observable();
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.isBusy = ko.observable(false);
    self.isDropdownChange = ko.observable(false);
    self.initialStage = ko.observable(false);
    self.initialCityStage = ko.observable(false);
    self.Cities = ko.observableArray();
    self.States = ko.observableArray();
    self.Countries = ko.observableArray();
    self.SelectedContact = ko.observable(new Contact({}));
    self.selectedCountry = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    self.selectedState = ko.observable().extend({ required: { params: true, message: "Please Select State" } });

    self.contactdelete = function (item) {
        bootbox.confirm("Do you want to delete the Contact" + " '" + item.Name() + "' " + " ?", function (result) {
            if (result) {
                var result = CRMLite.dataManager.postData(ko.toJS(self.url.contactapiDeleteContact) + item.Id());
                result.done(function (response) {
                    if (response.Status == true) {
                        bootbox.alert("Contact deleted Successfully..!!", function () {
                            window.location.href = ko.toJS(self.url.contactIndex);
                        });
                    }
                    else {
                        toastr["error"](response.Message, "Notification");
                    }
            });
            }
        });
    };
    self.getEditPage = function (item) {
        var self = this;
        self.CRMUrl = urls.CRM;
        window.location.href = ko.toJS(self.CRMUrl.contactEdit) + item.Id();
    };
    self.contactedit = function (item) {
        self.isCreate(false);
        self.isUpdate(true);
        self.isBusy(true);
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.contactapiGetAllCountries));
        result.done(function (response) {
            if (response.Status === true) {
                $.each(response.Result, function (key, value) {
                    self.Countries.push(new Country(value));
                });
                self.isBusy(false);
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });
        var contactIdValue = $("#hdnContactId").data('value');
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.contactapiGetContact) + contactIdValue);
        result.done(function (data) {
            self.SelectedContact(new Contact(data.Result));
        });
    };
    self.gotoContactdetails = function (item) {
        window.location.href = ko.toJS(self.url.gotoContactdetails) + item.Id();
    };
    self.contactdetails = function (item) {
        self.isBusy(true);
        var id = $("#hdnContactId").val();
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.contactapiGetContact) + id);
        result.done(function (response) {
            if (response.Status === true) {
                self.SelectedContact(new Contact(response.Result));
                self.isBusy(false);
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });
    };
};
ContactViewModel.prototype.init = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.isBusy(true);
    self.DisplayTitle('Create Contact');
    self.SelectedContact().resetValidation();
    var result = CRMLite.dataManager.getData(ko.toJS(self.url.contactapiGetAllContacts));
    result.done(function (response) {
        if (response.Status === true) {

            $.each(response.Result.Users, function (key, value) {
                self.User.push(new SelectAssignedTo(value));
            });
            $.each(response.Result.Accounts, function (key, value) {
                self.Account.push(new SelectAccount(value));
            });

            $.each(response.Result.Contacts, function (key, value) {
                self.ContactLists.push(new Contact(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            var oTable = $('#pagination').dataTable();
            self.isBusy(false);
        }
        else {
            toastr["error"](response.Message, "Notification");
        }
    });
};
ContactViewModel.prototype.createPage = function () {
    var self = this;
    self.isBusy(true);
    var result = CRMLite.dataManager.getData(ko.toJS(self.url.contactapiGetAllCountries));
    result.done(function (response) {
        if (response.Status === true) {
            $.each(response.Result, function (k, v) {
                self.Countries.push(new Country(v));
            });
            self.isBusy(false);
        }
        else {
            toastr["error"](response.Message, "Notification");
        }
    });
};
ContactViewModel.prototype.saveContact = function () {
    var self = this;
    self.SelectedContact().resetValidation();
    if (self.SelectedContact().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.SelectedContact());
        var result = CRMLite.dataManager.postData(ko.toJS(self.url.contactapiCreateContact), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status === true) {
                self.isBusy(true);
                bootbox.alert("Contact saved successfully...!!", function () {
                    self.isBusy(false);
                    window.location.href = ko.toJS(self.url.contactIndex);
                });
            }
            else {         
                toastr["error"](response.Message, "Notification");
            }

        });
    }
    else {
        self.SelectedContact().modelState.errors.showAllMessages();
        self.isBusy(false);
    }
};
ContactViewModel.prototype.updateContact = function () {
    var self = this;
    self.isBusy(true);
    if (self.SelectedContact().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.SelectedContact());
        var result = CRMLite.dataManager.postData(ko.toJS(self.url.contactapiUpdateContact), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Result === true) {
                bootbox.alert("Contact updated successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.contactIndex);
                });
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });
        self.isBusy(false);
    } else {
        self.SelectedContact().modelState.errors.showAllMessages();
        self.isBusy(false);
    }
};
ContactViewModel.prototype.search = function () {
    var self = this;
    self.isBusy(true);
    var oldTable = $("#pagination").DataTable();
    oldTable
      .clear()
      .draw();
    oldTable.destroy();
    var jsonData = {
        UserId: ko.toJS(self.SearchUser), AccountId: ko.toJS(self.SearchAccount), Title: ko.toJS(self.SearchTitle)
    };
    var result = CRMLite.dataManager.postData(ko.toJS(self.url.contactapiSearch), jsonData);
    result.done(function (response) {
        if (response.Status == true) {
            self.ContactLists.removeAll();
            $.each(response.Result, function (key, value) {
                self.ContactLists.push(new Contact(value));
            });

            $("#pagination").DataTable({ responsive: true });
            self.isBusy(false);
        }
        else {
            toastr["error"](response.Message, "Notification");
        }
    });

};
ContactViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.SelectedContact(new Contact({}));
    self.SelectedContact().resetValidation();
};
ContactViewModel.prototype.ToDo = function (item) {
    var self = this;
    self.url = urls.CRM;
    window.location.href = ko.toJS(self.url.fullCalenderIndexentityTypeContact) + ko.toJS(item.Id);
};
ContactViewModel.prototype.gotoContactPage = function () {
    var self = this;
    self.CRMUrl = urls.CRM;
    self.isCreate(true);
    self.isUpdate(false);
    self.SelectedContact(new Contact({}));
    self.SelectedContact().resetValidation();
    window.location.href = ko.toJS(self.CRMUrl.contactCreate);
};
function SettingsViewModel() {
    var self = this;
    self.pagingSize = ko.observable();
    self.url = urls.CRM;

    self.Change = function () {
        var result = CRMLite.dataManager.postData(ko.toJS(self.url.settingsapiChangePagingSize), jsonData);
        result.done(function (response) {
            if (response.Status === true) {
                bootbox.alert("Settings saved successfully...!!", function () {
                });
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });
    };
};
