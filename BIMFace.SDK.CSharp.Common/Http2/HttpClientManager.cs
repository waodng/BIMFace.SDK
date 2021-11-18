// /* ---------------------------------------------------------------------------------------
//    文件名：HttpClientManager.cs
//    文件功能描述：
// 
//    创建标识：20210726
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识：
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Http;

namespace BIMFace.SDK.CSharp.Common.Http2
{
    /// <summary>
    ///  基于 HttpClient 类封装的 HTTP 请求与响应辅助类（上传或下载普通文本、数据流、文件等）
    /// </summary>
    public class HttpClientManager
    {
        /*
         * 【附】微软官方关于 System.Net.HttpWebRequest 与 System.Net.Http.HttpClient 的说明：
           
         *  https://docs.microsoft.com/zh-cn/dotnet/api/system.net.httpwebrequest#remarks
         *  https://docs.microsoft.com/zh-cn/dotnet/api/system.net.http.httpclient#httpclient-and-net-core）
         */

        /* 
         * 特别提醒：HttpClient 用于在应用程序的整个生存期内实例化一次并重复使用。
         *         实例化每个请求的 HttpClient 类将耗尽重负载下可用的插槽数。 这将导致 SocketException 错误。
         * 具体请参考微软文档：https://docs.microsoft.com/zh-cn/dotnet/api/system.net.http.httpclient?view=net-5.0
         */

        #region 字段属性

        /// <summary>
        ///  获取或设置与请求或响应关联的协议标头
        /// </summary>
        public WebHeaderCollection HeaderCollection { get; set; }

        /// <summary>
        ///  获取或设置解析网页源码时使用的编码，默认
        /// </summary>
        /// <value></value>
        public Encoding EncodingType { get; set; }

        #endregion

        #region 构造函数

        public HttpClientManager()
        {
            EncodingType = Encoding.UTF8;
            HeaderCollection = new WebHeaderCollection();
        }

        public HttpClientManager(WebHeaderCollection headerCollection)
        {
            EncodingType = Encoding.UTF8;
            HeaderCollection = headerCollection;
        }

        #endregion

        #region (不包含body数据) GET、POST、Put、Delete 请求

        /// <summary>
        /// HTTP-GET方法，(不包含body数据)。
        /// 发送 HTTP 请求并返回来自 Internet 资源的响应(HTML代码)
        /// </summary>
        /// <param name="url">请求目标URL</param>
        /// <returns>HTTP-GET的响应结果</returns>
        public async Task<HttpResult> GetAsync(string url)
        {
            return await RequestStringAsync(url, string.Empty, HttpMethodValues.GET);
        }

        /// <summary>
        /// HTTP-POST方法，(不包含body数据)。
        /// 发送 HTTP 请求并返回来自 Internet 资源的响应(HTML代码)
        /// </summary>
        /// <param name="url">请求目标URL</param>
        /// <returns>HTTP-POST的响应结果</returns>
        public async Task<HttpResult> PostAsync(string url)
        {
            return await RequestStringAsync(url, string.Empty, HttpMethodValues.POST);
        }

        /// <summary>
        /// HTTP-PUT方法，(不包含body数据)。
        /// 发送 HTTP 请求并返回来自 Internet 资源的响应(HTML代码)
        /// </summary>
        /// <param name="url">请求目标URL</param>
        /// <returns>HTTP-POST的响应结果</returns>
        public async Task<HttpResult> PutAsync(string url)
        {
            return await RequestStringAsync(url, string.Empty, HttpMethodValues.PUT);
        }

        /// <summary>
        /// HTTP-DELETE方法，(不包含body数据)。
        /// 发送 HTTP 请求并返回来自 Internet 资源的响应(HTML代码)
        /// </summary>
        /// <param name="url">请求目标URL</param>
        /// <returns>HTTP-POST的响应结果</returns>
        public async Task<HttpResult> DeleteAsync(string url)
        {
            return await RequestStringAsync(url, string.Empty, HttpMethodValues.DELETE);
        }

        #endregion

        #region (包含文本的body数据) GET、POST、Put、Delete 请求

        /// <summary>
        /// HTTP-GET方法，(包含body数据)。
        /// 发送 HTTP 请求并返回来自 Internet 资源的响应(HTML代码)
        /// </summary>
        /// <param name="url">请求目标URL</param>
        /// <param name="data">主体数据(普通文本或者JSON文本)。如果参数中有中文，请使用合适的编码方式进行编码，例如：gb2312或者utf-8</param>
        /// <param name="contentType"><see langword="Content-type" /> HTTP 标头的值。请使用 HttpContentType 类的常量来获取</param>
        /// <returns>HTTP-GET的响应结果</returns>
        public async Task<HttpResult> GetAsync(string url, string data, string contentType = HttpContentType.APPLICATION_JSON)
        {
            return await RequestStringAsync(url, data, HttpMethodValues.GET, contentType);
        }

