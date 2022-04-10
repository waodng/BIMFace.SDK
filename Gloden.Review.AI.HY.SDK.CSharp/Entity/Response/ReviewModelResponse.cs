// /* ---------------------------------------------------------------------------------------
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

namespace BIMFace.AIReview.BIM.SDK.CSharp.Entity
{
    /// <summary>
    ///  模型检查返回的结果类
    /// </summary>
    public class ReviewModelResponse : GeneralResponse<ReviewModelResponseModel>
    {
    }

    public class ReviewModelResponseModel
    {
        /// <summary>
        /// -100 未检查 、-1 文件下载异常 、-2 同批次文件版本不一致、-3 发送消息异常、-99 接口异常、0 队列中、1 正在检查、2 检查完成、3 检查异常
        /// </summary>
        [JsonProperty("checkStatusMsg")]
        public string CheckStatusMsg { get; set; }

        /// <summary>
        /// -100 未检查 、-1 文件下载异常 、-2 同批次文件版本不一致、-3 发送消息异常、-99 接口异常、0 队列中、1 正在检查、2 检查完成、3 检查异常
        /// </summary>
        [JsonProperty("checkStatus")]
        public int CheckStatus { get; set; }

        [JsonProperty("checkStatusTag")]
        public string CheckStatusTag { get; set; }

        [JsonProperty("isCheckRetry")]
        public bool IsCheckRetry { get; set; }

        [JsonProperty("checkStatusTotal")]
        public int CheckStatusTotal { get; set; }

        [JsonProperty("queuesGuid")]
        public string QueuesGuid { get; set; }

        [JsonProperty("batchGuid")]
        public string BatchGuid { get; set; }

        [JsonProperty("checkStatusCount")]
        public int CheckStatusCount { get; set; }
    }
}
