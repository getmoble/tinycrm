function UserViewModel() {
    var self = this;
    self.DisplayTitle = ko.observable();
    self.busy = ko.observable();
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.SearchName = ko.observable();
    self.SearchEmail = ko.observable();
    self.SearchPhone = ko.observable();
    self.isBusy = ko.observable(false);
    self.UserLists = ko.observableArray();
    self.selectedUser = ko.observable(new User({}));
    self.gotoUserdetails = function (item) {
        CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.gotoUserdetails) + item.Id());
    };
    self.Userdetails = function () {
        self.isBusy(true);
        var id = $("#hdnUserId").val();
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.UserapiGetUser) + id);
        result.done(function (data) {
            if (data.Status == true) {
                self.selectedUser(new User(data.Result));
                self.isBusy(false);
            }
            else {
                toastr["error"](data.Message, "Notification");
            }
        });
    };
    self.Useredit = function (item) {
        self.isCreate(false);
        self.isUpdate(true);
        self.isBusy(true);
        self.DisplayTitle('Edit User');

        function changePic(strPath) {
            // var that = {};
            var vm = ko.toJS(strPath);
            var o = document.getElementById("ThumbnailImageS");
            var imagPath = new String(ko.toJS(CRMLite.CRM.uploadUser));
            imagPath = imagPath.concat(strPath);
            o.src = imagPath;
            path = ko.toJS(CRMLite.CRM.uploadUser)+ko.toJS(strPath);
            self.selectedUser().image(path);
            //return that;
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
        var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.UserapiEditUser) + item.Id());
        result.done(function (data) {
            if (data.Status == true) {
                self.selectedUser(new User(data.Result));
                self.isBusy(false);
            }
            else {
                toastr["error"](data.Message, "Notification");
            }
        });
    };
    self.Userdelete = function (item) {
        bootbox.confirm("Do you want to delete the User" + " '" + item.name() + "' " + " ?", function (result) {
            if (result) {
                var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.UserapiGetDelete) + item.Id());
                result.done(function (response) {
                    if (response.Status == true) {
                        bootbox.alert("User deleted successfully.", function () {
                            CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.UserIndex));
                        });
                    }
                    else {
                        toastr["error"](data.Message, "Notification");
                    }
                });
            }
        });
    };
    self.updateUserProfile = function (item) {
        CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.UserUpdate) + item.Id());
    };
    self.saveUserProfile = function () {
        self.selectedUser().resetValidation();
        if (self.selectedUser().modelState.isValid()) {
            self.busy(true);
            var jsonData = {
                FirstName: ko.toJS(self.selectedUser().firstname), LastName: ko.toJS(self.selectedUser().lastname),//$('#avatar').val()
                Email: ko.toJS(self.selectedUser().email), Phone: ko.toJS(self.selectedUser().phoneNumber), Image: ko.toJS(self.selectedUser().image), Address: ko.toJS(self.selectedUser().address),
                DEDlicenseNumber: ko.toJS(self.selectedUser().DEDlicenseNumber), RERAregistrationNumber: ko.toJS(self.selectedUser().RERAregistrationNumber),
                IsListingMember: ko.toJS(self.selectedUser().islistingmember), Id: ko.toJS(self.selectedUser().Id), CommunicationDetailID: ko.toJS(self.selectedUser().contactdetailId)
            };
            var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.UserapiUpdate) ,jsonData);
            result.done(function (response) {
                self.busy(false);
                if (response.Status === true) {
                    bootbox.alert("User profile updated successfully.", function () {
                        CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.UserIndex));
                    });
                }
                else {
                    toastr["error"](data.Message, "Notification");
                }
            });
        }
        else {
            self.selectedUser().modelState.errors.showAllMessages();
        }
    }
    self.gotoUserPage = function () {
        var self = this;
        self.DisplayTitle('Create User');
        CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.UserCreate));
    };
};
UserViewModel.prototype.init = function () {
    var self = this;
    self.selectedUser(new User({}));
};
UserViewModel.prototype.saveUser = function () {
    var self = this;
    self.selectedUser().resetValidation();
    if (self.selectedUser().modelState.isValid()) {
        self.busy(true);
        var jsonData = {
            FirstName: ko.toJS(self.selectedUser().firstname), LastName: ko.toJS(self.selectedUser().lastname),
            Email: ko.toJS(self.selectedUser().email), Phone: ko.toJS(self.selectedUser().phoneNumber),
            Address: ko.toJS(self.selectedUser().address), DEDlicenseNumber: ko.toJS(self.selectedUser().DEDlicenseNumber),
            RERAregistrationNumber: ko.toJS(self.selectedUser().RERAregistrationNumber),
            IsListingMember: ko.toJS(self.selectedUser().islistingmember), Id: ko.toJS(self.selectedUser().id), Image: ko.toJS($('#avatar').val())
        };
        var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.UserapiCreate) ,jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response.Status === true) {
                bootbox.alert("User saved successfully.", function () {
                    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.UserIndex));
                });
            }
            else {
                toastr["error"](data.Message, "Notification");
            }
        });
    }
    else {
        self.selectedUser().modelState.errors.showAllMessages();
    }

};
UserViewModel.prototype.AddUser = function () {
    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.UserList));
};
UserViewModel.prototype.updateUser = function () {
    var self = this;
    self.selectedUser().resetValidation();
    if (self.selectedUser().modelState.isValid()) {
        self.busy(true);
        var jsonData = {
            FirstName: ko.toJS(self.selectedUser().firstname), LastName: ko.toJS(self.selectedUser().lastname),//$('#avatar').val()
            Email: ko.toJS(self.selectedUser().email), Phone: ko.toJS(self.selectedUser().phoneNumber), Image: ko.toJS(self.selectedUser().image), Address: ko.toJS(self.selectedUser().address),
            DEDlicenseNumber: ko.toJS(self.selectedUser().DEDlicenseNumber), RERAregistrationNumber: ko.toJS(self.selectedUser().RERAregistrationNumber),
            IsListingMember: ko.toJS(self.selectedUser().islistingmember), Id: ko.toJS(self.selectedUser().Id), CommunicationDetailID: ko.toJS(self.selectedUser().contactdetailId)
        };
        var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.UserapiUpdate) ,jsonData);
        result.done(function (response) {  
            self.busy(false);
            if (response.Status === true) {
                bootbox.alert("User updated successfully.", function () {
                    CRMLite.windowManager.Redirect(ko.toJS(CRMLite.CRM.UserIndex));
                });
            }
            else {
                toastr["error"](data.Message, "Notification");
            }
        });
    }
    else {
        self.selectedUser().modelState.errors.showAllMessages();
    }
};
UserViewModel.prototype.UserListing = function () {
    var self = this;
    self.isBusy(true);
    self.isCreate(true);
    var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.UserapiList));
    result.done(function (response) {
        if (response.Status == true) {
            $.each($.parseJSON(response.Result), function (key, value) {
                self.UserLists.push(new User(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]],
                "oLanguage": {
                    "sSearch": "Filter: "
                }
            });
            oTable = $('#pagination').dataTable();

            self.isBusy(false);
        }
        else {
            CRMLite.showMesssage.error(response.Message, "Error");
        }
    });
};
UserViewModel.prototype.search = function () {
    var self = this;
    var oldTable = $("#pagination").DataTable();
    oldTable
      .clear()
      .draw();
    oldTable.destroy();
    var jsonData = {
        FirstName: ko.toJS(self.SearchName),
        Phone: ko.toJS(self.SearchPhone), Email: ko.toJS(self.SearchEmail)
    };
    var result = CRMLite.dataManager.postData(ko.toJS(CRMLite.CRM.UserapiSearch) ,jsonData);
    result.done(function (response) {
        if (response.Status == true) {
            self.UserLists.removeAll();
            $.each(response.Result, function (key, value) {
                self.UserLists.push(new User(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]],
                "oLanguage": {
                    "sSearch": "Filter: "
                }
            });
        }
        else {
            CRMLite.showMesssage.error(response.Message, "Error");
        }
    });
};
UserViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.DisplayTitle('Create User');
    self.selectedUser(new User({}));
    self.selectedUser().resetValidation();
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

        o.src = imagPath;;
        path = ko.toJS(strPath);
    }
};
UserViewModel.prototype.getUser = function () {
    var self = this;
    var id = $("#hdnAgnetId").val();
    self.isBusy(true);
    function changePic(strPath) {
        // var that = {};
        var vm = ko.toJS(strPath);
        var o = document.getElementById("ThumbnailImageS");
        var imagPath = new String(ko.toJS(CRMLite.CRM.uploadUser));
        imagPath = imagPath.concat(strPath);
        o.src = imagPath;
        path = ko.toJS(CRMLite.CRM.uploadUser) + ko.toJS(strPath);
        self.selectedUser().image(path);
        //return that;
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
    var result = CRMLite.dataManager.getData(ko.toJS(CRMLite.CRM.UserapiGetUser)+ id);
    result.done(function (data) {
        if (data.Status == true) {
            self.selectedUser(new User(data.Result));
            self.isBusy(false);
        }
        else {
            CRMLite.showMesssage.error(response.Message, "Error");
        }
    }); 
};

