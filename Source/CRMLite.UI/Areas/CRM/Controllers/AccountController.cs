using System.Web.Mvc;
using CRMLite.Infrastructure;
using CRMLite.Infrastructure.Enum;
using PropznetCommon.Features.CRM.ViewModel.User;
using PropznetCommon.Features.CRM.ViewModel.Account;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    [RoutePrefix("account")]
    [Route("{action=index}")]
    public class AccountController : BaseUIController
    {
        public ActionResult Index()
        {
            return RedirectIfNotLoggedIn(View);
        }
        public ActionResult Create()
        {
            return RedirectIfNotLoggedIn(() =>
            {
                AccountViewModel userVm = new AccountViewModel();
                userVm.UserId = WebUser.Id;
                return View("Create", userVm);
            });
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