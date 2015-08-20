﻿function AddEditUserViewModel() {
    var self = this;
    self = ViewModelBase(self);
    self.SelectedUser = ko.observable(new User({}));
    self.SaveUser = function () {
    self.SelectedUser().resetValidation();
    if (self.SelectedUser().modelState.isValid()) {
        self.IsButtonBusy(true);
        var jsonData = {
            FirstName: ko.toJS(self.SelectedUser().FirstName), LastName: ko.toJS(self.SelectedUser().LastName),
            Email: ko.toJS(self.SelectedUser().Email), Phone: ko.toJS(self.SelectedUser().PhoneNumber),
            Address: ko.toJS(self.SelectedUser().Address), IsListingMember: ko.toJS(self.SelectedUser().IsListingMember), Id: ko.toJS(self.SelectedUser().Id), Image: ko.toJS(self.SelectedUser().Image)
        };
        alert(ko.toJSON(jsonData));
        var result = CRMLite.dataManager.postData((CRMLite.CRM.UserapiCreate), jsonData);
        result.done(function (response) {
            self.IsButtonBusy(false);
            if (response.Status === true) {
                bootbox.alert("User saved successfully.", function () {
                    CRMLite.windowManager.Redirect((CRMLite.CRM.UserIndex));
                });
            }
            else {
                CRMLite.showMesssage.error(response.Message, "Error");
            }
        });
    }
    else {
        self.SelectedUser().modelState.errors.showAllMessages();
    }

};
    self.UserEdit = function (item) {
    function changePic(strPath) {
        // var that = {};
        var vm = ko.toJS(strPath);
        var o = document.getElementById("ThumbnailImageS");
        var imagPath = new String(ko.toJS(CRMLite.CRM.uploadUser));
        imagPath = imagPath.concat(strPath);
        o.src = imagPath;
        path = ko.toJS(CRMLite.CRM.uploadUser) + ko.toJS(strPath);
        self.SelectedUser().Image(path);
    }
    setTimeout(function () {
        $("#avatar").change(function () {
            var fileData = $("#avatar").prop("files")[0];
            var formData = new FormData();
            formData.append("file", fileData);
            formData.append("user_id", 123);
            $.ajax({
                url: ko.toJS(CRMLite.CRM.UserapiUploadImageFiles),
                dataType: 'json',
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                type: 'post',
                success: function (files, data, xhr) {
                    changePic(files.Name);
                },
            });
        });
    }, 3000);
    var path = null;
    var result = CRMLite.dataManager.getData((CRMLite.CRM.UserapiEditUser) + item.Id());
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
    self.GetUser = function () {
    var id = $("#hdnAgnetId").val();
    self.IsBusy(true);
    function changePic(strPath) {
        var vm = ko.toJS(strPath);
        var o = document.getElementById("ThumbnailImageS");
        var imagPath = new String(ko.toJS(CRMLite.CRM.uploadUser));
        imagPath = imagPath.concat(strPath);
        o.src = imagPath;
        path = ko.toJS(CRMLite.CRM.uploadUser) + ko.toJS(strPath);
        self.SelectedUser().Image(path);
    }
    setTimeout(function () {
        $("#avatar").change(function () {
            var fileData = $("#avatar").prop("files")[0];
            var formData = new FormData();
            formData.append("file", fileData);
            formData.append("user_id", 123);
            $.ajax({
                url: ko.toJS(CRMLite.CRM.UserapiUploadImageFiles),
                dataType: 'json',
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                type: 'post',
                success: function (files, data, xhr) {
                    changePic(files.Name);
                },

            });
        });
    }, 3000);
    var path = null;
    var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.UserapiGetUser) + id);
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
    self.UpdateUserProfile = function () {
    self.SelectedUser().resetValidation();
    if (self.SelectedUser().modelState.isValid()) {
        self.IsButtonBusy(true);
        var jsonData = {
            FirstName: ko.toJS(self.SelectedUser().FirstName), LastName: ko.toJS(self.SelectedUser().LastName),//$('#avatar').val()
            Email: ko.toJS(self.SelectedUser().Email), Phone: ko.toJS(self.SelectedUser().PhoneNumber), Image: ko.toJS(self.SelectedUser().Image), Address: ko.toJS(self.SelectedUser().Address),
            IsListingMember: ko.toJS(self.SelectedUser().IsListingMember), Id: ko.toJS(self.SelectedUser().Id)
        };
        alert(ko.toJSON(jsonData));
        var result = CRMLite.dataManager.postData((CRMLite.CRM.UserapiUpdate), jsonData);
        result.done(function (response) {
            self.IsButtonBusy(false);
            if (response.Status === true) {
                bootbox.alert("User profile updated successfully.", function () {
                    CRMLite.windowManager.Redirect((CRMLite.CRM.UserIndex));
                });
            }
            else {
                CRMLite.showMesssage.error(response.Message, "Error");
            }
        });
    }
    else {
        self.SelectedUser().modelState.errors.showAllMessages();
    }
    }
    self.clear = function () {
        self.SelectedUser(new User({}));
        self.SelectedUser().resetValidation();
        $("#avatar").change(function () {
            var file_data = $("#avatar").prop("files")[0];
            var form_data = new FormData();
            form_data.append("file", file_data);
            form_data.append("user_id", 123);
            $.ajax({
                url: ko.toJS(CRMLite.CRM.UserapiUploadImageFiles),
                dataType: 'json',
                cache: false,
                contentType: false,
                processData: false,
                data: form_data,
                type: 'post',
                success: function (files, data, xhr) {
                    changePic(files.Name);
                }
            });
        });
        var path = null;
        function changePic(strPath) {
            var that = {};
            var vm = ko.toJS(strPath);
            var o = document.getElementById("ThumbnailImageS");
            var imagPath = new String(ko.toJS(CRMLite.CRM.uploadUser));
            imagPath = imagPath.concat(strPath);
            o.src = imagPath;
            path = ko.toJS(CRMLite.CRM.uploadUser) + ko.toJS(strPath);
            self.SelectedUser().Image(path);

            o.src = imagPath;;
            path = ko.toJS(strPath);
        }
       };
};