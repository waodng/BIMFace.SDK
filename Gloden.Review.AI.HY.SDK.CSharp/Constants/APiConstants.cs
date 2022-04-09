// /* ---------------------------------------------------------------------------------------
//    文件名：APiConstants.cs
//    文件功能描述：API接口地址常量
// 
//    创建标识：20210715
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识： 
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System.Configuration;

using BIMFace.SDK.CSharp.Common.Exceptions;

namespace Gloden.Review.AI.HY.SDK.CSharp
{
    /// <summary>
    ///  API常量
    /// </summary>
    public class APiConstants
    {
        /// <summary>
        ///  API服务器地址
        /// </summary>
        //public const string API_HOST = "https://api.bimface.com";//20210112 mark by zcn 改为配置方式。主要考虑到私有化部署时，API地址变更的问题。

        public static string API_HOST
        {
            get
            {
                var apiHost = ConfigurationManager.AppSettings["REVIEW_AI_API_HOST"].Trim();
                if (string.IsNullOrWhiteSpace(apiHost))
                    throw new Configuration2Exception("请在 web.config 或 app.config 中配置 REVIEW_AI_API_HOST。" );

                return apiHost;
            }
        }


        public static string SERVICE_KEY
        {
            get
            {
                var apiHost = ConfigurationManager.AppSettings["REVIEW_AI_SERVICE_KEY"].Trim();
                if (string.IsNullOrWhiteSpace(apiHost))
                    throw new Configuration2Exception("请在 web.conig 或 app.conifg 中配置 REVIEW_AI_SERVICE_KEY。");

                return apiHost;
            }
        }

        public static string SERVICE_SECRET
        {
            get
            {
                var apiHost = ConfigurationManager.AppSettings["REVIEW_AI_SERVICE_SECRET"].Trim();
                if (string.IsNullOrWhiteSpace(apiHost))
                    throw new Configuration2Exception("请在 web.conig 或 app.conifg 中配置 REVIEW_AI_SERVICE_SECRET。");

                return apiHost;
            }
        }

    }
}
