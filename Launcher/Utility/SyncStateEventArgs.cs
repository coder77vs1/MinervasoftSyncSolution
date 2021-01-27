using ScanLauncher.Config;
using System;

namespace ScanLauncher
{
    public class SyncStateEventArgs : EventArgs
    {
        public string StepName { get; set; }
        public PublishProcessStatus Status { get; set; }
        public string Message { get; set; }
    }
}
