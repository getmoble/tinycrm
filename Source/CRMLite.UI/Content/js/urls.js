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
    self.CRM.errorNotAuthorized = '/CRM/Error/NotAuthorized';
    self.CRM.errorFound = '/CRM/Error/Index';
    self.CRM.userSignin = '/User/SignIn';

    //User Api

    self.CRM.UserapiGetUser = '/Api/UserApi/GetUser?id=';
    self.CRM.UserapiUploadImageFiles = "/UserApi/UploadImageFiles";
    self.CRM.uploadUser = "/Upload/Avatar/";
    self.CRM.UserapiEditUser = '/Api/UserApi/EditUser?id=';
    self.CRM.UserapiGetDelete = '/Api/UserApi/GetDelete?id=';
    self.CRM.UserapiCreate = '/Api/UserApi/Create';
    self.CRM.UserapiUpdate = '/Api/UserApi/Update';
    self.CRM.UserapiSearch = '/Api/UserApi/Search';
    self.CRM.UserapiList = '/Api/UserApi/List';

    //User Controllers
    self.CRM.UserIndex = "/CRM/User/Index";
    self.CRM.UserList = "/CRM/User";
    self.CRM.UserUpdate = "/CRM/User/Update?id=";
    self.CRM.UserCreate = "/CRM/User/Create";
    self.CRM.gotoUserdetails = "/CRM/User/Details?id=";
    //Contact Api
    self.CRM.contactapiDeleteContact = '/Api/ContactApi/DeleteContact?id=';
    self.CRM.contactapiGetContact = '/Api/ContactApi/GetContact?id=';
    self.CRM.contactapiGetAllContacts = '/Api/ContactApi/GetAllContacts';
    self.CRM.contactapiCreateContact = '/Api/ContactApi/CreateContact';
    self.CRM.contactapiUpdateContact = '/Api/ContactApi/UpdateContact';
    self.CRM.contactapiSearch = '/Api/ContactApi/Search';
    self.CRM.contactapiGetAllCountries = '/Api/ContactApi/GetAllCountries';
    self.CRM.contactapiGetAllStates = '/Api/ContactApi/GetAllStates?id=';
    self.CRM.contactapiGetAllCities = '/Api/ContactApi/GetAllCities?id=';

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
    self.CRM.potentialapiGetAllCountries = '/Api/PotentialApi/GetAllCountries';
    self.CRM.potentialapiGetAllStates = '/Api/PotentialApi/GetAllStates?id=';
    self.CRM.potentialapiGetAllCities = '/Api/PotentialApi/GetAllCities?id=';


    //Potential Controllers
    self.CRM.potentialIndex = "/CRM/Potential/Index";
    self.CRM.potentialCreate = "/CRM/Potential/Create";
    self.CRM.potentialEdit = "/CRM/Potential/Edit?id=";
    self.CRM.gotoPotentialdetails = "/CRM/Potential/Details?id=";

    //LeadSource Api
    self.CRM.leadSourceApiCreate = '/Api/LeadSourceApi/CreateLeadSource';
    self.CRM.leadSourceApiUpdate = '/Api/LeadSourceApi/UpdateLeadSource';
    self.CRM.leadSourceApiDelete = '/Api/LeadSourceApi/DeleteLeadSource';
    self.CRM.leadSourceApiGetAll = '/Api/LeadSourceApi/GetAllLeadSource';
    //..................................................................................................

};
