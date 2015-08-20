using CRMLite.Infrastructure;
using CRMLite.Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class LeadSourceController : BaseUIController
    {
        //
        // GET: /CRM/LeadSource/
        public ActionResult Index()
        {
             if(RoleChecker.CheckRole(ViewBag.RoleId, RoleIds.Admin))
            return RedirectIfNotLoggedIn(View);
            else
                 return RedirectIfNotAutherized();
        }
	}
}