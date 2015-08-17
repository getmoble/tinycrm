using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.UI.Web.Infrastructure;
using CRMLite.Infrastructure;

namespace CRMLite.UI
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
                    var sm = serializer.Deserialize<UserCoockieData>(authTicket.UserData);
                    var userInfo = HttpSessionWrapper.GetFromSession<UserInfo>(sm.Key);
                    if (userInfo == null)
                    {
                        var userService = DependencyResolver.Current.GetService<IUserService>();
                        var user = userService.GetUserBykey(sm.Key);
                        var permissionCodes = userService.GetAllUserPermissions(user.Id);

                        if (user != null&&permissionCodes!=null)
                        {
                            userInfo = UserInfo.GetInstance(user);
                            userInfo.PermissionCodes = permissionCodes;
                            HttpSessionWrapper.SetInSession(user.RefId, userInfo);
                            var newUser = new CRMLitePrincipal(userInfo.Name) { Name = userInfo.Name, Id = userInfo.Id, Role = userInfo.Role, Email = userInfo.Email, PermissionCodes = userInfo.PermissionCodes, Image = userInfo.Image, RoleId = userInfo.RoleId };
                            HttpContext.Current.User = newUser;
                        }
                        else
                        {
                        //we don't have to handle if we don't set the principal throwifnotlogin will redirect to login page.
                        }
                    }
                    else
                    {
                        var newUser = new CRMLitePrincipal(userInfo.Name) { Name = userInfo.Name, Id = userInfo.Id, Role = userInfo.Role, Email = userInfo.Email, PermissionCodes = userInfo.PermissionCodes, Image = userInfo.Image, RoleId = userInfo.RoleId };
                        //HttpSessionWrapper.SetInSession(newUser.Key, userInfo);
                        HttpContext.Current.User = newUser;
                    }
                }
            }
        }
    }
}