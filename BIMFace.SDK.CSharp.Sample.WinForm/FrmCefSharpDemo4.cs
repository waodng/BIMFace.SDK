using CefSharp;

using System;
using System.Windows.Forms;

namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    public partial class FrmCefSharpDemo4 : Form
    {
        public FrmCefSharpDemo4()
        {
            InitializeComponent();

            InitializeAsync();
        }

        async void InitializeAsync()
        {
            await webView2.EnsureCoreWebView2Async(null);
        }

        private void chromiumWebBrowser1_LoadError(object sender, LoadErrorEventArgs e)
        {
            MessageBox.Show("加载网页出错o(╥﹏╥)o"
                + Environment.NewLine
                + Environment.NewLine
                + "FailedUrl：" + e.FailedUrl
                + Environment.NewLine
                + "ErrorCode：" + e.ErrorCode
                + Environment.NewLine
                + "ErrorText：" + e.ErrorText,
                "提示",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        // 加载模型/图纸
        private void btnLaodBIMFaceFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("窗体中加载的网页来自 BIMFace.SDK.CSharp.Sample.Web 项目。\r\n请先运行Web项目。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string fileId = txtBIMFaceFileId.Text.Trim();
            if (string.IsNullOrEmpty(fileId))
            {
                MessageBox.Show("请填写 BIMFACE FileId。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBIMFaceFileId.Focus();

                return;
            }

            // 想网页注册C#对象，供JS调用
            webView2.CoreWebView2.AddHostObjectToScript("webView2Obj", new WebView2HostObject());

            string url = "https://localhost:44389/Pages/BIMFaceDemo7_4_1.html?fileId=" + fileId;
            webView2.Source = new Uri(url);
        }

        // C# 调用 JS 方法
        private async void btnCsharpCallJsMethod_Click(object sender, EventArgs e)
        {
            var jsResult = await webView2.CoreWebView2.ExecuteScriptAsync($"jsMethodForCSharpTestCalcSub({11},{5})");
            if (!string.IsNullOrEmpty(jsResult))
            {
                MessageBox.Show("C#调用JS方法，回传结果：" + jsResult, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
