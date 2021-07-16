// /* ---------------------------------------------------------------------------------------
//    文件名：ModelCheckProgressResponse.cs
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

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Gloden.Review.AI.HY.SDK.CSharp.Entity
{
    /// <summary>
    ///  获取模型检查进度数据返回的结果类
    /// </summary>
    [Serializable]
    public class ModelCheckProgressResponse : GeneralResponse<List<ModelCheckProgressResponseModel>>
    {

    }

    [Serializable]
    public class ModelCheckProgressResponseModel
    {
        /// <summary>
        ///  批次Id
        /// </summary>
        [JsonProperty("review_id")]
        public string ReviewId { get; set; }

        /// <summary>
        ///  队列进度[1/20]
        /// </summary>
        [JsonProperty("mcQueuesProgress")]
        public string McQueuesProgress { get; set; }

        /// <summary>
        ///  审查开始时间
        /// </summary>
        [JsonProperty("review_start")]
        public DateTime ReviewStart { get; set; }

        /// <summary>
        ///  审查结束时间
        /// </summary>
        [JsonProperty("review_end")]
        public DateTime ReviewEnd { get; set; }

        /// <summary>
        ///  队列Id
        /// </summary>
        [JsonProperty("mc_queues_id")]
        public string McQueuesId { get; set; }

        /// <summary>
        ///  问题数量
        /// </summary>
        [JsonProperty("mc_question_count")]
        public int McQuestionCount { get; set; }

        /// <summary>
        ///  正确检查点 数量
        /// </summary>
        [JsonProperty("mc_right_checkpoint")]
        public int McRightCheckpoint { get; set; }

        /// <summary>
        /// 问题检查点 数量
        /// </summary>
        [JsonProperty("mc_question_checkpoint")]
        public int McQuestionCheckpoint { get; set; }

        /// <summary>
        ///  异常检查点 数量
        /// </summary>
        [JsonProperty("mc_error_checkpoint")]
        public int McErrorCheckpoint { get; set; }

        /// <summary>
        ///  检查状态。 队列中0、正在检查1、检查完成2、检查异常3
        /// </summary>
        [JsonProperty("check_status")]
        public int CheckStatus { get; set; }

        /// <summary>
        ///  检查状态的描述
        /// </summary>
        [JsonProperty("check_status_msg")]
        public string CheckStatusMsg { get; set; }

        /// <summary>
        ///  问题分组信息
        /// </summary>
        [JsonProperty("questionGroupModels")]
        public List<QuestionGroupModel> QuestionGroupModels { get; set; }

        [JsonProperty("checkQueuesDataViewModel")]
        public CheckQueuesDataViewModel CheckQueuesDataViewModel { get; set; }
    }

    [Serializable]
    public class QuestionGroupModel
    {
        /// <summary>
        ///  规范出处。如《建筑设计防火规范》GB50016-2014
        /// </summary>
        [JsonProperty("ruleOrigin")]
        public string RuleOrigin { get; set; }

        /// <summary>
        ///  规范出处出现的问题数
        /// </summary>
        [JsonProperty("ruleQuestionCount")]
        public int RuleQuestionCount { get; set; }
    }

    [Serializable]
    public class CheckQueuesDataViewModel
    {
        [JsonProperty("checkQueuesNumberViewModels")]
        public List<CheckQueuesNumberViewModels> CheckQueuesNumberViewModels { get; set; }

        [JsonProperty("queuesTotal")]
        public int QueuesTotal { get; set; }

    }

    [Serializable]
    public class CheckQueuesNumberViewModels
    {
        [JsonProperty("queuesGuid")]
        public string QueuesGuid { get; set; }

        [JsonProperty("batchGuid")]
        public string BatchGuid { get; set; }

        [JsonProperty("currentBatchGuidNumber")]
        public int CurrentBatchGuidNumber { get; set; }
    }
}
