function ContactViewModel() {
    var self = this;
    self.url = urls.CRM;
    self.DisplayTitle = ko.observable();
    self.busy = ko.observable();
    self.Account = ko.observableArray();
    self.Agent = ko.observableArray();
    self.ContactLists = ko.observableArray();
    self.SearchTitle = ko.observable();
    self.SearchAgent = ko.observable();
    self.SearchAccount = ko.observable();
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.isBusy = ko.observable(false);
    self.Cities = ko.observableArray();
    self.States = ko.observableArray();
    self.Countries = ko.observableArray();
    self.SelectedContact = ko.observable(new Contact({}));
    self.selectedCountry = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    self.selectedState = ko.observable().extend({ required: { params: true, message: "Please Select State" } });
    self.selectedState.subscribe(function (newValue) {
        if (newValue !== '' && newValue != null && newValue != 'undefined') {
            $.get('/Api/ContactApi/GetAllCountries?id=' + newValue, function (data) {
                self.Cities.removeAll();
                $.each(data, function (k, v) {
                    self.Cities.push(new Location(v));
                });
            });
        }
    });
    self.contactdelete = function (item) {
        bootbox.confirm("Do you want to delete this Contact?", function (result) {
            if (result) {
                $.get(ko.toJS(self.url.contactapiDeleteContact) + item.Id());
                bootbox.alert("Deleted Successfully..!!", function () {
                    window.location.href = ko.toJS(self.url.contactIndex);
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
        $.get(ko.toJS(self.url.contactapiGetAllContacts), function (response) {
            if (response.Status === false) {
                if (response.Code === 401) {
                    window.location.href = ko.toJS(self.url.errorNotAuthorized);
                }
                else {
                    bootbox.alert(response);
                }
            } else {
                $.each(response.Agents, function (key, value) {
                    self.Agent.push(new SelectAssignedTo(value));
                });
                $.each(response.Accounts, function (key, value) {
                    self.Account.push(new SelectAccount(value));
                });
            }

            self.isBusy(false);
        });
        var contactIdValue = $("#hdnContactId").data('value');
        $.get(ko.toJS(self.url.contactapiGetContact) + contactIdValue, function (data) {
            self.SelectedContact(new Contact(data));
        });
    };
    self.gotoContactdetails = function (item) {
        window.location.href = ko.toJS(self.url.gotoContactdetails) + item.Id();
    };
    self.contactdetails = function (item) {
        self.isBusy(true);
        var id = $("#hdnContactId").val();
        $.get(ko.toJS(self.url.contactapiGetContact) + id, function (data) {
            self.SelectedContact(new Contact(data));
        });
        self.isBusy(false);
    };
};
ContactViewModel.prototype.init = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.isBusy(true);
    self.DisplayTitle('Create Contact');
    self.SelectedContact().resetValidation();
    $.get(ko.toJS(self.url.contactapiGetAllContacts), function (response) {
        if (response.Status === false) {
            if (response.Code === 401) {
                window.location.href = ko.toJS(self.url.errorNotAuthorized);
            }
            else {
                bootbox.alert(response);
            }
        } else {
            $.each(response.Agents, function (key, value) {
                self.Agent.push(new SelectAssignedTo(value));
            });
            $.each(response.Accounts, function (key, value) {
                self.Account.push(new SelectAccount(value));
            });

            $.each(response.Contacts, function (key, value) {
                self.ContactLists.push(new Contact(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            var oTable = $('#pagination').dataTable();
            self.isBusy(false);
        }
    });
};
ContactViewModel.prototype.createPage = function () {
    var self = this;
    var result = $.get(ko.toJS(self.url.contactapiGetAllStates), function (response) {
        $.each(response, function (k, v) {
            self.States.push(new State(v));
        });
    });
};
ContactViewModel.prototype.saveContact = function () {
    var self = this;
    self.SelectedContact().resetValidation();
    if (self.SelectedContact().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.SelectedContact());
        alert(jsonData);
        var result = $.post(ko.toJS(self.url.contactapiCreateContact), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                self.isBusy(true);
                bootbox.alert("Saved successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.contactIndex);
                });
            }
            else {
                self.isBusy(true);

                bootbox.alert("Error occured");
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
        var result = $.get(ko.toJS(self.url.contactapiUpdateContact), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                bootbox.alert("Updated successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.contactIndex);
                });
            }
            else {

                bootbox.alert("Error occured");

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
        AgentId: ko.toJS(self.SearchAgent), AccountId: ko.toJS(self.SearchAccount), Title: ko.toJS(self.SearchTitle)
    };

    $.get(ko.toJS(self.url.contactapiSearch), jsonData, function (response) {
        self.ContactLists.removeAll();
        $.each(response, function (key, value) {
            self.ContactLists.push(new Contact(value));
        });

        $("#pagination").DataTable({ responsive: true });
        self.isBusy(false);
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
        var result = $.post(ko.toJS(self.url.settingsapiChangePagingSize) + self.pagingSize());
        result.done(function (response) {
            if (response === true) {
                bootbox.alert("Saved successfully...!!", function () {
                });
            }
            else {
                bootbox.alert("Error occured");
            }
        });
    };
};
