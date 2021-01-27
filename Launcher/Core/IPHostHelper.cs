using System;
using System.Net;
using System.Net.Sockets;

namespace ScanLauncher.Core
{
    public class IPHostHelper
    {
        public static string GetCurrentIPAddress()
        {
            string sIPAddress = string.Empty;

            try
            {
                IPHostEntry ip = Dns.GetHostEntry(Dns.GetHostName());

                foreach (var item in ip.AddressList)
                {
                    if (item.AddressFamily != AddressFamily.InterNetworkV6)
                    {
                        sIPAddress = item.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sIPAddress;
        }
    }
}
