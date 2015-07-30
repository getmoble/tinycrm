using CRMLite.Infrastructure;
using CRMLite.Infrastructure.Enum;
using System.Web.Mvc;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class AgentController : BaseUIController
    {
        public ActionResult Index()
        {
            return View();
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
            ViewBag.AgentId = id;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Details(long id)
        {
            ViewBag.AgentId = id;
            return View();
        }
    }
}