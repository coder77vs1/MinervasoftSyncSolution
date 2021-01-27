namespace ScanLauncher.Data
{
    public class ConfigurationData
    {
        //서버 모드 :: R:운영, S:검증, D:개발
        public string Mode { get; set; } = string.Empty;
        public string ClientPath { get; set; } = string.Empty;
        public string ServerHost { get; set; } = string.Empty;        
        public string WebSocketPort { get; set; } = string.Empty;
        public string ProcessSyncMinute { get; set; } = string.Empty;
    }
}
