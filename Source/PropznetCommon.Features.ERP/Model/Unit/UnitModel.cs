using System;
using PropznetCommon.Features.ERP.Entities.Enum;
using PropznetCommon.Features.ERP.ViewModel;
using PropznetCommon.Features.ERP.Model.RentInfo;
using System.Collections.Generic;

namespace PropznetCommon.Features.ERP.Model.Unit
{
    public class UnitModel
    {
        public long Id { get; set; }
        public string UnitName { get; set; }
        public string UnitType { get; set; }
        public long PropertyId { get; set; }
        public string UsageType { get; set; }
        public ERPPropertyCategory Category { get; set; }
        public long UnitTypeId { get; set; }
        public ListingType UnitFor { get; set; }
        public bool IsRent { get; set; }
        public bool IsSale { get; set; }
        public bool IsRentalCommission { get; set; }
        public bool IsManagementCommission { get; set; }
        public bool IsLeasingTax { get; set; }
        public long ListedBy { get; set; }
        public int Floor { get; set; }
        public long TotalArea { get; set; }
        public int ParkingNumber { get; set; }
        public MeasurementUnit TotalAreaMeasurementUnit { get; set; }
        public int Bed { get; set; }
        public int Bath { get; set; }
        public int TotalFloors { get; set; }
        public long BuildUpArea { get; set; }
        public MeasurementUnit BuildUpAreaMeasurementUnit { get; set; }
        public bool ParkingAvailable { get; set; }
        public FurnishType FurnishType { get; set; }
        //public long RentInfoId { get; set; }
        //public long ChargeId { get; set; }
        //public int RentMonth { get; set; }
        //public double RentAmount { get; set; }
        //public bool Supress { get; set; }
        public IList<RentInfoModel> RentInfoModels { get; set; }
        public Vaccancy RentAvailable { get; set; }
        public bool MultipleUnit { get; set; }
        public RentalTerm RentalTerms { get; set; }
        public long SaleInfoId { get; set; }
        public bool HasSaleCommission { get; set; }
        public string GLAccount { get; set; }
        public SalesCommissionType SalesCommissionType { get; set; }
        public double SaleCommissionAmount { get; set; }
        public double ExpectedPrice { get; set; }
        public string SalesTemrs { get; set; }
        public MeasurementUnit SalePriceMeasurementUnit { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public long CountryId { get; set; }
        public long CommunicationDetailId { get; set; }
        public string Area { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public long Zip { get; set; }
        public ERPCommissionType CommissionType { get; set; }
        public double SalesCommission { get; set; }
        public Vaccancy Vaccancy { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
        public UnitModel() { }
        public UnitModel(UnitViewModel vm)
        {
            RentInfoModels = new List<RentInfoModel>();
            Id = vm.Id;
            UnitName = vm.UnitName;
            PropertyId = vm.PropertyId;
            UnitTypeId = vm.UnitTypeId;
            //RentInfoId = vm.RentId;
            SaleInfoId = vm.SaleId;
            CommunicationDetailId = vm.CommunicationDetailId;
            if(vm.IsRent)
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
            MultipleUnit = vm.MultipleUnit;
            Floor = vm.Floor;
            if (!string.IsNullOrEmpty(vm.Category))
                Category = (ERPPropertyCategory)Enum.Parse(typeof(ERPPropertyCategory), vm.Category);
            ListedBy = vm.ListedBy;
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

            if (!string.IsNullOrEmpty(vm.RentalTerms))
            RentalTerms = (RentalTerm)Enum.Parse(typeof(RentalTerm), vm.RentalTerms);
            ExpectedPrice = vm.ExpectedPrice;
            SalesTemrs = vm.SalesTerms;
            if (!string.IsNullOrEmpty(vm.PropertyMeasurementUnit))
            SalePriceMeasurementUnit = (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), vm.PropertyMeasurementUnit);
            Address = vm.Address;
            CountryId = vm.CountryId;
            State = vm.State;
            Bath = vm.NoOfBath;
            Bed = vm.NoOfBed;
            City = vm.City;
            Area = vm.Area;
            
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
            ParkingAvailable = vm.IsParking;
            ParkingNumber = vm.ParkingNumber;
            TotalFloors = vm.TotalFloors;
        }
    }
}
