using ScanLauncher.Data;
using System;
using System.Configuration;

namespace ScanLauncher.Config
{
    public class ApplicationConfig
    {
        public class Service
        {
            // 사용자정보 : 암호화
            public static readonly string[] USERINFO = new string[] { "/imageviewer/scanApi/getUser.do", "SCANSTATION_S0006" };
        }


        /// <summary>
        /// 개발실행모드 (R:운영, T:개발, S:임시개발, D:개발자(인터페이스 사용X)
        /// </summary>
        public static string Mode { get; } = ConfigurationManager.AppSettings["MODE"];

        /// <summary>
        /// 솔루션 이름
        /// </summary>
        public static string SolutionTitle = "ScanStation";

        /// <summary>
        /// 배포파일
        /// </summary>
        private static string sPublishFile = "publish.release";

        /// <summary>
        /// 배포파일
        /// </summary>
        private static string sProcessFile = "process.release";

        /// <summary>
        /// 서버경로
        /// </summary>
        private static string sServerResourcePath = "/nics/install";

        /// <summary>
        /// 서버 배포파일
        /// </summary>
        private static string sServerResourceFilePath = "/scanstation/publish.release";

        /// <summary>
        /// 서버 배포파일
        /// </summary>
        private static string sServerProcessFilePath = "/scanstation/process.release";

        /// <summary>
        /// 처리시간
        /// </summary>
        private static string iProcessSyncMinute = "5";

        /// <summary>
        /// 중복실행 체크(초)
        /// </summary>
        private static string iOverlapSeconds = "10";

        /// <summary>
        /// 클라이언트 설치 주소
        /// </summary>
        public static string ClientPath = @"C:\Minervasoft\ScanStation\";

        /// <summary>
        /// 서버주소
        /// </summary>
        public static string ServerHost;

        /// <summary>
        /// 서버주소
        /// </summary>
        public static string ServiceHost;

        /// <summary>
        /// 서버주소
        /// </summary>
        public static string ServerHostName;

        /// <summary>
        /// 웹소켓 포트 (50001:운영, 50002:검증, 50003:개발)
        /// </summary>
        private static string iWebSocketPort;

        /// <summary>
        /// Host으로 실행 모드 확인
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static string GetServerHostNameMode(string host)
        {
            string mode = string.Empty;

            switch (host)
            {   
                case "10.92.180.21": mode = "D"; break;
                case "ncis.com": mode = "R"; break;
                case "": 
                default:
                    mode = ""; break;
            }
            return mode;
        }
        
        /// <summary>
        /// 환경설정 초기화
        /// </summary>
        public static void InitializeAppSettings()
        {   
            if (Mode.Equals("R", StringComparison.CurrentCultureIgnoreCase)) //운영서버
            {
                iWebSocketPort = "50001";
                ServerHost = "https://nics.corrections.go.kr:50443";
                ServiceHost = "https://nics.corrections.go.kr:50443";
                ServerHostName = "https://nics.corrections.go.kr:50443";
                /**
                 * https://10.92.180.1:50443
                 * http://10.92.180.1:50080
                 * http://nics.corrections.go.kr:50080 --> 도메인접속안됨
                 * https://nics.corrections.go.kr:50443
                 **/
            }
            else if (Mode.Equals("T", StringComparison.CurrentCultureIgnoreCase)) //개발서버
            {
                iWebSocketPort = "50002";
                ServerHost = "https://nicsdev.corrections.go.kr:50443";
                ServiceHost = "https://nicsdev.corrections.go.kr:50443";
                ServerHostName = "https://nicsdev.corrections.go.kr:50443";
                /**
                 * https://10.92.180.33:50443
                 * http://10.92.180.33:50080
                 * http://nicsdev.corrections.go.kr:50080 --> 도메인접속안됨
                 * https://nicsdev.corrections.go.kr:50443 
                **/
            }
            else if (Mode.Equals("S", StringComparison.CurrentCultureIgnoreCase)) //임시개발서버(http)
            {
                iWebSocketPort = "50003";
                ServerHost = "http://10.92.180.21";
                ServiceHost = "http://10.92.180.21";
                ServerHostName = "10.92.180.21";
            }
            else if (Mode.Equals("SS", StringComparison.CurrentCultureIgnoreCase)) //임시개발서버(htpps)
            {
                iWebSocketPort = "50004";
                ServerHost = "https://10.92.180.21";
                ServiceHost = "https://10.92.180.21";
                ServerHostName = "10.92.180.21";
            }
            else if (Mode.Equals("D", StringComparison.CurrentCultureIgnoreCase)) //개발자모드
            {
                iWebSocketPort = "50003";
                ServerHost = "http://10.92.180.21";
                ServiceHost = "http://10.92.180.21";
                ServerHostName = "10.92.180.21";
            }
            else
            {
                iWebSocketPort = string.Empty;
                ServerHost = string.Empty;
                ServerHostName = string.Empty;
            }
        }

