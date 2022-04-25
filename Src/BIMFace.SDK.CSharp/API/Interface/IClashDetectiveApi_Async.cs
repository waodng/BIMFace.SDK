// /* ---------------------------------------------------------------------------------------
//    文件名：IClashDetectiveApi_Async.cs
//    文件功能描述：
// 
//    创建标识：20220425
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识：
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System;
using System.Threading.Tasks;

using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Http;
using BIMFace.SDK.CSharp.Constants;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.API
{
    public partial interface IClashDetectiveApi
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
        Task<ClashDetectiveResponse> StartClashDetectiveAsync(string accessToken, ClashDetectiveSource selectionA = null, ClashDetectiveSource selectionB = null,
                                                              ClashType clashType = ClashType.Hard, double? tolerance = null, string callBack = null);
        /// <summary>
        /// 查询碰撞检测状态。
        /// <para>发起碰撞检测后，可以通过该接口查询碰撞检测的状态</para>
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="clashDetectiveId">【必填】碰撞检测ID</param>
        /// <returns></returns>
        Task<ClashDetectiveResponse> QueryClashDetectiveStatusAsync(string accessToken, string clashDetectiveId);

        /// <summary>
        /// 查询碰撞检测结果
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="clashDetectiveId">【必填】碰撞检测ID</param>
        /// <returns></returns>
        Task<ClashDetectiveResultResponse> QueryClashDetectiveResultAsync(string accessToken, string clashDetectiveId);

        /// <summary>
        /// 根据模型ID查询碰撞检测ID列表
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">文件ID（fileId和integrateId选填一项）</param>
        /// <param name="integrateId"> 集成ID（fileId和integrateId选填一项）</param>
        /// <returns></returns>
        /// <exception cref="BIMFaceException"></exception>
        Task<ClashDetectiveListResponse> QueryClashDetectiveListAsync(string accessToken, string fileId, string integrateId);

    }
}