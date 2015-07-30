using System;
using System.Web.Mvc;
using PropznetCommon.Features.CRM.ElasticSearch;
using PropznetCommon.Features.CRM.Interfaces.Services;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class SearchController : BaseUIController
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
                try
                {
                    var searchResult = _elasticSearchService.GetElasticSearch(searchvalue);
                    return View(searchResult);
                }
                catch (Exception ex)
                {
                    return RedirectHappenedUnexpected();
                }
               
            });
        }
    }
}