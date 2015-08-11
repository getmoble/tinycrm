using Common.Auth.SingleTenant.Entities;
using Common.Data.Entities;
using Common.DynamicMenu.Entities;
using Common.Providers.Email.Entities;
using Common.Settings.Entities;
using PropznetCommon.Features.CRM.Entities;
using System;
using System.Data.Entity;

namespace CRMLite.Data.Data
{
    public partial class DataContext
    {
        //public DbSet<Country> Countries { get; set; }
        //public DbSet<City> Cities { get; set; }
        //public DbSet<State> States { get; set; }
        //public DbSet<AccessRule> AccessRules { get; set; }
        //public DbSet<Person> Persons { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<RoleMember> RoleMembers { get; set; }
        //public DbSet<RolePermission> RolePermissions { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Setting> Settings { get; set; }
        //public DbSet<EmailTemplate> EmailTemplates { get; set; }
        //public DbSet<Account> Accounts { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Lead> Leads { get; set; }
        //public DbSet<LeadSource> LeadSourceMaster { get; set; }
        //public DbSet<LeadStatus> LeadStatusMaster { get; set; }
        //public DbSet<Potential> Potentials { get; set; }
        //public DbSet<PropertyCategory> PropertyCategories { get; set; }
        //public DbSet<SalesStage> SalesStageMaster { get; set; }
        //public DbSet<CRMToDo> CRMToDos { get; set; }
        //public DbSet<CRMToDoMap> CRMToDoMaps { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<AccessRule> AccessRules { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CRMToDoMap> CRMToDoMaps { get; set; }
        public DbSet<CRMToDo> CRMToDos { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadSource> LeadSourceMaster { get; set; }
        public DbSet<LeadStatus> LeadStatusMaster { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Potential> Potentials { get; set; }
        public DbSet<RoleMember> RoleMembers { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SalesStage> SalesStageMaster { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
           .HasRequired(s => s.AssignedToUser)
           .WithMany()
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
            .HasRequired(s => s.Person)
            .WithMany()
            .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<User>()
           .HasRequired(s => s.Person)
           .WithMany()
           .WillCascadeOnDelete(false);

           // modelBuilder.Entity<User>()
           // .HasRequired(s => s.RoleMembers)
           // .WithMany()
           // .WillCascadeOnDelete(false);

           // modelBuilder.Entity<RoleMember>()
           //.HasRequired(s => s.User)
           //.WithMany()
           //.WillCascadeOnDelete(false);


            modelBuilder.Entity<RolePermission>()
           .HasRequired(s => s.Role)
           .WithMany()
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleMember>()
           .HasRequired(s => s.Role)
           .WithMany()
           .WillCascadeOnDelete(false);
            modelBuilder.Entity<Contact>()
           .HasRequired(s => s.Person)
           .WithMany()
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Potential>()
           .HasRequired(s => s.AssignedToUser)
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
            modelBuilder.Properties<DateTime>()
            .Configure(c => c.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);

        }
    }
}
