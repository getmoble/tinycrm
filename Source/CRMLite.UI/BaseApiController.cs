using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Common.DynamicMenu.Interfaces.Services;
using Common.Settings.Interfaces.Services;
using Common.UI.Web.Infrastructure;
using CRMLite.Data.Model.Settings;
using CRMLite.Infrastructure;
using PropznetCommon.Features.CRM.ViewModel.Setting;

namespace CRMLite.UI
{
    public class BaseApiController : BaseController
    {
        readonly IDynamicMenuService _dynamicMenuService;
        SettingsModel _siteSetting;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BaseApiController()
            : this(DependencyResolver.Current.GetService<ISettingService>(), DependencyResolver.Current.GetService<IDynamicMenuService>())
        {}
        public BaseApiController(ISettingService settingService, IDynamicMenuService dynamicMenuService)
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
        public bool IsAuthenticated
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
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (WebUser != null)
            {
                ViewBag.UserPermissions = WebUser.PermissionCodes;
                if (WebUser.Image != null)
                    ViewBag.Image = WebUser.Image;
                else
                    ViewBag.Image = "Dummy.jpg";
                ViewBag.UserId = WebUser.Id;
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
            return new RedirectResult("~/Error/NotAuthorized");
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
        public virtual JsonResult ThrowIfNotLoggedIn(Func<JsonResult> action)
        {
            var loggedIn = User.Identity.IsAuthenticated;
            if (loggedIn)
            {
                return action();
            }
            else
            {
                Response.StatusCode = 403;
                Response.StatusDescription = "Access Denied";
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        public virtual JsonResult TryExecuteWrapAndReturn<T>(Func<T> operation, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            try
            {
                var result = operation();
                var apiResult = new ApiResult<T>
                {
                    Status = true,
                    Message = "Success",
                    Result = result
                };

                return Json(apiResult, behavior);
            }
            catch (Exception ex)
            {
                if(AppConfigaration.GetExceptionMode()=="debug")
                {
                    var apiResult = new ApiResult<T>
                    {
                        Status = false,
                        Message = ex.Message
                    };
                    return Json(apiResult, behavior);
                }
                else
                {
                    var apiResult = new ApiResult<T>
                    {
                        Status = false,
                        Message = "Oops... Something bad has happened..."
                    };
                    logger.Error(ex.Message,ex);
                    return Json(apiResult, behavior);
                }
            }
        }

        public virtual JsonResult TryExecuteWrapExeptionAndReturn<T>(Func<T> operation, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            try
            {
                var result = operation();
                var apiResult = new ApiResult<T>
                {
                    Status = true,
                    Message = "Success",
                    Result = result
                };

                return Json(apiResult, behavior);
            }
            catch (Exception ex)
            {
                var apiResult = new ApiResult<T>
                {
                    Status = false,
                    Message = ex.Message
                };
                return Json(apiResult, behavior);
            }
        }

        public virtual T TryExecute<T>(Func<T> operation, Func<Exception, T> onError)
        {
            try
            {
                return operation();
                
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message,ex);
                return onError(ex);
            }
        }
      
        public class ApiResult<T>
        {
            public bool Status { get; set; }
            public string Message { get; set; }
            public T Result { get; set; }       
        }
    }
}