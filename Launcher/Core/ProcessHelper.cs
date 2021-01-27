using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ScanLauncher.Core
{
    public class ProcessHelper
    {
        static public bool RunApp(string applicationPath, string arguments)
        {
            try
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                procInfo.UseShellExecute = true;
                procInfo.FileName = applicationPath;

                // 파라미터 설정
                if (string.IsNullOrEmpty(arguments) == false)
                {
                    procInfo.Arguments = arguments;
                }

                var process = Process.Start(procInfo);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public Process[] GetProcessList()
        {
            return Process.GetProcesses();
        }

        static public List<Process> GetProcessList(string processName, bool isHasExited = true)
        {
            List<Process> targetProcessData = null;

            try
            {
                targetProcessData = new List<Process>();
                Process[] sourceProcessAry = Process.GetProcessesByName(processName);

                foreach (Process item in sourceProcessAry)
                {
                    if (isHasExited)
                    {
                        //Exit Process check
                        if (item.HandleCount == 0 || item.HasExited == true)
                            continue;
                    }

                    targetProcessData.Add(item);
                }
            }
            catch
            {
                if (isHasExited)
                    targetProcessData = GetProcessList(processName, false);
            }

            return targetProcessData;
        }

        static public Process GetProcessById(int processId)
        {
            return Process.GetProcessById(processId);
        }

        static public List<Process> GetProcessListByName(string processName)
        {
            List<Process> result = new List<Process>();
            List<Process> processAry = GetProcessList(processName);

            foreach (Process item in processAry)
            {
                if (item.ProcessName.Equals(processName, StringComparison.CurrentCultureIgnoreCase))
                    result.Add(item);
            }

            return result;
        }

        static public bool GetProcessContains(string processName)
        {
            return GetProcessList(processName).Count > 0 ? true : false;
        }

        static public int GetProcessId(string processName)
        {
            int result = -1;
            var processList = GetProcessList(processName);

            if (processList.Count == 1)
                result = processList[0].Id;

            return result;
        }

        static public int GetCurrentProcessId()
        {
            return Process.GetCurrentProcess().Id;
        }

        static public string GetCurrentProcessName()
        {
            return Process.GetCurrentProcess().ProcessName;
        }

        static public bool ProcessKill(string processName)
        {
            bool result = false;

            try
            {
                Process[] processAry = Process.GetProcessesByName(processName);

                foreach (Process item in processAry)
                {
                    ProcessKillExtend(item);
                }

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        static private bool ProcessKillExtend(Process item)
        {
            bool result = false;

            try
            {
                item.Kill();
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        static public string GetProcessGuid(Process process)
        {
            string result = string.Empty;

            Assembly assembly = Assembly.LoadFile(process.MainModule.FileName);
            object[] customAttribs = assembly.GetCustomAttributes(typeof(GuidAttribute), false);

            if (customAttribs.Length > 0)
                result = ((GuidAttribute)customAttribs.GetValue(0)).Value.ToString();

            return result;
        }

        static public void ProcessKill(List<Process> processData)
        {
            foreach (Process item in processData)
            {
                ProcessKillExtend(item);

            }
        }
    }
}
