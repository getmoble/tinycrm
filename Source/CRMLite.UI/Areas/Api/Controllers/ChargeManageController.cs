using Common.Utilities;
using PropznetCommon.Features.ERP.Entities.Enum;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Charge;
using PropznetCommon.Features.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class ChargeManageController : Controller
    {
        readonly IChargeService _chargeServivce;
        public ChargeManageController(IChargeService chargeServivce)
        {
            _chargeServivce = chargeServivce;
        }
        
         //GET: /Api/ChargeManage/
        public ActionResult Index()
        {
            var getChargeType = Enum.GetValues(typeof(ChargeType)).Cast<ChargeType>();
            var chargeType = getChargeType.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription(i), Value = ((int)i).ToString() });
            return Json(chargeType,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateCharge(ChargeViewModel vm)
        {
            var charge = new ChargeModel(vm);
            var createCharge = _chargeServivce.CreateCharge(charge);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCharges()
        {
            var charges = _chargeServivce.GetAllCharge();
            var vm = new List<ChargeViewModel>();
            foreach(var charge in charges)
            {
                var viewModel = new ChargeViewModel(charge);
                vm.Add(viewModel);
            }
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteCharge(long id)
        {
            var deleteCharge = _chargeServivce.DeleteCharge(id);
            return Json(deleteCharge);
        }
	}
}