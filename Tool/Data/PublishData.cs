using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinervasoftSyncApp.Data
{
    public class PublishData
    {
        public string PublishDate { get; set; } = string.Empty;
        public long BuildVersion { get; set; } = 0;
        public List<PublishFileItem> Files { get; set; }
    }
}
