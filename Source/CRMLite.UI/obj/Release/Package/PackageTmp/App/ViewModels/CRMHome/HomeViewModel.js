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