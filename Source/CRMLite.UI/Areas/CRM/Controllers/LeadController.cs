using System.Web.Mvc;
using PropznetCommon.Features.CRM.ViewModel.Lead;

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
            return RedirectIfNotLoggedIn(View);
        }
        public ActionResult Edit(long id=1)
        {
            ViewBag.LeadId = id;
            return View();
        }
        public ActionResult ConvertLead(int id)
        {
            ViewBag.LeadId = id;
            return View();
        }
        public ActionResult Details(long id)
        {
            ViewBag.LeadId = id;
            return View();
        }
    }
}