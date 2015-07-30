function PropertyViewModel() {
    var that = this;
    that.url = urls.ERP;
    var editedState = '';
    var editedCity = '';
    that.countries = ko.observableArray();
    that.states = ko.observableArray();
    that.cities = ko.observableArray();
    that.aminityList = ko.observableArray();
    that.unitList = ko.observableArray();
    that.managerList = ko.observableArray();
    that.aminities = ko.observableArray();
    that.furnishTypes = ko.observableArray();
    that.ownerLists = ko.observableArray();
    that.unitLists = ko.observableArray();
    that.owners = ko.observableArray();
    that.ownersId = ko.observableArray();
    that.units = ko.observableArray();
    that.unitsId = ko.observableArray();
    that.managers = ko.observableArray();
    that.propertyRentalCommission = ko.observableArray();
    that.managersId = ko.observableArray();
    that.aminityId = ko.observableArray();
    that.portfolios = ko.observableArray();
    that.multiUnits = ko.observableArray();
    that.usageTypes = ko.observableArray();
    that.sourceTypes = ko.observableArray();
    that.users = ko.observableArray();
    that.incomes = ko.observableArray();
    that.commissionType = ko.observableArray();
    that.gLAccounts = ko.observableArray();
    that.measurementUnit = ko.observableArray();
    that.targetRentType = ko.observableArray();
    that.charges = ko.observableArray();
    that.vacancies = ko.observableArray();
    that.RentInfoViewModel = ko.observableArray();
    that.selectedProperty = ko.observable(new Property({}));
    that.selectedEditProperty = ko.observable(new Property({}));
    that.selectedAminity = ko.observable(new Aminities({}));
    that.selectedMarketingInformation = ko.observable(new MarketingInformation({}));
    that.salesCommission = ko.observable(new SalesCommission({}));
    that.isMultiUnitIsNo = ko.observable(false);
    that.isBuidingProperty = ko.observable(false);
    that.editMultipleUnit = ko.observable();
    that.initialStage = ko.observable(false);
    that.initialCityStage = ko.observable(false);
    that.query = ko.observable('');
    that.isBusy = ko.observable(false);
    that.isDeleted = ko.observable(false);
    that.selectedCountry = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    that.selectedState = ko.observable().extend({ required: { params: true, message: "Please Select State" } });
    that.propertyLists = ko.observableArray();
    that.properties = ko.observableArray();
    that.propertyLists = ko.computed(function () {
        var search = that.query().toLowerCase();
        if (!search) {
            return that.properties();
        }
        else
        {
            return ko.utils.arrayFilter(that.properties(), function (item) {
                return (item.PropertyName().toLowerCase().indexOf(search) >= 0 || item.Portfolio().toLowerCase().indexOf(search) >= 0 || item.PropertyFor().toLowerCase().indexOf(search) >= 0
                    || item.ContractStartDate().toLowerCase().indexOf(search) >= 0 || item.ContractEndDate().toLowerCase().indexOf(search) >= 0);
            });
        }
        
    });
    that.prop = ko.dependentObservable(function () {
        var search = ko.toJS(that.query().toLowerCase());
        return ko.utils.arrayFilter(that.propertyLists, function (property) {

            return property.PropertyName().toLowerCase().indexOf(search) >= 0;
        });
    });
    that.prop = ko.dependentObservable(function () {
        var search = ko.toJS(that.query().toLowerCase());
        return ko.utils.arrayFilter(that.propertyLists, function (property) {

            return property.PropertyName().toLowerCase().indexOf(search) >= 0;
        });
    });
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
    that.init = function () {
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.propertyManageInit));
        result.done(function (data) {
            $.each(data.PropertyCategory, function (k, v) {
                that.usageTypes.push(v);
            });
            $.each(data.SourceType, function (k, v) {
                that.sourceTypes.push(v);
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
            $.each(data.Portfolios, function (k, v) {
                that.portfolios.push(v);
            });
            $.each(data.Countries, function (k, v) {
                that.countries.push(v);
            });
            $.each(data.Users, function (k, v) {
                that.users.push(v);
            });
            $.each(data.CommissionType, function (k, v) {
                that.commissionType.push(v);
            });
            $.each(data.Charges, function (k, v) {
                that.charges.push(v);
            });

            that.selectedProperty().RentInfoViewModel.push(new RentInfoViewModel({}));
            that.gLAccounts([
                    { Text: "NA", Value: "NA" }
            ]);
            var result = propznetSuite.dataManager.getData(ko.toJS(that.url.ownerManageGetAllOwners));
            result.done(function (data) {
                $.each(data.Owners, function (k, v) {
                    that.ownerLists.push(new Owner(v));
                });
                $("#pagination").DataTable({
                    responsive: true,
                    "order": [[3, "desc"]]
                });
                oTable = $('#pagination').dataTable();
            });
            that.multiUnits.push(new MultipleUnit('Yes'));
            that.multiUnits.push(new MultipleUnit('No'));
            that.selectedMarketingInformation().IsRent(false);
            that.selectedMarketingInformation().IsSale(false);
            
        });
    };
    that.selectedCountry.subscribe(function (newValue) {
        that.resetValidation();
        if (ko.toJS(that.selectedCountry) != null) {
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.propertyManageGetAllStatesByCountry) + ko.toJS(that.selectedCountry()));
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
                    that.selectedEditProperty().CityId('');
                }
                that.initialStage(false);
            });
        }
    });
    that.selectedState.subscribe(function () {
        that.resetValidation();
        if (ko.toJS(that.selectedState)) {
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.propertyManageGetAllCitiesByState) + ko.toJS(that.selectedState));
            result.done(function (data) {
                that.cities.removeAll();
                $.each(data.Cities, function (k, v) {
                    that.cities.push(v);
                });
                if (that.initialCityStage())
                    that.selectedEditProperty().CityId(editedCity);
                else {

                    that.selectedEditProperty().CityId('');

                }
                that.initialCityStage(false);
            });
        }
    });
    that.selectedProperty().MultipleUnit.subscribe(function () {
       
        if (ko.toJS(that.selectedProperty().MultipleUnit() === 'Yes')) {
            that.isMultiUnitIsNo(true);
        }
        if (ko.toJS(that.selectedProperty().MultipleUnit() === 'No')) {
            that.isMultiUnitIsNo(false);
        }
    });
    that.editMultipleUnit.subscribe(function () {

        if (ko.toJS(that.editMultipleUnit() === 'Yes')) {
            that.isMultiUnitIsNo(true);
        }
        if (ko.toJS(that.editMultipleUnit() === 'No')) {
            that.isMultiUnitIsNo(false);
        }
    });
    that.selectedProperty().IsBuilding.subscribe(function () {
        if (ko.toJS(that.selectedProperty().IsBuilding() === 'Building')) {
            that.isBuidingProperty(true);
            that.selectedProperty().IsLand(false);
        }
    });
    that.selectedProperty().IsLand.subscribe(function () {
        if (ko.toJS(that.selectedProperty().IsLand() === 'Land')) {
            that.isBuidingProperty(false);
            that.selectedProperty().IsBuilding(false);
        }
    });
    that.removeRow = function (item) {
        that.selectedProperty().RentInfoViewModel.remove(item);
    };
    that.removeEditRow = function (item) {
        that.selectedEditProperty().RentInfoViewModel.remove(item);
    };
    that.removeEditMoreInfoRow = function (item) {
        that.propertyRentalCommission.remove(item);
    };
    that.AddNewRowForRentInfoViewModel = function (item) {
        that.selectedProperty().RentInfoViewModel.push(new RentInfoViewModel({}));
        item.IsDeleted(false);
    };
    that.AddNewRowForEditRentInfoViewModel = function (item) {
        that.selectedEditProperty().RentInfoViewModel.push(new RentInfoViewModel({}));
        item.IsDeleted(false);
    };
    that.AddNewRowForEditMoreInfoRentInfoViewModel = function (item) {
        that.propertyRentalCommission.push(new PropertyRentalCommission({}));
        item.IsDeleted(false);
    };
    that.saveProperty = function () {
        that.selectedProperty().ContractStartDate($("#ContractStartDatetxt").val());
        that.selectedProperty().ContractEndDate($("#ContractEndDatetxt").val());
        if (that.selectedProperty().modelState.isValid() && that.locationModelState.isValid()) {
            that.isBusy(true);
            if (that.selectedProperty().IsRent() === false) {
                that.selectedProperty().RentAmount(null);
                that.selectedProperty().Deposit(null);
                that.selectedProperty().RentalTerms(null);
            }
            if (that.selectedProperty().IsSale() === false) {
                that.selectedProperty().ExpectedPrice(null);
                that.selectedProperty().PropertyMeasurementUnit(null);
                that.selectedProperty().SalesTerms(null);
            }
            if (that.isMultiUnitIsNo() === false)
            {
                that.selectedProperty().FurnishType(null);
            }
            if (that.isMultiUnitIsNo() === false) {
                that.selectedProperty().FurnishType(null);
            }
            if (that.selectedProperty().IsParking() === false)
            {
                that.selectedProperty().ParkingNumber(null);
            }
            var logitude = $("#hdlogitude").val();
            var latitude = $("#hdlatitude").val();
            that.selectedProperty().Longitude(logitude);
            that.selectedProperty().Latitude(latitude);
            var propertyJson = ko.toJS(that.selectedProperty());
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.propertyManageCreateProperty), propertyJson);
            result.done(function (data) {
                that.isBusy(false);
                if (data) {
                    window.location.href = ko.toJS(that.url.propertyEdit) + ko.toJS(data.Property.Id);
                }
                else {
                    bootbox.alert("Error occured...!!", function () {
                    });
                }
            });
        }
        else {
            that.selectedProperty().showErrors();
            that.locationShowErrors();
        }
    };
    that.saveAndCopyProperty = function () {
        that.selectedProperty().ContractStartDate($("#ContractStartDatetxt").val());
        that.selectedProperty().ContractEndDate($("#ContractEndDatetxt").val());
        if (that.selectedProperty().modelState.isValid() && that.locationModelState.isValid()) {
            that.isBusy(true);
            if (that.selectedProperty().IsRent() === false) {
                that.selectedProperty().RentAmount(null);
                that.selectedProperty().Deposit(null);
                that.selectedProperty().RentalTerms(null);
            }
            if (that.selectedProperty().IsSale() === false) {
                that.selectedProperty().ExpectedPrice(null);
                that.selectedProperty().PropertyMeasurementUnit(null);
                that.selectedProperty().SalesTerms(null);
            }
            if (that.isMultiUnitIsNo() === false) {
                that.selectedProperty().FurnishType(null);
            }
            if (that.isMultiUnitIsNo() === false) {
                that.selectedProperty().FurnishType(null);
            }
            if (that.selectedProperty().IsParking() === false) {
                that.selectedProperty().ParkingNumber(null);
            }
            var logitude = $("#hdlogitude").data('value');
            var latitude = $("#hdlatitude").data('value');
            that.selectedProperty().Longitude(logitude);
            that.selectedProperty().Latitude(latitude);
            var propertyJson = ko.toJS(that.selectedProperty());
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.propertyManageCreateProperty), propertyJson);
            result.done(function (data) {
                if (data) {
                    that.isBusy(false);
                    toastr["info"]("Saved successfully...!! ", "Notification");                
                }
                else {
                    bootbox.alert("Error occured...!!", function () {
                    });
                }
            });
        }
        else {
            that.selectedProperty().showErrors();
            that.locationShowErrors();
        }
    };
    that.CreateAminity = function () {
        if (that.selectedAminity().modelState.isValid()) {
            var aminityJson = ko.toJS(that.selectedAminity());

            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.propertyManageCreateAminity), aminityJson);
        result.done(function (data) {
            if (data) {
                $('#createAminityForProperty').modal('hide');
                that.aminityList.push(new Aminities(aminityJson));
            }
            else {
                bootbox.alert("Error occured...!!", function () {
                });
            }
        });
        }
        else {
            that.selectedAminity().showErrors();
        }
    };
    that.addOwners = function () {
        var tmp = [];            
        ko.utils.arrayForEach(that.owners(), function (val) {
            tmp.push(val.Id());
        });           
        ko.utils.arrayForEach(that.ownerLists(), function (item) {
            if(item.IsSelect())
            {                  
                if ((tmp.indexOf(item.Id()) === -1))
                {
                    that.owners.push(item);
                    that.ownersId.push(item.Id());
                }                  
            }
        });
    };
    that.removeOwner = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Owner " + item.FirstName(), function (result) {
            if (result) {
                that.owners.remove(item);
                that.ownersId.remove(item.Id());
            }
        });

    };
    that.addUnits = function () {
        var tmp = [];
        ko.utils.arrayForEach(that.units(), function (val) {
            tmp.push(val.Id());
        });
        ko.utils.arrayForEach(that.unitLists(), function (item) {
            if (item.IsSelect()) {
                if ((tmp.indexOf(item.Id()) === -1)) {
                    that.units.push(item);
                    that.unitsId.push(item.Id());
                }
            }
        });
    };
    that.removeUnit = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Unit " + item.UnitName(), function (result) {
            if (result) {
                that.units.remove(item);
                that.unitsId.remove(item.Id());
            }
        });

    };
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
    };
    that.removeManager = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Manager " + item.FirstName(), function (result) {
            if (result) {
                that.managers.remove(item);
                that.managersId.remove(item.Id());
            }
        });

    };
    that.saveMoreProperty = function () {
        $.each(that.aminityList(), function (k, v) {
            if(v.IsSelectAmenity())
            {
                that.aminityId.push(v.Id);
            }
        });
        var propertyIdValue = $("#hdnpropertyId").data('value');
        var marketingInfo = ko.toJS(that.selectedMarketingInformation());
        var saleCommision = ko.toJS(that.salesCommission());
        var vm = {
            PropertyId: ko.toJS(propertyIdValue), MarketingInformationViewModel: marketingInfo, SalesCommissionViewModel: saleCommision, OwnersId: ko.toJS(that.ownersId), UnitsId: ko.toJS(that.unitsId), OwnersId: ko.toJS(that.ownersId), ManagersId: ko.toJS(that.managersId), AminityId: ko.toJS(that.aminityId), PropertyRentalCommission: ko.toJS(that.propertyRentalCommission)
        };
        var result = propznetSuite.dataManager.postData(ko.toJS(that.url.propertyManageCreateMoreProperty), vm);
            result.done(function (data) {
                if (data) {
                    toastr["info"]("Updated successfully...!! ", "Notification");
                }
                else {
                    bootbox.alert("Error occured...!!", function () {
                    });
                }
            });
        };
    that.gotoAddProperty = function () {
        window.location.href = ko.toJS(that.url.propertyCreate);
    };
    that.getLists = function () {
        that.isBusy(true);
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.propertyManageGetAllProperties));
        result.done(function (data) {
            that.isBusy(false);
            $.each(data.Properties, function (k, v) {
                that.properties.push(new Property(v));
            });
        });
    };
    that.getEditPage = function (item) {
        window.location.href = ko.toJS(that.url.propertyEdit) + item.Id();
    };
    that.editProperty = function () {
        that.isBusy(true);
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.propertyManageInit));
        result.done(function (data) {
            $.each(data.PropertyCategory, function (k, v) {
                that.usageTypes.push(v);
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
            $.each(data.Portfolios, function (k, v) {
                that.portfolios.push(v);
            });
            $.each(data.Countries, function (k, v) {
                that.countries.push(v);
            });
            $.each(data.Users, function (k, v) {
                that.users.push(v);
            });
            $.each(data.Amenities, function (k, v) {
                that.aminityList.push(new Aminities(v));
            });
            $.each(data.Units, function (k, v) {
                that.unitList.push(new Unit(v));
            });
            $.each(data.Managers, function (k, v) {
                that.managerList.push(new Manager(v));
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
                $("#ownerDatatable").DataTable({
                    responsive: true,
                    "order": [[3, "desc"]]
                });
                oTable = $('#ownerDatatable').dataTable();
            });
            var getAllUnits = propznetSuite.dataManager.getData(ko.toJS(that.url.unitManageGetAllUnits));
            getAllUnits.done(function (data) {
                $.each(data.Units, function (k, v) {
                    that.unitLists.push(new Unit(v));
                });
                $("#unitDatatable").DataTable({
                    responsive: true,
                    "order": [[3, "desc"]]
                });
                var oTable = $('#unitDatatable').dataTable();
            }); 
            that.multiUnits.push(new MultipleUnit('Yes'));
            that.multiUnits.push(new MultipleUnit('No'));
            that.selectedMarketingInformation().IsRent(false);
            that.selectedMarketingInformation().IsSale(false);
            var propertyIdValue = $("#hdnpropertyId").data('value');
            var result = propznetSuite.dataManager.getData(ko.toJS(that.url.propertyManageEditPrperty) + propertyIdValue);
            result.done(function (data) {
                that.selectedEditProperty(new Property(ko.toJS(data.Property)));
                if (ko.toJS(data.Property.MultipleUnit) === true) {
                    that.editMultipleUnit('Yes');
                }
                if (ko.toJS(data.Property.MultipleUnit) === false) {
                    that.editMultipleUnit('No');
                }
                if (ko.toJS(data.Property.CommissionType)==='0')
                {
                    that.salesCommission().IsPercentage('Percentage');
                }
                if (ko.toJS(data.Property.CommissionType) === '1') {
                    that.salesCommission().IsPercentage('Flat');
                }
                that.selectedEditProperty().RentInfoViewModel.push(new RentInfoViewModel({}));
                $.each(data.RentInfo, function (k, v) {
                    that.selectedEditProperty().RentInfoViewModel.push(new RentInfoViewModel(v));
                });
                that.propertyRentalCommission.push(new PropertyRentalCommission({}));
                $.each(data.RentalCommission, function (k, v) {
                    that.propertyRentalCommission.push(new PropertyRentalCommission(v));
                });
                $.each(data.SalesCommissionType, function (k, v) {
                    that.commissionType.push(v);
                }); 
                that.selectedMarketingInformation(new MarketingInformation(ko.toJS(data.Property)));
                that.salesCommission().Comission(data.Property.SalesCommission);
                editedState = ko.toJS(that.selectedEditProperty().StateId);
                editedCity = ko.toJS(data.Property.CommunicationDetails.CityId);
                that.initialStage(true);
                $("#hdlogitude").val(ko.toJS(data.Property.CommunicationDetails.Longitude));
                $("#hdlatitude").val(ko.toJS(data.Property.CommunicationDetails.Latitude));

                var long = ko.toJS(data.Property.CommunicationDetails.Longitude);
                var lat = ko.toJS(data.Property.CommunicationDetails.Latitude);
                var myLatlng = new google.maps.LatLng(lat, long);
                var myOptions = {
                    center: myLatlng,
                    zoom: 6,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
                var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
                google.maps.event.addListenerOnce(map, 'idle', function () {
                    google.maps.event.trigger(map, 'resize');
                });
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: "lat: " + lat + " long: " + long,
                    draggable: true
                });
                google.maps.event.addListener(marker, 'dragend', function (marker) {
                    var latLng = marker.latLng;
                    document.getElementById('hdlogitude').value = latLng.lat();
                    document.getElementById('hdlatitude').value = latLng.lng();
                });

                that.selectedCountry(data.Property.CommunicationDetails.City.State.CountryId);
                $.each(data.Managers, function (k, v) {
                    that.managers.push(new Manager(v));
                    that.managersId.push(v.Id);
                });
                $.each(data.Owners, function (k, v) {
                    that.owners.push(new Owner(v));
                    that.ownersId.push(v.Id);
                });
                $.each(data.Units, function (k, v) {
                    that.units.push(new Unit(v));
                    that.unitsId.push(v.Id);
                });
                $.each(data.Amenities, function (key, val) {
                    $.each(that.aminityList(), function (k, v) {
                        if (ko.toJS(val.Id) === ko.toJS(v.Id))
                        {
                            v.IsSelectAmenity(true);
                        }
                   
                    });
                });
            });
        });
        that.isBusy(false);
    };
    self.getPropertyAminities = function () {
        self.isBusy(true);
        var result = propznetSuite.dataManager.getData(ko.toJS(self.url.potentialManagegetPropertyAminities));
        result.done(function (data) {
            self.isBusy(false);
            $.each(data.Properties, function (k, v) {
                self.propertyLists.push(new Property(v));
            });
            $.each(data.Amenities, function (k, v) {
                self.aminityList.push(new Aminities(v));
            });
        });
    };
    that.updateProperty = function () {
        that.selectedEditProperty().ContractStartDate($("#ContractStartDatetxt").val());
        that.selectedEditProperty().ContractEndDate($("#ContractEndDatetxt").val());
        if (that.selectedEditProperty().modelState.isValid() && that.locationModelState.isValid()) {
            that.isBusy(true);
            if (that.selectedEditProperty().IsRent() === false) {
                that.selectedEditProperty().RentAmount(null);
                that.selectedEditProperty().Deposit(null);
                that.selectedEditProperty().RentalTerms(null);
            }
            if (that.selectedEditProperty().IsSale() === false) {
                that.selectedEditProperty().ExpectedPrice(null);
                that.selectedEditProperty().PropertyMeasurementUnit(null);
                that.selectedEditProperty().SalesTerms(null);
            }
            if (that.isMultiUnitIsNo() === false) {
                that.selectedEditProperty().FurnishType(null);
            }
            if (that.isMultiUnitIsNo() === false) {
                that.selectedEditProperty().FurnishType(null);
            }
            if (that.selectedEditProperty().IsParking() === false) {
                that.selectedEditProperty().ParkingNumber(null);
            }
            that.selectedEditProperty().MultipleUnit(ko.toJS(that.editMultipleUnit));
            var propertyJson = ko.toJS(that.selectedEditProperty());

            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.propertyManageUpdateProperty), propertyJson);
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
            that.selectedEditProperty().showErrors();
            that.locationShowErrors();
        }  
    };
    that.removeProperty = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Property " + item.PropertyName(), function (result) {
            if (result) {
                var isDeleted = propznetSuite.dataManager.postData(ko.toJS(that.url.propertyManageDeleteProperty) + item.Id());
                isDeleted.done(function (data) {
                    that.properties.remove(item);
                });
            }
        });
    };
    that.clear = function () {
        that.selectedAminity().Name('');
        that.selectedAminity().resetValidation();
    };
}