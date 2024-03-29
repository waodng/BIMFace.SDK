﻿using System;
using System.IO;

using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Utils;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.Sample.Pages
{
    /// <summary>
    /// 示例2：源文件上传
    /// </summary>
    public partial class APIDemo2 : System.Web.UI.Page
    {
        /* 如果使用 ConfigUtility.GetAppSettingValue() 获取BIMFACE开发者配置信息，请添加 System.Configuration.ConfigurationManager.dll 6.0.0.0 引用。
        
         * 如果自定义方式获取BIMFACE开发者配置信息，请自行修改逻辑。
         */
        readonly string _appKey = ConfigUtility.GetAppSettingValue("BIMFACE_AppKey");
        readonly string _appSecret = ConfigUtility.GetAppSettingValue("BIMFACE_AppSecret");

        protected void Page_Load(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        // 获取 AccessToken
        protected void btnGetAccessToken_Click(object sender, EventArgs e)
        {
            txtAccessToken.Text = string.Empty;
            AccessTokenResponse response = GetAccessToken();
            if (response != null)
            {
                txtAccessToken.Text = response.Data.Token;
            }
        }

        // 普通文件流上传
        protected void btnUploadFileByStream_Click(object sender, EventArgs e)
        {
            string filePath = "G:\\大模型2.rvt"; //FileUpload1.PostedFile.FileName;//必须在IE兼容模式下才能获取到文件的绝对路径

            filePath = @"G:\CAD 测试图纸\建筑类\建筑图纸2-已拆分-已变更.dwg";//@"G:\智能审查测试图纸与模型\CAD\翡翠湖别院_G8#_ 电气_2019_10_17 - 95B灯具连线图.dwg"; 

            FileInfo fileInfo = new FileInfo(filePath);
            string fileName = fileInfo.Name;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            
            IFileApi api = new FileApi();
            FileUploadResponse fileUploadResponse = //api.UploadFileByPolicy(txtAccessToken.Text, filePath);
                api.UploadFileByStream(txtAccessToken.Text, fileName, fileStream);
            txtResult.Text = fileUploadResponse.SerializeToJson(true);
        }

        // 指定外部文件url方式上传
        protected void btnUploadFileByUrl_Click(object sender, EventArgs e)
        {
            string fileName = "test.rvt";
            string fileUrl = "xxxx/test.rvt";// 请替换成自己真实业务场景中的图纸所在的url地址

            IFileApi api = new FileApi();
            FileUploadResponse fileUploadResponse = api.UploadFileByUrl(txtAccessToken.Text, fileName, fileUrl);
            txtResult.Text = fileUploadResponse.SerializeToJson(true);
        }

        private AccessTokenResponse GetAccessToken()
        {
            IBasicApi api = new BasicApi();
            AccessTokenResponse response = api.GetAccessToken(_appKey, _appSecret);
            return response;
        }
    }
}