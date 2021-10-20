using System.Data.Entity;
using Common.Auth.SingleTenant.Entities;
using Common.Data.Entities;
using Common.Data.Interfaces;
using Common.Providers.Email.Entities;
using Common.Settings.Entities;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.Data
{
    public interface IERPDataContext : IDbContext, ICountryDataContext
    {
         DbSet<Country> Countries { get; set; }
         DbSet<City> Cities { get; set; }
         DbSet<State> States { get; set; }
         DbSet<AccessRule> AccessRules { get; set; }
         DbSet<Person> Persons { get; set; }
         DbSet<RoleMember> RoleMembers { get; set; }
         DbSet<RolePermission> RolePermissions { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<User> Users { get; set; }
         DbSet<Setting> Settings { get; set; }
         DbSet<EmailTemplate> EmailTemplates { get; set; }
         DbSet<Amenity> Amenities { get; set; }
         DbSet<AmenitiesMap> AmenitiesMaps { get; set; }
         DbSet<Area> Areas { get; set; }
         DbSet<Asset> Assets { get; set; }
         DbSet<AssetMap> AssetMaps { get; set; }
         DbSet<ERPCommunicationDetail> ERPCommunicationDetails { get; set; }
         DbSet<Document> Documents { get; set; }
         DbSet<DocumentMap> DocumentsMaps { get; set; }
         DbSet<Email> Emails { get; set; }
         DbSet<FloorPlan> FloorPlans { get; set; }
         DbSet<FloorPlanMap> FloorPlanMaps { get; set; }
         DbSet<ImageGallery> ImageGallery { get; set; }
         DbSet<ImageGalleryMap> ImageGalleryMaps { get; set; }
         DbSet<LeasingFee> LeasingFees { get; set; }
         DbSet<LeasingFeeMap> LeasingFeeMaps { get; set; }
         DbSet<WorkOrder> Maintenance { get; set; }
         DbSet<Manager> Managers { get; set; }
         DbSet<ManagerRole> ManagerRoles { get; set; }
         DbSet<WorkOrderMap> ManagerMaps { get; set; }
         DbSet<RentMarketingInformation> RentMarketingInformation { get; set; }
         DbSet<SaleMarketingInformation> SaleMarketingInformation { get; set; }
         DbSet<Owner> Owners { get; set; }
         DbSet<Portfolio> Portfolios { get; set; }
         DbSet<ERPProperty> ERPProperties { get; set; }
         DbSet<PropertyRentInfo> PropertyRentInfos { get; set; }
         DbSet<UnitRentInfo> UnitRentInfos { get; set; }
         DbSet<PropertySaleInfo> PropertySaleInfos { get; set; }
         DbSet<UnitSaleInfo> UnitSaleInfos { get; set; }
         DbSet<Tenant> TenantDetails { get; set; }
         DbSet<TenantDetailMap> TenantDetailMaps { get; set; }
         DbSet<ERPToDo> ERPToDos { get; set; }
         DbSet<ERPToDoMap> ERPToDoMaps { get; set; }
         DbSet<Unit> Units { get; set; }
         DbSet<UnitType> UnitTypes { get; set; }
         DbSet<PortfolioOwnerMap> PortfolioOwnerMaps { get; set; }
         DbSet<PropertyUnitMap> PropertyUnitMaps { get; set; }
         DbSet<PropertyAmenityMap> PropertyAmenityMaps { get; set; }
         DbSet<PropertyOwnerMap> PropertyOwnerMaps { get; set; }
         DbSet<PropertyManagerMap> PropertyManagerMaps { get; set; }
         DbSet<UnitAmenityMap> UnitAmenityMaps { get; set; }
         DbSet<UnitOwnerMap> UnitOwnerMaps { get; set; }
         DbSet<UnitManagerMap> UnitManagerMaps { get; set; }
         DbSet<Charge> Charges { get; set; }
         DbSet<PropertyChargeMap> PropertyChargeMaps { get; set; }
         DbSet<PropertyAgentMap> PropertyAgentMaps { get; set; }
         DbSet<PropertyRentInfoMap> PropertyRentInfoMaps { get; set; }
         DbSet<PropertyRentalCommission> PropertyRentalCommissions { get; set; }
         DbSet<PropertyRentalCommissionMap> PropertyRentalCommissionMaps { get; set; }
         DbSet<UnitChargeMap> UnitChargeMaps { get; set; }
         DbSet<UnitRentInfoMap> UnitRentInfoMaps { get; set; }
         DbSet<UnitRentalCommission> UnitRentalCommissions { get; set; }
         DbSet<UnitRentalCommissionMap> UnitRentalCommissionMaps { get; set; }
    }
}