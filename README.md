# BIMFace.SDK

#### 介绍
C#封装BIMFace服务端API，包含基础API、文件上传API、文件转换API、模型对比API以及API使用示例。

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

#### 参与贡献

1.  Fork 本仓库
2.  新建 Feat_xxx 分支
3.  提交代码
4.  新建 Pull Request

#### 码云特技

1.  使用 Readme\_XXX.md 来支持不同的语言，例如 Readme\_en.md, Readme\_zh.md
2.  码云官方博客 [blog.gitee.com](https://blog.gitee.com)
3.  你可以 [https://gitee.com/explore](https://gitee.com/explore) 这个地址来了解码云上的优秀开源项目
4.  [GVP](https://gitee.com/gvp) 全称是码云最有价值开源项目，是码云综合评定出的优秀开源项目
5.  码云官方提供的使用手册 [https://gitee.com/help](https://gitee.com/help)
6.  码云封面人物是一档用来展示码云会员风采的栏目 [https://gitee.com/gitee-stars/](https://gitee.com/gitee-stars/)
