namespace ScanLauncher.Data
{
    public class PublishFileItem
    {
        public string FileName { get; set; } = string.Empty;
        public string ServerUrl { get; set; } = string.Empty;        
        public string DownloadPath { get; set; } = string.Empty;
        public string ClientPath { get; set; } = string.Empty;
        public string PublishState { get; set; } = string.Empty;        
        public string State { get; set; } = string.Empty;
        public bool ExistsFile { get; set; }
        public string SpecialFileType { get; set; } = string.Empty;
    }
}
