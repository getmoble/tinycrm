using System;
using System.Collections;
using System.Linq;
using System.Web.Mvc;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Utilities;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Amenity;
using PropznetCommon.Features.ERP.Model.MarketingInformation;
using PropznetCommon.Features.ERP.Model.Property;
using PropznetCommon.Features.ERP.ViewModel;
using System.Collections.Generic;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class PropertyManageController : BaseApiController
    {
        //
        // GET: /Api/PropertyManage/
        readonly IPropertyService _propertyService;
        readonly IPortfolioService _portfolioService;
        readonly IUserService _userService;
        readonly ILocationService _locationService;
        readonly IAmenityService _amenityService;
        readonly IUnitService _unitService;
        readonly IManagerService _managerService;
        readonly IRentMarketingInformationService _rentMarketingInformationService;
        readonly ISaleMarketingInformationService _saleMarketingInformationService;
        readonly IPropertyAmenityMapService _propertyAmenityMapService;
        readonly IPropertyManagerMapService _propertyManagerMapService;
        readonly IPropertyOwnerMapService _propertyOwnerMapService;
        readonly IPropertyUnitMapService _propertyUnitMapService;
        readonly IPropertyRentInfoMapService _propertyRentInfoMapService;
        private readonly IPropertyRentalCommissionMapService _propertyRentalCommissionMapService;
        readonly IOwnerService _ownerService;
        readonly IChargeService _chargeServivce;
        private readonly IPropertyRentalCommissionService _propertyRentalCommissionService;
        public PropertyManageController(IPropertyService propertyService, IPortfolioService portfolioService,
            IUserService userService, ILocationService locationService, IAmenityService amenityService,
            IUnitService unitService, IManagerService managerService,
            IRentMarketingInformationService rentMarketingInformationService,
            ISaleMarketingInformationService saleMarketingInformationService,
            IPropertyAmenityMapService propertyAmenityMapService,
            IPropertyUnitMapService propertyUnitMapService,
            IPropertyManagerMapService propertyManagerMapService,
            IPropertyOwnerMapService propertyOwnerMapService, IOwnerService ownerService,
            IPropertyRentInfoMapService propertyRentInfoMapService,
            IPropertyRentalCommissionMapService propertyRentalCommissionMapService,
            IChargeService chargeServivce,
            IPropertyRentalCommissionService propertyRentalCommissionService)
        {
            _propertyService = propertyService;
            _portfolioService = portfolioService;
            _userService = userService;
            _locationService = locationService;
            _amenityService = amenityService;
            _unitService = unitService;
            _managerService = managerService;
            _propertyUnitMapService = propertyUnitMapService;
            _ownerService = ownerService;
            _saleMarketingInformationService = saleMarketingInformationService;
            _rentMarketingInformationService = rentMarketingInformationService;
            _propertyAmenityMapService = propertyAmenityMapService;
            _propertyManagerMapService = propertyManagerMapService;
            _propertyOwnerMapService = propertyOwnerMapService;
            _propertyRentInfoMapService = propertyRentInfoMapService;
            _chargeServivce = chargeServivce;
            _propertyRentalCommissionService = propertyRentalCommissionService;
            _propertyRentalCommissionMapService = propertyRentalCommissionMapService;
        }
        [HttpGet]
        public ActionResult Init()
        {
            
            var getPropertyCategory = Enum.GetValues(typeof(ERPPropertyCategory)).Cast<ERPPropertyCategory>();
            var propertyCategory = getPropertyCategory.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription(i), Value = ((int)i).ToString() });
            var getSourceType = Enum.GetValues(typeof(SourceType)).Cast<SourceType>();
            var getCommissionType = Enum.GetValues(typeof(ERPCommissionType)).Cast<ERPCommissionType>();
            var commissionType = getCommissionType.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription(i), Value = ((int)i).ToString() });
            var sourceType = getSourceType.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription(i), Value = ((int)i).ToString() });
            var getMeasurementUnit = Enum.GetValues(typeof(MeasurementUnit)).Cast<MeasurementUnit>();
            var measurementUnit = getMeasurementUnit.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription(i), Value = ((int)i).ToString() });
            var getRentalTerm = Enum.GetValues(typeof(RentalTerm)).Cast<RentalTerm>();
            var rentalTerm = getRentalTerm.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription(i), Value = ((int)i).ToString() });
            var getFurnishType = Enum.GetValues(typeof(FurnishType)).Cast<FurnishType>();
            var furnishType = getFurnishType.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription(i), Value = ((int)i).ToString() });
            var getVaccancy = Enum.GetValues(typeof(Vaccancy)).Cast<Vaccancy>();
            var vaccancy = getVaccancy.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription(i), Value = ((int)i).ToString() });
            var countries = _locationService.GetAllCountries();
            var amenities = _amenityService.GetAllAmenities();
            var units = _unitService.GetAllUnits();
            var managers = _managerService.GetAllManagers();
            var portfolios = _portfolioService.GetAllPortfolios();
            var users = _userService.GetAllUsers();
            var charges = _chargeServivce.GetAllCharge();
            var data = new
            {
                PropertyCategory = propertyCategory,
                SourceType = sourceType,
                CommissionType = commissionType,
                MeasurementUnit = measurementUnit,
                RentalTerm = rentalTerm,
                FurnishType = furnishType,
                Vaccancies = vaccancy,
                Portfolios = portfolios,
                Countries = countries,
                Users = users,
                Amenities = amenities,
                Units = units,
                Managers = managers,
                Charges = charges
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAllProperties()
        {
            var properties = _propertyService.GetAllProperties();
            var data = new { Properties = properties };
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
        public ActionResult CreateProperty(PropertyViewModel vm)
        {
            var property = new PropertyModel(vm);
            var newProperty = _propertyService.CreateProperty(property);
            if (newProperty != null)
            {
                TempData["InfoMessageForProperty"] = "Property Created Successfully!";
                 var data = new { Property = newProperty};
                 return Json(data);
            }
            else
                return Json(false);
        }
        [HttpGet]
        public ActionResult EditPrperty(long id)
        {
            var getSalesCommissionType = Enum.GetValues(typeof(SalesCommissionType)).Cast<SalesCommissionType>();
            var salesCommissionType = getSalesCommissionType.Select(i => new SelectListItem { Text = EnumUtils.GetEnumDescription(i), Value = ((int)i).ToString() });
            var properties = _propertyService.GetPropertyById(id);
            var units = _propertyUnitMapService.GetAllUnitsByPropertyId(id);
            var owners = _propertyOwnerMapService.GetAllOwnersByPropertyId(id);
            var managers = _propertyManagerMapService.GetAllManagerByPropertyId(id);
            var amenities = _propertyAmenityMapService.GetAllAmenityPropertyId(id);
            var rentInfo = _propertyRentInfoMapService.GetAllRentInfosByPropertyId(id);
            var rentalCommission = _propertyRentalCommissionService.GetAllPropertyRentalCommissions();
            var vm = new
            {
                Property = properties,
                Amenities = amenities,
                Units = units,
                Owners = owners,
                Managers = managers,
                RentInfo = rentInfo,
                RentalCommission = rentalCommission,
                SalesCommissionType = salesCommissionType
            };
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateMoreProperty(SaveMorePropertyInformationViewModel vm)
        {
            if (vm.MarketingInformationViewModel != null)
            {
                if (vm.MarketingInformationViewModel.IsRent)
                {
                    var rentMarketingInformationModel = new RentMarketingInformationModel
                    {
                        AdvertisingRent = vm.MarketingInformationViewModel.RentAdvertisingCost,
                        Description = vm.MarketingInformationViewModel.RentDescription,
                        DisplayAmenities = vm.MarketingInformationViewModel.RentDisplayAmenities,
                        DisplayImages = vm.MarketingInformationViewModel.RentDisplayImages,
                        Featured = vm.MarketingInformationViewModel.RentFeatured,
                        PropertyFor = ListingType.Rent,
                        ShowMap = vm.MarketingInformationViewModel.RentShowMap,
                        ShowRent = vm.MarketingInformationViewModel.RentShow,
                        Title = vm.MarketingInformationViewModel.RentTitle,
                        CreatedBy = WebUser.Id
                    };
                    var rentMarketingInformation = _rentMarketingInformationService.CreateRentMarketingInformation(rentMarketingInformationModel);
                    _propertyService.UpdateRentMarketingInformation(rentMarketingInformation.Id, vm.PropertyId);
                }

                if (vm.MarketingInformationViewModel.IsSale)
                {
                    var saleMarketingInformationModel = new SaleMarketingInformationModel
                    {
                        SaleAdvertisingCost = vm.MarketingInformationViewModel.SaleAdvertisingCost,
                        Description = vm.MarketingInformationViewModel.SaleDescription,
                        DisplayAmenities = vm.MarketingInformationViewModel.SaleDisplayAmenities,
                        DisplayImages = vm.MarketingInformationViewModel.SaleDisplayImages,
                        Featured = vm.MarketingInformationViewModel.SaleFeatured,
                        PropertyFor = ListingType.Sale,
                        ShowMap = vm.MarketingInformationViewModel.SaleShowMap,
                        ShowSalePrice = vm.MarketingInformationViewModel.ShowSales,
                        Title = vm.MarketingInformationViewModel.SaleTitle,
                        CreatedBy = WebUser.Id
                    };
                    var saleMarketingInformation = _saleMarketingInformationService.CreateSaleMarketingInformation(saleMarketingInformationModel);
                    _propertyService.UpdateSaleMarketingInformation(saleMarketingInformation.Id, vm.PropertyId);
                }
            }

            if (vm.AminityId != null)
            {
                var propertyAmenityMapModel = new PropertyAmenityMapModel
                {
                    AmenityId = vm.AminityId,
                    PropertyId = vm.PropertyId
                };
                _propertyAmenityMapService.CreatePropertyAmenityMap(propertyAmenityMapModel);
            }

            if (vm.ManagersId != null)
            {
                var propertyManagerMapModel = new PropertyManagerMapModel
                {
                    ManagerId = vm.ManagersId,
                    PropertyId = vm.PropertyId
                };
                _propertyManagerMapService.CreatePropertyManagerMap(propertyManagerMapModel);
            }

            if (vm.OwnersId != null)
            {
                var propertyOwnerMapModel = new PropertyOwnerMapModel
                {
                    OwnerId = vm.OwnersId,
                    PropertyId = vm.PropertyId
                };
                _propertyOwnerMapService.CreatePropertyOwnerMap(propertyOwnerMapModel);
            }
            
            if (vm.PropertyRentalCommission != null)
            {
                IList<long>propertyRentalCommissionModelIdsList=new List<long>();
                _propertyRentalCommissionService.DeleteAllPropertyRentalCommissionByPropertyId(vm.PropertyId);
                foreach (PropertyRentalCommissionViewModel propertyRentalCommissionViewModel in vm.PropertyRentalCommission)
                {
                    var propertyRentalCommissionModel = new PropertyRentalCommissionModel
                    {
                        Amount = propertyRentalCommissionViewModel.Amount,
                        GLAccount = propertyRentalCommissionViewModel.GLAccount,
                        ChargeId = propertyRentalCommissionViewModel.ChargeId,
                        Month = propertyRentalCommissionViewModel.Month,
                        Type = propertyRentalCommissionViewModel.Type
                    };
                    var createdpropertyRentalCommission =
                        _propertyRentalCommissionService.CreatePropertyRentalCommission(propertyRentalCommissionModel);
                    propertyRentalCommissionModelIdsList.Add(createdpropertyRentalCommission.Id);
                }
                if (propertyRentalCommissionModelIdsList.Count>0)
                {
                    var propertyRentalCommissionMapModel = new PropertyRentalCommissionMapModel
                    {
                        PropertyId=vm.PropertyId,
                        PropertyRentalCommissionIds=propertyRentalCommissionModelIdsList
                    };
                    _propertyRentalCommissionMapService.CreatePropertyRentalCommissionMap(
                        propertyRentalCommissionMapModel);
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
                    PropertyId = vm.PropertyId,
                    SalesCommission = vm.SalesCommissionViewModel.Comission,
                    CommissionType = commissionType
                };
                _propertyService.UpdateSalesCommissionDetails(salesCommissionModel);
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
        public ActionResult UpdateProperty(PropertyViewModel vm)
        {
            var property = new PropertyModel(vm);
            var newOwner = _propertyService.UpdateProperty(property);
            if (property != null)
            {
                return Json(true);
            }
            else
                return Json(false);
        }
        [HttpPost]
        public ActionResult DeleteProperty(long id)
        {
            var owner = _propertyService.DeleteProperty(id);
            return Json(owner, JsonRequestBehavior.AllowGet);
        }
    }
}