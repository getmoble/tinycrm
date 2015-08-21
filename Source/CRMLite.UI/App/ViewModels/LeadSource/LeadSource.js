function LeadSource(leadSource) {
    var self = this;
    self.modelState = ko.validatedObservable();
    self.isValid = function () {
        return self.modelState.isValid();
    };
    self.showErrors = function () {
        self.modelState.errors.showAllMessages(true);
    };
    self.Id = ko.observable(leadSource.Id || '');
    self.Name = ko.observable(leadSource.Name || '').extend({ required: { params: true, message: 'Please Enter A Name' } });
    self.modelState = ko.validatedObservable(
    {
        Name: self.Name,
    });
}