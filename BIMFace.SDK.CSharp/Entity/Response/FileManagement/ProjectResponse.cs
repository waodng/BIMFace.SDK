// /* ---------------------------------------------------------------------------------------
//    文件名：ProjectCreateResponse.cs
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

namespace BIMFace.SDK.CSharp.Entity
{
    /// <summary>
    /// 获取项目列表操作的返回类
    /// </summary>
    [Serializable]
    public class ProjectsGetResponse : GeneralResponse<List<ProjectEntity>>
    {

    }

    /// <summary>
    ///  项目操作的返回类
    /// </summary>
    [Serializable]
    public class ProjectResponse : GeneralResponse<ProjectEntity>
    {

    }

    [Serializable]
    public class ProjectEntity
    {
        /// <summary>
        /// hub编号
        /// </summary>
        [JsonProperty("hubId")]
        public string HubId { get; set; }

        /// <summary>
        /// 项目缩略图
        /// </summary>
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        /// <summary>
        /// 项目创建时间
        /// </summary>
        [JsonProperty("createTime")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 项目对应的AppKey
        /// </summary>
        [JsonProperty("appKey")]
        public string AppKey { get; set; }

        /// <summary>
        /// 项目更新时间
        /// </summary>
        [JsonProperty("updateTime")]
        public string UpdateTime { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// hub所属的租户
        /// </summary>
        [JsonProperty("tenantCode")]
        public string TenantCode { get; set; }

        /// <summary>
        ///  项目类型
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 项目信息
        /// </summary>
        [JsonProperty("info")]
        public string Info { get; set; }
    }
}