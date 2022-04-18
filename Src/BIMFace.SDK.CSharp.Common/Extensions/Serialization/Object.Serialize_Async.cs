#region using

using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using Newtonsoft.Json;

#endregion

namespace BIMFace.SDK.CSharp.Common.Extensions
{
    public static partial class CommonExtension
    {
        #region ToXml

        /// <summary>
        ///     自定义扩展方法：将 object 对象(一般指的是实体类等)序列化为 XML 字符串
        /// </summary>
        /// <param name="this">扩展对象</param>
        /// <param name="isFormat">是否需要格式化，缩进显示</param>
        /// <returns></returns>
        public static async Task<string> SerializeToXmlAsync(this object @this, bool isFormat = false)
        {
            return await Task.FromResult(SerializeToXml(@this, isFormat));
        }

        #endregion

        #region ToJson

        /// <summary>
        ///     自定义扩展方法：将指定的对象对象序列化为 Json 字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="isFormat">是否需要格式化，缩进显示</param>
        /// <returns></returns>
        public static async Task<string> SerializeToJsonAsync<T>(this T @this, bool isFormat = false) where T : class
        {
            return await Task.FromResult(SerializeToJson(@this, isFormat));
        }

        /// <summary>
        ///     自定义扩展方法：将 XML 文档中的单个节点序列化为 Json 字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">XML 文档中的单个节点</param>
        /// <param name="isFormat">是否需要格式化，缩进显示</param>
        /// <param name="omitRootObject">是否省略写入根对象</param>
        /// <returns></returns>
        public static async Task<string> SerializeToJsonAsync(this XmlNode @this, bool isFormat = false, bool omitRootObject = false) //where T : class
        {
            Newtonsoft.Json.Formatting formatting = isFormat ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;
            return await Task.FromResult(JsonConvert.SerializeXmlNode(@this, formatting, omitRootObject));
        }

        /// <summary>
        ///     自定义扩展方法：将 System.Xml.Linq.XNode 对象序列化为Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="isFormat">是否需要格式化，缩进显示</param>
        /// <param name="omitRootObject">是否省略写入根对象</param>
        /// <returns></returns>
        public static async Task<string> SerializeToJsonAsync(this XObject @this, bool isFormat = false, bool omitRootObject = false) //where T : class
        {
            Newtonsoft.Json.Formatting formatting = isFormat ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;
            return await Task.FromResult(JsonConvert.SerializeXNode(@this, formatting, omitRootObject));
        }

        #endregion

        #region ToBinary

        /// <summary>
        ///     自定义扩展方法：使用当前操作系统默认的ANSI编码方式将泛型类型对象序列化为二进制字符串
        /// </summary>
        /// <param name="this">扩展对象</param>
        /// <returns></returns>
        public static async Task<string> SerializeToBinaryAsync<T>(this T @this)
        {
            return await Task.FromResult(SerializeToBinary(@this));
        }

        /// <summary>
        ///     自定义扩展方法：使用指定的编码方式将泛型类型对象序列化为二进制字符串
        /// </summary>
        /// <param name="this">扩展对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns></returns>
        public static async Task<string> SerializeBinaryAsync<T>(this T @this, Encoding encoding)
        {
            return await Task.FromResult(SerializeBinary<T>(@this, encoding));
        }

        #endregion
    }
}