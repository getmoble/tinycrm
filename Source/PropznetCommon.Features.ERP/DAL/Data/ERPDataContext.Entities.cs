using System.Data.Entity;
using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.Data;
using Common.Data.Entities;
using Common.Providers.Email.Entities;
using Common.Settings.Entities;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.DAL.Data
{
    public partial class ERPDataContext : ISingleTenantAuthDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<AccessRule> AccessRules { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<RoleMember> RoleMembers { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<AmenitiesMap> AmenitiesMaps { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetMap> AssetMaps { get; set; }
        public DbSet<ERPCommunicationDetail> ERPCommunicationDetails { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentMap> DocumentsMaps { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<FloorPlan> FloorPlans { get; set; }
        public DbSet<FloorPlanMap> FloorPlanMaps { get; set; }
        public DbSet<ImageGallery> ImageGallery { get; set; }
        public DbSet<ImageGalleryMap> ImageGalleryMaps { get; set; }
        public DbSet<LeasingFee> LeasingFees { get; set; }
        public DbSet<LeasingFeeMap> LeasingFeeMaps { get; set; }
        public DbSet<WorkOrder> Maintenance { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ManagerRole> ManagerRoles { get; set; }
        public DbSet<WorkOrderMap> ManagerMaps { get; set; }
        public DbSet<RentMarketingInformation> RentMarketingInformation { get; set; }
        public DbSet<SaleMarketingInformation> SaleMarketingInformation { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<ERPProperty> ERPProperties { get; set; }
        public DbSet<PropertyRentInfo> PropertyRentInfos { get; set; }
        public DbSet<UnitRentInfo> UnitRentInfos { get; set; }
        public DbSet<UnitSaleInfo> UnitSaleInfos { get; set; }
        public DbSet<PropertySaleInfo> PropertySaleInfos { get; set; }
        public DbSet<Tenant> TenantDetails { get; set; }
        public DbSet<TenantDetailMap> TenantDetailMaps { get; set; }
        public DbSet<ERPToDo> ERPToDos { get; set; }
        public DbSet<ERPToDoMap> ERPToDoMaps { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<PortfolioOwnerMap> PortfolioOwnerMaps { get; set; }
        public DbSet<PropertyUnitMap> PropertyUnitMaps { get; set; }
        public DbSet<PropertyAmenityMap> PropertyAmenityMaps { get; set; }
        public DbSet<PropertyOwnerMap> PropertyOwnerMaps { get; set; }
        public DbSet<PropertyManagerMap> PropertyManagerMaps { get; set; }
        public DbSet<UnitAmenityMap> UnitAmenityMaps { get; set; }
        public DbSet<UnitOwnerMap> UnitOwnerMaps { get; set; }
        public DbSet<UnitManagerMap> UnitManagerMaps { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Charge> Charges { get; set; }
        public DbSet<PropertyChargeMap> PropertyChargeMaps { get; set; }
        public DbSet<PropertyAgentMap> PropertyAgentMaps { get; set; }
        public DbSet<PropertyRentInfoMap> PropertyRentInfoMaps { get; set; }
        public DbSet<PropertyRentalCommission> PropertyRentalCommissions { get; set; }
        public DbSet<PropertyRentalCommissionMap> PropertyRentalCommissionMaps { get; set; }
        public DbSet<UnitChargeMap> UnitChargeMaps { get; set; }
        public DbSet<UnitRentInfoMap> UnitRentInfoMaps { get; set; }
        public DbSet<UnitRentalCommission> UnitRentalCommissions { get; set; }
        public DbSet<UnitRentalCommissionMap> UnitRentalCommissionMaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
            .HasRequired(s => s.User)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
            .HasRequired(s => s.Property)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<ERPProperty>()
            .HasRequired(s => s.User)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnitAmenityMap>()
            .HasRequired(s => s.Amenity)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnitAmenityMap>()
            .HasRequired(s => s.Unit)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnitManagerMap>()
            .HasRequired(s => s.Unit)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnitManagerMap>()
            .HasRequired(s => s.Manager)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnitOwnerMap>()
            .HasRequired(s => s.Owner)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnitOwnerMap>()
            .HasRequired(s => s.Unit)
            .WithMany()
            .WillCascadeOnDelete(false);
        }
    }
}