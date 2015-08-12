﻿function AccountViewModel() {
    var self = this;
    self.CRMUrl = urls.CRM;
    self.busy = ko.observable();
    self.DisplayTitle = ko.observable();
    self.AccountLists = ko.observableArray();
    self.Users = ko.observableArray();
    self.SearchAssignedTo = ko.observable();
    self.isBusy = ko.observable(false);
    self.SelectedAccount = ko.observable(new Account({}));
    self.accountdelete = function (item) {
            bootbox.confirm("Do you want to delete the Account"+" '" + item.AccountName() +"' "+ " ?", function (result) {
                if (result) {
                    var result = CRMLite.dataManager.postData(ko.toJS(self.CRMUrl.accountapiDeleteAccount) + item.Id());
                    result.done(function (response) {
                        if (response.Status) {
                            bootbox.alert("Account deleted successfully..!!", function () {
                                window.location.href = ko.toJS(self.CRMUrl.accountIndex);
                            });
                        }
                        else
                        {
                            toastr["error"](response.Message, "Notification");
                        }
                    });
                }
        });
    };
    self.getEditPage = function (item) {
        var self = this;
        self.CRMUrl = urls.CRM;
        window.location.href = ko.toJS(self.CRMUrl.accountEdit) + item.Id();
    };
    self.accountedit = function () {
        self.isBusy(true);
        var result = CRMLite.dataManager.getData(ko.toJS(self.CRMUrl.accountapiGetAllAccount));
        result.done(function (response) {
            if (response.Status) {
                $.each(response.Result.User, function (key, value) {
                    self.Users.push(new SelectAssignedTo(value));
                });
            } else {            
          
                toastr["error"](response.Message, "Notification");
            }
        });
        var accountIdValue = $("#hdnAccountId").data('value');
        var result = CRMLite.dataManager.getData(ko.toJS(self.CRMUrl.accountapiGetAccount) + accountIdValue);
        result.done(function (response) {
            if (response.Status) {
                self.SelectedAccount(new Account(response.Result));
                self.isBusy(false);
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });
    };
    self.accountdetail = function (item) {
        var result = CRMLite.dataManager.getData(ko.toJS(self.CRMUrl.accountapiGetAccount) + item.Id());
        result.done(function (response) {
            self.SelectedAccount(new Account(data.Result));
        });
    };
};
AccountViewModel.prototype.init = function () {
    var self = this;
    self.isBusy(true);
    self.SelectedAccount().resetValidation();
    var result = CRMLite.dataManager.getData(ko.toJS(self.CRMUrl.accountapiGetAllAccount));
    result.done(function (response) {     
        //if (response.Status === false) {
        //    if (response.Code === 401) {
        //        window.location.href = ko.toJS(self.CRMUrl.errorNotAuthorized);
        //    }
        //    else {
        //        bootbox.alert(response);
        //    }
        //} else {
        if (response.Status === true) {
                $.each(response.Result.Account, function (key, value) {
                    //alert(ko.toJSON(v));
                    self.AccountLists.push(new Account(value));
                    self.isBusy(false);
                });
                $("#pagination").DataTable({
                    responsive: true,
                    "order": [[3, "desc"]]
                });
                var oTable = $('#pagination').dataTable();
            // oTable.fnSort([[6, 'desc']]);
                $.each(response.Result.User, function (key, value) {
                    self.Users.push(new SelectAssignedTo(value));
                });
        }
        else
        {
            toastr["error"](response.Message, "Notification");
        }
           
        //}
        self.isBusy(false);
    });

};
AccountViewModel.prototype.saveAccount = function () {
    var self = this;
    self.isBusy(true);
    self.SelectedAccount().resetValidation();
    if (self.SelectedAccount().modelState.isValid()) {
    self.busy(true);
    var jsonData = ko.toJS(self.SelectedAccount());
    var result = CRMLite.dataManager.postData(ko.toJS(self.CRMUrl.accountapiCreateAccount), jsonData);
        result.done(function (response) {
                self.busy(false);
            if (response.Status) {
                bootbox.alert("Account saved successfully...!!", function () {
                    window.location.href = ko.toJS(self.CRMUrl.accountIndex);
                });
            }
            else {
                toastr["error"](response.Message, "Notification");
            }
        });
    }
    else {
        self.SelectedAccount().modelState.errors.showAllMessages();
    }
    self.isBusy(false);
};
AccountViewModel.prototype.updateAccount = function () {
    var self = this;
    self.busy(true);
    var jsonData = ko.toJS(self.SelectedAccount());
    var result = CRMLite.dataManager.postData(ko.toJS(self.CRMUrl.accountapiUpdateAccount), jsonData);
    result.done(function (response) {
        self.busy(false);
        if (response.Status === true) {
            bootbox.alert("Account updated successfully...!!", function () {
                window.location.href = ko.toJS(self.CRMUrl.accountIndex);
            });
        }
        else {
            toastr["error"](response.Message, "Notification");
        }

        self.isBusy(false);
    });
};
AccountViewModel.prototype.search = function () {
    var self = this;
    self.isBusy(true);
    var oldTable = $("#pagination").DataTable();
    oldTable
      .clear()
      .draw();
    oldTable.destroy();
    var jsonData = {
        AgentId: ko.toJS(self.SearchAssignedTo)
    };
    var result = CRMLite.dataManager.postData(ko.toJS(self.CRMUrl.accountapiSearch) ,jsonData);
    result.done(function (response) {     
        self.AccountLists.removeAll();
        $.each(response.Result, function (key, value) {
            self.AccountLists.push(new Account(value));
        });

        $("#pagination").DataTable({ responsive: true });
    });
    self.isBusy(false);
};
AccountViewModel.prototype.gotoAccountPage = function () {
    var self = this;
    self.DisplayTitle('Create Account');
    self.SelectedAccount(new Account({}));
    self.SelectedAccount().resetValidation();
    window.location.href = ko.toJS(self.CRMUrl.accountCreate);
}; 
AccountViewModel.prototype.clear = function () {
    var self = this;
    self.DisplayTitle('Create Account');
    self.SelectedAccount(new Account({}));
    self.SelectedAccount().resetValidation();
};
AccountViewModel.prototype.ToDo = function (item) {
    var self = this;
    self.CRMUrl = urls.CRM;
    window.location.href = ko.toJS(self.CRMUrl.fullCalenderIndexEntityTypeAccountid) + ko.toJS(item.Id);
};