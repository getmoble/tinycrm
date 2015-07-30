function Setting(setting) {
    var that = this;
    that.Id = ko.observable(setting.Id);
    that.PagingSize = ko.observable(setting.PagingSize);
    that.Logo = ko.observable(setting.Logo);
}