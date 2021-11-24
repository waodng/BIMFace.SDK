
namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    partial class FrmCefSharpDemo4
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCsharpCallJsMethod = new System.Windows.Forms.Button();
            this.btnLaodBIMFaceFile = new System.Windows.Forms.Button();
            this.txtBIMFaceFileId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCsharpCallJsMethod);
            this.panel1.Controls.Add(this.btnLaodBIMFaceFile);
            this.panel1.Controls.Add(this.txtBIMFaceFileId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1120, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnCsharpCallJsMethod
            // 
            this.btnCsharpCallJsMethod.Location = new System.Drawing.Point(724, 9);
            this.btnCsharpCallJsMethod.Name = "btnCsharpCallJsMethod";
            this.btnCsharpCallJsMethod.Size = new System.Drawing.Size(156, 34);
            this.btnCsharpCallJsMethod.TabIndex = 3;
            this.btnCsharpCallJsMethod.Text = "C# 调用 JS 方法";
            this.btnCsharpCallJsMethod.UseVisualStyleBackColor = true;
            this.btnCsharpCallJsMethod.Click += new System.EventHandler(this.btnCsharpCallJsMethod_Click);
            // 
            // btnLaodBIMFaceFile
            // 
            this.btnLaodBIMFaceFile.Location = new System.Drawing.Point(549, 9);
            this.btnLaodBIMFaceFile.Name = "btnLaodBIMFaceFile";
            this.btnLaodBIMFaceFile.Size = new System.Drawing.Size(156, 34);
            this.btnLaodBIMFaceFile.TabIndex = 2;
            this.btnLaodBIMFaceFile.Text = "加载模型/图纸";
            this.btnLaodBIMFaceFile.UseVisualStyleBackColor = true;
            this.btnLaodBIMFaceFile.Click += new System.EventHandler(this.btnLaodBIMFaceFile_Click);
            // 
            // txtBIMFaceFileId
            // 
            this.txtBIMFaceFileId.Location = new System.Drawing.Point(184, 14);
            this.txtBIMFaceFileId.Name = "txtBIMFaceFileId";
            this.txtBIMFaceFileId.Size = new System.Drawing.Size(350, 28);
            this.txtBIMFaceFileId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIMFace FileId：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.webView2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1120, 532);
            this.panel2.TabIndex = 1;
            // 
            // webView2
            // 
            this.webView2.CreationProperties = null;
            this.webView2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView2.Location = new System.Drawing.Point(0, 0);
            this.webView2.Name = "webView2";
            this.webView2.Size = new System.Drawing.Size(1120, 532);
            this.webView2.TabIndex = 0;
            this.webView2.ZoomFactor = 1D;
            // 
            // FrmCefSharpDemo4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 582);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCefSharpDemo4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebView2组件加载BIMFACE模型/图纸1  简单应用（单窗体加载单网页）";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLaodBIMFaceFile;
        private System.Windows.Forms.TextBox txtBIMFaceFileId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCsharpCallJsMethod;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
    }
}

