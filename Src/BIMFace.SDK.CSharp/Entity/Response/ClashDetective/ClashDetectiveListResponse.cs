// /* ---------------------------------------------------------------------------------------
//    文件名：ClashDetectiveListResponse.cs
//    文件功能描述：
// 
//    创建标识：20220425
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
    ///     根据模型ID查询碰撞检测ID列表响应操作类
    /// </summary>
    [Serializable]
    public class ClashDetectiveListResponse : GeneralResponse<List<ClashDetectiveItem>>
    {
    }

    [Serializable]
    public class ClashDetectiveItem
    {
        /// <summary>
        ///     碰撞检测ID
        /// </summary>
        [JsonProperty("clashDetectiveId", NullValueHandling = NullValueHandling.Ignore)]
        public long ClashDetectiveId { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        [JsonProperty("createTime", NullValueHandling = NullValueHandling.Ignore)]
        public string CreateTime { get; set; }

        /// <summary>
        ///     选择集A的文件ID
        /// </summary>
        [JsonProperty("fileIdA", NullValueHandling = NullValueHandling.Ignore)]
        public long FileIdA { get; set; }

        /// <summary>
        ///     选择集B的文件ID
        /// </summary>
        [JsonProperty("fileIdB", NullValueHandling = NullValueHandling.Ignore)]
        public long FileIdB { get; set; }

        /// <summary>
        ///     选择集A的集成ID
        /// </summary>
        [JsonProperty("integrateIdA", NullValueHandling = NullValueHandling.Ignore)]
        public long IntegrateIdA { get; set; }

        /// <summary>
        ///     选择集B的集成ID
        /// </summary>
        [JsonProperty("integrateIdB", NullValueHandling = NullValueHandling.Ignore)]
        public long IntegrateIdB { get; set; }
    }
}