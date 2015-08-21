function PotentialViewModel() {
    var self = this;
    var editedState = '';
    var editedCity = '';
    self.DisplayTitle = ko.observable();
    self.busy = ko.observable();
    self.PotentialLists = ko.observableArray();
    self.TempPotentialLists = ko.observableArray();
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
    self.selectedCountry = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    self.selectedState = ko.observable().extend({ required: { params: true, message: "Please Select State" } });
    self.SelectedPotential = ko.observable(new Potential({}));
    self.SelectedAccount = ko.observable(new Account({}));
    self.potentialdelete = function (item) {
        bootbox.confirm("Do you want to delete the Potential" + " '" + item.PotentialName() + "' " + " ?", function (result) {
            if (result) {
                var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.potentialapiDeletePotential) + item.Id());
                result.done(function (response) {
                    if (response) {
                        if (response.Status == true) {
                            bootbox.alert("Deleted Successfully.", function () {
                                CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.potentialIndex));
                            });
                        }
                        else {
                            CRMLite.showMesssage.error(response.Message, "Error");
                        }
                    }
                    else {
                        bootbox.alert("Error Please Try Again Later .");
                    }
                });
            }
        });
    };
 
    self.getEditPage = function (item) {
        var self = this;
        CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.potentialEdit) + item.Id());
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
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.potentialapiGetPotential) + potentialIdValue);
        result.done(function (data) {
            if (data.Status == true) {
                self.SelectedPotential(new Potential(data.Result));
                    var date = new Date();
                    date.setDate(date.getDate());
                    $('#ExpectedDate').datepicker({
                        format: 'dd/mm/yyyy',
                        clearBtn: true,
                        todayHighlight: date,
                        autoclose: true,
                    });
            }
            else {
                CRMLite.showMesssage.error(response.Message, "Error");
            }
        });

    };
    self.gotoPotentialdetails = function (item) {

        CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.gotoPotentialdetails) + item.Id());
    };
    self.potentialdetail = function () {
        var id = $("#hdnPotentialId").val();
        var result = CRMLite.dataManager.getData((CRMLite.CRM.potentialapiDetails) + id);
        result.done(function (data) {
            if (data.Status == true) {
                self.SelectedPotential(new Potential(data.Result));
            }
            else {
                CRMLite.showMesssage.error(data.Message, "Error");
            }
        });
    };
};
PotentialViewModel.prototype.init = function (userId) {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.isBusy(true);
    self.SelectedPotential().resetValidation();
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.potentialapiGetAllPotential));
        result.done(function (response) {
            if (response) {
                if (response.Status == true) {
                    $.each($.parseJSON(response.Result.Potential), function (key, value) {
                        self.TempPotentialLists.push(new Potential(value));
                    });
                    ko.utils.arrayPushAll(self.PotentialLists, self.TempPotentialLists());
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]],
                "oLanguage": {
                    "sSearch": "Filter: "
                }
            });
            var oTable = $('#pagination').dataTable();
            //oTable.fnSort([[6, 'desc']]);
            $.each(response.Result.Contacts, function (k, v) {
                self.Contacts.push(new SelectAccount(v));
            });
            $.each(response.Result.LeadSource, function (k, v) {
                self.Leadsource.push(new SelectedItem(v));
            });
            $.each($.parseJSON(response.Result.Accounts), function (k, v) {
                self.Account.push(new SelectAccount(v));
            });
            $.each(response.Result.SalesStage, function (k, v) {
                self.Salesstage.push(new SelectedItem(v));
            });
            $.each($.parseJSON(response.Result.Users), function (k, v) {
                self.User.push(new SelectedItem(v));
            });
            if (userId) {
                self.SelectedPotential().selectedAssignedTo(userId);
            }
            self.isBusy(false);
                }
            else {
                    CRMLite.showMesssage.error(response.Message, "Error");
            }
        }
    });
};
PotentialViewModel.prototype.gotoPotentialPage = function () {
    var self = this;
    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.potentialCreate));
};
PotentialViewModel.prototype.savePotential = function () {
    var self = this;
    self.SelectedPotential().resetValidation();

    self.SelectedPotential().ExpectedCloseDate($("#ExpectedDate").val());
    if (self.SelectedPotential().modelState.isValid()) {
      
        self.busy(true);
        var jsonData = ko.toJS(self.SelectedPotential());
        var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.potentialapiCreatePotential), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status === true) {
                bootbox.alert("Potential saved successfully.", function () {
                    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.potentialIndex));
                });
            }
            else {
                CRMLite.showMesssage.error(response.Message, "Error");
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
        var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.potentialapiUpdatePotential), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status === true) {
                bootbox.alert("Potential updated successfully.", function () {
                    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.potentialIndex));
                });
            }
            else {
                CRMLite.showMesssage.error(response.Message, "Error");
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
        var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.accountapiCreateAccount), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status == true) {
                $('#createAccount').modal('hide');
                self.Account.push(new SelectAccount(response.Result));
                self.SelectedAccount(new Account({}));
                CRMLite.showMesssage.info("Account saved successfully.", "Info");
            }
            else {
                CRMLite.showMesssage.error(response.Message, "Error");
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
    var jsonData = { SalesStageId: ko.toJS(self.SearchSalesStage), PropertyTypeId: ko.toJS(self.SearchPropertyType), LeadSourceId: ko.toJS(self.SearchLeadSource), AssignedToUserId: ko.toJS(self.SearchUser) };
    var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.potentialapiSearch),jsonData);
    result.done(function (response) {
        if (response.Status == true) {
            self.PotentialLists.removeAll();
            self.TempPotentialLists.removeAll();
            $.each($.parseJSON(response.Result), function (key, value) {
                self.TempPotentialLists.push(new Potential(value));
            });
            ko.utils.arrayPushAll(self.PotentialLists, self.TempPotentialLists());
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]],
                "oLanguage": {
                    "sSearch": "Filter: "
                }
            });
        }
        else {
            CRMLite.showMesssage.error(response.Message, "Error");
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
    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.fullCalenderIndexentityTypePotential) + ko.toJS(item.Id));
}

