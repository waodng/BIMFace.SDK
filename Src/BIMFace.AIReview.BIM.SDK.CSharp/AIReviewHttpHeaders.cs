﻿// /* ---------------------------------------------------------------------------------------
//    文件名：ReviewAIHttpHeaders.cs
//    文件功能描述：
// 
//    创建标识：20210715
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识： 
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System.Net;

namespace BIMFace.AIReview.BIM.SDK.CSharp
{
    /// <summary>
    ///  调用智能审图相关API时，需要放置在 http header 中的参数集合类
    /// </summary>
    public class AIReviewHttpHeaders : WebHeaderCollection
    {
        public const string AUTHORIZATION = "Authorization";
        public const string CACHE_CONTROL = "Cache-Control";
        public const string CONTENT_DISPOSITION = "Content-Disposition";
        public const string CONTENT_ENCODING = "Content-Encoding";
        public const string CONTENT_LENGTH = "Content-Length";
        public const string CONTENT_MD5 = "Content-MD5";
        public const string CONTENT_TYPE = "Content-Type";
        public const string TRANSFER_ENCODING = "Transfer-Encoding";
        public const string DATE = "Date";
        public const string ETAG = "ETag";
        public const string EXPIRES = "Expires";
        public const string HOST = "Host";
        public const string LAST_MODIFIED = "Last-Modified";
        public const string RANGE = "Range";
        public const string LOCATION = "Location";
        public const string CONNECTION = "Connection";


        /// <summary>
        ///     header 里添加授权 Authorization 的 Bearer 认证
        /// </summary>
        /// <param name="token">【必填】登录认证后获取到的authorization值 </param>
        public virtual void AddOAuth2Header(string token)
        {
            Add(AUTHORIZATION, "Bearer " + token);
        }
    }
}
