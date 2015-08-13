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
                    toastr["error"]("Bad Server, something has gone wrong...!!", "Notification");
                    //bootbox.alert("Bad Server, something has gone wrong...!!", function () {
                    //    window.location.href = ko.toJS(urls.CRM.errorNotAuthorized);
                    //});
                },
                403: function () {
                    //notificationManager.error("Session Expired, Login again");
                    bootbox.alert("Session Expired, Login again...!!", function () {
                        window.location.href = ko.toJS(urls.CRM.userSignin);
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
CRMLite = {};
CRMLite.dataManager = new DataManager();
