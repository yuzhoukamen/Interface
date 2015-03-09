namespace Windows
{
    partial class Frm_Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageIDCard = new System.Windows.Forms.TabPage();
            this.pictureBoxPerson = new System.Windows.Forms.PictureBox();
            this.richBoxResult = new System.Windows.Forms.RichTextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.tabPageInterface = new System.Windows.Forms.TabPage();
            this.panelParameter = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxLoginID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxLoginPasswd = new System.Windows.Forms.TextBox();
            this.btnLoginGet = new System.Windows.Forms.Button();
            this.btnLoginUpdate = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxServlet = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInterfaceInit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxFuncID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxIDCard = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxHospitalID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBoxBiz = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoxCenterID = new System.Windows.Forms.TextBox();
            this.btnBIZC131101 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageIDCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerson)).BeginInit();
            this.tabPageInterface.SuspendLayout();
            this.panelParameter.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageIDCard);
            this.tabControl1.Controls.Add(this.tabPageInterface);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(944, 483);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageIDCard
            // 
            this.tabPageIDCard.Controls.Add(this.pictureBoxPerson);
            this.tabPageIDCard.Controls.Add(this.richBoxResult);
            this.tabPageIDCard.Controls.Add(this.txtBoxName);
            this.tabPageIDCard.Controls.Add(this.label1);
            this.tabPageIDCard.Controls.Add(this.btnCheck);
            this.tabPageIDCard.Location = new System.Drawing.Point(4, 22);
            this.tabPageIDCard.Name = "tabPageIDCard";
            this.tabPageIDCard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIDCard.Size = new System.Drawing.Size(936, 457);
            this.tabPageIDCard.TabIndex = 0;
            this.tabPageIDCard.Text = "身份证验证";
            this.tabPageIDCard.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPerson
            // 
            this.pictureBoxPerson.Location = new System.Drawing.Point(24, 65);
            this.pictureBoxPerson.Name = "pictureBoxPerson";
            this.pictureBoxPerson.Size = new System.Drawing.Size(172, 165);
            this.pictureBoxPerson.TabIndex = 4;
            this.pictureBoxPerson.TabStop = false;
            // 
            // richBoxResult
            // 
            this.richBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richBoxResult.Location = new System.Drawing.Point(202, 54);
            this.richBoxResult.Name = "richBoxResult";
            this.richBoxResult.Size = new System.Drawing.Size(473, 352);
            this.richBoxResult.TabIndex = 3;
            this.richBoxResult.Text = "";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(65, 23);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(131, 21);
            this.txtBoxName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名:";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(215, 21);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(54, 23);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "校验";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // tabPageInterface
            // 
            this.tabPageInterface.Controls.Add(this.groupBox1);
            this.tabPageInterface.Controls.Add(this.panelParameter);
            this.tabPageInterface.Location = new System.Drawing.Point(4, 22);
            this.tabPageInterface.Name = "tabPageInterface";
            this.tabPageInterface.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInterface.Size = new System.Drawing.Size(936, 457);
            this.tabPageInterface.TabIndex = 1;
            this.tabPageInterface.Text = "湖南创智接口访问";
            this.tabPageInterface.UseVisualStyleBackColor = true;
            // 
            // panelParameter
            // 
            this.panelParameter.Controls.Add(this.flowLayoutPanel2);
            this.panelParameter.Controls.Add(this.flowLayoutPanel1);
            this.panelParameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelParameter.Location = new System.Drawing.Point(3, 3);
            this.panelParameter.Name = "panelParameter";
            this.panelParameter.Size = new System.Drawing.Size(930, 110);
            this.panelParameter.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.txtBoxLoginID);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.txtBoxLoginPasswd);
            this.flowLayoutPanel2.Controls.Add(this.btnLoginGet);
            this.flowLayoutPanel2.Controls.Add(this.btnLoginUpdate);
            this.flowLayoutPanel2.Controls.Add(this.btnLogin);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 58);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(930, 39);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "登陆账号：";
            // 
            // txtBoxLoginID
            // 
            this.txtBoxLoginID.Location = new System.Drawing.Point(68, 3);
            this.txtBoxLoginID.Name = "txtBoxLoginID";
            this.txtBoxLoginID.Size = new System.Drawing.Size(97, 21);
            this.txtBoxLoginID.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "登陆密码：";
            // 
            // txtBoxLoginPasswd
            // 
            this.txtBoxLoginPasswd.Location = new System.Drawing.Point(241, 3);
            this.txtBoxLoginPasswd.Name = "txtBoxLoginPasswd";
            this.txtBoxLoginPasswd.Size = new System.Drawing.Size(145, 21);
            this.txtBoxLoginPasswd.TabIndex = 7;
            // 
            // btnLoginGet
            // 
            this.btnLoginGet.Location = new System.Drawing.Point(392, 3);
            this.btnLoginGet.Name = "btnLoginGet";
            this.btnLoginGet.Size = new System.Drawing.Size(87, 23);
            this.btnLoginGet.TabIndex = 8;
            this.btnLoginGet.Text = "获取登陆信息";
            this.btnLoginGet.UseVisualStyleBackColor = true;
            this.btnLoginGet.Click += new System.EventHandler(this.btnLoginGet_Click);
            // 
            // btnLoginUpdate
            // 
            this.btnLoginUpdate.Location = new System.Drawing.Point(485, 3);
            this.btnLoginUpdate.Name = "btnLoginUpdate";
            this.btnLoginUpdate.Size = new System.Drawing.Size(94, 23);
            this.btnLoginUpdate.TabIndex = 9;
            this.btnLoginUpdate.Text = "修改登陆账户";
            this.btnLoginUpdate.UseVisualStyleBackColor = true;
            this.btnLoginUpdate.Click += new System.EventHandler(this.btnLoginUpdate_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(585, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "接口登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxServer);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxPort);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxServlet);
            this.flowLayoutPanel1.Controls.Add(this.btnInit);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel1.Controls.Add(this.btnInterfaceInit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(930, 58);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "服务器地址：";
            // 
            // txtBoxServer
            // 
            this.txtBoxServer.Location = new System.Drawing.Point(80, 3);
            this.txtBoxServer.Name = "txtBoxServer";
            this.txtBoxServer.Size = new System.Drawing.Size(97, 21);
            this.txtBoxServer.TabIndex = 1;
            this.txtBoxServer.Text = "192.168.1.254";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口号：";
            // 
            // txtBoxPort
            // 
            this.txtBoxPort.Location = new System.Drawing.Point(241, 3);
            this.txtBoxPort.Name = "txtBoxPort";
            this.txtBoxPort.Size = new System.Drawing.Size(44, 21);
            this.txtBoxPort.TabIndex = 3;
            this.txtBoxPort.Text = "7001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "入口Servlet名称：";
            // 
            // txtBoxServlet
            // 
            this.txtBoxServlet.Location = new System.Drawing.Point(403, 3);
            this.txtBoxServlet.Name = "txtBoxServlet";
            this.txtBoxServlet.Size = new System.Drawing.Size(262, 21);
            this.txtBoxServlet.TabIndex = 5;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(671, 3);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 6;
            this.btnInit.Text = "初始化参数";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(752, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "修改参数";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInterfaceInit
            // 
            this.btnInterfaceInit.Location = new System.Drawing.Point(3, 32);
            this.btnInterfaceInit.Name = "btnInterfaceInit";
            this.btnInterfaceInit.Size = new System.Drawing.Size(102, 23);
            this.btnInterfaceInit.TabIndex = 8;
            this.btnInterfaceInit.Text = "初始化医保接口";
            this.btnInterfaceInit.UseVisualStyleBackColor = true;
            this.btnInterfaceInit.Click += new System.EventHandler(this.btnInterfaceInit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel3);
            this.groupBox1.Location = new System.Drawing.Point(6, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 330);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通过个人标识取人员信息";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label7);
            this.flowLayoutPanel3.Controls.Add(this.txtBoxFuncID);
            this.flowLayoutPanel3.Controls.Add(this.label8);
            this.flowLayoutPanel3.Controls.Add(this.txtBoxIDCard);
            this.flowLayoutPanel3.Controls.Add(this.label9);
            this.flowLayoutPanel3.Controls.Add(this.txtBoxHospitalID);
            this.flowLayoutPanel3.Controls.Add(this.label10);
            this.flowLayoutPanel3.Controls.Add(this.txtBoxBiz);
            this.flowLayoutPanel3.Controls.Add(this.label11);
            this.flowLayoutPanel3.Controls.Add(this.txtBoxCenterID);
            this.flowLayoutPanel3.Controls.Add(this.btnBIZC131101);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(246, 310);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 7, 0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "业务功能号：";
            // 
            // txtBoxFuncID
            // 
            this.txtBoxFuncID.Location = new System.Drawing.Point(82, 3);
            this.txtBoxFuncID.Name = "txtBoxFuncID";
            this.txtBoxFuncID.Size = new System.Drawing.Size(136, 21);
            this.txtBoxFuncID.TabIndex = 3;
            this.txtBoxFuncID.Text = "BIZC131101";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "公民身份证号码";
            // 
            // txtBoxIDCard
            // 
            this.txtBoxIDCard.Location = new System.Drawing.Point(97, 30);
            this.txtBoxIDCard.Name = "txtBoxIDCard";
            this.txtBoxIDCard.Size = new System.Drawing.Size(125, 21);
            this.txtBoxIDCard.TabIndex = 5;
            this.txtBoxIDCard.Text = "632122198804046119";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 61);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "医疗结构编码";
            // 
            // txtBoxHospitalID
            // 
            this.txtBoxHospitalID.Location = new System.Drawing.Point(85, 57);
            this.txtBoxHospitalID.Name = "txtBoxHospitalID";
            this.txtBoxHospitalID.Size = new System.Drawing.Size(125, 21);
            this.txtBoxHospitalID.TabIndex = 7;
            this.txtBoxHospitalID.Text = "10";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 88);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "业务类型";
            // 
            // txtBoxBiz
            // 
            this.txtBoxBiz.Location = new System.Drawing.Point(61, 84);
            this.txtBoxBiz.Name = "txtBoxBiz";
            this.txtBoxBiz.Size = new System.Drawing.Size(125, 21);
            this.txtBoxBiz.TabIndex = 9;
            this.txtBoxBiz.Text = "10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 115);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "医保中心编号";
            // 
            // txtBoxCenterID
            // 
            this.txtBoxCenterID.Location = new System.Drawing.Point(85, 111);
            this.txtBoxCenterID.Name = "txtBoxCenterID";
            this.txtBoxCenterID.Size = new System.Drawing.Size(125, 21);
            this.txtBoxCenterID.TabIndex = 11;
            this.txtBoxCenterID.Text = "1";
            // 
            // btnBIZC131101
            // 
            this.btnBIZC131101.Location = new System.Drawing.Point(3, 138);
            this.btnBIZC131101.Name = "btnBIZC131101";
            this.btnBIZC131101.Size = new System.Drawing.Size(141, 23);
            this.btnBIZC131101.TabIndex = 12;
            this.btnBIZC131101.Text = "执行并且获取基本信息";
            this.btnBIZC131101.UseVisualStyleBackColor = true;
            this.btnBIZC131101.Click += new System.EventHandler(this.btnBIZC131101_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 483);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用湖南创智医保接口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.Shown += new System.EventHandler(this.Frm_Main_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPageIDCard.ResumeLayout(false);
            this.tabPageIDCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerson)).EndInit();
            this.tabPageInterface.ResumeLayout(false);
            this.panelParameter.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageIDCard;
        private System.Windows.Forms.RichTextBox richBoxResult;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TabPage tabPageInterface;
        private System.Windows.Forms.PictureBox pictureBoxPerson;
        private System.Windows.Forms.Panel panelParameter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxServlet;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInterfaceInit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxLoginID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxLoginPasswd;
        private System.Windows.Forms.Button btnLoginGet;
        private System.Windows.Forms.Button btnLoginUpdate;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxFuncID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBoxIDCard;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxHospitalID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBoxBiz;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBoxCenterID;
        private System.Windows.Forms.Button btnBIZC131101;
    }
}

