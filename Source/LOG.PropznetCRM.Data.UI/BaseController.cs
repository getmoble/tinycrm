using Common.Auth.SingleTenant.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LOG.Propnet.Data.UI
{
    public class AppContext
    {
        public HttpServerUtilityBase Server { get; set; }
    }
    public class BaseController : Controller
    {

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
            return User.Identity.IsAuthenticated ? action() : new RedirectResult(System.Web.Security.FormsAuthentication.LoginUrl + "?returnUrl=" + Server.UrlEncode(Request.RawUrl));
        }

        public virtual ActionResult HandleIfOperationFailed(Func<ActionResult> action, Func<Exception, ActionResult> onError)
        {
            try
            {
                return action();
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

        public PrincipalModel WebUser
        {
            get { return User as PrincipalModel; }
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