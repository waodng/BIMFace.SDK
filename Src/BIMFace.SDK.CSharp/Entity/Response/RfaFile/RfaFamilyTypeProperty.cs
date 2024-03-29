﻿// /* ---------------------------------------------------------------------------------------
//    文件名：RfaFamilyTypeProperty.cs
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

using Newtonsoft.Json;

namespace BIMFace.SDK.CSharp.Entity
{
    public class RfaFamilyTypeProperty
    {
        [JsonProperty("familyTypeId")]
        public string FamilyTypeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("properties")]
        public PropertyGroup[] Properties { get; set; }
    }
}