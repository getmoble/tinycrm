using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Infrastructure;

namespace LOG.PropznetCRM.Data.UI
{
    public class ElasticSearchSettings : IElasticSearchSettings
    {
        public string ElasticSearchUrl()
        {
            return AppConfigaration.ElasticSearchUrl();
        }
        public string GetDefaultIndex()
        {
            return AppConfigaration.GetDefaultIndex();
        }
    }
}