        /// <summary>
        /// HTTP-POST方法，(包含body数据)。
        /// 发送 HTTP 请求并返回来自 Internet 资源的响应(HTML代码)
        /// </summary>
        /// <param name="url">请求目标URL</param>
        /// <param name="data">主体数据(普通文本或者JSON文本)。如果参数中有中文，请使用合适的编码方式进行编码，例如：gb2312或者utf-8</param>
        /// <param name="contentType"><see langword="Content-type" /> HTTP 标头的值。请使用 HttpContentType 类的常量来获取</param>
        /// <returns>HTTP-POST的响应结果</returns>
        public async Task<HttpResult> PostAsync(string url, string data, string contentType = HttpContentType.APPLICATION_JSON)
        {
            return await RequestStringAsync(url, data, HttpMethodValues.POST, contentType);
        }

        /// <summary>
        /// HTTP-PUT方法，(包含body数据)。
        /// 发送 HTTP 请求并返回来自 Internet 资源的响应(HTML代码)
        /// </summary>
        /// <param name="url">请求目标URL</param>
        /// <param name="data">主体数据(普通文本或者JSON文本)。如果参数中有中文，请使用合适的编码方式进行编码，例如：gb2312或者utf-8</param>
        /// <param name="contentType"><see langword="Content-type" /> HTTP 标头的值。请使用 HttpContentType 类的常量来获取</param>
        /// <returns>HTTP-POST的响应结果</returns>
        public async Task<HttpResult> PutAsync(string url, string data, string contentType = HttpContentType.APPLICATION_JSON)
        {
            return await RequestStringAsync(url, data, HttpMethodValues.PUT, contentType);
        }

        /// <summary>
        /// HTTP-DELETE方法，(包含body数据)。
        /// 发送 HTTP 请求并返回来自 Internet 资源的响应(HTML代码)
        /// </summary>
        /// <param name="url">请求目标URL</param>
        /// <param name="data">主体数据(普通文本或者JSON文本)。如果参数中有中文，请使用合适的编码方式进行编码，例如：gb2312或者utf-8</param>
        /// <param name="contentType"><see langword="Content-type" /> HTTP 标头的值。请使用 HttpContentType 类的常量来获取</param>
        /// <returns>HTTP-POST的响应结果</returns>
        public async Task<HttpResult> DeleteAsync(string url, string data, string contentType = HttpContentType.APPLICATION_JSON)
        {
            return await RequestStringAsync(url, data, HttpMethodValues.DELETE, contentType);
        }

        #endregion

        #region Request

        /// <summary>
        ///  HTTP请求(包含文本的body数据)
        /// </summary>
        /// <param name="url">【必填】请求目标URL</param>
        /// <param name="data">主体数据(普通文本或者JSON文本)。如果参数中有中文，请使用合适的编码方式进行编码，例如：gb2312或者utf-8</param>
        /// <param name="method">【必填】请求的方法。请使用 HttpMethodValues 类中的常量值</param>
        /// <param name="contentType"><see langword="Content-type" /> HTTP 标头的值。请使用 HttpContentType 类的常量来获取</param>
        /// <returns></returns>
        private async Task<HttpResult> RequestStringAsync(string url, string data, string method, string contentType = HttpContentType.APPLICATION_JSON)
        {
            HttpResult httpResult = new HttpResult();
            HttpClient client = new HttpClient();
          
            try
            {
                //// HttpRequestMessage request; //= await CreateHttpRequestMessage(method, url, data, null, HeaderCollection, contentType);

                HttpMethod httpMethod = new HttpMethod(method);
                HttpRequestMessage request = new HttpRequestMessage(httpMethod, url);

                MemoryStream memoryStream = new MemoryStream();

                if (data != null)
                {
                    StreamWriter streamWriter = new StreamWriter(memoryStream);
                    await streamWriter.WriteAsync(data);
                    await streamWriter.FlushAsync();
                    memoryStream.Position = 0;
                }

                request.Content = new StreamContent(memoryStream);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(HttpContentType.APPLICATION_JSON);
                request.Headers.Add("Authorization", "Basic eFpuVzJ5V2g1MXJCVkJJOXBZRldrbDdOVXczMXY0bnc6NURWbFEwMXpuVUtKcnRjTGNjQnRiVGpOWlZsOXNnejg=");

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();

                string result = response.Content.ReadAsStringAsync().Result;

                httpResult =  await result.DeserializeJsonToObjectAsync<HttpResult>();
                
                await response.GetObjectAsync<HttpResult>();
            }
            catch (HttpRequestException exception)
            {
                return null;
            }
            catch (Exception ex)
            {
                GetExceptionResponse(httpResult, ex, method, contentType);
            }

            return httpResult;
        }

