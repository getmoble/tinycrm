function AgentViewModel() {
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
    self.AgentLists = ko.observableArray();
    self.selectedAgent = ko.observable(new Agent({}));
    self.gotoAgentdetails = function (item) {
        window.location.href = ko.toJS(self.url.gotoAgentdetails) + item.Id();
    };
    self.agentdetails = function () {
        self.isBusy(true);
        var id = $("#hdnAgentId").val();
        $.get(ko.toJS(self.url.agentapiGetAgent) + id, function (data) {
            self.selectedAgent(new Agent(data));
            self.isBusy(false);
        });
    };
    self.agentedit = function (item) {
        self.isCreate(false);
        self.isUpdate(true);
        self.DisplayTitle('Edit Agent');

        function changePic(strPath) {
            // var that = {};
            var vm = ko.toJS(strPath);
            var o = document.getElementById("ThumbnailImageS");
            var imagPath = new String(ko.toJS(self.url.uploadAgent));
            imagPath = imagPath.concat(strPath);
            o.src = imagPath;
            path = ko.toJS(self.url.uploadAgent)+ko.toJS(strPath);
            self.selectedAgent().image(path);
            //return that;
        }

        setTimeout(function () {
            $("#avatar").change(function () {
                var fileData = $("#avatar").prop("files")[0];
                var formData = new FormData();
                formData.append("file", fileData);
                formData.append("user_id", 123);
                $.ajax({
                    url: ko.toJS(self.url.agentapiUploadImageFiles),
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
        $.get(ko.toJS(self.url.agentapiEditAgent) + item.Id(), function (data) {
            self.selectedAgent(new Agent(data));
        });
    };
    self.agentdelete = function (item) {
        bootbox.confirm("Do you want to delete this Agent?", function (result) {
            if (result) {
                $.get(ko.toJS(self.url.agentapiGetDelete) + item.Id());
                bootbox.alert("Deleted Successfully..!!", function () {
                    window.location.href = ko.toJS(self.url.agentIndex);
                });
            }
        });
    };
    self.updateAgentProfile = function (item) {
        window.location.href = ko.toJS(self.url.agentUpdate) + item.Id();
    };
    self.saveAgentProfile = function () {
        self.selectedAgent().resetValidation();
        if (self.selectedAgent().modelState.isValid()) {
            self.busy(true);
            var jsonData = {
                FirstName: ko.toJS(self.selectedAgent().firstname), LastName: ko.toJS(self.selectedAgent().lastname),//$('#avatar').val()
                Email: ko.toJS(self.selectedAgent().email), Phone: ko.toJS(self.selectedAgent().phoneNumber), Image: ko.toJS(self.selectedAgent().image), Address: ko.toJS(self.selectedAgent().address),
                DEDlicenseNumber: ko.toJS(self.selectedAgent().DEDlicenseNumber), RERAregistrationNumber: ko.toJS(self.selectedAgent().RERAregistrationNumber),
                IsListingMember: ko.toJS(self.selectedAgent().islistingmember), Id: ko.toJS(self.selectedAgent().Id), CommunicationDetailID: ko.toJS(self.selectedAgent().contactdetailId)
            };
            var result = $.post(ko.toJS(self.url.agentapiUpdate), jsonData);
            result.done(function (response) {
                self.busy(false);
                if (response === true) {
                    bootbox.alert("Updated successfully...!!", function () {
                        window.location.href = ko.toJS(self.url.agentIndex);
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
    self.gotoAgentPage = function () {
        var self = this;
        self.DisplayTitle('Create Agent');
        window.location.href = ko.toJS(self.url.agentCreate);
    };
};
AgentViewModel.prototype.init = function () {
    var self = this;
    self.selectedAgent(new Agent({}));
};
AgentViewModel.prototype.saveAgent = function () {
    var self = this;
    self.selectedAgent().resetValidation();
    if (self.selectedAgent().modelState.isValid()) {
        self.busy(true);
        var jsonData = {
            FirstName: ko.toJS(self.selectedAgent().firstname), LastName: ko.toJS(self.selectedAgent().lastname),
            Email: ko.toJS(self.selectedAgent().email), Phone: ko.toJS(self.selectedAgent().phoneNumber),
            Address: ko.toJS(self.selectedAgent().address), DEDlicenseNumber: ko.toJS(self.selectedAgent().DEDlicenseNumber),
            RERAregistrationNumber: ko.toJS(self.selectedAgent().RERAregistrationNumber),
            IsListingMember: ko.toJS(self.selectedAgent().islistingmember), Id: ko.toJS(self.selectedAgent().id), Image: ko.toJS($('#avatar').val())
        };
        var result = $.post(ko.toJS(self.url.agentapiCreate), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                bootbox.alert("Saved successfully...!!", function () {

                    window.location.href = ko.toJS(self.url.agentIndex);
                });
            }
            else {
                bootbox.alert("Error occured");

            }
        });
    }
    else {
        self.selectedAgent().modelState.errors.showAllMessages();
    }

};
AgentViewModel.prototype.AddAgent = function () {
    window.location.href = ko.toJS(self.url.agentList);
};
AgentViewModel.prototype.updateAgent = function () {
    var self = this;
    self.selectedAgent().resetValidation();
    if (self.selectedAgent().modelState.isValid()) {
        self.busy(true);
        var jsonData = {
            FirstName: ko.toJS(self.selectedAgent().firstname), LastName: ko.toJS(self.selectedAgent().lastname),//$('#avatar').val()
            Email: ko.toJS(self.selectedAgent().email), Phone: ko.toJS(self.selectedAgent().phoneNumber), Image: ko.toJS(self.selectedAgent().image), Address: ko.toJS(self.selectedAgent().address),
            DEDlicenseNumber: ko.toJS(self.selectedAgent().DEDlicenseNumber), RERAregistrationNumber: ko.toJS(self.selectedAgent().RERAregistrationNumber),
            IsListingMember: ko.toJS(self.selectedAgent().islistingmember), Id: ko.toJS(self.selectedAgent().Id), CommunicationDetailID: ko.toJS(self.selectedAgent().contactdetailId)
        };
        var result = $.post(ko.toJS(self.url.agentapiUpdate), jsonData);
        result.done(function (response) {
            self.busy(false);
            if (response === true) {
                bootbox.alert("Updated successfully...!!", function () {
                    window.location.href = ko.toJS(self.url.agentIndex);
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
AgentViewModel.prototype.AgentListing = function () {
    var self = this;
    self.isBusy(true);
    self.isCreate(true);
    $.getJSON(ko.toJS(self.url.agentapiList), function (response) {
        if (response.Status == false) {
            if (response.Code == 401) {
                window.location.href = ko.toJS(self.url.errorNotAuthorized);
            }
            else {
                bootbox.alert(response);
            }
        } else {
            $.each($.parseJSON(response), function (key, value) {
                self.AgentLists.push(new Agent(value));
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
AgentViewModel.prototype.search = function () {
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

    $.get(ko.toJS(self.url.agentapiSearch), jsonData, function (response) {
        self.AgentLists.removeAll();
        $.each(response, function (key, value) {
            self.AgentLists.push(new Agent(value));
        });
        $("#pagination").DataTable({ responsive: true });
    });
};
AgentViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.isBusy(true);
    self.DisplayTitle('Create Agent');
    self.selectedAgent(new Agent({}));
    self.selectedAgent().resetValidation();
    $("#avatar").change(function () {
        var file_data = $("#avatar").prop("files")[0];
        var form_data = new FormData();
        form_data.append("file", file_data);
        form_data.append("user_id", 123);
        $.ajax({
            url: ko.toJS(self.url.agentapiUploadImageFiles),
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
        var imagPath = new String(ko.toJS(self.url.uploadAgent));
        imagPath = imagPath.concat(strPath);

        o.src = imagPath;;
        path = ko.toJS(strPath);
    }
    self.isBusy(false);
};
AgentViewModel.prototype.getAgent = function () {
    var self = this;
    var id = $("#hdnAgnetId").val();
    self.isBusy(true);
    function changePic(strPath) {
        // var that = {};
        var vm = ko.toJS(strPath);
        var o = document.getElementById("ThumbnailImageS");
        var imagPath = new String(ko.toJS(self.url.uploadAgent));
        imagPath = imagPath.concat(strPath);
        o.src = imagPath;
        path = ko.toJS(self.url.uploadAgent) + ko.toJS(strPath);
        self.selectedAgent().image(path);
        //return that;
    }

    setTimeout(function () {
        $("#avatar").change(function () {
            var fileData = $("#avatar").prop("files")[0];
            var formData = new FormData();
            formData.append("file", fileData);
            formData.append("user_id", 123);
            $.ajax({
                url: ko.toJS(self.url.agentapiUploadImageFiles),
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
    $.getJSON(ko.toJS(self.url.agentapiGetAgent) + id, function (data) {
        self.selectedAgent(new Agent(data));
        self.isBusy(false);
    });
 
};

