function UserViewModel() {
    var self = this;
    self.url = urls.CRM;
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
        window.location.href = ko.toJS(self.url.gotoUserdetails) + item.Id();
    };
    self.Userdetails = function () {
        self.isBusy(true);
        var id = $("#hdnUserId").val();
        $.get(ko.toJS(self.url.UserapiGetUser) + id, function (data) {
            self.selectedUser(new User(data));
            self.isBusy(false);
        });
    };
    self.Useredit = function (item) {
        self.isCreate(false);
        self.isUpdate(true);
        self.DisplayTitle('Edit User');

        function changePic(strPath) {
            // var that = {};
            var vm = ko.toJS(strPath);
            var o = document.getElementById("ThumbnailImageS");
            var imagPath = new String(ko.toJS(self.url.uploadUser));
            imagPath = imagPath.concat(strPath);
            o.src = imagPath;
            path = ko.toJS(self.url.uploadUser)+ko.toJS(strPath);
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
                    url: ko.toJS(self.url.UserapiUploadImageFiles),
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
        $.get(ko.toJS(self.url.UserapiEditUser) + item.Id(), function (data) {
            self.selectedUser(new User(data));
        });
    };
    self.Userdelete = function (item) {
        bootbox.confirm("Do you want to delete this User?", function (result) {
            if (result) {
                $.get(ko.toJS(self.url.UserapiGetDelete) + item.Id());
                bootbox.alert("Deleted Successfully..!!", function () {
                    window.location.href = ko.toJS(self.url.UserIndex);
                });
            }
        });
    };
    self.updateUserProfile = function (item) {
        window.location.href = ko.toJS(self.url.UserUpdate) + item.Id();
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
            var result = $.post(ko.toJS(self.url.UserapiUpdate), jsonData);
            result.done(function (response) {
                self.busy(false);
                if (response === true) {
                    bootbox.alert("Updated successfully...!!", function () {
                        window.location.href = ko.toJS(self.url.UserIndex);
                    });
                }
                else {
                    bootbox.alert("Error occured");

                }
            });
        }
        else {
            self.modelState.errors.showAllMessages();
        }
    }
    self.gotoUserPage = function () {
        var self = this;
        self.DisplayTitle('Create User');
        //window.location.href = ko.toJS(self.url.UserCreate);
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
        var result = $.post(ko.toJS(self.url.UserapiCreate), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                bootbox.alert("Saved successfully...!!", function () {

                    window.location.href = ko.toJS(self.url.UserIndex);
                });
            }
            else {
                bootbox.alert("Error occured");

            }
        });
    }
    else {
        self.selectedUser().modelState.errors.showAllMessages();
    }

};
UserViewModel.prototype.AddUser = function () {
    window.location.href = ko.toJS(self.url.UserList);
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
        var result = $.post(ko.toJS(self.url.UserapiUpdate), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                bootbox.alert("Updated successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.UserIndex);
                });
            }
            else {
                bootbox.alert("Error occured");

            }
        });
    }
    else {
        self.modelState.errors.showAllMessages();
    }
};
UserViewModel.prototype.UserListing = function () {
    var self = this;
    self.isBusy(true);
    self.isCreate(true);
    $.getJSON(ko.toJS(self.url.UserapiList), function (response) {
        if (response.Status == false) {
            if (response.Code == 401) {
                window.location.href = ko.toJS(self.url.errorNotAuthorized);
            }
            else {
                bootbox.alert(response);
            }
        } else {
            alert(ko.toJSON(response));
            $.each($.parseJSON(response), function (key, value) {             
                self.UserLists.push(new User(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            oTable = $('#pagination').dataTable();
        }
        self.isBusy(false);
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

    $.get(ko.toJS(self.url.UserapiSearch), jsonData, function (response) {
        self.UserLists.removeAll();
        $.each(response, function (key, value) {
            self.UserLists.push(new User(value));
        });
        $("#pagination").DataTable({ responsive: true });
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
            url: ko.toJS(self.url.UserapiUploadImageFiles),
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
        var imagPath = new String(ko.toJS(self.url.uploadUser));
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
        var imagPath = new String(ko.toJS(self.url.uploadUser));
        imagPath = imagPath.concat(strPath);
        o.src = imagPath;
        path = ko.toJS(self.url.uploadUser) + ko.toJS(strPath);
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
                url: ko.toJS(self.url.UserapiUploadImageFiles),
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
    $.getJSON(ko.toJS(self.url.UserapiGetUser) + id, function (data) {
        self.selectedUser(new User(data));
        self.isBusy(false);
    });
 
};

