﻿using System;
using System.Threading.Tasks;

using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Cache;
using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Utils;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.Sample.Pages
{
    /// <summary>
    /// 示例1：获取 Access Token
    /// </summary>
    public partial class APIDemo1 : System.Web.UI.Page
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
            txtResult.Text = string.Empty;

            AccessTokenResponse response = GetAccessToken();
            if (response != null)
            {
                txtAccessToken.Text = response.Data.Token;
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        private AccessTokenResponse GetAccessToken()
        {
            IBasicApi api = new BasicApi();
            AccessTokenResponse response = api.GetAccessToken(_appKey, _appSecret);
            return response;
        }

        private async Task<AccessTokenResponse> GetAccessTokenAsync()
        {
            IBasicApi api = new BasicApi();
            AccessTokenResponse response = await api.GetAccessTokenAsync(_appKey, _appSecret);
            return response;
        }

        // 缓存方式获取 AccessToken
        protected void btnGetAccessTokenFormCache_Click(object sender, EventArgs e)
        {
            txtAccessToken.Text = string.Empty;
            txtResult.Text = string.Empty;

            AccessTokenResponse response = null;

            string cacheKey = _appKey + "-" + _appSecret;//自定义缓存键
            var cacheValue = MemoryCacheUtils.GetItem(cacheKey);//从缓存中获取
            if (cacheValue != null)
            {
                response = cacheValue as AccessTokenResponse;
            }
            else
            {
                //没有缓存
                response = GetAccessToken(); //直接调用接口获取AccessToken值

                //MemoryCacheUtils.SetItem(cacheKey, response, response.Data.ExpireTime.ToDateTime());//该方式不保险
                MemoryCacheUtils.SetItem(cacheKey, response, response.Data.ExpireTime.ToDateTime().AddSeconds(-5));//保险安全的缓存方式
            }

            txtAccessToken.Text = response.Data.Token;
            txtResult.Text = response.SerializeToJson(true);
        }
    }
}