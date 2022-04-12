// /* ---------------------------------------------------------------------------------------
//    文件名：FolderResponse.cs
//    文件功能描述：
// 
//    创建标识：20220410
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识：
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System;

using Newtonsoft.Json;


namespace BIMFace.SDK.CSharp.Entity.Response
{
    /// <summary>
    ///     项目下文件夹操作的返回类
    /// </summary>
    [Serializable]
    public class FolderResponse : GeneralResponse<FileItemEntity>
    {
    }

    /// <summary>
    ///     删除文件夹操作的返回类
    /// </summary>
    [Serializable]
    public class FolderDeleteResponse : GeneralResponse<string>
    {
    }

    [Serializable]
    public class FileItemEntity
    {
        /// <summary>
        ///     对象存储索引
        /// </summary>
        [JsonProperty("physicalIndex")]
        public string PhysicalIndex { get; set; }

        /// <summary>
        ///     文件id
        /// </summary>
        [JsonProperty("fileItemId")]
        public string FileItemId { get; set; }

        /// <summary>
        ///     文件大小
        /// </summary>
        [JsonProperty("length")]
        public long Length { get; set; }

        /// <summary>
        ///     文件更新时间
        /// </summary>
        [JsonProperty("updateTime")]
        public string UpdateTime { get; set; }

        /// <summary>
        ///     内部存储唯一标识
        /// </summary>
        [JsonProperty("storeId")]
        public string StoreId { get; set; }

        /// <summary>
        ///     文件后缀
        /// </summary>
        [JsonProperty("suffix")]
        public int Suffix { get; set; }

        /// <summary>
        ///     文件版本号
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        ///     父目录id
        /// </summary>
        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        /// <summary>
        ///     是否是文件夹
        /// </summary>
        [JsonProperty("folder")]
        public string IsFolder { get; set; }

        /// <summary>
        ///     文件创建时间
        /// </summary>
        [JsonProperty("createTime")]
        public string CreateTime { get; set; }

        /// <summary>
        ///     文件名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     appKey
        /// </summary>
        [JsonProperty("appKey")]
        public string AppKey { get; set; }

        /// <summary>
        ///     versionId
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     上传模式
        /// </summary>
        [JsonProperty("uploadMode")]
        public string UploadMode { get; set; }

        /// <summary>
        ///     项目id
        /// </summary>
        [JsonProperty("projectId")]
        public string ProjectId { get; set; }

        /// <summary>
        ///     文件的哈希值
        /// </summary>
        [JsonProperty("md5")]
        public string Md5 { get; set; }

        /// <summary>
        ///     文件状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}