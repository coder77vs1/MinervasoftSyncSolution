namespace ScanLauncher.Utility
{
    public class SpecialContext
    {
        public static string GetSpecialcContext(string fileName)
        {
            string result = string.Empty;

            switch (fileName.ToLower())
            {
                case "scanstation.exe.config":
                    result = GetScanStation_exe_config;
                    break;
                default:
                    break;
            }

            return result;
        }

        private static string GetScanStation_exe_config
        {
            get 
            {
                return @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<configuration>  
    <startup>  
        <supportedRuntime version = ""v4.0"" sku = "".NETFramework,Version=v4.5""/>     
    </startup>
</configuration>";
            }
        }
    }
}
