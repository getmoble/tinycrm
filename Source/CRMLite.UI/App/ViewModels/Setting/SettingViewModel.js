function SettingViewModel() {
    var self = this;
    self.url = urls.ERP;
    self.pagingSize = ko.observable();

    self.Change = function () {
        var result = $.post(ko.toJS(self.url.settingManageChangePagingSize) + self.pagingSize());
        result.done(function (response) {
            if (response === true) {
                bootbox.alert("Settings saved successfully.", function () {
                    CRMLite.windowManager.Redirect(ko.toJS(self.url.settingsList));
                });
            }
            else {
                toastr["error"]("Bad Server, something has gone wrong.", "Error");
            }
        });
    };
};