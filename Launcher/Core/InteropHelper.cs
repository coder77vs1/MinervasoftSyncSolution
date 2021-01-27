using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ScanLauncher.Core
{
    public class InteropHelper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, bool turnOn);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        public enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3,
            Maximize = 3,
            ShowNormalNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActivate = 7,
            ShowNoActivate = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimized = 11
        }

        public static void BrignMainWindowToFront(string sProcessName)
        {
            List<Process> processAry = ProcessHelper.GetProcessList(sProcessName);

            if (processAry.Count > 0)
            {
                Process current = processAry[0];

                if (current.MainWindowHandle == IntPtr.Zero)
                {
                    ShowWindow(current.Handle, ShowWindowEnum.Restore);
                }

                SetForegroundWindow(current.Handle);
            }
        }

        static public void SetFocusToExternalApp(string sProcessName)
        {
            List<Process> processAry = ProcessHelper.GetProcessList(sProcessName);

            if (processAry.Count > 0)
            {
                IntPtr ipHwnd = processAry[0].MainWindowHandle;
                SetForegroundWindow(ipHwnd);
            }
        }

        static public void SwitchToThisWindowApp(string sProcessName)
        {
            List<Process> processAry = ProcessHelper.GetProcessList(sProcessName);

            if (processAry.Count > 0)
            {
                IntPtr ipHwnd = processAry[0].MainWindowHandle;
                SwitchToThisWindow(ipHwnd, true);
            }
        }

        static public bool SwitchToThisWindowApp(int sProcessId)
        {
            bool result = false;
            Process process = Process.GetProcessById(sProcessId);

            if (process != null)
            {
                result = SwitchToThisWindowApp(process);
            }

            return result;
        }

        static public bool SwitchToThisWindowApp(Process process)
        {
            bool result = false;

            if (process != null)
            {
                IntPtr ipHwnd = process.MainWindowHandle;
                SwitchToThisWindow(ipHwnd, true);
                result = true;
            }

            return result;
        }

        static public ServiceController GetServiceName(string serviceName)
        {
            ServiceController scService = null;

            try
            {
                ServiceController[] scServiceAry = ServiceController.GetServices();

                foreach (ServiceController item in scServiceAry)
                {
                    if (item.ServiceName.Equals(serviceName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        scService = item;
                        break;
                    }
                }
            }
            catch
            {
                scService = null;
            }

            return scService;
        }

        static public void ServiceRun()
        {
            string strSvcName = "runSvc";

            ServiceController svc = GetServiceName(strSvcName);

            if (svc != null)
            {
                if (svc.Status == ServiceControllerStatus.Running)
                {
                    //run process
                }
            }
        }

        static public void IExploreCall(string url)
        {
            try
            {
                Process.Start("IExplore.exe", url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public void SetRegData(string key)
        {
            if (string.IsNullOrEmpty(key)) return;

            try
            {
                string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(runKey);

                if (key.Equals("startup"))
                {
                    if (registryKey.GetValue("ScanLauncher") == null)
                    {
                        registryKey.Close();
                        registryKey = Registry.LocalMachine.OpenSubKey(runKey, true);
                        registryKey.SetValue("ScanLauncher", Application.ExecutablePath);
                        registryKey.Close();
                    }
                }
                else if (key.Equals("remove"))
                {
                    registryKey.Close();
                    registryKey = Registry.LocalMachine.OpenSubKey(runKey, true);
                    registryKey.DeleteValue("ScanLauncher");
                    registryKey.Close();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
