using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    public partial class FrmDemoList : Form
    {
        public static FrmCefSharpDemo2 FrmCefSharpDemo2 { get; set; }
        public static FrmCefSharpDemo3 FrmCefSharpDemo3 { get; set; }

        public static FrmCefSharpDemo5 FrmCefSharpDemo3_1 { get; set; }

        public FrmDemoList()
        {
            InitializeComponent();
        }

        // 使用 CefSharp 加载网页 简单应用（单窗体加载单网页）
        private void btnUseCefSharpSimple_Click(object sender, EventArgs e)
        {
            FrmCefSharpDemo1 frm = new FrmCefSharpDemo1();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        // 使用 CefSharp 加载网页 复杂应用（单窗体加载多网页）
        private void btnUseCefSharpComplex_Click(object sender, EventArgs e)
        {
            FrmCefSharpDemo2 frm = new FrmCefSharpDemo2();
            frm.WindowState = FormWindowState.Maximized;
            FrmCefSharpDemo2 = frm;
            frm.ShowDialog();
        }

        // 使用 CefSharp 加载网页 复杂应用（多窗体加载多网页）
        private void btnUseCefSharpComplex2_Click(object sender, EventArgs e)
        {
            FrmCefSharpDemo3 frm = new FrmCefSharpDemo3();
            frm.WindowState = FormWindowState.Maximized;
            FrmCefSharpDemo3 = frm;

            frm.ShowDialog();
        }

        // 使用 WebView2 加载网页 简单应用
        private void btnUseWebView2Simple_Click(object sender, EventArgs e)
        {
            FrmCefSharpDemo4 frm = new FrmCefSharpDemo4();
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

       
    }
}
