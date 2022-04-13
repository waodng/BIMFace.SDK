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

using BIMFace.AIReview.BIM.SDK.CSharp.Entity;

namespace BIMFace.AIReview.BIM.SDK.CSharp.API
{
    /// <summary>
    ///  桥接接口
    /// </summary>
    public class AbutmentApi : IAbutmentApi
    {
        /// <summary>
        ///  批量获取模型检查进度数据
        /// </summary>
        /// <param name="token">【必填】登录认证后获取到的authorization值</param>
        /// <param name="id">【必填】第三方平台批次Id（理解为一个项目ID）</param>
        public SingleBatchModelCheckProgressResponse GetModelCheckProgress(string token, string id)
        {
            List<string> ids = new List<string> { id };

            var batchResponse = GetModelCheckProgress(token, ids);

            var signalBatchResponse = new SingleBatchModelCheckProgressResponse
            {
                Code = batchResponse.Code,
                Message = batchResponse.Message,
                Success = batchResponse.Success
            };
            if (batchResponse.Data != null && batchResponse.Data.Count > 0)
            {
                signalBatchResponse.Data = batchResponse.Data[0];
            }

            return signalBatchResponse;
        }

        /// <summary>
        ///  批量获取模型检查进度数据
        /// </summary>
        /// <param name="token">【必填】登录认证后获取到的authorization值</param>
        /// <param name="ids">【必填】第三方平台批次Id（理解为一个项目ID）</param>
        public BatchModelCheckProgressResponse GetModelCheckProgress(string token, List<string> ids)
        {
            //Post
            string url = ApiConstants.API_HOST + "/api/abutment/callBackByIds";

            ReviewAIHttpHeaders headers = new ReviewAIHttpHeaders();
            headers.AddOAuth2Header(token);

            try
            {
                BatchModelCheckProgressResponse response;
                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, ids.SerializeToJson());
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<BatchModelCheckProgressResponse>();
                }
                else
                {
                    response = new BatchModelCheckProgressResponse
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
