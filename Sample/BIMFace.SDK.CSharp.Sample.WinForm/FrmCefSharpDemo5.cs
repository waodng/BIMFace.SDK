﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using CefSharp;
using CefSharp.WinForms;

namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    public partial class FrmCefSharpDemo5 : Form
    {
        static int CaclTimes31 = 0;

        string TabKey = string.Empty;
        Dictionary<string, ChromiumWebBrowser> dicFileIdAndChroms; //key： FileId 。Value：ChromiumWebBrowser 对象

        public static FrmCefSharpDemo5 Form;

        public FrmCefSharpDemo5(string tabKey)
        {
            InitializeComponent();

            tabControl.TabPages.Clear();

            TabKey = tabKey;

            dicFileIdAndChroms = new Dictionary<string, ChromiumWebBrowser>();

            Form = this;
        }

        // 设置控件
      
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
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                if (bimFaceFileId == tabPage.Name)
                {
                    tabControl.SelectedTab = tabPage;
                    return;
                }
            }

            ChromiumWebBrowser chromeBrowser = new ChromiumWebBrowser();
            chromeBrowser.ActivateBrowserOnCreation = false;
            chromeBrowser.Dock = DockStyle.Fill;

            TabPage newTabPage = new TabPage();
            newTabPage.Text = newTabPage.Name = bimFaceFileId;
            newTabPage.Controls.Add(chromeBrowser);

            tabControl.TabPages.Add(newTabPage);
            tabControl.SelectedTab = newTabPage;

            // 文件已在BIMFACE平台转换。使用BIMFACE查看器查看模型
            LoadChromium(chromeBrowser, bimFaceFileId);

            dicFileIdAndChroms.Add(bimFaceFileId, chromeBrowser);// 将图纸与浏览器对象加入集合
        }

        private void LoadChromium(ChromiumWebBrowser chromeBrowser, string bimFaceFileId)
        {
            /* 参考：https://blog.csdn.net/cxb2011/article/details/97611337?utm_medium=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7EsearchFromBaidu%7Edefault-1.pc_relevant_baidujshouduan&depth_1-utm_source=distribute.pc_relevant_t0.none-task-blog-2%7Edefault%7EsearchFromBaidu%7Edefault-1.pc_relevant_baidujshouduan*/
            /* 如何暴露.NET 类，提供给Javascript
             * 参考：https://github.com/cefsharp/CefSharp/wiki/General-Usage#3-how-do-you-expose-a-net-class-to-javascript*/

            var objToBind = new ChromiumWebBrowserBindObject3();
            chromeBrowser.JavascriptObjectRepository.Register("_chromeBrowser", objToBind, true, BindingOptions.DefaultBinder);

            string url = "https://localhost:44389/Pages/BIMFaceDemo7_3_3.html?fileId=" + bimFaceFileId;
            chromeBrowser.Load(url);
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
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                if (fileId == tabPage.Name)
                {
                    tabControl.SelectedTab = tabPage;

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
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                if (fileId == tabPage.Name)
                {
                    tabControl.SelectedTab = tabPage;

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

        /// <summary>
        /// 计算网页调用C#方法的次数
        /// </summary>
        public void CalcTimes()
        {
            ++CaclTimes31;

            lblCalcTimes.Text = CaclTimes31.ToString();
            lblCalcTimes.Refresh();
        }
    }
}
