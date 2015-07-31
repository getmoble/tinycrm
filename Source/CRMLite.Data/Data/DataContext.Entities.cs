using System.Data.Entity;
using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.Data;
using Common.Data.Entities;
using Common.DynamicMenu.Entities;
using Common.Providers.Email.Entities;
using Common.Settings.Entities;
using PropznetCommon.Features.CRM.Entities;

namespace CRMLite.Data.Data
{
    public partial class DataContext : ISingleTenantAuthDbContext
    {
        public DbSet<AgentPropertyMap> AgentPropertyMaps { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<AccessRule> AccessRules { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleMember> RoleMembers { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CRMCommunicationDetail> CRMCommunicationDetails { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadSource> LeadSourceMaster { get; set; }
        public DbSet<LeadStatus> LeadStatusMaster { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Potential> Potentials { get; set; }
        public DbSet<CRMProperty> CRMProperties { get; set; }
        public DbSet<PropertyCategory> PropertyCategories { get; set; }
        public DbSet<SalesStage> SalesStageMaster { get; set; }
        public DbSet<CRMToDo> CRMToDos { get; set; }
        public DbSet<CRMToDoMap> CRMToDoMaps { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Permission> Permissions { get; set; }
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>()
           .HasRequired(s => s.CommunicationDetail)
           .WithMany()
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<RolePermission>()
           .HasRequired(s => s.Role)
           .WithMany()
           .WillCascadeOnDelete(false);
            modelBuilder.Entity<RoleMember>()
           .HasRequired(s => s.Role)
           .WithMany()
           .WillCascadeOnDelete(false);
            modelBuilder.Entity<Contact>()
           .HasRequired(s => s.CommunicationDetail)
           .WithMany()
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Potential>()
           .HasRequired(s => s.Agent)
           .WithMany()
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Potential>()
           .HasRequired(s => s.Contact)
           .WithMany()
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Potential>()
           .HasRequired(s => s.SalesStage)
           .WithMany()
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<CRMProperty>()
           .HasRequired(s => s.PropertyCategory)
           .WithMany()
           .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
