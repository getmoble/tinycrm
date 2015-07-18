using Common.Auth.SingleTenant.Interfaces.Services;
using Common.UI.Web.Infrastructure;
using LOG.PropznetCRM.Data.Infrastructure;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace LOG.PropznetCRM.Data.UI
{
    public class GlobalIdentityInjector : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            var authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var serializer = new JavaScriptSerializer();
                if (authTicket != null)
                {
                    var sm = serializer.Deserialize<CRMPrincipal>(authTicket.UserData);
                    var userInfo = HttpSessionWrapper.GetFromSession<LOG.PropznetCRM.Data.Infrastructure.UserInfo>(sm.Key);
                    if (userInfo == null)
                    {
                        var userService = DependencyResolver.Current.GetService<IUserService>();
                        var user = userService.GetUserByUsername(sm.Key);
                        if (user != null)
                        {
                            userInfo = UserInfo.GetInstance(user);
                            HttpSessionWrapper.SetInSession(user.RefId, userInfo);
                        }
                    }
                    else
                    {
                        var newUser = new CRMPrincipal(userInfo.Name) { Name = userInfo.Name, Id = userInfo.Id, Role = userInfo.Role, Email = userInfo.Email, PermissionCodes = userInfo.PermissionCodes, Image = userInfo.Image, };
                        HttpSessionWrapper.SetInSession(newUser.Key, userInfo);
                        HttpContext.Current.User = newUser;
                    }
                }
            }
        }
    }
}