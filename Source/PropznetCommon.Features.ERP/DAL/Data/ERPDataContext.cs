using System.Data.Entity;
using Common.Providers.Email.Intefaces.Data;
using Common.Settings.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.Data;
using Common.Auth.SingleTenant.Interfaces.Data;

namespace PropznetCommon.Features.ERP.DAL.Data
{
    public partial class ERPDataContext : DbContext, IERPDataContext, ISettingsDataContext, IEmailProviderDataContext,ISingleTenantAuthDbContext
    {
        public ERPDataContext()
            : base("PropznetERP")
        {
            Database.SetInitializer(new DataSeeder());
            Database.Initialize(true);
            Configuration.ProxyCreationEnabled = false;
        }  
    }
}