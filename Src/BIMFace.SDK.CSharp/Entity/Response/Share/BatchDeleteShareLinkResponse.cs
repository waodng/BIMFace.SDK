﻿// /* ---------------------------------------------------------------------------------------
//    文件名：BatchDeleteShareLinkResponse.cs
//    文件功能描述：
// 
//    创建标识：20200316
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
    ///   批量删除分享链接的响应结果类
    /// </summary>
    public class BatchDeleteShareLinkResponse : GeneralResponse<BatchDeleteResultEntity>
    {

    }

    public class BatchDeleteResultEntity
    {
        [JsonProperty("deleted")]
        public long[] Deleted { get; set; }

        [JsonProperty("nonexistence")]
        public long[] Nonexistence { get; set; }
    }
}