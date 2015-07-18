using System;

namespace LOG.PropznetCRM.Data.Infrastructure
{
    public static class ImageUrlResolver
    {
        const string agenturl = "/Upload/Agent/";
        public static string ResolveUrl(string urlfilename)
        {
            string sbUrl;
            if (String.IsNullOrEmpty(urlfilename))
            {
                sbUrl = agenturl + "Person-Dummy.jpg";
            }
            else
            {
                sbUrl = agenturl + urlfilename;
            }

            return sbUrl;
        }

        public static string ThumbNail()
        {
            const string sbUrl = "/Upload/Logo/";
            return sbUrl;
        }
    }
}
