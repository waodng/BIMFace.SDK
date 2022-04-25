// /* ---------------------------------------------------------------------------------------
//    文件名：ClashDetectiveResponse.cs
//    文件功能描述：
// 
//    创建标识：20220424
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
    ///  碰撞检测操作返回的实体类
    /// </summary>
    [Serializable]
    public class ClashDetectiveResponse : GeneralResponse<ClashDetectiveEntity>
    {
    }

    [Serializable]
    public class ClashDetectiveEntity
    {

        /// <summary>
        /// 失败原因
        /// </summary>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }

        /// <summary>
        /// 碰撞检测ID
        /// </summary>
        [JsonProperty("clashDetectiveId", NullValueHandling = NullValueHandling.Ignore)]
        public long ClashDetectiveId { get; set; }

        /// <summary>
        ///  	创建时间
        /// </summary>
        [JsonProperty("createTime", NullValueHandling = NullValueHandling.Ignore)]
        public string CreateTime { get; set; }

        /// <summary>
        ///  	错误码
        /// </summary>
        [JsonProperty("errorCode", NullValueHandling = NullValueHandling.Ignore)]
        public long ErrorCode { get; set; }


        /// <summary>
        ///  	数据包版本
        /// </summary>
        [JsonProperty("databagVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string DatabagVersion { get; set; }

        /// <summary>
        ///  	任务状态
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }

}