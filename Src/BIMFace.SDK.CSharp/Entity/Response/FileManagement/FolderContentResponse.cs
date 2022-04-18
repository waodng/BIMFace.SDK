// /* ---------------------------------------------------------------------------------------
//    文件名：FolderContentResponse.cs
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
using System.Collections.Generic;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity
{
    /// <summary>
    ///     获取文件夹下的所有文件的返回类
    /// </summary>
    [Serializable]
    public class FolderContentResponse : GeneralResponse<FolderContentEntity>
    {
        
    }

    [Serializable]
    public class FolderContentEntity
    {
        [JsonProperty("list")]
        public List<FileItemEntity> FileItems { get; set; }

        [JsonProperty("page")]
        public Page2 Page { get; set; }
    }
}