using Common.Providers.Email.Intefaces.Data;
using Common.Settings.Interfaces.Data;
using System.Data.Entity;
using LOG.PropznetCRM.Data.Core.Interfaces.Data;

namespace LOG.PropznetCRM.Data.DAL.Data
{
    public partial class DataContext : DbContext, IDataContext, ISettingsDataContext, IEmailProviderDataContext
    {
        public DataContext()
            : base("PropznetCRM")
        {
            Database.SetInitializer(new DataSeeder());
            Database.Initialize(true);
            Configuration.ProxyCreationEnabled = false;
        }
    }
}