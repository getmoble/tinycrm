function OwnerViewModel() {
    var that = this;
    that.url = urls.ERP;
    var editedState = '';
    var editedCity = '';
    that.busy = ko.observable();
    that.saveAndCopyBusy = ko.observable();
    that.data = ko.observableArray();
    that.selectedOwner = ko.observable(new Owner({}));
    that.editSelectedOwner = ko.observable(new Owner({}));
    that.ownerLists = ko.observableArray();
    that.getOwners = ko.observableArray();
    that.owners = ko.observableArray();
    that.initialStage = ko.observable(false);
    that.initialCityStage = ko.observable(false);
    that.countries = ko.observableArray();
    that.states = ko.observableArray();
    that.cities = ko.observableArray();
    that.selectedCountry = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    that.selectedState = ko.observable().extend({ required: { params: true, message: "Please Select State" } });
    that.locationModelState = ko.validatedObservable();
    that.sCountry = ko.observable();
    that.query = ko.observable('');
    that.isBusy = ko.observable(false);
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
    that.ownerLists = ko.computed(function () {
        var search = that.query().toLowerCase();
        if (!search) {
            return that.getOwners();
        }
        else {
            return ko.utils.arrayFilter(that.getOwners(), function (item) {
                return (item.FirstName().toLowerCase().indexOf(search) >= 0 || item.Email().toLowerCase().indexOf(search) >= 0);
            });
        }

    });
    that.init = function () {
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.ownerManageInit));
        result.done(function (data) {
            $.each(data.Countries, function (k, v) {
                that.countries.push(v);
            });           
        });
    };
    that.editOwner = function () {
        that.isBusy(true);
        var ownerIdValue = $("#hdnownerId").data('value');
        $.get(ko.toJS(that.url.ownerManageEditOwner) + ownerIdValue, function (data) {
            $.each(data.Countries, function (k, v) {
                that.countries.push(v);
            });
            that.editSelectedOwner(new Owner(ko.toJS(data.Owner)));
            editedState = data.Owner.City.StateId;
            editedCity = data.Owner.CityId;
            that.initialStage(true);
            that.selectedCountry(data.Owner.City.State.CountryId);
            that.isBusy(false);
        });
    };
    that.selectedCountry.subscribe(function (newValue) {
        that.resetValidation();
        if (ko.toJS(that.selectedCountry) != null) {
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.OwnerManageGetAllStatesByCountry) + ko.toJS(that.selectedCountry()));
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
                    that.editSelectedOwner().CityId('');
                }
                that.initialStage(false);
            });
        }
    });
    that.selectedState.subscribe(function () {
        that.resetValidation();
        if (ko.toJS(that.selectedState)) {
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.ownerManageGetAllCitiesByState) + ko.toJS(that.selectedState));
            result.done(function (data) {
                that.cities.removeAll();
                $.each(data.Cities, function (k, v) {
                    that.cities.push(v);
                });
                if (that.initialCityStage())
                    that.editSelectedOwner().CityId(editedCity);
                else {
         
                    that.editSelectedOwner().CityId('');
                
                }
                that.initialCityStage(false);
            });
        }
    });
    that.getLists = function () {
        that.isBusy(true);
        $.get(ko.toJS(that.url.ownerManageGetAllOwners), function (data) {
            $.each(data.Owners, function (k, v) {
                that.getOwners.push(new Owner(v));
            });
            that.isBusy(false);
        });
    };
    that.gotoAddNewOwnerPage = function () {
        window.location.href = ko.toJS(that.url.ownerCreate);
    };
    that.saveOwner = function () {
        if (that.selectedOwner().modelState.isValid() && that.locationModelState.isValid()) {
            that.isBusy(true);
            that.busy(true);
            if (that.selectedOwner().TaxEligible == false) {
                that.selectedOwner().TaxId(null);
                that.selectedOwner().TaxPayerName(null);
            }
            if (that.selectedOwner().OnlinePaymentMode == false) {
                that.selectedOwner().BankAccountNumber(null);
                that.selectedOwner().Bank(null);
                that.selectedOwner().Branch(null);
                that.selectedOwner().BankIFSC(null);
                that.selectedOwner().Description(null);
            }
            var ownerJson = ko.toJS(that.selectedOwner());
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.ownerManageCreateOwner), ownerJson);
            result.done(function (data) {
                if (data) {
                    that.isBusy(false);
                    window.location.href = ko.toJS(that.url.ownerList);
                }
                else {
                    that.isBusy(false);
                    toastr["info"]("Sorry, Owner already exists !! ", "Notification");
                }
            });
            that.busy(false);
        }
        else {
            that.selectedOwner().showErrors();
            that.locationShowErrors();
        }
    };
    that.saveAndCopyOwner = function () {
        if (that.selectedOwner().modelState.isValid() && that.locationModelState.isValid()) {
            that.isBusy(true);
            that.saveAndCopyBusy(true);
            if (that.selectedOwner().TaxEligible === false) {
                that.selectedOwner().TaxId(null);
                that.selectedOwner().TaxPayerName(null);
            }
            if (that.selectedOwner().OnlinePaymentMode === false) {
                that.selectedOwner().BankAccountNumber(null);
                that.selectedOwner().Bank(null);
                that.selectedOwner().Branch(null);
                that.selectedOwner().BankIFSC(null);
                that.selectedOwner().Description(null);
            }
            var ownerJson = ko.toJS(that.selectedOwner());

            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.ownerManageCreateOwner), ownerJson);
            result.done(function (data) {
                that.isBusy(false);
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
            that.selectedOwner().showErrors();
            that.locationShowErrors();
        }
    };
    that.getEditPage = function (item) {
        window.location.href = ko.toJS(that.url.ownerEdit) + item.Id();
    };
    that.updateOwner = function () {
        if (that.editSelectedOwner().modelState.isValid() && that.locationModelState.isValid()) {
            that.isBusy(true);
            that.busy(true);
            if (that.editSelectedOwner().TaxEligible === false) {
                that.editSelectedOwner().TaxId(null);
                that.editSelectedOwner().TaxPayerName(null);
            }
            if (that.editSelectedOwner().OnlinePaymentMode == false) {
                that.editSelectedOwner().BankAccountNumber(null);
                that.editSelectedOwner().Bank(null);
                that.editSelectedOwner().Branch(null);
                that.editSelectedOwner().BankIFSC(null);
                that.editSelectedOwner().Description(null);
            }
            that.editSelectedOwner().CountryId(that.selectedCountry);
            that.editSelectedOwner().StateId(that.selectedState);
        var ownerJson = ko.toJS(that.editSelectedOwner());

        var result = propznetSuite.dataManager.postData(ko.toJS(that.url.ownerManageUpdateOwner), ownerJson);
        result.done(function (data) {
            that.isBusy(false);
            that.busy(false);
            if (data) {
                window.location.href = ko.toJS(that.url.ownerList);
            }
            else {
            }
        });
    }
else {
    that.selectedOwner().showErrors();
    that.locationShowErrors();
}
    };
    that.removeOwner = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Owner " + item.FirstName(), function (result) {
            if (result) {
                result = propznetSuite.dataManager.postData(ko.toJS(that.url.ownerManageDeleteOwner) + item.Id());
                result.done(function (data) {
                    that.getOwners.remove(item);
                });
            }

        });

    };
}

