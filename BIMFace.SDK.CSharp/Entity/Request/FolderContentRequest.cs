// /* ---------------------------------------------------------------------------------------
//    文件名：FolderContentRequest.cs
//    文件功能描述：
// 
//    创建标识：20220411
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识：
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity.Request
{
    /// <summary>
    ///  获取文件夹下的所有文件的请求参数类
    /// </summary>
    [Serializable]
    public class FolderContentRequest
    {
        public FolderContentRequest()
        {
            WithItemSource = false;
            PageNo = 1;
            PageSize = 20;
            UseFuzzySearch = true;
            ExcludeFolder = false;
        }

        /// <summary>
        /// 【必填】父目录文件id(parentId和parentPath，必须二选一填入)
        /// </summary>
        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        /// <summary>
        /// 【必填】父目录文件路径(parentId和parentPath，必须二选一填入)
        /// </summary>
        [JsonProperty("parentPath")]
        public string ParentPath { get; set; }

        /// <summary>
        /// 【选填】 	调用方文件源id
        /// </summary>
        [JsonProperty("sourceId",NullValueHandling = NullValueHandling.Ignore)]
        public string SourceId { get; set; }

        /// <summary>
        /// 【选填】 	文件名字
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// 【选填】 	是否返回ItemSource信息，默认为false
        /// </summary>
        [JsonProperty("withItemSource", NullValueHandling = NullValueHandling.Ignore)]
        public bool WithItemSource { get; set; }

        /// <summary>
        /// 【选填】 	开始页码，默认为1
        /// </summary>
        [JsonProperty("pageNo", NullValueHandling = NullValueHandling.Ignore)]
        public int PageNo { get; set; }

        /// <summary>
        /// 【选填】 每页大小，默认20
        /// </summary>
        [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
        public int PageSize { get; set; }

        /// <summary>
        /// 【选填】开始时间，格式为YYYY-MM-DD HH:mm:ss 	
        /// </summary>
        [JsonProperty("startTime", NullValueHandling = NullValueHandling.Ignore)]
        public string StartTime { get; set; }

        /// <summary>
        /// 【选填】结束时间，格式为YYYY-MM-DD HH:mm:ss 	
        /// </summary>
        [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime { get; set; }

        /// <summary>
        /// 【选填】 	文件后缀
        /// </summary>
        [JsonProperty("suffix", NullValueHandling = NullValueHandling.Ignore)]
        public string Suffix { get; set; }

        /// <summary>
        /// 【选填】 	当传了name,是否开启模糊查询,默认开启
        /// </summary>
        [JsonProperty("useFuzzySearch", NullValueHandling = NullValueHandling.Ignore)]
        public bool UseFuzzySearch { get; set; }

        /// <summary>
        /// 【选填】是否排除文件夹，默认为false
        /// </summary>
        [JsonProperty("excludeFolder", NullValueHandling = NullValueHandling.Ignore)]
        public bool ExcludeFolder { get; set; }
    }
}