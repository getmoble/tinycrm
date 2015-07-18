using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Infrastructure;
using System.Web.Mvc;
using LOG.PropznetCRM.Data.ElasticSearch;

namespace LOG.PropznetCRM.Data.UI.Controllers
{
    public class SearchController : CRMBaseController
    {
        readonly ElasticSearchService _elasticSearchService;
        public SearchController(IElasticSearchSettings elasticsearchsettings)
        {
            _elasticSearchService = _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
        }
        public ActionResult Index(string searchvalue)
        {
            return RedirectIfNotLoggedIn(() =>
            {
                var searchResult = _elasticSearchService.GetElasticSearch(searchvalue);
                return View(searchResult);
            });
        }
    }
}