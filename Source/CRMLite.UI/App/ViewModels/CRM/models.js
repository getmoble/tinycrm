function SelectedItem(item) {
    var self = this;
    self.Id = ko.observable(item.Id);
    self.Name = ko.observable(item.Name);
}

function SelectAccount(account) {
    var self = this;
    self.Id = ko.observable(account.Id || 0);

    self.Name = ko.observable('');
    if (account.Person)
    {
        self.Name(account.Person.FirstName);
    }
}
function BarChart(sales) {
    var self = this;
    self.y = sales.Month || '';
    self.a = parseInt(sales.Count) || 0;
}
function DoNutChart(leadSource) {
    var self = this;
    self.label = leadSource.LeadStatusKey || '';
    self.value = parseInt(leadSource.Count) || 0;
}
function ParseDate(date) {
    return new Date(parseFloat(/Date\(([^)]+)\)/.exec(date)[1]));
};
function Schedule(events) {
    var self = this;
    self.id = events.Id || 0;
    self.title = events.Title || '';
    self.time = events.Time || '';
    if (events.StartTime) {
        self.start = ParseDate(events.StartTime) || '';
    }
    else {
        self.start = new Date();
    }
    if (events.EndTime)
        self.end = ParseDate(events.EndTime) || '';
    else
        self.end = new Date();
}