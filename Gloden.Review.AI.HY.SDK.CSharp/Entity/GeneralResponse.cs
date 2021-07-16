// /* ---------------------------------------------------------------------------------------
//    文件名：GeneralResponse.cs
//    文件功能描述：接口响应结果泛型基类
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

using Newtonsoft.Json;

namespace Gloden.Review.AI.HY.SDK.CSharp.Entity
{
    /// <summary>
    /// 接口响应结果泛型基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class GeneralResponse<T>
    {
        #region 属性

        /// <summary>
        ///  请求返回代码，success 或者 xxxx.failed。
        ///  更详细的信息请参考接口文档：http://mq-test.yunzu360.com/rule/swagger/index.html
        /// </summary>
        [JsonProperty("code")]
        public virtual int Code { get; set; }


        /// <summary>
        /// success（布尔值）直观标记了请求接口是否成功。如请求失败，程序处理出错，会统一使用返回值code响应错误码
        /// </summary>
        [JsonProperty("success")]
        public virtual bool Success { get; set; }

        /// <summary>
        ///  失败的错误原因。
        ///  如果 Code 为 success 则 Message 为空。
        ///  如果 Code 为 xxxx.failed 则 Message 为具体的失败信息。
        /// </summary>
        [JsonProperty("msg")]
        public virtual string Message { get; set; }

        /// <summary>
        ///  各API实际响应数据
        /// </summary>
        [JsonProperty("data")]
        public virtual T Data { get; set; }

        #endregion

        #region 构造函数
        public GeneralResponse()
        {
        }

        public GeneralResponse(T data)
        {
            this.Data = data;
        }

        #endregion

        #region 方法
      
        #endregion
    }
}
