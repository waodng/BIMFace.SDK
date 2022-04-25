// /* ---------------------------------------------------------------------------------------
//    文件名：ClashDetectiveResult.cs
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
    /// 获取碰撞检测结果响应的结果类
    /// </summary>

    [Serializable]
    public class ClashDetectiveResultResponse : GeneralResponse<ClashDetectiveResult>
    {

    }


    [Serializable]
    public class ClashDetectiveResult
    {
        /// <summary>
        ///  碰撞类型，"Hard"为硬碰撞，"Clearance"为间隙碰撞
        /// </summary>
        [JsonProperty("clashType", NullValueHandling = NullValueHandling.Ignore)]
        public string ClashType { get; set; }

        /// <summary>
        /// 碰撞公差
        /// </summary>
        [JsonProperty("tolerance", NullValueHandling = NullValueHandling.Ignore)]
        public double Tolerance { get; set; }

        /// <summary>
        /// 选择集A
        /// </summary>
        [JsonProperty("selectionA", NullValueHandling = NullValueHandling.Ignore)]
        public ClashDetectiveSource SelectionA { get; set; }

        /// <summary>
        /// 选择集B
        /// </summary>
        [JsonProperty("selectionB", NullValueHandling = NullValueHandling.Ignore)]
        public ClashDetectiveSource SelectionB { get; set; }


        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public List<ClashDetectiveResultItem> Results { get; set; }
    }

    [Serializable]
    public class ClashDetectiveResultItem
    {
        /// <summary>
        ///  碰撞ID
        /// </summary>
        [JsonProperty("clashId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClashId { get; set; }

        /// <summary>
        ///  选择集A的构件ID
        /// </summary>
        [JsonProperty("objectIdA", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectIdA { get; set; }

        /// <summary>
        ///  选择集B的构件ID
        /// </summary>
        [JsonProperty("objectIdB", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectIdB { get; set; }

        /// <summary>
        ///  碰撞位置
        /// </summary>
        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public Position Position { get; set; }
    }

    [Serializable]
    public class Position
    {
        /// <summary>
        /// 碰撞位置，X坐标
        /// </summary>
        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public double X { get; set; }

        /// <summary>
        /// 碰撞位置，Y坐标
        /// </summary>
        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public double Y { get; set; }

        /// <summary>
        /// 碰撞位置，Z坐标
        /// </summary>
        [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
        public double Z { get; set; }
    }
}