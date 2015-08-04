using CRMLite.Infrastructure;
using CRMLite.Infrastructure.Enum;
using System.Web.Mvc;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class AgentController : BaseUIController
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
                if (PermissionChecker.CheckPermission(WebUser.PermissionCodes, PermissionCodes.ManageAgent) || RoleChecker.CheckRole(WebUser.RoleId,RoleIds.Agent))
                {
                    ViewBag.AgentId = id;
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
                ViewBag.AgentId = id;
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
                ViewBag.AgentId = id;
                return View();
            });
        }
    }
}