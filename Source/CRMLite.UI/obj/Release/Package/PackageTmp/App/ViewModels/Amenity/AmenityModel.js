function Aminities(aminity) {
    var that = this;
    that.modelState = ko.validatedObservable();
    that.isValid = function () {
        return that.modelState.isValid();
    };
    that.showErrors = function () {
        that.modelState.errors.showAllMessages(true);
    };
    that.Id = ko.observable(aminity.Id);
    that.Name = ko.observable(aminity.Name).extend({ required: { params: true, message: "Please Enter Name" } });
    that.IsSelectAmenity = ko.observable();
    that.modelState = ko.validatedObservable(
    {
        Name: that.Name
    });
    that.resetValidation = function () {
        that.Name.isModified(false);
    };
}