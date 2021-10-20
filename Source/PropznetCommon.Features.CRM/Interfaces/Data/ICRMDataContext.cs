using System.Data.Entity;
using Common.Auth.SingleTenant.Entities;
using Common.Data.Entities;
using Common.Data.Interfaces;
using Common.Providers.Email.Entities;
using Common.Settings.Entities;
using PropznetCommon.Features.CRM.Entities;

namespace PropznetCommon.Features.CRM.Interfaces.Data
{
    public interface ICRMDataContext : IDbContext, ICountryDataContext, ICRMLiteDataContext
    {
         DbSet<AgentInfo> AgentInfos { get; set; }
         DbSet<PropertyCategory> PropertyCategories { get; set; }
         DbSet<ContactPaymentInfo> ContactPaymentInfo { get; set; }
         DbSet<PaymentContact> PaymentContact { get; set; }
         DbSet<PotentialPropertyInfo> PotentialPropertyInfos { get; set; }
         DbSet<PropertyPotential> PropertyPotentials { get; set; }        
    }
}