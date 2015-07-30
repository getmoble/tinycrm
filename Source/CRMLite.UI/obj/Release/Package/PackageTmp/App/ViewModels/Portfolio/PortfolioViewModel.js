function PortfolioViewModel() {
    var that = this;
    that.url = urls.ERP;
    that.busy = ko.observable();
    that.data = ko.observableArray();
    that.modelState = ko.validatedObservable();
    that.isValid = function () {
        return that.modelState.isValid();
    };
    that.showErrors = function () {

        that.modelState.errors.showAllMessages(true);
    };
    that.Id = ko.observable();
    that.name = ko.observable().extend({ required: { params: true, message: "Please Enter Name" } });
    that.usageType = ko.observable();
    that.description = ko.observable();
    that.query = ko.observable('');
    that.isBusy = ko.observable(false);
    that.portfolioLists = ko.observableArray();
    that.getPortfolios = ko.observableArray();
    that.portfolios = ko.observableArray();
    that.portfolioTypes = ko.observableArray();
    that.ownerLists = ko.observableArray();
    that.owners = ko.observableArray();
    that.ownersId = ko.observableArray();
    that.tempownersId = ko.observableArray();
    that.modelState = ko.validatedObservable(
   {
       name: that.name,
       usageType: that.usageType
   });
    that.portfolioLists = ko.computed(function () {
        var search = that.query().toLowerCase();
        if (!search) {
            return that.getPortfolios();
        }
        else {
            return ko.utils.arrayFilter(that.getPortfolios(), function (item) {
                return (item.PortfolioName().toLowerCase().indexOf(search) >= 0 || item.PortfolioType().toLowerCase().indexOf(search) >= 0);
            });
        }

    });
    that.init = function () {
        var portfolioresult = propznetSuite.dataManager.getData(ko.toJS(that.url.portfolioManageInit));
        portfolioresult.done(function (data) {
            $.each(data.PropertyCategory, function (k, v) {
                that.portfolioTypes.push(v);
            });
        });
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.ownerManageGetAllOwners));
        result.done(function (data) {
            $.each(data.Owners, function (k, v) {
                that.ownerLists.push(new Owner(v));
            });
            $("#pagination").DataTable({
                responsive: true,
                "order": [[3, "desc"]]
            });
            var oTable = $('#pagination').dataTable();
        });
    };
    that.getLists = function () {
        that.isBusy(true);
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.portfolioManageGetAllPortfolios));
        result.done(function (data) {
            $.each(data.Portfolios, function (k, v) {
                that.getPortfolios.push(new Portfolio(v));
            });
            that.isBusy(false);
        });
    };
    that.addOwners = function () {
        that.owners.removeAll();
        that.ownersId.removeAll();
        $.each(that.ownerLists(), function (k, v) {
            if (v.IsSelect() === true) {
                that.owners.push(v);
                that.ownersId.push(v.Id());
            }
        });
    };
    that.editaddOwners = function () {       
        var tmp = [];            
            ko.utils.arrayForEach(that.owners(), function (val) {
                  tmp.push(val.Id());
               });           
            ko.utils.arrayForEach(that.ownerLists(), function (item) {
                if(item.IsSelect())
                {                  
                    if ((tmp.indexOf(item.Id()) == -1))
                    {
                        that.owners.push(item);
                        that.ownersId.push(item.Id());
                    }                  
                }
            });
    };
    that.removeOwner = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Owner " + item.FirstName(), function (result) {
            if (result) {            
                that.owners.remove(item);
                that.ownersId.remove(item.Id());
            }          
        });

    };
    that.addPortfolios = function () {
        if (that.modelState.isValid())
        {
            that.isBusy(true);
            that.busy(true);
                var portfoliosJson = {
                    Name: ko.toJS(that.name), OwnersId: ko.toJS(that.ownersId), UsageType: ko.toJS(that.usageType), Description: ko.toJS(that.description)
                };
                var result = propznetSuite.dataManager.postData(ko.toJS(that.url.portfolioManageCreatePortfolio), portfoliosJson);
                result.done(function (data) {
                   
                    that.isBusy(false);
                    that.busy(false);
                    if (data) {
                        window.location.href = ko.toJS(that.url.portfolioList);
                    }
                    else {
                        toastr["info"]("Portfolio Already Exists !! ", "Notification");
                    }
                });
        }
        else {
            that.modelState.errors.showAllMessages();
        }
    };
    that.gotoAddPortfolioPage = function () {
        window.location.href = ko.toJS(that.url.portfolioCreate);
    };
    that.getEditPage = function (item) {
        window.location.href = ko.toJS(that.url.portfolioEdit) + item.Id();
    };
    that.editPortfolio = function () {
        that.isBusy(true);
        that.busy(true);
        var portfolioIdValue = $("#hdnportfolioId").data('value');
        var result = propznetSuite.dataManager.getData(ko.toJS(that.url.portfolioManageEditPortfolio) + portfolioIdValue);
        result.done(function (data) {
            that.isBusy(false);
            that.busy(false);
                that.Id(data.Portfolio.Id);
                that.name(data.Portfolio.Name);
                that.usageType(data.Portfolio.UsageType);
                that.description(data.Portfolio.Description);

            $.each(data.PortfolioOwners, function (k, v) {
                that.owners.push(new Owner(v));
                that.ownersId.push(v.Id);
            });
        });
    };
    that.updatePortfolio = function () {
        if (that.modelState.isValid()) {
            that.isBusy(true);
            that.busy(true);
            var portfoliosJson = {
                Id:ko.toJS(that.Id),Name: ko.toJS(that.name), OwnersId: ko.toJS(that.ownersId), UsageType: ko.toJS(that.usageType), Description: ko.toJS(that.description)
            };
            var result = propznetSuite.dataManager.postData(ko.toJS(that.url.portfolioManageUpdatePortfolio), portfoliosJson);
            result.done(function (data) {
                that.isBusy(false);
                that.busy(false);
                if (data) {
                    window.location.href = ko.toJS(that.url.portfolioList);
                    toastr["info"]("Updated Successfully ", "Notification");
                }
                else {
                }
            });
        }
        else {
            that.selectedOwner().showErrors();
            that.locationShowErrors();
        }
    };
    that.removePortfolio = function (item) {
        bootbox.confirm("Warning! Are You Sure You Want to delete this Portfolio " + item.PortfolioName(), function (result) {
            if (result) {
                var result = propznetSuite.dataManager.postData(ko.toJS(that.url.portfolioManageDeletePortfolio) + item.Id());
                result.done(function (data) {
                    that.getPortfolios.remove(item);
                });
            }
        });

    };
}