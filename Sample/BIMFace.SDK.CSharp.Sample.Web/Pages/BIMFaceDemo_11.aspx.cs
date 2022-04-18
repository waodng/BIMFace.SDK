using System;

using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Utils;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.Sample.Pages
{
    public partial class BIMFaceDemo_11 : System.Web.UI.Page
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

        // 创建项目
        protected void btnCreateProject_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtProjectId.Text  = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.CreateProject(txtAccessToken.Text, txtHubId.Text, txtProjectName.Text);
            if (response != null)
            {
                txtProjectId.Text = response.Data.Id;

                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 删除项目
        protected void btnDeleteProject_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.DeleteProject(txtAccessToken.Text, txtHubId.Text, txtProjectId.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取项目信息
        protected void Button1_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetProjectInfo(txtAccessToken.Text, txtHubId.Text, txtProjectId.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

       
    }
}