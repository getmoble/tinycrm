using System.Configuration;

namespace CRMLite.Infrastructure
{
    public class AppConfigaration
    {
        public static string ElasticSearchUrl()
        {
            var elasticsearchurl = ConfigurationManager.AppSettings["elasticSearchUrl"];
            return elasticsearchurl;
        }
        public static string GetDefaultIndex()
        {
            string defaultIndex = ConfigurationManager.AppSettings["defaultIndex"];
            return defaultIndex;
        }
        public static string GetPotentialPrefix()
        {
            string potentialPrefix = ConfigurationManager.AppSettings["potentialprefix"];
            return potentialPrefix;
        }
        public static string GetLeadPrefix()
        {
            string leadPrefix = ConfigurationManager.AppSettings["leadprefix"];
            return leadPrefix;
        }
        public static string GetMaxInvalidPasswordAttempts()
        {
            string maxinvalidpasswordattempts = ConfigurationManager.AppSettings["maxinvalidpasswordattempts"];
            return maxinvalidpasswordattempts;
        }
        public static string GetFromAddress()
        {
            string fromAddress = ConfigurationManager.AppSettings["fromAddress"];
            return fromAddress;
        }

        public static string GetAppName()
        {
            var appname = ConfigurationManager.AppSettings["AppName"];
            return appname;
        }
        public static string GetExceptionMode()
        {
            var appname = ConfigurationManager.AppSettings["ExceptionMode"];
            return appname;
        }
    }
}