// /* ---------------------------------------------------------------------------------------
//    文件名：FolderUpdateRequest.cs
//    文件功能描述：
// 
//    创建标识：20220413
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
    /// <summary>
    ///  FileManagement功能中更新文件夹接口的请求参数类
    /// </summary>
    public class FolderUpdateRequest
    {
        /// <summary>
        /// 【必填】 	项目名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 【必填】 文件夹路径(folderId和path,必须二选一填入)
        /// </summary>
        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        /// <summary>
        /// 【必填】 	文件夹id(folderId和path,必须二选一填入),id的优先级大于path
        /// </summary>
        [JsonProperty("folderId", NullValueHandling = NullValueHandling.Ignore)]
        public string FolderId { get; set; }

        /// <summary>
        /// 【选填】 	存在同名文件夹时,是否自动重命名（默认false,false情况下有同名文件夹则报错）
        /// </summary>
        [JsonProperty("autoRename", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoRename { get; set; }
    }
}