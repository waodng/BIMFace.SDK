// /* ---------------------------------------------------------------------------------------
//    文件名：IAuthorizeApi.cs
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

using Gloden.Review.AI.HY.SDK.CSharp.Entity;

namespace Gloden.Review.AI.HY.SDK.CSharp.API
{
    /// <summary>
    ///  BIM 智能审图授权操作接口
    /// </summary>
    public interface IAuthorizeApi
    {
        /// <summary>
        ///  授权认证接口
        /// </summary>
        /// <returns></returns>
        LoginResponse Login();

        /// <summary>
        ///  获取接口访问凭证（登录认证后获取到的authorization值）
        /// </summary>
        /// <returns></returns>
        string GetToken();
    }
}
