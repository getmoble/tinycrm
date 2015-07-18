function HomeViewModel() {
    var self = this;
    self.donut = ko.observable();
    self.bar = ko.observable();
    //var colors_array = ["#CC9999", "#0066FF", "#660000", "#CC0000", "#CC0000", "#B00000", "#FF0000 "];
    $.get('/Api/HomeApi/GetStatus', function (data) {

        var dataArray = [];
        var leadStatusesArray = [];

        $.each(data.SalesStage, function (k, v) {
            dataArray.push(new BarChart(v));
        });

        Morris.Bar({
            element: 'barChart',
            data: dataArray,
            xkey: 'y',
            ykeys: ['a'],
            labels: ['Series A']
            //,
            //barColors: function (row, series, type) {
            //    if (type === 'bar') {
            //        var red = Math.ceil(255 * row.y / this.ymax);
            //        return 'rgb(' + red + ',0,0)';
            //    }
            //    else {
            //        return '#000';
            //    }
            //}
        });

        $.each(data.LeadStatuses, function (k, v) {
            leadStatusesArray.push(new DoNutChart(v));
        });
        Morris.Donut({
            element: 'doNutChart',
            data: leadStatusesArray
            //,colors: ['#CC9999']
        });

        //self.donut(leadStatusesArray);
    });
};
function ParseToCommonDateFormat(date) {
    if (date) {
        var myDate = new Date(parseFloat(/Date\(([^)]+)\)/.exec(date)[1]));
        return myDate.getDate() + '/' + (myDate.getMonth() + 1) + '/'
+ myDate.getFullYear() + '  ' + myDate.getHours() + ':' + myDate.getMinutes() + ':'
+ myDate.getSeconds();
    } else {
        return '';
    }
};
function FullCalendarViewModel() {
    var self = this;
    self.Id = ko.observable();
    self.PersonId = ko.observable();
    self.eventTitle = ko.observable('');
    self.eventDate = ko.observable('');
    self.EntityType = ko.observable();
    self.eventTime = ko.observable('9:00');
    self.eventDuration = ko.observable('');
    self.events = ko.observableArray();
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.fetchEvents = function () {
   
        $.ajax({
            url: '/Api/FullCalenderApi/GetEvents',
            data: {
                //start: start,
                //end: end
            },
            success: function (result) {               
                $.each(result, function (key, value) {                    
                   self.events.push(new Schedule(value));
                });    
            }
        });
    };
    self.init = function (item, id) {
        self.EntityType(item);
        self.PersonId(id);
        self.isCreate(true);
        self.isUpdate(false);
        $.get('/Api/FullCalenderApi/GetEvents?entityType=' + item, function (response) {
            $.each(response, function (key, value) {
                self.events.push(new Schedule(value));
            });

       
        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay',
                theme: true
            },
            // This will be called whenever the calender needs new data
            events: ko.toJS(self.events),
            selectable: true,
            selectHelper: true,
            select: function (start, end) {
                self.Id('');
                self.eventTitle('');
                self.eventTime('');
                self.eventDate(moment(start).format('MM/DD/YYYY'));
                self.eventTime(moment(start).format('HH:MM'));
                //$('#OpertationDiv').modal('hide');
                $('#popupEventForm').modal('show');
                //$('#eventDate').val(start);
            },
            eventClick: function (callEvent) {
                self.isCreate(false);
                self.isUpdate(true);
                self.Id(callEvent.id);
                self.eventDate(moment(callEvent.start).format('MM/DD/YYYY'));
                self.eventTime(moment(callEvent.start).format('HH:MM'));
                self.eventTitle(callEvent.title);
                self.eventTime(callEvent.time);
                $('#OpertationDiv').modal('show');
            }
        });
        });
    };
    self.save = function () {
        var jsonData = {
            Title: ko.toJS(self.eventTitle), NewEventDate: ko.toJS(self.eventDate),
            NewEventTime: ko.toJS(self.eventTime), NewEventDuration: ko.toJS(self.eventDuration),
            EventForId: ko.toJS(self.PersonId), EntityType: ko.toJS(self.EntityType)
        };
        $.get('/Api/FullCalenderApi/SaveEvent', jsonData, function (data) {
            if(data)
            {               
                //$('#calendar').fullCalendar('refetchEvents');
                bootbox.alert('New event saved!');
                // $('#calendar').fullCalendar('refresh');
                window.location.href = '/FullCalender/Index?entityType=' + ko.toJS(self.EntityType) + '&id=' + ko.toJS(self.PersonId);
            }
        });
    };
    self.edit = function () {
       // alert(ko.toJS(self.eventDate));
        $('#OpertationDiv').modal('hide');
        $('#popupEventForm').modal('show');
    };
    self.eventdelete = function () {
        $.get('/Api/FullCalenderApi/DeleteEvent?id='+ ko.toJS(self.Id), function (data) {
            if (data) {
                //$('#calendar').fullCalendar('refetchEvents');
                bootbox.alert('Event Deleted!');
                // $('#calendar').fullCalendar('refresh');
                window.location.href = '/FullCalender/Index?entityType='+ko.toJS(self.EntityType)+'&id='+ko.toJS(self.PersonId);
            }
        });
    };
    self.btnDetails = function () {
        $.get('/Api/FullCalenderApi/DetailEvent?id=' + ko.toJS(self.Id), function (data) {
            if (data) {
                alert(data)
                ////$('#calendar').fullCalendar('refetchEvents');
                //bootbox.alert('Event Deleted!');
                //// $('#calendar').fullCalendar('refresh');
                //window.location.href = '/FullCalender/Index?entityType=' + ko.toJS(self.EntityType) + '&id=' + ko.toJS(self.PersonId);
            }
        });
    };
    self.update = function () {
        var jsonData = {
            id: ko.toJS(self.Id), title: ko.toJS(self.eventTitle), newEventDate: ko.toJS(self.eventDate),
            newEventTime: ko.toJS(self.eventTime), NewEventDuration: ko.toJS(self.eventDuration),
            EventForId: ko.toJS(self.PersonId), EntityType: ko.toJS(self.EntityType)
        };
        $.get('/Api/FullCalenderApi/UpdateEvent', jsonData, function (data) {
            if (data) {
                //$('#calendar').fullCalendar('refetchEvents');
                bootbox.alert('Event Updated!');
                // $('#calendar').fullCalendar('refresh');
                window.location.href = '/FullCalender/Index?entityType=' + ko.toJS(self.EntityType) + '&id=' + ko.toJS(self.PersonId);
            }
        });
    };
};
function AgentViewModel() {
    var self = this;
    self.DisplayTitle = ko.observable();
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.SearchName = ko.observable();
    self.SearchEmail = ko.observable();
    self.SearchPhone = ko.observable();
    self.AgentLists = ko.observableArray();
    self.selectedAgent = ko.observable(new Agent({}));
    self.agentdetails = function (item) {
        $.get('/Api/AgentApi/GetAgent?id=' + item.Id(), function (data) {
            self.selectedAgent(new Agent(data));
        });
    };
    self.agentedit = function (item) {
        self.isCreate(false);
        self.isUpdate(true);
        self.DisplayTitle('Edit Agent');
        setTimeout(function () {
            $("#avatar").change(function () {
                var file_data = $("#avatar").prop("files")[0];
                var form_data = new FormData();
                form_data.append("file", file_data)
                form_data.append("user_id", 123)
                $.ajax({
                    url: "/AgentApi/UploadImageFiles",
                    dataType: 'json',
                    cache: false,
                    contentType: false,
                    processData: false,
                    data: form_data,
                    type: 'post',
                    success: function (files, data, xhr) {
                        changePic(files.Name);
                    },

                })
            });
        }, 2000);
        var path = null;
        function changePic(strPath) {
            // var that = {};
            var vm = ko.toJS(strPath);
            var o = document.getElementById("ThumbnailImageS");
            var imagPath = new String("/Upload/Agent/")
            imagPath = imagPath.concat(strPath);
            o.src = imagPath;;
            path = ko.toJS(strPath);
            //alert(imagPath);
            //return that;
        }
        $.get('/Api/AgentApi/EditAgent?id=' + item.Id(), function (data) {
            self.selectedAgent(new Agent(data));
        });
    };
    self.agentdelete = function (item) {
        bootbox.confirm("Do you want to delete this Agent?", function (result) {
            if (result) {
                $.get('/Api/AgentApi/GetDelete?id=' + item.Id());
                bootbox.alert("Deleted Successfully..!!", function () {
                    window.location.href = "/Agent/Index";
                });
            }
        });
    };
};
AgentViewModel.prototype.init = function () {
    var self = this;
    // self.resetValidation();
    self.selectedAgent(new Agent({}));
};
AgentViewModel.prototype.saveAgent = function () {
    var self = this;
    self.selectedAgent().resetValidation();
    //self.dataManager = propznetCRM.dataManager;
    //alert(JSON.stringify(self.selectedAgent()))
    if (self.selectedAgent().modelState.isValid()) {
        var jsonData = {
            FirstName: ko.toJS(self.selectedAgent().firstname), LastName: ko.toJS(self.selectedAgent().lastname),
            Email: ko.toJS(self.selectedAgent().email), Phone: ko.toJS(self.selectedAgent().phoneNumber),
            Address: ko.toJS(self.selectedAgent().address), DEDlicenseNumber: ko.toJS(self.selectedAgent().DEDlicenseNumber),
            RERAregistrationNumber: ko.toJS(self.selectedAgent().RERAregistrationNumber),
            IsListingMember: ko.toJS(self.selectedAgent().islistingmember), Id: ko.toJS(self.selectedAgent().id), Image: ko.toJS($('#avatar').val())
        };
        var result = $.post('/Api/AgentApi/Create', jsonData);
        result.done(function (response) {
            if (response == true) {
                bootbox.alert("Saved successfully...!!", function () {

                    window.location.href = "/Agent/Index";
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
    window.location.href = "/Agent";
};
AgentViewModel.prototype.updateAgent = function () {
    var self = this;
    self.selectedAgent().resetValidation();
    if (self.selectedAgent().modelState.isValid()) {
        var jsonData = {
            FirstName: ko.toJS(self.selectedAgent().firstname), LastName: ko.toJS(self.selectedAgent().lastname),//$('#avatar').val()
            Email: ko.toJS(self.selectedAgent().email), Phone: ko.toJS(self.selectedAgent().phoneNumber), Image: ko.toJS(self.selectedAgent().image), Address: ko.toJS(self.selectedAgent().address),
            DEDlicenseNumber: ko.toJS(self.selectedAgent().DEDlicenseNumber), RERAregistrationNumber: ko.toJS(self.selectedAgent().RERAregistrationNumber),
            IsListingMember: ko.toJS(self.selectedAgent().islistingmember), Id: ko.toJS(self.selectedAgent().Id), CommunicationDetailID: ko.toJS(self.selectedAgent().contactdetailId)
        };
        // alert(JSON.stringify(jsonData));
        var result = $.post('/Api/AgentApi/Update', jsonData);
        result.done(function (response) {
            if (response == true) {
                bootbox.alert("Updated successfully...!!", function () {
                    window.location.href = "/Agent/Index";
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
    self.isCreate(true);
    $.getJSON('/Api/AgentApi/List', function (response) {
        if (response.Status == false) {
            if (response.Code == 401) {
                window.location.href = '/Error/NotAuthorized';
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
            // oTable.fnSort([[6, 'desc']]);
        }
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

    $.get('/Api/AgentApi/Search', jsonData, function (response) {
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
    self.DisplayTitle('Create Agent');
    self.selectedAgent(new Agent({}));
    self.selectedAgent().resetValidation();
    $("#avatar").change(function () {
        var file_data = $("#avatar").prop("files")[0];
        var form_data = new FormData();
        form_data.append("file", file_data)
        form_data.append("user_id", 123)
        $.ajax({
            url: "/AgentApi/UploadImageFiles",
            dataType: 'json',
            cache: false,
            contentType: false,
            processData: false,
            data: form_data,
            type: 'post',
            success: function (files, data, xhr) {
                changePic(files.Name);
            },

        })
    });
    var path = null;
    function changePic(strPath) {
        var that = {};
        var vm = ko.toJS(strPath);
        //alert(strPath);
        var o = document.getElementById("ThumbnailImageS");
        var imagPath = new String("/Upload/Agent/")
        imagPath = imagPath.concat(strPath);

        o.src = imagPath;;
        path = ko.toJS(strPath);
        //alert(imagPath);
        //return that;
    }
};
function LeadViewModel() {
    var self = this;
    self.DisplayTitle = ko.observable();
    self.LeadLists = ko.observableArray();
    self.Assignto = ko.observableArray();
    self.salesStage = ko.observableArray();
    self.SelectedAssignedTo = ko.observable();
    self.SelectedLeadStatus = ko.observable();
    self.SelectedLeadSource = ko.observable();
    self.SelectedSalesStage = ko.observable();
    self.SelectedSearchAssignedTo = ko.observable();
    self.SelectedSearchLeadStatus = ko.observable();
    self.SelectedSearchLeadSource = ko.observable();
    self.Leadsource = ko.observableArray();
    self.Leadstatus = ko.observableArray();
    self.salesStage = ko.observableArray();
    self.selectedLead = ko.observable(new Lead({}));
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);

    self.selectedConvertLead = ko.observable(new SelectConvertLead({}));

    self.leaddelete = function (item) {
        bootbox.confirm("Do you want to delete this Lead?", function (result) {
            if (result) {
                $.get('/Api/LeadApi/DeleteLead?id=' + item.Id());
                bootbox.alert("Deleted Successfully..!!", function () {
                    window.location.href = "/Lead/Index";
                });
            }
        });
    };
    self.leaddetail = function (item) {

        $.get('/Api/LeadApi/GetLead?id=' + item.Id(), function (data) {
            self.selectedLead(new Lead(data));
        });
    };
    self.leadedit = function (item) {
        self.DisplayTitle('Edit Lead');
        self.isCreate(false);
        self.isUpdate(true);
        //$.get('/Api/LeadApi/GetData', function (data) {
        //    //self.Leadsource.removeAll();
        //    //self.Leadstatus.removeAll();
        //    //$.each(data.Agent, function (k, v) {
        //    //    self.Assignto.push(new SelectAssignedTo(v));
        //    //});
        //    //$.each(data.LeadStatus, function (k, v) {
        //    //    self.Leadstatus.push(new SelectLeadStatus(v));
        //    //});
        //    //$.each(data.LeadSource, function (k, v) {
        //    //    self.Leadsource.push(new SelectLeadSource(v));
        //    //});
        //});
        $.get('/Api/LeadApi/GetLead?id=' + item.Id(), function (data) {
            self.selectedLead(new Lead(data));
        });
    };
    self.convertLead = function (item) {

        //alert(item.Id())
        $.get('/Api/LeadApi/GetConvertLead?id=' + item.Id(), function (response) {
            //alert(JSON.stringify(response))
            self.selectedConvertLead(new SelectConvertLead(response));
            // alert(self.selectedConvertLead().firstname)

        });

    };
};
LeadViewModel.prototype.init = function () {
    var self = this;
    $.get('/Api/LeadApi/GetData', function (data) {
        self.selectedLead(new Lead({}));
        $.each(data.Agent, function (k, v) {
            self.Assignto.push(new SelectAssignedTo(v));
        });
        $.each(data.LeadStatus, function (k, v) {
            self.Leadstatus.push(new SelectLeadStatus(v));
        });
        $.each(data.LeadSource, function (k, v) {
            self.Leadsource.push(new SelectLeadSource(v));
        });

    });

};
LeadViewModel.prototype.search = function () {
    var self = this;
    var oldTable = $("#pagination").DataTable();
    oldTable
      .clear()
      .draw();
    oldTable.destroy();
    var jsonData = {
        LeadStatusId: ko.toJS(self.SelectedSearchLeadStatus),
        LeadSourceId: ko.toJS(self.SelectedSearchLeadSource), AgentId: ko.toJS(self.SelectedSearchAssignedTo)
    };

    $.post('/Api/LeadApi/Search', jsonData, function (response) {
        self.LeadLists.removeAll();
        $.each($.parseJSON(response), function (key, value) {
            self.LeadLists.push(new Lead(value));
        });
        $("#pagination").DataTable({ responsive: true });
    });
};
LeadViewModel.prototype.LeadListing = function () {
    var self = this;
    $.get('/Api/LeadApi/GetData', function (data) {
        self.selectedLead(new Lead({}));
        $.each(data.Agent, function (k, v) {
            self.Assignto.push(new SelectAssignedTo(v));
        });
        $.each(data.LeadStatus, function (k, v) {
            self.Leadstatus.push(new SelectLeadStatus(v));
        });
        $.each(data.LeadSource, function (k, v) {
            self.Leadsource.push(new SelectLeadSource(v));
        });
        $.each(data.SalesStage, function (k, v) {
            self.salesStage.push(new SelectSalesStage(v));
        });
    });
    $.getJSON('/Api/LeadApi/Index', function (response) {
        if (response.Status == false) {
            if (response.Code == 401) {
                window.location.href = '/Error/NotAuthorized';
            }
            else {
                bootbox.alert(response);
            }
        } else {
            $.each($.parseJSON(response), function (key, value) {
                self.LeadLists.push(new Lead(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            oTable = $('#pagination').dataTable();
            // oTable.fnSort([[6, 'desc']]);
        }
    });
};
LeadViewModel.prototype.saveLead = function () {
    var self = this;
  
    if (self.selectedLead().modelState.isValid()) {
        var jsonData = ko.toJS(self.selectedLead());
        //alert(JSON.stringify(jsonData));
        var result = $.post('/Api/LeadApi/Create', jsonData);
        result.done(function (response) {
            if (response == true) {
                bootbox.alert("Saved successfully...!!", function () {
                    window.location.href = "/Lead/Index";
                });
            }
            else {

                bootbox.alert("Error occured");
            }
        });
    }
    else {
        self.selectedLead().modelState.errors.showAllMessages();
    }
};
LeadViewModel.prototype.updateLead = function () {
    var self = this;
    if (self.selectedLead().modelState.isValid()) {
        //var jsonData = {
        //    Id: ko.toJS(self.selectedLead().Id), FirstName: ko.toJS(self.selectedLead().firstname), LastName: ko.toJS(self.selectedLead().lastname),
        //    RefId: ko.toJS(self.selectedLead().refId), LeadStatus: ko.toJS(self.selectedLead().SelectedLeadStatus), CommunicationDetailID: ko.toJS(self.selectedLead().contactdetailId),
        //    LeadSource: ko.toJS(self.selectedLead().SelectedLeadSource), AssignedTo: ko.toJS(self.selectedLead().SelectedAssignedTo), Email: ko.toJS(self.selectedLead().email),
        //    Phone: ko.toJS(self.selectedLead().phoneNumber), Company: ko.toJS(self.selectedLead().company),
        //    Comments: ko.toJS(self.selectedLead().comment), Website: ko.toJS(self.selectedLead().website)

        //};
        var jsonData = ko.toJS(self.selectedLead());
        //alert(JSON.stringify(jsonData));
        var result = $.post('/Api/LeadApi/Update', jsonData);
        result.done(function (response) {
            if (response == true) {
                bootbox.alert("Updated successfully...!!", function () {
                    window.location.href = "/Lead/Index";
                });
            }
            else {

                bootbox.alert("Error occured");

            }
        });
    }
    else {
        self.selectedLead().modelState.errors.showAllMessages();
    }
};
LeadViewModel.prototype.convertingLead = function (item) {
    var self = this;
    // alert($('#ExpectedDate').val());
    self.selectedConvertLead().ExpectedDate($('#ExpectedDate').val());
    var jsonData = ko.toJS(self.selectedConvertLead());
    //{
    //    FirstName: ko.toJS(self.selectedConvertLead().firstname), LastName: ko.toJS(self.selectedConvertLead().lastname),
    //    AccountName: ko.toJS(self.selectedConvertLead().AccountName), Id: ko.toJS(self.selectedConvertLead().Id),
    //    ExpectedDate: $('#ExpectedClosingDate').val(), PotentialName: ko.toJS(self.selectedConvertLead().PotentialName),
    //    PotentialAmount: ko.toJS(self.selectedConvertLead().PotentialAmount), SalesStageId: ko.toJS(self.selectedConvertLead().SelectedSalesStage),
    //    AgentId: ko.toJS(self.selectedConvertLead().SelectedAssignedTo), CommunicationDetailId: ko.toJS(self.selectedConvertLead().ContactDetailId),
    //    Email: ko.toJS(self.selectedConvertLead().email), Phone: ko.toJS(self.selectedConvertLead().phoneNumber),
    //    IsChecked: ko.toJS(self.selectedConvertLead().isChecked)

    //};
    //alert(ko.toJSON(self.selectedConvertLead().ExpectedDate))
    //alert(JSON.stringify(jsonData))
    $.post('/Api/LeadApi/ConvertLead', ko.toJS(jsonData), function (response) {
        // alert(response)
        if (response == true) {
            bootbox.alert("Converted successfully...!!", function () {
                window.location.href = "/Lead/Index";
            });
        }
        else {
            bootbox.alert(response);
        }
    });
};
LeadViewModel.prototype.ToDo = function (item) {  
    window.location.href = '/FullCalender/Index?entityType=Lead&id=' + ko.toJS(item.Id);
};
LeadViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.DisplayTitle('Create Lead');
    self.selectedLead(new Lead({}));
    self.selectedLead().resetValidation();
};
function PotentialViewModel() {
    var self = this;
    self.DisplayTitle = ko.observable();
    self.PotentialLists = ko.observableArray();
    self.Contacts = ko.observableArray();
    self.Leadsource = ko.observableArray();
    self.Leadstatus = ko.observableArray();
    self.Salesstage = ko.observableArray();
    self.propertytype = ko.observableArray();
    self.propertycategories = ko.observableArray();
    self.locations = ko.observableArray();
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.states = ko.observableArray();
    self.Agent = ko.observableArray();
    self.Account = ko.observableArray();
    self.SearchPropertyType = ko.observable();
    self.SearchAgent = ko.observable();
    self.SearchLeadSource = ko.observable();
    self.SearchSalesStage = ko.observable();
    self.SelectedPotential = ko.observable(new Potential({}));    
    self.SelectedAccount = ko.observable(new Account({}));
    self.potentialdelete = function (item) {
        bootbox.confirm("Do you want to delete this Potential?", function (result) {
            if (result) {
                $.post('/Api/PotentialApi/DeletePotential?id=' + item.Id(), function (response) {
                    if (response) {
                        bootbox.alert("Deleted Successfully..!!", function () {
                            window.location.href = "/Potential/Index";
                        });
                    }
                    else {
                        bootbox.alert("Error Please Try Again Later ..!!");
                    }
                });
            }
        });
    };
    self.potentialedit = function (item) {
       
        function toggleChevron(e) {
            $(e.target)
                .prev('.panel-heading')
                .find("i.indicator")
                .toggleClass('glyphicon-chevron-down glyphicon-chevron-up');
        }
        $('#accordion').on('hidden.bs.collapse', toggleChevron);
        $('#accordion').on('shown.bs.collapse', toggleChevron);
        self.isCreate(false);
        self.isUpdate(true);
        self.DisplayTitle('Edit Potential');
        $.get('/Api/PotentialApi/GetPotential?id=' + item.Id(), function (data) {
            self.SelectedPotential(new Potential(data));
            $("#AccountSelect").select2();
        });
        
    };
    self.potentialdetail = function (item) {
        $.get('/Api/PotentialApi/Details?id=' + item.Id(), function (data) {
            self.SelectedPotential(new Potential(data));
        });
    };
    //self.SelectedPotential().selectedState.subscribe(function (newValue) {
    //    alert(newValue)
    //    if (newValue != '' && newValue != null && newValue != 'undefined') {
    //        $.get('Api/PotentialApi/GetLocations?id=' + newValue, function (data) {
    //            self.locations.removeAll();
    //            $.each(data, function (k, v) {
    //                self.locations.push(new Location(v))
    //            });
    //        });
    //    }
    //});
};
PotentialViewModel.prototype.init = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);

    self.SelectedPotential().resetValidation();
    $.get('/Api/PotentialApi/GetAllPotential', function (response) {
        if (response.Status == false) {
            if (response.Code == 401) {
                window.location.href = '/Error/NotAuthorized';
            }
            else {
                bootbox.alert(response);
            }
        } else {
            $.each($.parseJSON(response.Potential), function (key, value) {
                self.PotentialLists.push(new Potential(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            oTable = $('#pagination').dataTable();
            // oTable.fnSort([[6, 'desc']]);
            $.each(response.Contacts, function (k, v) {
                self.Contacts.push(new Contact(v));
            });
            $.each(response.LeadSource, function (k, v) {
                self.Leadsource.push(new SelectLeadSource(v));
            });
            $.each(response.Accounts, function (k, v) {
                self.Account.push(new SelectAccount(v));
            });
            $.each(response.SalesStage, function (k, v) {
                self.Salesstage.push(new SelectLeadStatus(v));
            });
            $.each(response.Agents, function (k, v) {
                self.Agent.push(new SelectAssignedTo(v));
            });
            $.each(response.Propertytype, function (k, v) {
                self.propertytype.push(new PropertyType(v));
            });
            $.each(response.States, function (k, v) {
                self.states.push(new State(v));
            });
            $.each(response.Category, function (k, v) {
                self.propertycategories.push(new PropertyCategory(v));
            });
        }
        $("#AccountSelect").select2();
    });
    
    //self.SelectedPotential().selectedState.subscribe(function (newValue) {
    //    $.get('Api/PotentialApi/GetLocations?id=' + newValue, function (data) {
    //        self.locations.removeAll();
    //        $.each(data, function (k, v) {
    //            self.locations.push(new Location(v))
    //        });
    //    });

    //});

};
PotentialViewModel.prototype.savePotential = function () {
    var self = this;
    self.SelectedPotential().resetValidation();
    if (self.SelectedPotential().modelState.isValid()) {
        var jsonData = ko.toJS(self.SelectedPotential());
        //alert(JSON.stringify(jsonData))
        var result = $.post('/Api/PotentialApi/CreatePotential', jsonData);
        result.done(function (response) {
            if (response == true) {
                bootbox.alert("Saved successfully...!!", function () {
                    window.location.href = "/Potential/Index";
                });
            }
            else {

                bootbox.alert("Error occured");
            }
        });
    }
    else {
        self.SelectedPotential().modelState.errors.showAllMessages();
    }

};
PotentialViewModel.prototype.updatePotential = function () {
    var self = this;
    self.SelectedPotential().resetValidation();
    if (self.SelectedPotential().modelState.isValid()) {
        var jsonData = ko.toJS(self.SelectedPotential());
        var result = $.post('/Api/PotentialApi/UpdatePotential', jsonData);
        result.done(function (response) {
            if (response == true) {
                bootbox.alert("Updated successfully...!!", function () {
                    window.location.href = "/Potential/Index";
                });
            }
            else {

                bootbox.alert("Error occured");
            }
        });
    }
    else {
        self.SelectedPotential().modelState.errors.showAllMessages();
    }
};
PotentialViewModel.prototype.CreateAccount = function () {
    var self = this;
    self.SelectedAccount().resetValidation();
    if (self.SelectedAccount().modelState.isValid()) {
        var jsonData = ko.toJS(self.SelectedAccount());
        var result = $.post('/Api/AccountApi/CreateAccount', jsonData);
        result.done(function (response) {
            if (response == true) {
                //bootbox.alert("Saved successfully...!!", function () {
                //    //window.location.href = "/Potential/Index";
                //});
                bootbox.alert("Saved successfully...!!");
            }
            else {

                bootbox.alert(response);
            }
        });
    }
    else {
        self.SelectedAccount().modelState.errors.showAllMessages();
    }
    
};
PotentialViewModel.prototype.search = function () {
    var self = this;
    var oldTable = $("#pagination").DataTable();
    oldTable
      .clear()
      .draw();
    oldTable.destroy();
    var jsonData = { SalesStageId: ko.toJS(self.SearchSalesStage), PropertyTypeId: ko.toJS(self.SearchPropertyType), LeadSourceId: ko.toJS(self.SearchLeadSource), AgentId: ko.toJS(self.SearchAgent) };
    //alert(JSON.stringify(jsonData))
    $.get('/Api/PotentialApi/Search', jsonData, function (response) {
        self.PotentialLists.removeAll();
        $.each($.parseJSON(response), function (key, value) {
            self.PotentialLists.push(new Potential(value));
        });
        $("#pagination").DataTable({ responsive: true });
    });
};
PotentialViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.DisplayTitle('Create Potential');
    self.SelectedPotential(new Potential({}));
    self.SelectedPotential().resetValidation();
    function toggleChevron(e) {
        $(e.target)
            .prev('.panel-heading')
            .find("i.indicator")
            .toggleClass('fa fa-chevron-down fa fa-chevron-up');
    }
    $('#accordion').on('hidden.bs.collapse', toggleChevron);
    $('#accordion').on('shown.bs.collapse', toggleChevron);
    $("#AccountSelect").select2();
};
PotentialViewModel.prototype.ToDo = function (item) {
    window.location.href = '/FullCalender/Index?entityType=Potential&id=' + ko.toJS(item.Id);
};
function AccountViewModel() {
    var self = this;
    self.DisplayTitle = ko.observable();
    self.AccountLists = ko.observableArray();
    self.Agents = ko.observableArray();
    self.SearchAssignedTo = ko.observable();
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.SelectedAccount = ko.observable(new Account({}));
    self.accountdelete = function (item) {
        bootbox.confirm("Do you want to delete this Account?", function (result) {
            if (result) {
                $.get('/Api/AccountApi/DeleteAccount?id=' + item.Id());
                bootbox.alert("Deleted Successfully..!!", function () {
                    window.location.href = "/Account/Index";
                });
            }
        });
    };
    self.accountedit = function (item) {
        self.isCreate(false);
        self.isUpdate(true);
        self.DisplayTitle('Edit Account');
        $.get('/Api/AccountApi/GetAccount?id=' + item.Id(), function (data) {
            self.SelectedAccount(new Account(data));
        });
    };
    self.accountdetail = function (item) {
        $.get('/Api/AccountApi/GetAccount?id=' + item.Id(), function (data) {
            self.SelectedAccount(new Account(data));
        });
    };
};
AccountViewModel.prototype.init = function () {
    var self = this;
    self.SelectedAccount().resetValidation();
    self.isCreate(true);
    $.get('/Api/AccountApi/GetAllAccounts', function (response) {
        if (response.Status == false) {
            if (response.Code == 401) {
                window.location.href = '/Error/NotAuthorized';
            }
            else {
                bootbox.alert(response);
            }
        } else {
            $.each(response.Account, function (key, value) {
                self.AccountLists.push(new Account(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            oTable = $('#pagination').dataTable();
            // oTable.fnSort([[6, 'desc']]);
            $.each(response.Agent, function (key, value) {
                self.Agents.push(new SelectAssignedTo(value));
            });
        }
    });

};
AccountViewModel.prototype.saveAccount = function () {
    var self = this;
    self.SelectedAccount().resetValidation();
    if (self.SelectedAccount().modelState.isValid()) {
        var jsonData = ko.toJS(self.SelectedAccount());
        var result = $.post('/Api/AccountApi/CreateAccount', jsonData);
        result.done(function (response) {
            if (response == true) {
                bootbox.alert("Saved successfully...!!", function () {
                    window.location.href = "/Account/Index";
                });
            }
            else {

                bootbox.alert(response);
            }
        });
    }
    else {
        self.SelectedAccount().modelState.errors.showAllMessages();
    }
};
AccountViewModel.prototype.updateAccount = function () {
    var self = this;
    var jsonData = ko.toJS(self.SelectedAccount());
    var result = $.post('/Api/AccountApi/UpdateAccount', jsonData);
    result.done(function (response) {
        if (response == true) {
            bootbox.alert("Updated successfully...!!", function () {
                window.location.href = "/Account/Index";
            });
        }
        else {
            bootbox.alert("Error occured");

        }
    });
};
AccountViewModel.prototype.search = function () {
    var self = this;
    var oldTable = $("#pagination").DataTable();
    oldTable
      .clear()
      .draw();
    oldTable.destroy();
    var jsonData = {
        AgentId: ko.toJS(self.SearchAssignedTo)
    };

    $.get('/Api/AccountApi/Search', jsonData, function (response) {
        self.AccountLists.removeAll();
        $.each(response, function (key, value) {
            self.AccountLists.push(new Account(value));
        });

        $("#pagination").DataTable({ responsive: true });
    });
};
AccountViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.DisplayTitle('Create Account');
    self.SelectedAccount(new Account({}));
    self.SelectedAccount().resetValidation();
};
AccountViewModel.prototype.ToDo = function (item) {
    window.location.href = '/FullCalender/Index?entityType=Account&id=' + ko.toJS(item.Id);
};
function ContactViewModel() {
    var self = this;
    self.DisplayTitle = ko.observable();
    self.Account = ko.observableArray();
    self.Agent = ko.observableArray();
    self.ContactLists = ko.observableArray();
    self.SearchTitle = ko.observable();
    self.SearchAgent = ko.observable();
    self.SearchAccount = ko.observable();
    self.isCreate = ko.observable(false);
    self.isUpdate = ko.observable(false);
    self.SelectedContact = ko.observable(new Contact({}));
    self.contactdelete = function (item) {
        bootbox.confirm("Do you want to delete this Contact?", function (result) {
            if (result) {
                $.get('/Api/ContactApi/DeleteContact?id=' + item.Id());
                bootbox.alert("Deleted Successfully..!!", function () {
                    window.location.href = "/Contact/Index";
                });
            }
        });
    };
    self.contactedit = function (item) {
        self.isCreate(false);
        self.isUpdate(true);
        self.DisplayTitle('Edit Contact');
        $.get('/Api/ContactApi/GetContact?id=' + item.Id(), function (data) {
            self.SelectedContact(new Contact(data));
        });
    };
    self.contactdetails = function (item) {
        $.get('/Api/ContactApi/GetContact?id=' + item.Id(), function (data) {
            self.SelectedContact(new Contact(data));
        });
    };
};
ContactViewModel.prototype.init = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.DisplayTitle('Create Contact');
    self.SelectedContact().resetValidation();
    $.get('/Api/ContactApi/GetAllContacts', function (response) {
        if (response.Status == false) {
            if (response.Code == 401) {
                window.location.href = '/Error/NotAuthorized';
            }
            else {
                bootbox.alert(response);
            }
        } else {
            $.each(response.Agents, function (key, value) {
                self.Agent.push(new SelectAssignedTo(value));
            });
            $.each(response.Accounts, function (key, value) {
                self.Account.push(new SelectAccount(value));
            });

            self.Refresh = function () {
                Pace.track(function () {
                    //obj.page = currentPage;
                    //var result = propznetApp.dataManager.postData('/Api/PropertyList/SearchProperty');
                    //result.done(function (data) {
                    //    self.pagingInfo(data.PagingInfo);
                    //    currentPage = ko.toJS(data.PagingInfo.CurrentPage);
                    //    totalPage = ko.toJS(data.PagingInfo.TotalPages);
                    //    self.totalItems(data.PagingInfo.TotalItems);
                    //    $.each(data.SearchList, function (x, i) {
                    //        self.Properties.push(new PropertySearch(i));
            //    });
                       
                    //});
                });


            };
            //self.GetNextPage = function () {
            //    if (currentPage < totalPage) {
            //        currentPage = currentPage + 1;
            //        self.Refresh();
            //    }

            //};
            //self.Refresh();


            $.each(response.Contacts, function (key, value) {
                self.ContactLists.push(new Contact(value));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            oTable = $('#pagination').dataTable();
            // oTable.fnSort([[6, 'desc']]);
            
        }
    });
};
ContactViewModel.prototype.saveContact = function () {
    var self = this;
    self.SelectedContact().resetValidation();
    if (self.SelectedContact().modelState.isValid()) {
        var jsonData = ko.toJS(self.SelectedContact());
        var result = $.post('/Api/ContactApi/CreateContact', jsonData);
        result.done(function (response) {
            if (response == true) {
                bootbox.alert("Saved successfully...!!", function () {
                    window.location.href = "/Contact/Index";
                });
            }
            else {

                bootbox.alert("Error occured");
            }
        });
    }
    else {
        self.SelectedContact().modelState.errors.showAllMessages();
    }
};
ContactViewModel.prototype.updateContact = function () {
    var self = this;
    if (self.SelectedContact().modelState.isValid()) {
        var jsonData = ko.toJS(self.SelectedContact());
        //$.get('/Api/ContactApi/UpdateContact', jsonData, function (data) {
        //    self.SelectedContact(new Contact(data));
        //});
        var result = $.get('/Api/ContactApi/UpdateContact', jsonData);
        result.done(function (response) {
            if (response == true) {
                bootbox.alert("Updated successfully...!!", function () {
                    window.location.href = "/Contact/Index";
                });
            }
            else {

                bootbox.alert("Error occured");

            }
        });
    } else {
        self.SelectedContact().modelState.errors.showAllMessages();
    }
};
ContactViewModel.prototype.search = function () {
    var self = this;
    var oldTable = $("#pagination").DataTable();
    oldTable
      .clear()
      .draw();
    oldTable.destroy();
    var jsonData = {
        AgentId: ko.toJS(self.SearchAgent), AccountId: ko.toJS(self.SearchAccount), Title: ko.toJS(self.SearchTitle)
    };

    $.get('/Api/ContactApi/Search', jsonData, function (response) {
        self.ContactLists.removeAll();
        $.each(response, function (key, value) {
            self.ContactLists.push(new Contact(value));
        });

        $("#pagination").DataTable({ responsive: true });
    });
};
ContactViewModel.prototype.clear = function () {
    var self = this;
    self.isCreate(true);
    self.isUpdate(false);
    self.SelectedContact(new Contact({}));
    self.SelectedContact().resetValidation();
};
ContactViewModel.prototype.ToDo = function (item) {
    window.location.href = '/FullCalender/Index?entityType=Contact&id=' + ko.toJS(item.Id);
};
function SettingsViewModel() {
    var self = this;
    self.pagingSize = ko.observable();

    self.Change = function () {
        var result = $.post('/Api/SettingsApi/ChangePagingSize?pagingsize=' + self.pagingSize());
        result.done(function (response) {
            if (response == true) {
                bootbox.alert("Saved successfully...!!", function () {
                    //window.location.href = "/Settings";
                });
            }
            else {
                bootbox.alert("Error occured");
            }
        });
    };
};
