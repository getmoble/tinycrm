function Manager(manager) {
    var that = this;
    that.modelState = ko.validatedObservable();
    that.isValid = function () {
        return that.modelState.isValid();
    };
    that.showErrors = function () {
        that.modelState.errors.showAllMessages(true);
    };
    that.resetValidation = function () {

        that.CityId.isModified(false);

    };
    that.Id = ko.observable(manager.Id);
    that.FirstName = ko.observable(manager.FirstName).extend({ required: { params: true, message: "Please Enter First Name" } });
    that.LastName = ko.observable(manager.LastName);
    that.IsSelect = ko.observable();
    if (manager.ManagerRole)
        that.Role = ko.observable(manager.ManagerRole.Name);
    else
        that.Role = ko.observable('');
    that.RoleId = ko.observable(manager.RoleId);
    that.Email = ko.observable(manager.Email).extend({ email: { params: true, message: "Please Enter valid Email" } });
    that.Phone = ko.observable(manager.Phone).extend({ required: { params: true, message: "Please Enter Phone Number" } });
    that.Mobile = ko.observable(manager.Mobile);
    that.CountryId = ko.observable(manager.CountryId).extend({ required: { params: true, message: "Please Select Country" } });
    that.StateId = ko.observable(manager.StateId).extend({ required: { params: true, message: "Please Select State" } });
    if (manager.CommunicationDetail) {
        that.AddressId = ko.observable(manager.CommunicationDetail.AddressId);
        that.Address = ko.observable(manager.CommunicationDetail.Address);
        that.Zip = ko.observable(manager.CommunicationDetail.Zip);
        that.CityId = ko.observable(manager.CommunicationDetail.CityId).extend({ required: { params: true, message: "Please Select City" } });
    } else {
        that.CityId = ko.observable("").extend({ required: { params: true, message: "Please Select City" } });
        that.Address = ko.observable("");
        that.Zip = ko.observable("");
    }

    that.modelState = ko.validatedObservable(
 {
     FirstName: that.FirstName,
     Email: that.Email,
     Phone: that.Phone,
     CityId: that.CityId
 });
}