using System.Collections.Generic;
using System.Linq;

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        /// <summary>
        ///  自定义扩展方法：将集合的集合合并为一个并集
        /// </summary>
        /// <typeparam name="T">泛型类型参数</typeparam>
        /// <param name="this">扩展对象</param>
        /// <returns></returns>
        public static IEnumerable<T> MergeDistinctInnerEnumerable<T>(this IEnumerable<IEnumerable<T>> @this)
        {
            var list = new List<T>();

            List<IEnumerable<T>> listItem = @this.ToList();
            foreach(var item in listItem)
            {
                list = list.Union(item).ToList();
            }

            return list;
        }
    }
}