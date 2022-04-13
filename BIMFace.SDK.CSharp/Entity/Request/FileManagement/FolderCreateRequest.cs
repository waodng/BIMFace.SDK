// /* ---------------------------------------------------------------------------------------
//    文件名：FolderSaveRequest.cs
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

using System;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity
{
    /// <summary>
    ///  FileManagement功能中创建文件夹接口的请求参数类
    /// </summary>
    [Serializable]
    public class FolderCreateRequest
    {
        /// <summary>
        /// 【必填】 	项目名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 【必填】 父目录文件路径,parentId和parentPath,必须二选一填入
        /// </summary>
        [JsonProperty("parentPath", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentPath { get; set; }

        /// <summary>
        /// 【必填】 父目录文件ID,parentId和parentPath,必须二选一填入
        /// </summary>
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId { get; set; }

        /// <summary>
        /// 【选填】 	存在同名文件夹时,是否自动重命名（默认false,false情况下有同名文件夹则报错）
        /// </summary>
        [JsonProperty("autoRename", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoRename { get; set; }
    }
}