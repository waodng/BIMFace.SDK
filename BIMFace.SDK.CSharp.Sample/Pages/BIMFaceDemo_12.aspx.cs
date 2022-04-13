using System;

using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Utils;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.Sample.Pages
{
    public partial class BIMFaceDemo_12 : System.Web.UI.Page
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

            IBasicApi api = new BasicApi();
            AccessTokenResponse response = api.GetAccessToken(_appKey, _appSecret);
            if (response != null)
            {
                txtAccessToken.Text = response.Data.Token;
            }
        }

        // 获取Hub列表
        protected void btnGetHubs_Click(object sender, EventArgs e)
        {
            txtHubId.Text = string.Empty;
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetHubs(txtAccessToken.Text);
            if (response != null)
            {
                txtHubId.Text = response.Data[0].Id;
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取项目列表
        protected void btnGetProjects_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetProjects(txtAccessToken.Text, txtHubId.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取文件夹信息
        protected void btnGetFolderInfo_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetFolder(txtAccessToken.Text, txtProjectId.Text, null, txtFolderPath.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);

                if(response.Code == "success" && response.Data != null)
                {
                    txtFolderId.Text = response.Data.Id;
                }
            }
        }

        // 获取文件夹路径
        protected void btnGetFolderPath_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetFolderPath(txtAccessToken.Text, txtProjectId.Text, txtFolderId.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取父文件夹
        protected void btnGetParentFolder_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetParentFolder(txtAccessToken.Text, txtProjectId.Text, txtFolderId.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取文件夹下的所有文件
        protected void btnGetFolderContents_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            FolderContentRequest request = new FolderContentRequest
            {
                ParentPath = txtParentPath.Text
            };

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetFolderContent(txtAccessToken.Text, txtProjectId.Text, request);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 指定目录下创建文件夹
        protected void btnCreateFolderByParentPath_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.CreateFolder(txtAccessToken.Text, txtProjectId.Text, txtFolderName.Text, txtParentPath.Text, null);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }

        }

        // 指定目录下创建文件夹 测试项目1/全部
        protected void btnCreateFolderByParentId_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.CreateFolder(txtAccessToken.Text, txtProjectId.Text, txtFolderName.Text, null, txtParentId.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }
    }
}