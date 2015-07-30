function FullCalendarViewModel() {
    var self = this;
    self.url = urls.CRM;
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
            url: ko.toJS(self.url.fullCalenderapiGetEvents),
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
        $.get(ko.toJS(self.url.fullCalenderapiGetEventsentityType) + item, function (response) {
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
        $.get(ko.toJS(self.url.fullCalenderapiSaveEvent), jsonData, function (data) {
            if (data) {
                //$('#calendar').fullCalendar('refetchEvents');
                bootbox.alert('New event saved!');
                // $('#calendar').fullCalendar('refresh');
                window.location.href = ko.toJS(self.url.fullCalenderIndexentityType) + ko.toJS(self.EntityType) + '&id=' + ko.toJS(self.PersonId);
            }
        });
    };
    self.edit = function () {
        // alert(ko.toJS(self.eventDate));
        $('#OpertationDiv').modal('hide');
        $('#popupEventForm').modal('show');
    };
    self.eventdelete = function () {
        $.get(ko.toJS(self.url.fullCalenderapiDeleteEvent) + ko.toJS(self.Id), function (data) {
            if (data) {
                //$('#calendar').fullCalendar('refetchEvents');
                bootbox.alert('Event Deleted!');
                // $('#calendar').fullCalendar('refresh');
                window.location.href = ko.toJS(self.url.fullCalenderIndexentityType) + ko.toJS(self.EntityType) + '&id=' + ko.toJS(self.PersonId);
            }
        });
    };
    self.btnDetails = function () {
        $.get(ko.toJS(self.url.fullCalenderapiDetailEvent) + ko.toJS(self.Id), function (data) {
            if (data) {
                alert(data);
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
        $.get(ko.toJS(self.url.fullCalenderapiUpdateEvent), jsonData, function (data) {
            if (data) {
                //$('#calendar').fullCalendar('refetchEvents');
                bootbox.alert('Event Updated!');
                // $('#calendar').fullCalendar('refresh');
                window.location.href = ko.toJS(self.url.fullCalenderIndexentityType) + ko.toJS(self.EntityType) + '&id=' + ko.toJS(self.PersonId);
            }
        });
    };
};