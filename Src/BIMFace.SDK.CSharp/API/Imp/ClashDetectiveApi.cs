// /* ---------------------------------------------------------------------------------------
//    文件名：ClashDetectiveApi.cs
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

using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Http;
using BIMFace.SDK.CSharp.Constants;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.API
{
    /// <summary>
    ///  BIMFACE 碰撞检测接口实现类
    /// </summary>
    public partial class ClashDetectiveApi: IClashDetectiveApi
    {
        /// <summary>
        /// 发起碰撞检测。
        /// <para>发起碰撞检测。碰撞检测分为以下两类：</para>
        /// <para>（1）硬碰撞(Hard)：指两个构件在空间上发生碰撞（正好接触的构件不会视为碰撞），如管道穿过结构框架柱；</para>
        /// <para>（2）间隙碰撞(Clearance)：两个构件在空间上并未发生实际碰撞，但构件之间预留空间过小，预留距离无法满足施工工艺或设备安装需求。</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="selectionA">【非必填】 选择集A</param>
        /// <param name="selectionB"> 【非必填】选择集B</param>
        /// <param name="clashType">【非必填】碰撞类型，"Hard"为硬碰撞，"Clearance"为间隙碰撞</param>
        /// <param name="tolerance">【非必填】碰撞公差，单位为mm（精确到0.1），仅间隙碰撞支持设置公差，当间隙小于等于公差时视为碰撞</param>
        /// <param name="callBack">【非必填】 	回调url</param>
        /// <returns></returns>
        public virtual ClashDetectiveResponse StartClashDetective(string accessToken, ClashDetectiveSource selectionA = null, ClashDetectiveSource selectionB = null,
                                                                  ClashType clashType = ClashType.Hard, double? tolerance = null, string callBack = null)
        {
            // POST https://api.bimface.com/clashDetective
            string url = BIMFaceConstants.API_HOST + "/clashDetective";

            ClashDetectiveRequest request = new ClashDetectiveRequest
            {
                SelectionA = selectionA,
                SelectionB = selectionB,
                ClashType = clashType == ClashType.Hard ? "Hard" : "Clearance",
                Tolerance = tolerance,
                Callback = callBack
            };
            string data = request.SerializeToJson();


            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                ClashDetectiveResponse response;
                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Post(url, data);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ClashDetectiveResponse>();
                }
                else
                {
                    response = new ClashDetectiveResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[发起模型碰撞]发生异常！", ex);
            }
        }

        /// <summary>
        /// 查询碰撞检测状态。
        /// <para>发起碰撞检测后，可以通过该接口查询碰撞检测的状态</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="clashDetectiveId">【必填】碰撞检测ID</param>
        /// <returns></returns>
        public virtual ClashDetectiveResponse QueryClashDetectiveStatus(string accessToken, string clashDetectiveId)
        {
            // GET https://api.bimface.com/clashDetective
            string url = BIMFaceConstants.API_HOST + "/clashDetective?clashDetectiveId=" + clashDetectiveId;

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                ClashDetectiveResponse response;
                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ClashDetectiveResponse>();
                }
                else
                {
                    response = new ClashDetectiveResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[查询模型碰撞状态]发生异常！", ex);
            }
        }

        /// <summary>
        /// 查询碰撞检测结果
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="clashDetectiveId">【必填】碰撞检测ID</param>
        /// <returns></returns>
        public virtual ClashDetectiveResultResponse QueryClashDetectiveResult(string accessToken, string clashDetectiveId)
        {
            // GET https://api.bimface.com/data/clashDetective/{clashDetectiveId}/result
            string url = BIMFaceConstants.API_HOST + string.Format("/data/clashDetective/{0}/result", clashDetectiveId);

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                ClashDetectiveResultResponse response;
                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ClashDetectiveResultResponse>();
                }
                else
                {
                    response = new ClashDetectiveResultResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[查询模型碰撞结果]发生异常！", ex);
            }
        }

        /// <summary>
        /// 根据模型ID查询碰撞检测ID列表
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">文件ID（fileId和integrateId选填一项）</param>
        /// <param name="integrateId"> 集成ID（fileId和integrateId选填一项）</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        public virtual ClashDetectiveListResponse QueryClashDetectiveList(string accessToken, string fileId, string integrateId)
        {
            // GET https://api.bimface.com/clashDetectiveList
            string url = BIMFaceConstants.API_HOST + "/clashDetectiveList?1=1";
            if (string.IsNullOrWhiteSpace(fileId) == false)
            {
                url = url + "&fileId=" + fileId;
            }
            if (string.IsNullOrWhiteSpace(integrateId) == false)
            {
                url = url + "&integrateId=" + integrateId;
            }

            BIMFaceHttpHeaders headers = new BIMFaceHttpHeaders();
            headers.AddOAuth2Header(accessToken);

            try
            {
                ClashDetectiveListResponse response;
                HttpManager httpManager = new HttpManager(headers);
                HttpResult httpResult = httpManager.Get(url);
                if (httpResult.Status == HttpResult.STATUS_SUCCESS)
                {
                    response = httpResult.Text.DeserializeJsonToObject<ClashDetectiveListResponse>();
                }
                else
                {
                    response = new ClashDetectiveListResponse
                    {
                        Message = httpResult.RefText
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new BIMFaceException("[根据模型ID查询碰撞检测ID列表]发生异常！", ex);
            }
        }
    }
}