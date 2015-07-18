using Common.Settings.Interfaces.Services;
using LOG.PropznetCRM.Data.ViewModel.Setting;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.Infrastructure
{
    public class CRMBaseController : Controller
    {
        public CRMBaseController()
            : this(DependencyResolver.Current.GetService<ISettingService>())
        { }
        public CRMBaseController(ISettingService settingService)
        {
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

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (WebUser != null)
            {
                ViewBag.UserPermissions = WebUser.PermissionCodes;
                ViewBag.Image = WebUser.Image;
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
            return User.Identity.IsAuthenticated ? action() : new RedirectResult("~/User/SignIn" + "?returnUrl=" + Server.UrlEncode(Request.RawUrl));
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
        public CRMPrincipal WebUser
        {
            get { return User as CRMPrincipal; }
        }
    }
}