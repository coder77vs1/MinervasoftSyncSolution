using System.Collections.Generic;

namespace MinervasoftSyncApp.Data
{
    public class PublishData
    {
        public string PublishDate { get; set; } = string.Empty;
        public long BuildVersion { get; set; } = 0;
        public List<PublishFileItem> Files { get; set; }
    }
}
