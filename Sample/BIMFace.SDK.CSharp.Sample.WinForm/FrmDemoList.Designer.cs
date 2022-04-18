
namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    partial class FrmDemoList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUseCefSharpSimple = new System.Windows.Forms.Button();
            this.btnUseCefSharpComplex = new System.Windows.Forms.Button();
            this.btnUseWebView2Simple = new System.Windows.Forms.Button();
            this.btnUseCefSharpComplex2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUseCefSharpSimple
            // 
            this.btnUseCefSharpSimple.Location = new System.Drawing.Point(183, 32);
            this.btnUseCefSharpSimple.Name = "btnUseCefSharpSimple";
            this.btnUseCefSharpSimple.Size = new System.Drawing.Size(490, 54);
            this.btnUseCefSharpSimple.TabIndex = 0;
            this.btnUseCefSharpSimple.Text = "使用 CefSharp 加载网页 简单应用（单窗体加载单网页）";
            this.btnUseCefSharpSimple.UseVisualStyleBackColor = true;
            this.btnUseCefSharpSimple.Click += new System.EventHandler(this.btnUseCefSharpSimple_Click);
            // 
            // btnUseCefSharpComplex
            // 
            this.btnUseCefSharpComplex.Location = new System.Drawing.Point(183, 93);
            this.btnUseCefSharpComplex.Name = "btnUseCefSharpComplex";
            this.btnUseCefSharpComplex.Size = new System.Drawing.Size(490, 54);
            this.btnUseCefSharpComplex.TabIndex = 1;
            this.btnUseCefSharpComplex.Text = "使用 CefSharp 加载网页 复杂应用（单窗体加载多网页）";
            this.btnUseCefSharpComplex.UseVisualStyleBackColor = true;
            this.btnUseCefSharpComplex.Click += new System.EventHandler(this.btnUseCefSharpComplex_Click);
            // 
            // btnUseWebView2Simple
            // 
            this.btnUseWebView2Simple.Location = new System.Drawing.Point(183, 240);
            this.btnUseWebView2Simple.Name = "btnUseWebView2Simple";
            this.btnUseWebView2Simple.Size = new System.Drawing.Size(490, 54);
            this.btnUseWebView2Simple.TabIndex = 2;
            this.btnUseWebView2Simple.Text = "使用 WebView2 加载网页 简单应用(单窗体加载单网页）";
            this.btnUseWebView2Simple.UseVisualStyleBackColor = true;
            this.btnUseWebView2Simple.Click += new System.EventHandler(this.btnUseWebView2Simple_Click);
            // 
            // btnUseCefSharpComplex2
            // 
            this.btnUseCefSharpComplex2.Location = new System.Drawing.Point(183, 153);
            this.btnUseCefSharpComplex2.Name = "btnUseCefSharpComplex2";
            this.btnUseCefSharpComplex2.Size = new System.Drawing.Size(490, 54);
            this.btnUseCefSharpComplex2.TabIndex = 4;
            this.btnUseCefSharpComplex2.Text = "使用 CefSharp 加载网页 复杂应用（多窗体加载多网页）";
            this.btnUseCefSharpComplex2.UseVisualStyleBackColor = true;
            this.btnUseCefSharpComplex2.Click += new System.EventHandler(this.btnUseCefSharpComplex2_Click);
            // 
            // FrmDemoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 450);
            this.Controls.Add(this.btnUseCefSharpComplex2);
            this.Controls.Add(this.btnUseWebView2Simple);
            this.Controls.Add(this.btnUseCefSharpComplex);
            this.Controls.Add(this.btnUseCefSharpSimple);
            this.Name = "FrmDemoList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForm 程序加载 Web 程序汇总";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUseCefSharpSimple;
        private System.Windows.Forms.Button btnUseCefSharpComplex;
        private System.Windows.Forms.Button btnUseWebView2Simple;
        private System.Windows.Forms.Button btnUseCefSharpComplex2;
    }
}