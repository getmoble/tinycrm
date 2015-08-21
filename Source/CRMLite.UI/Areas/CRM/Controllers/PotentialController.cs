using System.Web.Mvc;
using CRMLite.Infrastructure;
using CRMLite.Infrastructure.Enum;
using PropznetCommon.Features.CRM.ViewModel.User;
using PropznetCommon.Features.CRM.ViewModel.Potential;

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
            return RedirectIfNotLoggedIn(() =>
            {
                PotentialViewModel userVm = new PotentialViewModel();
                userVm.UserId = WebUser.Id;
                return View("Create", userVm);
            });
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