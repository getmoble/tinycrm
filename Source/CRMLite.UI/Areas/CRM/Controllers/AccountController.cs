using System.Web.Mvc;
using CRMLite.Infrastructure;
using CRMLite.Infrastructure.Enum;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class AccountController : BaseUIController
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
                if (PermissionChecker.CheckPermission(WebUser.PermissionCodes, PermissionCodes.ManageAccount))
                {
                    ViewBag.AccountId = id;
                    return View();
                }
                else
                {
                    return Redirect("Index");
                }
            });
        }

	}
}