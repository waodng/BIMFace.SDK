// /* ---------------------------------------------------------------------------------------
//    文件名：ClashDetectiveSource.cs
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

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity
{
    /// <summary>
    ///  碰撞检测源，选择集
    /// </summary>
    [Serializable]
    public class ClashDetectiveSource
    {
        /// <summary>
        ///  文件ID（fileId和integrateId选填一项）
        /// </summary>
        [JsonProperty("fileId", NullValueHandling = NullValueHandling.Ignore)]
        public long FileId { get; set; }

        /// <summary>
        ///  集成ID（fileId和integrateId选填一项）
        /// </summary>
        [JsonProperty("integrateId", NullValueHandling = NullValueHandling.Ignore)]
        public long IntegrateId { get; set; }

        /// <summary>
        ///  构件筛选条件，筛选字段可通过getObjectDataById方法获取
        /// </summary>
        [JsonProperty("objectData", NullValueHandling = NullValueHandling.Ignore)]
        public List<Dictionary<string,string>>ObjectData { get; set; }

        /// <summary>
        ///  构件ID的数组
        /// </summary>
        [JsonProperty("objectIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ObjectIds { get; set; }
    }
}