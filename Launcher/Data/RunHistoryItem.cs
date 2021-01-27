using System;

namespace ScanLauncher.Data
{
    public class RunHistoryItem
    {
        public bool IsRun { get; set; }        
        public string AutoSyncStatus { get; set; }
        public string CreateDate { get; set; }
        public string LastUpdateDate { get; set; } = string.Empty;
        public string WebSocketInfo { get; set; } = string.Empty;
        public string ServerInfo { get; set; } = string.Empty;
        public string ServerHost { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
