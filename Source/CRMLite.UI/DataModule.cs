using Autofac;
using Common.Auth.SingleTenant.DAL;
using Common.Auth.SingleTenant.Interfaces.DAL;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Auth.SingleTenant.Services;
using Common.Data.Interfaces;
using Common.DynamicMenu.DAL;
using Common.DynamicMenu.Interfaces.Data;
using Common.DynamicMenu.Interfaces.DAL;
using Common.DynamicMenu.Interfaces.Services;
using Common.DynamicMenu.Services;
using Common.Providers.Email;
using Common.Providers.Email.DAL;
using Common.Providers.Email.Intefaces.DAL;
using Common.Providers.Email.Intefaces.Services;
using Common.Providers.Email.Services;
using Common.Settings.DAL;
using Common.Settings.Interfaces.Data;
using Common.Settings.Interfaces.DAL;
using Common.Settings.Interfaces.Services;
using Common.Settings.Services;
using CRMLite.Core.Interfaces.Data;
using CRMLite.Data.Data;
using PropznetCommon.Features.CRM.DAL;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Services;
using AccountService = PropznetCommon.Features.CRM.Services.AccountService;
using IAccountRepository = PropznetCommon.Features.CRM.Interfaces.DAL.IAccountRepository;
using IAccountService = PropznetCommon.Features.CRM.Interfaces.Services.IAccountService;
using IRoleRepository = Common.Auth.SingleTenant.Interfaces.DAL.IRoleRepository;
using IUserRepository = Common.Auth.SingleTenant.Interfaces.DAL.IUserRepository;
using RoleRepository = PropznetCommon.Features.CRM.DAL.RoleRepository;

namespace CRMLite.UI
{
    public class DataModule : Module
    {
        private string connStr;

        public DataModule(string connString)
        {
            connStr = connString;
        }
        protected override void Load(ContainerBuilder container)
        {
            container.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            container.RegisterType<DataContext>().As<ISettingsDataContext>().InstancePerLifetimeScope();
            container.RegisterType<DataContext>().As<IDynamicMenuDataContext>().InstancePerLifetimeScope();
            container.RegisterType<DataContext>().As<IDataContext>().InstancePerLifetimeScope();
            container.RegisterType<DataContext>().As<ICRMLiteDataContext>().InstancePerLifetimeScope();

            RegisterCrmRepositories(container);
            RegisterCrmServices(container);
            base.Load(container);
        }
        static void RegisterCrmRepositories(ContainerBuilder container)
        {
            container.RegisterType<AccountRepository>().As<IAccountRepository>().InstancePerRequest();
            container.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerRequest();
            container.RegisterType<LeadRepository>().As<ILeadRepository>().InstancePerRequest();
            container.RegisterType<LeadSourceRepository>().As<ILeadSourceRepository>().InstancePerRequest();
            container.RegisterType<LeadStatusRepository>().As<ILeadStatusRepository>().InstancePerRequest();
            container.RegisterType<PotentialRepository>().As<IPotentialRepository>().InstancePerRequest();
            container.RegisterType<PropertyCategoryRepository>().As<IPropertyCategoryRepository>().InstancePerRequest();
            container.RegisterType<SalesStageRepository>().As<ISalesStageRepository>().InstancePerRequest();
            container.RegisterType<ToDoRepository>().As<IToDoRepository>().InstancePerRequest();
            container.RegisterType<ToDoMapRepository>().As<IToDoMapRepository>().InstancePerRequest();
            container.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerRequest();
            container.RegisterType<AccessRuleRepository>().As<IAccessRuleRepository>().InstancePerRequest();
            container.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            container.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerRequest();
            container.RegisterType<EmailTemplateRepository>().As<IEmailTemplateRepository>().InstancePerRequest();
            container.RegisterType<SmtpEmailProvider>().As<IEmailProvider>().InstancePerRequest();
            container.RegisterType<SettingRepository>().As<ISettingRepository>().InstancePerRequest();
            container.RegisterType<MenuItemRepository>().As<IMenuItemRepository>().InstancePerRequest();
            container.RegisterType<RolePermissionRepository>().As<IRolePermissionRepository>().InstancePerRequest();
            container.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerRequest();
            container.RegisterType<RoleMemberRepository>().As<IRoleMemberRepository>().InstancePerRequest();
            container.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            container.RegisterType<AccessRuleRepository>().As<IAccessRuleRepository>().InstancePerRequest();
            container.RegisterType<CountryRepository>().As<ICountryRepository>().InstancePerRequest();
            container.RegisterType<CityRepository>().As<ICityRepository>().InstancePerRequest();
            container.RegisterType<CountryRepository>().As<ICountryRepository>().InstancePerRequest(); 
        }
        static void RegisterCrmServices(ContainerBuilder container)
        {
            container.RegisterType<AccountService>().As<IAccountService>().InstancePerRequest();
            container.RegisterType<Common.Auth.SingleTenant.Services.AccountService>().As<Common.Auth.SingleTenant.Interfaces.Services.IAccountService>().InstancePerRequest();
            container.RegisterType<PersonService>().As<IPersonService>().InstancePerRequest();
            container.RegisterType<CRMLiteContactService>().As<ICRMLiteContactService>().InstancePerRequest();
            container.RegisterType<LeadService>().As<ILeadService>().InstancePerRequest();
            container.RegisterType<LeadSourceService>().As<ILeadSourceService>().InstancePerRequest();
            container.RegisterType<LeadStatusService>().As<ILeadStatusService>().InstancePerRequest();
            container.RegisterType<PotentialService>().As<IPotentialService>().InstancePerRequest();
            container.RegisterType<PropertyCategoryService>().As<IPropertyCategoryService>().InstancePerRequest();
            container.RegisterType<SalesStageService>().As<ISalesStageService>().InstancePerRequest();
            container.RegisterType<ToDoService>().As<IToDoService>().InstancePerRequest();
            container.RegisterType<ToDoMapService>().As<IToDoMapService>().InstancePerRequest();
            container.RegisterType<ElasticSearchSettings>().As<IElasticSearchSettings>().InstancePerRequest();
            container.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            container.RegisterType<ReportService>().As<IReportService>().InstancePerRequest();
            container.RegisterType<RoleService>().As<IRoleService>().InstancePerRequest();
            container.RegisterType<EmailTemplateService>().As<IEmailTemplateService>().InstancePerRequest();
            container.RegisterType<SettingService>().As<ISettingService>().InstancePerRequest();
            container.RegisterType<DynamicMenuService>().As<IDynamicMenuService>().InstancePerRequest();
            container.RegisterType<RolePermissionService>().As<IRolePermissionService>().InstancePerRequest();
            container.RegisterType<Common.Auth.SingleTenant.Services.AccountService>().As<Common.Auth.SingleTenant.Interfaces.Services.IAccountService>().InstancePerRequest();
            container.RegisterType<RoleService>().As<IRoleService>().InstancePerRequest();
            container.RegisterType<Common.Auth.SingleTenant.Services.AccountService>().As<Common.Auth.SingleTenant.Interfaces.Services.IAccountService>().InstancePerRequest();
            container.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            container.RegisterType<CountryService>().As<ICountryService>().InstancePerRequest();
        }
    }
}
