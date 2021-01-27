using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanLauncher.Data
{
    public class CertificateItem
    {
        public string Url { get; set; }
        public string PfxPath { get; set; }
        public string CertName { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
    }
}
