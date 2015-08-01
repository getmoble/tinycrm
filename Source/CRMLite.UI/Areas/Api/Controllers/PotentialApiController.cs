using Common.Utilities;
using CRMLite.Infrastructure;
using CRMLite.Infrastructure.Enum;
using Newtonsoft.Json;
using PropznetCommon.Features.CRM.Entities.Enum;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Potential;
using PropznetCommon.Features.CRM.Model.Property;
using PropznetCommon.Features.CRM.ViewModel.Potential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class PotentialApiController : BaseApiController
    {
        readonly IPotentialService _potentialService;
        readonly ILeadSourceService _leadSourceService;
        readonly ILeadStatusService _leadStatusService;
        readonly ISalesStageService _salesStageService;
        readonly IContactService _contactService;
        readonly IAgentService _agentService;
        readonly ILocationService _locationService;
        readonly IStateService _stateService;
        readonly IAccountService _accountService;
        readonly IPropertyCategoryService _propertyCategoryService;
        readonly IPropertyService _propertyService;
        public PotentialApiController(IPotentialService potentialService,
                                      ILeadSourceService leadSourceService,
                                      ILeadStatusService leadStatusService,
                                      ISalesStageService salesStageService,
                                      IContactService contactService,
                                      IAgentService agentService,
                                      IStateService stateService,
                                      ILocationService locationService,
                                      IPropertyCategoryService propertyCategoryService,
                                      IAccountService accountService,
                                      IPropertyService propertyService)
        {
            _potentialService = potentialService;
            _leadSourceService = leadSourceService;
            _leadStatusService = leadStatusService;
            _salesStageService = salesStageService;
            _contactService = contactService;
            _agentService = agentService;
            _stateService = stateService;
            _locationService = locationService;
            _accountService = accountService;
            _propertyService = propertyService;
            _propertyCategoryService = propertyCategoryService;
        }
        public ActionResult GetAllPotential()
        {
            return ExecuteIfValid(() =>
            {
                if (!RoleChecker.CheckRole(WebUser.RoleId, RoleIds.Admin))
                {
                    var potentials = _potentialService.GetAllPotentials(WebUser.Id, WebUser.PermissionCodes).ToList();
                    var leadsource = _leadSourceService.GetAllLeadSources();
                    var leadstatus = _leadStatusService.GetAllLeadStatuses();
                    var salesstage = _salesStageService.GetAllSalesStages();
                    var agents = _agentService.GetAllAgents();
                    var contacts = _contactService.GetAllContacts();
                    var categories = _propertyCategoryService.GetAllPropertyCategories();
                    var propertytype = Enum.GetValues(typeof(CRMPropertyType)).Cast<CRMPropertyType>();
                    var countries = _locationService.GetAllCountries();
                    var getpropertytype = propertytype.Select(i => new SelectListItem
                    {
                        Text = i.ToString(),
                        Value = ((int)i).ToString()
                    });
                    var states = _stateService.GetAllStates();
                    var accounts = _accountService.GetAllAccountsByUserId(WebUser.Id, WebUser.PermissionCodes);
                    var potentialvm = new List<PotentialViewModel>();
                    string propertyType = null;
                    foreach (var potential in potentials)
                    {

                        if (potential.Property != null)
                        {
                            propertyType = EnumUtils.GetEnumDescription(potential.Property.PropertyType);
                        }
                        var model = new PotentialViewModel
                        {
                            Name = potential.Name,
                            ExpectedAmount = potential.ExpectedAmount,
                            ExpectedCloseDate = potential.ExpectedCloseDate.ToString(),
                            ShowingDate = potential.ExpectedCloseDate.DateTime.ToShortDateString(),
                            LeadSourceName = potential.LeadSource.Name,
                            AccountName = potential.Account.Name,
                            PropertyType = propertyType,
                            Id = potential.Id,
                            AgentId = potential.AgentId,
                            AgentName = potential.Agent.FirstName,
                            SalesStageName = potential.SalesStage.Name,
                            RefId = potential.RefId,
                        };
                        potentialvm.Add(model);
                    }
                    var returnData = new
                    {
                        Potential = JsonConvert.SerializeObject(potentialvm),
                        LeadStatus = leadstatus,
                        LeadSource = leadsource,
                        SalesStage = salesstage,
                        Contacts = contacts,
                        Agents = agents,
                        Propertytype = getpropertytype,
                        States = states,
                        Category = categories,
                        Accounts = accounts,
                        Countries = countries
                    };
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var potentials = _potentialService.GetAllPotentials(WebUser.PermissionCodes);
                    var leadsource = _leadSourceService.GetAllLeadSources();
                    var leadstatus = _leadStatusService.GetAllLeadStatuses();
                    var salesstage = _salesStageService.GetAllSalesStages();
                    var agents = _agentService.GetAllAgents();
                    var contacts = _contactService.GetAllContacts();
                    var countries = _locationService.GetAllCountries();
                    var categories = _propertyCategoryService.GetAllPropertyCategories();
                    var propertytype = Enum.GetValues(typeof(CRMPropertyType)).Cast<CRMPropertyType>();
                    var getpropertytype = propertytype.Select(i => new SelectListItem
                    {
                        Text = i.ToString(),
                        Value = ((int)i).ToString()
                    });
                    var states = _stateService.GetAllStates();
                    var accounts = _accountService.GetAllAccountsByUserId(WebUser.Id, WebUser.PermissionCodes);
                    var potentialvm = new List<PotentialViewModel>();
                    string propertyType = null;
                    foreach (var potential in potentials)
                    {

                        if (potential.Property != null)
                        {
                            propertyType = EnumUtils.GetEnumDescription(potential.Property.PropertyType);
                        }
                        var model = new PotentialViewModel
                        {
                            Name = potential.Name,
                            ExpectedAmount = potential.ExpectedAmount,
                            ExpectedCloseDate = potential.ExpectedCloseDate.ToString(),
                            ShowingDate = potential.ExpectedCloseDate.DateTime.ToShortDateString(),
                            LeadSourceName = potential.LeadSource.Name,

                            AccountName = potential.Account.Name,
                            PropertyType = propertyType,
                            Id = potential.Id,
                            AgentId = potential.AgentId,
                            AgentName = potential.Agent.FirstName,
                            SalesStageName = potential.SalesStage.Name,
                            RefId = potential.RefId,
                        };
                        potentialvm.Add(model);
                    }
                    var returnData = new
                    {
                        Potential = JsonConvert.SerializeObject(potentialvm),
                        LeadStatus = leadstatus,
                        LeadSource = leadsource,
                        SalesStage = salesstage,
                        Contacts = contacts,
                        Agents = agents,
                        Propertytype = getpropertytype,
                        Countries = countries,
                        States = states,
                        Category = categories,
                        Accounts = accounts
                    };
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }
            },
            () =>
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            },
            error =>
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            });
        }
        public ActionResult GetAllCountries()
        {
            var countries = _locationService.GetAllCountries();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllStates(long id)
        {
            var states = _locationService.GetAllStatesByCountry(id);
            return Json(states, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllCities(long id)
        {
            var cities = _locationService.GetAllCitiesByState(id);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeletePotential(long id)
        {
            var potential = _potentialService.DeletePotential(id);
            return Json(potential, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLocations(long id)
        {
            var locations = _locationService.GetAllCitiesByState(id);
            return Json(locations, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreatePotential(PotentialModel potentialModel)
        {
            var propertyModel = new PropertyModel
            {
                Area = potentialModel.Area,
                BudgetFrom = potentialModel.BudgetFrom,
                BudgetTo = potentialModel.BudgetTo,
                Floor = potentialModel.Floor,
                Baths = potentialModel.Baths,
                Beds = potentialModel.Beds,
                CityId = potentialModel.CityId,
                PropertyCategoryId = potentialModel.selectedPropertyCategory,
                PropertyType = potentialModel.selectedProperty,
                // StateId = potentialModel.selectedState,
            };
            var createProperty = _propertyService.CreateProperty(propertyModel);
            potentialModel.PropertyId = createProperty.Id;
            potentialModel.CreatedBy = WebUser.Id;
            _potentialService.CreatePotential(potentialModel, SiteSettings.Potentialprefix);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPotential(long id)
        {
            var potential = _potentialService.GetPotential(id);
            var vm = new
            {
                Potential = potential
            };
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(long id)
        {
            var potential = _potentialService.GetPotential(id);
            var propertyType = "";
            if (potential.Property != null)
                propertyType = EnumUtils.GetEnumDescription(potential.Property.PropertyType);
            var propertyArea = potential.Coalesce(p => p.Property, a => a.Area, 0);  //potential.Property.Area; 
            var propertyBudgetFrom = potential.Coalesce(p => p.Property, a => a.BudgetFrom, 0);
            var propertyBudgetTo = potential.Coalesce(p => p.Property, a => a.BudgetTo, 0);
            var propertyCategory = potential.Coalesce(p => p.Property, a => a.PropertyCategory, n => n.Name, "");
            var propertyFloor = potential.Coalesce(p => p.Property, a => a.Floor, 0);
            var potentialvm = new PotentialViewModel
            {
                Name = potential.Name,
                ExpectedAmount = potential.ExpectedAmount,
                ExpectedCloseDate = potential.ExpectedCloseDate.ToString(),
                ShowingDate = potential.ExpectedCloseDate.DateTime.ToShortDateString(),
                LeadSourceName = potential.LeadSource.Name,
                AccountName = potential.Account.Name,
                PropertyType = propertyType,
                Id = potential.Id,
                AgentId = potential.AgentId,
                AgentName = potential.Agent.FirstName,
                SalesStageName = potential.SalesStage.Name,
                RefId = potential.RefId,
                ContactName = potential.Contact.FirstName,
                ContactNo = potential.Contact.RefId,
                AccountNo = potential.Account.RefId,
                Industry = potential.Account.Industry,
                ContactTitle = potential.Contact.Title,
                PropertyArea = propertyArea,
                PropertyBudgetFrom = propertyBudgetFrom,
                PropertyBudgetTo = propertyBudgetTo,
                PropertyCategory = propertyCategory,
                PropertyFloor = propertyFloor
            };
            return Json(potentialvm, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdatePotential(PotentialModel potentialModel)
        {
            if (potentialModel.PropertyId > 0)
            {
                if (potentialModel.PropertyId != null)
                {
                    var propertyModel = new PropertyModel
                    {
                        Area = potentialModel.Area,
                        BudgetFrom = potentialModel.BudgetFrom,
                        BudgetTo = potentialModel.BudgetTo,
                        Floor = potentialModel.Floor,
                        Baths = potentialModel.Baths,
                        Beds = potentialModel.Beds,
                        //LocationId = potentialModel.selectedLocation,
                        PropertyCategoryId = potentialModel.selectedPropertyCategory,
                        PropertyType = potentialModel.selectedProperty,
                        //StateId = potentialModel.selectedState,
                        Id = potentialModel.PropertyId.Value
                    };
                    _propertyService.UpdateProperty(propertyModel);
                }
            }
            _potentialService.UpdatePotential(potentialModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(PotentialSearchFilter potentialSearchFilter)
        {
            potentialSearchFilter.UserId = WebUser.Id;
            var potentialSearchResult = _potentialService.Search(potentialSearchFilter, 0, 0);
            var potentialvm = new List<PotentialViewModel>();
            foreach (var potential in potentialSearchResult.Items)
            {
                var model = new PotentialViewModel
                {
                    Name = potential.Name,
                    ExpectedAmount = potential.ExpectedAmount,
                    ExpectedCloseDate = potential.ExpectedCloseDate.ToString(),
                    ShowingDate = potential.ExpectedCloseDate.ToString(),
                    LeadSourceName = potential.LeadSource.Name,
                    AccountName = potential.Account.Name,
                    PropertyType = EnumUtils.GetEnumDescription(potential.Property.PropertyType),
                    Id = potential.Id,
                    AgentId = potential.AgentId,
                    AgentName = potential.Agent.FirstName,
                    SalesStageName = potential.SalesStage.Name,
                    RefId = potential.RefId
                };
                potentialvm.Add(model);
            }
            return Json(JsonConvert.SerializeObject(potentialvm), JsonRequestBehavior.AllowGet);
        }

    }
}