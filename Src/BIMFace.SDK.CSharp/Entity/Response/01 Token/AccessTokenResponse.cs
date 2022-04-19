﻿// /* ---------------------------------------------------------------------------------------
//    文件名：AccessTokenResponse.cs
//    文件功能描述：
// 
//    创建标识：20200308
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识： 
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity
{
    /// <summary>
    ///  获取 AccessToken 的请求返回结果类
    /// </summary>
    [Serializable]
    public class AccessTokenResponse : GeneralResponse<AccessTokenEntity>
    {
    }

    [Serializable]
    public class AccessTokenEntity
    {
        /// <summary>
        ///  token 的过期时间
        /// </summary>
        [JsonProperty("expireTime", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpireTime { get; set; }

        /// <summary>
        ///  token 内容值
        /// </summary>
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        /// <summary>返回表示当前对象的字符串。</summary>
        /// <returns>表示当前对象的字符串。</returns>
        public override string ToString()
        {
            return string.Format("AccessTokenEntity [token={0}, expireTime={1}]", Token, ExpireTime);
        }
    }
}