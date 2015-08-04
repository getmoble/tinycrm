ko.observableArray.fn.pushAll = function (valuesToPush) {
    var underlyingArray = this();
    this.valueWillMutate();
    ko.utils.arrayPushAll(underlyingArray, valuesToPush);
    this.valueHasMutated();
    return this;  //optional
};

ko.validation.init({ insertMessages: true, decorateElement: true });


ko.bindingHandlers.loading = {
    init: function (element) {
        var $element = $(element), currentPosition = $element.css("position");
        $loader = $("<div>").addClass("loader").hide();

        //add the loader
        $element.append($loader);

        //make sure that we can absolutely position the loader against the original element
        if (currentPosition == "auto" || currentPosition == "static")
            $element.css("position", "relative");

        //center the loader
        $loader.css({
            position: "absolute",
            top: "80%",
            left: "50%",
            "margin-left": -($loader.width() / 2) + "px",
            //"margin-top": -($loader.height()/2) + "px"
            "margin-top": "80px"
        });
    },
    update: function (element, valueAccessor) {
        var isLoading = ko.utils.unwrapObservable(valueAccessor()),
            $element = $(element),
            $childrenToHide = $element.children(":not(div.loader)"),
            $loader = $element.find("div.loader");
        var currentOpacity = $element.css("opacity");
        if (isLoading) {
            $element.fadeTo('slow', .6);
            $element.append('<div class="childDiv" style="position: absolute;top:0;left:0;width: 100%;height:100%;z-index:2;opacity:0.4;filter: alpha(opacity = 50)"></div>');
            $loader.show();
        }
        else {
            $element.fadeTo("fast", 1);
            $loader.fadeOut("fast");
            $('.childDiv').remove();
        }
    }
};

ko.bindingHandlers.arcLoader = {
    init: function (element) {
        var $element = $(element), currentPosition = $element.css("position");
        $arc = $("<div>").addClass("arc").hide();

        //add the arc
        $element.append($arc);

        //make sure that we can absolutely position the arc against the original element
        if (currentPosition === "auto" || currentPosition == "static")
            $element.css("position", "relative");

        //center the arc
        $arc.css({
            position: "absolute",
            top: "80%",
            left: "50%",
            "margin-left": -($arc.width() / 2) + "px",
            //"margin-top": -($arc.height()/2) + "px"
            "margin-top": "20px"
        });
    },
    update: function (element, valueAccessor) {
        var isArc = ko.utils.unwrapObservable(valueAccessor()),
            $element = $(element),
            $arc = $element.find("div.arc");
        if (isArc) {
            $element.fadeTo('slow', .6);
            $element.append('<div class="childDiv" style="position: absolute;top:0;left:0;width: 100%;height:100%;z-index:2;opacity:0.4;filter: alpha(opacity = 50)"></div>');
            $arc.show();
        }
        else {
            $element.fadeTo("fast", 1);
            $arc.fadeOut("fast");
            $('.childDiv').remove();
        }
    }
};


ko.bindingHandlers.datepicker = {

    init: function (element, valueAccessor, allBindingsAccessor) {

        //initialize datepicker with some optional options

        var options = allBindingsAccessor().datepickerOptions || {},

        $el = $(element);

        $el.datepicker(options);

        //handle the field changing by registering datepicker's changeDate event

        ko.utils.registerEventHandler(element, "changeDate", function () {

            var observable = valueAccessor();
            //alert($el.datepicker("getDate"))
            observable($el.datepicker("getDate"));

        });

        //handle disposal (if KO removes by the template binding)

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {

            $el.datepicker("destroy");

        });

    },

    update: function (element, valueAccessor) {

        var value = ko.utils.unwrapObservable(valueAccessor());

        //handle date data coming via json from Microsoft

        if (String(value).indexOf('/Date(') == 0) {

            value = new Date(parseInt(value.replace(/\/Date\((.*?)\)\//gi, "$1")));

        }

    }

};

ko.bindingHandlers.loadingWhen = {
    init: function (element) {
        var
            $element = $(element),
            currentPosition = $element.css("position")
        $loader = $("<div>").addClass("loader").hide();

        //add the loader
        $element.append($loader);

        //make sure that we can absolutely position the loader against the original element
        if (currentPosition == "auto" || currentPosition == "static")
            $element.css("position", "relative");

        //center the loader
        $loader.css({
            position: "absolute",
            top: "50%",
            left: "50%",
            "margin-left": -($loader.width() / 2) + "px",
            "margin-top": -($loader.height() / 2) + "px"
        });
    },
    update: function (element, valueAccessor) {
        var isLoading = ko.utils.unwrapObservable(valueAccessor()),
            $element = $(element),
            $childrenToHide = $element.children(":not(div.loader)"),
            $loader = $element.find("div.loader");

        if (isLoading) {
            $childrenToHide.css("visibility", "hidden").attr("disabled", "disabled");
            $loader.show();
        }
        else {
            $loader.fadeOut("fast");
            $childrenToHide.css("visibility", "visible").removeAttr("disabled");
        }
    }
};



ko.bindingHandlers.animatedIf = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var value = valueAccessor();
        if (value())
            $(element).show("fast");
        else {
            $(element).hide("fast");
        }
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var value = valueAccessor();
        if (value())
            $(element).slideDown("fast");
        else {
            $(element).slideUp("fast");
        }
    }
};

