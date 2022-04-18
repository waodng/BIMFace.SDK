using CefSharp;
using CefSharp.WinForms;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    public partial class FrmCefSharpDemo3 : Form
    {
        static int CaclTimes3 = 0;

        public static Dictionary<string, FrmCefSharpDemo3_1> DicModelAndForm;    //key：BIM   Value：窗体

        public static Dictionary<string, ChromiumWebBrowser> dicFileIdAndChroms; //key：FileId 。Value：ChromiumWebBrowser 对象

        public FrmCefSharpDemo3()
        {
            InitializeComponent();

            DicModelAndForm = new Dictionary<string, FrmCefSharpDemo3_1>();
            dicFileIdAndChroms = new Dictionary<string, ChromiumWebBrowser>();

            SetControl();
        }

        private void SetControl()
        {
            tabControl.TabPages.Clear();// 删除所有Tab页
        }

        // 加载 BIMFACE 模型
        private void btnLoadBIMFaceFile1_Click(object sender, EventArgs e)
        {
            CreateTabAndLoadForm("Tab-" + (tabControl.TabPages.Count + 1));
        }

        private void CreateTabAndLoadForm(string key)
        {
            // 如果图纸已经打开，则直接切换到目标tab，无需再创建
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                if (key == tabPage.Name)
                {
                    tabControl.SelectedTab = tabPage;
                    return;
                }
            }

            TabPage newTabPage = new TabPage();
            newTabPage.Text = newTabPage.Name = key;

            FrmCefSharpDemo3_1 frm = new FrmCefSharpDemo3_1(key);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Parent = newTabPage;
            frm.Dock = DockStyle.Fill;
            frm.Show();

            tabControl.Controls.Add(newTabPage);
            tabControl.SelectedTab = newTabPage;

            DicModelAndForm.Add(key, frm);
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
        }

        /// <summary>
        /// 计算网页调用C#方法的次数
        /// </summary>
        public void CalcTimes()
        {
            ++CaclTimes3;

            lblCalcTimes.Text = CaclTimes3.ToString();
            lblCalcTimes.Refresh();
        }
    }
}
