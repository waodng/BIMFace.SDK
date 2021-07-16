// /* ---------------------------------------------------------------------------------------
//    文件名：AbutmentApi.cs
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
using System.Collections.Generic;

using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Http;

using Gloden.Review.AI.HY.SDK.CSharp.Entity;
using Gloden.Review.AI.HY.SDK.CSharp.Exceptions;
using Gloden.Review.AI.HY.SDK.CSharp.Http;

namespace Gloden.Review.AI.HY.SDK.CSharp.API
{
    /// <summary>
    ///  桥接接口
    /// </summary>
    public class AbutmentApi : IAbutmentApi
    {
        /// <summary>
        ///  获取模型检查进度数据
        /// </summary>
        /// <param name="token">【必填】登录认证后获取到的authorization值</param>
        /// <param name="ids">【必填】第三方平台批次Id（理解为一个项目ID）</param>
        public ModelCheckProgressResponse GetModelCheckProgress(string token, List<string> ids)
        {
            //Get
            string url = APiConstants.API_HOST + "/api/abutment/callBackByIds";

            ReviewAIHttpHeaders headers = new ReviewAIHttpHeaders();
            headers.AddOAuth2Header(token);

            try
            {
                ModelCheckProgressResponse response;
                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url,ids.SerializeToJson());
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ModelCheckProgressResponse>();
                }
                else
                {
                    response = new ModelCheckProgressResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new ReviewAIException("[获取模型检查进度数据]发生异常！", ex);
            }
        }
    }
}
