function LeadViewModel() {
    var self = this;
    self.DisplayTitle = ko.observable();
    self.busy = ko.observable();
    self.LeadLists = ko.observableArray();
    self.Assignto = ko.observableArray();
    self.salesStage = ko.observableArray();
    self.TempLeadLists = ko.observableArray();
    self.SelectedAssignedTo = ko.observable();
    self.SelectedLeadStatus = ko.observable();
    self.SelectedLeadSource = ko.observable();
    self.SelectedSalesStage = ko.observable();
    self.SelectedSearchAssignedTo = ko.observable();
    self.SelectedSearchLeadStatus = ko.observable();
    self.SelectedSearchLeadSource = ko.observable();
    self.Leadsource = ko.observableArray();
    self.Leadstatus = ko.observableArray();
    self.salesStage = ko.observableArray();
    self.selectedLead = ko.observable(new Lead({}));
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.isBusy = ko.observable(false);
    self.selectedConvertLead = ko.observable(new SelectConvertLead({}));

    self.leaddelete = function (item) {
        bootbox.confirm("Do you want to delete the Lead" + " '" + item.Name() + "' " + " ?", function (result) {
            if (result) {
                var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.leadapiDeleteLead) + item.Id());
                result.done(function (response) {
                    if (response.Status == true) {
                        bootbox.alert("Lead deleted successfully.", function () {
                            CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.leadIndex));
                        });
                    }
                    else {
                        toastr["error"](response.Message, "Error");
                    }
                });
            }
        });
    };
    self.gotoLeaddetails = function (item) {
        CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.gotoLeaddetails) + item.Id());
    };
    self.leaddetail = function () {
        var id = $("#hdnLeadId").val(); self.isBusy(true);
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.leadapiGetLead) + id);
        result.done(function (data) {
            if (data.Status == true) {
                self.selectedLead(new Lead(data.Result));
                self.isBusy(false);
            }
            else {
                toastr["error"](data.Message, "Notification");
            }
        });
    };
    self.leadedit = function (item) {
        self.DisplayTitle('Edit Lead');
        self.isBusy(true);
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.leadapiGetLead) + id);

        result.done(function (data) {
            if (data.Status == true) {
                self.selectedLead(new Lead(data.Result));
                self.isBusy(false);
            }
            else {
                toastr["error"](data.Message, "Notification");
            }
        });

    };
    self.convertLead = function (item) {
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.leadApiGetConvertLead) + item.Id());
        result.done(function (response) {
            if (response.Status == true) {
                self.selectedConvertLead(new SelectConvertLead(response.Result));
            }
            else {
                CRMLite.showMesssage.error(response.Message, "Error");
            }
        });

    };
    self.initDate = function () {
        var date = new Date();
        date.setDate(date.getDate());
        $('#RecievedOn').datepicker({
            format: 'dd/mm/yyyy',
            clearBtn: true,
            todayHighlight: date,
            autoclose: true,
        });
    }
    self.getLead = function () {
        var self = this;
        var id = $("#hdnLeadId").val();
        self.isBusy(true);
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.leadapiGetLead) + id);
        result.done(function (data) {
            if (data.Status == true) {
                self.selectedLead(new Lead(data.Result));
                self.selectedLead().SelectedLeadSource(self.selectedLead().LeadSourceUserId);
                self.isBusy(false);
                var date = new Date();
                date.setDate(date.getDate());
                $('#RecievedOn').datepicker({
                    format: 'dd/mm/yyyy',
                    clearBtn: true,
                    todayHighlight: date,
                    autoclose: true,
                });
            }
            else {
                toastr["error"](data.Message, "Notification");
            }
        });
    }
    self.update = function (item) {
        CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.leadUpdate) + item.Id());
    };
    self.gotoCreatePage = function () {
        var self = this;
        self.DisplayTitle('Create Lead');
        CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.gotoLeadCreate));
    }
    self.convert = function (item) {
        CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.convertLead) + item.Id());
    };
    self.convertSelectedLead = function () {
        var id = $("#hdnLeadId").val();
        self.isBusy(true);
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.leadApiGetConvertLead) + id);
        result.done(function (response) {
            if (response.Status == true) {
                self.selectedConvertLead(new SelectConvertLead(response.Result));
                self.isBusy(false);
                $('#datetimepicker3').datetimepicker().on('changeDate', function (e) {
                    $(this).datetimepicker('hide');
                });
            }
            else {
                CRMLite.showMesssage.error(response.Message, "Error");
            }
        });

    };
};
LeadViewModel.prototype.init = function (userId) {
    var self = this;
    self.isBusy(true);
    var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.leadapiGetData));
    result.done(function (data) {
        if (data.Status == true) {
            self.selectedLead(new Lead({}));
            $.each(data.Result.User, function (k, v) {
                self.Assignto.push(new SelectedItem(v));
            });
            $.each(data.Result.LeadStatus, function (k, v) {
                self.Leadstatus.push(new SelectedItem(v));
            });
            $.each(data.Result.LeadSource, function (k, v) {
                self.Leadsource.push(new SelectedItem(v));
            });
            $.each(data.Result.SalesStage, function (k, v) {
                self.salesStage.push(new SelectedItem(v));
            });
            var id = $("#hdnLeadId").val();
            if (id) {
                self.getLead();
            }
            if (userId) {
                self.selectedLead().SelectedAssignedTo(userId);
            }
            self.isBusy(false);
        }

        else {
            toastr["error"](data.Message, "Notification");
        }
        var date = new Date();
        date.setDate(date.getDate());
        $('#RecievedOn').datepicker({
            format: 'dd/mm/yyyy',
            clearBtn: true,
            todayHighlight: date,
            autoclose: true,
        });
    });


};
LeadViewModel.prototype.search = function () {
    var self = this;
    self.isBusy(true);
    var oldTable = $("#pagination").DataTable();
    oldTable
      .clear()
      .draw();
    oldTable.destroy();
    var jsonData = {
        LeadStatusId: ko.toJS(self.SelectedSearchLeadStatus),
        LeadSourceId: ko.toJS(self.SelectedSearchLeadSource), UserId: ko.toJS(self.SelectedSearchAssignedTo)
    };
    var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.leadapiSearch), jsonData);
    result.done(function (response) {
        if (response.Status == true) {
            self.LeadLists.removeAll();
            self.TempLeadLists.removeAll();
            $.each(response.Result, function (key, value) {
                self.TempLeadLists.push(new Lead(value));
            });
            ko.utils.arrayPushAll(self.LeadLists, self.TempLeadLists());
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]],
                "oLanguage": {
                    "sSearch": "Filter: "
                }
            });
            self.isBusy(false);
        }
        else {
            CRMLite.showMesssage.error(response.Message, "Error");
        }
    });
};
LeadViewModel.prototype.LeadListing = function () {
    var self = this;
    self.isBusy(true);
    var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.leadapiGetData));
    result.done(function (data) {
        if (data.Status == true) {
            self.selectedLead(new Lead({}));
            $.each(data.Result.User, function (k, v) {
                self.Assignto.push(new SelectedItem(v));
            });
            $.each(data.Result.LeadStatus, function (k, v) {
                self.Leadstatus.push(new SelectedItem(v));
            });
            $.each(data.Result.LeadSource, function (k, v) {
                self.Leadsource.push(new SelectedItem(v));
            });
            $.each(data.Result.SalesStage, function (k, v) {
                self.salesStage.push(new SelectedItem(v));
            });
        }
        else {
            toastr["error"](data.Message, "Notification");
        }
    });
    var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.leadapiIndex));
    result.done(function (response) {
        if (response.Status == true) {
            $.each($.parseJSON(response.Result), function (key, value) {
                self.TempLeadLists.push(new Lead(value));
            });
            ko.utils.arrayPushAll(self.LeadLists, self.TempLeadLists());
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]],
                "oLanguage": {
                    "sSearch": "Filter: "
                }
            });
            var oTable = $('#pagination').dataTable();
            // oTable.fnSort([[6, 'desc']]);        
            self.isBusy(false);
        }
        else {
            CRMLite.showMesssage.error(response.Message, "Error");
        }
    });

};
LeadViewModel.prototype.saveLead = function () {
    var self = this;
    self.isBusy(true);
    if (self.selectedLead().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.selectedLead());
        var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.leadapiCreate), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status === true) {
                bootbox.alert("Lead saved successfully.", function () {
                    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.leadIndex));
                });
            }
            else {

                CRMLite.showMesssage.error(response.Message, "Error");
            }
        });
    }
    else {
        self.selectedLead().modelState.errors.showAllMessages();
    }
    self.isBusy(false);
};
LeadViewModel.prototype.updateLead = function () {
    var self = this;
    if (self.selectedLead().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.selectedLead());
        var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.leadapiUpdate), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status === true) {
                bootbox.alert("Lead updated successfully.", function () {
                    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.leadIndex));
                });
            }
            else {

                CRMLite.showMesssage.error(response.Message, "Error");
            }
        });
    }
    else {
        self.selectedLead().modelState.errors.showAllMessages();
    }
};
LeadViewModel.prototype.convertingLead = function (item) {
    var self = this;
    // alert($('#ExpectedDate').val());
    self.busy(true);
    self.selectedConvertLead().ExpectedDate($('#datePickerPoint').val());
    var jsonData = ko.toJS(self.selectedConvertLead());
    var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.leadapiConvertLead), ko.toJS(jsonData));
    result.done(function (response) {
        self.busy(false);
        if (response.Status === true) {
            bootbox.alert("Lead converted successfully.", function () {
                CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.leadIndex));
            });
        }
        else {
            CRMLite.showMesssage.error(response.Message, "Error");
        }
    });
};
LeadViewModel.prototype.ToDo = function (item) {
    var self = this;
    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.fullCalenderIndexentityTypeLeadid) + ko.toJS(item.Id));
};
LeadViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.DisplayTitle('Create Lead');
    self.selectedLead(new Lead({}));
    self.selectedLead().resetValidation();
};