        public static CertificateItem GetX509Certificate()
        {
            CertificateItem item = new CertificateItem();

            if (Mode.Equals("R", StringComparison.CurrentCultureIgnoreCase)) //운영서버
            {
                item.Url = "https://+:50001/ScanLauncher/";
                item.Port = "50001";
                item.PfxPath = string.Format("{0}\\CourtCert.pfx", System.IO.Directory.GetCurrentDirectory());
                item.CertName = "CN=localhost";
                item.Password = "minervasoft";
            }
            else if (Mode.Equals("T", StringComparison.CurrentCultureIgnoreCase)) //개발서버
            {
                item.Url = "https://+:50002/ScanLauncher/";
                item.Port = "50002";
                item.PfxPath = string.Format("{0}\\CourtCert.pfx", System.IO.Directory.GetCurrentDirectory());
                item.CertName = "CN=localhost";
                item.Password = "minervasoft";
            }
            else if (Mode.Equals("SS", StringComparison.CurrentCultureIgnoreCase)) //임시개발서버(https)
            {
                item.Url = "https://+:50004/ScanLauncher/";
                item.Port = "50004";
                item.PfxPath = string.Format("{0}\\CourtCert.pfx", System.IO.Directory.GetCurrentDirectory());
                item.CertName = "CN=localhost";
                item.Password = "minervasoft";
            }

            return item;
        }
        /*
        private static readonly string sPublishFile = ConfigurationManager.AppSettings["PublishFile"];
        private static readonly string sProcessFile = ConfigurationManager.AppSettings["ProcessFile"];
        private static readonly string sServerResourcePath = ConfigurationManager.AppSettings["ServerResourcePath"];
        private static readonly string sServerResourceFilePath = ConfigurationManager.AppSettings["ServerResourceFilePath"];
        private static readonly string sServerProcessFilePath = ConfigurationManager.AppSettings["ServerProcessFilePath"];
        private static readonly string iWebSocketPort = ConfigurationManager.AppSettings["WebSocketPort"];        
        private static readonly string iProcessSyncMinute = ConfigurationManager.AppSettings["ProcessSyncMinute"];
        private static readonly string iOverlapSeconds = ConfigurationManager.AppSettings["OverlapSeconds"];         
        public static string ClientPath { get; } = ConfigurationManager.AppSettings["ClientResourcePath"];
        public static string ServerHost { get; } = ConfigurationManager.AppSettings["ServerHost"];
        public static string ServerResourceHost { get; } = ConfigurationManager.AppSettings["ServerResourceHost"];
        
		<!--Server Host :: 서버주소-->
		<!--http://10.92.180.21/nics/install/scanstaion-->
		<add key="ServerResourceHost" value="http://10.92.180.21"/>
		<!--Server Host :: 서버주소-->
		<add key="ServerHost" value="http://10.92.180.21"/>
		<!--Client Path :: 클라이언트 설치 주소-->
		<add key="ClientResourcePath" value="C:\Minervasoft\ScanStation\"/>
		<!--Client Path :: 클라이언트 설치 주소-->
		<add key="ServerResourcePath" value="/nics/install"/>
		<!--Server Path :: 서버 주소-->
		<add key="ServerResourceFilePath" value="/scanstation/publish.release"/>
		<!--Server Path :: 서버 주소-->
		<add key="ServerProcessFilePath" value="/scanstation/process.release"/>
		<!--WebSocket Port :: 50001:운영, 50002:검증, 50003:개발-->
		<add key="WebSocketPort" value="50003"/>
		<!--Timeout : 분-->
		<add key="ProcessSyncMinute" value="59"/>
		<!--Overlap Seconds: 중복실행 체크 초-->
		<add key="OverlapSeconds" value="10"/>		
		<!--publish release : 배포파일-->
		<add key="PublishFile" value="publish.release"/>
		<!--process release : 배포파일-->
		<add key="ProcessFile" value="process.release"/>


        */

        public static int WebSocketPort
        {
            get { return Convert.ToInt32(iWebSocketPort); }
        }

        public static int TimeoutSeconds
        {
            get { return Convert.ToInt32(iProcessSyncMinute); }
        }

        public static string MediaType { get; } = "application/json";

        public static string ClientPublishPath
        {
            get { return ClientPath + sPublishFile; }
        }

        public static string ClientProcessPath
        {
            get { return ClientPath + sProcessFile; }
        }

        public static string ClientPublishDirectory
        {
            get { return System.IO.Path.Combine(ClientPath, "Publish"); }
        }

        public static string ServerPublishPath
        {
            get { return ServerHost + sServerResourcePath; }
        }

        public static string ServerPublishFilePath
        {
            get { return ServerHost + sServerResourcePath + sServerResourceFilePath; }
        }

        public static string ServerProcessFilePath
        {
            get { return ServerHost + sServerResourcePath + sServerProcessFilePath; }
        }

        public static int OverlapSeconds
        {
            get { return Convert.ToInt32(iOverlapSeconds); }
        }

        public static bool DevMode
        {
            get { return Mode.Equals("R") ? false : true; }
        }

        public class HttpListenerConfig
        {
            public static string ListenerUrl
            {
                get
                {
                    if (Mode.Equals("R", StringComparison.CurrentCultureIgnoreCase)) //운영서버
                    {
                        return string.Format("https://localhost:{0}/ScanLauncher/", WebSocketPort);
                    }
                    else if (Mode.Equals("T", StringComparison.CurrentCultureIgnoreCase)) //운영서버
                    {
                        return string.Format("https://localhost:{0}/ScanLauncher/", WebSocketPort);
                    }
                    else if (Mode.Equals("S", StringComparison.CurrentCultureIgnoreCase)) //운영서버
                    {
                        return string.Format("http://localhost:{0}/ScanLauncher/", WebSocketPort);
                    }
                    else if (Mode.Equals("SS", StringComparison.CurrentCultureIgnoreCase)) //운영서버
                    {
                        return string.Format("https://localhost:{0}/ScanLauncher/", WebSocketPort);
                    }
                    else if (Mode.Equals("D", StringComparison.CurrentCultureIgnoreCase)) //운영서버
                    {
                        return string.Format("http://localhost:{0}/ScanLauncher/", WebSocketPort);
                    }
                    else
                        return string.Format("http://localhost:{0}/ScanLauncher/", WebSocketPort);
                }
            }

            public static string RequestHeaderName = "GUID";
        }
    }
}