using PropznetCommon.Features.CRM.Interfaces.Services;
using CRMLite.Infrastructure;

namespace CRMLite.UI
{
    public class ElasticSearchSettings : IElasticSearchSettings
    {
        static string _elasticSearchUrl;
        static string _defaultIndex;
        public static void SetElasticSearchSettings(string elasticSearchUrl, string defaultIndex)
        {
            _elasticSearchUrl = elasticSearchUrl;
            _defaultIndex = defaultIndex;
        }
        public string ElasticSearchUrl()
        {
            return _elasticSearchUrl;
        }
        public string GetDefaultIndex()
        {
            return _defaultIndex;
        }
    }
}