        /// <summary>
        ///  HTTP请求(包含文本的body数据)
        /// </summary>
        /// <param name="url">【必填】请求目标URL</param>
        /// <param name="data">主体数据(普通文本或者JSON文本)。如果参数中有中文，请使用合适的编码方式进行编码，例如：gb2312或者utf-8</param>
        /// <param name="method">【必填】请求的方法。请使用 HttpMethodValues 类中的常量值</param>
        /// <param name="contentType"><see langword="Content-type" /> HTTP 标头的值。请使用 HttpContentType 类的常量来获取</param>
        /// <returns></returns> 
        private async Task<HttpResult> RequestDataAsync(string url, byte[] data, string method, string contentType = HttpContentType.APPLICATION_JSON)
        {
            HttpResult httpResult = new HttpResult();
            HttpClient client = new HttpClient();

            try
            {
                HttpRequestMessage request = await CreateHttpRequestMessage(method, url, data, null, HeaderCollection, contentType);
                HttpResponseMessage response = await client.SendAsync(request);

                httpResult = await response.GetObjectAsync<HttpResult>();
            }
            catch (HttpRequestException exception)
            {
                // GetWebExceptionResponse(httpResult, webException);
                HttpStatusCode statusCode;

                if (exception.Message.Contains("401 (Unauthorized)"))
                { statusCode = HttpStatusCode.Unauthorized; }
                else if (exception.Message.Contains("403 (Forbidden)"))
                { statusCode = HttpStatusCode.Forbidden; }
                else if (exception.Message.Contains("404 (Forbidden)"))
                { statusCode = HttpStatusCode.NotFound; }

                return null;
            }
            catch (Exception ex)
            {
                GetExceptionResponse(httpResult, ex, method, contentType);
            }

            return httpResult;
        }


        private void GetRequestException(HttpResult httpResult, HttpRequestException exceptionn)
        {
            //if (exceptionn != null)
            //{
            //    httpResult.HttpWebResponse = null;
            //    httpResult.Status = HttpResult.STATUS_FAIL;
            //    httpResult.StatusDescription = exResponse.StatusDescription;
            //    httpResult.StatusCode = (int)exResponse.StatusCode;

            //    httpResult.RefCode = httpResult.StatusCode;
            //    using (StreamReader sr = new StreamReader(exResponse.GetResponseStream(), EncodingType))
            //    {
            //        httpResult.Text = sr.ReadToEnd();
            //        httpResult.RefText = httpResult.Text;
            //    }

            //    exResponse.Close();
            //}
            //else
            //{
            //    httpResult.HttpWebResponse = null;
            //    httpResult.Status = HttpResult.STATUS_FAIL;
            //    httpResult.StatusDescription = webException.Message;
            //    httpResult.StatusCode = 500;

            //    httpResult.RefCode = httpResult.StatusCode;
            //    httpResult.Text = null;
            //    httpResult.RefText = webException.Message;
            //}
        }

        /// <summary>
        ///  将数据缓冲区(一般是指文件流或内存流对应的字节数组)上载到由 URI 标识的资源。(包含body数据)
        /// </summary>
        /// <param name="url">请求目标URL</param>
        /// <param name="data">主体数据(字节数据)。如果没有请传递null</param>
        /// <param name="method">请求的方法。请使用 HttpMethod 的枚举值</param>
        /// <param name="contentType"><see langword="Content-type" /> HTTP 标头的值。请使用 ContentType 类的常量来获取。默认为 application/octet-stream</param>
        /// <returns>HTTP-POST的响应结果</returns>
        private HttpResult RequestData(string url, byte[] data, string method = HttpMethodValues.POST,
                                       string contentType = HttpContentType.APPLICATION_OCTET_STREAM)
        {
            return null;
        }

        #endregion

        #region HttpMessage

