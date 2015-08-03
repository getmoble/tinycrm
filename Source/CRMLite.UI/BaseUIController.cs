using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Common.Settings.Interfaces.Services;
using CRMLite.Data.Model.Settings;
using PropznetCommon.Features.CRM.ViewModel.Setting;
using CRMLite.Infrastructure;
using Common.DynamicMenu.Interfaces.Services;
using Common.DynamicMenu.ViewModel;
using CRMLite.Data.Model.Setting;
using Common.UI.Web.Infrastructure;

namespace CRMLite.UI
{
    public class AppContext
    {
        public HttpServerUtilityBase Server { get; set; }
    }
    public class BaseUIController : BaseController
    {
        readonly IDynamicMenuService _dynamicMenuService;
        SettingsModel _siteSetting;
        public BaseUIController()
            : this(DependencyResolver.Current.GetService<ISettingService>(), DependencyResolver.Current.GetService<IDynamicMenuService>())
        {}
        public BaseUIController(ISettingService settingService, IDynamicMenuService dynamicMenuService)
        {
            _dynamicMenuService = dynamicMenuService;
            var siteSettingdeSerialized = settingService.GetSetting<SettingsModel>("SiteSetting");
            _siteSetting = new SettingsModel(siteSettingdeSerialized);
            EmailHelper.SmptpCredentials(_siteSetting.SmtpConfigUsername, _siteSetting.SmtpConfigPassword);
            ElasticSearchSettings.SetElasticSearchSettings(_siteSetting.ElasticSearchUrl, _siteSetting.DefaultIndex);
            var settingdeserialized = settingService.GetAllSettings().FirstOrDefault(i => i.Key == "logo");
            if (settingdeserialized != null)
            {
                var settings = new SettingViewModel(settingdeserialized.Value);
                ViewBag.Settings = settings;
            }
        }
        public new bool IsAuthenticated
        {
            get
            {
                if (User != null)
                {
                    return User.Identity.IsAuthenticated;
                }

                return false;
            }
        }
        public AppContext Application
        {
            get
            {
                return new AppContext { Server = Server };
            }
        }
        protected override void Initialize(RequestContext requestContext)
        {            
            base.Initialize(requestContext);
        }
        public virtual void GenerateMenu()
        {
            var menuList = _dynamicMenuService.GetMenu(WebUser.PermissionCodes);
            var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            //var selectedItem = new MenuViewModel(menuList.FirstOrDefault(m => m.Controller.Contains(controllerName)));
            //if (selectedItem != null)
            //{
            //    selectedItem.Class = "active";
            //}
            ViewBag.MenuItems = menuList.ToList();
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (WebUser != null)
            {
                ViewBag.UserPermissions = WebUser.PermissionCodes;
                ViewBag.RoleId = WebUser.RoleId;
                if (WebUser.Image != null)
                    ViewBag.Image = WebUser.Image;
                else
                    ViewBag.Image = "Dummy.jpg";
                ViewBag.UserId = WebUser.Id;
                GenerateMenu();
            }            
            base.OnActionExecuting(filterContext);      
        }

        public string GetUserIP()
        {
            return Request.ServerVariables["REMOTE_HOST"];
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ViewBag.User = filterContext.HttpContext.User;
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                ViewBag.UserName = filterContext.HttpContext.User.Identity.Name;
        }

        public virtual ActionResult ExecuteIfValid(Func<ActionResult> onValid, Func<ActionResult> onInvalid, Func<Exception, ActionResult> onError)
        {
            return ModelState.IsValid ? HandleIfOperationFailed(onValid, onError) : onInvalid();
        }

        public virtual ActionResult RedirectIfNotLoggedIn(Func<ActionResult> action)
        {
            return User.Identity.IsAuthenticated ? action() : new RedirectResult(FormsAuthentication.LoginUrl + "?returnUrl=" + Server.UrlEncode(Request.RawUrl));
        }

        public virtual ActionResult RedirectIfNotAutherized()
        {
            return new RedirectResult("~/CRM/Error/NotAuthorized");
        }
        public virtual ActionResult RedirectHappenedUnexpected()
        {
            return new RedirectResult("~/CRM/Error/Index");
        }
        public virtual ActionResult HandleIfOperationFailed(Func<ActionResult> action, Func<Exception, ActionResult> onError)
        {
            try
            {
                return action();
            }
            catch (UnauthorizedAccessException ex)
            {
                var returnData = new { Status = false, Code = 401 };
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return onError(ex);
            }
        }
        public virtual ActionResult GotoNotFound()
        {
            return View("NotFound");
        }

        public CRMLitePrincipal WebUser
        {
            get { return User as CRMLitePrincipal; }
        }

        public SettingsModel SiteSettings
        {
            get { return _siteSetting; }
        }

        // Flash Message Helpers
        public void Error(string message)
        {
            CreateCookieWithFlashMessage(Notification.Danger, message);
        }
        public void Warning(string message)
        {
            CreateCookieWithFlashMessage(Notification.Warning, message);
        }
        public void Success(string message)
        {
            CreateCookieWithFlashMessage(Notification.Success, message);
        }
        public void Information(string message)
        {
            CreateCookieWithFlashMessage(Notification.Info, message);
        }
        void CreateCookieWithFlashMessage(Notification notification, string message)
        {
            HttpContext.Response.Cookies.Add(new HttpCookie(string.Format("Flash.{0}", notification), message) { Path = "/" });
        }

        enum Notification
        {
            Danger,
            Warning,
            Success,
            Info
        }
    }
}