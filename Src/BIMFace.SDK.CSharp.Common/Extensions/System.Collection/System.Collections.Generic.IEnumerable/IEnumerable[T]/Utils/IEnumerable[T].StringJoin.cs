using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        /// <summary>
        ///  自定义扩展方法：使用指定的分隔符号将集合中的元素串联成一个字符串
        /// </summary>
        /// <typeparam name="T">泛型类型参数</typeparam>
        /// <param name="this">扩展对象</param>
        /// <param name="separator">分隔符号</param>
        /// <returns></returns>
        internal static string JoinWith<T>(this IEnumerable<T> @this, string separator)
        {
            if (@this == null || @this.Any() == false)
                return "";

            return string.Join(separator, @this);
        }

        /// <summary>
        ///  自定义扩展方法：使用指定的分隔符号将集合中的元素串联成一个字符串
        /// </summary>
        /// <typeparam name="T">泛型类型参数</typeparam>
        /// <param name="this">扩展对象</param>
        /// <param name="separator">分隔符号</param>
        /// <returns></returns>
        internal static string JoinWith<T>(this IEnumerable<T> @this, char separator)
        {
            if (@this == null || @this.Any() == false)
                return "";

            return string.Join(separator.ToString(), @this);
        }

        /// <summary>
        ///  自定义扩展方法：使用指定的分隔符号将集合中的元素串联成一个字符串
        /// </summary>
        /// <typeparam name="T">泛型类型参数</typeparam>
        /// <param name="this">扩展对象</param>
        /// <param name="separator">分隔符号</param>
        /// <returns></returns>
        public static string ToStringWith<T>(this IEnumerable<T> @this, string separator)
        {
            if (@this == null || @this.Any() == false)
                return "";

            return string.Join(separator, @this);
        }

        /// <summary>
        ///  自定义扩展方法：使用指定的分隔符号将集合中的元素串联成一个字符串。每个对象显示为单独的一行。
        ///  该方法一般用于将自定义类的对象集合拼接成多行显示的字符串。
        /// </summary>
        /// <typeparam name="T">泛型类型参数</typeparam>
        /// <param name="this">扩展对象</param>
        /// <param name="ignoreNullObj">是否忽略集合中为 NULL 的对象</param>
        /// <returns></returns>
        public static string ToStringLine<T>(this IEnumerable<T> @this, bool ignoreNullObj = true)
        {
            if (@this == null || @this.Any() == false)
                return "";

            StringBuilder sb = new StringBuilder();
            foreach (var obj in @this)
            {
                if (obj != null)
                {
                    sb.AppendLine(obj.ToString());
                }
                else
                {
                    if (ignoreNullObj == false)
                    {
                        sb.AppendLine("NULL");
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        ///  自定义扩展方法：使用指定的分隔符号将集合中的元素串联成一个字符串。每个对象显示为单独的一行。
        ///  该方法一般用于将自定义类的对象集合拼接成多行显示的字符串。
        /// </summary>
        /// <typeparam name="T">泛型类型参数</typeparam>
        /// <param name="this">扩展对象</param>
        /// <param name="separator">分隔符号。</param>
        /// <param name="ignoreNullObj">是否忽略集合中为 NULL 的对象</param>
        /// <returns></returns>
        public static string ToStringLineWith<T>(this IEnumerable<T> @this, string separator, bool ignoreNullObj = true)
        {
            if (@this == null || @this.Any() == false)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            foreach (var obj in @this)
            {
                if (obj != null)
                {
                    sb.AppendLine(obj.ToString() + separator);
                }
                else
                {
                    if (ignoreNullObj == false)
                    {
                        sb.AppendLine("NULL");
                    }
                }
            }

            return sb.ToString();
        }



        /// <summary>
        ///  自定义扩展方法：使用指定的分隔符号将集合中的元素串联成一个字符串
        /// </summary>
        /// <typeparam name="T">泛型类型参数</typeparam>
        /// <param name="this">扩展对象</param>
        /// <param name="separator">分隔符号</param>
        /// <returns></returns>
        public static string ToStringWith<T>(this IEnumerable<T> @this, char separator)
        {
            if (@this == null || @this.Any() == false)
            {
                return "";
            }
            return string.Join(separator.ToString(), @this);
        }
    }
}