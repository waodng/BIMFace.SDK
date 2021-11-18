
namespace BIMFace.SDK.CSharp.Sample.WinForm
{
    partial class FrmCefSharpDemo2
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblCalcTimes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCsharpCallJsMethod2 = new System.Windows.Forms.Button();
            this.btnCsharpCallJsMethod1 = new System.Windows.Forms.Button();
            this.txtBIMFaceFileId2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBIMFaceFileId1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadBIMFaceFile2 = new System.Windows.Forms.Button();
            this.btnLoadBIMFaceFile1 = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblCalcTimes);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btnCsharpCallJsMethod2);
            this.splitContainer1.Panel1.Controls.Add(this.btnCsharpCallJsMethod1);
            this.splitContainer1.Panel1.Controls.Add(this.txtBIMFaceFileId2);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.txtBIMFaceFileId1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadBIMFaceFile2);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadBIMFaceFile1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(1239, 688);
            this.splitContainer1.SplitterDistance = 85;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblCalcTimes
            // 
            this.lblCalcTimes.AutoSize = true;
            this.lblCalcTimes.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lblCalcTimes.ForeColor = System.Drawing.Color.Red;
            this.lblCalcTimes.Location = new System.Drawing.Point(1174, 32);
            this.lblCalcTimes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalcTimes.Name = "lblCalcTimes";
            this.lblCalcTimes.Size = new System.Drawing.Size(45, 52);
            this.lblCalcTimes.TabIndex = 11;
            this.lblCalcTimes.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1074, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "计算次数：";
            // 
            // btnCsharpCallJsMethod2
            // 
            this.btnCsharpCallJsMethod2.Location = new System.Drawing.Point(776, 58);
            this.btnCsharpCallJsMethod2.Name = "btnCsharpCallJsMethod2";
            this.btnCsharpCallJsMethod2.Size = new System.Drawing.Size(231, 34);
            this.btnCsharpCallJsMethod2.TabIndex = 9;
            this.btnCsharpCallJsMethod2.Text = "C# 调用图纸网页 JS 方法";
            this.btnCsharpCallJsMethod2.UseVisualStyleBackColor = true;
            this.btnCsharpCallJsMethod2.Click += new System.EventHandler(this.btnCsharpCallJsMethod2_Click);
            // 
            // btnCsharpCallJsMethod1
            // 
            this.btnCsharpCallJsMethod1.Location = new System.Drawing.Point(776, 15);
            this.btnCsharpCallJsMethod1.Name = "btnCsharpCallJsMethod1";
            this.btnCsharpCallJsMethod1.Size = new System.Drawing.Size(231, 34);
            this.btnCsharpCallJsMethod1.TabIndex = 8;
            this.btnCsharpCallJsMethod1.Text = "C# 调用模型网页 JS 方法";
            this.btnCsharpCallJsMethod1.UseVisualStyleBackColor = true;
            this.btnCsharpCallJsMethod1.Click += new System.EventHandler(this.btnCsharpCallJsMethod1_Click);
            // 
            // txtBIMFaceFileId2
            // 
            this.txtBIMFaceFileId2.Location = new System.Drawing.Point(184, 60);
            this.txtBIMFaceFileId2.Name = "txtBIMFaceFileId2";
            this.txtBIMFaceFileId2.Size = new System.Drawing.Size(350, 28);
            this.txtBIMFaceFileId2.TabIndex = 5;
            this.txtBIMFaceFileId2.Text = "10000714680909";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "BIMFace FileId：";
            // 
            // txtBIMFaceFileId1
            // 
            this.txtBIMFaceFileId1.Location = new System.Drawing.Point(184, 16);
            this.txtBIMFaceFileId1.Name = "txtBIMFaceFileId1";
            this.txtBIMFaceFileId1.Size = new System.Drawing.Size(350, 28);
            this.txtBIMFaceFileId1.TabIndex = 3;
            this.txtBIMFaceFileId1.Text = "10000706968508";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "BIMFace FileId：";
            // 
            // btnLoadBIMFaceFile2
            // 
            this.btnLoadBIMFaceFile2.Location = new System.Drawing.Point(549, 56);
            this.btnLoadBIMFaceFile2.Name = "btnLoadBIMFaceFile2";
            this.btnLoadBIMFaceFile2.Size = new System.Drawing.Size(204, 34);
            this.btnLoadBIMFaceFile2.TabIndex = 1;
            this.btnLoadBIMFaceFile2.Text = "加载 BIMFACE 图纸";
            this.btnLoadBIMFaceFile2.UseVisualStyleBackColor = true;
            this.btnLoadBIMFaceFile2.Click += new System.EventHandler(this.btnLoadBIMFaceFile2_Click);
            // 
            // btnLoadBIMFaceFile1
            // 
            this.btnLoadBIMFaceFile1.Location = new System.Drawing.Point(549, 14);
            this.btnLoadBIMFaceFile1.Name = "btnLoadBIMFaceFile1";
            this.btnLoadBIMFaceFile1.Size = new System.Drawing.Size(204, 34);
            this.btnLoadBIMFaceFile1.TabIndex = 0;
            this.btnLoadBIMFaceFile1.Text = "加载 BIMFACE 模型";
            this.btnLoadBIMFaceFile1.UseVisualStyleBackColor = true;
            this.btnLoadBIMFaceFile1.Click += new System.EventHandler(this.btnLoadBIMFaceFile1_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(84, 30);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1239, 599);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1231, 561);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1231, 548);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FrmCefSharpDemo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 688);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmCefSharpDemo2";
            this.Text = "CefSharp组件加载BIMFACE模型/图纸2  复杂应用(单窗体加载多网页)";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnLoadBIMFaceFile2;
        private System.Windows.Forms.Button btnLoadBIMFaceFile1;
        private System.Windows.Forms.TextBox txtBIMFaceFileId1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBIMFaceFileId2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCsharpCallJsMethod2;
        private System.Windows.Forms.Button btnCsharpCallJsMethod1;
        private System.Windows.Forms.Label lblCalcTimes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}