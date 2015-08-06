using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Common.Auth.SingleTenant.Interfaces.Data;
using Common.Data.Interfaces;
using Common.Providers.Email.Intefaces.Data;
using Common.Settings.Interfaces.Data;
using CRMLite.Core.Interfaces.Data;
using CRMLite.Data.Data;
using PropznetCommon.Features.CRM.Interfaces.Data;

namespace CRMLite.UI
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            #region Register all controllers for the assembly

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            #endregion

            #region Register modules
            builder.RegisterModule(new DataModule("CRMLite"));

            builder.RegisterType<DataContext>()
               .As<DataContext>()
               .As<IDbContext>()
                .As<IDataContext>()
                .As<ICRMLiteDataContext>()
               .As<ISettingsDataContext>()
               .As<ISingleTenantAuthDbContext>().
               As<IEmailProviderDataContext>()
               .InstancePerRequest();

            //var tenantContext = new TenantDataContext();

            #endregion

            #region Set the MVC dependency resolver to use Autofac

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            #endregion

       }
    }
}