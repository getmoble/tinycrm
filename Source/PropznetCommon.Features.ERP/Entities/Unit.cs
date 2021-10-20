using System.ComponentModel.DataAnnotations.Schema;
using Common.Auth.SingleTenant.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Unit : ERPEntityBase
    {
        public string Name { get; set; }
        public ERPPropertyCategory Category { get; set; }
        public ListingType UnitFor { get; set; }
        public int FloorNo { get; set; }
        public long TotalArea { get; set; }
        public MeasurementUnit MeasurementUnitForTotalArea { get; set; }
        public int TotalFloors { get; set; }
        public long BuildUpArea { get; set; }
        public MeasurementUnit MeasurementUnitForBuiltUpArea { get; set; }
        public bool ParkingAvailable { get; set; }
        public int? ParkingNumber { get; set; }
        public FurnishType Furnished { get; set; }
        public int NoOfBed { get; set; }
        public int NoOfBath { get; set; }
        public ERPCommissionType CommissionType { get; set; }
        public double SalesCommission { get; set; }
        public Vaccancy Vacccancy { get; set; }
        public string Description { get; set; }

        public long UnitTypeId { get; set; }
        [ForeignKey("UnitTypeId")]
        public UnitType UnitType { get; set; }
        public long PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public virtual ERPProperty Property { get; set; }
        public long ListedBy { get; set; }
        [ForeignKey("ListedBy")]
        public User User { get; set; }
        public long? SaleId { get; set; }
        [ForeignKey("SaleId")]
        public virtual UnitSaleInfo Sale { get; set; }
        public long CommunicationDetailId { get; set; }
        [ForeignKey("CommunicationDetailId")]
        public virtual ERPCommunicationDetail CommunicationDetails { get; set; }
    }
}