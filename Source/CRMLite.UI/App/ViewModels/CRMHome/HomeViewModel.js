function HomeViewModel() {
    var self = this;
    self.donut = ko.observable();
    self.bar = ko.observable();
    $.get('/Api/HomeApi/GetStatus', function (data) {

        var dataArray = [];
        var leadStatusesArray = [];

        $.each(data.SalesStage, function (k, v) {
            dataArray.push(new BarChart(v));
        });
        if (dataArray.length != 0)
        {
            Morris.Bar({
                element: 'barChart',
                data: dataArray,
                xkey: 'y',
                ykeys: ['a'],
                labels: ['Series A']
            });
        }
        else
        {
            Morris.Donut({
                element: 'barChart',
                data: data.length ? data : [{ label: "No Data", value: 0 }]
                , colors: ['#CC9999']
            });
        }
    

        $.each(data.LeadStatuses, function (k, v) {
            leadStatusesArray.push(new DoNutChart(v));
        });

        if (leadStatusesArray.length != 0) {
            Morris.Donut({
                element: 'doNutChart',
                data: leadStatusesArray
                //,colors: ['#CC9999']
            });
        }
        else {
            Morris.Donut({
                element: 'doNutChart',
                data: data.length ? data : [{ label: "No Data", value: 0 }]
                , colors: ['#CC9999']
            });
        }
       
    });
};