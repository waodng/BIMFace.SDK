// /* ---------------------------------------------------------------------------------------
//    文件名：Project.cs
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

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity
{
    /// <summary>
    ///  FileManagement功能中创建项目接口、更新项目接口的请求参数类
    /// </summary>
    [Serializable]
    public class ProjectSaveRequest
    {
        /// <summary>
        /// 【必填】 	项目名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 【选填】 项目缩略图url，若不填则使用默认缩略图
        /// </summary>
        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }

        /// <summary>
        /// 【选填】 	项目描述
        /// </summary>
        [JsonProperty("info", NullValueHandling = NullValueHandling.Ignore)]
        public string Info { get; set; }
    }
}