using ScanLauncher.Config;
using ScanLauncher.Core;
using ScanLauncher.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScanLauncher.Service
{
    public class AuthService : IDisposable
    {
        /// <summary>
        /// 권한정보 조회 서비스
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerDate()
        {
            return DateTime.Now;
        }
        public RequestItem GetUserInfo(string corrinstt, string usrid)
        {
            RequestItem request = null;

            try
            {
                UserRequestItem Request = new UserRequestItem
                {
                    corrInsttCd = corrinstt,
                    usrId = usrid,
                };
                
                string requestContext = JsonHelper.JsonSerizlizer<UserRequestItem>(Request);

                UserRequestItem userRequestItem = UserInfoService(requestContext);

                if (userRequestItem == null || string.IsNullOrEmpty(userRequestItem.ENC_DATA))
                {
                    request = new RequestItem();
                }
                else
                {
                    //암호화
                    //string responseContext = CryptographyHelper.AES.Decrypt(userRequestItem.ENC_DATA, Convert.ToInt32(userRequestItem.privateKey));
                    //List<RequestItem> requestData = JsonHelper.JsonDeserizlizer<List<RequestItem>>(responseContext);
                    //평문
                    //string responseContext = CryptographyHelper.AES.Decrypt(userRequestItem.ENC_DATA, Convert.ToInt32(userRequestItem.privateKey));
                    List<RequestItem> requestData = JsonHelper.JsonDeserizlizer<List<RequestItem>>(userRequestItem.ENC_DATA);

                    if (requestData != null && requestData.Count == 1)
                        request = requestData[0];
                }
            }
            catch
            {
                request = new RequestItem();
            }

            return request;
        }

        public UserRequestItem UserInfoService(string context)
        {
            UserRequestItem userRequestItem = null;
            string responseContext = string.Empty;            
            int privateKey = CryptographyHelper.AES.CreateKeyIndex();
            //암호화
            //string decryptContext = CryptographyHelper.AES.Encrypt(context, privateKey);
            //평문
            string decryptContext = context;

            UserRequestItem requestVO = new UserRequestItem
            {
                privateKey = privateKey.ToString(),
                encData = decryptContext,
            };

            string requestContext = JsonHelper.JsonSerizlizer<UserRequestItem>(requestVO);

            try
            {
                using (HttpRequestHelper client = new HttpRequestHelper(ApplicationConfig.ServiceHost))
                {
                    var response = client.PostASJsonAsync(ApplicationConfig.Service.USERINFO[1], ApplicationConfig.Service.USERINFO[0], requestContext);

                    if (response.IsSuccessStatusCode)
                    {
                        responseContext = client.GetHttpResponseMessage(response);
                        userRequestItem = JsonHelper.JsonDeserizlizer<UserRequestItem>(responseContext);
                    }
                    else
                    {
                        responseContext = client.GetHttpResponseMessage(response);
                    }
                }
            }
            catch
            {
                userRequestItem = new UserRequestItem();
            }

            return userRequestItem;
        }


        public void Dispose()
        {   
        }
    }
}
