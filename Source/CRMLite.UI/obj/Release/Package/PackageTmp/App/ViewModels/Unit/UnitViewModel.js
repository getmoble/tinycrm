function UnitViewModel() {
    var that = this;
    that.url = urls.ERP;
    var editedState = '';
    var editedCity = '';
    that.selectedUnit = ko.observable(new Unit({}));
    that.selectedEditUnit = ko.observable(new Unit({}));
    that.selectedAminity = ko.observable(new Aminities({}));
    that.salesCommission = ko.observable(new SalesCommission({}));
    that.unitTypes = ko.observableArray();
    that.properties = ko.observableArray();
    that.multiUnits = ko.observableArray();
    that.categories = ko.observableArray();
    that.users = ko.observableArray();
    that.measurementUnit = ko.observableArray();
    that.targetRentType = ko.observableArray();
    that.vacancies = ko.observableArray();
    that.isMultiUnitIsNo = ko.observable(false);
    that.initialStage = ko.observable(false);
    that.initialCityStage = ko.observable(false);
    that.query = ko.observable('');
    that.isBusy = ko.observable(false);
    that.countries = ko.observableArray();
    that.states = ko.observableArray();
    that.cities = ko.observableArray();
    that.aminityList = ko.observableArray();
    that.unitList = ko.observableArray();
    that.managerList = ko.observableArray();
    that.aminities = ko.observableArray();
    that.furnishTypes = ko.observableArray();
    that.ownerLists = ko.observableArray();
    that.propertyRentalCommission = ko.observableArray();
    that.owners = ko.observableArray();
    that.ownersId = ko.observableArray();
    that.units = ko.observableArray();
    that.unitsId = ko.observableArray();
    that.incomes = ko.observableArray();
    that.managers = ko.observableArray();
    that.managersId = ko.observableArray();
    that.aminityId = ko.observableArray(); 
    that.unitLists = ko.observableArray();
    that.getUnits = ko.observableArray();
    that.commissionType = ko.observableArray();
    that.gLAccounts = ko.observableArray();
    that.charges = ko.observableArray();
    that.selectedCountry = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    that.selectedState = ko.observable().extend({ required: { params: true, message: "Please Select State" } });
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
    that.unitLists = ko.computed(function () {
        var search = that.query().toLowerCase();
        if (!search) {
            return that.getUnits();
        }
        else {
            return ko.utils.arrayFilter(that.getUnits(), function (item) {
                return (item.PropertyName().toLowerCase().indexOf(search) >= 0 || item.UnitName().toLowerCase().indexOf(search) >= 0 || item.Category().toLowerCase().indexOf(search) >= 0
                    || item.FurnishType().toLowerCase().indexOf(search) >= 0 );
            });
        }

    });

    that.init = function () {
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.unitManageInit));
        result.done(function (data) {
            $.each(data.PropertyCategory, function (k, v) {
                that.categories.push(v);
            });
            $.each(data.MeasurementUnit, function (k, v) {
                that.measurementUnit.push(v);
            });
            $.each(data.RentalTerm, function (k, v) {
                that.targetRentType.push(v);
            });
            $.each(data.FurnishType, function (k, v) {
                that.furnishTypes.push(v);
            });
            $.each(data.Vaccancies, function (k, v) {
                that.vacancies.push(v);
            });
            $.each(data.Countries, function (k, v) {
                that.countries.push(v);
            });
            $.each(data.Users, function (k, v) {
                that.users.push(v);
            });
            $.each(data.UnitTypes, function (k, v) {
                that.unitTypes.push(v);
            });
            $.each(data.Properties, function (k, v) {
                that.properties.push(v);
            });
            $.each(data.CommissionType, function (k, v) {
                that.commissionType.push(v);
            });
            $.each(data.Charges, function (k, v) {
                that.charges.push(v);
            });

            that.selectedUnit().RentInfoViewModel.push(new RentInfoViewModel({}));
            that.gLAccounts([
                    { Text: "NA", Value: "NA" }
            ]);
            that.multiUnits.push(new MultipleUnit('Yes'));
            that.multiUnits.push(new MultipleUnit('No'));
        });
    }
    that.removeRow = function (item) {
        that.selectedUnit().RentInfoViewModel.remove(item);
    };
    that.AddNewRowForRentInfoViewModel = function (item) {
        that.selectedUnit().RentInfoViewModel.push(new RentInfoViewModel({}));
        item.IsDeleted(false);
    };
    that.removeEditRow = function (item) {
        that.selectedEditUnit().RentInfoViewModel.remove(item);
    };
    that.AddNewRowForEditRentInfoViewModel = function (item) {
        that.selectedEditUnit().RentInfoViewModel.push(new RentInfoViewModel({}));
        item.IsDeleted(false);
    };
    that.removeEditMoreInfoRow = function (item) {
        that.propertyRentalCommission.remove(item);
    };
    that.AddNewRowForEditMoreInfoRentInfoViewModel = function (item) {
        that.propertyRentalCommission.push(new UnitRentalCommission({}));
        item.IsDeleted(false);
    };
    that.selectedCountry.subscribe(function (newValue) {
        that.resetValidation();
        if (ko.toJS(that.selectedCountry) != null) {
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.unitManageGetAllStatesByCountry) + ko.toJS(that.selectedCountry()));
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
                    that.selectedEditUnit().CityId('');
                }
                that.initialStage(false);
            });
        }
    });
    that.selectedState.subscribe(function () {
        that.resetValidation();
        if (ko.toJS(that.selectedState)) {
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.unitManageGetAllCitiesByState) + ko.toJS(that.selectedState));
            result.done(function (data) {
                that.cities.removeAll();
                $.each(data.Cities, function (k, v) {
                    that.cities.push(v);
                });
                if (that.initialCityStage())
                    that.selectedEditUnit().CityId(editedCity);
                else {

                    that.selectedEditUnit().CityId('');

                }
                that.initialCityStage(false);

            });
        }
    });
    that.selectedUnit().MultipleUnit.subscribe(function () {

        if (ko.toJS(that.selectedUnit().MultipleUnit() === 'Yes')) {
            that.isMultiUnitIsNo(true);
        }
        if (ko.toJS(that.selectedUnit().MultipleUnit() === 'No')) {
            that.isMultiUnitIsNo(false);
        }
    });
    that.saveUnit = function () {
        if (that.selectedUnit().modelState.isValid() && that.locationModelState.isValid()) {
            that.isBusy(true);
            if (that.selectedUnit().IsRent() == false) {
                that.selectedUnit().RentAmount(null);
                that.selectedUnit().Deposit(null);
                that.selectedUnit().RentalTerms(null);
            }
            if (that.selectedUnit().IsSale() == false) {
                that.selectedUnit().ExpectedPrice(null);
                that.selectedUnit().PropertyMeasurementUnit(null);
                that.selectedUnit().SalesTerms(null);
            }
            if (that.isMultiUnitIsNo() == false) {
                that.selectedUnit().FurnishType(null);
            }
            if (that.isMultiUnitIsNo() == false) {
                that.selectedUnit().FurnishType(null);
            }
            if (that.selectedUnit().IsParking() == false) {
                that.selectedUnit().ParkingNumber(null);
            }
            var unitJson = ko.toJS(that.selectedUnit());
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.unitManageCreateUnit), unitJson);
            result.done(function (data) {
                that.isBusy(false);
                if (data) {
                    window.location.href = ko.toJS(that.url.unitEdit) + ko.toJS(data.Unit.Id)
                }
                else {
                    bootbox.alert("Error occured...!!", function () {
                    });
                }
            });
        }
        else {
            that.selectedUnit().showErrors();
            that.locationShowErrors();
        }
    }
    that.saveAndCopyUnit = function () {
        if (that.selectedUnit().modelState.isValid() && that.locationModelState.isValid()) {
            that.isBusy(true);
            if (that.selectedUnit().IsRent() === false) {
                that.selectedUnit().RentAmount(null);
                that.selectedUnit().Deposit(null);
                that.selectedUnit().RentalTerms(null);
            }
            if (that.selectedUnit().IsSale() === false) {
                that.selectedUnit().ExpectedPrice(null);
                that.selectedUnit().PropertyMeasurementUnit(null);
                that.selectedUnit().SalesTerms(null);
            }
            if (that.isMultiUnitIsNo() === false) {
                that.selectedUnit().FurnishType(null);
            }
            if (that.isMultiUnitIsNo() === false) {
                that.selectedUnit().FurnishType(null);
            }
            if (that.selectedUnit().IsParking() === false) {
                that.selectedUnit().ParkingNumber(null);
            }
            var unitJson = ko.toJS(that.selectedUnit());
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.unitManageCreateUnit), unitJson);
            result.done(function (data) {
                that.isBusy(false);
                if (data) {
                    toastr["info"]("Updated successfully...!! ", "Notification");
                }
                else {
                    bootbox.alert("Error occured...!!", function () {
                    });
                }
            });
        }
        else {
            that.selectedUnit().showErrors();
            that.locationShowErrors();
        }
    }
    that.CreateAminity = function () {
        var aminityJson = ko.toJS(that.selectedAminity());
        var result = propznetSuite.dataManager.postData(ko.toJS(that.url.propertyManageCreateAminity), aminityJson);
        result.done(function (data) {
            if (data) {
                that.aminityList.push(new Aminities(aminityJson));
            }
            else {
                bootbox.alert("Error occured...!!", function () {
                });
            }
        });

    }
    that.addOwners = function () {
        var tmp = [];
        ko.utils.arrayForEach(that.owners(), function (val) {
            tmp.push(val.Id());
        });
        ko.utils.arrayForEach(that.ownerLists(), function (item) {
            if (item.IsSelect()) {
                if ((tmp.indexOf(item.Id()) === -1)) {
                    that.owners.push(item);
                    that.ownersId.push(item.Id());
                }
            }
        });
    }
    that.removeOwner = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Owner " + item.FirstName(), function (result) {
            if (result) {
                that.owners.remove(item);
                that.ownersId.remove(item.Id());
            }
        });

    }
    that.addManager = function () {
        var tmp = [];
        ko.utils.arrayForEach(that.managers(), function (val) {
            tmp.push(val.Id());
        });
        ko.utils.arrayForEach(that.managerList(), function (item) {
            if (item.IsSelect()) {
                if ((tmp.indexOf(item.Id()) === -1)) {
                    that.managers.push(item);
                    that.managersId.push(item.Id());
                }
            }
        });
    }
    that.removeManager = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Manager " + item.FirstName(), function (result) {
            if (result) {
                that.managers.remove(item);
                that.managersId.remove(item.Id());
            }
        });

    }
    that.saveMoreUnit = function () {
        $.each(that.aminityList(), function (k, v) {
            if (v.IsSelectAmenity()) {
                that.aminityId.push(v.Id);
            }
        });
        var unitIdValue = $("#hdnunitId").data('value');
        var saleCommision = ko.toJS(that.salesCommission());
        var vm = {
            UnitId: ko.toJS(unitIdValue), SalesCommissionViewModel: saleCommision, OwnersId: ko.toJS(that.ownersId), ManagersId: ko.toJS(that.managersId), AminityId: ko.toJS(that.aminityId)
        }
        var result = propznetSuite.dataManager.postData(ko.toJS(that.url.unitManageCreateMoreUnit), vm);
        result.done(function (data) {
            if (data) {
                toastr["info"]("Updated successfully...!! ", "Notification");
            }
            else {
                bootbox.alert("Error occured...!!", function () {
                });
            }
        });
    }
    that.gotoAddUnit = function () {
        window.location.href = "/ERP/unit/create";
    }
    that.getLists = function () {
        that.isBusy(true);
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.unitManageGetAllUnits));
        result.done(function (data) {
            $.each(data.Units, function (k, v) {
                that.getUnits.push(new Unit(v));
            });
        });
        that.isBusy(false);
    }
    that.getEditPage = function (item) {
        window.location.href = ko.toJS(that.url.unitEdit) + item.Id();
    }
    that.editUnit = function () {
        that.isBusy(true);
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.unitManageInit));
        result.done(function (data) {
            $.each(data.PropertyCategory, function (k, v) {
                that.categories.push(v);
            });
            $.each(data.MeasurementUnit, function (k, v) {
                that.measurementUnit.push(v);
            });
            $.each(data.RentalTerm, function (k, v) {
                that.targetRentType.push(v);
            });
            $.each(data.FurnishType, function (k, v) {
                that.furnishTypes.push(v);
            });
            $.each(data.Vaccancies, function (k, v) {
                that.vacancies.push(v);
            });
            $.each(data.Countries, function (k, v) {
                that.countries.push(v);
            });
            $.each(data.Users, function (k, v) {
                that.users.push(v);
            });
            $.each(data.UnitTypes, function (k, v) {
                that.unitTypes.push(v);
            });
            $.each(data.Properties, function (k, v) {
                that.properties.push(v);
            });
            $.each(data.Amenities, function (k, v) {
                that.aminityList.push(new Aminities(v));
            });
                  $.each(data.Charges, function (k, v) {
                that.charges.push(v);
            });
            that.gLAccounts([
                { Text: "NA", Value: "NA" }
            ]);
            that.incomes([
              { Text: "NA", Value: "NA" }
            ]);
            that.multiUnits.push(new MultipleUnit('Yes'));
            that.multiUnits.push(new MultipleUnit('No'));
            $.each(data.Managers, function (k, v) {
                that.managerList.push(new Manager(v));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            var oTable = $('#pagination').dataTable();
            var result = propznetSuite.dataManager.getData(ko.toJS(that.url.ownerManageGetAllOwners));
            result.done(function (data) {
                $.each(data.Owners, function (k, v) {
                    that.ownerLists.push(new Owner(v));
                });
                $("#addManagerDataTable").DataTable({
                    responsive: true,
                    "order": [[3, "desc"]]
                });
                oTable = $('#addManagerDataTable').dataTable();
            });
            var unitIdValue = $("#hdnunitId").data('value');
            var result = propznetSuite.dataManager.getData(ko.toJS(that.url.unitManageEditUnit + unitIdValue));
            result.done(function (data) {
                that.selectedEditUnit(new Unit(ko.toJS(data.Unit)));
                if (ko.toJS(data.Unit.CommissionType) === '0') {
                    that.salesCommission().IsPercentage('Percentage');
                }
                if (ko.toJS(data.Unit.CommissionType) === '1') {
                    that.salesCommission().IsPercentage('Flat');
                }
                editedState = ko.toJS(data.Unit.CommunicationDetails.City.StateId);
                editedCity = ko.toJS(data.Unit.CommunicationDetails.CityId);
                that.initialStage(true);
                that.selectedCountry(data.Unit.CommunicationDetails.City.State.CountryId);
                $.each(data.Managers, function (k, v) {
                    that.managers.push(new Manager(v));
                    that.managersId.push(v.Id);
                });
                $.each(data.Owners, function (k, v) {
                    that.owners.push(new Owner(v));
                    that.ownersId.push(v.Id);
                });
                $.each(data.Amenities, function (key, val) {
                    $.each(that.aminityList(), function (k, v) {
                        if (ko.toJS(val.Id) === ko.toJS(v.Id)) {
                            v.IsSelectAmenity(true);
                        }

                    });
                });
                that.selectedEditUnit().RentInfoViewModel.push(new RentInfoViewModel({}));
                $.each(data.RentInfo, function (k, v) {
                    that.selectedEditUnit().RentInfoViewModel.push(new RentInfoViewModel(v));
                });
                that.propertyRentalCommission.push(new UnitRentalCommission({}));
                $.each(data.RentalCommission, function (k, v) {
                    that.propertyRentalCommission.push(new UnitRentalCommission(v));
                });
            });
        });
        that.isBusy(false);
    }
    that.updateUnit = function () {
        if (that.selectedEditUnit().modelState.isValid() && that.locationModelState.isValid()) {
            that.isBusy(true);
            if (that.selectedEditUnit().IsRent() === false) {
                that.selectedEditUnit().RentAmount(null);
                that.selectedEditUnit().Deposit(null);
                that.selectedEditUnit().RentalTerms(null);
            }
            if (that.selectedEditUnit().IsSale() === false) {
                that.selectedEditUnit().ExpectedPrice(null);
                that.selectedEditUnit().PropertyMeasurementUnit(null);
                that.selectedEditUnit().SalesTerms(null);
            }
            if (that.isMultiUnitIsNo() === false) {
                that.selectedEditUnit().FurnishType(null);
            }
            if (that.isMultiUnitIsNo() === false) {
                that.selectedEditUnit().FurnishType(null);
            }
            if (that.selectedEditUnit().IsParking() == false) {
                that.selectedEditUnit().ParkingNumber(null);
            }
            var unitJson = ko.toJS(that.selectedEditUnit());

            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.unitManageUpdateUnit), unitJson);
        result.done(function (data) {
            that.isBusy(false);
            if (data) {
                window.location.href = unitList;
            }
            else {
                bootbox.alert("Error occured...!!", function () {
                });
            }
        });
    }
else {
            that.selectedEditUnit().showErrors();
            that.locationShowErrors();
}

    }
    that.removeUnit = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Unit " + item.UnitName(), function (result) {
            if (result) {
                var isDeleted = propznetSuite.dataManager.postData(ko.toJS(that.url.unitManageDeleteUnit) + item.Id());
                isDeleted.done(function (data) {
                    that.getUnits.remove(item);
                });
            }
        });

    }
    that.clear = function () {
        that.selectedAminity().Name('');
    }
}