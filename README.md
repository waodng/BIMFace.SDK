# BIMFace.SDK

#### 介绍
【 **BIMFace.SDK.CSharp** 】不是BIMFace官方提供的SDK，而是由广联达开发者网络GDN先锋会员- **南京群耀智远信息科技有限公司 http://www.sparkcn.com** 提供的开源免费SDK。作者也是BIMFace产品的深度用户、BIMFace社区的参与者与贡献者。

【 **BIMFace.SDK.CSharp** 】 是基于微软.NET 技术封装的用于 BIMFACE 二次开发的通用类库。其中封装了BIMFace服务端API，包含基础API、文件上传API、文件转换API、模型集成API、模型对比API、模型构建属性重写API、模型信息和构建属性查询API、构建空间关系计算API、转换/集成/对比数据包相关API、离线数据包API、导出数据包相关API、烘焙API、rfa构建数据API、分享链接API、回调API等服务器端接口。

#### 软件架构
本项目使用 .NET Framework 4.5、VS2019 创建。 如果使用低版本的VS，请自行创建解决方案，然后手动添加 BIMFace.SDK.CSharp、BIMFace.SDK.CSharp.Common、BIMFace.SDK.CSharp.Sample 项目即可。

#### 使用说明

1、下载完整项目，本项目使用VS2019创建，使用VS2019打开该项目。 
2、重新生成解决方案。 
3、项目结构说明 
（1）BIMFace.SDK.CSharp 为 SDK，里面包含了基础API、文件上传API、文件转换API、模型对比API等。 
（2）BIMFace.SDK.CSharp.Common 为项目公用类库。 
（3）BIMFace.SDK.CSharp.Sample 为API使用示例。编译时会自动还原NuGet包。
4、BIMFace.SDK.CSharp.Sample 为示例项目，使用前需要在web.config中配置 BIMFACE 的BIMFACE_AppKey、BIMFACE_AppSecret、BIMFACE_Callback。

SDK中的所有API的详细请阅读作者的博客：《C# 开发 BIMFACE 系列》 https://www.cnblogs.com/SavionZhang/p/11424431.html

大家在使用过程中，如遇到任何问题请联系作者，QQ：905442693 微信：savionzhang。