// /* ---------------------------------------------------------------------------------------
//    文件名：LogUtility.cs
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

using System;
using System.IO;
using System.Text;

namespace BIMFace.SDK.CSharp.Common.Log
{
    /// <summary>
    ///     文本类型日志工具类
    /// </summary>
    public class LogUtility
    {
        #region 构造函数

        static LogUtility()
        {
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }

            EncodingType = Encoding.Default; //操作系统的当前 ANSI 代码页的编码 //System.Text.Encoding.GetEncoding(EncodingNames.GB2312);//简体中文
        }

        #endregion

        #region 属性

        private static readonly string Separator = "===============================================================";

        /// <summary>
        ///     日志输出目录
        /// </summary>
        private static readonly string LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");

        /// <summary>
        ///     记录日志时使用的编码方式
        /// </summary>
        private static Encoding EncodingType { get; }

        #endregion

        #region 方法

        #region Info

        /// <summary>
        ///     使用操作系统的当前ANSI代码页的编码方式将提示信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        public static void Info(string msg)
        {
            Info(msg, EncodingType);
        }

        /// <summary>
        ///     使用指定的编码方式将提示信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="encoding">编码方式(建议使用 EncodingNames 编码方式常量类获取不同的编码方式名称)</param>
        public static void Info(string msg, Encoding encoding)
        {
            Info(msg, null, encoding);
        }

        /// <summary>
        ///     使用操作系统的当前ANSI代码页的编码方式将提示息与异常信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="ex">异常信息对象</param>
        public static void Info(string msg, System.Exception ex)
        {
            Info(msg, ex, EncodingType);
        }

        /// <summary>
        ///     使用指定的编码方式将提示信息与异常信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="ex">异常信息对象</param>
        /// <param name="encoding">编码方式(建议使用 EncodingNames 编码方式常量类获取不同的编码方式名称)</param>
        public static void Info(string msg, System.Exception ex, Encoding encoding)
        {
            Write(msg, ex, encoding, LogLevel.Info);
        }

        #endregion

        #region Warn

        /// <summary>
        ///     使用操作系统的当前ANSI代码页的编码方式将警告信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        public static void Warn(string msg)
        {
            Warn(msg, EncodingType);
        }

        /// <summary>
        ///     使用指定的编码方式将警告信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="encoding">编码方式(建议使用 EncodingNames 编码方式常量类获取不同的编码方式名称)</param>
        public static void Warn(string msg, Encoding encoding)
        {
            Warn(msg, null, encoding);
        }

        /// <summary>
        ///     使用操作系统的当前ANSI代码页的编码方式将警告息与异常信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="ex">异常信息对象</param>
        public static void Warn(string msg, System.Exception ex)
        {
            Warn(msg, ex, EncodingType);
        }

        /// <summary>
        ///     使用指定的编码方式将警告信息与异常信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="ex">异常信息对象</param>
        /// <param name="encoding">编码方式(建议使用 EncodingNames 编码方式常量类获取不同的编码方式名称)</param>
        public static void Warn(string msg, System.Exception ex, Encoding encoding)
        {
            Write(msg, ex, encoding, LogLevel.Warn);
        }

        #endregion

        #region Error

        /// <summary>
        ///     使用操作系统的当前ANSI代码页的编码方式将错误信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        public static void Error(string msg)
        {
            Error(msg, EncodingType);
        }

        /// <summary>
        ///     使用指定的编码方式将错误信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="encoding">编码方式(建议使用 EncodingNames 编码方式常量类获取不同的编码方式名称)</param>
        public static void Error(string msg, Encoding encoding)
        {
            Error(msg, null, encoding);
        }

        /// <summary>
        ///     使用操作系统的当前ANSI代码页的编码方式将错误信息与异常信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="ex">异常信息对象</param>
        public static void Error(string msg, System.Exception ex)
        {
            Error(msg, ex, EncodingType);
        }

        /// <summary>
        ///     使用指定的编码方式将错误信息与异常信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="ex">异常信息对象</param>
        /// <param name="encoding">编码方式(建议使用 EncodingNames 编码方式常量类获取不同的编码方式名称)</param>
        public static void Error(string msg, System.Exception ex, Encoding encoding)
        {
            Write(msg, ex, encoding, LogLevel.Error);
        }

        #endregion

        #region Debug

        /// <summary>
        ///     使用操作系统的当前ANSI代码页的编码方式将调试信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        public static void Debug(string msg)
        {
            Debug(msg, EncodingType);
        }

        /// <summary>
        ///     使用指定的编码方式将调试信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="encoding">编码方式(建议使用 EncodingNames 编码方式常量类获取不同的编码方式名称)</param>
        public static void Debug(string msg, Encoding encoding)
        {
            Debug(msg, null, encoding);
        }

        /// <summary>
        ///     使用操作系统的当前ANSI代码页的编码方式将调试息与异常信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="ex">异常信息对象</param>
        public static void Debug(string msg, System.Exception ex)
        {
            Debug(msg, ex, EncodingType);
        }

        /// <summary>
        ///     使用操作系统的当前ANSI代码页的编码方式将调试信息与异常信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="ex">异常信息对象</param>
        /// <param name="encoding">编码方式(建议使用 EncodingNames 编码方式常量类获取不同的编码方式名称)</param>
        public static void Debug(string msg, System.Exception ex, Encoding encoding)
        {
            Write(msg, ex, encoding, LogLevel.Debug);
        }

        #endregion

        /// <summary>
        ///     使用指定的编码方式将自定义信息与异常信息写入文本文件
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="exception">异常对象</param>
        /// <param name="encoding">编码方式(建议使用 EncodingNames 编码方式常量类获取不同的编码方式名称)</param>
        /// <param name="logLevel">日志类型</param>
        private static void Write(string msg, System.Exception exception, Encoding encoding, LogLevel logLevel)
        {
            string fileName = DateTime.Now.ToString("yyyyMMddHH") + ".log"; //每小时产生一个log文件
            string tip = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff]") + "[" + logLevel + "]";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.Append(tip + " Start " + Separator);
            sb.AppendLine();
            sb.AppendLine(msg);

            while (exception != null)
            {
                sb.AppendLine("Exception:" + exception);
                exception = exception.InnerException;
            }

            sb.Append(tip + " End   " + Separator);
            sb.AppendLine();

            try
            {
                string newPath = Path.Combine(LogPath, DateTime.Now.ToString("yyyyMMdd")); //以天为单位，产生独立的目录
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                File.AppendAllText(Path.Combine(newPath, fileName), sb.ToString(), encoding);
            }
            catch (IOException ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}