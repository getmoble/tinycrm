using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Utilities;
using CRMLite.Core.Models;
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
using System.Globalization;
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
        readonly ICRMLiteContactService _contactService;
        readonly PropznetCommon.Features.CRM.Interfaces.Services.IAccountService _crmaccountService;
        readonly IUserService _userService;
        readonly ICountryService _countryService;
        readonly PropznetCommon.Features.CRM.Interfaces.Services.IAccountService _accountService;
        public PotentialApiController(IPotentialService potentialService,
                                      ILeadSourceService leadSourceService,
                                      ILeadStatusService leadStatusService,
                                      ISalesStageService salesStageService,
                                      ICRMLiteContactService contactService,
                                      IUserService userService,
                                      ICountryService countryService,
                                      PropznetCommon.Features.CRM.Interfaces.Services.IAccountService accountService,
            PropznetCommon.Features.CRM.Interfaces.Services.IAccountService crmaccountService)
        {
            _potentialService = potentialService;
            _leadSourceService = leadSourceService;
            _leadStatusService = leadStatusService;
            _salesStageService = salesStageService;
            _contactService = contactService;
            _crmaccountService = crmaccountService;
            _userService = userService;
            _countryService = countryService;
            _accountService = accountService;
        }
        [HttpGet]
        public JsonResult GetAllPotential()
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                    if (!RoleChecker.CheckRole(WebUser.RoleId, RoleIds.Admin))
                    {
                        var potentials = _potentialService.GetAllPotentials(WebUser.Id, WebUser.PermissionCodes).ToList();
                        var leadsource = _leadSourceService.GetAllLeadSources();
                        var leadstatus = _leadStatusService.GetAllLeadStatuses();
                        var salesstage = _salesStageService.GetAllSalesStages();
                        var users = _userService.GetAllUsers().ToList();
                        var contacts = _contactService.GetAllContacts();
                        var countries = _countryService.GetAllCountries();
                        //var states = _stateService.GetAllStates();
                        var accounts = _crmaccountService.GetAllAccountsByUserId(WebUser.Id, WebUser.PermissionCodes);
                        var potentialvm = new List<PotentialViewModel>();
                        string propertyType = null;
                        foreach (var potential in potentials)
                        {
                            var model = new PotentialViewModel
                            {
                                Name = potential.Person.FirstName,
                                ExpectedAmount = potential.ExpectedAmount,
                                ExpectedCloseDate = potential.ExpectedCloseDate.Value.Date.ToShortDateString(),
                                ShowingDate = potential.ExpectedCloseDate.Value.Date.ToShortDateString(),
                                //LeadSourceName = potential.LeadSource.Name,
                                //AccountName = potential.Account.Person.FirstName,
                                //AssignedTo = potential.AssignedToUser.Person.FirstName,
                                PropertyType = propertyType,
                                Id = potential.Id,
                                AgentId = potential.AssignedToUserId,
                                //AgentName = potential.AssignedToUser.Person.FirstName,
                                //SalesStageName = potential.SalesStage.Name,
                                RefId = potential.RefId,
                            };
                            if (potential.LeadSource != null)
                                model.LeadSourceName = potential.LeadSource.Name;
                            if (potential.AssignedToUser != null)
                                if (potential.AssignedToUser.Person != null)
                                    model.AssignedTo = potential.AssignedToUser.Person.FirstName;
                            if (potential.Account != null)
                                if (potential.Account.Person != null)
                                    model.AccountName = potential.Account.Person.FirstName;
                            if (potential.Person != null)
                                model.AgentName = potential.Person.FirstName;
                            if (potential.SalesStage != null)
                                model.SalesStageName = potential.SalesStage.Name;
                            potentialvm.Add(model);
                        }
                        var output = JsonConvert.SerializeObject(accounts, Formatting.None, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });
                        var potentialvmoutput = JsonConvert.SerializeObject(potentialvm, Formatting.None, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });
                        var getusersoutput = JsonConvert.SerializeObject(users, Formatting.None, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });
                        var returnData = new PotentialResult
                        {
                            Potential = potentialvmoutput,
                            LeadStatus = leadstatus,
                            LeadSource = leadsource,
                            SalesStage = salesstage,
                            Contacts = contacts,
                            Users = getusersoutput,
                            Accounts = output,
                            Countries = countries
                        };
                        return returnData;
                    }
                    else
                    {
                        var potentials = _potentialService.GetAllPotentials(WebUser.PermissionCodes);
                        var leadsource = _leadSourceService.GetAllLeadSources();
                        var leadstatus = _leadStatusService.GetAllLeadStatuses();
                        var salesstage = _salesStageService.GetAllSalesStages();
                        var getusers = _userService.GetAllUsers().ToList();
                        var contacts = _contactService.GetAllContacts();
                        var countries = _countryService.GetAllCountries();
                        var accounts = _crmaccountService.GetAllAccountsByUserId(WebUser.Id, WebUser.PermissionCodes);
                        var potentialvm = new List<PotentialViewModel>();
                        string propertyType = null;
                        foreach (var potential in potentials)
                        {
                            var model = new PotentialViewModel
                            {
                                Name = potential.Person.FirstName,
                                ExpectedAmount = potential.ExpectedAmount,
                                ExpectedCloseDate = potential.ExpectedCloseDate.ToString(),
                                ShowingDate = potential.ExpectedCloseDate.Value.Date.ToShortDateString(),                              
                                PropertyType = propertyType,
                                Id = potential.Id,
                                AgentId = potential.AssignedToUserId,
                                RefId = potential.RefId,
                            };
                            if (potential.LeadSource != null)
                                model.LeadSourceName = potential.LeadSource.Name;
                            if (potential.AssignedToUser != null)
                                if (potential.AssignedToUser.Person != null)
                                    model.AssignedTo = potential.AssignedToUser.Person.FirstName;
                            if (potential.Account != null)
                                if (potential.Account.Person != null)
                                    model.AccountName = potential.Account.Person.FirstName;
                            if (potential.Person != null)
                                model.AgentName = potential.Person.FirstName;
                            if (potential.SalesStage != null)
                                model.SalesStageName = potential.SalesStage.Name;

                            potentialvm.Add(model);
                        }
                        var output = JsonConvert.SerializeObject(accounts, Formatting.None, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });
                        var potentialvmoutput = JsonConvert.SerializeObject(potentialvm, Formatting.None, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });
                        var getusersoutput = JsonConvert.SerializeObject(getusers, Formatting.None, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });
                        var returnData = new PotentialResult
                        {
                            Potential = potentialvmoutput,
                            LeadStatus = leadstatus,
                            LeadSource = leadsource,
                            SalesStage = salesstage,
                            Contacts = contacts,
                            Users = getusersoutput,
                            Countries = countries,
                            Accounts = getusersoutput
                        };
                        return returnData;
                    }                         
            }));
        }
        [HttpGet]
        public JsonResult GetAllCountries()
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var countries = _countryService.GetAllCountries();
                return countries;
            }));
        }
        [HttpPost]
        public JsonResult DeletePotential(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var potential = _potentialService.DeletePotential(id);
                return potential;
            }));
        }
        [HttpPost]
        public JsonResult CreatePotential(PotentialModel potentialModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                potentialModel.CreatedBy = WebUser.Id;
                var result=_potentialService.CreatePotential(potentialModel, SiteSettings.Potentialprefix);
                return result;
            }));
        }
        [HttpGet]
        public JsonResult GetPotential(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var potential = _potentialService.GetPotential(id);
                return potential;
            }));
        }
        [HttpGet]
        public JsonResult Details(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var potential = _potentialService.GetPotential(id);
                var propertyType = "";
                var potentialvm = new PotentialViewModel
                {
                    Name = potential.Person.FirstName,
                    ExpectedAmount = potential.ExpectedAmount,
                    ExpectedCloseDate = potential.ExpectedCloseDate.ToString(),
                    ShowingDate = potential.ExpectedCloseDate.Value.Date.ToShortDateString(),
                    LeadSourceName = potential.LeadSource.Name,
                    AccountName = potential.Account.Person.FirstName,
                    PropertyType = propertyType,
                    Id = potential.Id,
                    AgentId = potential.AssignedToUserId,
                    AgentName = potential.Person.FirstName,
                    SalesStageName = potential.SalesStage.Name,
                    RefId = potential.RefId,
                    ContactName = potential.Contact.Person.FirstName,
                    ContactNo = potential.Contact.RefId,
                    AccountNo = potential.Account.RefId,
                    Industry = potential.Account.Industry,
                    ContactTitle = potential.Contact.Person.Title,
                    AssignedTo = potential.AssignedToUser.Name
                };
            return potentialvm;
        }));
        }
        [HttpPost]
        public JsonResult UpdatePotential(PotentialModel potentialModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var result=_potentialService.UpdatePotential(potentialModel);
                return result;
            }));
        }
        [HttpPost]
        public JsonResult Search(PotentialSearchFilter potentialSearchFilter)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                potentialSearchFilter.UserId = WebUser.Id;
                var potentialSearchResult = _potentialService.Search(potentialSearchFilter, 0, 0);
                var potentialvm = new List<PotentialViewModel>();
                foreach (var potential in potentialSearchResult.Items)
                {
                    var model = new PotentialViewModel
                    {
                        Name = potential.Person.FirstName,
                        ExpectedAmount = potential.ExpectedAmount,
                        ExpectedCloseDate = potential.ExpectedCloseDate.Value.Date.ToShortDateString(),
                        ShowingDate = potential.ExpectedCloseDate.Value.Date.ToShortDateString(),
                        //LeadSourceName = potential.LeadSource.Name,
                        //AccountName = potential.Account.Person.FirstName,
                        Id = potential.Id,
                        AgentId = potential.AssignedToUserId,
                        //AgentName = potential.Person.FirstName,
                        //SalesStageName = potential.SalesStage.Name,
                        RefId = potential.RefId,
                        //AssignedTo = potential.AssignedToUser.Person.FirstName
                    };
                    if (potential.LeadSource != null)
                        model.LeadSourceName = potential.LeadSource.Name;
                    if (potential.AssignedToUser != null)
                        if (potential.AssignedToUser.Person != null)
                            model.AssignedTo = potential.AssignedToUser.Person.FirstName;
                    if (potential.Account != null)
                        if (potential.Account.Person != null)
                            model.AccountName = potential.Account.Person.FirstName;
                    if (potential.Person != null)
                        model.AgentName = potential.Person.FirstName;
                    if (potential.SalesStage != null)
                        model.SalesStageName = potential.SalesStage.Name;

                    potentialvm.Add(model);
                }
                return JsonConvert.SerializeObject(potentialvm);
            }));
        }

    }
}