// /* ---------------------------------------------------------------------------------------
//    文件名：FileUpload2StatusResponse.cs
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

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity
{
    /// <summary>
    ///  File Management 模块中获取文件上传状态的返回类
    /// </summary>
    public class FileUpload2StatusResponse : GeneralResponse<FileUpload2StatusEntity>
    {

    }

    public class FileUpload2StatusEntity
    {
        /// <summary>
        ///     文件ID
        /// </summary>
        [JsonProperty("fileItemId")]
        public string FileItemId { get; set; }

        /// <summary>
        ///     文件名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }


        /// <summary>
        ///      	文件状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        ///     失败原因
        /// </summary>
        [JsonProperty("failedReason")]
        public string FailedReason { get; set; }

    }
}