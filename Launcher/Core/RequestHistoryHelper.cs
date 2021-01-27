using ScanLauncher.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ScanLauncher.Core
{
    public class RequestHistoryHelper
    {
        public static void InitializeResource() { RequestHistoryData = new List<RequestHistoryItem>(); }
        public static List<RequestHistoryItem> RequestHistoryData { get; set; } = null;

        public static int AddItem(HttpListenerRequest request)
        {
            int result = -1;

            try
            {
                if (RequestHistoryData == null)
                    InitializeResource();

                RequestHistoryItem requestHistoryItem = new RequestHistoryItem
                {
                    RequestDomain = request.UrlReferrer == null ? string.Empty : request.UrlReferrer.Host,
                    RequestUri = request.Url,
                    RequestQueryString = string.Join("&", request.QueryString.AllKeys.Select(x => x + "=" + request.QueryString[x])),
                State = "Fail"
                };

                RequestHistoryData.Add(requestHistoryItem);

                result = RequestHistoryData.Count - 1;
            }
            catch
            {
                
            }

            return result;
        }

        public static RequestHistoryItem GetActiveItem(int index = -1)
        {
            if (RequestHistoryData != null && RequestHistoryData.Count > 0)
            {
                int idx = (index == -1) ? RequestHistoryData.Count - 1 : index;
                return RequestHistoryData[idx];
            }
            else
            {
                return new RequestHistoryItem();
            }
        }
    }
}
