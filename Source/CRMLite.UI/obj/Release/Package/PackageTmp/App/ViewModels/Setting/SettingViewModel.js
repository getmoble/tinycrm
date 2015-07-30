function SettingViewModel() {
    var self = this;
    self.url = urls.ERP;
    self.pagingSize = ko.observable();

    self.Change = function () {
        var result = $.post(ko.toJS(self.url.settingManageChangePagingSize) + self.pagingSize());
        result.done(function (response) {
            if (response === true) {
                bootbox.alert("Saved successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.settingsList);
                });
            }
            else {
                bootbox.alert("Error occured");
            }
        });
    };
};