        private async Task<HttpRequestMessage> CreateHttpRequestMessage(string method, string url, string body, NameValueCollection queryParameterKeyValues = null, NameValueCollection headers = null, string contentType = HttpContentType.APPLICATION_JSON)
        {
            url = BuildUrl(url, queryParameterKeyValues);
            HttpMethod httpMethod = new HttpMethod(method);

            HttpRequestMessage request = new HttpRequestMessage(httpMethod, url);
            await request.SetContentAsync(body);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
           
            SetHeaders(request, headers);
            return request;
        }

        private async Task<HttpRequestMessage> CreateHttpRequestMessage(string method, string url, byte[] body, NameValueCollection queryParameterKeyValues = null, NameValueCollection headers = null, string contentType = HttpContentType.APPLICATION_OCTET_STREAM)
        {
            url = BuildUrl(url, queryParameterKeyValues);
            HttpMethod httpMethod = new HttpMethod(method);

            HttpRequestMessage request = new HttpRequestMessage(httpMethod, url);
            await request.SetContentAsync(body);
            request.SetContentHeadersContentType(contentType);
            SetHeaders(request, headers);
            return request;
        }

        private async Task<HttpRequestMessage> CreateHttpRequestMessage(string method, string url, Stream body, NameValueCollection queryParameterKeyValues = null, NameValueCollection headers = null, string contentType = HttpContentType.APPLICATION_OCTET_STREAM)
        {
            return await CreateHttpRequestMessage(method, url, body.ToByteArray(), queryParameterKeyValues, headers, contentType);
        }

        private async Task<HttpRequestMessage> CreateHttpRequestMessage(string method, string url, HttpRequestMessage requestMessage, NameValueCollection queryParameterKeyValues = null, NameValueCollection headers = null)
        {
            url = BuildUrl(url, queryParameterKeyValues);
            HttpMethod httpMethod = new HttpMethod(method);

            if (requestMessage != null)
            {
                requestMessage.RequestUri = new Uri(url);
                requestMessage.Method = httpMethod;
                SetHeaders(requestMessage, headers);
                return await Task.FromResult(requestMessage);
            }

            return null;
        }

        #endregion

        #region HttpMessage

        #endregion

        #region 辅助方法

        /// <summary>
        ///  构建 HttpHeader 请求头
        /// </summary>
        /// <param name="request">Http请求对象</param>
        /// <param name="headers">请求头集合</param>
        private void SetHeaders(HttpRequestMessage request, NameValueCollection headers)
        {
            if (request == null || headers == null)
                return;

            var keys = headers.AllKeys;
            foreach (string key in keys)
            {
                request.Headers.Add(key, headers[key]);
            }
        }

        /// <summary>
        ///  构建完整的 url 字符串，包含参数
        /// </summary>
        /// <param name="url">不包含查询参数的url</param>
        /// <param name="queryParameters">查询参数键值对集合</param>
        /// <returns></returns>
        public string BuildUrl(string url, NameValueCollection queryParameters)
        {
            if (queryParameters != null && queryParameters.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                List<string> keys = queryParameters.AllKeys.ToList();
                foreach (string key in keys)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append("&");
                    }
                    sb.Append(key).Append("=");

                    if (string.IsNullOrEmpty(queryParameters[key]) == false)
                    {
                        //将键值对的值进行编码，防止出现乱码以及值中包含特殊字符串&会分隔参数的情况
                        sb.Append(System.Net.WebUtility.UrlEncode(queryParameters[key]));
                    }
                }

                if (url.Contains("?"))
                {
                    url = url + "&" + sb.ToString();
                }
                else
                {
                    url = url + "?" + sb.ToString();
                }
            }

            return url;
        }

        /// <summary>
        /// 获取HTTP的异常响应信息
        /// </summary>
        /// <param name="httpResult">即将被HTTP请求封装函数返回的HttpResult变量</param>
        /// <param name="ex">异常对象</param>
        /// <param name="method">HTTP请求的方式</param>
        /// <param name="contentType">HTTP的标头类型</param>
        private void GetExceptionResponse(HttpResult httpResult, Exception ex, string method, string contentType = "")
        {
            contentType = string.IsNullOrWhiteSpace(contentType) ? string.Empty : "-" + contentType;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[{0}] [HTTP-" + method + contentType + "] Error:  ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"));

            sb.AppendLine(ex.GetAllExceptionMessage());

            //httpResult.HttpWebResponse = null;
            httpResult.Status = HttpResult.STATUS_FAIL;

            httpResult.RefCode = (int)HttpStatusCode2.USER_UNDEF;
            httpResult.RefText += sb.ToString();
        }


        #endregion
    }


}