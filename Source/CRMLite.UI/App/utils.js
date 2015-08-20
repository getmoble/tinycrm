CRMLite = {};
CRMLite.CRM = new Urls().CRM;
function NotificationManager() {
    var self = this;
    self.success = function (message) {
        alert(message);
    };
    self.error = function (message) {
        alert(message);
    };
};
function cacheManager() {
    
};
// DataManager
function DataManager() {

    var self = this;

    var notificationManager = new NotificationManager();

    self.ajaxTransport = function (url, options) {
        //var baseUrl = 'http://propznet.com' + url;
        var baseUrl = '' + url;
        var deferred = new $.Deferred();
        
        var defaults = {
            statusCode: {
                500: function () {
                    // notificationManager.error("Bad Server, something has gone wrong");
                    toastr["error"]("Bad Server, something has gone wrong.", "Error");
                    //bootbox.alert("Bad Server, something has gone wrong...!!", function () {
                    //    window.location.href = ko.toJS(urls.CRM.errorNotAuthorized);
                    //});
                },
                403: function () {
                    //notificationManager.error("Session Expired, Login again");
                    bootbox.alert("Session Expired,Please Login again.", function () {
                        window.location.href = ko.toJS(CRMLite.CRM.userSignin);
                    });
                }
            },
            url: baseUrl,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
 
                deferred.resolve(result);
            },
            error: function (xhr, statusText) {
                deferred.rejectWith("Error");
            }
        };

        var o = $.extend({}, defaults, options);
        $.ajax(o);
        return deferred.promise();
    };

    self.getData = function (url) {
        return self.ajaxTransport(url, { type: 'GET' });
    };

    self.postData = function (url, data) {
        return self.ajaxTransport(url, { type: 'POST', data: JSON.stringify(data) });
    };

    self.postDeleteData = function (url, data) {
        return self.ajaxTransport(url, { type: 'POST', data: JSON.stringify(data) });
    };
};
function ShowMessage() {
    var self = this;
    self.error = function (message, type) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr["error"](message, type);
    };
    self.warning = function (message, type) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr["warning"](message, type);
    };
    self.info = function (message, type) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr["info"](message, type);
    };
};
function WindowManager() {
    var self = this;
    self.Redirect = function (path) {
        window.location.href = path;
    };
};

function ViewModelBase(child) {
    var self = child;
    self.IsBusy = ko.observable(false);
    self.IsButtonBusy = ko.observable(false);
    return self;
};
CRMLite.dataManager = new DataManager();
CRMLite.showMesssage = new ShowMessage();
CRMLite.windowManager = new WindowManager();