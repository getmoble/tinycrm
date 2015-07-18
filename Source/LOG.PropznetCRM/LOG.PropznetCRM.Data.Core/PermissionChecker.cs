using LOG.PropznetCRM.Data.Entities.Enum;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.Core
{
   public class PermissionChecker
    {
       public static bool CheckPermission(IList<int> userPermissions,PermissionCodes permissioncode)
       {
           if (userPermissions != null)
           {
               var permissionCode = (int)permissioncode;
               return userPermissions.Contains(permissionCode);
           }
           
           return false;
       }

       public static HtmlString MenuForUser(IList<int> userPermissions)
       {
           var builder = new StringBuilder();

           var dashboardMenuLi = new TagBuilder("li");
           if (CheckPermission(userPermissions, PermissionCodes.DashBoard))
               dashboardMenuLi.InnerHtml = "<a href=/Home/Index><i class=fa fa-dashboard icon> <b class=bg-danger></b> </i> <span>Dashboard</span></a>";

           var leadMenuLi = new TagBuilder("li");
           if (CheckPermission(userPermissions, PermissionCodes.ViewLead))
               leadMenuLi.InnerHtml = "<a href=/Lead/Index><i class=fa fa-columns icon> <b class=bg-warning></b> </i>  <span>Leads</span></a>";

           var accountMenuLi = new TagBuilder("li");
           if(CheckPermission(userPermissions,PermissionCodes.ViewAccount))
               accountMenuLi.InnerHtml = "<a href=/Account/Index><i class=fa fa-dollar> <b class=bg-success></b> </i> <span>Accounts</span></a>";

           var contactMenuLi = new TagBuilder("li");
           if (CheckPermission(userPermissions, PermissionCodes.ViewContact))
               contactMenuLi.InnerHtml = "<a href=/Contact/Index><i class=fa fa-envelope> <b class=bg-primary></b> </i> <span>Contacts</span></a>";

           var potentialMenuLi = new TagBuilder("li");
           if (CheckPermission(userPermissions, PermissionCodes.ViewPotential))
               potentialMenuLi.InnerHtml = "<a href=/Potential/Index><i class=fa fa-envelope-o icon> </i> <b class=bg-light><span>Potentials</span> </a>";

           var agentMenuLi = new TagBuilder("li");
           if (CheckPermission(userPermissions, PermissionCodes.ViewAgent))
               agentMenuLi.InnerHtml = "<a href=/Agent/Index><i class=fa fa-share> <b class=bg-info></b> </i> <span>Agents</span></a>";


           builder.Append(accountMenuLi);
           builder.AppendLine(agentMenuLi.ToString());
           builder.AppendLine(contactMenuLi.ToString());
           builder.AppendLine(leadMenuLi.ToString());
           builder.AppendLine(potentialMenuLi.ToString());
           return new HtmlString(builder.ToString());
       }
    }
}