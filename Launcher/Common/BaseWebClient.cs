using System;

namespace ScanLauncher.Common
{
    public class BaseWebClient
    {
        protected string NoCacheNoUrlContext(string url)
        {
            return BaseWebClient.NoCacheNoUrl(url);
        }


        protected static string NoCacheNoUrl(string url)
        {
            return string.Format("{0}?version={1}", url, DateTime.Now.Ticks);
        }
    }
}