ko.bindingHandlers.timeago = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var $this = $(element);
        var value = ko.utils.unwrapObservable(valueAccessor());
        $this.livestamp(value);
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        
    }
};
ko.bindingHandlers.richText = {
    init: function(element, valueAccessor, allBindingsAccessor, viewModel) {

        var txtBoxID = $(element).attr("id");

        var options = allBindingsAccessor().richTextOptions || {};

        options.toolbar_Full = [
            ['Source', '-', 'Format', 'Font', 'FontSize', 'TextColor', 'BGColor', '-', 'Bold', 'Italic', 'Underline', 'SpellChecker'],
            ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'],
            ['Link', 'Unlink', 'Image', 'Table']
        ];

        //handle disposal (if KO removes by the template binding)

        ko.utils.domNodeDisposal.addDisposeCallback(element, function() {

            if (CKEDITOR.instances[txtBoxID]) {
                CKEDITOR.remove(CKEDITOR.instances[txtBoxID]);
            }
            ;

        });

        $(element).ckeditor(options);

        //wire up the blur event to ensure our observable is properly updated

        CKEDITOR.instances[txtBoxID].focusManager.blur = function() {

            var observable = valueAccessor();

            observable($(element).val());

        };
    },

    update: function(element, valueAccessor, allBindingsAccessor, viewModel) {

        var val = ko.utils.unwrapObservable(valueAccessor());

        $(element).val(val);
    }
};

/*Date picker value binder for knockout*/
//ko.bindingHandlers.datepicker = {
//    init: function (element, valueAccessor, allBindingsAccessor) {
//        var options = allBindingsAccessor().datepickerOptions || {};
//        $(element).datepicker(options).on("changeDate", function (ev) {
//            var observable = valueAccessor();
//            observable(ev.date);
//        });
//    },
//    update: function (element, valueAccessor) {
//        var value = ko.utils.unwrapObservable(valueAccessor());
//        $(element).datepicker("setValue", value);
//    }
//};
ko.extenders.mask = function(observable, mask) {
    observable.mask = mask;
    return observable;
};

ko.bindingHandlers.numericOnly = {
    init: function (element, valueAccessor, allBindings) {
        ko.utils.registerEventHandler(element, "keypress", function (event) {
            if (event.which == 47 || (event.which < 46 && event.which != 8 && event.which != 0) || event.which > 57) {
                return false;
            }
        });
    }
};
ko.bindingHandlers.integerOnly = {
    init: function (element, valueAccessor, allBindings) {
        ko.utils.registerEventHandler(element, "keypress", function (event) {
            if (event.which == 47 || (event.which <= 46 && event.which != 8 && event.which != 0) || event.which > 57) {
                return false;
            }
        });
    }
};


ko.bindingHandlers.selectTextFromTextBox = {
    init: function (element, valueAccessor, allBindings) {
        ko.utils.registerEventHandler(element, "click", function (event) {
            element.select();
        });
        return true;
    }
};
//ko.bindingHandlers.maskDateTimePicker = {
//    init: function (element, valueAccessor, allBindings) {
//       $(element).datetimepicker({
//           mask: '39/19/9999',
//           format: 'm/d/Y',
//           defaultDate: new Date(),
//           timepicker:false,
//        });
//        return true;
//    }
//};

ko.extenders.numericType = function (target, precision) {
    //create a writeable computed observable to intercept writes to our observable
    var result = ko.computed({
        read: target,  //always return the original observables value
        write: function (newValue) {
            var current = target(),
                roundingMultiplier = Math.pow(10, precision),
                newValueAsNum = isNaN(newValue) ? 0 : parseFloat(+newValue),
                valueToWrite = Math.round(newValueAsNum * roundingMultiplier) / roundingMultiplier;

            //only write if it changed
            if (valueToWrite !== current) {
                target(valueToWrite);
            } else {
                //if the rounded value is the same, but a different value was written, force a notification for the current field
                if (newValue !== current) {
                    target.notifySubscribers(valueToWrite);
                }
            }
        }
    }).extend({ notify: 'always' });

    //initialize with current value to make sure it is rounded appropriately
    result(target());

    //return the new computed observable
    return result;
};
ko.validation.rules['duplicate'] = {
    validator: function (item, array) {
        alert(array.length);
            return array.indexOf(item) == -1;
    },
    message: 'Value already exists!'
};
ko.validation.registerExtenders();

ko.validation.rules['equalOrGreater'] = {
    validator: function (val, otherVal) {
        return val >= otherVal;
    },
    message: 'Amount need equal or greater than {0}!'
};
ko.validation.registerExtenders();

ko.validation.rules['mustEqual'] = {
    validator: function (val, otherVal) {
        return val === otherVal();
    },
    message: 'Password does not match!'
};
ko.validation.registerExtenders();

