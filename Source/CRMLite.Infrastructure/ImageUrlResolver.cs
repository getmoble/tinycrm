using System;

namespace CRMLite.Infrastructure
{
    public static class ImageUrlResolver
    {
        const string avatarUrl = "/Upload/Avatar/";
        public static string ResolveUrl(string urlfilename)
        {
            string sbUrl;
            if (String.IsNullOrEmpty(urlfilename))
            {
                sbUrl = avatarUrl + "Person-Dummy.jpg";
            }
            else
            {
                sbUrl = avatarUrl + urlfilename;
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
