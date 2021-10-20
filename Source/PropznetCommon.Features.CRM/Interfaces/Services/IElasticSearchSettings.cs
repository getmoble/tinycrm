namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IElasticSearchSettings
    {
        string ElasticSearchUrl();
        string GetDefaultIndex();
    }
}