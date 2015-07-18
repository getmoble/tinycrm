using System.Data.Entity;
using Common.Data.Interfaces;
using Common.Settings.Entities;
using LOG.PropznetCRM.Data.Entities;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Data
{
    public interface IDataContext : IDbContext, ICountryDataContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Agent> Agents { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<CommunicationDetail> CommunicationDetails { get; set; }
        DbSet<Lead> Leads { get; set; }
        DbSet<LeadSource> LeadSourceMaster { get; set; }
        DbSet<LeadStatus> LeadStatusMaster { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Potential> Potentials { get; set; }
        DbSet<Property> Properties { get; set; }
        DbSet<PropertyCategory> PropertyCategories { get; set; }
        DbSet<SalesStage> SalesStageMaster { get; set; }
        DbSet<Setting> Settings { get; set; }
        DbSet<ToDo> ToDos { get; set; }
        DbSet<ToDoMap> ToDoMaps { get; set; }
    }
}
