using CRMLite.Infrastructure;
using CRMLite.Infrastructure.Enum;
using System.Web.Mvc;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class UserController : BaseUIController
    {
        public ActionResult Index()
        {
            return RedirectIfNotLoggedIn(() =>
            {
                return View();
            });
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            return RedirectIfNotLoggedIn(() =>
            {
                if (PermissionChecker.CheckPermission(WebUser.PermissionCodes, PermissionCodes.ManageUser) || RoleChecker.CheckRole(WebUser.RoleId,RoleIds.User))
                {
                    ViewBag.UserId = id;
                    return View();
                }
                else
                {
                    return View();
                }
            });
        }

        public ActionResult Edit(int id)
        {
            return RedirectIfNotLoggedIn(() =>
            {
                ViewBag.UserId = id;
                return View();
            });
        }

        public ActionResult Create()
        {
            return RedirectIfNotLoggedIn(() =>
            {
                return View();
            });
        }
        public ActionResult Details(long id)
        {
            return RedirectIfNotLoggedIn(() =>
            {
                ViewBag.UserId = id;
                return View();
            });
        }
    }
}