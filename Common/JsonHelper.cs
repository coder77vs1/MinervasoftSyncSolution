using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Minervasoft.Sync.Common
{
    public class JsonHelper
    {
        public static string JsonSerizlizer<T>(T t)
        {
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T));
            MemoryStream m = new MemoryStream();
            s.WriteObject(m, t);
            string jsonString = Encoding.UTF8.GetString(m.ToArray());
            m.Close();

            return jsonString;
        }

        public static T JsonDeserizlizer<T>(string context)
        {
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T));
            MemoryStream m = new MemoryStream(Encoding.UTF8.GetBytes(context));
            T t = (T)s.ReadObject(m);

            return t;
        }
    }
}
