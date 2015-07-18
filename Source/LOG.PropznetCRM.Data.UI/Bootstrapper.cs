using System.Web.Mvc;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Data;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.DAL;
using LOG.PropznetCRM.Data.Services;
using System.Data.Entity;
using Common.Data.Interfaces;
using Common.Auth.SingleTenant.DAL;
using Common.Auth.SingleTenant.Interfaces.DAL;
using Common.Auth.SingleTenant.Interfaces.Data;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Auth.SingleTenant.Services;
using Common.Providers.Email.Intefaces.DAL;
using Common.Providers.Email.DAL;
using Common.Providers.Email.Intefaces.Services;
using Common.Providers.Email.Services;
using Common.Settings.Interfaces.DAL;
using Common.Settings.DAL;
using Common.Settings.Interfaces.Services;
using Common.Settings.Services;
using Common.Settings.Interfaces.Data;
using Common.Providers.Email.Intefaces.Data;
using Common.Providers.Email;
using IAccountRepository = LOG.PropznetCRM.Data.Core.Interfaces.DAL.IAccountRepository;
using IAccountService = LOG.PropznetCRM.Data.Core.Interfaces.Services.IAccountService;

namespace LOG.PropznetCRM.Data.UI
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<DataContext>(new PerRequestLifetimeManager(), new InjectionConstructor());
            container.RegisterType<IDataContext, DataContext>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<ISingleTenantAuthDbContext, DataContext>();
            container.RegisterType<ISettingsDataContext, DataContext>();
            container.RegisterType<IEmailProviderDataContext, DataContext>();
            RegisterRepositories(container);
            RegisterServices(container);
            container.RegisterType<DbContext, DataContext>(new HierarchicalLifetimeManager());
            return container;
        }
        static void RegisterRepositories(UnityContainer container)
        {
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAgentRepository, AgentRepository>();
            container.RegisterType<ICommunicationDetailRepository, CommunicationDetailRepository>();
            container.RegisterType<IContactRepository, ContactRepository>();
            container.RegisterType<ILeadRepository, LeadRepository>();
            container.RegisterType<ILeadSourceRepository, LeadSourceRepository>();
            container.RegisterType<ILeadStatusRepository, LeadStatusRepository>();
            container.RegisterType<ILocationRepository, LocationRepository>();
            container.RegisterType<IPotentialRepository, PotentialRepository>();
            container.RegisterType<IPropertyRepository, PropertyRepository>();
            container.RegisterType<IPropertyCategoryRepository, PropertyCategoryRepository>();
            container.RegisterType<ISalesStageRepository, SalesStageRepository>();
            container.RegisterType<ISettingRepository, SettingRepository>();
            container.RegisterType<IStateRepository, StateRepository>();
            container.RegisterType<IToDoRepository, ToDoRepository>();
            container.RegisterType<IToDoMapRepository, ToDoMapRepository>();
            container.RegisterType<IPersonRepository, PersonRepository>();
            container.RegisterType<IAccessRuleRepository, AccessRuleRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IRoleMemberRepository, RoleMemberRepository>();
            container.RegisterType<IPersonRepository, PersonRepository>();
            container.RegisterType<IEmailTemplateRepository, EmailTemplateRepository>();
            container.RegisterType<IEmailProvider, SmtpEmailProvider>();
            container.RegisterType<ISettingRepository, SettingRepository>();
        }
        static void RegisterServices(UnityContainer container)
        {
            container.RegisterType<IAccountService, LOG.PropznetCRM.Data.Services.AccountService>();
            container.RegisterType<Common.Auth.SingleTenant.Interfaces.Services.IAccountService, Common.Auth.SingleTenant.Services.AccountService>();
            container.RegisterType<IAgentService, AgentService>();
            container.RegisterType<ICommunicationDetailService, CommunicationDetailService>();
            container.RegisterType<IContactService, ContactService>();
            container.RegisterType<ILeadService, LeadService>();
            container.RegisterType<ILeadSourceService, LeadSourceService>();
            container.RegisterType<ILeadStatusService, LeadStatusService>();
            container.RegisterType<ILocationService, LocationService>();
            container.RegisterType<IPotentialService, PotentialService>();
            container.RegisterType<IPropertyService, PropertyService>();
            container.RegisterType<IPropertyCategoryService, PropertyCategoryService>();
            container.RegisterType<ISalesStageService, SalesStageService>();
            container.RegisterType<ISettingService, SettingService>();
            container.RegisterType<IStateService, StateService>();
            container.RegisterType<IToDoService, ToDoService>();
            container.RegisterType<IToDoMapService, ToDoMapService>();
            container.RegisterType<IElasticSearchSettings, ElasticSearchSettings>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IReportService, ReportService>();
            //container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<Common.Auth.SingleTenant.Interfaces.Services.IAccountService,Common.Auth.SingleTenant.Services.AccountService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IEmailTemplateService, EmailTemplateService>();
            container.RegisterType<ISettingService, SettingService>();
        }
    }
}