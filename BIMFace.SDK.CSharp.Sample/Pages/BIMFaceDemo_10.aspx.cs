using System;

using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Utils;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.Sample.Pages
{
    public partial class BIMFaceDemo10 : System.Web.UI.Page
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

        // 获取Hub Meta信息
        protected void btnGetHubMeta_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetHubMeta(txtAccessToken.Text, txtHubId.Text.Trim());
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }
    }
}