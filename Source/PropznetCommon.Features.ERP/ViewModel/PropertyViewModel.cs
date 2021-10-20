using PropznetCommon.Features.ERP.Entities.Enum;
using System;
using System.Collections.Generic;
namespace PropznetCommon.Features.ERP.ViewModel
{
    public class PropertyViewModel
    {
        public long Id { get; set; }
        public string PropertyName { get; set; }
        public long? PortfolioId { get; set; }
        public string PropertyFor { get; set; }
        public bool IsRent { get; set; }
        public bool IsSale { get; set; }
        public bool IsBuild { get; set; }
        public bool IsLand { get; set; }
        public bool IsParking { get; set; }
        public int ParkingNumber { get; set; }
        public string PropertyType { get; set; }  
        public string MultipleUnit { get; set; }
        public int Floor { get; set; }
        public string UsageType { get; set; }
        public long ListedBy { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }             
        public long TotalArea { get; set; }
        public string TotalAreaMeasurementUnit { get; set; }        
        public long BuildUpArea { get; set; }
        public string BuildUpAreaMeasurementUnit { get; set; }
        //public long RentId { get; set; }
        //public double RentAmount { get; set; }
        //public double Deposit { get; set; }
        //public string RentalTerms { get; set; }        
        public IList<RentInfoViewModel> RentInfoViewModel { get; set; }
        public Vaccancy RentAvailable { get; set; }
        public long SaleId { get; set; }
        public bool HasSaleCommission { get; set; }
        public string GLAccount { get; set; }
        public SalesCommissionType SalesCommissionType { get; set; }
        public double SaleCommissionAmount { get; set; }
        public long ExpectedPrice { get; set; }
        public int NoOfBed { get; set; }
        public int NoOfBath { get; set; }
        public int FloorNumber { get; set; }
        public bool IsExpectedPrice { get; set; }
        public long SourceType { get; set; }
        public string PropertyMeasurementUnit { get; set; }
        public string SalesTerms { get; set; }
        public long CommunicationDetailsId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long CountryId { get; set; }
        public string State { get; set; }
        public long Zip { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public bool Status { get; set; }
        public bool Availability { get; set; }
        public string Description { get; set; }
        public string CommissionType { get; set; }
        public double SalesCommission { get; set; }
        public string Area { get; set; }
        public string Vaccancy { get; set; }
        public string FurnishType { get; set; }
        public long CreatedBy { get; set; }
        public bool IsSaleCommission { get; set; }
    }
} 