using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace MinervasoftSyncApp.Common
{
    public class BaseForm : Form
    {
        protected virtual void ClearControls() { }
        public string ResourcePath { get; set; }
        protected string JsonSerizlizer<T>(T t)
        {
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T));
            MemoryStream m = new MemoryStream();
            s.WriteObject(m, t);
            string jsonString = Encoding.UTF8.GetString(m.ToArray());
            m.Close();

            return jsonString;
        }

        protected T JsonDeserizlizer<T>(string context)
        {
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T));
            MemoryStream m = new MemoryStream(Encoding.UTF8.GetBytes(context));
            T t = (T)s.ReadObject(m);

            return t;
        }

        protected string OpenFilePathByXml(string dir)
        {
            string result = string.Empty;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Get Resource File";
            ofd.InitialDirectory = dir;
            ofd.Filter = "XML Files (*.xml) | *.xml";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                result = ofd.FileName;
            }

            return result;
        }
    }
}
