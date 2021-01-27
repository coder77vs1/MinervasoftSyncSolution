using ScanLauncher.Data;
using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using ScanLauncher.Config;
using System.Diagnostics;

namespace ScanLauncher.Core
{
    public class X509CertificateHelper
    {
        /// <summary>
        /// https 인증서 등록
        /// </summary>
        public static void Create(CertificateItem item)
        {
            try
            {
                // Get the certifcate to use to encrypt the key.
                X509Certificate2 cert = GetCertificateFromStore(item.CertName);

                // 법무부에 동일한 loclahost 명의 인증서파일이 존재하므로 검사하지않고 그냥 등록
                // 접속 안될때 : Explorer -> 인터넷옵션 -> 로컬 인트라넷 -> 사이트 -> 3가지항목 체크 해제 확인
                // 접속 안될때 : 신롸할수없는 사이트 추가, 호환성보기 설정 추가
                // 접속 안될때 : telnet 확인
                //if (cert == null)
                {
                    if (FileHelper.ExistsFile(item.PfxPath) == false)
                        throw new Exception("인증서 파일이 존재 하지 않습니다.");

                    X509Certificate2 x509 = new X509Certificate2(item.PfxPath, item.Password);

                    // 신뢰할수있는 루트인증기관 등록
                    X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(x509);
                    store.Close();

                    // 신뢰할수있는 루트인증기관 등록
                    store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(x509);
                    store.Close();

                    // 신뢰할수있는 게시자 등록
                    store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(x509);
                    store.Close();

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                }

                // netsh 실행 (add urlacl, add sslcert)
                NetshReg(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// netsh 실행 (add urlacl, add sslcert)
        /// </summary>
        /// <param name="item"></param>
        private static void NetshReg(CertificateItem item)
        {
            try
            {
                string sUrlAcl = "";
                string sSslCert = "";
                sUrlAcl = string.Format(@"http add urlacl url={0} user={1}\{2}", item.Url, Environment.UserDomainName, Environment.UserName);
                sSslCert = string.Format("http add sslcert ipport = 0.0.0.0:{0} certhash = c081f6fce7ebd93aea6556b37a14980850087534 appid = \"{{4225a41c-4b33-4353-ab2b-3790924f73f7}}\"", item.Port);

                // URL 예약등록
                ProcessStartInfo psi = new ProcessStartInfo("netsh", sUrlAcl);
                psi.Verb = "runas";
                psi.CreateNoWindow = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.UseShellExecute = true;
                Process.Start(psi).WaitForExit();

                // SSL 바인딩등록
                psi = new ProcessStartInfo("netsh", sSslCert);
                psi.Verb = "runas";
                psi.CreateNoWindow = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.UseShellExecute = true;
                Process.Start(psi).WaitForExit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static X509Certificate2 GetCertificateFromStore(string certName)
        {

            // Get the certificate store for the current user.
            X509Store store = new X509Store(StoreLocation.LocalMachine);
            try
            {
                store.Open(OpenFlags.ReadOnly);

                // Place all certificates in an X509Certificate2Collection object.
                X509Certificate2Collection certCollection = store.Certificates;
                // If using a certificate with a trusted root you do not need to FindByTimeValid, instead:
                // currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, true);
                X509Certificate2Collection currentCerts = certCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection signingCert = currentCerts.Find(X509FindType.FindBySubjectDistinguishedName, certName, false);
                if (signingCert.Count == 0)
                    return null;
                // Return the first certificate in the collection, has the right name and is current.
                return signingCert[0];
            }
            finally
            {
                store.Close();
            }
        }
    }
}
