using System;
using System.Collections.Specialized;

namespace ScanLauncher.Data
{
    public class ProcessItem
    {
        public ProcessItem() { }

        public ProcessItem(ProcessItem item)        
        {
            ProcessId = item.ProcessId;
            ProcessName = item.ProcessName;
            ProcessPath = item.ProcessPath;
            QueryString = item.QueryString;
            Arguments = item.Arguments;
            Mode = item.Mode;
            Request = item.Request;
            CreateDateTime = item.CreateDateTime;
            LastAccessDateTime = item.LastAccessDateTime;
        }

        public int ProcessId { get; set; } = 0;
        public string ProcessName { get; set; } = string.Empty;
        public string ProcessPath { get; set; } = string.Empty;
        public NameValueCollection QueryString { get; set; } = new NameValueCollection();
        public string Arguments { get; set; } = string.Empty;
        public string ReqArguments { get; set; } = string.Empty;
        public string Mode { get; set; } = string.Empty;
        public RequestItem Request { get; set; } = new RequestItem();
        public DateTime CreateDateTime { get; set; }
        public DateTime LastAccessDateTime { get; set; }
    }
}
