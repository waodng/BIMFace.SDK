// /* ---------------------------------------------------------------------------------------
//    文件名：DatabagDerivativeRequest.cs
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

using System;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity
{
    /// <summary>
    ///  为文件创建bake数据包或者离线数据包的请求类
    /// </summary>
    [Serializable]
    public class DatabagDerivativeRequest
    {
        /// <summary>
        /// 设置参数，请参考官方具体API需要配置的相关参数
        /// </summary>
        [JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
        public Config Config { get; set; }
    }

    [Serializable]
    public class Config
    {
        public Config()
        {
            KeepModel = true;
            KeepDB = true;
        }

        /// <summary>
        /// 默认值为 true
        /// </summary>
        [JsonProperty("keepModel", NullValueHandling = NullValueHandling.Ignore)]
        public bool KeepModel { get; set; }

        /// <summary>
        /// 默认值为 true
        /// </summary>
        [JsonProperty("keepDB", NullValueHandling = NullValueHandling.Ignore)]
        public bool KeepDB { get; set; }
    }

}