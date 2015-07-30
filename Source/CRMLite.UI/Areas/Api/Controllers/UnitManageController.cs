using System;
using System.Linq;
using System.Web.Mvc;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Utilities;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Amenity;
using PropznetCommon.Features.ERP.Model.Unit;
using PropznetCommon.Features.ERP.ViewModel;
using System.Collections.Generic;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class UnitManageController : BaseApiController
    {
        readonly IPropertyService _propertyService;
        readonly IPortfolioService _portfolioService;
        readonly IUserService _userService;
        readonly ILocationService _locationService;
        readonly IAmenityService _amenityService;
        readonly IUnitService _unitService;
        readonly IManagerService _managerService;
        readonly IUnitTypeService _unitTypeService;
        readonly IUnitAmenityMapService _unitAmenityMapService;
        readonly IUnitManagerMapService _unitManagerMapService;
        readonly IUnitOwnerMapservice _unitOwnerMapService;
        private readonly IChargeService _chargeServivce;
        private readonly IUnitRentInfoMapService _unitRentInfoMapService;
        private readonly IUnitRentalCommissionService _unitRentalCommissionService;
        private readonly IUnitRentalCommissionMapService _unitRentalCommissionMapService;
        public UnitManageController(IPropertyService propertyService, IPortfolioService portfolioService,
            IUserService userService, ILocationService locationService, IAmenityService amenityService,
            IUnitService unitService, IManagerService managerService, IUnitTypeService unitTypeService,
              IUnitAmenityMapService unitAmenityMapService, IUnitManagerMapService unitManagerMapService,
            IUnitRentalCommissionMapService unitRentalCommissionMapService,
            IUnitOwnerMapservice unitOwnerMapService, IChargeService chargeServivce,IUnitRentInfoMapService unitRentInfoMapService,
            IUnitRentalCommissionService unitRentalCommissionService)
        {
            _propertyService = propertyService;
            _portfolioService = portfolioService;
            _userService = userService;
            _locationService = locationService;
            _amenityService = amenityService;
            _unitService = unitService;
            _managerService = managerService;
            _unitTypeService = unitTypeService;
            _unitAmenityMapService = unitAmenityMapService;
            _unitManagerMapService = unitManagerMapService;
            _unitOwnerMapService = unitOwnerMapService;
            _chargeServivce = chargeServivce;
            _unitRentInfoMapService = unitRentInfoMapService;
            _unitRentalCommissionService = unitRentalCommissionService;
            _unitRentalCommissionMapService = unitRentalCommissionMapService;
        }
         [HttpGet]
         public ActionResult Init()
         {
             var getPropertyCategory = Enum.GetValues(typeof(ERPPropertyCategory)).Cast<ERPPropertyCategory>();
             var propertyCategory = getPropertyCategory.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription<ERPPropertyCategory>(i), Value = ((int)i).ToString() });
             var getMeasurementUnit = Enum.GetValues(typeof(MeasurementUnit)).Cast<MeasurementUnit>();
             var measurementUnit = getMeasurementUnit.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription<MeasurementUnit>(i), Value = ((int)i).ToString() });
             var getRentalTerm = Enum.GetValues(typeof(RentalTerm)).Cast<RentalTerm>();
             var rentalTerm = getRentalTerm.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription<RentalTerm>(i), Value = ((int)i).ToString() });
             var getFurnishType = Enum.GetValues(typeof(FurnishType)).Cast<FurnishType>();
             var furnishType = getFurnishType.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription<FurnishType>(i), Value = ((int)i).ToString() });
             var getVaccancy = Enum.GetValues(typeof(Vaccancy)).Cast<Vaccancy>();
             var vaccancy = getVaccancy.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription<Vaccancy>(i), Value = ((int)i).ToString() });
             var getCommissionType = Enum.GetValues(typeof(ERPCommissionType)).Cast<ERPCommissionType>();
             var commissionType = getCommissionType.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription(i), Value = ((int)i).ToString() });
             var countries = _locationService.GetAllCountries();
             var unitTypes = _unitTypeService.GetAllUnitType();
             var users = _userService.GetAllUsers();
             var amenities = _amenityService.GetAllAmenities();
             var managers = _managerService.GetAllManagers();
             var properties = _propertyService.GetAllProperties();
             var charges = _chargeServivce.GetAllCharge();
             var data = new { PropertyCategory = propertyCategory,
                                MeasurementUnit = measurementUnit, 
                                RentalTerm = rentalTerm,
                                FurnishType = furnishType,
                                Vaccancies = vaccancy,  
                                Countries = countries,
                                Users=users,
                                Amenities = amenities,
                                UnitTypes = unitTypes,
                                Properties = properties,
                                Managers = managers,
                                Charges = charges,
                                CommissionType = commissionType
                            };
             return Json(data, JsonRequestBehavior.AllowGet);
         }
         [HttpGet]
         public ActionResult GetAllUnits()
         {
             var units = _unitService.GetAllUnits();
             var data = new { Units = units };
             return Json(data, JsonRequestBehavior.AllowGet);
         }
         [HttpPost]
         public ActionResult GetAllStatesByCountry(long countryId)
         {
             var states = _locationService.GetAllStatesByCountry(countryId);
             var data = new { States = states };
             return Json(data, JsonRequestBehavior.AllowGet);
         }
         [HttpPost]
         public ActionResult GetAllCitiesByState(long stateId)
         {
             var cities = _locationService.GetAllCitiesByState(stateId);
             var data = new { Cities = cities };
             return Json(data, JsonRequestBehavior.AllowGet);
         }
         [HttpPost]
         public ActionResult CreateUnit(UnitViewModel vm)
        {
            var unit = new UnitModel(vm);
            var newUnit = _unitService.CreateUnit(unit);
            if (newUnit != null)
            {
                TempData["InfoMessageForUnit"] = "Unit Created Successfully!";
                var data = new { Unit = newUnit };
                return Json(data);
            }
            else
                return Json(false);
        }
         [HttpGet]
         public ActionResult EditUnit(long id)
         {
             var unit = _unitService.GetUnitById(id);
             var owners = _unitOwnerMapService.GetAllOwnerByUnitId(id);
             var managers = _unitManagerMapService.GetAllManagerByUnitId(id);
             var amenities = _unitAmenityMapService.GetAllAmenityByUnitId(id);
             var rentInfo = _unitRentInfoMapService.GetAllRentInfosByUnitId(id);
             var rentalCommission = _unitRentalCommissionService.GetAllUnitRentalCommissions();
             var vm = new
             {
                 Unit = unit,
                 Amenities = amenities,
                 Owners = owners,
                 Managers = managers,
                 RentInfo = rentInfo,
                 RentalCommission = rentalCommission
             };
             return Json(vm, JsonRequestBehavior.AllowGet);
         }
         [HttpPost]
         public ActionResult CreateMoreUnit(SaveMoreUnitInformationViewModel vm)
         {
             long rentMarketingInfoId = 0;
             long saleMarketingInfoId = 0;            

             if (vm.AminityId != null)
             {
                 var unitAmenityMapModel = new UnitAmenityMapModel
                 {
                     AmenityId = vm.AminityId,
                     UnitId = vm.UnitId
                 };
                 _unitAmenityMapService.CreateUnitAmenityMap(unitAmenityMapModel);
             }

             if (vm.ManagersId != null)
             {
                 var unitManagerMapModel = new UnitManagerMapModel
                 {
                     ManagerId = vm.ManagersId,
                     UnitId = vm.UnitId
                 };
                 _unitManagerMapService.CreateUnitManagerMap(unitManagerMapModel);
             }

             if (vm.OwnersId != null)
             {
                 var propertyOwnerMapModel = new UnitOwnerMapModel
                 {
                     OwnerId = vm.OwnersId,
                     UnitId = vm.UnitId
                 };
                 _unitOwnerMapService.CreatePropertyOwnerMap(propertyOwnerMapModel);
             }

             if (vm.PropertyRentalCommission != null)
             {
                 IList<long> unitRentalCommissionModelIdsList = new List<long>();
                 _unitRentalCommissionService.DeleteAllUnitRentalCommissionByUnitId(vm.UnitId);
                 foreach (UnitRentalCommissionViewModel unitRentalCommissionViewModel in vm.PropertyRentalCommission)
                 {
                     var unitRentalCommissionModel = new UnitRentalCommissionModel
                     {
                         Amount = unitRentalCommissionViewModel.Amount,
                         GLAccount = unitRentalCommissionViewModel.GLAccount,
                         ChargeId = unitRentalCommissionViewModel.ChargeId,
                         Month = unitRentalCommissionViewModel.Month,
                         Type = unitRentalCommissionViewModel.Type
                     };
                     var createdpropertyRentalCommission =
                         _unitRentalCommissionService.CreateUnitRentalCommission(unitRentalCommissionModel);
                     unitRentalCommissionModelIdsList.Add(createdpropertyRentalCommission.Id);
                 }
                 if (unitRentalCommissionModelIdsList.Count > 0)
                 {
                     var unitRentalCommissionMapModel = new UnitRentalCommissionMapModel
                     {
                         UnitId = vm.UnitId,
                         UnitRentalCommissionIds = unitRentalCommissionModelIdsList
                     };
                     _unitRentalCommissionMapService.CreateUnitRentalCommissionMap(
                         unitRentalCommissionMapModel);
                 }
             }

             if (vm.SalesCommissionViewModel != null)
             {
                 var commissionType = ERPCommissionType.Percentage;
                 if (vm.SalesCommissionViewModel.IsPercentage == "Flat")
                 {
                     commissionType = ERPCommissionType.Flat;
                 }
                 else if (vm.SalesCommissionViewModel.IsPercentage == "Percentage")
                 {
                     commissionType = ERPCommissionType.Percentage;
                 }
                 var salesCommissionModel = new SalesCommissionModel
                 {
                     UnitId = vm.UnitId,
                     SalesCommission = vm.SalesCommissionViewModel.Comission,
                     CommissionType = commissionType
                 };
                 _unitService.UpdateSalesCommissionDetails(salesCommissionModel);
             }
             return Json(true);
         }
         [HttpPost]
         public ActionResult CreateAminity(AmenityViewModel vm)
         {
             var amenity = new AmenityModel(vm);
             var newAmenity = _amenityService.CreateAmenity(amenity);
             if (newAmenity != null)
                 return Json(true);
             else
                 return Json(false);
         }
         [HttpPost]
         public ActionResult UpdateUnit(UnitViewModel vm)
         {
             var unit = new UnitModel(vm);
             var newOwner = _unitService.UpdateUnit(unit);
             if (unit != null)
                 return Json(true);
             else
                 return Json(false);
         }
         [HttpPost]
         public ActionResult DeleteUnit(long id)
         {
             var unit = _unitService.DeleteUnit(id);
             return Json(unit, JsonRequestBehavior.AllowGet);
         }
	}
}