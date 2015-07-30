
function Portfolio(portfolio) {
    var that = this;
    that.Id = ko.observable(portfolio.Id);
    that.PortfolioName = ko.observable(portfolio.Name);
    that.PortfolioType = ko.observable();
    that.Description = ko.observable(portfolio.Description);
    if (ko.toJS(portfolio.UsageType) == '0')
        that.PortfolioType('Residential');
    if (ko.toJS(portfolio.UsageType) == '1')
        that.PortfolioType('Commercial');
}
