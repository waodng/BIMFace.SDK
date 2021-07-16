// /* ---------------------------------------------------------------------------------------
//    文件名：ModelCheckApi.cs
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
    /// 模型检查接口
    /// </summary>
    public class ModelCheckApi : IModelCheckApi
    {
        /// <summary>
        ///  检查模型
        /// </summary>
        /// <param name="token">【必填】【必填】登录认证后获取到的authorization值</param>
        /// <param name="id">【必填】第三方web平台批次id（理解为一个项目ID）</param>
        /// <param name="files">【必填】文件信息集合</param>
        /// <param name="checkBackName">【选填】检查批次名称（如不填，默认为"默认项目"）</param>
        /// <param name="createdBy">【选填】检查人名称（如不填，默认为"未知"）</param>
        /// <param name="rules">【选填】规则信息集合（如不填，默认为"全部规则条文"）</param>
        /// <param name="projects">【选填】项目信息集合（如不填，默认为"默认项目信息参数"）</param>
        public ReviewModelResponse Review(string token, string id, List<FilesViewModel> files, string checkBackName = "", string createdBy = "江苏群耀",
                           List<RulesViewModel> rules = null, List<ProjectViewModel> projects = null)
        {
            //POST
            string url = APiConstants.API_HOST + "/api/mc/review";
            var data = new
            {
                id = id,
                checkBackName = checkBackName,
                createdBy = createdBy,
                files = files,
                rules = rules ?? new List<RulesViewModel>(),
                project = projects ?? new List<ProjectViewModel>()
            };

            ReviewAIHttpHeaders headers = new ReviewAIHttpHeaders();
            headers.AddOAuth2Header(token);

            var jsonData = data.SerializeToJson();

            try
            {
                ReviewModelResponse response;
                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, data.SerializeToJson());
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ReviewModelResponse>();
                }
                else
                {
                    response = new ReviewModelResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new ReviewAIException("[检查模型]发生异常！", ex);
            }
        }
    }
}
