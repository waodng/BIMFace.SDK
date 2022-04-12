// /* ---------------------------------------------------------------------------------------
//    文件名：AuthorizeApi.cs
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

using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Http;

using BIMFace.AIReview.BIM.SDK.CSharp.Entity;
using BIMFace.AIReview.BIM.SDK.CSharp.Exceptions;

namespace BIMFace.AIReview.BIM.SDK.CSharp.API
{
    /// <summary>
    /// BIM 智能审图授权操作接口
    /// </summary>
    public class AuthorizeApi : IAuthorizeApi
    {
        /// <summary>
        ///  授权认证接口
        /// </summary>
        /// <returns></returns>
        public virtual LoginResponse Login()
        {
            // POST
            string url = ApiConstants.API_HOST + "/api/authorize/login";
            var data = new
            {
                serviceKey = ApiConstants.SERVICE_KEY,
                secret = ApiConstants.SERVICE_SECRET
            };

            try
            {
                LoginResponse response;
                HttpManager httpManager = new HttpManager();
                HttpResult httpResult = httpManager.Post(url, data.SerializeToJson());
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<LoginResponse>();
                }
                else
                {
                    response = new LoginResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new ReviewAIException("[用户登录]发生异常！", ex);
            }
        }

        /// <summary>
        ///  获取接口访问凭证（登录认证后获取到的authorization值）
        /// </summary>
        /// <returns></returns>
        public virtual string GetToken()
        {
            string token = string.Empty;
            var response = Login();
            if (response.Success)
            {
                token = response.Data?.Authorization;
            }

            return token;
        }
    }
}
