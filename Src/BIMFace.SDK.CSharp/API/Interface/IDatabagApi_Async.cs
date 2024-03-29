﻿// /* ---------------------------------------------------------------------------------------
//    文件名：IDatabagApi.cs
//    文件功能描述：
// 
//    创建标识：20200316
//    作   者：张传宁  （QQ：905442693  微信：savionzhang）
//    作者博客：https://www.cnblogs.com/SavionZhang/
//    BIMFace专栏地址：https://www.cnblogs.com/SavionZhang/p/11424431.html
// 
//    修改标识： 
//    修改描述：
//  ------------------------------------------------------------------------------------------*/

using System.Threading.Tasks;

using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.API
{
    /// <summary>
    ///  转换/集成/对比数据包相关API接口
    /// </summary>
    public partial interface IDatabagApi
    {
        /// <summary>
        ///  当模型转换成功执行后，获取数据包大小
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】文件id</param>
        /// <returns></returns>
        Task<DatabagLengthQueryResponse> QueryDatabagLengthByFileIdAsync(string accessToken, long fileId);

        /// <summary>
        ///  当模型对比成功执行后，获取数据包大小
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="compareId">【必填】compareId</param>
        /// <returns></returns>
        Task<DatabagLengthQueryResponse> QueryDatabagLengthByCompareIdAsync(string accessToken, long compareId);

        /// <summary>
        ///  当模型集成成功执行后，获取数据包大小
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="integrateId">【必填】integrateId</param>
        /// <returns></returns>
        Task<DatabagLengthQueryResponse> QueryDatabagLengthByIntegrateIdAsync(string accessToken, long integrateId);

        /// <summary>
        ///  当模型转换成功执行后，获取缩略图链接
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="fileId">【必填】文件id</param>
        /// <param name="size">【必填】缩略图大小</param>
        /// <returns></returns>
        Task<DatabagThumbnailQueryResponse> QueryDatabagThumbnailFileIdAsync(string accessToken, long fileId, int size);

        /// <summary>
        ///  当模型对比成功执行后，获取缩略图链接
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="compareId">【必填】 compareId</param>
        /// <param name="size">【必填】缩略图大小</param>
        /// <returns></returns>
        Task<DatabagThumbnailQueryResponse> QueryDatabagThumbnailByCompareIdAsync(string accessToken, long compareId, int size);

        /// <summary>
        ///  当模型集成成功执行后，获取缩略图链接
        /// </summary>
        /// <param name="accessToken">【必填】令牌</param>
        /// <param name="integrateId">【必填】integrateId</param>
        /// <param name="size">【必填】缩略图大小</param>
        /// <returns></returns>
        Task<DatabagThumbnailQueryResponse> QueryDatabagThumbnailByIntegrateIdAsync(string accessToken, long integrateId, int size);
    }
}