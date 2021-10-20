using System.Data.Entity;
using Common.Providers.Email.Intefaces.Data;
using Common.Settings.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.Data;
using Common.Auth.SingleTenant.Interfaces.Data;

namespace PropznetCommon.Features.CRM.DAL.Data
{
    public partial class CRMDataContext : DbContext, ICRMDataContext, ISettingsDataContext, IEmailProviderDataContext, ISingleTenantAuthDbContext
    {
        public CRMDataContext()
            : base("PropznetCRM")
        {
            Database.SetInitializer(new DataSeeder());
            Database.Initialize(true);
            Configuration.ProxyCreationEnabled = false;
        }
    }
}