ko.protectedObservable = function (initialValue) {
    var _actualValue = ko.observable(initialValue);
    var _tempValue = ko.observable(initialValue);

    //computed observable that we will return
    var result = ko.computed({
        //always return the actual value
        read: function () {
            return _actualValue();
        },
        //stored in a temporary spot until commit
        write: function (newValue) {
            _tempValue(newValue);
        }
    });

    result.peek = function() {
        return _tempValue;
    };

    //if different, commit temp value
    result.commit = function () {
        if (_tempValue !== _actualValue()) {
            _actualValue(_tempValue());
        }
    };

    //force subscribers to take original
    result.reset = function () {
        _actualValue.valueHasMutated();
        _tempValue(_actualValue());   //reset temp value
    };

    return result;
};

ko.bindingHandlers.bootstrapSwitch = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        //initialize bootstrapSwitch
        $(element).bootstrapSwitch();
        // setting initial value
        $(element).bootstrapSwitch('state', valueAccessor());

        //handle the field changing
        $(element).on('switchChange.bootstrapSwitch', function (event, state) {
            var observableOne = valueAccessor();

            observableOne(state);

        });  

        // Adding component options
        var options = allBindingsAccessor().bootstrapSwitchOptions || {};
        for (var property in options) {
            $(element).bootstrapSwitch(property, ko.utils.unwrapObservable(options[property]));
        }

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).bootstrapSwitch("destroy");
        });

    },
    //update the control when the view model changes
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        // Adding component options
        var options = allBindingsAccessor().bootstrapSwitchOptions || {};
        for (var property in options) {
            $(element).bootstrapSwitch(property, ko.utils.unwrapObservable(options[property]));
        }
        $(element).bootstrapSwitch("state", value);
    }
};
ko.bindingHandlers.ladda = {
    init: function (element, valueAccessor) {
        var l = Ladda.create(element);

        ko.computed({
            read: function () {
                var state = ko.unwrap(valueAccessor());
                if (state) {
                    l.start();
                }
                else
                    l.stop();
            },
            disposeWhenNodeIsRemoved: element
        });
    }
};
// its use for subscribe function change stop(infinite function call stop)
ko.observable.fn.withPausing = function() {
    this.notifySubscribers = function() {
       if (!this.pauseNotifications) {
          ko.subscribable.fn.notifySubscribers.apply(this, arguments);
       }
    };

    this.sneakyUpdate = function(newValue) {
        this.pauseNotifications = true;
        this(newValue);
        this.pauseNotifications = false;
    };

    return this;
};

//knockout pagination
(function (window, ko, undefined) {
    "use strict";

    window.Utils = window.Utils || {};

    ko.pagedList = window.Utils.pagedList = function (options) {
        if (!options) { throw "Options not specified"; }
        if (!options.loadPage) { throw "loadPage not specified on options"; }

        var //page size
			_pageSize = ko.observable(options.pageSize || 10),

			//current page index
			_pageIndex = ko.observable(0),

			//the total number of rows, defaulting to -1 indicating unknown
			_totalRows = ko.observable(-1),

			//observable containing current page data.  Using observable instead of observableArray as
			//all this will do is present data
			_page = ko.observable([]),

			//load a page of data, then display it
			_loadPage = window.Utils.command(function (pageIndex) {
			    var promise = options.loadPage(pageIndex, _pageSize());
			    if (!promise.pipe) { throw "loadPage should return a promise"; }

			    return promise.pipe(_displayPage).done(function () {
			        _pageIndex(pageIndex);
			    });
			}),

			//display a page of data
			_displayPage = function (result) {
			    if (!result) { throw "No page results"; }
			    if (!result.rows) { throw "Result should contain rows array"; }

			    if (options.map) {
			        _page($.map(result.rows, options.map));
			    } else {
			        _page(result.rows);
			    }

			    //save the total row count if it was returned
			    if (result.totalRows) {
			        _totalRows(result.totalRows);
			    }

			    return result;
			},

			//the number of pages
			_pageCount = ko.computed(function () {
			    if (_totalRows() === -1) { return -1; }

			    return Math.ceil(_totalRows() / _pageSize()) || 1;
			}),

			//command to move to the next page
			_nextPage = function () {
			    var currentIndex = _pageIndex(),
					pageCount = _pageCount();
			    if (pageCount === -1 || currentIndex < (pageCount - 1)) {
			        _loadPage(currentIndex + 1);
			    }
			},

			//command to move to the previous page
			_previousPage = function () {
			    var targetIndex = _pageIndex() - 1;
			    if (targetIndex >= 0) {
			        _loadPage(targetIndex);
			    }
			};

        //reset page index when page size changes
        _pageSize.subscribe(function () {
            _loadPage(0);
        });

        //populate with default data if specified
        if (options.firstPage) {
            _displayPage(options.firstPage);
        } else {
            _loadPage(0);
        }

        //public members
        _page.pageSize = _pageSize;
        _page.pageIndex = _pageIndex;
        _page.pageCount = _pageCount;
        _page.totalRows = _totalRows;
        _page.nextPage = _nextPage;
        _page.previousPage = _previousPage;
        _page.loadPage = _loadPage;

        return _page;
    };
}(window, ko));





