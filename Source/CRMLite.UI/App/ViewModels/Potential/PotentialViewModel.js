function PotentialViewModel() {
    var self = this;
    self.url = urls.CRM;
    var editedState = '';
    var editedCity = '';
    self.DisplayTitle = ko.observable();
    self.busy = ko.observable();
    self.PotentialLists = ko.observableArray();
    self.Contacts = ko.observableArray();
    self.Leadsource = ko.observableArray();
    self.Leadstatus = ko.observableArray();
    self.Salesstage = ko.observableArray();
    self.propertytype = ko.observableArray();
    self.propertycategories = ko.observableArray();
    self.aminityList = ko.observableArray();
    self.locations = ko.observableArray();
    self.propertyLists = ko.observableArray();
    self.assignProperty = ko.observableArray();
    self.propertyId = ko.observableArray();
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.initialStage = ko.observable(false);
    self.initialCityStage = ko.observable(false);
    self.Cities = ko.observableArray();
    self.States = ko.observableArray();
    self.Countries = ko.observableArray();
    self.Countries = ko.observableArray();
    self.states = ko.observableArray();
    self.User = ko.observableArray();
    self.Account = ko.observableArray();
    self.SearchPropertyType = ko.observable();
    self.SearchUser = ko.observable();
    self.SearchLeadSource = ko.observable();
    self.SearchSalesStage = ko.observable();
    self.isBusy = ko.observable(false);
    self.SelectedContact = ko.observable(new Contact({}));
    self.selectedCountry = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    self.selectedState = ko.observable().extend({ required: { params: true, message: "Please Select State" } });
    self.SelectedPotential = ko.observable(new Potential({}));
    self.SelectedAccount = ko.observable(new Account({}));
    self.potentialdelete = function (item) {
        bootbox.confirm("Do you want to delete the Potential" + " '" + item.PotentialName() + "' " + " ?", function (result) {
            if (result) {
                var result = CRMLite.dataManager.postData(ko.toJS(self.url.potentialapiDeletePotential) + item.Id());
                result.done(function (response) {
                    if (response) {
                        if (response.Status == true) {
                            bootbox.alert("Deleted Successfully..!!", function () {
                                window.location.href = ko.toJS(self.url.potentialIndex);
                            });
                        }
                        else {
                            toastr["error"](response.Message, "Notification");
                        }
                    }
                    else {
                        bootbox.alert("Error Please Try Again Later ..!!");
                    }
                });
            }
        });
    };
 
    self.getEditPage = function (item) {
        var self = this;
        self.CRMUrl = urls.CRM;
        window.location.href = ko.toJS(self.CRMUrl.potentialEdit) + item.Id();
    };
    self.potentialedit = function (item) {

        function toggleChevron(e) {
            $(e.target)
                .prev('.panel-heading')
                .find("i.indicator")
                .toggleClass('glyphicon-chevron-down glyphicon-chevron-up');
        }
        $('#accordion').on('hidden.bs.collapse', toggleChevron);
        $('#accordion').on('shown.bs.collapse', toggleChevron);
        self.isCreate(false);
        self.isUpdate(true);
        var potentialIdValue = $("#hdnPotentialId").data('value');    
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.potentialapiGetPotential) + potentialIdValue);
        result.done(function (data) {
            if (data.Status == true) {
                self.SelectedPotential(new Potential(data.Result));
                $("#AccountSelect").select2();
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });

    };
    self.gotoPotentialdetails = function (item) {
        window.location.href = ko.toJS(self.url.gotoPotentialdetails) + item.Id();
    };
    self.potentialdetail = function () {
        var id = $("#hdnPotentialId").val();
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.potentialapiDetails) + id);
        result.done(function (data) {
            if (data.Status == true) {
                self.SelectedPotential(new Potential(data.Result));
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });
    };
};
PotentialViewModel.prototype.init = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.isBusy(true);
    self.SelectedPotential().resetValidation();
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.potentialapiGetAllPotential));
        result.done(function (response) {
            if (response) {
                if (response.Status == true) {
                    $.each($.parseJSON(response.Result.Potential), function (key, value) {
                        self.PotentialLists.push(new Potential(value));
                    });
  
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            var oTable = $('#pagination').dataTable();
            //oTable.fnSort([[6, 'desc']]);
            $.each(response.Result.Contacts, function (k, v) {
                self.Contacts.push(new Contact(v));
            });
            $.each(response.Result.LeadSource, function (k, v) {
                self.Leadsource.push(new SelectLeadSource(v));
            });
            $.each(response.Result.Accounts, function (k, v) {
                self.Account.push(new SelectAccount(v));
            });
            $.each(response.Result.SalesStage, function (k, v) {
                self.Salesstage.push(new SelectLeadStatus(v));
            });
            $.each(response.Result.Users, function (k, v) {
                self.User.push(new SelectAssignedTo(v));
            });
            
        
            $("#AccountSelect").select2();
            self.isBusy(false);
                }
            else {
                    toastr["error"](response.Message, "Notification");
            }
        }
    });
};
PotentialViewModel.prototype.gotoPotentialPage = function () {
    var self = this;
    self.CRMUrl = urls.CRM;
    window.location.href = ko.toJS(self.CRMUrl.potentialCreate);
};
PotentialViewModel.prototype.savePotential = function () {
    var self = this;
    self.SelectedPotential().resetValidation();

    self.SelectedPotential().ExpectedCloseDate($("#ExpectedDate").val());
    if (self.SelectedPotential().modelState.isValid()) {
      
        self.busy(true);
        var jsonData = ko.toJS(self.SelectedPotential());
        var result = CRMLite.dataManager.postData(ko.toJS(self.url.potentialapiCreatePotential), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status === true) {
                bootbox.alert("Potential saved successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.potentialIndex);
                });
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });
    }
    else {
        self.SelectedPotential().modelState.errors.showAllMessages();
    }

};
PotentialViewModel.prototype.updatePotential = function () {
    var self = this;
    self.SelectedPotential().resetValidation();
    if (self.SelectedPotential().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.SelectedPotential());
        var result = CRMLite.dataManager.postData(ko.toJS(self.url.potentialapiUpdatePotential), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status === true) {
                bootbox.alert("Potential updated successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.potentialIndex);
                });
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });
    }
    else {
        self.SelectedPotential().modelState.errors.showAllMessages();
    }
};
PotentialViewModel.prototype.CreateAccount = function () {
    var self = this;
    self.SelectedAccount().resetValidation();
    if (self.SelectedAccount().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.SelectedAccount());
        var result = CRMLite.dataManager.postData(ko.toJS(self.url.accountapiCreateAccount), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status==true) {
                self.Account.push(new SelectAccount(response));
                self.SelectedAccount(new Account({}));
                bootbox.alert("Account saved successfully...!!");
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });
    }
    else {
        self.SelectedAccount().modelState.errors.showAllMessages();
    }

};
PotentialViewModel.prototype.search = function () {
    var self = this;
    var oldTable = $("#pagination").DataTable();
    oldTable
      .clear()
      .draw();
    oldTable.destroy();
    var jsonData = { SalesStageId: ko.toJS(self.SearchSalesStage), PropertyTypeId: ko.toJS(self.SearchPropertyType), LeadSourceId: ko.toJS(self.SearchLeadSource), UserId: ko.toJS(self.SearchUser) };
    var result = CRMLite.dataManager.postData(ko.toJS(self.url.potentialapiSearch),jsonData);
    result.done(function (response) {
        if (response.Status == true) {
            self.PotentialLists.removeAll();
            $.each($.parseJSON(response.Result), function (key, value) {
                self.PotentialLists.push(new Potential(value));
            });
            $("#pagination").DataTable({ responsive: true });
        }
        else {
            toastr["error"](response.Message, "Notification");
        }
    });
};
PotentialViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.DisplayTitle('Create Potential');
    self.SelectedPotential(new Potential({}));
    self.SelectedPotential().resetValidation();
    function toggleChevron(e) {
        $(e.target)
            .prev('.panel-heading')
            .find("i.indicator")
            .toggleClass('fa fa-chevron-down fa fa-chevron-up');
    }
    $('#accordion').on('hidden.bs.collapse', toggleChevron);
    $('#accordion').on('shown.bs.collapse', toggleChevron);
    $("#AccountSelect").select2();
};
PotentialViewModel.prototype.ToDo = function (item) {
    var self = this;
    self.url = urls.CRM;
    window.location.href = ko.toJS(self.url.fullCalenderIndexentityTypePotential) + ko.toJS(item.Id);
}

