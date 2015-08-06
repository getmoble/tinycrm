using Common.Auth.SingleTenant.Interfaces.Data;
using Common.DynamicMenu.Interfaces.Data;
using Common.Providers.Email.Intefaces.Data;
using Common.Settings.Interfaces.Data;
using CRMLite.Core.Interfaces.Data;
using System.Data.Entity;
using PropznetCommon.Features.CRM.Entities;

namespace CRMLite.Data.Data
{
    public partial class DataContext : DbContext, IDataContext, ISettingsDataContext, IEmailProviderDataContext, IDynamicMenuDataContext, ISingleTenantAuthDbContext
    {
        public DataContext()
            : base("CRMLite")
        {
            Database.SetInitializer(new DataSeeder());
            Database.Initialize(true);
            Configuration.ProxyCreationEnabled = false;
        }
    }
}