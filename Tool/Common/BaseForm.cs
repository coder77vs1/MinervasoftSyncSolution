using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using Minervasoft.Sync.Common;

namespace MinervasoftSyncApp.Common
{
    public class BaseForm : Form
    {
        protected virtual void ClearControls() { }
        public string ResourcePath { get; set; } 

        protected string OpenFilePathByXml(string dir)
        {
            string result = string.Empty;

            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Get Resource File",
                InitialDirectory = dir,
                Filter = "XML Files (*.xml) | *.xml"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                result = ofd.FileName;
            }

            return result;
        }
    }
}
