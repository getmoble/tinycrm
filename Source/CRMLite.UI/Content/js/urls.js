//CRM Urls
function Urls() {
    var self = this;

    self.CRM = {};
    self.ERP = {};

    //Account Api
    self.CRM.accountapiCreateAccount = '/Api/AccountApi/CreateAccount';
    self.CRM.accountapiUpdateAccount = '/Api/AccountApi/UpdateAccount';
    self.CRM.accountapiSearch = '/Api/AccountApi/Search';
    self.CRM.accountapiGetAccount = '/Api/AccountApi/GetAccount?id=';
    self.CRM.accountapiGetAllAccount = '/Api/AccountApi/GetAllAccounts';
    self.CRM.accountapiDeleteAccount = '/Api/AccountApi/DeleteAccount?id=';

    //Account Controllers
    self.CRM.accountIndex = "/CRM/Account/Index";
    self.CRM.accountCreate = "/CRM/Account/Create";
    self.CRM.fullCalenderIndexEntityTypeAccountid = '/CRM/FullCalender/Index?entityType=Account&id=';
    self.CRM.accountEdit = '/CRM/Account/Edit?id=';

    //Error Controllers
    self.errorNotAuthorized = '/CRM/Error/NotAuthorized';

    //Agent Api

    self.CRM.agentapiGetAgent = '/Api/AgentApi/GetAgent?id=';
    self.CRM.agentapiUploadImageFiles = "/AgentApi/UploadImageFiles";
    self.CRM.uploadAgent = "/Upload/Avatar/";
    self.CRM.agentapiEditAgent = '/Api/AgentApi/EditAgent?id=';
    self.CRM.agentapiGetDelete = '/Api/AgentApi/GetDelete?id=';
    self.CRM.agentapiCreate = '/Api/AgentApi/Create';
    self.CRM.agentapiUpdate = '/Api/AgentApi/Update';
    self.CRM.agentapiSearch = '/Api/AgentApi/Search';
    self.CRM.agentapiList = '/Api/AgentApi/List';

    //Agent Controllers
    self.CRM.agentIndex = "/CRM/Agent/Index";
    self.CRM.agentList = "/CRM/Agent";
    self.CRM.agentUpdate = "/CRM/Agent/Update?id=";
    self.CRM.agentCreate = "/CRM/Agent/Create";
    self.CRM.gotoAgentdetails = "/CRM/Agent/Details?id=";
    //Contact Api
    self.CRM.contactapiDeleteContact = '/Api/ContactApi/DeleteContact?id=';
    self.CRM.contactapiGetContact = '/Api/ContactApi/GetContact?id=';
    self.CRM.contactapiGetAllContacts = '/Api/ContactApi/GetAllContacts';
    self.CRM.contactapiCreateContact = '/Api/ContactApi/CreateContact';
    self.CRM.contactapiUpdateContact = '/Api/ContactApi/UpdateContact';
    self.CRM.contactapiSearch = '/Api/ContactApi/Search';
    self.CRM.contactapiGetCountries = '/Api/ContactApi/GetAllCountries';
    self.CRM.contactapiGetAllStates = '/Api/ContactApi/GetAllStates';

    //Contact Controllers
    self.CRM.contactIndex = "/CRM/Contact/Index";
    self.CRM.fullCalenderIndexentityTypeContact = '/CRM/FullCalender/Index?entityType=Contact&id=';
    self.CRM.contactCreate = "/CRM/Contact/Create";
    self.CRM.contactEdit = "/CRM/Contact/Edit?id=";
    self.CRM.gotoContactdetails = "/CRM/Contact/Details?id=";

    //Settings Api
    self.CRM.settingsapiChangePagingSize = '/Api/SettingsApi/ChangePagingSize?pagingsize=';

    //Full Calender Api
    self.CRM.fullCalenderapiGetEvents = '/Api/FullCalenderApi/GetEvents';
    self.CRM.fullCalenderapiGetEventsentityType = '/Api/FullCalenderApi/GetEvents?entityType=';
    self.CRM.fullCalenderapiSaveEvent = '/Api/FullCalenderApi/SaveEvent';
    self.CRM.fullCalenderapiDeleteEvent = '/Api/FullCalenderApi/DeleteEvent?id=';
    self.CRM.fullCalenderapiDetailEvent = '/Api/FullCalenderApi/DetailEvent?id=';
    self.CRM.fullCalenderapiUpdateEvent = '/Api/FullCalenderApi/UpdateEvent';

    //Full Calender Controllers
    self.CRM.fullCalenderIndexentityType = '/CRM/FullCalender/Index?entityType=';
    self.CRM.fullCalenderIndexentityTypeLeadid = '/CRM/FullCalender/Index?entityType=Lead&id=';
    self.CRM.fullCalenderIndexentityTypePotential = '/CRM/FullCalender/Index?entityType=Potential&id=';

    //Lead Api
    self.CRM.leadapiGetData = '/Api/LeadApi/GetData';
    self.CRM.leadapiSearch = '/Api/LeadApi/Search';
    self.CRM.leadapiIndex = '/Api/LeadApi/Index';
    self.CRM.leadapiCreate = '/Api/LeadApi/Create';
    self.CRM.leadapiUpdate = '/Api/LeadApi/Update';
    self.CRM.leadapiConvertLead = '/Api/LeadApi/ConvertLead';
    self.CRM.leadapiDeleteLead = '/Api/LeadApi/DeleteLead?id=';
    self.CRM.leadapiGetLead = '/Api/LeadApi/GetLead?id=';
    self.CRM.leadApiGetConvertLead = '/Api/LeadApi/GetConvertLead?id=';

    //Lead Controllers
    self.CRM.leadIndex = "/CRM/Lead/Index";
    self.CRM.leadUpdate = "/CRM/Lead/Edit?id=";
    self.CRM.gotoLeadCreate = "/CRM/Lead/Create";
    self.CRM.convertLead = "/CRM/Lead/ConvertLead?id=";
    self.CRM.gotoLeaddetails = "/CRM/Lead/Details?id=";

    //Potential Api
    self.CRM.potentialapiDeletePotential = '/Api/PotentialApi/DeletePotential?id=';
    self.CRM.potentialapiGetPotential = '/Api/PotentialApi/GetPotential?id=';
    self.CRM.potentialapiDetails = '/Api/PotentialApi/Details?id=';
    self.CRM.potentialapiGetAllPotential = '/Api/PotentialApi/GetAllPotential';
    self.CRM.potentialapiCreatePotential = '/Api/PotentialApi/CreatePotential';
    self.CRM.potentialapiUpdatePotential = '/Api/PotentialApi/UpdatePotential';
    self.CRM.potentialapiSearch = '/Api/PotentialApi/Search';
    self.CRM.potentialManageCreateAminity = '/Api/PropertyManage/CreateAminity';
    self.CRM.potentialManagegetPropertyAminities = '/Api/PotentialApi/GetPropertiesAndAminities';
    self.CRM.potentialCreateMorePotential = '/Api/PotentialApi/CreateMorePotential';
    

    //Potential Controllers
    self.CRM.potentialIndex = "/CRM/Potential/Index";
    self.CRM.potentialCreate = "/CRM/Potential/Create";
    self.CRM.potentialEdit = "/CRM/Potential/Edit?id=";
    self.CRM.gotoPotentialdetails = "/CRM/Potential/Details?id=";
    //..................................................................................................

    //ERP Urls

    //Manager Api
    self.ERP.managerManageInit = '/Api/ManagerManage/Init';
    self.ERP.managerManageGetAllManagers = '/Api/ManagerManage/GetAllManagers';
    self.ERP.managerManageCreateManager = '/Api/ManagerManage/CreateManager';
    self.ERP.managerManageEditManager = '/Api/ManagerManage/EditManager?id=';
    self.ERP.managerManageUpdateManager = '/Api/ManagerManage/UpdateManager';
    self.ERP.managerManageDeleteManager = '/Api/ManagerManage/DeleteManager?id=';
    self.ERP.managerManageGetAllStatesByCountry = '/Api/ManagerManage/GetAllStatesByCountry?countryId=';
    self.ERP.managerManageGetAllCitiesByState = '/Api/ManagerManage/GetAllCitiesByState?stateId=';

    //Manager Controllers
    self.ERP.managerList = "/ERP/Manager";
    self.ERP.managerCreate = "/ERP/Manager/Create";
    self.ERP.managerEdit = '/ERP/Manager/Edit?id=';

    //Owner Api
    self.ERP.ownerManageInit ='/Api/OwnerManage/Init';
    self.ERP.ownerManageEditOwner = '/Api/OwnerManage/EditOwner?id=';
    self.ERP.OwnerManageGetAllStatesByCountry = '/Api/OwnerManage/GetAllStatesByCountry?countryId=';
    self.ERP.ownerManageGetAllCitiesByState = '/Api/OwnerManage/GetAllCitiesByState?stateId=';
    self.ERP.ownerManageGetAllOwners = '/Api/OwnerManage/GetAllOwners';
    self.ERP.ownerManageCreateOwner = '/Api/OwnerManage/CreateOwner';
    self.ERP.ownerManageUpdateOwner = '/Api/OwnerManage/UpdateOwner';
    self.ERP.ownerManageDeleteOwner = '/Api/OwnerManage/DeleteOwner?id=';

    //Owner Controllers
    self.ERP.ownerCreate = "/ERP/Owner/Create";
    self.ERP.ownerList = "/ERP/Owner/";
    self.ERP.ownerEdit = '/ERP/Owner/Edit?id=';

    //Portfolio Api
    self.ERP.portfolioManageInit = '/Api/PortfolioManage/Init';
    self.ERP.portfolioManageGetAllPortfolios = '/Api/PortfolioManage/GetAllPortfolios';
    self.ERP.portfolioManageCreatePortfolio = '/Api/PortfolioManage/CreatePortfolio';
    self.ERP.portfolioManageEditPortfolio = '/Api/PortfolioManage/EditPortfolio?id=';
    self.ERP.portfolioManageUpdatePortfolio = '/Api/PortfolioManage/UpdatePortfolio';
    self.ERP.portfolioManageDeletePortfolio = '/Api/PortfolioManage/DeletePortfolio?id=';

    //Portfolio Controllers
    self.ERP.portfolioList = "/ERP/Portfolio";
    self.ERP.portfolioCreate = "/ERP/Portfolio/Create";
    self.ERP.portfolioEdit = '/ERP/Portfolio/Edit?id=';

    //Property Api
    self.ERP.propertyManageInit = '/Api/PropertyManage/Init';
    self.ERP.propertyManageGetAllStatesByCountry = '/Api/PropertyManage/GetAllStatesByCountry?countryId=';
    self.ERP.propertyManageGetAllCitiesByState = '/Api/PropertyManage/GetAllCitiesByState?stateId=';
    self.ERP.propertyManageCreateProperty = '/Api/PropertyManage/CreateProperty';
    self.ERP.propertyManageCreateAminity = '/Api/PropertyManage/CreateAminity';
    self.ERP.propertyManageCreateMoreProperty = '/Api/PropertyManage/CreateMoreProperty';
    self.ERP.propertyManageGetAllProperties = '/Api/PropertyManage/GetAllProperties';
    self.ERP.propertyManageEditPrperty = '/Api/PropertyManage/EditPrperty?id=';
    self.ERP.propertyManageUpdateProperty ='/Api/PropertyManage/UpdateProperty';
    self.ERP.propertyManageDeleteProperty ='/Api/PropertyManage/DeleteProperty?id=';


    //Property Controllers
    self.ERP.propertyEdit = '/ERP/Property/Edit?id=';
    self.ERP.propertyCreate = "/ERP/property/create";

    //Setting Api
    self.ERP.settingManageChangePagingSize ='/Api/SettingManage/ChangePagingSize?pagingsize=';

    //Setting Controllers
    self.ERP.settingsList = "/ERP/Settings";

    //Unit Api
    self.ERP.unitManageGetAllUnits = '/Api/UnitManage/GetAllUnits';
    self.ERP.unitManageInit = '/Api/UnitManage/Init';
    self.ERP.unitManageGetAllStatesByCountry = '/Api/UnitManage/GetAllStatesByCountry?countryId=';
    self.ERP.unitManageGetAllCitiesByState = '/Api/UnitManage/GetAllCitiesByState?stateId=';
    self.ERP.unitManageCreateUnit = '/Api/UnitManage/CreateUnit';
    self.ERP.unitManageCreateMoreUnit = '/Api/unitManage/CreateMoreUnit';
    self.ERP.unitManageEditUnit = '/Api/UnitManage/EditUnit?id=';
    self.ERP.unitManageUpdateUnit = '/Api/UnitManage/UpdateUnit';
    self.ERP.unitManageDeleteUnit = '/Api/UnitManage/DeleteUnit?id=';

    //Unit Controllers
    self.ERP.unitEdit = '/ERP/Unit/Edit?id=';
    self.ERP.unitList = '/ERP/unit';

    //Charge Api
    self.ERP.ChargeManageInit = '/Api/ChargeManage';
    self.ERP.ChargeManageCreate = '/Api/ChargeManage/CreateCharge';
    self.ERP.chargeManageGetAllCharges = '/Api/ChargeManage/GetCharges';
    self.ERP.chargeManageDeleteCharge = '/Api/ChargeManage/DeleteCharge?id=';

    //Charge Controllers

    self.ERP.chargeCreate = '/ERP/Charge/Create';
};
urls = {};
urls.CRM = new Urls().CRM;
urls.ERP = new Urls().ERP;