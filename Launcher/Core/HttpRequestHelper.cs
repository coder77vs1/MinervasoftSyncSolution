using ScanLauncher.Common;
using ScanLauncher.Config;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScanLauncher.Core
{
    public class HttpRequestHelper : BaseWebClient, IDisposable
    {
        private HttpClient client;
        private int timeoutSeonds;
        private string url;
        private string mediaType;

        public HttpRequestHelper()
        {
            InitializeConfig();
            InitializeComponent();
        }

        public HttpRequestHelper(string host)
        {
            url = host;
            InitializeConfig();
            InitializeComponent();
        }

        private void InitializeConfig()
        {
            this.url = string.IsNullOrEmpty(url) ? ApplicationConfig.ServiceHost : this.url;
            this.timeoutSeonds = ApplicationConfig.TimeoutSeconds;
            this.mediaType = ApplicationConfig.MediaType;
        }

        private void InitializeComponent()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(this.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(this.mediaType));
        }

        public HttpResponseMessage PostASJsonAsync(string guid, string requestUrl, string context)
        {
            try
            {
                client.DefaultRequestHeaders.Add(ApplicationConfig.HttpListenerConfig.RequestHeaderName, guid);
                return client.PostAsync(requestUrl, new StringContent(context, Encoding.UTF8, this.mediaType)).Result;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetHttpResponseMessage(HttpResponseMessage responseMessage)
        {
            string result = string.Empty;

            using (HttpContent content = responseMessage.Content)
            {
                Task<string> read = content.ReadAsStringAsync();
                result = read.Result;
            }

            return result;
        }

        public string DownloadFile(string serverPath, string tempPath, string fileName)
        {
            
            string result = string.Empty;
            //http://webapp2020.com/imageviewer/res/scatstation/Data/IMR/IMR_Data.db

            //serverPath = "http://webapp2020.com/Files/BarcodeReader.dll";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(serverPath).Result;

                if (response.IsSuccessStatusCode)
                {
                    using (var stream = response.Content.ReadAsStreamAsync().Result)
                    {
                        var downloadPath = FileHelper.GetDownloadTempPath(tempPath, fileName);

#if DEBUG 
                        Console.WriteLine(downloadPath);
#endif                  
                        var fileInfo = new System.IO.FileInfo(downloadPath);
                        using (var fileStream = fileInfo.OpenWrite())
                        {
                            stream.CopyToAsync(fileStream).Wait();

                            result = downloadPath;
                        }
                    }
                }
            }

            return result;
        }

        public void Dispose()
        {
            if (client != null)
                client.Dispose();
        }
    }
}
