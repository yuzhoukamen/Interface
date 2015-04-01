namespace Windows
{
    partial class Frm_Setup
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
            this.tabControlSetup = new System.Windows.Forms.TabControl();
            this.tabPageConnectionString = new System.Windows.Forms.TabPage();
            this.tabPageOther = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxUrl = new System.Windows.Forms.TextBox();
            this.txtBoxDataBase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxPasswd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxAppTitle = new System.Windows.Forms.TextBox();
            this.txtBoxAppInfo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTips = new System.Windows.Forms.Label();
            this.tabControlSetup.SuspendLayout();
            this.tabPageConnectionString.SuspendLayout();
            this.tabPageOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSetup
            // 
            this.tabControlSetup.Controls.Add(this.tabPageConnectionString);
            this.tabControlSetup.Controls.Add(this.tabPageOther);
            this.tabControlSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlSetup.Location = new System.Drawing.Point(0, 0);
            this.tabControlSetup.Name = "tabControlSetup";
            this.tabControlSetup.SelectedIndex = 0;
            this.tabControlSetup.Size = new System.Drawing.Size(374, 181);
            this.tabControlSetup.TabIndex = 0;
            // 
            // tabPageConnectionString
            // 
            this.tabPageConnectionString.Controls.Add(this.txtBoxPasswd);
            this.tabPageConnectionString.Controls.Add(this.label4);
            this.tabPageConnectionString.Controls.Add(this.txtBoxUserName);
            this.tabPageConnectionString.Controls.Add(this.label3);
            this.tabPageConnectionString.Controls.Add(this.txtBoxDataBase);
            this.tabPageConnectionString.Controls.Add(this.label2);
            this.tabPageConnectionString.Controls.Add(this.txtBoxUrl);
            this.tabPageConnectionString.Controls.Add(this.label1);
            this.tabPageConnectionString.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnectionString.Name = "tabPageConnectionString";
            this.tabPageConnectionString.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnectionString.Size = new System.Drawing.Size(366, 155);
            this.tabPageConnectionString.TabIndex = 0;
            this.tabPageConnectionString.Text = "服务器连接参数设置";
            this.tabPageConnectionString.UseVisualStyleBackColor = true;
            // 
            // tabPageOther
            // 
            this.tabPageOther.Controls.Add(this.txtBoxAppInfo);
            this.tabPageOther.Controls.Add(this.label6);
            this.tabPageOther.Controls.Add(this.txtBoxAppTitle);
            this.tabPageOther.Controls.Add(this.label5);
            this.tabPageOther.Location = new System.Drawing.Point(4, 22);
            this.tabPageOther.Name = "tabPageOther";
            this.tabPageOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOther.Size = new System.Drawing.Size(366, 155);
            this.tabPageOther.TabIndex = 1;
            this.tabPageOther.Text = "其他参数设置";
            this.tabPageOther.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址：";
            // 
            // txtBoxUrl
            // 
            this.txtBoxUrl.Location = new System.Drawing.Point(90, 16);
            this.txtBoxUrl.Name = "txtBoxUrl";
            this.txtBoxUrl.Size = new System.Drawing.Size(268, 21);
            this.txtBoxUrl.TabIndex = 1;
            // 
            // txtBoxDataBase
            // 
            this.txtBoxDataBase.Location = new System.Drawing.Point(90, 50);
            this.txtBoxDataBase.Name = "txtBoxDataBase";
            this.txtBoxDataBase.Size = new System.Drawing.Size(268, 21);
            this.txtBoxDataBase.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库：";
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Location = new System.Drawing.Point(90, 84);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(268, 21);
            this.txtBoxUserName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名：";
            // 
            // txtBoxPasswd
            // 
            this.txtBoxPasswd.Location = new System.Drawing.Point(90, 121);
            this.txtBoxPasswd.Name = "txtBoxPasswd";
            this.txtBoxPasswd.PasswordChar = '*';
            this.txtBoxPasswd.Size = new System.Drawing.Size(268, 21);
            this.txtBoxPasswd.TabIndex = 7;
            this.txtBoxPasswd.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码：";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::Windows.ResImage.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(94, 187);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "   保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Windows.ResImage.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(184, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "   取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "应用程序标题：";
            // 
            // txtBoxAppTitle
            // 
            this.txtBoxAppTitle.Location = new System.Drawing.Point(91, 16);
            this.txtBoxAppTitle.Name = "txtBoxAppTitle";
            this.txtBoxAppTitle.Size = new System.Drawing.Size(258, 21);
            this.txtBoxAppTitle.TabIndex = 1;
            // 
            // txtBoxAppInfo
            // 
            this.txtBoxAppInfo.Location = new System.Drawing.Point(91, 55);
            this.txtBoxAppInfo.Name = "txtBoxAppInfo";
            this.txtBoxAppInfo.Size = new System.Drawing.Size(258, 21);
            this.txtBoxAppInfo.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "应用程序信息：";
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.Location = new System.Drawing.Point(292, 192);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(0, 12);
            this.lblTips.TabIndex = 3;
            // 
            // Frm_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 216);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControlSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Setup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器参数设置";
            this.Load += new System.EventHandler(this.Frm_Setup_Load);
            this.tabControlSetup.ResumeLayout(false);
            this.tabPageConnectionString.ResumeLayout(false);
            this.tabPageConnectionString.PerformLayout();
            this.tabPageOther.ResumeLayout(false);
            this.tabPageOther.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSetup;
        private System.Windows.Forms.TabPage tabPageConnectionString;
        private System.Windows.Forms.TabPage tabPageOther;
        private System.Windows.Forms.TextBox txtBoxUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxDataBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxPasswd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtBoxAppTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxAppInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTips;
    }
}