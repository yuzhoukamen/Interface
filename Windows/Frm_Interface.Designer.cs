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
            this.lblFrmTitle = new System.Windows.Forms.Label();
            this.menuStripInterface = new System.Windows.Forms.MenuStrip();
            this.住院业务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.普通门诊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.门诊特殊病ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工伤门诊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemBuyMedic = new System.Windows.Forms.ToolStripMenuItem();
            this.住院业务ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.普通住院ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工伤住院ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基础字典维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemInterfaceDic = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemJCType = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemInterfaceFunc = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFuncTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTest = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label3 = new System.Windows.Forms.Label();
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
            this.panelInterface.Size = new System.Drawing.Size(1184, 541);
            this.panelInterface.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 600);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 32);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblTips);
            this.flowLayoutPanel1.Controls.Add(this.lblUnitName);
            this.flowLayoutPanel1.Controls.Add(this.lblUserName);
            this.flowLayoutPanel1.Controls.Add(this.lblCurrentTime);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1184, 32);
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
            this.基础字典维护ToolStripMenuItem});
            this.menuStripInterface.Location = new System.Drawing.Point(0, 0);
            this.menuStripInterface.Name = "menuStripInterface";
            this.menuStripInterface.Size = new System.Drawing.Size(1184, 25);
            this.menuStripInterface.TabIndex = 0;
            this.menuStripInterface.Text = "menuStrip1";
            // 
            // 住院业务ToolStripMenuItem
            // 
            this.住院业务ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.普通门诊ToolStripMenuItem,
            this.门诊特殊病ToolStripMenuItem,
            this.工伤门诊ToolStripMenuItem,
            this.toolStripSeparator1,
            this.ToolStripMenuItemBuyMedic});
            this.住院业务ToolStripMenuItem.Image = global::Windows.ResImage.user;
            this.住院业务ToolStripMenuItem.Name = "住院业务ToolStripMenuItem";
            this.住院业务ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.住院业务ToolStripMenuItem.Text = "门诊业务";
            // 
            // 普通门诊ToolStripMenuItem
            // 
            this.普通门诊ToolStripMenuItem.Image = global::Windows.ResImage.user_green;
            this.普通门诊ToolStripMenuItem.Name = "普通门诊ToolStripMenuItem";
            this.普通门诊ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.普通门诊ToolStripMenuItem.Text = "普通门诊";
            // 
            // 门诊特殊病ToolStripMenuItem
            // 
            this.门诊特殊病ToolStripMenuItem.Image = global::Windows.ResImage.user_red;
            this.门诊特殊病ToolStripMenuItem.Name = "门诊特殊病ToolStripMenuItem";
            this.门诊特殊病ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.门诊特殊病ToolStripMenuItem.Text = "门诊特殊病";
            // 
            // 工伤门诊ToolStripMenuItem
            // 
            this.工伤门诊ToolStripMenuItem.Image = global::Windows.ResImage.user_gray;
            this.工伤门诊ToolStripMenuItem.Name = "工伤门诊ToolStripMenuItem";
            this.工伤门诊ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.工伤门诊ToolStripMenuItem.Text = "工伤门诊";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // ToolStripMenuItemBuyMedic
            // 
            this.ToolStripMenuItemBuyMedic.Image = global::Windows.ResImage.stop;
            this.ToolStripMenuItemBuyMedic.Name = "ToolStripMenuItemBuyMedic";
            this.ToolStripMenuItemBuyMedic.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItemBuyMedic.Text = "(省直)购药";
            // 
            // 住院业务ToolStripMenuItem1
            // 
            this.住院业务ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.普通住院ToolStripMenuItem,
            this.工伤住院ToolStripMenuItem});
            this.住院业务ToolStripMenuItem1.Image = global::Windows.ResImage.group;
            this.住院业务ToolStripMenuItem1.Name = "住院业务ToolStripMenuItem1";
            this.住院业务ToolStripMenuItem1.Size = new System.Drawing.Size(84, 21);
            this.住院业务ToolStripMenuItem1.Text = "住院业务";
            // 
            // 普通住院ToolStripMenuItem
            // 
            this.普通住院ToolStripMenuItem.Image = global::Windows.ResImage.group_add;
            this.普通住院ToolStripMenuItem.Name = "普通住院ToolStripMenuItem";
            this.普通住院ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.普通住院ToolStripMenuItem.Text = "普通住院";
            // 
            // 工伤住院ToolStripMenuItem
            // 
            this.工伤住院ToolStripMenuItem.Image = global::Windows.ResImage.group_error;
            this.工伤住院ToolStripMenuItem.Name = "工伤住院ToolStripMenuItem";
            this.工伤住院ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.工伤住院ToolStripMenuItem.Text = "工伤住院";
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
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.splitter1);
            this.flowLayoutPanel2.Controls.Add(this.label3);
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
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1184, 28);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Image = global::Windows.ResImage.user_green;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "   普通门诊报销";
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
            this.label2.Text = "   普通住院报销";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Image = global::Windows.ResImage.accept;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(214, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "   读卡";
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
            // Frm_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 632);
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
        private System.Windows.Forms.ToolStripMenuItem 普通门诊ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 门诊特殊病ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工伤门诊ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemBuyMedic;
        private System.Windows.Forms.ToolStripMenuItem 普通住院ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工伤住院ToolStripMenuItem;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label3;
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
    }
}