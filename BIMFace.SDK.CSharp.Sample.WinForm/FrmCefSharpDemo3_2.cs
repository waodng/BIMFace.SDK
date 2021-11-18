using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;

using DevComponents.DotNetBar;

namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    public partial class FrmCefSharpDemo3_2 : Form
    {
        public static int CaclTimes = 0;
        private int RegisterFlag = 0; //注册 ChromiumWebBrowserBindObject 对象标记。0：未注册，1：已注册
        private int RegisterFlag2 = 0;//注册 ChromiumWebBrowserBindObject 对象标记。0：未注册，1：已注册


        Dictionary<string, ChromiumWebBrowser> dicFileIdAndChroms; //key： FileId 。Value：ChromiumWebBrowser 对象

        public static FrmCefSharpDemo3_2 Form; 

        public FrmCefSharpDemo3_2()
        {
            InitializeComponent();

            dicFileIdAndChroms = new Dictionary<string, ChromiumWebBrowser>();

            SetControl();

            Form = this;
        }

        // 设置控件
        private void SetControl()
        {
            tabControl.CloseButtonOnTabsVisible = true;
            tabControl.CloseButtonPosition = eTabCloseButtonPosition.Right;
            tabControl.Tabs.Clear();// 删除所有Tab页
            tabControl.TabItemClose += TabControl1_TabItemClose;
        }

        private void TabControl1_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            if (dicFileIdAndChroms.ContainsKey(tabControl.SelectedTab.Name))
            {
                dicFileIdAndChroms.Remove(tabControl.SelectedTab.Name); // 从集合中移除对应的键值对
            }

            tabControl.Tabs.Remove(tabControl.SelectedTab);// 关闭Tab页签（必须在删除字典之后进行）
        }

        // 加载 BIMFACE 模型
        private void btnLoadBIMFaceFile1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("窗体中加载的网页来自 BIMFace.SDK.CSharp.Sample.Web 项目。\r\n请先运行Web项目。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string fileId = txtBIMFaceFileId1.Text.Trim();
            if (string.IsNullOrEmpty(fileId))
            {
                MessageBox.Show("请填写 BIMFACE FileId。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBIMFaceFileId1.Focus();

                return;
            }

            CreateTabAndLoadChromium(fileId);
        }

        // 加载 BIMFACE 图纸
        private void btnLoadBIMFaceFile2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("窗体中加载的网页来自 BIMFace.SDK.CSharp.Sample.Web 项目。\r\n请先运行Web项目。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string fileId = txtBIMFaceFileId2.Text.Trim();
            if (string.IsNullOrEmpty(fileId))
            {
                MessageBox.Show("请填写 BIMFACE FileId。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBIMFaceFileId2.Focus();

                return;
            }

            CreateTabAndLoadChromium(fileId);
        }

        private void CreateTabAndLoadChromium(string bimFaceFileId)
        {
            // 如果图纸已经打开，则直接切换到目标tab，无需再创建
            foreach (TabItem tItem in tabControl.Tabs)
            {
                if (bimFaceFileId == tItem.Name)
                {
                    tabControl.SelectedTab = tItem;
                    return;
                }
            }

            ChromiumWebBrowser chromeBrowser = new ChromiumWebBrowser();
            chromeBrowser.ActivateBrowserOnCreation = false;
            chromeBrowser.Dock = DockStyle.Fill;

            TabControlPanel tabPanel = new TabControlPanel();
            tabPanel.Name = bimFaceFileId;

            TabItem tabItem = tabControl.CreateTab(bimFaceFileId);
            tabItem.Name = bimFaceFileId;
            tabItem.Text = bimFaceFileId;
            tabItem.AttachedControl = tabPanel;

            tabPanel.TabItem = tabItem;
            tabPanel.Dock = DockStyle.Fill;

            tabPanel.Controls.Add(chromeBrowser);

            tabControl.Controls.Add(tabPanel);
            tabControl.SelectedTab = tabItem;

            // 文件已在BIMFACE平台转换。使用BIMFACE查看器查看模型
            LoadChromium(chromeBrowser, bimFaceFileId);

            dicFileIdAndChroms.Add(bimFaceFileId, chromeBrowser);// 将图纸与浏览器对象加入集合
        }

        private void LoadChromium(ChromiumWebBrowser chromeBrowser, string bimFaceFileId)
        {
            /* 参考：https://blog.csdn.net/cxb2011/article/details/97611337?utm_medium=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7EsearchFromBaidu%7Edefault-1.pc_relevant_baidujshouduan&depth_1-utm_source=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7EsearchFromBaidu%7Edefault-1.pc_relevant_baidujshouduan*/
            /* 如何暴露.NET 类，提供给Javascript
             * 参考：https://github.com/cefsharp/CefSharp/wiki/General-Usage#3-how-do-you-expose-a-net-class-to-javascript*/

            var objToBind = new ChromiumWebBrowserBindObject2();
            chromeBrowser.JavascriptObjectRepository.Register("_chromeBrowser", objToBind, true, BindingOptions.DefaultBinder);

            string url = "https://localhost:44389/Pages/BIMFaceDemo7_3_2.html?fileId=" + bimFaceFileId;
            chromeBrowser.Load(url);
        }

        /// <summary>
        /// 计算网页调用C#方法的次数
        /// </summary>
        public void CalcTimes()
        {
            ++CaclTimes;

            lblCalcTimes.Text = CaclTimes.ToString();
            lblCalcTimes.Refresh();
        }

        // C# 调用模型网页 JS 方法
        private void btnCsharpCallJsMethod1_Click(object sender, EventArgs e)
        {
            string fileId = txtBIMFaceFileId1.Text.Trim();
            if (string.IsNullOrEmpty(fileId))
            {
                MessageBox.Show("请填写 BIMFACE FileId。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBIMFaceFileId1.Focus();

                return;
            }

            // 如果图纸已经打开，则直接切换到目标tab，无需再创建
            foreach (TabItem tItem in tabControl.Tabs)
            {
                if (fileId == tItem.Name)
                {
                    tabControl.SelectedTab = tItem;

                    Task<JavascriptResponse> jsResponse = dicFileIdAndChroms[fileId].EvaluateScriptAsync("jsMethodForCSharpTestCalcSub", 25, 7);

                    if (jsResponse.Result != null && jsResponse.Result.Success == false)
                    {
                        MessageBox.Show("C#调用JS方法发生异常。" + jsResponse.Result.Message
                            , "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }
            }

            // 未加载模型，直接加载
            CreateTabAndLoadChromium(fileId);
        }

        // C# 调用图纸网页 JS 方法
        private void btnCsharpCallJsMethod2_Click(object sender, EventArgs e)
        {
            string fileId = txtBIMFaceFileId2.Text.Trim();
            if (string.IsNullOrEmpty(fileId))
            {
                MessageBox.Show("请填写 BIMFACE FileId。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBIMFaceFileId2.Focus();

                return;
            }

            // 如果图纸已经打开，则直接切换到目标tab，无需再创建
            foreach (TabItem tItem in tabControl.Tabs)
            {
                if (fileId == tItem.Name)
                {
                    tabControl.SelectedTab = tItem;

                    Task<JavascriptResponse> jsResponse = dicFileIdAndChroms[fileId].EvaluateScriptAsync("jsMethodForCSharpTestCalcSub", 19, 15);

                    if (jsResponse.Result != null && jsResponse.Result.Success == false)
                    {
                        MessageBox.Show("C#调用JS方法发生异常。" + jsResponse.Result.Message
                            , "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }
            }

            // 未加载图纸，直接加载
            CreateTabAndLoadChromium(fileId);

        }
    }
}
