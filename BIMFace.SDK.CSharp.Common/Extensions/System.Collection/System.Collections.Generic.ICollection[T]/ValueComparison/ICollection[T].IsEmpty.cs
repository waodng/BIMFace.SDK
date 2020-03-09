using System.Collections.Generic;

namespace BIMFace.SDK.CSharp.Common.Extension
{
    public static partial class CommonExtension
    {
        /// <summary>
        ///  自定义扩展方法：判断集合是否不为 null 且元素的个数等于0 
        /// </summary>
        /// <param name="this">扩展对象</param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this ICollection<T> @this)
        {
            return @this.Count == 0;
        }

        /// <summary>
        ///  自定义扩展方法：判断集合是否不为 null 且元素的个数大于0。
        ///  该方法等同于 ICollection.IsNotNullAndEmpty()方法 
        /// </summary>
        /// <param name="this">扩展对象</param>
        /// <returns></returns>
        public static bool IsNotEmpty<T>(this ICollection<T> @this)
        {
            return @this.Count != 0;
        }
    }
}