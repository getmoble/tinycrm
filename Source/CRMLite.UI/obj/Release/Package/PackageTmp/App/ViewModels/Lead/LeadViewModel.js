﻿function LeadViewModel() {
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
        bootbox.confirm("Do you want to delete this Lead?", function (result) {
            if (result) {
                $.get(ko.toJS(self.url.leadapiDeleteLead) + item.Id());
                bootbox.alert("Deleted Successfully..!!", function () {
                    window.location.href = ko.toJS(self.url.leadIndex);
                });
            }
        });
    };
    self.gotoLeaddetails = function (item) {
        window.location.href = ko.toJS(self.url.gotoLeaddetails) + item.Id();
    };
    self.leaddetail = function () {
        var id = $("#hdnLeadId").val();
        $.get(ko.toJS(self.url.leadapiGetLead) + id, function (data) {
            self.selectedLead(new Lead(data));
        });
    };
    self.leadedit = function (item) {
        self.DisplayTitle('Edit Lead');
        self.isCreate(false);
        self.isUpdate(true);
        $.get(ko.toJS(self.url.leadapiGetLead) + item.Id(), function (data) {
            self.selectedLead(new Lead(data));
        });
    };
    self.convertLead = function (item) {
        $('#ConvertLead').modal('show');
        $('.datePickerPoint').datepicker({
            autoclose: false
        });
        $('#datePickerPoint').datepicker();
        $.get(ko.toJS(self.url.leadApiGetConvertLead) + item.Id(), function (response) {
            self.selectedConvertLead(new SelectConvertLead(response));
        });

    };
    self.getLead=function()
    {
        var self = this;
        var id = $("#hdnLeadId").val();
        $.get(ko.toJS(self.url.leadapiGetLead) + id, function (data) {
            self.selectedLead(new Lead(data));
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
        window.location.href=ko.toJS(self.url.convertLead) + item.Id();
    };
    self.convertSelectedLead = function () {
        var id = $("#hdnLeadId").val();
        //$('.datePickerPoint').datepicker({
        //    autoclose: false
        //});
        
        $.get(ko.toJS(self.url.leadApiGetConvertLead) + id, function (response) {
            self.selectedConvertLead(new SelectConvertLead(response));
        });

    };
};
LeadViewModel.prototype.init = function () {
    var self = this;
    self.isBusy(true);
    $.get(ko.toJS(self.url.leadapiGetData), function (data) {
        self.selectedLead(new Lead({}));
        $.each(data.Agent, function (k, v) {
            self.Assignto.push(new SelectAssignedTo(v));
        });
        $.each(data.LeadStatus, function (k, v) {
            self.Leadstatus.push(new SelectLeadStatus(v));
        });
        $.each(data.LeadSource, function (k, v) {
            self.Leadsource.push(new SelectLeadSource(v));
        });
        $.each(data.SalesStage, function (k, v) {
            self.salesStage.push(new SelectSalesStage(v));
        });
        self.isBusy(false);
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
        LeadSourceId: ko.toJS(self.SelectedSearchLeadSource), AgentId: ko.toJS(self.SelectedSearchAssignedTo)
    };

    $.post(ko.toJS(self.url.leadapiSearch), jsonData, function (response) {
        self.LeadLists.removeAll();
        $.each($.parseJSON(response), function (key, value) {
            self.LeadLists.push(new Lead(value));
        });
        $("#pagination").DataTable({ responsive: true });
        self.isBusy(false);
    });
};
LeadViewModel.prototype.LeadListing = function () {
    var self = this;
    self.isBusy(true);
    $.get(ko.toJS(self.url.leadapiGetData), function (data) {
        self.selectedLead(new Lead({}));
        $.each(data.Agent, function (k, v) {
            self.Assignto.push(new SelectAssignedTo(v));
        });
        $.each(data.LeadStatus, function (k, v) {
            self.Leadstatus.push(new SelectLeadStatus(v));
        });
        $.each(data.LeadSource, function (k, v) {
            self.Leadsource.push(new SelectLeadSource(v));
        });
        $.each(data.SalesStage, function (k, v) {
            self.salesStage.push(new SelectSalesStage(v));
        });
    });
    $.getJSON(ko.toJS(self.url.leadapiIndex), function (response) {
        if (response.Status === false) {
            if (response.Code === 401) {
                window.location.href = errorNotAuthorized;
            }
            else {
                bootbox.alert(response);
            }
        } else {
            $.each($.parseJSON(response), function (key, value) {
                self.LeadLists.push(new Lead(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            var oTable = $('#pagination').dataTable();
            // oTable.fnSort([[6, 'desc']]);
        }
        self.isBusy(false);
    });

};
LeadViewModel.prototype.saveLead = function () {
    var self = this;
    self.isBusy(true);
    if (self.selectedLead().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.selectedLead());
        //alert(JSON.stringify(jsonData));
        var result = $.post(ko.toJS(self.url.leadapiCreate), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                bootbox.alert("Saved successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.leadIndex);
                });
            }
            else {

                bootbox.alert("Error occured");
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
        var result = $.post(ko.toJS(self.url.leadapiUpdate), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                bootbox.alert("Updated successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.leadIndex);
                });
            }
            else {

                bootbox.alert("Error occured");

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
    self.selectedConvertLead().ExpectedDate($('#ExpectedDate').val());
    var jsonData = ko.toJS(self.selectedConvertLead());
    $.post(ko.toJS(self.url.leadapiConvertLead), ko.toJS(jsonData), function (response) {
        self.busy(false);
        if (response === true) {
            bootbox.alert("Converted successfully...!!", function () {
                window.location.href = ko.toJS(self.url.leadIndex);
            });
        }
        else {
            bootbox.alert(response);
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