﻿// /* ---------------------------------------------------------------------------------------
//    文件名：LoginResponse.cs
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

using Newtonsoft.Json;

namespace Gloden.Review.AI.HY.SDK.CSharp.Entity
{
    /// <summary>
    ///  模型检查返回的结果类
    /// </summary>
    public class ReviewModelResponse : GeneralResponse<ReviewModelResponseModel>
    {
    }

    public class ReviewModelResponseModel
    {
        [JsonProperty("queuesGuid")]
        public string QueuesGuid { get; set; }

        [JsonProperty("batchGuid")]
        public string batchGuid { get; set; }

        [JsonProperty("currentBatchGuidNumber")]
        public int currentBatchGuidNumber { get; set; }

        [JsonProperty("operateMsg")]
        public string OperateMsg { get; set; }

        [JsonProperty("operateState")]
        public int OperateState { get; set; }

        [JsonProperty("queuesTotal")]
        public int QueuesTotal { get; set; }
    }
}
