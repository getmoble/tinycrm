using System.Web.Mvc;
using PropznetCommon.Features.CRM.ViewModel.Lead;
using PropznetCommon.Features.CRM.ViewModel.User;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class LeadController : BaseUIController
    {

        public ActionResult Index()
        {
            return RedirectIfNotLoggedIn(View);
        }
        public ActionResult Create()
        {
            return RedirectIfNotLoggedIn(() =>
            {
                LeadViewModel userVm = new LeadViewModel();
                userVm.UserId = WebUser.Id;
                return View("Create", userVm);
            });
        }
        public ActionResult Edit(long id=1)
        {
            return RedirectIfNotLoggedIn(() =>
            {
                ViewBag.LeadId = id;
                return View();
            });
        }
        public ActionResult ConvertLead(int id)
        {
            return RedirectIfNotLoggedIn(() =>
            {
                ViewBag.LeadId = id;
                return View();
            });
        }
        public ActionResult Details(long id)
        {
            return RedirectIfNotLoggedIn(() =>
            {
                ViewBag.LeadId = id;
                return View();
            });
        }
    }
}