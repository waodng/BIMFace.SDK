// /* ---------------------------------------------------------------------------------------
//    文件名：FileCopyRequest.cs
//    文件功能描述：
// 
//    创建标识：20220412
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识：
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System.Collections.Generic;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity.Request
{
    /// <summary>
    ///  FileManagement功能中复制文件接口的请求参数类
    /// </summary>
    public class FileCopy2Request
    {
        /// <summary>
        /// 【必填】目标位置上传文件夹Id,(targetParentId和targetParentPath必须二选一)
        /// </summary>
        [JsonProperty("targetParentId", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetParentId { get; set; }

        /// <summary>
        /// 【必填】 需要复制的文件路径集合(fileItemIds和fileItemPath必须二选一)
        /// </summary>

        [JsonProperty("fileItemPaths", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FileItemPaths { get; set; }

        /// <summary>
        /// 【必填】需要复制的文件id集合(fileItemIds和fileItemPath必须二选一)
        /// </summary>

        [JsonProperty("fileItemIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FileItemIds { get; set; }

        /// <summary>
        /// 【必填】目标位置的项目Id
        /// </summary>

        [JsonProperty("targetProjectId", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetProjectId { get; set; }

        /// <summary>
        /// 【必填】目标位置上层文件夹路径,(targetParentId和targetParentPath必须二选一)
        /// </summary>

        [JsonProperty("targetParentPath", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetParentPath { get; set; }
    }
}