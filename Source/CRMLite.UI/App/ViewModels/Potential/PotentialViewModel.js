function PotentialViewModel() {
    var self = this;
    self.url = urls.CRM;
    var editedState = '';
    var editedCity = '';
    self.DisplayTitle = ko.observable();
    self.busy = ko.observable();
    self.PotentialLists = ko.observableArray();
    self.Contacts = ko.observableArray();
    self.Leadsource = ko.observableArray();
    self.Leadstatus = ko.observableArray();
    self.Salesstage = ko.observableArray();
    self.propertytype = ko.observableArray();
    self.propertycategories = ko.observableArray();
    self.aminityList = ko.observableArray();
    self.locations = ko.observableArray();
    self.propertyLists = ko.observableArray();
    self.assignProperty = ko.observableArray();
    self.propertyId = ko.observableArray();
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.initialStage = ko.observable(false);
    self.initialCityStage = ko.observable(false);
    self.Cities = ko.observableArray();
    self.States = ko.observableArray();
    self.Countries = ko.observableArray();
    self.Countries = ko.observableArray();
    self.states = ko.observableArray();
    self.User = ko.observableArray();
    self.Account = ko.observableArray();
    self.SearchPropertyType = ko.observable();
    self.SearchUser = ko.observable();
    self.SearchLeadSource = ko.observable();
    self.SearchSalesStage = ko.observable();
    self.isBusy = ko.observable(false);
    self.SelectedContact = ko.observable(new Contact({}));
    self.selectedCountry = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    self.selectedState = ko.observable().extend({ required: { params: true, message: "Please Select State" } });
    self.SelectedPotential = ko.observable(new Potential({}));
    self.SelectedAccount = ko.observable(new Account({}));
    self.potentialdelete = function (item) {
        bootbox.confirm("Do you want to delete this Potential?", function (result) {
            if (result) {
                $.post(ko.toJS(self.url.potentialapiDeletePotential) + item.Id(), function (response) {
                    if (response) {
                        bootbox.alert("Deleted Successfully..!!", function () {
                            window.location.href = ko.toJS(self.url.potentialIndex);
                        });
                    }
                    else {
                        bootbox.alert("Error Please Try Again Later ..!!");
                    }
                });
            }
        });
    };
 
    self.addProperties = function () {
        self.assignProperty.removeAll();
        self.propertyId.removeAll();
        $.each(self.propertyLists(), function (k, v) {
            if (v.IsSelect() === true) {
                self.assignProperty.push(v);
                self.propertyId.push(v.Id());
            }
        });
    };
    self.removeAssignProperty = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Property " + item.PropertyName(), function (result) {
            if (result) {
                self.assignProperty.remove(item);
                self.propertyId.remove(item.Id());
            }
        });

    };
    self.saveMorePotential = function () {
        if (self.modelState.isValid()) {
            self.busy(true);
            $.each(self.aminityList(), function (k, v) {
                if (v.IsSelectAmenity()) {
                    self.aminityId.push(v.Id);
                }
            });
            var id = $("#hdnPotentialId").val();
            var potentialJson = {
                PotentialId: id, PropertiesId: ko.toJS(self.propertyId), AminityId: ko.toJS(self.aminityId)
            };
            var result = CRMLite.dataManager.postData(ko.toJS(self.url.potentialCreateMorePotential), potentialJson);
            result.done(function (data) {

                self.busy(false);
            });
        }
    };
    self.getEditPage = function (item) {
        var self = this;
        self.CRMUrl = urls.CRM;
        window.location.href = ko.toJS(self.CRMUrl.potentialEdit) + item.Id();
    };
    self.potentialedit = function (item) {

        function toggleChevron(e) {
            $(e.target)
                .prev('.panel-heading')
                .find("i.indicator")
                .toggleClass('glyphicon-chevron-down glyphicon-chevron-up');
        }
        $('#accordion').on('hidden.bs.collapse', toggleChevron);
        $('#accordion').on('shown.bs.collapse', toggleChevron);
        self.isCreate(false);
        self.isUpdate(true);
        var potentialIdValue = $("#hdnPotentialId").data('value');    

        $.get(ko.toJS(self.url.potentialapiGetPotential) + potentialIdValue, function (data) {
            self.initialStage(true);
            self.SelectedPotential(new Potential(data.Potential));
            self.selectedCountry(data.Potential.Property.City.State.CountryId);
            editedState = ko.toJS(self.SelectedPotential().StateId);
            editedCity = ko.toJS(data.CityId);
            $("#AccountSelect").select2();
        });

    };
    self.gotoPotentialdetails = function (item) {
        window.location.href = ko.toJS(self.url.gotoPotentialdetails) + item.Id();
    };
    self.potentialdetail = function () {
        var id = $("#hdnPotentialId").val();
        $.get(ko.toJS(self.url.potentialapiDetails) + id, function (data) {
            self.SelectedPotential(new Potential(data));
        });
    };
    self.selectedCountry.subscribe(function (newValue) {
        // self.resetValidation();
        if (ko.toJS(self.selectedCountry) != null) {
            var result = CRMLite.dataManager.postData(ko.toJS(self.url.potentialapiGetAllStates) + ko.toJS(self.selectedCountry()));
            result.done(function (data) {
                self.States.removeAll();
                self.Cities.removeAll();
                $.each(data, function (k, v) {
                    self.States.push(v);
                });
                if (self.initialStage()) {
                    self.initialCityStage(true);
                    self.selectedState(editedState);
                }
                else {
                    self.selectedState('');
                    self.SelectedPotential().CityId('');
                }
                self.initialStage(false);
            });
        }
    });
    self.selectedState.subscribe(function () {
        //self.resetValidation();
        if (ko.toJS(self.selectedState)) {
            var result = CRMLite.dataManager.postData(ko.toJS(self.url.potentialapiGetAllCities) + ko.toJS(self.selectedState));
            result.done(function (data) {
                self.Cities.removeAll();
                $.each(data, function (k, v) {
                    self.Cities.push(v);
                });
                if (self.initialCityStage())
                    self.SelectedPotential().CityId(editedCity);
                else {

                    self.SelectedPotential().CityId('');

                }
                self.initialCityStage(false);
            });
        }
    });
};
PotentialViewModel.prototype.init = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.isBusy(true);
    self.SelectedPotential().resetValidation();
    $.get(ko.toJS(self.url.potentialapiGetAllPotential), function (response) {

        if (response.Status === false) {
            if (response.Code === 401) {
                window.location.href = ko.toJS(self.url.errorNotAuthorized);
            }
            else {
                bootbox.alert(response);
            }
        } else {
            if (response) {

                $.each($.parseJSON(response.Potential), function (key, value) {
                    self.PotentialLists.push(new Potential(value));

                });
            }
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            var oTable = $('#pagination').dataTable();
            //oTable.fnSort([[6, 'desc']]);
            $.each(response.Contacts, function (k, v) {
                self.Contacts.push(new Contact(v));
            });
            $.each(response.LeadSource, function (k, v) {
                self.Leadsource.push(new SelectLeadSource(v));
            });
            $.each(response.Accounts, function (k, v) {
                self.Account.push(new SelectAccount(v));
            });
            $.each(response.SalesStage, function (k, v) {
                self.Salesstage.push(new SelectLeadStatus(v));
            });
            $.each(response.Users, function (k, v) {
                self.User.push(new SelectAssignedTo(v));
            });
            $.each(response.Propertytype, function (k, v) {
                self.propertytype.push(new PropertyType(v));
            });
            $.each(response.States, function (k, v) {
                self.states.push(new State(v));
            });
            $.each(response.Category, function (k, v) {
                self.propertycategories.push(new PropertyCategory(v));
            });
            $.each(response.Countries, function (k, v) {
                self.Countries.push(new Country(v));
            });
            
        }
        $("#AccountSelect").select2();
        self.isBusy(false);
    });
};
PotentialViewModel.prototype.gotoPotentialPage = function () {
    var self = this;
    self.CRMUrl = urls.CRM;
    window.location.href = ko.toJS(self.CRMUrl.potentialCreate);
};
PotentialViewModel.prototype.savePotential = function () {
    var self = this;
    self.SelectedPotential().resetValidation();

    self.SelectedPotential().ExpectedCloseDate($("#ExpectedDate").val());
    self.SelectedPotential().ExpectedMoveInDate($("#ExpectedMoveInDate").val());
    if (self.SelectedPotential().modelState.isValid()) {
      
        self.busy(true);
        var jsonData = ko.toJS(self.SelectedPotential());
        var result = $.post(ko.toJS(self.url.potentialapiCreatePotential), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                bootbox.alert("Saved successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.potentialIndex);
                });
            }
            else {

                bootbox.alert("Error occured");
            }
        });
    }
    else {
        self.SelectedPotential().modelState.errors.showAllMessages();
    }

};
PotentialViewModel.prototype.updatePotential = function () {
    var self = this;
    self.SelectedPotential().resetValidation();
    if (self.SelectedPotential().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.SelectedPotential());
        var result = $.post(ko.toJS(self.url.potentialapiUpdatePotential), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                bootbox.alert("Updated successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.potentialIndex);
                });
            }
            else {

                bootbox.alert("Error occured");
            }
        });
    }
    else {
        self.SelectedPotential().modelState.errors.showAllMessages();
    }
};
PotentialViewModel.prototype.CreateAccount = function () {
    var self = this;
    self.SelectedAccount().resetValidation();
    if (self.SelectedAccount().modelState.isValid()) {
        self.busy(true);
        var jsonData = ko.toJS(self.SelectedAccount());
        var result = $.post(ko.toJS(self.url.accountapiCreateAccount), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                //bootbox.alert("Saved successfully...!!", function () {
                //    //window.location.href = "/Potential/Index";
                //});
                bootbox.alert("Saved successfully...!!");
            }
            else {

                bootbox.alert(response);
            }
        });
    }
    else {
        self.SelectedAccount().modelState.errors.showAllMessages();
    }

};
PotentialViewModel.prototype.search = function () {
    var self = this;
    var oldTable = $("#pagination").DataTable();
    oldTable
      .clear()
      .draw();
    oldTable.destroy();
    var jsonData = { SalesStageId: ko.toJS(self.SearchSalesStage), PropertyTypeId: ko.toJS(self.SearchPropertyType), LeadSourceId: ko.toJS(self.SearchLeadSource), UserId: ko.toJS(self.SearchUser) };
    //alert(JSON.stringify(jsonData))
    $.get(ko.toJS(self.url.potentialapiSearch), jsonData, function (response) {
        self.PotentialLists.removeAll();
        $.each($.parseJSON(response), function (key, value) {
            self.PotentialLists.push(new Potential(value));
        });
        $("#pagination").DataTable({ responsive: true });
    });
};
PotentialViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.DisplayTitle('Create Potential');
    self.SelectedPotential(new Potential({}));
    self.SelectedPotential().resetValidation();
    function toggleChevron(e) {
        $(e.target)
            .prev('.panel-heading')
            .find("i.indicator")
            .toggleClass('fa fa-chevron-down fa fa-chevron-up');
    }
    $('#accordion').on('hidden.bs.collapse', toggleChevron);
    $('#accordion').on('shown.bs.collapse', toggleChevron);
    $("#AccountSelect").select2();
};
PotentialViewModel.prototype.ToDo = function (item) {
    var self = this;
    self.url = urls.CRM;
    window.location.href = ko.toJS(self.url.fullCalenderIndexentityTypePotential) + ko.toJS(item.Id);
}

