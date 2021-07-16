// /* ---------------------------------------------------------------------------------------
//    文件名：LoginResponse.cs
//    文件功能描述：
// 
//    创建标识：20210715
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识： 
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System;

using Newtonsoft.Json;

namespace Gloden.Review.AI.HY.SDK.CSharp.Entity
{
    /// <summary>
    ///  登录接口返回的结果类
    /// </summary>
    [Serializable]
    public class LoginResponse : GeneralResponse<LoginResponseModel>
    {

    }

    public class LoginResponseModel
    {
        /// <summary>
        ///  用户主键
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///  登录名
        /// </summary>
        [JsonProperty("loginName")]
        public string LoginName { get; set; }

        /// <summary>
        ///  显示名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///  邮箱
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///  电话
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        ///  接口授权认证token，默认token三天有效期
        /// </summary>
        [JsonProperty("authorization")]
        public string Authorization { get; set; }

        /// <summary>
        ///  创建用户id
        /// </summary>
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        ///  创建时间
        /// </summary>
        [JsonProperty("createdTime")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        ///  第三方平台对接id
        /// </summary>
        [JsonProperty("createdById")]
        public string CreatedById { get; set; }

        /// <summary>
        ///  超时跳转第三方平台地址
        /// </summary>
        [JsonProperty("returnUrl")]
        public string ReturnUrl { get; set; }
    }
}
