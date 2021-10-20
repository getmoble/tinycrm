using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Auth.SingleTenant.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class ERPProperty : ERPEntityBase
    {
        public string Name { get; set; }
       // public ListingType PropertyFor { get; set; }
        public bool IsForRent { get; set; }
        public bool IsForSale { get; set; }
        public bool HasRentalCommission { get; set; }
        public bool HasManagementCommission { get; set; }
        public bool HasLeasingTax { get; set; }
        public bool HasSalesCommission { get; set; }
        public ERPPropertyType PropertyType { get; set; }  
        public bool IsMultipleUnit { get; set; }
        public int Floor { get; set; }
        public int FloorNumber{ get; set; }
        public ERPPropertyCategory UsageType { get; set; }
        public SourceType SourceType { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }             
        public long TotalArea { get; set; }
        public MeasurementUnit MeasurementUnitForTotalArea { get; set; }        
        public long BuildUpArea { get; set; }
        public int NoOfBed { get; set; }
        public int NoOfBath { get; set; }
        public bool Parking { get; set; }
        public int? NoOfParkingAvailable { get;set; }
        public FurnishType Furnished { get; set; }
        public MeasurementUnit MeasurementUnitForBuiltupArea { get; set; }
        public Vaccancy RentAvailablity { get; set; }
        public Vaccancy Vaccancy { get; set; }
        public string Description { get; set; }
        public ERPCommissionType CommissionType { get; set; }
        public double SalesCommission { get; set; }
        public long? RentMarketingInformationId { get; set; }
        [ForeignKey("RentMarketingInformationId")]
        public virtual RentMarketingInformation RentMarketingInformation { get; set; }
        public long? SaleMarketingInformationId { get; set; }
        [ForeignKey("SaleMarketingInformationId")]
        public virtual SaleMarketingInformation SaleMarketingInformation { get; set; }
        public long? PortfolioId { get; set; }
        [ForeignKey("PortfolioId")]
        public virtual Portfolio Portfolio { get; set; }
        public long ListedBy { get; set; }
        [ForeignKey("ListedBy")]
        public virtual User User { get; set; }
        public long? SaleInfoId { get; set; }
        [ForeignKey("SaleInfoId")]
        public virtual PropertySaleInfo SaleInfo { get; set; }
        public long? CommunicationDetailId { get; set; }
        [ForeignKey("CommunicationDetailId")]
        public virtual ERPCommunicationDetail CommunicationDetails { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}