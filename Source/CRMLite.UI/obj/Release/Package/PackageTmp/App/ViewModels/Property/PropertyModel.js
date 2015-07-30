function ModelBase() {
    var that = {};

    that.IsSelected = ko.observable(false);
    //that.dataManager = rapid.resolve("dataManager");
    that.parseDateForEdit = function (date) {
        if (date) {
            return new Date(date.match(/\d+/)[0] * 1);
        } else {
            return '';
        }
    };
    that.parseDate = function (date) {
        if (date) {
            var myDate = new Date(parseFloat(/Date\(([^)]+)\)/.exec(date)[1]));
            return myDate.getDate() + '/' + (myDate.getMonth() + 1) + '/'
+ myDate.getFullYear() + '  ' + myDate.getHours() + ':' + myDate.getMinutes() + ':'
+ myDate.getSeconds();
        } else {
            return '';
        }
    };
    that.parseDateOnly = function (date) {
        if (date) {
            var myDate = new Date(parseFloat(/Date\(([^)]+)\)/.exec(date)[1]));
            if (myDate.getDate() < 10) {
                datess = "0" + ko.toJSON(myDate.getDate());
            }
            else {
                datess = ko.toJSON(myDate.getDate());
            }
            if ((myDate.getMonth() + 1) < 10) {
                months = "0" + ko.toJSON(myDate.getMonth() + 1)
            }
            else {
                months = ko.toJSON(myDate.getMonth() + 1)
            }
            return datess + '/' + months + '/'
+ myDate.getFullYear();
        } else {
            return '';
        }
    };

    return that;
}
function Property(property) {
    var that = this;
    that.modelState = ko.validatedObservable();
    that.isValid = function () {
        return that.modelState.isValid();
    };
    that.showErrors = function () {

        that.modelState.errors.showAllMessages(true);
    };
    that.Id = ko.observable(property.Id);
    that.IsSelect = ko.observable();
    that.PropertyName = ko.observable(property.PropertyName).extend({ required: { params: true, message: "Please Enter Property Name" } });
    that.UsageType = ko.observable(property.UsageType);
    that.SourceType = ko.observable(property.SourceType);
    that.CategoryType = ko.observable(property.CategoryType);
    that.PortfolioId = ko.observable(property.PortfolioId).extend({ required: { params: true, message: "Please Select Portfolio" } });
    that.ListedBy = ko.observable(property.ListedBy).extend({ required: { params: true, message: "Please Select Listed By" } });
    that.PropertyFor = ko.observable().extend({ required: { params: true, message: "Please Select Property For" } });
    that.ContractStartDate = ko.observable(ModelBase().parseDateOnly(property.ContractStartDate || '')).extend({ required: { params: true, message: "Please Select Contract Start Date" } });
    that.ContractEndDate = ko.observable(ModelBase().parseDateOnly(property.ContractEndDate || '')).extend({ required: { params: true, message: "Please Select Contract End Date" } });
    that.PropertyType = ko.observable(property.PropertyType);
    that.IsBuilding = ko.observable(false);
    that.IsLand = ko.observable(false);
    that.IsExpectedPrice = ko.observable(false);
    that.NoOfBed = ko.observable(property.NoOfBed);
    that.NoOfBath = ko.observable(property.NoOfBath);
    that.FloorNumber = ko.observable(property.FloorNumber);
    that.MultipleUnit = ko.observable(property.MultipleUnit);
    that.FurnishType = ko.observable(property.FurnishType);
    that.Area = ko.observable(property.Area);
    that.TotalArea = ko.observable(property.TotalArea); 
    that.Parking = ko.observable(property.Parking);
    that.ParkingNumber = ko.observable(property.NoOfParkingAvailable);
    that.TotalAreaMeasurementUnit = ko.observable(property.TotalAreaMeasurementUnit);
    that.BuildUpArea = ko.observable(property.BuildUpArea);
    that.BuildUpAreaMeasurementUnit = ko.observable(property.BuildUpAreaMeasurementUnit);
    that.Floor = ko.observable(property.Floor);
    that.IsRent = ko.observable();
    that.IsSale = ko.observable();
    that.RentId = ko.observable(); 
    that.SaleId = ko.observable();
    that.CommissionType = ko.observable(property.CommissionType);
    that.GLAccount = ko.observable(property.GLAccount);
    that.RentAmount = ko.observable(property.RentAmount);
    that.Deposit = ko.observable(property.Deposit);
    that.RentalTerms = ko.observable(property.RentalTerms);
    that.SalesAmount = ko.observable(property.SalesAmount);
    that.ExpectedPrice = ko.observable(property.ExpectedPrice);
    that.PropertyMeasurementUnit = ko.observable(property.PropertyMeasurementUnit);
    that.SalesTerms = ko.observable(property.SalesTerms);
    that.Availability = ko.observable(property.Availability);
    that.CommunicationDetailsId = ko.observable();
    that.Address = ko.observable();
    that.Longitude =ko.observable();
    that.Latitude =ko.observable();
    that.CityId = ko.observable().extend({ required: { params: true, message: "Please Select City" } });
    that.StateId = ko.observable().extend({ required: { params: true, message: "Please Select State" } });
    that.CountryId = ko.observable().extend({ required: { params: true, message: "Please Select Country" } });
    that.Zip = ko.observable(property.Zip);
    that.Vaccancy = ko.observable(property.Vaccancy);
    that.Description = ko.observable(property.Description);
    that.IsParking = ko.observable(false);
    that.IsRentalCommission = ko.observable(property.IsRentalCommission);
    that.IsManagementCommission = ko.observable(property.IsManagementCommission);
    that.IsLeasingTax = ko.observable(property.IsLeasingTax);
    that.Portfolio = ko.observable();
    that.RentInfoViewModel = ko.observableArray();
    that.Parking.subscribe(function (val) {
        if (val === "Yes") {
     
            that.IsParking(true);
        }
        else {
            that.IsParking(false);
        }
    });
    if (ko.toJS(property.Parking) == false)
    {
        that.Parking('No');
    }
    else if (ko.toJS(property.Parking) == true) {
        that.Parking('Yes');
    }
    if (property.Portfolio)
    {
        that.Portfolio(property.Portfolio.Name);
    }
    if (property.CommunicationDetails) {
        that.CommunicationDetailsId(property.CommunicationDetails.Id);
        that.Address(property.CommunicationDetails.Address);
        that.Zip(property.CommunicationDetails.Zip);
        that.Area(property.CommunicationDetails.Area);
        if (property.CommunicationDetails.City) {
            that.CityId(property.CommunicationDetails.CityId);
            that.StateId(property.CommunicationDetails.City.StateId);
            that.CountryId(property.CommunicationDetails.City.State.CountryId);
        }
    }    
    
    if (property.IsForRent == true) {
        if (property.Rent)
        {
            that.PropertyFor('Rent');
            that.RentId(property.Rent.Id);
            that.RentAmount(property.Rent.RentAmount);
            that.Deposit(property.Rent.Deposit);
            that.RentalTerms(property.Rent.RentalTerms);
        }
    }
    if (property.IsForSale == true) {
        if (property.SaleInfo) {
            that.PropertyFor('Rent');
            that.SaleId(property.SaleInfo.Id);
            that.ExpectedPrice(property.SaleInfo.ExpectedPrice);
            that.PropertyMeasurementUnit(property.SaleInfo.PropertyMeasurementUnit);
            that.SalesTerms(property.SaleInfo.SalesTerms);
        }
    }
    if (property.IsForSale == true && property.IsForRent == true) {
        that.PropertyFor('Rent & Sale');
    }
    if (ko.toJS(property.PropertyType) == '0')
        that.IsBuilding('Building');
    if (ko.toJS(property.PropertyType) == '1')
        that.IsLand('Land');
    if (ko.toJS(property.IsForRent) == true)
        that.IsRent(true);
    if (ko.toJS(property.IsForSale) == true)
        that.IsSale(true);
    if (ko.toJS(property.MultipleUnit)==true)
    {
        that.MultipleUnit('Yes')
    }
    if (ko.toJS(property.MultipleUnit) == false) {
        that.MultipleUnit('No')
    }
    that.modelState = ko.validatedObservable(
{
    PropertyName: that.PropertyName,
    PortfolioId: that.PortfolioId,
    ContractStartDate:that.ContractStartDate,
    ContractEndDate: that.ContractEndDate
});
}
function MultipleUnit(unit) {
    var that = this;
    that.Text = ko.observable(unit);
    that.Value = ko.observable(unit);
}
function MarketingInformation(property)
{
    var that = this;
    that.SaleId = ko.observable();
    that.PropertyFor = ko.observable();
    that.IsRent = ko.observable();
    that.IsSale = ko.observable();
    that.SaleTitle = ko.observable();
    that.SaleDescription = ko.observable();
    that.SaleAdvertisingCost = ko.observable();
    that.SaleDisplayAmenities = ko.observable();
    that.SaleShowMap = ko.observable();
    that.SaleFeatured = ko.observable();
    that.ShowSales = ko.observable();
    that.SaleDisplayImages = ko.observable();
    that.RentTitle = ko.observable();
    that.RentDescription = ko.observable();
    that.RentAdvertisingCost = ko.observable();
    that.RentDisplayAmenities = ko.observable();
    that.RentShowMap = ko.observable();
    that.RentFeatured = ko.observable();
    that.RentShow = ko.observable();
    that.RentDisplayImages = ko.observable();

    if (property.SaleMarketingInformation) {
        that.IsSale(true);
        that.SaleTitle(property.SaleMarketingInformation.Title);
        that.SaleDescription(property.SaleMarketingInformation.Description);
        that.SaleAdvertisingCost(property.SaleMarketingInformation.AdvertisingCost);
        that.SaleDisplayAmenities(property.SaleMarketingInformation.DisplayAmenities);
        that.SaleShowMap(property.SaleMarketingInformation.ShowMap);
        that.SaleFeatured(property.SaleMarketingInformation.Featured);
        that.ShowSales(property.SaleMarketingInformation.ShowSalePrice);
        that.SaleDisplayImages(property.SaleMarketingInformation.DisplayImages);
    }
    if(property.RentMarketingInformation)
    {
        that.IsRent(true);
        that.RentTitle(property.RentMarketingInformation.Title);
        that.RentDescription(property.RentMarketingInformation.Description);
        that.RentAdvertisingCost(property.RentMarketingInformation.AdvertisingRent);
        that.RentDisplayAmenities(property.RentMarketingInformation.DisplayAmenities);
        that.RentShowMap(property.RentMarketingInformation.ShowMap);
        that.RentFeatured(property.RentMarketingInformation.Featured);
        that.RentShow(property.RentMarketingInformation.ShowRent);
        that.RentDisplayImages(property.RentMarketingInformation.DisplayImages);
    }
   
}
function SalesCommission(salesCommission) {
    var that = this;
    that.Id = ko.observable(salesCommission.Id);
    that.IsPercentage = ko.observable();
    that.Comission = ko.observable(salesCommission.Comission);
}
function Unit(unit) {
    var that = this;
    that.Id = ko.observable(unit.Id);
    that.UnitName = ko.observable(unit.UnitName);
    that.TotalFloors = ko.observable(unit.TotalFloors);
    that.BuildUpArea = ko.observable(unit.BuildUpArea);
    that.UnitFor = ko.observable(unit.UnitFor);
}
function RentInfoViewModel(rentInfoViewModel) {
    var that = this;
    that.Id = ko.observable(rentInfoViewModel.Id||0);
    that.Amount = ko.observable(rentInfoViewModel.Amount||"");
    that.Month = ko.observable(rentInfoViewModel.Month || "");
    that.Supress = ko.observable(rentInfoViewModel.Supress || "");
    that.ChargeId = ko.observable(rentInfoViewModel.ChargeId || "");
    that.IsDeleted = ko.observable(true);
    
}
function PropertyRentalCommission(rentalCommission) {
    var that = this;
    that.Id = ko.observable(rentalCommission.Id || 0);
    that.GLAccount= ko.observable(rentalCommission.GLAccount || "");
    that.Type = ko.observable(rentalCommission.Type || "");
    that.Amount = ko.observable(rentalCommission.Amount || "");
    that.Month = ko.observable(rentalCommission.Month || "");
    that.Supress = ko.observable(rentalCommission.Supress || "");
    that.ChargeId = ko.observable(rentalCommission.ChargeId || "");
    that.IsDeleted = ko.observable(true);
    
}

