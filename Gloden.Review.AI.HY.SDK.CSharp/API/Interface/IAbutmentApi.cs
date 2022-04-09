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

using System.Collections.Generic;

using Gloden.Review.AI.BIM.SDK.CSharp.Entity;

namespace Gloden.Review.AI.BIM.SDK.CSharp.API
{
    /// <summary>
    ///  桥接接口
    /// </summary>
    public interface IAbutmentApi
    {
        /// <summary>
        ///  获取一个批次中所有模型检查进度数据
        /// </summary>
        /// <param name="token">【必填】登录认证后获取到的authorization值</param>
        /// <param name="ids">【必填】第三方平台批次Id（理解为一个项目ID）</param>
        SingleBatchModelCheckProgressResponse GetModelCheckProgress(string token, string id);

        /// <summary>
        ///  获取多批次模型检查进度数据
        /// </summary>
        /// <param name="token">【必填】登录认证后获取到的authorization值</param>
        /// <param name="ids">【必填】第三方平台批次Id（理解为一个项目ID）</param>
        BatchModelCheckProgressResponse GetModelCheckProgress(string token, List<string> ids);
    }
}
