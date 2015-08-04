using System.Web.Mvc;
using CRMLite.Infrastructure;
using CRMLite.Infrastructure.Enum;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class ContactController : BaseUIController
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
                if (PermissionChecker.CheckPermission(WebUser.PermissionCodes, PermissionCodes.ManageContact))
                {
                    ViewBag.ContactId = id;
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
                ViewBag.ContactId = id;
                return View();
            });
        }
    }
}
