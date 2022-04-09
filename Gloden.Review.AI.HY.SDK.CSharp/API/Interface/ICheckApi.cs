// /* ---------------------------------------------------------------------------------------
//    文件名：IAbutmentApi.cs
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

using Gloden.Review.AI.BIM.SDK.CSharp.Entity;

namespace Gloden.Review.AI.BIM.SDK.CSharp.API
{
    /// <summary>
    /// 信息检查接口
    /// </summary>
    public interface ICheckApi
    {
        /// <summary>
        ///  获取重定向地址
        /// </summary>
        /// <param name="token">【必填】登录认证后获取到的authorization值</param>
        /// <param name="id">【必填】第三方平台发起审批检查批次主键id（理解为一个项目ID）</param>
        /// <returns></returns>
        string GetRedirectUrl(string token, string id);
    }
}
