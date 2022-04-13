﻿using System;
using System.IO;

using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Utils;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.Sample.Pages
{
    public partial class APIDemo3 : System.Web.UI.Page
    {
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

        // 获取policy凭证
        protected void btnGetPolicy_Click(object sender, EventArgs e)
        {
            string filePath = @"G:\BIM 示例模型\01_BIMFACE示例文件-Revit模型5.rvt"; //FileUpload1.PostedFile.FileName; //必须在IE兼容模式下才能获取到文件的绝对路径

            FileInfo fileInfo = new FileInfo(filePath);
            string fileName = fileInfo.Name;

            IFileApi api = new FileApi();
            FileUploadPolicyResponse policyResponse = api.GetFileUploadPolicy(txtAccessToken.Text, fileName);
            txtResult.Text = policyResponse.SerializeToJson(true);
        }

        // 文件直传
        protected void btnUploadFileByUrl_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload1.PostedFile.FileName; //必须在IE兼容模式下才能获取到文件的绝对路径
            
            IFileApi api = new FileApi();

            filePath = @"G:\BIM 示例模型\01_BIMFACE示例文件-Revit模型5.rvt";
            FileUploadResponse fileUploadResponse = api.UploadFileByPolicy(txtAccessToken.Text, filePath);
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