using Common.Auth.SingleTenant.Entities;
using Common.Data.Entities;
using Common.Data.Interfaces;
using Common.Providers.Email.Entities;
using Common.Settings.Entities;
using PropznetCommon.Features.CRM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Interfaces.Data
{
    public interface ICRMLiteDataContext: IDbContext, ICountryDataContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Lead> Leads { get; set; }
        DbSet<LeadSource> LeadSourceMaster { get; set; }
        DbSet<LeadStatus> LeadStatusMaster { get; set; }
        DbSet<Potential> Potentials { get; set; }
        DbSet<SalesStage> SalesStageMaster { get; set; }
        DbSet<AccessRule> AccessRules { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<RoleMember> RoleMembers { get; set; }
        DbSet<RolePermission> RolePermissions { get; set; }
        DbSet<Setting> Settings { get; set; }
        DbSet<CRMToDo> CRMToDos { get; set; }
        DbSet<CRMToDoMap> CRMToDoMaps { get; set; }
        DbSet<EmailTemplate> EmailTemplates { get; set; }
    }
}