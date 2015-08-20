function LeadSourceViewModel() {
    var self = this;
    self.selectedLeadSource = ko.observable(new LeadSource({}));
    self.leadSources = ko.observableArray();
    self.isBusy = ko.observable(false);
    self.isLadda = ko.observable(false);
    self.init = function () {
        self.isBusy(true);
        var result = CRMLite.dataManager.getData(CRMLite.CRM.leadSourceApiGetAll);
        result.done(function (data) {
            ko.utils.arrayForEach(data.Result, function (item) {
                self.leadSources.push(new LeadSource(item));
            })
            self.isBusy(false);
        })
    }
    self.add = function () {
        self.selectedLeadSource(new LeadSource({}));
        $('#LeadSource').modal('show');
    }
    self.saveLeadSource = function () {
        if (self.selectedLeadSource().modelState.isValid()) {
            var flag = false;
            var match = ko.utils.arrayFirst(self.leadSources(), function (item) {
                return item.Name().toLowerCase() === self.selectedLeadSource().Name().toLowerCase();  //note the ()
            });
            if (match == null) {
                flag = true;
            }
            if (flag == true) {
                var jsonresult = ko.toJS(self.selectedLeadSource);
                self.isLadda(true);
                var result = CRMLite.dataManager.postData(CRMLite.CRM.leadSourceApiCreate, jsonresult);
                result.done(function (data) {
                    self.leadSources.push(new LeadSource(data.Result));
                    $('#LeadSource').modal('hide');
                    self.isLadda(false);
                })
            }
            else {
                bootbox.alert("The entered name already been used");
            }
        }
        else {
            self.selectedLeadSource().modelState.errors.showAllMessages();
        }

    }
    self.edit = function (item) {
        $('#LeadSourceEdit').modal('show');
        self.selectedLeadSource(new LeadSource(ko.toJS(item)));
    }
    self.remove = function (item) {
        var jsonValue = { id: ko.toJS(item.Id()) };
        bootbox.confirm("Warning! Are you sure you want to remove this lead source" +item.Name(), function (result) {
            if (result) {
                var result = CRMLite.dataManager.postData(CRMLite.CRM.leadSourceApiDelete, jsonValue);
                result.done(function (data) {
                    if (data.Result == true) {
                        self.leadSources.remove(item);
                    }
                });
            }
        });
    }
    self.updateLeadSource = function () {
        if (self.selectedLeadSource().modelState.isValid()) {
            var flag = false;
            var match = ko.utils.arrayFirst(self.leadSources(), function (item) {
                return item.Name().toLowerCase() === self.selectedLeadSource().Name().toLowerCase();  //note the ()
            });
            var matchId = ko.utils.arrayFirst(self.leadSources(), function (item) {
                return item.Id() === self.selectedLeadSource().Id();  //note the ()
            });
            if ((self.selectedLeadSource().Name().toLowerCase() == matchId.Name().toLowerCase()) || match == null || (match != null && match.Id() == self.selectedLeadSource().Id())) {
                //alert(ko.toJSON(self.selectedLeadSource().Name().toLowerCase() + " " + matchId.Name().toLowerCase()) + "" + ko.toJSON(match) + "" + ko.toJSON(match.Id() + "==" + self.selectedLeadSource().Id()))
                flag = true;
            }
            if (flag == true) {
                self.isLadda(true);
                var jsonresult = ko.toJS(self.selectedLeadSource);
                var result = CRMLite.dataManager.postData(CRMLite.CRM.leadSourceApiUpdate, jsonresult);
                result.done(function (data) {
                    self.leadSources.removeAll();
                    var result = CRMLite.dataManager.getData(CRMLite.CRM.leadSourceApiGetAll);
                    result.done(function (data) {
                        ko.utils.arrayForEach(data.Result, function (item) {
                            self.leadSources.push(new LeadSource(item));
                        });
                        self.isLadda(false);
                    })
                    $('#LeadSourceEdit').modal('hide');
                })
            }
            else {
                bootbox.alert("The entered name already been used");
            }
        }
        else {
            self.selectedLeadSource().modelState.errors.showAllMessages();
        }

    }
}

function LeadSource(leadSource) {
    var self = this;
    self.modelState = ko.validatedObservable();
    self.isValid = function () {
        return self.modelState.isValid();
    };
    self.showErrors = function () {
        self.modelState.errors.showAllMessages(true);
    };
    self.Id = ko.observable(leadSource.Id || '');
    self.Name = ko.observable(leadSource.Name || '').extend({ required: { params: true, message: 'Please Enter A Name' } });
    self.modelState = ko.validatedObservable(
    {
        Name: self.Name,
    });
}

var vm = new LeadSourceViewModel();
ko.applyBindings(vm);
vm.init();