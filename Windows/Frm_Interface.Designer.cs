namespace Windows
{
    partial class Frm_Interface
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
            this.components = new System.ComponentModel.Container();
            this.timerCurrentTime = new System.Windows.Forms.Timer(this.components);
            this.panelInterface = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTips = new System.Windows.Forms.Label();
            this.lblUnitName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.lblFrmTitle = new System.Windows.Forms.Label();
            this.menuStripInterface = new System.Windows.Forms.MenuStrip();
            this.住院业务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMZ = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMZSpecial = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.住院业务ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemZYRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRegisterUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemZYDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.出院结算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iC卡信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemMZQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemPersonInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.数据统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemMZAllOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.门诊特殊病数据统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemZYAllOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.基础字典维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemInterfaceDic = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemJCType = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemInterfaceFunc = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFuncTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTest = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMZCharge = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lblReadCard = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.label4 = new System.Windows.Forms.Label();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.labelDirCompare = new System.Windows.Forms.Label();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.lblMsg = new System.Windows.Forms.Label();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.lblFlow = new System.Windows.Forms.Label();
            this.lblSetup = new System.Windows.Forms.Label();
            this.splitter6 = new System.Windows.Forms.Splitter();
            this.toolStripMenuItemFeeDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStripInterface.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerCurrentTime
            // 
            this.timerCurrentTime.Enabled = true;
            this.timerCurrentTime.Tick += new System.EventHandler(this.timerCurrentTime_Tick);
            // 
            // panelInterface
            // 
            this.panelInterface.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInterface.Location = new System.Drawing.Point(0, 59);
            this.panelInterface.Name = "panelInterface";
            this.panelInterface.Size = new System.Drawing.Size(1349, 561);
            this.panelInterface.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 620);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1349, 32);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblTips);
            this.flowLayoutPanel1.Controls.Add(this.lblUnitName);
            this.flowLayoutPanel1.Controls.Add(this.lblUserName);
            this.flowLayoutPanel1.Controls.Add(this.lblCurrentTime);
            this.flowLayoutPanel1.Controls.Add(this.btnLogin);
            this.flowLayoutPanel1.Controls.Add(this.lblLoginStatus);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1349, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTips.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTips.Location = new System.Drawing.Point(3, 8);
            this.lblTips.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(211, 14);
            this.lblTips.TabIndex = 0;
            this.lblTips.Text = "欢迎使用青海埃立福湖南创智接口系统";
            // 
            // lblUnitName
            // 
            this.lblUnitName.AutoSize = true;
            this.lblUnitName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUnitName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUnitName.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblUnitName.Location = new System.Drawing.Point(220, 8);
            this.lblUnitName.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(115, 14);
            this.lblUnitName.TabIndex = 1;
            this.lblUnitName.Text = "单位：民和县中医院";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.ForeColor = System.Drawing.Color.Green;
            this.lblUserName.Location = new System.Drawing.Point(341, 8);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(115, 14);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "操作人员：宇宙卡门";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentTime.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentTime.Location = new System.Drawing.Point(462, 8);
            this.lblCurrentTime.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(181, 14);
            this.lblCurrentTime.TabIndex = 3;
            this.lblCurrentTime.Text = "当前时间：2015-03-26 00:00:00";
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Image = global::Windows.ResImage.accept;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(649, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "   登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLoginStatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginStatus.Location = new System.Drawing.Point(730, 8);
            this.lblLoginStatus.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(2, 14);
            this.lblLoginStatus.TabIndex = 5;
            // 
            // lblFrmTitle
            // 
            this.lblFrmTitle.AutoSize = true;
            this.lblFrmTitle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFrmTitle.ForeColor = System.Drawing.Color.Red;
            this.lblFrmTitle.Location = new System.Drawing.Point(673, 8);
            this.lblFrmTitle.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblFrmTitle.Name = "lblFrmTitle";
            this.lblFrmTitle.Size = new System.Drawing.Size(122, 12);
            this.lblFrmTitle.TabIndex = 0;
            this.lblFrmTitle.Text = "操作窗体：接口测试";
            // 
            // menuStripInterface
            // 
            this.menuStripInterface.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.住院业务ToolStripMenuItem,
            this.住院业务ToolStripMenuItem1,
            this.信息查询ToolStripMenuItem,
            this.数据统计ToolStripMenuItem,
            this.基础字典维护ToolStripMenuItem});
            this.menuStripInterface.Location = new System.Drawing.Point(0, 0);
            this.menuStripInterface.Name = "menuStripInterface";
            this.menuStripInterface.Size = new System.Drawing.Size(1349, 25);
            this.menuStripInterface.TabIndex = 0;
            this.menuStripInterface.Text = "menuStrip1";
            // 
            // 住院业务ToolStripMenuItem
            // 
            this.住院业务ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMZ,
            this.ToolStripMenuItemMZSpecial,
            this.toolStripSeparator1});
            this.住院业务ToolStripMenuItem.Image = global::Windows.ResImage.user;
            this.住院业务ToolStripMenuItem.Name = "住院业务ToolStripMenuItem";
            this.住院业务ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.住院业务ToolStripMenuItem.Text = "门诊业务";
            // 
            // ToolStripMenuItemMZ
            // 
            this.ToolStripMenuItemMZ.Image = global::Windows.ResImage.user_green;
            this.ToolStripMenuItemMZ.Name = "ToolStripMenuItemMZ";
            this.ToolStripMenuItemMZ.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItemMZ.Text = "普通门诊";
            this.ToolStripMenuItemMZ.Click += new System.EventHandler(this.ToolStripMenuItemMZ_Click);
            // 
            // ToolStripMenuItemMZSpecial
            // 
            this.ToolStripMenuItemMZSpecial.Image = global::Windows.ResImage.user_red;
            this.ToolStripMenuItemMZSpecial.Name = "ToolStripMenuItemMZSpecial";
            this.ToolStripMenuItemMZSpecial.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItemMZSpecial.Text = "门诊特殊病";
            this.ToolStripMenuItemMZSpecial.Click += new System.EventHandler(this.ToolStripMenuItemMZSpecial_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // 住院业务ToolStripMenuItem1
            // 
            this.住院业务ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemZYRegister,
            this.ToolStripMenuItemRegisterUpdate,
            this.ToolStripMenuItemZYDetails,
            this.toolStripSeparator4,
            this.toolStripMenuItemFeeDetails,
            this.出院结算ToolStripMenuItem});
            this.住院业务ToolStripMenuItem1.Image = global::Windows.ResImage.group;
            this.住院业务ToolStripMenuItem1.Name = "住院业务ToolStripMenuItem1";
            this.住院业务ToolStripMenuItem1.Size = new System.Drawing.Size(84, 21);
            this.住院业务ToolStripMenuItem1.Text = "住院业务";
            // 
            // ToolStripMenuItemZYRegister
            // 
            this.ToolStripMenuItemZYRegister.Image = global::Windows.ResImage.group_add;
            this.ToolStripMenuItemZYRegister.Name = "ToolStripMenuItemZYRegister";
            this.ToolStripMenuItemZYRegister.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemZYRegister.Text = "入院登记";
            this.ToolStripMenuItemZYRegister.Click += new System.EventHandler(this.ToolStripMenuItemZYRegister_Click);
            // 
            // ToolStripMenuItemRegisterUpdate
            // 
            this.ToolStripMenuItemRegisterUpdate.Image = global::Windows.ResImage.group_edit;
            this.ToolStripMenuItemRegisterUpdate.Name = "ToolStripMenuItemRegisterUpdate";
            this.ToolStripMenuItemRegisterUpdate.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemRegisterUpdate.Text = "住院信息修改";
            this.ToolStripMenuItemRegisterUpdate.Click += new System.EventHandler(this.ToolStripMenuItemRegisterUpdate_Click);
            // 
            // ToolStripMenuItemZYDetails
            // 
            this.ToolStripMenuItemZYDetails.Image = global::Windows.ResImage.application_cascade;
            this.ToolStripMenuItemZYDetails.Name = "ToolStripMenuItemZYDetails";
            this.ToolStripMenuItemZYDetails.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemZYDetails.Text = "住院信息查询";
            this.ToolStripMenuItemZYDetails.Click += new System.EventHandler(this.ToolStripMenuItemZYDetails_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // 出院结算ToolStripMenuItem
            // 
            this.出院结算ToolStripMenuItem.Image = global::Windows.ResImage.sum;
            this.出院结算ToolStripMenuItem.Name = "出院结算ToolStripMenuItem";
            this.出院结算ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.出院结算ToolStripMenuItem.Text = "出院结算";
            // 
            // 信息查询ToolStripMenuItem
            // 
            this.信息查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iC卡信息查询ToolStripMenuItem,
            this.toolStripSeparator3,
            this.ToolStripMenuItemMZQuery,
            this.toolStripSeparator5,
            this.ToolStripMenuItemPersonInfo});
            this.信息查询ToolStripMenuItem.Image = global::Windows.ResImage.application_side_boxes;
            this.信息查询ToolStripMenuItem.Name = "信息查询ToolStripMenuItem";
            this.信息查询ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.信息查询ToolStripMenuItem.Text = "信息查询";
            // 
            // iC卡信息查询ToolStripMenuItem
            // 
            this.iC卡信息查询ToolStripMenuItem.Image = global::Windows.ResImage.application_view_columns;
            this.iC卡信息查询ToolStripMenuItem.Name = "iC卡信息查询ToolStripMenuItem";
            this.iC卡信息查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.iC卡信息查询ToolStripMenuItem.Text = "IC卡信息查询";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // ToolStripMenuItemMZQuery
            // 
            this.ToolStripMenuItemMZQuery.Image = global::Windows.ResImage.application_side_expand;
            this.ToolStripMenuItemMZQuery.Name = "ToolStripMenuItemMZQuery";
            this.ToolStripMenuItemMZQuery.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemMZQuery.Text = "门诊信息查询";
            this.ToolStripMenuItemMZQuery.Click += new System.EventHandler(this.ToolStripMenuItemMZQuery_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // ToolStripMenuItemPersonInfo
            // 
            this.ToolStripMenuItemPersonInfo.Image = global::Windows.ResImage.application_double;
            this.ToolStripMenuItemPersonInfo.Name = "ToolStripMenuItemPersonInfo";
            this.ToolStripMenuItemPersonInfo.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemPersonInfo.Text = "患者基本信息";
            this.ToolStripMenuItemPersonInfo.Click += new System.EventHandler(this.ToolStripMenuItemPersonInfo_Click);
            // 
            // 数据统计ToolStripMenuItem
            // 
            this.数据统计ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMZAllOrders,
            this.门诊特殊病数据统计ToolStripMenuItem,
            this.ToolStripMenuItemZYAllOrders});
            this.数据统计ToolStripMenuItem.Image = global::Windows.ResImage.package;
            this.数据统计ToolStripMenuItem.Name = "数据统计ToolStripMenuItem";
            this.数据统计ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.数据统计ToolStripMenuItem.Text = "数据统计";
            // 
            // ToolStripMenuItemMZAllOrders
            // 
            this.ToolStripMenuItemMZAllOrders.Image = global::Windows.ResImage.user;
            this.ToolStripMenuItemMZAllOrders.Name = "ToolStripMenuItemMZAllOrders";
            this.ToolStripMenuItemMZAllOrders.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItemMZAllOrders.Text = "普通门诊数据统计";
            this.ToolStripMenuItemMZAllOrders.Click += new System.EventHandler(this.ToolStripMenuItemMZAllOrders_Click);
            // 
            // 门诊特殊病数据统计ToolStripMenuItem
            // 
            this.门诊特殊病数据统计ToolStripMenuItem.Image = global::Windows.ResImage.user_red;
            this.门诊特殊病数据统计ToolStripMenuItem.Name = "门诊特殊病数据统计ToolStripMenuItem";
            this.门诊特殊病数据统计ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.门诊特殊病数据统计ToolStripMenuItem.Text = "门诊特殊病数据统计";
            // 
            // ToolStripMenuItemZYAllOrders
            // 
            this.ToolStripMenuItemZYAllOrders.Image = global::Windows.ResImage.group;
            this.ToolStripMenuItemZYAllOrders.Name = "ToolStripMenuItemZYAllOrders";
            this.ToolStripMenuItemZYAllOrders.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItemZYAllOrders.Text = "普通住院数据统计";
            this.ToolStripMenuItemZYAllOrders.Click += new System.EventHandler(this.ToolStripMenuItemZYAllOrders_Click);
            // 
            // 基础字典维护ToolStripMenuItem
            // 
            this.基础字典维护ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemInterfaceDic,
            this.ToolStripMenuItemJCType,
            this.toolStripSeparator2,
            this.ToolStripMenuItemInterfaceFunc,
            this.ToolStripMenuItemFuncTest,
            this.ToolStripMenuItemTest});
            this.基础字典维护ToolStripMenuItem.Image = global::Windows.ResImage.arrow_branch;
            this.基础字典维护ToolStripMenuItem.Name = "基础字典维护ToolStripMenuItem";
            this.基础字典维护ToolStripMenuItem.Size = new System.Drawing.Size(108, 21);
            this.基础字典维护ToolStripMenuItem.Text = "基础字典维护";
            // 
            // ToolStripMenuItemInterfaceDic
            // 
            this.ToolStripMenuItemInterfaceDic.Image = global::Windows.ResImage.application_key;
            this.ToolStripMenuItemInterfaceDic.Name = "ToolStripMenuItemInterfaceDic";
            this.ToolStripMenuItemInterfaceDic.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemInterfaceDic.Text = "接口基础数据字典维护";
            this.ToolStripMenuItemInterfaceDic.Click += new System.EventHandler(this.ToolStripMenuItemInterfaceDic_Click);
            // 
            // ToolStripMenuItemJCType
            // 
            this.ToolStripMenuItemJCType.Image = global::Windows.ResImage.arrow_in;
            this.ToolStripMenuItemJCType.Name = "ToolStripMenuItemJCType";
            this.ToolStripMenuItemJCType.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemJCType.Text = "类型对照表维护";
            this.ToolStripMenuItemJCType.Click += new System.EventHandler(this.ToolStripMenuItemJCType_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // ToolStripMenuItemInterfaceFunc
            // 
            this.ToolStripMenuItemInterfaceFunc.Image = global::Windows.ResImage.application_view_tile;
            this.ToolStripMenuItemInterfaceFunc.Name = "ToolStripMenuItemInterfaceFunc";
            this.ToolStripMenuItemInterfaceFunc.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemInterfaceFunc.Text = "接口维护";
            this.ToolStripMenuItemInterfaceFunc.Click += new System.EventHandler(this.ToolStripMenuItemInterfaceFunc_Click);
            // 
            // ToolStripMenuItemFuncTest
            // 
            this.ToolStripMenuItemFuncTest.Image = global::Windows.ResImage.disconnect;
            this.ToolStripMenuItemFuncTest.Name = "ToolStripMenuItemFuncTest";
            this.ToolStripMenuItemFuncTest.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemFuncTest.Text = "接口测试";
            this.ToolStripMenuItemFuncTest.Click += new System.EventHandler(this.ToolStripMenuItemFuncTest_Click);
            // 
            // ToolStripMenuItemTest
            // 
            this.ToolStripMenuItemTest.Name = "ToolStripMenuItemTest";
            this.ToolStripMenuItemTest.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemTest.Text = "测试";
            this.ToolStripMenuItemTest.Click += new System.EventHandler(this.ToolStripMenuItemTest_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.PowderBlue;
            this.flowLayoutPanel2.Controls.Add(this.lblMZCharge);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.splitter1);
            this.flowLayoutPanel2.Controls.Add(this.lblReadCard);
            this.flowLayoutPanel2.Controls.Add(this.splitter2);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.splitter3);
            this.flowLayoutPanel2.Controls.Add(this.labelDirCompare);
            this.flowLayoutPanel2.Controls.Add(this.splitter4);
            this.flowLayoutPanel2.Controls.Add(this.lblMsg);
            this.flowLayoutPanel2.Controls.Add(this.splitter5);
            this.flowLayoutPanel2.Controls.Add(this.lblFlow);
            this.flowLayoutPanel2.Controls.Add(this.lblSetup);
            this.flowLayoutPanel2.Controls.Add(this.splitter6);
            this.flowLayoutPanel2.Controls.Add(this.lblFrmTitle);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1349, 28);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // lblMZCharge
            // 
            this.lblMZCharge.AutoSize = true;
            this.lblMZCharge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMZCharge.Image = global::Windows.ResImage.user_green;
            this.lblMZCharge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMZCharge.Location = new System.Drawing.Point(3, 8);
            this.lblMZCharge.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblMZCharge.Name = "lblMZCharge";
            this.lblMZCharge.Size = new System.Drawing.Size(95, 12);
            this.lblMZCharge.TabIndex = 1;
            this.lblMZCharge.Text = "   普通门诊收费";
            this.lblMZCharge.Click += new System.EventHandler(this.lblMZCharge_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Image = global::Windows.ResImage.group;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(104, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "   普通住院收费";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.splitter1.Location = new System.Drawing.Point(205, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 14);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // lblReadCard
            // 
            this.lblReadCard.AutoSize = true;
            this.lblReadCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblReadCard.Image = global::Windows.ResImage.accept;
            this.lblReadCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReadCard.Location = new System.Drawing.Point(214, 8);
            this.lblReadCard.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblReadCard.Name = "lblReadCard";
            this.lblReadCard.Size = new System.Drawing.Size(47, 12);
            this.lblReadCard.TabIndex = 4;
            this.lblReadCard.Text = "   读卡";
            this.lblReadCard.Click += new System.EventHandler(this.lblReadCard_Click);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.splitter2.Location = new System.Drawing.Point(267, 3);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 14);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Image = global::Windows.ResImage.application_tile_horizontal;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(276, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "   数据统计";
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.splitter3.Location = new System.Drawing.Point(353, 3);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 14);
            this.splitter3.TabIndex = 7;
            this.splitter3.TabStop = false;
            // 
            // labelDirCompare
            // 
            this.labelDirCompare.AutoSize = true;
            this.labelDirCompare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDirCompare.Image = global::Windows.ResImage.application_view_detail;
            this.labelDirCompare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDirCompare.Location = new System.Drawing.Point(362, 8);
            this.labelDirCompare.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.labelDirCompare.Name = "labelDirCompare";
            this.labelDirCompare.Size = new System.Drawing.Size(71, 12);
            this.labelDirCompare.TabIndex = 8;
            this.labelDirCompare.Text = "   目录对照";
            this.labelDirCompare.Click += new System.EventHandler(this.labelDirCompare_Click);
            // 
            // splitter4
            // 
            this.splitter4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.splitter4.Location = new System.Drawing.Point(439, 3);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(3, 14);
            this.splitter4.TabIndex = 9;
            this.splitter4.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMsg.Image = global::Windows.ResImage.box;
            this.lblMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsg.Location = new System.Drawing.Point(448, 8);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(71, 12);
            this.lblMsg.TabIndex = 10;
            this.lblMsg.Text = "   通知管理";
            this.lblMsg.Click += new System.EventHandler(this.lblMsg_Click);
            // 
            // splitter5
            // 
            this.splitter5.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.splitter5.Location = new System.Drawing.Point(525, 3);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(3, 14);
            this.splitter5.TabIndex = 11;
            this.splitter5.TabStop = false;
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFlow.Image = global::Windows.ResImage.application_home;
            this.lblFlow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFlow.Location = new System.Drawing.Point(534, 8);
            this.lblFlow.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(47, 12);
            this.lblFlow.TabIndex = 12;
            this.lblFlow.Text = "   首页";
            this.lblFlow.Click += new System.EventHandler(this.lblFlow_Click);
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Image = global::Windows.ResImage.application_key;
            this.lblSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSetup.Location = new System.Drawing.Point(587, 8);
            this.lblSetup.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(71, 12);
            this.lblSetup.TabIndex = 13;
            this.lblSetup.Text = "   参数设置";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // splitter6
            // 
            this.splitter6.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.splitter6.Location = new System.Drawing.Point(664, 3);
            this.splitter6.Name = "splitter6";
            this.splitter6.Size = new System.Drawing.Size(3, 14);
            this.splitter6.TabIndex = 14;
            this.splitter6.TabStop = false;
            // 
            // toolStripMenuItemFeeDetails
            // 
            this.toolStripMenuItemFeeDetails.Image = global::Windows.ResImage.accept;
            this.toolStripMenuItemFeeDetails.Name = "toolStripMenuItemFeeDetails";
            this.toolStripMenuItemFeeDetails.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemFeeDetails.Text = "费用记帐";
            this.toolStripMenuItemFeeDetails.Click += new System.EventHandler(this.toolStripMenuItemFeeDetails_Click);
            // 
            // Frm_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 652);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.panelInterface);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripInterface);
            this.MainMenuStrip = this.menuStripInterface;
            this.Name = "Frm_Interface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Interface";
            this.Load += new System.EventHandler(this.Frm_Interface_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.menuStripInterface.ResumeLayout(false);
            this.menuStripInterface.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripInterface;
        private System.Windows.Forms.ToolStripMenuItem 住院业务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 住院业务ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 基础字典维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMZ;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMZSpecial;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemZYRegister;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemZYDetails;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemJCType;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemInterfaceFunc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTest;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Timer timerCurrentTime;
        private System.Windows.Forms.Panel panelInterface;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFuncTest;
        private System.Windows.Forms.Label lblFrmTitle;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemInterfaceDic;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblMZCharge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label lblReadCard;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Label labelDirCompare;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Splitter splitter6;
        private System.Windows.Forms.ToolStripMenuItem 信息查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem iC卡信息查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMZQuery;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblLoginStatus;
        private System.Windows.Forms.ToolStripMenuItem 数据统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMZAllOrders;
        private System.Windows.Forms.ToolStripMenuItem 门诊特殊病数据统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRegisterUpdate;
        private System.Windows.Forms.ToolStripMenuItem 出院结算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemZYAllOrders;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPersonInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFeeDetails;
    }
}