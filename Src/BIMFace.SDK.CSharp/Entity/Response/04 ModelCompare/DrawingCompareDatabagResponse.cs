// /* ---------------------------------------------------------------------------------------
//    文件名：DrawingCompareDatabagResponse.cs
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
    ///  图纸对比的数据包信息类
    /// </summary>
    public class DrawingCompareDatabagResponse : GeneralResponse<DrawingCompareDatabagInfo>
    {
    }

    public class DrawingCompareDatabagInfo
    {
        /// <summary>
        ///  (应该是一个对象)
        /// </summary>
        [JsonProperty("bake", NullValueHandling = NullValueHandling.Ignore)]
        public object Bake { get; set; }

        /// <summary>
        ///  (应该是一个对象)
        /// </summary>
        [JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
        public object Config { get; set; }

        /// <summary>
        ///  数据包ID
        /// </summary>
        [JsonProperty("databagId", NullValueHandling = NullValueHandling.Ignore)]
        public string DatabagId { get; set; }

        /// <summary>
        ///  (应该是一个对象)
        /// </summary>
        [JsonProperty("integrateDrawings", NullValueHandling = NullValueHandling.Ignore)]
        public object IntegrateDrawings { get; set; }

        [JsonProperty("isSupportComponentProperty", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportComponentProperty { get; set; }

        [JsonProperty("isSupportDrawing", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportDrawing { get; set; }

        [JsonProperty("isSupportFamilyTypeList", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportFamilyTypeList { get; set; }

        [JsonProperty("isSupportMaterialProperty", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportMaterialProperty { get; set; }

        [JsonProperty("isSupportMiniMap", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportMiniMap { get; set; }

        [JsonProperty("isSupportModelTree", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportModelTree { get; set; }

        [JsonProperty("isSupportRoomArea", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportRoomArea { get; set; }

        [JsonProperty("isSupportWalk", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportWalk { get; set; }

        [JsonProperty("jsSDKVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string JsSDKVersion { get; set; }

        [JsonProperty("modelId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ModelId { get; set; }

        [JsonProperty("modelType", NullValueHandling = NullValueHandling.Ignore)]
        public string ModelType { get; set; }

        /// <summary>
        /// 对比时的自定义名称
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// 渲染类型：drawingView、3DView
        /// </summary>
        [JsonProperty("renderType", NullValueHandling = NullValueHandling.Ignore)]
        public string RenderType { get; set; }

        /// <summary>
        /// 渲染版本号
        /// </summary>
        [JsonProperty("renderVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string RenderVersion { get; set; }

        [JsonProperty("sceneJsonInfo", NullValueHandling = NullValueHandling.Ignore)]
        public object SceneJsonInfo { get; set; }

        [JsonProperty("shell", NullValueHandling = NullValueHandling.Ignore)]
        public object Shell { get; set; }

        [JsonProperty("split", NullValueHandling = NullValueHandling.Ignore)]
        public object Split { get; set; }

        [JsonProperty("subRenders", NullValueHandling = NullValueHandling.Ignore)]
        public List<SubRender> SubRenders { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public int Type { get; set; }

        [JsonProperty("workerType", NullValueHandling = NullValueHandling.Ignore)]
        public string WorkerType { get; set; }
    }

    public class SubRender
    {
        [JsonProperty("isSupportComponentProperty", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportComponentProperty { get; set; }

        [JsonProperty("isSupportFamilyTypeList", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportFamilyTypeList { get; set; }

        [JsonProperty("isSupportMiniMap", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportMiniMap { get; set; }

        [JsonProperty("isSupportModelTree", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSupportModelTree { get; set; }

        [JsonProperty("jsSDKVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string JsSDKVersion { get; set; }

        /// <summary>
        /// 渲染类型：drawingView、3DView
        /// </summary>
        [JsonProperty("renderType", NullValueHandling = NullValueHandling.Ignore)]
        public string RenderType { get; set; }

        /// <summary>
        /// 渲染版本号
        /// </summary>
        [JsonProperty("renderVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string RenderVersion { get; set; }
    }
}
