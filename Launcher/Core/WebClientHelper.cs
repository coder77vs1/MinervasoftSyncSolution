using ScanLauncher.Common;
using System.Net;
using System.Text;

namespace ScanLauncher.Core
{
    public class WebClientHelper : BaseWebClient
    {


        public static string WebClientReadFile(string url)
        {
            string result = string.Empty;

            url = NoCacheNoUrl(url);

            try
            {
                using (WebClient client = new WebClient())
                {
                    ////client.Headers.Add("Cache-Control", "no-cache");
                    client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                    client.Encoding = Encoding.UTF8;
                    result = client.DownloadString(url);
                }
            }
            catch
            {
                
            }

            return result;
        }
    }
}
