namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IElasticSearchSettings
    {
        string ElasticSearchUrl();
        string GetDefaultIndex();
    }
}