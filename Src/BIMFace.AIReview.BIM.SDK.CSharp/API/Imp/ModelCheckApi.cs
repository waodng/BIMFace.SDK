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

using BIMFace.AIReview.BIM.SDK.CSharp.Entity;

namespace BIMFace.AIReview.BIM.SDK.CSharp.API
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
        /// <param name="files">【必填】文件信息集合。特别说明：集合中的rvt模型必须是来自同一版本的Revit软件，否则审查失败。目前仅支持 revit 2020 及以上版本 版本</param>
        /// <param name="checkBackName">【选填】检查批次名称（如不填，默认为"默认项目"）</param>
        /// <param name="createdBy">【选填】检查人名称（如不填，默认为"未知"）</param>
        /// <param name="reviewState">【选填】是否重新检查(如不填，默认为 0)</param>
        /// <param name="rules">【选填】规则信息集合（如不填，默认为"全部规则条文"）</param>
        /// <param name="projects">【选填】项目信息集合（如不填，默认为"默认项目信息参数"）</param>
        public ReviewModelResponse Review(string token, string id, List<FilesViewModel> files, string checkBackName = "", string createdBy = "江苏群耀", int reviewState = 0,
                           List<RulesViewModel> rules = null, List<ProjectViewModel> projects = null)
        {
            //POST
            string url = ApiConstants.API_HOST + "/api/mc/review";
            var data = new
            {
                id = id,
                checkBackName = checkBackName,
                createdBy = createdBy,
                files = files,
                rules = rules ?? new List<RulesViewModel>(),
                project = projects ?? new List<ProjectViewModel>()
            };

            AIReviewHttpHeaders headers = new AIReviewHttpHeaders();
            headers.AddOAuth2Header(token);

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
                throw new AIReviewException("[检查模型]发生异常！", ex);
            }
        }
    }
}
