using Hangfire;
using Microsoft.Owin;
using Owin;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(LOG.PropznetCRM.Data.UI.Startup))]
namespace LOG.PropznetCRM.Data.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(ConfigurationManager.ConnectionStrings["CRM_HangFire"].ConnectionString);
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
