// /* ---------------------------------------------------------------------------------------
//    文件名：HubsResponse.cs
//    文件功能描述：
// 
//    创建标识：20220410
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识：
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity.Response
{
    /// <summary>
    ///  查询开发者账号已注册的存储中心（Hub）返回的结果类
    /// </summary>
    [Serializable]
    public class HubsResponse : GeneralResponse<List<HubEntity>>
    {

    }

    /// <summary>
    ///  获取Hub Meta信息返回的结果类
    /// </summary>
    [Serializable]
    public class HubMetaResponse : GeneralResponse<HubEntity>
    {

    }

    [Serializable]
    public class HubEntity
    {
        /// <summary>
        /// hub创建时间
        /// </summary>
        [JsonProperty("createTime")]
        public string CreateTime { get; set; }

        /// <summary>
        /// hub名字
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// hub对应的AppKey
        /// </summary>
        [JsonProperty("appKey")]
        public string AppKey { get; set; }

        /// <summary>
        /// hub更新时间
        /// </summary>
        [JsonProperty("updateTime")]
        public string UpdateTime { get; set; }

        /// <summary>
        /// hub编号
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// hub所属的租户
        /// </summary>
        [JsonProperty("tenantCode")]
        public string TenantCode { get; set; }

        /// <summary>
        /// hub说明
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }
    }
}