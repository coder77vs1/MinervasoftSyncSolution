using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinervasoftSyncApp.Data
{
    public class PublishFileItem
    {
        public string FileName { get; set; } = string.Empty;
        public string ServerUrl { get; set; } = string.Empty;
        public string ClientPath { get; set; } = string.Empty;
        public string PublishState { get; set; } = string.Empty;
        public string SpecialFileType { get; set; } = string.Empty;
    }
}
