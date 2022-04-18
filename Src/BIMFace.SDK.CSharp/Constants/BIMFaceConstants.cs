// /* ---------------------------------------------------------------------------------------
//    文件名：BIMFaceConstants.cs
//    文件功能描述：
// 
//    创建标识：20200308
//    作   者：张传宁 （QQ：905442693  微信：savionzhang）  
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识： 
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System.Configuration;

using BIMFace.SDK.CSharp.Common.Exceptions;

namespace BIMFace.SDK.CSharp.Constants
{
    /// <summary>
    ///     Bimface常量
    /// </summary>
    public class BIMFaceConstants
    {
        private static string _apiHost = string.Empty;
        private static string _fileHost = string.Empty;

        /// <summary>
        ///  API服务器地址。
        /// <para>公有云返回 https://api.bimface.com 。私有云返回自定义配置地址</para>
        /// </summary>
        public static string API_HOST
        {
#if NETCOREAPP3_1_OR_GREATER

            get { return _apiHost; }

#else
            get
            {
                _apiHost = ConfigurationManager.AppSettings["BIMFACE_API_HOST"].Trim();
                if (string.IsNullOrWhiteSpace(_apiHost))
                    throw new Configuration2Exception("请在 web.config 或 app.config 中配置 BIMFACE_API_HOST。\r\n" +
                        "如果采用BIMFACE公有云，请填写 https://api.bimface.com \r\n" +
                        "如果采用BIMFACE私有化部署，请填写部署时自定义地址。");

                return _apiHost;
            }
#endif

            set { _apiHost = value; }
        }

        /// <summary>
        ///  文件上传API服务器地址。
        /// <para>公有云返回 https://file.bimface.com 。私有云返回自定义配置地址</para>
        /// </summary>
        public static string FILE_HOST
        {
#if NETCOREAPP3_1_OR_GREATER

            get { return _fileHost; }

#else
            get
            {
                _fileHost = ConfigurationManager.AppSettings["BIMFACE_FILE_HOST"].Trim();
                if (string.IsNullOrWhiteSpace(_fileHost))
                    throw new Configuration2Exception("请在 web.config 或 app.config 中配置 BIMFACE_FILE_HOST。\r\n" +
                        "如果采用BIMFACE公有云，请填写 https://file.bimface.com \r\n" +
                        "如果采用BIMFACE私有化部署，请填写部署时自定义地址。");

                return _fileHost;
            }
#endif
            set { _fileHost = value; }
        }

        /// <summary>
        ///  BIMFACE 控制台地址
        /// </summary>
        public const string REFERENCE_HOST = "http://bimface.com/user-console";

        public const string STREAM_MIME = "application/octet-stream";
        public const string JSON_MIME = "application/json";
        public const string FORM_MIME = "application/x-www-form-urlencoded";

        /// <summary>
        /// 断点上传时的分块大小(默认的分块大小, 不允许改变)
        /// </summary>
        public const int BLOCK_SIZE = 4 * 1024 * 1024;

        /// <summary>
        ///  最大空闲连接数
        /// </summary>
        public const int DEFAULT_MAX_IDLE_CONNECTIONS = 32;

        /// <summary>
        /// 保持活动周期时长
        /// </summary>
        public const long DEFAULT_KEEP_ALIVE_DURATION_NS = 5 * 60 * 1000;

        /// <summary>
        /// 最大请求数
        /// </summary>
        public const int DEFAULT_MAX_REQUESTS = 64;

        /// <summary>
        /// 每台主机最大的请求数
        /// </summary>
        public const int DEFAULT_MAX_REQUESTS_PER_HOST = 5;

        /// <summary>
        /// 连接超时时间 单位秒(默认10000 ms)
        /// </summary>
        public const int DEFAULT_CONNECT_TIMEOUT = 100000;

        /// <summary>
        /// 写超时时间 单位秒(默认 0 ms , 不超时)
        /// </summary>
        public const int DEFAULT_WRITE_TIMEOUT = 0;

        /// <summary>
        /// 读写超时时间 单位秒(默认 0 ms , 不超时)
        /// </summary>
        public const int DEFAULT_READ_WRITE_TIMEOUT = 100000;

        /// <summary>c
        /// 回复超时时间 单位秒(默认30000 ms)
        /// </summary>
        public const int DEFAULT_RESPONSE_TIMEOUT = 30000000;

        /// <summary>
        /// 默认字符集编码
        /// </summary>
        public static readonly int UTF_8 = 65001;

        public static readonly string MEDIA_TYPE_JSON = "application/json; charset=utf-8";

        /// <summary>
        /// 如果文件大小大于此值则使用断点上传, 否则使用Form上传
        /// </summary>
        public static int PUT_THRESHOLD = BLOCK_SIZE;
    }
}