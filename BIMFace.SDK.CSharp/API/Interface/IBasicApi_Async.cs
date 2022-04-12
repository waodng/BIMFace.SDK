// /* ---------------------------------------------------------------------------------------
//    文件名：BimfaceException.cs
//    文件功能描述：
// 
//    创建标识：20200308
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识： 
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

using BIMFace.SDK.CSharp.Constants;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.API
{
    /// <summary>
    ///  BIMFace 基础操作 API 接口
    /// </summary>
    public partial interface IBasicApi
    {
        /// <summary>
        ///  获取访问服务端其他API的令牌
        /// </summary>
        /// <param name="appKey">秘钥</param>
        /// <param name="appSecret">密码</param>
        /// <returns></returns>
        Task<AccessTokenResponse> GetAccessTokenAsync(string appKey, string appSecret);

        /// <summary>
        ///  获取单个模型的 ViewToken
        /// </summary>
        /// <param name="accessToken">令牌</param>
        /// <param name="objectId">文件转换ID</param>
        /// <returns></returns>
        Task<ViewTokenResponse> GetViewTokenByFileIdAsync(string accessToken, long objectId);

        /// <summary>
        ///  获取模型集成的 ViewToken
        /// </summary>
        /// <param name="accessToken">令牌</param>
        /// <param name="integrateId">集成模型ID</param>
        /// <returns></returns>
        Task<ViewTokenResponse> GetViewTokenByIntegrateIdAsync(string accessToken, long integrateId);

        /// <summary>
        ///  获取模型比对的 ViewToken
        /// </summary>
        /// <param name="accessToken">令牌</param>
        /// <param name="compareId">模型比对ID</param>
        /// <returns></returns>
        Task<ViewTokenResponse> GetViewTokenByCompareIdAsync(string accessToken, long compareId);

        /// <summary>
        ///  获取子文件的 ViewToken
        /// </summary>
        /// <param name="accessToken">令牌</param>
        /// <param name="integrateId">集成ID</param>
        /// <param name="fileId">文件ID</param>
        /// <returns></returns>
        Task<ViewTokenResponse> GetSubFileViewTokenAsync(string accessToken, long integrateId, long fileId);

        /// <summary>
        ///  批量获取同一类型的模型的 ViewToken 集合
        /// </summary>
        /// <param name="accessToken">令牌</param>
        /// <param name="modelType">模型类型</param>
        /// <param name="objectIds">文件转换ID(fileId)、模型对比ID(compareId)、集成模型ID(integrateId)的值，三者中的一个</param>
        /// <returns></returns>
        Task<ConcurrentDictionary<long, ViewTokenResponse>> GetViewTokenListAsync(string accessToken, ModelType modelType, List<long> objectIds);

        /// <summary>
        ///  批量获取不同类型的模型的 ViewToken 集合
        /// </summary>
        /// <param name="accessToken">令牌</param>
        /// <param name="objectInfos">模型类型以及对应的模型ID</param>
        /// <returns></returns>
        Task<ConcurrentDictionary<long, ViewTokenResponse>> GetViewTokenListAsync(string accessToken, ConcurrentDictionary<ModelType, List<long>> objectInfos);
    }
}