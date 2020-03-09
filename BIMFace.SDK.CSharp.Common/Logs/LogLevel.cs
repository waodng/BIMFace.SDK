// /* ---------------------------------------------------------------------------------------
//    文件名：LogLevel.cs
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

namespace BIMFace.SDK.CSharp.Common.Log
{
    /// <summary>
    ///     日志级别
    /// </summary>
    internal enum LogLevel
    {
        /// <summary>
        ///     致命异常
        /// </summary>
        Fatal,

        /// <summary>
        ///     错误
        /// </summary>
        Error,

        /// <summary>
        ///     警告
        /// </summary>
        Warn,

        /// <summary>
        ///     信息
        /// </summary>
        Info,

        /// <summary>
        ///     跟踪(一般用于开发与测试阶段)
        /// </summary>
        Trace,

        /// <summary>
        ///     调试(一般用于开发阶段)
        /// </summary>
        Debug
    }
}