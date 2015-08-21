function AccountViewModel() {
    var self = this;
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
                    var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.accountapiDeleteAccount) + item.Id());
                    result.done(function (response) {
                        if (response.Status) {
                            bootbox.alert("Account deleted successfully.", function () {
                                CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.accountIndex));
                            });
                        }
                        else
                        {
                            CRMLite.showMesssage.error(response.Message, "Error");
                        }
                    });
                }
        });
    };
    self.getEditPage = function (item) {
        var self = this;
        CRMLite.windowManager.Redirect(CRMLite.CRM.accountEdit + item.Id());
    };
    self.accountedit = function () {
        self.isBusy(true);
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.accountapiGetAllAccount));
        result.done(function (response) {
            if (response.Status) {
                $.each(response.Result.User, function (key, value) {
                    self.Users.push(new SelectedItem(value));
                });
            } else {            
          
                CRMLite.showMesssage.error(response.Message, "Error");
            }
        });
        var accountIdValue = $("#hdnAccountId").data('value');
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.accountapiGetAccount) + accountIdValue);
        result.done(function (response) {
            if (response.Status) {
                self.SelectedAccount(new Account(response.Result));
                self.isBusy(false);
            }
            else {
                CRMLite.showMesssage.error(response.Message, "Error");
            }
        });
    };
    self.accountdetail = function (item) {
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.accountapiGetAccount) + item.Id());
        result.done(function (response) {
            self.SelectedAccount(new Account(data.Result));
        });
    };
};
AccountViewModel.prototype.init = function (userId) {
    var self = this;
    self.isBusy(true);
    self.SelectedAccount().resetValidation();
    var result = CRMLite.dataManager.getData(CRMLite.CRM.accountapiGetAllAccount);
    result.done(function (response) {     
        if (response.Status === true) {
                $.each(response.Result.Account, function (key, value) {
                    self.AccountLists.push(new Account(value));
                    self.isBusy(false);
                });
                $("#pagination").DataTable({
                    responsive: true,
                    "order": [[3, "desc"]],
                    "oLanguage": {
                        "sSearch": "Filter: "
                    }
                });
                var oTable = $('#pagination').dataTable();
                $.each(response.Result.User, function (key, value) {
                    self.Users.push(new SelectedItem(value));
                });
                if(userId)
                {
                    self.SelectedAccount().SelectedAssignedto(userId);
                }
        }
        else
        {
            CRMLite.showMesssage.error(response.Message, "Error");
        }
        self.isBusy(false);
    });

};
AccountViewModel.prototype.saveAccount = function () {
    var self = this;
    self.SelectedAccount().resetValidation();
    if (self.SelectedAccount().modelState.isValid()) {
    self.busy(true);
    var jsonData = ko.toJS(self.SelectedAccount());
    var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.accountapiCreateAccount), jsonData);
        result.done(function (response) {
            self.busy(false);
    
            if (response.Status) {
                bootbox.alert("Account saved successfully.", function () {
                    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.accountIndex));
                });
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
AccountViewModel.prototype.updateAccount = function () {
    var self = this;
    self.busy(true);
    var jsonData = ko.toJS(self.SelectedAccount());
    var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.accountapiUpdateAccount), jsonData);
    result.done(function (response) {
        self.busy(false);
        if (response.Status === true) {
            bootbox.alert("Account updated successfully.", function () {
                CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.accountIndex));
            });
        }
        else {
            CRMLite.showMesssage.error(response.Message, "Error");
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
    var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.accountapiSearch) ,jsonData);
    result.done(function (response) {     
        self.AccountLists.removeAll();
        $.each(response.Result, function (key, value) {
            self.AccountLists.push(new Account(value));
        });
        $("#pagination").DataTable({
            responsive: true,
            "order": [[3, "desc"]],
            "oLanguage": {
                "sSearch": "Filter: "
            }
        });
    });
    self.isBusy(false);
};
AccountViewModel.prototype.gotoAccountPage = function () {
    var self = this;
    self.DisplayTitle('Create Account');
    self.SelectedAccount(new Account({}));
    self.SelectedAccount().resetValidation();
    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.accountCreate));
}; 
AccountViewModel.prototype.clear = function () {
    var self = this;
    self.DisplayTitle('Create Account');
    self.SelectedAccount(new Account({}));
    self.SelectedAccount().resetValidation();
};
AccountViewModel.prototype.ToDo = function (item) {
    var self = this;
    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.fullCalenderIndexEntityTypeAccountid) + ko.toJS(item.Id));
};