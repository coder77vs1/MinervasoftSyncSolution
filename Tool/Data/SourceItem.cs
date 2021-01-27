namespace MinervasoftSyncApp.Data
{
    public class SourceItem
    {
        public string ApplicationId { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string CurrentPath { get; set; } = string.Empty;
        public bool Use { get; set; } = false;
        public string SpecialFileType { get; set; } = string.Empty;
    }
}
