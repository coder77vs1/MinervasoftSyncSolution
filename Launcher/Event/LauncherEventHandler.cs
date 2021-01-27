using ScanLauncher.Config;

namespace ScanLauncher.Event
{
    public delegate void LauncherEventHandler(object sender, string mode, LauncherStatus state, string message);
}
