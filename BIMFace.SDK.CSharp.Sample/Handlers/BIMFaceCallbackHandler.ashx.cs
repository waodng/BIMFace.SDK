using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Log;
using BIMFace.SDK.CSharp.Common.Utils;

using System;
using System.Text;
using System.Web;

namespace BIMFace.SDK.CSharp.Sample.Handlers
{
    /// <summary>
    /// BIMFaceCallbackHandler 的摘要说明
    /// </summary>
    public class BIMFaceCallbackHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentEncoding = Encoding.UTF8;

            string appKey = ConfigUtility.GetAppSettingValue("BIMFACE_AppKey");
            string appSecret = ConfigUtility.GetAppSettingValue("BIMFACE_AppSecret");
            string uid = context.Request.QueryString["uid"];  // SparkBimFace

            #region 校验
            if (appKey.IsNullOrWhiteSpace())
            {
                LogUtility.Error("BIMFace appKey 配置项没有配置！");

                return;
            }

            if (appSecret.IsNullOrWhiteSpace())
            {
                LogUtility.Error("BIMFace appSecret 配置项没有配置！");

                return;
            }

            if (uid.IsNullOrWhiteSpace())
            {
                LogUtility.Error("[非法请求]回调地址Url链接中的参数 uid 没有配置或者配置的值为空！");

                return;
            }

            #endregion

            long fileId = context.Request.QueryString["fileId"].ToLong();  // 文件ID
            string status = context.Request.QueryString["status"];         // 转换的结果
            string reason = context.Request.QueryString["reason"];         // 若转换失败，则返回失败原因
            string thumbnail = context.Request.QueryString["thumbnail"];   // 缩略图地址
            string nonce = context.Request.QueryString["nonce"];           // 回调随机数
            string signature = context.Request.QueryString["signature"];   // BIMFACE的加密签名

            string callbackResponse = string.Format("fileId:{0},\r\nstatus:{1},\r\nreason:{2},\r\nthumbnail:{3},\r\nnonce:{4},\r\nsignature:{5}",
                                                     fileId, status, reason, thumbnail, nonce, signature);
            string tip;
            string custCalcSignature;

            bool checkSignature = CallbackUtils.CheckCallbackSignature(appKey, appSecret, fileId, status, nonce, signature, out custCalcSignature);
            if (checkSignature)
            {
                tip = "[BIMFace发出的回调信息签名验证成功！]"
                      + Environment.NewLine
                      + callbackResponse;
                LogUtility.Info(tip);

                //Todo 此处可以根据fileId把相关的信息写入数据库中

                // 回执消息：应用收到回调后，须向BIMFace发送回执，回执消息：HTTP STATUS 200
                context.Response.Write("HTTP STATUS 200");
            }
            else
            {
                tip = "[BIMFace发出的回调信息签名验证不通过！]"
                    + Environment.NewLine
                    + callbackResponse
                    + Environment.NewLine
                    + "自定义计算签名 custCalcSignature：" + custCalcSignature;

                LogUtility.Error(tip);

                context.Response.Write(tip);
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