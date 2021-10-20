using System;
using System.Globalization;
using PropznetCommon.Features.ERP.Entities.Enum;
using PropznetCommon.Features.ERP.ViewModel;
using PropznetCommon.Features.ERP.Model.RentInfo;
using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.Model.Property
{
    public class PropertyModel
    {
        public long Id { get; set; }
        public string PropertyName { get; set; }
        public long? PortfolioId { get; set; }
        public ListingType PropertyFor { get; set; }
        public ERPPropertyType PropertyType { get; set; }
        public bool MultipleUnit { get; set; }
        public int Floor { get; set; }
        public int FloorNumber { get; set; }
        public ERPPropertyCategory UsageType { get; set; }
        public long ListedBy { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public long TotalArea { get; set; }
        public MeasurementUnit TotalAreaMeasurementUnit { get; set; }
        public long BuildUpArea { get; set; }
        public MeasurementUnit BuildUpAreaMeasurementUnit { get; set; }
        public int Bed { get; set; }
        public int Bath { get; set; }
        public bool Parking { get; set; }
        public bool IsParking { get; set; }
        public bool IsRent { get; set; }
        public bool IsSale { get; set; }
        public bool IsRentalCommission { get; set; }
        public bool IsManagementCommission { get; set; }
        public bool IsLeasingTax { get; set; }
        public int? NoOfParkingAvailable { get; set; }
        public FurnishType Furnished { get; set; }
        //public long RentInfoId { get; set; }
        //public long ChargeId { get; set; }
        //public int Month { get; set; }
        //public double RentAmount { get; set; }
        //public bool Supress { get; set; }
        public IList<RentInfoModel> RentInfoModels { get; set; }
        public Vaccancy RentAvailable { get; set; }
        public long SaleId { get; set; }
        public bool HasSaleCommission { get; set; }
        public string GLAccount { get; set; }
        public SalesCommissionType SalesCommissionType { get; set; }
        public double SaleCommissionAmount { get; set; }
        public double ExpectedPrice { get; set; }
        public string SalesTemrs { get; set; }
        public MeasurementUnit SalePriceMeasurementUnit { get; set; }
        public long CommunicationDetailId { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public long CountryId { get; set; }
        public string Area { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public long Zip { get; set; }
        public Vaccancy Vaccancy { get; set; }
        public FurnishType FurnishType { get; set; }
        public string Description { get; set; }
        public ERPCommissionType CommissionType { get; set; }
        public double? SalesCommission { get; set; }
        public long MarketingInformationId { get; set; }
        public long CreatedBy { get; set; }
        public PropertyModel() { }
        public PropertyModel(PropertyViewModel vm)
        {
            Id = vm.Id;
            PropertyName = vm.PropertyName;
            if (vm.PortfolioId.HasValue)
            PortfolioId = vm.PortfolioId.Value;
            SaleId = vm.SaleId;
            RentInfoModels = new List<RentInfoModel>();
            if (vm.IsRent)
                IsRent = true;
            if (vm.IsSale)
            {
                IsSale = true;
                ExpectedPrice = vm.ExpectedPrice;
                SalesTemrs = vm.SalesTerms;
                HasSaleCommission = vm.HasSaleCommission;
                SalesCommissionType = vm.SalesCommissionType;
                SaleCommissionAmount = vm.SaleCommissionAmount;
                GLAccount = vm.GLAccount;
            }
            if (vm.IsLand)
                PropertyType = ERPPropertyType.Land;
            if (vm.IsBuild)
                PropertyType = ERPPropertyType.Building;
            if(vm.MultipleUnit=="Yes")
            MultipleUnit = true ;
            else
                MultipleUnit = false;
            Floor = vm.Floor;
            if (!string.IsNullOrEmpty(vm.UsageType))
                UsageType = (ERPPropertyCategory)Enum.Parse(typeof(ERPPropertyCategory), vm.UsageType);
            ListedBy = vm.ListedBy;
           // if (!string.IsNullOrEmpty(vm.ContractStartDate))
            ContractStartDate = vm.ContractStartDate;//DateTime.ParseExact(vm.ContractStartDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
           // if (!string.IsNullOrEmpty(vm.ContractEndDate))
            ContractEndDate = vm.ContractEndDate;//DateTime.ParseExact(vm.ContractEndDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            TotalArea = vm.TotalArea;
            if (!string.IsNullOrEmpty(vm.TotalAreaMeasurementUnit))
                TotalAreaMeasurementUnit = (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), vm.TotalAreaMeasurementUnit);
            BuildUpArea = vm.BuildUpArea;
            if (!string.IsNullOrEmpty(vm.BuildUpAreaMeasurementUnit))
                BuildUpAreaMeasurementUnit = (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), vm.BuildUpAreaMeasurementUnit);
            if (vm.RentInfoViewModel != null)
            {
                foreach (var item in vm.RentInfoViewModel)
                {
                    var rentInfoModel = new RentInfoModel
                    {
                        Amount = item.Amount,
                        ChargeId = item.ChargeId,
                        CreatedBy = vm.CreatedBy,
                        Month = item.Month,
                        Supress = item.Supress
                    };
                    RentInfoModels.Add(rentInfoModel);
                }
            }

            if (!string.IsNullOrEmpty(vm.PropertyMeasurementUnit))
                SalePriceMeasurementUnit = (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), vm.PropertyMeasurementUnit);
            CommunicationDetailId = vm.CommunicationDetailsId;
            Address = vm.Address;
            CountryId = vm.CountryId;
            State = vm.State;
            City = vm.City;
            Area = vm.Area;
            Latitude = vm.Latitude;
            Longitude = vm.Longitude;
            RentAvailable = vm.RentAvailable;
            Bath = vm.NoOfBath;
            Bed = vm.NoOfBed;
            HasSaleCommission = vm.IsSaleCommission;
            Zip = vm.Zip;
            if (!string.IsNullOrEmpty(vm.Vaccancy))
                Vaccancy = (Vaccancy)Enum.Parse(typeof(Vaccancy), vm.Vaccancy);
            if (!string.IsNullOrEmpty(vm.FurnishType))
                FurnishType = (FurnishType)Enum.Parse(typeof(FurnishType), vm.FurnishType);
            Description = vm.Description;
            if (!string.IsNullOrEmpty(vm.CommissionType))
                CommissionType = (ERPCommissionType)Enum.Parse(typeof(ERPCommissionType), vm.CommissionType);
            SalesCommission = vm.SalesCommission;
            CreatedBy = vm.CreatedBy;
            IsParking = vm.IsParking;
            NoOfParkingAvailable = vm.ParkingNumber;
        }
    }
}