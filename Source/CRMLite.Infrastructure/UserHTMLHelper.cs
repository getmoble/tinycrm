using System;
using System.Web;

namespace CRMLite.Infrastructure
{
    public static class UserHTMLHelper
    {
        static CRMLitePrincipal WebUser
        {
            get { return HttpContext.Current.User as CRMLitePrincipal; }
        }
        public static string RenderUserName()
        {
            if (WebUser != null)
            {
                string userName="";
                if (!String.IsNullOrEmpty(WebUser.Name))
                {
                    userName = WebUser.Name;
                }
                return "Hi, "+userName;
            }
            return "Hi,Guest";
        }
    }
}