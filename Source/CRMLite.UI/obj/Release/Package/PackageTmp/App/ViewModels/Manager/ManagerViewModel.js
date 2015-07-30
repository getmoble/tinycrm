function ManagerViewModel() {
    var that = this;
    that.url = urls.ERP;
    that.busy = ko.observable();
    that.saveAndCopyBusy = ko.observable();
    that.ManagerData = ko.observable(new Manager({}));
    that.ManagerLists = ko.observableArray();
    that.Managers = ko.observableArray();
    that.selectedCountry = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    that.selectedState = ko.observable().extend({ required: { params: true, message: "Please Select State" } });
    var editedState = '';
    var editedCity = '';
    that.initialStage = ko.observable(false);
    that.initialCityStage = ko.observable(false);
    that.countries = ko.observableArray();
    that.states = ko.observableArray();
    that.cities = ko.observableArray();
    that.Roles = ko.observableArray();
    that.query = ko.observable('');
    that.isBusy = ko.observable(false);
    that.locationModelState = ko.validatedObservable();
    that.locationIsValid = function () {
        return that.modelState.isValid();
    };
    that.locationShowErrors = function () {

        that.locationModelState.errors.showAllMessages(true);
    };
    that.locationModelState = ko.validatedObservable(
  {
      selectedCountry: that.selectedCountry,
      selectedState: that.selectedState
  });
    that.resetValidation = function () {

        that.selectedCountry.isModified(false);
        that.selectedState.isModified(false);

    };
    that.ManagerLists = ko.computed(function () {
        var search = that.query().toLowerCase();
        if (!search) {
            return that.Managers();
        }
        else {
            return ko.utils.arrayFilter(that.Managers(), function (item) {
                return (item.FirstName().toLowerCase().indexOf(search) >= 0 || item.Email().toLowerCase().indexOf(search) >= 0
                    || item.Role().toLowerCase().indexOf(search) >= 0);
            });
        }

    });
    that.init = function () {
        that.ManagerData().resetValidation();
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.managerManageInit));
        result.done(function (data) {            
            $.each(data.Countries, function (k, v) {
                that.countries.push(v);
            });
            $.each(data.ManagerRoles, function (k, v) {
                that.Roles.push(v);
            });
        });
    };
    that.getManagerLists = function () {
        that.isBusy(true);
        $.get(ko.toJS(that.url.managerManageGetAllManagers), function (data) {
            $.each(data.Managers, function (k, v) {
                that.Managers.push(new Manager(v));
            });
            that.isBusy(false);
        });
    };
    that.saveManager = function () {
        if (that.ManagerData().modelState.isValid() && that.locationModelState.isValid()) {
            that.busy(true);
            var jsonData = ko.toJS(that.ManagerData);
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.managerManageCreateManager), jsonData);
            result.done(function (data) {
                that.busy(false);
                if (data) {
                    window.location.href = ko.toJS(that.url.managerList);
                }
                else {
                    //window.location.href = "/Account/SignIn";
                }
            });
        }
        else {
            that.ManagerData().showErrors();
            that.locationShowErrors();
        }
    };
    that.saveandCopyManager = function () {
        if (that.ManagerData().modelState.isValid() && that.locationModelState.isValid()) {
            that.saveAndCopyBusy(true);
            var jsonData = ko.toJS(that.ManagerData);
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.managerManageCreateManager), jsonData);
            result.done(function (data) {
                that.saveAndCopyBusy(false);
                if (data) {
                    toastr["info"]("Saved successfully...!! ", "Notification");
                }
                else {
                    bootbox.alert("Error occured...!!", function () {
                    });
                }
            });
        }
        else {
            that.ManagerData().showErrors();
            that.locationShowErrors();
        }
    };
    that.gotoAddNewManagerPage = function () {
        window.location.href = ko.toJS(that.url.managerCreate);
    };
    that.getEditPage = function (item) {
        window.location.href = ko.toJS(that.url.managerEdit) + item.Id();
    };
    that.editManager = function () {
        that.busy(true);
        var managerIdValue = $("#hdnManagerId").data('value');
        that.ManagerData().resetValidation();
        $.get(ko.toJS(that.url.managerManageEditManager) + managerIdValue, function (data) {
            $.each(data.Countries, function (k, v) {
                that.countries.push(v);
            });
            $.each(data.ManagerRoles, function (k, v) {
                that.Roles.push(v);
            });
            that.ManagerData(new Manager(ko.toJS(data.Manager)));
            editedState = data.Manager.CommunicationDetail.City.StateId;
            editedCity = data.Manager.CommunicationDetail.CityId;
            that.initialStage(true);
            that.selectedCountry(data.Manager.CommunicationDetail.City.State.CountryId);
            that.busy(false);
        });
    };
    that.updateManager = function () {
        if (that.ManagerData().modelState.isValid() && that.locationModelState.isValid()) {
            that.isBusy(true);
            that.ManagerData().CountryId(that.selectedCountry);
            that.ManagerData().StateId(that.selectedState);
            var managerJson = ko.toJS(that.ManagerData());

            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.managerManageUpdateManager), managerJson);
            result.done(function (data) {
                that.isBusy(false);
                if (data) {
                    window.location.href = ko.toJS(that.ERP.managerList);
                }
                else {
                }
            });
        }
        else {
            that.ManagerData().showErrors();
            that.locationShowErrors();
        }
    };
    that.removeManager = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Manager ", function (result) {
            if (result) {
                result = propznetSuite.dataManager.postData(ko.toJS(that.url.managerManageDeleteManager) + item.Id());
                result.done(function (data) {
                    that.Managers.remove(item);
                });
            }

        });

    };
    that.selectedCountry.subscribe(function (newValue) {
        that.resetValidation();
        if (ko.toJS(that.selectedCountry) != null) {
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.managerManageGetAllStatesByCountry) + ko.toJS(that.selectedCountry()));
            result.done(function (data) {
                that.states.removeAll();
                that.cities.removeAll();
                $.each(data.States, function (k, v) {
                    that.states.push(v);
                });
                    if (that.initialStage()) {
                        that.initialCityStage(true);
                        that.selectedState(editedState);
                    }
                    else {

                        that.selectedState('');
                        that.ManagerData().CityId('');
                    }
                    that.initialStage(false);
            });
        }
    });
    that.selectedState.subscribe(function () {
        that.resetValidation();
        if (ko.toJS(that.selectedState)) {
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.managerManageGetAllCitiesByState) + ko.toJS(that.selectedState));
            result.done(function (data) {
                that.cities.removeAll();
                $.each(data.Cities, function (k, v) {
                    that.cities.push(v);
                });
                if (that.initialCityStage())
                    that.ManagerData().CityId(editedCity);
                else {

                    that.ManagerData().CityId('');

                }
                that.initialCityStage(false);
            });
        }
    });
}