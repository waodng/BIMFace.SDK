// /* ---------------------------------------------------------------------------------------
//    文件名：BIMFaceDemo5.cs
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

using System;

using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Utils;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.Sample.Pages
{
    public partial class BIMFaceDemo5 : System.Web.UI.Page
    {
        readonly string _appKey = ConfigUtility.GetAppSettingValue("BIMFACE_AppKey");
        readonly string _appSecret = ConfigUtility.GetAppSettingValue("BIMFACE_AppSecret");
        private readonly string _callback = ConfigUtility.GetAppSettingValue("BIMFACE_Callback");

        protected void Page_Load(object sender, EventArgs e)
        {

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

        // 开始集成
        protected void btnStartIntegrate_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long followingId = txtFile1Id.Text.ToLong();
            long previousId = txtFile2Id.Text.ToLong();

            IModelIntegrateApi api = new ModelIntegrateApi();
            ModelIntegrateResponse response = api.Integrate(txtAccessToken.Text, followingId,previousId);

            txtResult.Text = response.SerializeToJson(true);
            txtIntegratID.Text = response.Data.IntegrateId.ToString();
        }

        // 获取集成状态
        protected void btnGetIntegrateStatus_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long integrateId = txtIntegratID.Text.ToLong();
            IModelIntegrateApi api = new ModelIntegrateApi();
            ModelIntegrateResponse response = api.GetIntegrateStatus(txtAccessToken.Text, integrateId);

            txtResult.Text = response.SerializeToJson(true);
        }
    }
}