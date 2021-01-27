using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using ScanLauncher.Data;
using ScanLauncher.Config;

namespace ScanLauncher.Core
{
    public class HttpListenerHelper
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<Common.BaseForm, HttpListenerRequest, string> _responderMethod;

        public HttpListenerHelper(Func<Common.BaseForm, HttpListenerRequest, string> method, params string[] prefixes) : this(prefixes, method) { }

        public HttpListenerHelper(IReadOnlyCollection<string> prefixes, Func<Common.BaseForm, HttpListenerRequest, string> method)
        {
            if (!HttpListener.IsSupported)
            {
                throw new NotSupportedException("Need Windows XP SP2, Server 2003 or later.");
            }

            if (prefixes == null || prefixes.Count == 0)
            {
                throw new ArgumentException("URI prefixes are required");
            }

            if (method == null)
            {
                throw new ArgumentException("responder method required.");
            }

            //https 환경설정 정보
            CertificateItem cfitem = ApplicationConfig.GetX509Certificate();

            //운영 모드 시 https 설정
            if (string.IsNullOrEmpty(cfitem.Url) == false)
            {
                X509CertificateHelper.Create(cfitem);

                _listener.Prefixes.Add(cfitem.Url);
                _listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            }
            else
            {
                foreach (var item in prefixes)
                {
                    _listener.Prefixes.Add(item);
                }
            }

            _responderMethod = method;
            _listener.Start();
        }

        public string Runs(Common.BaseForm fm)
        {
            string result = string.Empty;

            try
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    try
                    {
                        while (_listener.IsListening)
                        {
                            ThreadPool.QueueUserWorkItem(c =>
                            {
                                HttpListenerContext ctx = c as HttpListenerContext;

                                try
                                {
                                    if (ctx == null)
                                        return;

                                    var rstr = _responderMethod(fm, ctx.Request);
                                    var buf = System.Text.Encoding.UTF8.GetBytes(rstr);
                                    ctx.Response.ContentLength64 = buf.Length;
                                    ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                                }
                                catch (Exception ex)
                                {
                                    result = ex.Message;
                                }
                                finally
                                {
                                    if (ctx != null)
                                        ctx.Response.OutputStream.Close();
                                }
                            }, _listener.GetContext());
                        }
                    }
                    catch (Exception ex)
                    {
                        result = ex.Message;
                    }
                });
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}
