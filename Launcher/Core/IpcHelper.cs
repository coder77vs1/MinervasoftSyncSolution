using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace ScanLauncher.Core
{
    public class IpcHelper
    {
        public static void ServerChannel(string userId, int processId, string context, string clickOnceVersion)
        {
            try
            {
                IpcServerChannel svr = new IpcServerChannel("remote");
                ChannelServices.RegisterChannel(svr, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteHelper), "iScan", WellKnownObjectMode.Singleton);
                RemoteHelper rHelper = new RemoteHelper();
                rHelper.SetCurrentAuthData(userId, processId, context, clickOnceVersion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object[] ClientChannelByIScan()
        {
            object[] result = new object[] { 0, string.Empty };

            try
            {
                IpcClientChannel client = new IpcClientChannel();
                ChannelServices.RegisterChannel(client, false);
                RemotingConfiguration.RegisterWellKnownClientType(typeof(RemoteHelper), "ipc://remote/iScan");
                RemoteHelper rHelper = new RemoteHelper();
                result[0] = rHelper.GetProcessId();
                result[1] = rHelper.GetCurrentClickOnceVersion();
            }
            catch
            {
                result = new object[] { 0, string.Empty };
            }

            return result;
        }

        public static object[] ClientChannelByRS()
        {
            object[] result = new object[] { 0, string.Empty, string.Empty };

            try
            {
                IpcClientChannel client = new IpcClientChannel();
                ChannelServices.RegisterChannel(client, false);
                RemotingConfiguration.RegisterWellKnownClientType(typeof(RemoteHelper), "ipc://remote/iScan");
                RemoteHelper rHelper = new RemoteHelper();
                result[0] = rHelper.GetProcessId();
                result[1] = rHelper.GetCurrentUserId();
                result[2] = rHelper.GetCurrentAuthData();
            }
            catch
            {
                result = new object[] { 0, string.Empty, string.Empty };
            }

            return result;
        }
    }
}
