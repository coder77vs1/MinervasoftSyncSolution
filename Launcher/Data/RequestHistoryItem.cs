using System;
using System.Collections.Specialized;

namespace ScanLauncher.Data
{
    public class RequestHistoryItem
    {
        public RequestHistoryItem()
        {
            RequestDatetime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        public string RequestDatetime { get; set; } = string.Empty;
        public Uri RequestUri { get; set; } = null;
        public string RequestQueryString { get; set; } = string.Empty;
        public string RequestDomain { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return string.Format("{0} : {1}", RequestDatetime, State);
        }
    }
}
