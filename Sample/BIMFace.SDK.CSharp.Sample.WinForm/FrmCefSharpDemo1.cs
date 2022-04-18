using CefSharp;

using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    public partial class FrmCefSharpDemo1 : Form
    {
        private int RegisterFlag = 0;//注册 ChromiumWebBrowserBindObject 对象标记。0：未注册，1：已注册

        public FrmCefSharpDemo1()
        {
            InitializeComponent();
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

            /* 参考：https://blog.csdn.net/cxb2011/article/details/97611337?utm_medium=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7EsearchFromBaidu%7Edefault-1.pc_relevant_baidujshouduan&depth_1-utm_source=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7EsearchFromBaidu%7Edefault-1.pc_relevant_baidujshouduan*/
            /* 如何暴露.NET 类，提供给Javascript
             * 参考：https://github.com/cefsharp/CefSharp/wiki/General-Usage#3-how-do-you-expose-a-net-class-to-javascript*/

            if (RegisterFlag == 0)
            {
                // 将 ChromiumWebBrowserBindObject 实例对象注入到 js 对象中。网页中即可调用 ChromiumWebBrowserBindObject 类中定义的属性、方法
                var objToBind = new ChromiumWebBrowserBindObject();
                chromiumWebBrowser1.JavascriptObjectRepository.Register("_chromeBrowser", objToBind, true, BindingOptions.DefaultBinder);

                RegisterFlag = 1;
            }

            string url = "https://localhost:44389/Pages/BIMFaceDemo7_3_1.html?fileId=" + fileId;
            chromiumWebBrowser1.Load(url);
        }

        // C# 调用 JS 方法
        private void btnCsharpCallJsMethod_Click(object sender, EventArgs e)
        {
            Task<JavascriptResponse> jsResponse = chromiumWebBrowser1.EvaluateScriptAsync("jsMethodForCSharpTestCalcSub", 25, 7);

            if (jsResponse.Result != null && jsResponse.Result.Success == false)
            {
                MessageBox.Show("C#调用JS方法发生异常。" + jsResponse.Result.Message
                    , "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
