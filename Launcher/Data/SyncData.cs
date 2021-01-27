namespace ScanLauncher.Data
{
    public class SyncResourceData
    {
        public PublishData ClientConfig { get; set; }
        public string ClientState { get; set; }
        public string ServerState { get; set; }
        public PublishData ServerConfig { get; set; }
        public string ServerPublishRelease { get; set; }
    }
}