using PropznetCommon.Features.ERP.Entities.Enum;
using System.Collections.Generic;
namespace PropznetCommon.Features.ERP.ViewModel
{
    public class UnitViewModel
    {
        public long Id { get; set; }
        public string UnitName { get; set; }
        public long PropertyId { get; set; }
        public long UnitTypeId { get; set; }
        public bool IsRent { get; set; }
        public bool IsSale { get; set; }
        public long RentId { get; set; }
        public long SaleId { get; set; }
        public bool HasSaleCommission { get; set; }
        public string GLAccount { get; set; }
        public SalesCommissionType SalesCommissionType { get; set; }
        public double SaleCommissionAmount { get; set; }
        public string PropertyType { get; set; }
        public string Category { get; set; }
        public bool MultipleUnit { get; set; }
        public int Floor { get; set; }
        public int TotalFloors { get; set; }
        public bool IsParking { get; set; }
        public int ParkingNumber { get; set; }
        public string UsageType { get; set; }
        public long ListedBy { get; set; }
        public long TotalArea { get; set; }
        public string TotalAreaMeasurementUnit { get; set; }
        public long BuildUpArea { get; set; }
        public string BuildUpAreaMeasurementUnit { get; set; }
        public IList<RentInfoViewModel> RentInfoViewModel { get; set; }
        public int NoOfBed { get; set; }
        public int NoOfBath { get; set; }
        public double RentAmount { get; set; }
        public double Deposit { get; set; }
        public string RentalTerms { get; set; }
        public long ExpectedPrice { get; set; }
        public string PropertyMeasurementUnit { get; set; }
        public string SalesTerms { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long CountryId { get; set; }
        public string State { get; set; }
        public long Zip { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string CommissionType { get; set; }
        public double SalesCommission { get; set; }
        public string Area { get; set; }
        public string Vaccancy { get; set; }
        public string FurnishType { get; set; }
        public long CreatedBy { get; set; }
        public long CommunicationDetailId { get; set; }
    }
}
