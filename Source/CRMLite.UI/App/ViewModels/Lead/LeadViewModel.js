function LeadViewModel() {
    var self = this;
    self.url = urls.CRM;
    self.DisplayTitle = ko.observable();
    self.busy = ko.observable();
    self.LeadLists = ko.observableArray();
    self.Assignto = ko.observableArray();
    self.salesStage = ko.observableArray();
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
                var result = CRMLite.dataManager.postData(ko.toJS(self.url.leadapiDeleteLead) + item.Id());
                result.done(function (response) {
                    if (response.Status == true) {
                        bootbox.alert("Lead deleted successfully..!!", function () {
                            window.location.href = ko.toJS(self.url.leadIndex);
                        });
                    }
                    else {
                        toastr["error"](response.Message, "Notification");
                    }
                });
            }
        });
    };
    self.gotoLeaddetails = function (item) {
        window.location.href = ko.toJS(self.url.gotoLeaddetails) + item.Id();
    };
    self.leaddetail = function () {
        var id = $("#hdnLeadId").val(); self.isBusy(true);
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.leadapiGetLead) + id);
        result.done(function (data) {
            if (data.Status == true)
            {
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
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.leadapiGetLead) + id);
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
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.leadApiGetConvertLead) + item.Id());
        result.done(function (response) {
            if (response.Status == true) {
                self.selectedConvertLead(new SelectConvertLead(response.Result));
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });

    };
    self.getLead = function () {
        var self = this;
        var id = $("#hdnLeadId").val();
        self.isBusy(true);
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.leadapiGetLead) + id);
        result.done(function (data) {
            if (data.Status == true) {
                self.selectedLead(new Lead(data.Result));
                self.isBusy(false);
            }
            else {
                toastr["error"](data.Message, "Notification");
            }
        });
    }
    self.update = function (item) {
        window.location.href = ko.toJS(self.url.leadUpdate) + item.Id();
    };
    self.gotoCreatePage = function () {
        var self = this;
        self.DisplayTitle('Create Lead');
        window.location.href = ko.toJS(self.url.gotoLeadCreate);
    }
    self.convert = function (item) {
        window.location.href = ko.toJS(self.url.convertLead) + item.Id();
    };
    self.convertSelectedLead = function () {
        var id = $("#hdnLeadId").val();
        self.isBusy(true);
        var result = CRMLite.dataManager.getData(ko.toJS(self.url.leadApiGetConvertLead) + id);
        result.done(function (response) {
            if (response.Status == true) {
                self.selectedConvertLead(new SelectConvertLead(response.Result));
                self.isBusy(false);
                $('#datetimepicker3').datetimepicker().on('changeDate', function (e) {
                    $(this).datetimepicker('hide');
                });
                //$('#datetimepicker3').datetimepicker();
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });

    };
};
LeadViewModel.prototype.init = function () {
    var self = this;
    self.isBusy(true);
    var result = CRMLite.dataManager.getData(ko.toJS(self.url.leadapiGetData));
    result.done(function (data) {
        if (data.Status == true) {
            self.selectedLead(new Lead({}));
            $.each(data.Result.User, function (k, v) {
                self.Assignto.push(new SelectAssignedTo(v));
            });
            $.each(data.Result.LeadStatus, function (k, v) {
                self.Leadstatus.push(new SelectLeadStatus(v));
            });
            $.each(data.Result.LeadSource, function (k, v) {
                self.Leadsource.push(new SelectLeadSource(v));
            });
            $.each(data.Result.SalesStage, function (k, v) {
                self.salesStage.push(new SelectSalesStage(v));
            });
            self.isBusy(false);
        }
    
    else {
            toastr["error"](data.Message, "Notification");
        }
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
    var result = CRMLite.dataManager.postData(ko.toJS(self.url.leadapiSearch), jsonData);
    result.done(function (response) {
        if (response.Status == true) {
            self.LeadLists.removeAll();
            $.each(response.Result, function (key, value) {
                self.LeadLists.push(new Lead(value));
            });
            $("#pagination").DataTable({ responsive: true });
            self.isBusy(false);
        }
        else {
            toastr["error"](response.Message, "Notification");
        }
    });
};
LeadViewModel.prototype.LeadListing = function () {
    var self = this;
    self.isBusy(true);
    var result = CRMLite.dataManager.getData(ko.toJS(self.url.leadapiGetData));
    result.done(function (data) {
        if (data.Status == true) {
        self.selectedLead(new Lead({}));
        $.each(data.Result.User, function (k, v) {
            self.Assignto.push(new SelectAssignedTo(v));
        });
        $.each(data.Result.LeadStatus, function (k, v) {
            self.Leadstatus.push(new SelectLeadStatus(v));
        });
        $.each(data.Result.LeadSource, function (k, v) {
            self.Leadsource.push(new SelectLeadSource(v));
        });
        $.each(data.Result.SalesStage, function (k, v) {
            self.salesStage.push(new SelectSalesStage(v));
        });
        }
        else {
            toastr["error"](data.Message, "Notification");
        }
    });
    var result = CRMLite.dataManager.getData(ko.toJS(self.url.leadapiIndex));
    result.done(function (response) {
        if (response.Status == true) {
            $.each($.parseJSON(response.Result), function (key, value) {
                self.LeadLists.push(new Lead(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            var oTable = $('#pagination').dataTable();
            // oTable.fnSort([[6, 'desc']]);        
            self.isBusy(false);
        }
        else {
            toastr["error"](response.Message, "Notification");
        }
    });

};
LeadViewModel.prototype.saveLead = function () {
    var self = this;
    self.isBusy(true);
    if (self.selectedLead().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.selectedLead());
        var result = CRMLite.dataManager.postData(ko.toJS(self.url.leadapiCreate), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status === true) {
                bootbox.alert("Lead saved successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.leadIndex);
                });
            }
            else {

                toastr["error"](response.Message, "Notification");
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
        var result = CRMLite.dataManager.postData(ko.toJS(self.url.leadapiUpdate), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status === true) {
                bootbox.alert("Lead updated successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.leadIndex);
                });
            }
            else {

                toastr["error"](response.Message, "Notification");
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
    var result = CRMLite.dataManager.postData(ko.toJS(self.url.leadapiConvertLead), ko.toJS(jsonData));
    result.done(function (response) {
        self.busy(false);
        if (response.Status === true) {
            bootbox.alert("Lead converted successfully...!!", function () {
                window.location.href = ko.toJS(self.url.leadIndex);
            });
        }
        else {
            toastr["error"](response.Message, "Notification");
        }
    });
};
LeadViewModel.prototype.ToDo = function (item) {
    var self = this;
    self.url = urls.CRM;
    window.location.href = ko.toJS(self.url.fullCalenderIndexentityTypeLeadid) + ko.toJS(item.Id);
};
LeadViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.DisplayTitle('Create Lead');
    self.selectedLead(new Lead({}));
    self.selectedLead().resetValidation();
};