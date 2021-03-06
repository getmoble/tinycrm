$(document).ready( function(){
  var cTime = new Date(), month = cTime.getMonth()+1, year = cTime.getFullYear();

	theMonths = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

	theDays = ["S", "M", "T", "W", "T", "F", "S"];
    events = [
      [
        "4/"+month+"/"+year, 
        'Meet a friend', 
        '#', 
        '#177bbb', 
        'Contents here'
      ],
      [
        "7/"+month+"/"+year, 
        'Kick off meeting!', 
        '#', 
        '#1bbacc', 
        'Have a kick off meeting with .inc company'
      ],
      [
        "17/"+month+"/"+year, 
        'Milestone release', 
        '#', 
        '#fcc633', 
        'Contents here'
      ],
      [
        "19/"+month+"/"+year, 
        'A link', 
        'http://www.logiticks.com', 
        '#e33244'
      ]
    ];
    //$('#calendar').calendar({
    //    months: theMonths,
    //    days: theDays,
    //    events: events,
    //    popover_options:{
    //        placement: 'top',
    //        html: true
    //    }
    //});
});




jQuery(function ($) {
            /**
             * A jQuery plugin that loads data from HTML tables, Google Sheets and data arrays and draws charts using Google Charts.
             *
             * Using HTML Tables
             * HTML tables can help make the chart data accessible.
             * You can either display the table with the chart or accessibly hide the table
             *
             * Suggested HTML Table setup
             * Create an HTML table with a caption and 'th' elements in the first row
             * For each 'th' element apply one of the following
             * 'data-type' attribute: 'string' 'number' 'boolean' 'date' 'datetime' 'timeofday'
             * or 'data-role' attribute:  'tooltip','annotation'
             * The caption element's text is used as a title for the chart by default.
             *
             * Apply the jQuery Chartinator plugin to the chart canvas(es)
             * or select the table(s) and Chartinator will insert a new chart canvas(es) after the table
             * or create js data arrays
             * See examples below and the readme file for more info
             */

            // Bar Chart Example
        //    var chart1 = $('#barChart').chartinator({

        //        // Custom Options ------------------------------------------------------

        //        // The Google Sheet key
        //        // The id code of the Google sheet taken from the public url of your Google Sheet
        //        // Default: false
        //        googleSheetKey: '1kg6f4UVJPpT45D7ucAE8lhsVp8vIUl7bSMM442_DrhI',

        //        // The jQuery selector of the HTML table element to extract the data from - String
        //        // Default: false
        //        // If unspecified, the element this plugin is applied to must be the HTML table
        //        // or js columns and rows arrays must be defined
        //        //tableSel: '.barChart',

        //        // The chart type - String
        //        // Derived from the Google Charts visualization class name
        //        // Default: 'BarChart'
        //        // Use TitleCase names. eg. BarChart, PieChart, ColumnChart, Calendar, GeoChart, Table.
        //        // See Google Charts Gallery for a complete list of Chart types
        //        // https://developers.google.com/chart/interactive/docs/gallery
        //        chartType: 'BarChart',

        //        // The data title
        //        // A title used to identify the set of data
        //        // Used as a caption when generating an HTML table
        //        dataTitle: 'Bar Chart Data',

        //        // The class to apply to the table element
        //        tableClass: 'col-table',

        //        // Create Table - String
        //        // Create a basic HTML table or a Google Table Chart from chart data
        //        // Options: false, 'basic-table', 'table-chart'
        //        // Note: This table will replace an existing HTML table
        //        createTable: 'basic-table',

        //        // Transpose data Boolean - swap columns and rows
        //        // Default: false
        //        transpose: false,

        //        // Ignore row indexes array - An array of row index numbers to ignore
        //        // Default: []
        //        // Note: Only works when extracting data from HTML tables or Google Sheets
        //        // The headings row is index 0
        //        ignoreRow: [],

        //        // Ignore column indexes array
        //        // An array of column indexes to ignore in the HTML table or Google Sheet
        //        // Default: []
        //        // Note: Only works on data extracted from HTML tables or Google Sheets
        //        ignoreCol: [],

        //        // The tooltip concatenation - Defines a string for concatenating a custom tooltip.
        //        // Keywords: 'domain', 'data', 'label' - these will be replaced with current values
        //        // 'domain': the primary axis value, 'data': the data value, 'label': the column title
        //        // Default: false - use Google Charts tooltip defaults
        //        // Not supported on pie, calendar charts
        //        //tooltipConcat: 'domain - label: data',

        //        // The chart aspect ratio custom option - width/height
        //        // Used to calculate the chart dimensions relative to the width or height
        //        // this is overridden if the Google Chart's height and width options have values
        //        // Suggested value: 1.25
        //        // Default: false - not used
        //        //chartAspectRatio: 1.25,

        //        // Google Bar Chart Options
        //        barChart: {

        //            // Width of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            width: null,

        //            // Height of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            height: 400,

        //            chartArea: {
        //                left: "20%",
        //                top: 30,
        //                width: "74%",
        //                height: "80%"
        //            },

        //            // The font size in pixels - Number
        //            // Or use css selectors as keywords to assign font sizes from the page
        //            // For example: 'body'
        //            // Default: false - Use Google Charts defaults
        //            //fontSize: 'body',

        //            // Font-family name - String
        //            // Default: The body font-family
        //            fontName: 'Roboto',

        //            // Chart Title - String
        //            // Default: Table caption.
        //            title: '',
					
		//			  backgroundColor: '#fff',

        //            titleTextStyle: {

        //                // The font size in pixels - Number
        //                // Or use css selectors as keywords to assign font sizes from the page
        //                // For example: 'body'
        //                // Default: false - Use Google Charts defaults
        //                fontSize: 'h4'
        //            },
        //            legend: {

        //                // Legend position - String
        //                // Options: bottom, top, left, right, in, none.
        //                // Default: bottom
        //                position: 'bottom'
        //            },

        //            // Array of colours
        //            colors: ['#1fc063'],

        //            // Stack values within a bar or column chart - Boolean
        //            // Default: false.
        //            isStacked: false,

        //            tooltip: {

        //                // Shows tooltip with values on hover - String
        //                // Options: focus, none.
        //                // Default: focus
        //                trigger: 'focus'
        //            }
        //        },

        //        // Show table as well as chart - String
        //        // Options: 'show', 'hide', 'remove'
        //        showTable: 'show'
        //    });

        //    //  Pie Chart Example
        //    var chart2 = $('#pieChart').chartinator({

        //        // Custom Options ------------------------------------------------------
        //        // Note: This example appends data from a data array
        //        // to the data extracted from an HTML table
        //        // Google Charts does not support custom tooltips or annotations on Pie Charts

        //        // Append the following rows of data to the data extracted from the table
        //        rows: [
        //            ['France', 5],
        //            ['Mexico', 2]],

        //        // Create Table - String
        //        // Create a basic HTML table or a Google Table Chart from chart data
        //        // Options: false, 'basic-table', 'table-chart'
        //        // Note: This table will replace an existing HTML table
        //        createTable: 'table-chart',

        //        // The data title
        //        // A title used to identify the set of data
        //        // Used as a caption when generating an HTML table
        //        dataTitle: '',

        //        // The chart type - String
        //        // Derived from the Google Charts visualization class name
        //        // Default: 'BarChart'
        //        // Use TitleCase names. eg. BarChart, PieChart, ColumnChart, Calendar, GeoChart, Table.
        //        // See Google Charts Gallery for a complete list of Chart types
        //        // https://developers.google.com/chart/interactive/docs/gallery
        //        chartType: 'PieChart',

        //        // The class to apply to the chart container element
        //        chartClass: 'col',

        //        // The class to apply to the table element
        //        tableClass: 'col-table',

        //        // The chart aspect ratio custom option - width/height
        //        // Used to calculate the chart dimensions relative to the width or height
        //        // this is overridden if the Google Chart's height and width options have values
        //        // Suggested value: 1.25
        //        // Default: false - not used
        //        //chartAspectRatio: 1.25,

        //        // Google Pie Chart Options
        //        pieChart: {

        //            // Width of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            width: null,

        //            // Height of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            height: 300,

        //            chartArea: {
        //                left: "6%",
        //                top: 30,
        //                width: "94%",
        //                height: "100%"
        //            },

        //            // The font size in pixels - Number
        //            // Or use css selectors as keywords to assign font sizes from the page
        //            // For example: 'body'
        //            // Default: false - Use Google Charts defaults
        //            fontSize: 'body',

        //            // The font family name. String
        //            // Default: body font family
        //            fontName: 'Roboto',

        //            // Chart Title - String
        //            // Default: Table caption.
        //            //title: 'Pie Chart',

        //            titleTextStyle: {

        //                // The font size in pixels - Number
        //                // Or use css selectors as keywords to assign font sizes from the page
        //                // For example: 'body'
        //                // Default: false - Use Google Charts defaults
        //                fontSize: 'h4'
        //            },
        //            legend: {

        //                // Legend position - String
        //                // Options: bottom, top, left, right, in, none.
        //                // Default: right
        //                position: 'right'
        //            },

        //            // Array of colours
        //            colors: ['#1ec565', '#23d26d', '#10c05b', '#0db153', '#0b9e49'],

        //            // Make chart 3D - Boolean
        //            // Default: false.
        //            is3D: true,

        //            tooltip: {

        //                // Shows tooltip with values on hover - String
        //                // Options: focus, none.
        //                // Default: focus
        //                trigger: 'focus'
        //            }
        //        },
        //        // Show table as well as chart - String
        //        // Options: 'show', 'hide', 'remove'
        //        showTable: 'show'
        //    });

        //    //  Geo Chart Example
        //    var chart3 = $('#geoChart').chartinator({

        //        // Custom Options ------------------------------------------------------
        //        // Note: This example extracts data from an HTML table
        //        // and replaces the tooltip column in the HTML table with tooltip defined in a js array
        //        // Google Charts does not support custom annotations on Geo Charts

        //        // The jQuery selector of the HTML table element to extract the data from - String
        //        // Default: false
        //        // If unspecified, the element this plugin is applied to must be the HTML table
        //        // or columns and rows arrays must be defined
        //        tableSel: '.geoChart',

        //        // Columns - The columns data-array
        //        columns: [{role: 'tooltip', type: 'string'}],

        //        // Column indexes array - An array of column indexes defining where
        //        // the data will be inserted into any existing data extracted from an HTML table or Google Sheet
        //        // Default: false - js data array columns replace any existing columns
        //        // Note: when inserting more than one column be sure to increment index number
        //        // to account for previously inserted indexes
        //        colIndexes: [2],

        //        // Rows - The rows data-array
        //        // If colIndexes array has values the row data will be inserted into the columns
        //        // defined in the colindexes array. Otherwise the row data will be appended
        //        // to any existing row data extracted from an HTML table or Google Sheet
        //        rows: [
        //            ['China - 2015'],
        //            ['Colombia - 2015'],
        //            ['France - 2015'],
        //            ['Italy - 2015'],
        //            ['Japan - 2015'],
        //            ['Kazakhstan - 2015'],
        //            ['Mexico - 2015'],
        //            ['Poland - 2015'],
        //            ['Russia - 2015'],
        //            ['Spain - 2015'],
        //            ['February - 2015'],
        //            ['January - 2015']],

        //        // Ignore column indexes array - An array of column indexes to ignore
        //        // Default: []
        //        // Note: Only works when extracting data from HTML tables or Google Sheets
        //        ignoreCol: [2],

        //        // The chart type - String
        //        // Derived from the Google Charts visualization class name
        //        // Default: 'BarChart'
        //        // Use TitleCase names. eg. BarChart, PieChart, ColumnChart, Calendar, GeoChart, Table.
        //        // See Google Charts Gallery for a complete list of Chart types
        //        // https://developers.google.com/chart/interactive/docs/gallery
        //        chartType: 'GeoChart',

        //        // The chart aspect ratio custom option - width/height
        //        // Used to calculate the chart dimensions relative to the width or height
        //        // this is overridden if the Google Chart's height and width options have values
        //        // Suggested value: 1.25
        //        // Default: false - not used
        //        chartAspectRatio: 1.5,

        //        // The chart zoom factor - number
        //        // A scaling factor for the chart - uses CSS3 transform
        //        // To prevent tooltips from displaying off canvas while zooming, set tooltip.isHtml: true
        //        // Default: 0
        //        chartZoom: 1.75,

        //        // The chart offset - Array of numbers
        //        // An array of x and y offset percentage values
        //        // Used to offset the chart by percentages of the height and width - uses CSS3 transform
        //        // To prevent tooltips from displaying off canvas while offsetting, set tooltip.isHtml: true
        //        // Default: false
        //        chartOffset: [-12,0],

        //        // The Chart Options
        //        // The Google Chart options - This option can be used with any chart type
        //        chartOptions: {

        //            // Width of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            width: null,

        //            // Height of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            //height: 250,

        //            // The chart title - not a Google Geo Chart option
        //            // This option is supported by Chartinator only
        //            title: 'Geo Chart',

        //            // Background color
        //            // Default: 'white'
        //            backgroundColor: '#fff',

        //            // Color of regions that have no data - String
        //            // Default: '#F5F5F5'
        //            datalessRegionColor: '#F5F5F5',

        //            // Map region - String
        //            // Options: 'world', continent, region, country, states.
        //            // Default: 'world'
        //            region: 'world',

        //            // Resolution - String
        //            // Options: 'countries', 'provinces', 'metros'.
        //            // Default: 'countries'
        //            resolution: 'countries',

        //            // Legend options - Object or string
        //            // Options: Object or 'none'.
        //            // Default: null
        //            legend: 'none',

        //            colorAxis: {

        //                // Start and end colour gradient values - Array
        //                // Default: null
        //                colors: ['#e0e5c8', '#94ac27']
        //            },
        //            tooltip: {

        //                // Show tooltip with values on hover - String
        //                // Options: focus, none. Default: 'focus'
        //                trigger: 'focus',

        //                isHtml: true
        //            }
        //        }

        //        // Show table as well as chart - String
        //        // Options: 'show', 'hide', 'remove'
        //        //showTable: 'show'
        //    });

        //    //  Column Chart Example
        //    var chart4 = $('#columnChart').chartinator({

        //        // Custom Options ------------------------------------------------------
        //        // note: This example uses js data arrays for data instead of HTML tables

        //        // Columns - The columns data-array
        //        columns: [
        //            {label: 'Country', type: 'string'},
        //            {label: '2013', type: 'number'},
        //            {label: '2014', type: 'number'},
        //            {label: '2015', type: 'number'}],

        //        // Rows - The rows data-array
        //        // If colIndexes array has values the row data will be inserted into the columns
        //        // defined in the colindexes array. Otherwise the row data will be appended
        //        // to any existing row data extracted from an HTML table or Google Sheet
        //        rows: [
        //            ['China', 18, 11, 9],
        //            ['Japan', 12, 8, 9],
        //            ['Russia', 10, 9, 7],
        //            ['Mexico', 5, 4, 2],
        //            ['Brazil', 6, 2, 1],
        //            ['Italy', 4, 3, 5]],

        //        // The class to apply to the table element
        //        tableClass: 'col-table',

        //        // Create Table - String
        //        // Create a basic HTML table or a Google Table Chart from chart data
        //        // Options: false, 'basic-table', 'table-chart'
        //        // Note: This table will replace an existing HTML table
        //        createTable: 'basic-table',

        //        // The chart type - String
        //        // Derived from the Google Charts visualization class name
        //        // Default: 'BarChart'
        //        // Use TitleCase names. eg. BarChart, PieChart, ColumnChart, Calendar, GeoChart, Table.
        //        // See Google Charts Gallery for a complete list of Chart types
        //        // https://developers.google.com/chart/interactive/docs/gallery
        //        chartType: 'ColumnChart',

        //        // The data title
        //        // A title used to identify the set of data
        //        // Used as a caption when generating an HTML table
        //        dataTitle: 'Column Chart Data',

        //        // The chart aspect ratio custom option - width/height
        //        // Used to calculate the chart dimensions relative to the width or height
        //        // this is overridden if the Google Chart's height and width options have values
        //        // Suggested value: 1.25
        //        // Default: false - not used
        //        chartAspectRatio: 1.5,

        //        // Google Column Chart Options
        //        columnChart: {

        //            // Width of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            width: null,

        //            // Height of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            //height: 200,

        //            chartArea: {
        //                left: "10%",
        //                top: 30,
        //                width: "90%",
        //                height: "65%"
        //            },

        //            // The font size in pixels - Number
        //            // Or use css selectors as keywords to assign font sizes from the page
        //            // For example: 'body'
        //            // Default: false - Use Google Charts defaults
        //            //fontSize: 'body',

        //            // The font family name - String
        //            // Default: body font family
        //            fontName: 'Roboto',

        //            // Chart Title - String
        //            // Default: Table caption.
        //            title: 'Column Chart',

        //            titleTextStyle: {

        //                // The font size in pixels - Number
        //                // Or use css selectors as keywords to assign font sizes from the page
        //                // For example: 'body'
        //                // Default: false - Use Google Charts defaults
        //                fontSize: 'h4'
        //            },
        //            legend: {

        //                // Legend position - String
        //                // Options: bottom, top, left, right, in, none.
        //                // Default: bottom
        //                position: 'bottom'
        //            },

        //            // Array of colours
        //            colors: ['#a82180', '#dd61b8', '#ff99e1'],

        //            // Stack values within a bar or column chart - Boolean
        //            // Default: false.
        //            isStacked: true,

        //            tooltip: {

        //                // Shows tooltip with values on hover - String
        //                // Options: focus, none.
        //                // Default: focus
        //                trigger: 'focus'
        //            }
        //        },

        //        // Show table as well as chart - String
        //        // Options: 'show', 'hide', 'remove'
        //        showTable: 'show'
        //    });

        //    //  Area Chart Example
        //    var chart5 = $('#areaChart').chartinator({

        //        // Custom Options ------------------------------------------------------
        //        // note: This example uses js data arrays for data instead of HTML tables

        //        // Columns - The columns data-array
        //        columns: [
        //            {label: 'Country', type: 'string'},
        //            {label: '2013', type: 'number'},
        //            {label: '2014', type: 'number'},
        //            {label: '2015', type: 'number'}],

        //        // Rows - The rows data-array
        //        // If colIndexes array has values the row data will be inserted into the columns
        //        // defined in the colindexes array. Otherwise the row data will be appended
        //        // to any existing row data extracted from an HTML table or Google Sheet
        //        rows: [
        //            ['China', 18, 11, 9],
        //            ['Japan', 12, 8, 9],
        //            ['Russia', 10, 9, 7],
        //            ['Mexico', 5, 4, 2],
        //            ['Brazil', 6, 2, 1],
        //            ['Italy', 4, 3, 5]],

        //        // Create Table - String
        //        // Create a basic HTML table or a Google Table Chart from chart data
        //        // Options: false, 'basic-table', 'table-chart'
        //        // Note: This table will replace an existing HTML table
        //        createTable: 'table-chart',

        //        // The data title
        //        // A title used to identify the set of data
        //        // Used as a caption when generating an HTML table
        //        dataTitle: 'Area Chart Data - Table Chart',

        //        // The class to apply to the chart container element
        //        chartClass: 'col',

        //        // The class to apply to the table element
        //        tableClass: 'col-table',

        //        // The chart type - String
        //        // Derived from the Google Charts visualization class name
        //        // Default: 'BarChart'
        //        // Use TitleCase names. eg. BarChart, PieChart, ColumnChart, Calendar, GeoChart, Table.
        //        // See Google Charts Gallery for a complete list of Chart types
        //        // https://developers.google.com/chart/interactive/docs/gallery
        //        chartType: 'AreaChart',

        //        // The chart aspect ratio custom option - width/height
        //        // Used to calculate the chart dimensions relative to the width or height
        //        // this is overridden if the Google Chart's height and width options have values
        //        // Suggested value: 1.25
        //        // Default: false - not used
        //        chartAspectRatio: 1.5,

        //        // Google Area Chart Options
        //        areaChart: {

        //            // Width of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            width: null,

        //            // Height of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            //height: 400,

        //            chartArea: {
        //                left: "10%",
        //                top: 40,
        //                width: "85%",
        //                height: "65%"
        //            },

        //            // The font size in pixels - Number
        //            // Or use css selectors as keywords to assign font sizes from the page
        //            // For example: 'body'
        //            // Default: false - Use Google Charts defaults
        //            //fontSize: 'body',

        //            // The font family name. String
        //            // Default: body font family
        //            fontName: 'Roboto',

        //            // Chart Title - String
        //            // Default: Table caption.
        //            title: 'Area Chart',

        //            titleTextStyle: {

        //                // The font size in pixels - Number
        //                // Or use css selectors as keywords to assign font sizes from the page
        //                // For example: 'body'
        //                // Default: false - Use Google Charts defaults
        //                fontSize: 'h4'
        //            },
        //            legend: {

        //                // Legend position - String
        //                // Options: bottom, top, left, right, in, none.
        //                // Default: bottom
        //                position: 'bottom'
        //            },

        //            // Array of colours
        //            colors: ['#94ac27', '#3691ff', '#bf5cff'],

        //            tooltip: {

        //                // Shows tooltip with values on hover - String
        //                // Options: focus, none.
        //                // Default: focus
        //                trigger: 'focus'
        //            }
        //        },

        //        // Show table as well as chart - String
        //        // Options: 'show', 'hide', 'remove'
        //        showTable: 'show'
        //    });

        //    //  Line Chart Example
        //    var chart6 = $('#lineChart').chartinator({

        //        // Custom Options ------------------------------------------------------
        //        // note: This example uses js data arrays for data instead of HTML tables

        //        // Columns - The columns data-array
        //        columns: [
        //            {label: 'Country', type: 'string'},
        //            {label: '2013', type: 'number'},
        //            {role: 'annotation', type: 'string'},
        //            {label: '2014', type: 'number'},
        //            {role: 'annotation', type: 'string'},
        //            {label: '2015', type: 'number'},
        //            {role: 'annotation', type: 'string'}],

        //        // Rows - The rows data-array
        //        // If colIndexes array has values the row data will be inserted into the columns
        //        // defined in the colindexes array. Otherwise the row data will be appended
        //        // to any existing row data extracted from an HTML table or Google Sheet
        //        rows: [
        //            ['China', 18, '18', 11, '11', 9, '9'],
        //            ['Japan', 12, '12', 8, '8', 9, '9'],
        //            ['Russia', 10, '10', 9, '9', 7, '7'],
        //            ['Mexico', 5, '5', 4, '4', 2, '2'],
        //            ['Brazil', 6, '6', 2, '2', 1, '1'],
        //            ['Italy', 4, '4', 3, '3', 5, '5']],

        //        // The chart type - String
        //        // Derived from the Google Charts visualization class name
        //        // Default: 'BarChart'
        //        // Use TitleCase names. eg. BarChart, PieChart, ColumnChart, Calendar, GeoChart, Table.
        //        // See Google Charts Gallery for a complete list of Chart types
        //        // https://developers.google.com/chart/interactive/docs/gallery
        //        chartType: 'LineChart',

        //        // The chart aspect ratio custom option - width/height
        //        // Used to calculate the chart dimensions relative to the width or height
        //        // this is overridden if the Google Chart's height and width options have values
        //        // Suggested value: 1.25
        //        // Default: false - not used
        //        //chartAspectRatio: 1.25,

        //        // Google Line Chart Options
        //        lineChart: {

        //            // Width of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            width: null,

        //            // Height of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            height: 310,

        //            chartArea: {
        //                left: "10%",
        //                top: 40,
        //                width: "85%",
        //                height: "65%"
        //            },

        //            // The font size in pixels - Number
        //            // Or use css selectors as keywords to assign font sizes from the page
        //            // For example: 'body'
        //            // Default: false - Use Google Charts defaults
        //            //fontSize: 'body',

        //            // The font family name. String
        //            // Default: body font family
        //            fontName: 'Roboto',

        //            // Chart Title - String
        //            // Default: Table caption.
        //            title: 'Line Chart',

        //            titleTextStyle: {

        //                // The font size in pixels - Number
        //                // Or use css selectors as keywords to assign font sizes from the page
        //                // For example: 'body'
        //                // Default: false - Use Google Charts defaults
        //                fontSize: 'h4'
        //            },
        //            legend: {

        //                // Legend position - String
        //                // Options: bottom, top, left, right, in, none.
        //                // Default: bottom
        //                position: 'bottom'
        //            },

        //            // Array of colours
        //            colors: ['#94ac27', '#3691ff', '#bf5cff'],

        //            tooltip: {

        //                // Shows tooltip with values on hover - String
        //                // Options: focus, none.
        //                // Default: focus
        //                trigger: 'focus'
        //            }
        //        }

        //        // Show table as well as chart - String
        //        // Options: 'show', 'hide', 'remove'
        //        //showTable: 'show'
        //    });

        //    //  Table Chart Example
        //    var chart7 = $('#tableChart').chartinator({

        //        // Custom Options ------------------------------------------------------
        //        // Note: this chart type does not display the table caption as a chart heading
        //        // add the chart heading manually.

        //        // The jQuery selector of the HTML table element to extract the data from - String
        //        // Default: false
        //        // If unspecified, the element this plugin is applied to must be the HTML table
        //        // or columns and rows arrays must be defined
        //        tableSel: '.tableChart',

        //        // Ignore column indexes array - An array of column indexes to ignore
        //        // Default: []
        //        // Note: Only works when extracting data from HTML tables or Google Sheets
        //        ignoreCol: [2],

        //        // The chart type - String
        //        // Derived from the Google Charts visualization class name
        //        // Default: 'BarChart'
        //        // Use TitleCase names. eg. BarChart, PieChart, ColumnChart, Calendar, GeoChart, Table.
        //        // See Google Charts Gallery for a complete list of Chart types
        //        // https://developers.google.com/chart/interactive/docs/gallery
        //        chartType: 'Table',

        //        // Google Table Chart Options
        //        table: {

        //            // The table caption - not a Google Charts option for this chart type
        //            // Chartinator option only
        //            title: 'Table Chart',

        //            // The font size in pixels - Number
        //            // Or use css selectors as keywords to assign font sizes from the page
        //            // For example: 'body'
        //            // Not a Google Charts option for this chart type
        //            fontSize: 16,

        //            // The table caption - not a Google Charts option for this chart type
        //            // Chartinator option only
        //            // Default: the body font-family
        //            fontName: 'Roboto',

        //            // Format a data column in a Table Chart
        //            formatter: {

        //                // Formatter type - String
        //                // Options: none, BarFormat
        //                // Default: 'none'
        //                type: 'BarFormat',

        //                // The index number of the column to format - Integer
        //                // Options: 0, 1, 2, etc.
        //                // Default: 1
        //                column: 1,

        //                // Base value number to compare the cell value against - Integer
        //                // Default: 0
        //                base: 0,

        //                // Negative bar color - String
        //                // Options: 'red', 'green', 'blue'.
        //                // Default: 'red'
        //                colorNegative: 'red',

        //                // Positive bar color - String
        //                // Options: 'red', 'green', 'blue'.
        //                // Default: 'red'
        //                colorPositive: 'blue',

        //                // Dark base line when negative values are present - Boolean
        //                // Default value is 'false'
        //                drawZeroLine: false,

        //                // Maximum  bar value - Number
        //                // Default: highest value in table
        //                max: null,

        //                // Minimum bar value - Number
        //                // Default; lowest value in the table
        //                min: 0,

        //                // Show number values - Boolean
        //                // Default: true
        //                showValue: false,

        //                // Width of each bar in pixels - Number
        //                // Default: 100
        //                width: 150
        //            },

        //            // Allow HTML in cells - Boolean
        //            // default: true
        //            allowHtml: true,

        //            // Alternate row styling - Boolean
        //            // Default: true
        //            alternatingRowStyle: true,

        //            // Width of container element in pixels - Number
        //            // Default: automatic (unspecified)
        //            width: null,

        //            // Height of container element in pixels - Number
        //            // Default: automatic (unspecified)
        //            //height: 320,

        //            // Enable paging - String
        //            // Options: 'enable', 'event', 'disable'.
        //            // Default: 'disable'
        //            page: 'disable',

        //            // Rows per page - Integer
        //            // Default 10
        //            pageSize: 10,

        //            // Enable row numbers - Boolean
        //            // Default: false
        //            showRowNumber: false,

        //            // Enable sorting String
        //            // Options: 'enable', 'event', 'disable'.
        //            // Default: 'enable'
        //            sort: 'enable',

        //            // Sort Ascending - Boolean
        //            // Default: true
        //            sortAscending: false,

        //            // The index of a column to sort - Integer
        //            // Default: -1
        //            sortColumn: 1,

        //            // CSS class names - Default: no classes
        //            cssClassNames: {
        //                headerRow: 'headerRow',
        //                tableRow: 'tableRow',
        //                oddTableRow: 'oddTableRow',
        //                selectedTableRow: 'selectedTableRow',
        //                hoverTableRow: 'hoverTableRow',
        //                headerCell: 'headerCell',
        //                tableCell: 'tableCell',
        //                rowNumberCell: 'rowNumberCell'
        //            }
        //        }

        //        // Show table as well as chart - String
        //        // Options: 'show', 'hide', 'remove'
        //        //showTable: 'show'
        //    });

        //    // Calendar example
        //    var chart8 = $('#myDates').chartinator({

        //        // Custom Options ------------------------------------------------------

        //        // The chart type - String
        //        // Derived from the Google Charts visualization class name
        //        // Default: 'BarChart'
        //        // Use TitleCase names. eg. BarChart, PieChart, ColumnChart, Calendar, GeoChart, Table.
        //        // See Google Charts Gallery for a complete list of Chart types
        //        // https://developers.google.com/chart/interactive/docs/gallery
        //        chartType: 'Calendar',

        //        // The chart aspect ratio custom option - width/height
        //        // Used to calculate the chart dimensions relative to the width or height
        //        // this is overridden if the Google Chart's height and width options have values
        //        // Suggested value: 4
        //        // Default: false - not used
        //        chartAspectRatio: 4,

        //        // Google Calendar Chart Options
        //        calendar: {

        //            // The cell scaling factor custom option - Not a Google Chart option
        //            // Used to refactor the cell size in responsive designs
        //            // this is overridden if the calendar.cellSize option has a value
        //            cellScaleFactor: 0.017,

        //            // Width of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            //width: null,

        //            // Height of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            //height: 200,

        //            titleTextStyle: {
        //            // Note: Support for this option has been added by Chartinator
        //            // but is not supported by Google Charts for this chart type

        //                color: '#000',
        //                fontWeight: 'bold',
        //                fontName: 'Roboto', // Default is body font-family

        //                // The font size in pixels - Number
        //                // Or use css selectors as keywords to assign font sizes from the page
        //                // For example: 'body'
        //                // Default: '' - Use Google Charts defaults
        //                fontSize: 'h4'
        //            },

        //            // Chart Title - String
        //            // Default: Table caption.
        //            title: 'Calendar Chart',

        //            calendar: {

        //                // Cell size in pixels - Number
        //                // Default: 16
        //                // Overrides the cellScaleFactor
        //                // cellSize: 14,

        //                monthLabel: {

        //                    // The font size in pixels - Number
        //                    // Or use css selectors as keywords to assign font sizes from the page
        //                    // For example: 'body'
        //                    // Default: false - Use Google Charts defaults
        //                    //fontSize: 12,

        //                    // The font family name. String
        //                    // Default: body font family
        //                    fontName: 'Roboto'

        //                },
        //                dayOfWeekLabel: {

        //                    // The font size in pixels - Number
        //                    // Or use css selectors as keywords to assign font sizes from the page
        //                    // For example: 'body'
        //                    // Default: false - Use Google Charts defaults
        //                    //fontSize: 12,

        //                    // The font family name. String
        //                    // Default: body font family
        //                    fontName: 'Roboto'
        //                },
        //                monthOutlineColor: {

        //                    // Outline color - String
        //                    // Default '#000'
        //                    stroke: '#bbbbbb'
        //                }
        //            },
        //            colorAxis: {

        //                // The colour gradient start and end values
        //                colors: ['ff9de2', '#a82180']
        //            },
        //            tooltip: {
        //                // Note: Support for this option has been added by Chartinator
        //                // but is not supported by Google Charts for this chart type
        //                textStyle: {
        //                    fontName: 'Roboto', // Default: body font-family
        //                    fontSize: 14 // Default: 16
        //                }
        //            }
        //        }

        //    });

        //    //  Bubble Chart Example
        //    var chart9 = $('#bubbleChart').chartinator({

        //        // Custom Options ------------------------------------------------------
        //        // note: This example uses js data arrays for data instead of HTML tables

        //        // Columns - The columns data-array
        //        // Note: In this example the data types are not defined but are inferred by Google Charts
        //        columns: ['Module', 'Attendance rate', 'Average Grade', 'Course', 'Number of Students'],

        //        // Rows - The rows data-array
        //        // If colIndexes array has values, the row data will be inserted into the columns
        //        // defined in the colIndexes array. Otherwise the row data will be appended
        //        // to any existing row data extracted from an HTML table or Google Sheet
        //        rows: [
        //            ['HTML', .90, .75, 'Front-End Dev', 22],
        //            ['CSS', .88, .82, 'Front-End Dev', 25],
        //            ['JS', .92, .78, 'Front-End Dev', 21],
        //            ['PHP', .95, .75, 'Back-End Dev', 28],
        //            ['Node', .88, .73, 'Back-End Dev', 20],
        //            ['UX', .91, .85, 'Design', 20],
        //            ['UI', .85, .75, 'Design', 26]
        //        ],

        //        // The chart type - String
        //        // Derived from the Google Charts visualization class name
        //        // Default: 'BarChart'
        //        // Use TitleCase names. eg. BarChart, PieChart, ColumnChart, Calendar, GeoChart, Table.
        //        // See Google Charts Gallery for a complete list of Chart types
        //        // https://developers.google.com/chart/interactive/docs/gallery
        //        chartType: 'BubbleChart',

        //        // The chart aspect ratio custom option - width/height
        //        // Used to calculate the chart dimensions relative to the width or height
        //        // this is overridden if the Google Chart's height and width options have values
        //        // Suggested value: 1.25
        //        // Default: false - not used
        //        chartAspectRatio: 1.5,

        //        // Google Bubble Chart Options
        //        chartOptions: {
        //            // Note: This chart type does not have any Chartinator defined defaults
        //            // All Google Charts options use Google Charts defaults except where noted

        //            // Width of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            width: null,

        //            // Height of chart in pixels - Number
        //            // Default: automatic (unspecified)
        //            //height: 400,

        //            chartArea: {
        //                left: "10%",
        //                top: 40,
        //                width: "85%",
        //                height: "65%"
        //            },

        //            // The font size in pixels - Number
        //            // Or use css selectors as keywords to assign font sizes from the page
        //            // For example: 'body'
        //            // Default: Use Google Charts defaults
        //            //fontSize: 'body',

        //            // Font-family name - String
        //            fontName: 'Roboto',

        //            // Chart Title - String
        //            // Default: Table caption.
        //            title: 'Bubble Chart',

        //            // Format the horizontal axis as %
        //            hAxis: {
        //                title: 'Attendance Rate',
        //                format:'#%'},

        //            // Format the vertical axis as %
        //            vAxis: {
        //                title: 'Average Grade',
        //                format:'#%'},

        //            titleTextStyle: {

        //                // The font size in pixels - Number
        //                // Or use css selectors as keywords to assign font sizes from the page
        //                // For example: 'body'
        //                // Default: Use Google Charts defaults
        //                fontSize: 'h4'
        //            },
        //            legend: {

        //                // Legend position - String
        //                // Options: bottom, top, left, right, in, none.
        //                position: 'bottom'
        //            },

        //            // Array of colours
        //            colors: ['#94ac27', '#3691ff', '#bf5cff'],

        //            tooltip: {

        //                // Shows tooltip with values on hover - String
        //                // Options: focus, none.
        //                trigger: 'focus'
        //            }
        //        }

        //        // Show table as well as chart - String
        //        // Options: 'show', 'hide', 'remove'
        //        //showTable: 'show'
        //    });

        });
		
		
		$('.collapse').on('shown.bs.collapse', function(){
$(this).parent().find(".fa-chevron-down").removeClass("fa-chevron-down").addClass("fa-chevron-up");
}).on('hidden.bs.collapse', function(){
$(this).parent().find(".fa-chevron-up").removeClass("fa-chevron-up").addClass("fa-chevron-down");
});


//lightbox plugin

$(document).ready(function ($) {

				// delegate calls to data-toggle="lightbox"
				$(document).delegate('*[data-toggle="lightbox"]:not([data-gallery="navigateTo"])', 'click', function(event) {
					event.preventDefault();
					return $(this).ekkoLightbox({
						onShown: function() {
							if (window.console) {
								return console.log('Checking our the events huh?');
							}
						},
						onNavigate: function(direction, itemIndex) {
							if (window.console) {
								return console.log('Navigating '+direction+'. Current item: '+itemIndex);
							}
						}
					});
				});

				//Programatically call
				$('#open-image').click(function (e) {
					e.preventDefault();
					$(this).ekkoLightbox();
				});
				$('#open-youtube').click(function (e) {
					e.preventDefault();
					$(this).ekkoLightbox();
				});

				$(document).delegate('*[data-gallery="navigateTo"]', 'click', function(event) {
					event.preventDefault();
					return $(this).ekkoLightbox({
						onShown: function() {
							var a = this.modal_content.find('.modal-footer a');
							if(a.length > 0) {
								a.click(function(e) {
									e.preventDefault();
									this.navigateTo(2);
								}.bind(this));
							}
						}
					});
				});

			});
			
			
			