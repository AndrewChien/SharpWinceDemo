using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace PocketGate.Helper
{
    public class ApiHelper
    {
        /// <summary>
        /// 获取前置网关信息
        /// </summary>
        /// <returns></returns>
        public static string GetTicketGateWayUrl(string webUrl)
        {
            if (string.IsNullOrEmpty(webUrl))
                return string.Empty;

            string resultUrl = string.Empty;
            var url =
                string.Format("{0}/sysconfig/getgatewayurl", webUrl);

            var result = SendDataToApiService<string>(url, "GET", string.Empty);
            if (result == null) return string.Empty;

            return result.oData;
        }

        /// <summary>
        /// 发送数据到Api服务接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiUrl"></param>
        /// <param name="requestType"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ApiResult<T> SendDataToApiService<T>(string apiUrl, string requestType, string param)
        {
            if (string.IsNullOrEmpty(apiUrl) || string.IsNullOrEmpty(requestType))
                return ApiResultHelper<T>.getFailApiResult("没有找到api接口地址", default(T));

            string strJson = string.Empty;
            HttpWebRequest request = null; 
            HttpWebResponse response = null; 
            try
            {
                
                ASCIIEncoding encoding = new ASCIIEncoding();
                request = WebRequest.Create(apiUrl) as HttpWebRequest;
                //request.ProtocolVersion = HttpVersion.Version11;
                //request.AllowAutoRedirect = true;
                //request.KeepAlive = true;
                //request.Headers.Add("Accept-Language", "zh-cn");
                //request.Accept = "*/*";
                //request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.2; Trident/4.0;)";

                byte[] b = Encoding.UTF8.GetBytes(param);
                request.ContentType = "application/json";
                request.ContentLength = b.Length;
                request.Method = requestType;
                if (b.Length > 0)
                {
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(b, 0, b.Length);
                        stream.Close();
                    }
                }

                //获取服务器返回的资源
                using (response = request.GetResponse() as HttpWebResponse)  //自动关闭和释放
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))  //自动关闭和释放
                    {
                        strJson = reader.ReadToEnd();
                        reader.Close();
                    }
                }
                return JsonConvert.DeserializeObject<ApiResult<T>>(strJson);
            }
            catch (Exception exception)
            {
                //new Common.LogHelper().WriteLine(exception.ToString());
                return ApiResultHelper<T>.getFailApiResult(exception.Message, default(T));
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }

        /// <summary>
        /// 发送数据到Api服务接口（青岛）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiUrl"></param>
        /// <param name="requestType"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ApiResult_QD<T> SendDataToApiService_QD<T>(string apiUrl, string requestType, string param, TokenStyle token)
        {
            if (string.IsNullOrEmpty(apiUrl) || string.IsNullOrEmpty(requestType))
                return ApiResultHelper_QD<T>.getFailApiResult("没有找到api接口地址", default(T));

            string strJson = string.Empty;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                request = WebRequest.Create(apiUrl) as HttpWebRequest;
                request.AllowWriteStreamBuffering = true;//
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                //request.ProtocolVersion = HttpVersion.Version11;
                //request.AllowAutoRedirect = true;
                //request.KeepAlive = true;
                //request.Headers.Add("Accept-Language", "zh-cn");
                //request.Accept = "*/*";
                //request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.2; Trident/4.0;)";

                byte[] b = Encoding.UTF8.GetBytes(param);
                //Header中添加token验证（服务器要求）
                request.Headers.Add("Authorization", token.token_type+ " " + token.access_token);//已有token添加入头
                request.ContentType = "application/json";//已有token使用json类型
                request.ContentLength = b.Length;
                request.Method = requestType;
                if (b.Length > 0)
                {
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(b, 0, b.Length);
                        stream.Close();
                    }
                }
                //获取服务器返回
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        strJson = reader.ReadToEnd();
                        reader.Close();
                    }
                }
                return JsonConvert.DeserializeObject<ApiResult_QD<T>>(strJson);
            }
            catch (Exception exception)
            {
                //new Common.LogHelper().WriteLine(exception.ToString());
                return ApiResultHelper_QD<T>.getFailApiResult(exception.Message, default(T));
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <returns></returns>
        public static TokenStyle GetTokenString(string apiUrl)
        {
            string strJson = string.Empty;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                request = WebRequest.Create(apiUrl) as HttpWebRequest;
                request.AllowWriteStreamBuffering = true;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
                request.ContentType = "multipart/form-data; boundary=" + boundary;//获取token
                request.Method = "POST";
                request.KeepAlive = true;
                string format = "--" + boundary + "\r\nContent-Disposition:form-data;name=\"{0}\"\r\n\r\n{1}\r\n";    //自带项目分隔符
                MemoryStream stream = new MemoryStream();
                //以下添加服务器token验证键值对
                string s1 = string.Format(format, "client_id", "client.gate");
                string s2 = string.Format(format, "client_secret", "ETP.Gate.2018!");
                string s3 = string.Format(format, "grant_type", "client_credentials");
                string s4 = string.Format(format, "scope", "ETPApi");
                byte[] data1 = Encoding.UTF8.GetBytes(s1);
                byte[] data2 = Encoding.UTF8.GetBytes(s2);
                byte[] data3 = Encoding.UTF8.GetBytes(s3);
                byte[] data4 = Encoding.UTF8.GetBytes(s4);
                stream.Write(data1, 0, data1.Length);
                stream.Write(data2, 0, data2.Length);
                stream.Write(data3, 0, data3.Length);
                stream.Write(data4, 0, data4.Length);
                byte[] foot_data = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");      //项目最后的分隔符字符串需要带上--  
                stream.Write(foot_data, 0, foot_data.Length);
                request.ContentLength = stream.Length;
                Stream requestStream = request.GetRequestStream(); //写入请求
                stream.Position = 0L;
                //stream.CopyTo(requestStream); //framework4.0以上使用，改为以下方式写入
                byte[] array = new byte[81920];
                int count;
                while ((count = stream.Read(array, 0, array.Length)) != 0)
                {
                    requestStream.Write(array, 0, count);
                }
                stream.Close();
                requestStream.Close();

                //获取服务器返回
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        strJson = reader.ReadToEnd();
                        reader.Close();
                    }
                }
                var result= JsonConvert.DeserializeObject<TokenStyle>(strJson);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
        }
    }
}
