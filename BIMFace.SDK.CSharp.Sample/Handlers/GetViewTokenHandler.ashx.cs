using System;
using System.Configuration;
using System.Text;
using System.Web;

using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Log;

namespace BIMFace.SDK.CSharp.Sample.Handlers
{
    /// <summary>
    /// GetViewTokenHandler 的摘要说明
    /// </summary>
    public class GetViewTokenHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentEncoding = Encoding.UTF8;

            string bimfaceAppKey = ConfigurationManager.AppSettings["BIMFACE_AppKey"];
            string bimfaceAppSecret = ConfigurationManager.AppSettings["BIMFACE_AppSecret"];
            if (bimfaceAppKey.IsNullOrWhiteSpace())
            {
                LogUtility.Error("web.config 中未配置 BIMFACE_AppKey。");
            }
            if (bimfaceAppSecret.IsNullOrWhiteSpace())
            {
                LogUtility.Error("web.config 中未配置 BIMFACE_AppSecret。");
            }

            string fileId = context.Request["fileId"];
            IBasicApi basicApi = new BasicApi();
            try
            {
                string accessToken = basicApi.GetAccessToken(bimfaceAppKey, bimfaceAppSecret).Data.Token;
                string viewToken = basicApi.GetViewTokenByFileId(accessToken, fileId.ToLong()).Data;

                var response = new
                {
                    code = true,
                    message = "",
                    viewToken = viewToken
                };

                context.Response.Write(response.SerializeToJson());
            }
            catch (Exception ex)
            {
                var response = new
                {
                    code = false,
                    message = "获取模型ViewToken失败。",
                    viewToken = ""
                };

                context.Response.Write(response.SerializeToJson());

                LogUtility.Error("GetViewTokenHandler 产生异常：" + ex);
            }

            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}