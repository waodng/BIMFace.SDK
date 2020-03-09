// /* ---------------------------------------------------------------------------------------
//    文件名：AccessTokenResponse.cs
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

using System.Collections.Generic;

using BIMFace.SDK.CSharp.Common.Extensions;

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity.Response
{
    /// <summary>
    /// 获取单个模型单个构件的材质列表返回的结果类
    /// </summary>
    public class SingleModelSingleElementMaterials : GeneralResponse<List<MaterialInfo>>
    {

    }

    public class MaterialInfo
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public PropertyGroup[] Parameters { get; set; }

        /// <summary>返回表示当前对象的字符串。</summary>
        /// <returns>表示当前对象的字符串。</returns>
        public override string ToString()
        {
            return string.Format("[id={0}, name={1}, parameters={2}]",
                                 Id, Name, Parameters.ToStringLine());
        }
    }

    public class PropertyGroup
    {
        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public PropertyItem[] Items { get; set; }

        /// <summary>返回表示当前对象的字符串。</summary>
        /// <returns>表示当前对象的字符串。</returns>
        public override string ToString()
        {
            return string.Format("[group={0}, items={1}]",Group, Items.ToStringLine());
        }
    }

    public class PropertyItem
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("extension", NullValueHandling = NullValueHandling.Ignore)]
        public object Extension { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("orderNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int? OrderNumber { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public object Value { get; set; }

        [JsonProperty("valueType", NullValueHandling = NullValueHandling.Ignore)]
        public int? ValueType { get; set; }

        /// <summary>返回表示当前对象的字符串。</summary>
        /// <returns>表示当前对象的字符串。</returns>
        public override string ToString()
        {
            return string.Format("[code={0}, extension={1}, key={2}, orderNumber={3},unit={4},value={5},valueType={6}]",
                                 Code, Extension, Key, OrderNumber, Unit, Value, ValueType);
        }
    }
}