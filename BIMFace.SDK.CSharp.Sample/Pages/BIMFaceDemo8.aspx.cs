// /* ---------------------------------------------------------------------------------------
//    文件名：BIMFaceDemo8.cs
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
    public partial class BIMFaceDemo8 : System.Web.UI.Page
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

        // 创建文件离线数据包
        protected void btnCreateOffilineDataBagByFileId_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long id = txtFileId.Text.ToLong();

            IOfflineDatabagApi api = new OfflineDatabagApi();
            DatabagDerivativeCreateResponse response = api.CreateDatabagByFileId(txtAccessToken.Text, id);

            txtResult.Text = response.SerializeToJson(true);
        }

        // 创建集成文件离线数据包
        protected void btnCreateOffilineDataBagByIntegratId_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long id = txtIntegratId.Text.ToLong();

            IOfflineDatabagApi api = new OfflineDatabagApi();
            DatabagDerivativeCreateResponse response = api.CreateDatabagByIntegrateId(txtAccessToken.Text, id);

            txtResult.Text = response.SerializeToJson(true);
        }

        // 创建对比文件离线数据包
        protected void btnCreateOffilineDataBagByCompareId_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long id = txtCompareId.Text.ToLong();
            IOfflineDatabagApi api = new OfflineDatabagApi();
            DatabagDerivativeCreateResponse response = api.CreateDatabagByCompareId(txtAccessToken.Text, id);

            txtResult.Text = response.SerializeToJson(true);
        }

        // 查询文件离线数据包
        protected void btnQueryOffilineDataBagByFileId_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long id = txtFileId.Text.ToLong();
            IOfflineDatabagApi api = new OfflineDatabagApi();
            DatabagDerivativeQueryResponse response = api.QueryDatabagByFileId(txtAccessToken.Text, id);

            txtResult.Text = response.SerializeToJson(true);
        }

        // 查询集成文件离线数据包
        protected void btnQueryOffilineDataBagByIntegratId_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long id = txtIntegratId.Text.ToLong();
            IOfflineDatabagApi api = new OfflineDatabagApi();
            DatabagDerivativeQueryResponse response = api.QueryDatabagByIntegrateId(txtAccessToken.Text, id);

            txtResult.Text = response.SerializeToJson(true);
        }

        // 查询对比文件离线数据包
        protected void btnQueryOffilineDataBagByCompareId_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long id = txtCompareId.Text.ToLong();
            IOfflineDatabagApi api = new OfflineDatabagApi();
            DatabagDerivativeQueryResponse response = api.QueryDatabagByCompareId(txtAccessToken.Text, id);

            txtResult.Text = response.SerializeToJson(true);
        }

        // 获取数据包下载地址
        protected void btnQueryOffilineDataBagDownloadUrlByFileId_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long id = txtFileId.Text.ToLong();
            IOfflineDatabagApi api = new OfflineDatabagApi();
            GetUrlSwaggerDisplay response = api.GetDatabagDownloadUrlByFileId(txtAccessToken.Text, id);

            txtResult.Text = response.SerializeToJson(true);

            txtOffilineDataBagDownloadUrl.Text = response.Data ?? string.Empty;
        }

        // 获取数据包下载地址(集成)
        protected void btnQueryOffilineDataBagDownloadUrlByIntegratId_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long id = txtIntegratId.Text.ToLong();
            IOfflineDatabagApi api = new OfflineDatabagApi();
            GetUrlSwaggerDisplay response = api.GetDatabagDownloadUrlByIntegrateId(txtAccessToken.Text, id);

            txtResult.Text = response.SerializeToJson(true);

            txtOffilineDataBagDownloadUrl.Text = response.Data ?? string.Empty;
        }

        // 获取数据包下载地址(集成)
        protected void btnQueryOffilineDataBagDownloadUrlByCompareId_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            long id = txtCompareId.Text.ToLong();
            IOfflineDatabagApi api = new OfflineDatabagApi();
            GetUrlSwaggerDisplay response = api.GetDatabagDownloadUrlByCompareId(txtAccessToken.Text, id);

            txtResult.Text = response.SerializeToJson(true);

            txtOffilineDataBagDownloadUrl.Text = response.Data ?? string.Empty;
        }

        // 下载离线数据包
        protected void btnDownloadOffilineDataBag_Click(object sender, EventArgs e)
        {


        }
    }
}