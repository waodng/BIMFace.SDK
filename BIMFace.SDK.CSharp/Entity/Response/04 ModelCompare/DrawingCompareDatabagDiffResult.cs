// /* ---------------------------------------------------------------------------------------
//    文件名：DrawingCompareDatabagDiffResult.cs
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

using Newtonsoft.Json;

using System.Collections.Generic;

namespace BIMFace.SDK.CSharp.Entity
{
    /// <summary>
    ///  解析图纸对比的数据包中的result.json内容类
    /// </summary>
    public class DrawingCompareDatabagDiffResult
    {
        /// <summary>
        ///  版本号
        /// </summary>
        [JsonProperty("ver", NullValueHandling = NullValueHandling.Ignore)]
        public string Ver { get; set; }

        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public Model Model { get; set; }
    }

    public class Model
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("additions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Addition> Additions { get; set; }

        [JsonProperty("deletions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Addition> Deletions { get; set; }

        [JsonProperty("modifications", NullValueHandling = NullValueHandling.Ignore)]
        public List<Modification> Modifications { get; set; }
    }

    /// <summary>
    /// 增加的图元项信息
    /// </summary>
    public class Addition : DiffItem
    {

    }

    /// <summary>
    /// 删除的图元项
    /// </summary>
    public class Deletion : DiffItem
    {

    }

    /// <summary>
    /// 修改的图元
    /// </summary>
    public class Modification
    {
        /// <summary>
        ///  前一版本的Layer
        /// </summary>
        [JsonProperty("previousLayer", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousLayer { get; set; }

        /// <summary>
        ///  当前版本的Layer
        /// </summary>
        [JsonProperty("currentLayer", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentLayer { get; set; }

        /// <summary>
        /// 图元ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 前一版本的图框对象
        /// </summary>
        [JsonProperty("previousFrame", NullValueHandling = NullValueHandling.Ignore)]
        public Frame PreviousFrame { get; set; }

        /// <summary>
        /// 当前版本的图框对象
        /// </summary>
        [JsonProperty("currentFrame", NullValueHandling = NullValueHandling.Ignore)]
        public Frame CurrentFrame { get; set; }
    }

    /// <summary>
    ///  差异项
    /// </summary>

    public class DiffItem
    {
        /// <summary>
        /// 图层名称
        /// </summary>
        [JsonProperty("layer", NullValueHandling = NullValueHandling.Ignore)]
        public string Layer { get; set; }

        /// <summary>
        ///  图元ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        ///  图框的名称
        /// </summary>
        [JsonProperty("frame", NullValueHandling = NullValueHandling.Ignore)]
        public Frame Frame { get; set; }
    }

    /// <summary>
    /// 图框信息类
    /// </summary>
    public class Frame
    {
        /// <summary>
        ///  图框序号
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        ///  图框名称
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        ///  图框编号
        /// </summary>
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public string Number { get; set; }
    }
}
