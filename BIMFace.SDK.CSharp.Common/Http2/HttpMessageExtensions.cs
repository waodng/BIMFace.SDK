// /* ---------------------------------------------------------------------------------------
//    文件名：HttpMessageExtensions.cs
//    文件功能描述：
// 
//    创建标识：20210731
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识：
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using BIMFace.SDK.CSharp.Common.Extensions;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Common.Http2
{
    public static class HttpMessageExtensions
    {
        #region HttpRequestMessage

        public static void SetContentHeadersContentType(this HttpRequestMessage request, string contentType)
        {
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
        }

        public static async Task SetContentAsync(this HttpRequestMessage request, string body)
        {
            MemoryStream memoryStream = await CreateContentStream(body);
            request.Content = new StreamContent(memoryStream);
        }

        public static async Task SetContentAsync(this HttpRequestMessage request, Stream body)
        {
            MemoryStream memoryStream = await CreateContentStream(body);
            request.Content = new StreamContent(memoryStream);
        }

        public static async Task SetContentAsync(this HttpRequestMessage request, byte[] body)
        {
            MemoryStream memoryStream = await CreateContentStream(body);
            request.Content = new StreamContent(memoryStream);
        }

        private static async Task<MemoryStream> CreateContentStream(string body)
        {
            MemoryStream memoryStream = new MemoryStream();

            if (body != null)
            {
                StreamWriter streamWriter = new StreamWriter(memoryStream);
                await streamWriter.WriteAsync(body);
                await streamWriter.FlushAsync();
                memoryStream.Position = 0;
            }

            return memoryStream;
        }

        private static async Task<MemoryStream> CreateContentStream(Stream body)
        {
            return await CreateContentStream(body.ToByteArray());
        }

        private static async Task<MemoryStream> CreateContentStream(byte[] body)
        {
            MemoryStream memoryStream = new MemoryStream();

            if (body != null)
            {
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write(body);

                memoryStream.Flush();
                memoryStream.Position = 0;
            }

            return await Task.FromResult(memoryStream);
        }

        #endregion

        #region HttpResponseMessage

        /// <summary>
        /// 从Response中获取指定类型的对象
        /// </summary>
        /// <typeparam name="TResponse">应答对象类型</typeparam>
        /// <param name="response">应答消息</param>
        /// <param name="copy">是否以异步操作方式将 HTTP 内容序列化到内存缓冲区</param>
        /// <returns>应答对象</returns>
        public static async Task<TResponse> GetObjectAsync<TResponse>(this HttpResponseMessage response, bool copy = false)
        {
            if (response?.Content == null)
                return default;

            Stream stream = null;
            if (copy)
            {
                await response.Content.LoadIntoBufferAsync();
            }

            stream = await response.Content.ReadAsStreamAsync();

            if (typeof(TResponse) == typeof(string))
            {
                StreamReader streamReader = new StreamReader(stream);
                var str = (TResponse)(object)(await streamReader.ReadToEndAsync());
                stream.Position = 0;
                return str;
            }
            else if (typeof(TResponse) == typeof(HttpResponseMessage))
            {
                // 如果类型为HttpResponseMessage直接返回
                return (TResponse)(object)response;
            }
            else
            {
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    var strJsonContent = await streamReader.ReadToEndAsync();

                    return await strJsonContent.DeserializeFromBinaryAsync<TResponse>();
                }
            }
        }

        #endregion
    }
}