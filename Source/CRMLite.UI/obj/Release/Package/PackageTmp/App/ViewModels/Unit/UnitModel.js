function Unit(unit) {
    var that = this;
    that.modelState = ko.validatedObservable();
    that.isValid = function () {
        return that.modelState.isValid();
    };
    that.showErrors = function () {

        that.modelState.errors.showAllMessages(true);
    };
    that.Id = ko.observable(unit.Id);
    that.UnitName = ko.observable(unit.UnitName).extend({ required: { params: true, message: "Please Enter Unit Name" } });
    that.UnitTypeId = ko.observable(unit.UnitTypeId);
    that.UnitType = ko.observable(); 
    that.PropertyId = ko.observable(unit.PropertyId).extend({ required: { params: true, message: "Please Select Property" } });
    that.PropertyName = ko.observable();
    that.Category = ko.observable();
    that.IsRent = ko.observable();
    that.SourceType = ko.observable(unit.SourceType);
    that.IsSale = ko.observable();
    that.RentId = ko.observable();
    that.SaleId = ko.observable();
    that.ListedBy = ko.observable(unit.ListedBy).extend({ required: { params: true, message: "Please Select Listed By" } });
    that.Floor = ko.observable(unit.FloorNo);
    that.IsExpectedPrice = ko.observable(false);
    that.NoOfBed = ko.observable(unit.NoOfBed);
    that.NoOfBath = ko.observable(unit.NoOfBath);
    that.Availability = ko.observable(unit.Availability);
    that.GLAccount = ko.observable(unit.GLAccount);
    that.TotalFloors = ko.observable(unit.TotalFloors);
    that.MultipleUnit = ko.observable(unit.MultipleUnit);
    that.FurnishType = ko.observable(unit.FurnishType);
    that.TotalArea = ko.observable(unit.TotalArea);
    that.TotalAreaMeasurementUnit = ko.observable(unit.TotalAreaMeasurementUnit);
    that.BuildUpArea = ko.observable(unit.BuildUpArea);
    that.BuildUpAreaMeasurementUnit = ko.observable(unit.BuildUpAreaMeasurementUnit);
    that.IsParking = ko.observable(false);
    that.Parking = ko.observable(unit.Parking);
    that.ParkingNumber = ko.observable(unit.ParkingNumber);
    that.RentAmount = ko.observable(unit.RentAmount);
    that.Deposit = ko.observable(unit.Deposit);
    that.RentalTerms = ko.observable(unit.RentalTerms);
    that.ExpectedPrice = ko.observable(unit.ExpectedPrice);
    that.PropertyMeasurementUnit = ko.observable(unit.PropertyMeasurementUnit);
    that.SalesTerms = ko.observable(unit.SalesTerms);
    that.Address = ko.observable(unit.Address);
    that.CityId = ko.observable().extend({ required: { params: true, message: "Please Select City" } });
    that.StateId = ko.observable()
    that.CountryId = ko.observable()
    that.Zip = ko.observable(unit.Zip);
    that.Area = ko.observable(unit.Area);
    that.Vaccancy = ko.observable(unit.Vaccancy);
    that.Description = ko.observable(unit.Description);
    that.IsSelect = ko.observable();
    that.CommunicationDetailId = ko.observable();
    that.IsRentalCommission = ko.observable(unit.IsRentalCommission);
    that.IsManagementCommission = ko.observable(unit.IsManagementCommission);
    that.IsLeasingTax = ko.observable(unit.IsLeasingTax);
    that.CommissionType = ko.observable(unit.CommissionType);
    that.SalesAmount = ko.observable(unit.SalesAmount);
    that.RentInfoViewModel = ko.observableArray();
    that.Parking.subscribe(function (val) {
        if (val == "Yes") {
            that.IsParking(true);
        }
        else {
            that.IsParking(false);
        }
    });
    if (ko.toJS(unit.ParkingAvailable) == false) {
        that.Parking('No');
    }
    else if (ko.toJS(unit.ParkingAvailable) == true) {
        that.Parking('Yes');
    }
    if (unit.CommunicationDetails) {
        that.CommunicationDetailId(unit.CommunicationDetails.Id);
        that.Address(unit.CommunicationDetails.Address);
        that.Zip(unit.CommunicationDetails.Zip);
        that.Area(unit.CommunicationDetails.Area);
        if (unit.CommunicationDetails.City) {
            that.CityId(unit.CommunicationDetails.CityId);
            that.StateId(unit.CommunicationDetails.City.StateId);
            that.CountryId(unit.CommunicationDetails.City.State.CountryId);
        }
    }
    if (unit.UnitType)
        that.UnitType(unit.UnitType.Name);
    if (unit.Property)
        that.PropertyName(unit.Property.PropertyName);
    if (ko.toJS(unit.Category) == '0')
        that.Category('Residential');
    if (ko.toJS(unit.Category) == '1')
        that.Category('Commercial');
    if (unit.City) {
        that.CityId(unit.CommunicationDetails.City.Id);
        that.StateId(unit.CommunicationDetails.City.State.Id);
        that.CountryId(unit.CommunicationDetails.City.State.Country.Id);
    }
    if (unit.Furnished == '0')
        that.FurnishType('Fully Furnished');
    if (unit.Furnished == '1')
        that.FurnishType('Partially Furnished');
    if (unit.Furnished == '2')
        that.FurnishType('Not Furnished');
    if (unit.Rent == true) {
        that.RentAmount(unit.Rent.RentAmount);
        that.Deposit(unit.Rent.Deposit);
        if (unit.RentalTerms == '0')
            that.RentalTerms('Month');
        if (that.RentalTerms == '1')
            that.RentalTerms('Week');
        if (that.RentalTerms == '2')
            that.RentalTerms('Night');
        if (that.RentalTerms == '3')
            that.RentalTerms('SqftperMonth');
        if (that.RentalTerms == '4')
            that.RentalTerms('SqftperYear');
        if (that.RentalTerms == '5')
            that.RentalTerms('SqmperMonth');
        if (that.RentalTerms == '6')
            that.RentalTerms('SqmperYear');

    }
    if (unit.Rent)
        that.IsRent(true);
    if (unit.Sale)
        that.IsSale(true);
    if (ko.toJS(unit.MultipleUnit) == true) {
        that.MultipleUnit('Yes')
    }
    if (ko.toJS(unit.MultipleUnit) == false) {
        that.MultipleUnit('No')
    }
        if (unit.Rent) {
            that.RentId(unit.Rent.Id);
            that.RentAmount(unit.Rent.RentAmount);
            that.Deposit(unit.Rent.Deposit);
            that.RentalTerms(unit.Rent.RentalTerms);
        }
        if (unit.Sale) {
            that.SaleId(unit.Sale.Id);
            that.ExpectedPrice(unit.Sale.ExpectedPrice);
            that.PropertyMeasurementUnit(unit.Sale.PropertyMeasurementUnit);
            that.SalesTerms(unit.Sale.SalesTerms);
        }
    that.modelState = ko.validatedObservable(
{
    UnitName: that.UnitName,
    PropertyId: that.PropertyId
});
}
function MultipleUnit(unit) {
    var that = this;
    that.Text = ko.observable(unit);
    that.Value = ko.observable(unit);
}
function SalesCommission(salesCommission) {
    var that = this;
    that.Id = ko.observable(salesCommission.Id);
    that.IsPercentage = ko.observable(salesCommission.IsPercentage);
    that.IsFlat = ko.observable(salesCommission.IsFlat);
    that.Comission = ko.observable(salesCommission.Comission);
}
function RentInfoViewModel(RentInfoViewModel) {
    var that = this;
    that.Id = ko.observable(RentInfoViewModel.Id || 0);
    that.Amount = ko.observable(RentInfoViewModel.Amount || "");
    that.Month = ko.observable(RentInfoViewModel.Month || "");
    that.Supress = ko.observable(RentInfoViewModel.Supress || "");
    that.ChargeId = ko.observable(RentInfoViewModel.ChargeId || "");
    that.IsDeleted = ko.observable(true);

}
function UnitRentalCommission(rentalCommission) {
    var that = this;
    that.Id = ko.observable(rentalCommission.Id || 0);
    that.GLAccount = ko.observable(rentalCommission.GLAccount || "");
    that.Type = ko.observable(rentalCommission.Type || "");
    that.Amount = ko.observable(rentalCommission.Amount || "");
    that.Month = ko.observable(rentalCommission.Month || "");
    that.Supress = ko.observable(rentalCommission.Supress || "");
    that.ChargeId = ko.observable(rentalCommission.ChargeId || "");
    that.IsDeleted = ko.observable(true);

}