// /* ---------------------------------------------------------------------------------------
//    文件名：ReviewModelRequest.cs
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


using System.Collections.Generic;

using Newtonsoft.Json;

namespace Gloden.Review.AI.BIM.SDK.CSharp.Entity
{
    /// <summary>
    /// 模型检查接口请求参数类
    /// </summary>
    public class ReviewModelRequest
    {
      
    }

    /// <summary>
    /// 文件信息
    /// </summary>
    public class FilesViewModel
    {
        public FilesViewModel()
        {
            Rules = new List<string>();
        }

        /// <summary>
        /// 【必填】审图系统中的图纸/模型编号
        /// </summary>
        [JsonProperty("fileId")]
        public string FileId { get; set; }

        /// <summary>
        /// 【必填】审图系统中的图纸/模型名称
        /// </summary>
        [JsonProperty("fileName")]
        public string FileName { get; set; }

        /// <summary>
        /// 【必填】图纸/模在BIMFACE引擎中的编号
        /// </summary>
        [JsonProperty("bimFaceFieldId")]
        public string BIMFaceFieldId { get; set; }

        /// <summary>
        /// 【必填】文件的网络地址。例如：http://www.abc.com/测试文件.rvt
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// 【必填】图纸/模型对应的审查专业编号
        /// </summary>
        [JsonProperty("sczyCode")]
        public string SczyCode { get; set; }

        /// <summary>
        /// 【选填】文件规则（拓展字段）
        /// </summary>
        [JsonProperty("rules")]
        public List<string> Rules { get; set; }
    }

    /// <summary>
    /// 规则信息
    /// </summary>
    public class RulesViewModel
    {
        /// <summary>
        /// 【必填】规则id
        /// </summary>
        [JsonProperty("ruleId")]
        public string RuleId { get; set; }

        /// <summary>
        /// 【选填】规则名称，示例：{"户门和安全出口的净宽度不应小于(m)":"0.90","疏散走道、首层疏散外门的净宽度不应小于(m)":"1.10"}
        /// </summary>
        [JsonProperty("ruleParam")]
        public Dictionary<string, string> RuleParam { get; set; }
    }

    /// <summary>
    /// 项目信息
    /// </summary>
    public class ProjectViewModel
    {
        /*参考文档：https://docs.qq.com/doc/DQmhwZmlEbGJmT0xQ */

        /// <summary>
        /// 【必填】名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 【必填】值
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// 【必填】类型
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
