#region using

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using Newtonsoft.Json;

#endregion

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        /// <summary>
        ///     自定义扩展方法:将 Json 字符串反序列化为指定类型的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">json字符串</param>
        /// <param name="settings">json字符串</param>
        /// <returns></returns>
        public static async Task<T> DeserializeJsonToObjectAsync<T>(this string @this, JsonSerializerSettings settings = null) where T : class
        {
            return await Task.FromResult(JsonConvert.DeserializeObject<T>(@this, settings));
        }

        /// <summary>
        ///     自定义扩展方法:将json格式的<see cref="T:System.Xml.XmlNode" /> 字符串转换为XmlNode
        /// </summary>
        /// <param name="this">json字符串</param>
        /// <param name="deserializeRootElementName">反序列化时要附加的根元素的名称</param>
        /// <param name="writeArrayAttribute">指示是否写入json.net数组属性的标志。此属性有助于在将写入的XML转换回json时保留数组。</param>
        /// <returns></returns>
        public static async Task<XmlNode> DeserializeJsonToXmlNodeAsync(this string @this, string deserializeRootElementName = null,
                                                                       bool writeArrayAttribute = false)
        {
            return await Task.FromResult(JsonConvert.DeserializeXmlNode(@this, deserializeRootElementName, writeArrayAttribute));
        }

        /// <summary>
        ///     自定义扩展方法:将 Json格式的<see cref="T:System.Xml.Linq.XNode" /> 字符串反序列化为XDocument
        /// </summary>
        /// <param name="this">json字符串</param>
        /// <param name="deserializeRootElementName">反序列化时要附加的根元素的名称</param>
        /// <param name="writeArrayAttribute">指示是否写入json.net数组属性的标志。此属性有助于在将写入的XML转换回json时保留数组。</param>
        /// <returns></returns>
        public static async Task<XDocument> DeserializeJsonToXNodeAsync(this string @this, string deserializeRootElementName = null,
                                                                       bool writeArrayAttribute = false)
        {
            return await Task.FromResult(JsonConvert.DeserializeXNode(@this, deserializeRootElementName, writeArrayAttribute));
        }

        /// <summary>
        ///     自定义扩展方法： 将 XML 字符串反序列化为指定类型的对象
        /// </summary>
        /// <typeparam name="T">泛型类型参数，例如 typeof(实体、DataTable、List集合等对象)</typeparam>
        /// <param name="this">XML字符串</param>
        /// <returns></returns>
        public static async Task<object> DeserializeXmlToObjectAsync<T>(this string @this) where T : class
        {
            return await Task.FromResult(DeserializeXmlToObject<T>(@this));
        }

        /// <summary>
        ///     自定义扩展方法： 将 XML 字符串反序列化为泛型类型对象
        /// </summary>
        /// <typeparam name="T">泛型类型参数，例如 typeof(实体、DataTable、List集合等对象)</typeparam>
        /// <param name="this">XML字符串</param>
        /// <returns></returns>
        public static async Task<T> DeserializeXmlToTObjectAsync<T>(this string @this) where T : class
        {
            return await Task.FromResult((T)@this.DeserializeXmlToObject<T>());
        }

        /// <summary>
        ///   自定义扩展方法：使用当前操作系统默认的 ANSI 编码方式将二进制字符串反序列化为泛型类型对象
        /// </summary>
        /// <param name="this">扩展对象。二进制字符串</param>
        /// <returns></returns>
        public static async Task<T> DeserializeFromBinaryAsync<T>(this string @this)
        {
            return await Task.FromResult(DeserializeFromBinary<T>(@this));
        }

        /// <summary>
        ///   自定义扩展方法：使用指定的编码方式将二进制字符串反序列化为泛型类型对象
        /// </summary>
        /// <param name="this">扩展对象。二进制字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns></returns>
        public static async Task<T> DeserializeFromBinaryAsync<T>(this string @this, Encoding encoding)
        {
            return await Task.FromResult(DeserializeFromBinary<T>(@this, encoding));
        }
    }
}