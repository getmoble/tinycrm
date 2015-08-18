function UserDetailsViewModel() {
    var self = this;
    self = ViewModelBase(self);
    self.SelectedUser = ko.observable(new User({}));
    self.Userdetails = function () {
        self.IsBusy(true);
        var id = $("#hdnUserId").val();
        var result = CRMLite.dataManager.getData((CRMLite.CRM.UserapiGetUser) + id);
        result.done(function (data) {
            if (data.Status == true) {
                self.SelectedUser(new User(data.Result));
                self.IsBusy(false);
            }
            else {
                CRMLite.showMesssage.error(response.Message, "Error");
            }
        });
    };
};