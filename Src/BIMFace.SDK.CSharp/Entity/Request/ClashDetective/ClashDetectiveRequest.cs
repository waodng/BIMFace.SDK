// /* ---------------------------------------------------------------------------------------
//    文件名：ClashDetectiveRequest.cs
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

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity
{
    public class ClashDetectiveRequest
    {
        /// <summary>
        ///  选择集A
        /// </summary>
        [JsonProperty("selectionA", NullValueHandling = NullValueHandling.Ignore)]
        public ClashDetectiveSource SelectionA { get; set; }

        /// <summary>
        ///  选择集B
        /// </summary>
        [JsonProperty("selectionB", NullValueHandling = NullValueHandling.Ignore)]
        public ClashDetectiveSource SelectionB { get; set; }

        /// <summary>
        /// 碰撞类型，"Hard"为硬碰撞，"Clearance"为间隙碰撞
        /// </summary>
        [JsonProperty("clashType", NullValueHandling = NullValueHandling.Ignore)]
        public string ClashType { get; set; }

        /// <summary>
        /// 碰撞公差，单位为mm（精确到0.1），仅间隙碰撞支持设置公差，当间隙小于等于公差时视为碰撞
        /// </summary>
        [JsonProperty("tolerance", NullValueHandling = NullValueHandling.Ignore)]
        public double? Tolerance { get; set; }

        /// <summary>
        ///  	回调url
        /// </summary>
        [JsonProperty("callback", NullValueHandling = NullValueHandling.Ignore)]
        public string Callback { get; set; }
    }
}