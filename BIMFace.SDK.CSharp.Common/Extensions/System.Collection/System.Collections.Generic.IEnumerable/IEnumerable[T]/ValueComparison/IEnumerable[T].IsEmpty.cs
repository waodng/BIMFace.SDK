using System.Collections.Generic;
using System.Linq;

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        /// <summary>
        ///  自定义扩展方法：判断集合是否不包含任何元素
        /// </summary>
        /// <param name="this">扩展对象</param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> @this)
        {
            return @this != null && !@this.Any();
        }

        /// <summary>
        ///  自定义扩展方法：判断集合是否不为 null 且元素的个数大于0。
        ///  该方法等同于 ICollection.IsNotNullAndEmpty()方法 
        /// </summary>
        /// <param name="this">扩展对象</param>
        /// <returns></returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> @this)
        {
            return @this != null && @this.Any();
        }
    }
}