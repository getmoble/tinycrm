using System.Web.Mvc;
using CRMLite.Infrastructure;
using CRMLite.Infrastructure.Enum;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class PotentialController : BaseUIController
    {
        public ActionResult Index()
        {
            return RedirectIfNotLoggedIn(View);
        }
        public ActionResult Create()
        {
            return RedirectIfNotLoggedIn(View);
        }
        public ActionResult Edit(long id)
        {
            return RedirectIfNotLoggedIn(() =>
            {
                if (PermissionChecker.CheckPermission(WebUser.PermissionCodes, PermissionCodes.ManagePotential))
                {
                    ViewBag.PotentialId = id;
                    return View();
                }
                else
                {
                    return Redirect("Index");
                }
            });
        }

        public ActionResult Details(long id)
        {
            return RedirectIfNotLoggedIn(() =>
            {
                ViewBag.PotentialId = id;
                return View();
            });
        }
	}
}