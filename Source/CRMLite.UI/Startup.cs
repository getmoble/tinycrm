using System.Configuration;
using Hangfire;
using Microsoft.Owin;
using Owin;
using CRMLite.UI;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
[assembly: OwinStartup(typeof(Startup))]
namespace CRMLite.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //GlobalConfiguration.Configuration.UseSqlServerStorage(ConfigurationManager.ConnectionStrings["CRM_HangFire"].ConnectionString);
            //app.UseHangfireDashboard();
            //app.UseHangfireServer();
        }
    }
}