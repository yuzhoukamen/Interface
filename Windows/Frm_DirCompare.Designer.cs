namespace Windows
{
    partial class Frm_DirCompare
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.c1FlexGridInterfaceJC = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxKeyWords = new System.Windows.Forms.TextBox();
            this.btnQueryJC = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnInitDir = new System.Windows.Forms.Button();
            this.btnInitAddMatch = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnAutoMatch = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.btnClearCompare = new System.Windows.Forms.Button();
            this.c1FlexGridAddMatch = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCenterID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHospitalID = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxMatchType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxAuditFlag = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtBoxAddMatchItemName = new System.Windows.Forms.TextBox();
            this.btnQueryData = new System.Windows.Forms.Button();
            this.btnQueryCenterMatchedInfo = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridInterfaceJC)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridAddMatch)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1348, 566);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.c1FlexGridInterfaceJC);
            this.panel2.Controls.Add(this.flowLayoutPanel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1027, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 546);
            this.panel2.TabIndex = 4;
            // 
            // c1FlexGridInterfaceJC
            // 
            this.c1FlexGridInterfaceJC.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridInterfaceJC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridInterfaceJC.Location = new System.Drawing.Point(0, 34);
            this.c1FlexGridInterfaceJC.Name = "c1FlexGridInterfaceJC";
            this.c1FlexGridInterfaceJC.Rows.DefaultSize = 20;
            this.c1FlexGridInterfaceJC.Size = new System.Drawing.Size(318, 512);
            this.c1FlexGridInterfaceJC.TabIndex = 3;
            this.c1FlexGridInterfaceJC.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.c1FlexGridInterfaceJC_MouseDoubleClick);
            this.c1FlexGridInterfaceJC.SelChange += new System.EventHandler(this.c1FlexGridInterfaceJC_SelChange);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Controls.Add(this.txtBoxKeyWords);
            this.flowLayoutPanel4.Controls.Add(this.btnQueryJC);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(318, 34);
            this.flowLayoutPanel4.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "关键词：";
            // 
            // txtBoxKeyWords
            // 
            this.txtBoxKeyWords.Location = new System.Drawing.Point(64, 3);
            this.txtBoxKeyWords.Name = "txtBoxKeyWords";
            this.txtBoxKeyWords.Size = new System.Drawing.Size(157, 21);
            this.txtBoxKeyWords.TabIndex = 0;
            this.txtBoxKeyWords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxKeyWords_KeyDown);
            // 
            // btnQueryJC
            // 
            this.btnQueryJC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryJC.Image = global::Windows.ResImage.tick;
            this.btnQueryJC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQueryJC.Location = new System.Drawing.Point(227, 3);
            this.btnQueryJC.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnQueryJC.Name = "btnQueryJC";
            this.btnQueryJC.Size = new System.Drawing.Size(81, 23);
            this.btnQueryJC.TabIndex = 5;
            this.btnQueryJC.Text = "   检索数据";
            this.btnQueryJC.UseVisualStyleBackColor = true;
            this.btnQueryJC.Click += new System.EventHandler(this.btnQueryJC_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.flowLayoutPanel2);
            this.groupBox3.Location = new System.Drawing.Point(3, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1018, 546);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "对照结果";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.c1FlexGridAddMatch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 500);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel5);
            this.panel3.Controls.Add(this.flowLayoutPanel3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 430);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1012, 70);
            this.panel3.TabIndex = 2;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label15);
            this.flowLayoutPanel5.Controls.Add(this.label16);
            this.flowLayoutPanel5.Controls.Add(this.label8);
            this.flowLayoutPanel5.Controls.Add(this.label7);
            this.flowLayoutPanel5.Controls.Add(this.label10);
            this.flowLayoutPanel5.Controls.Add(this.label9);
            this.flowLayoutPanel5.Controls.Add(this.label12);
            this.flowLayoutPanel5.Controls.Add(this.label11);
            this.flowLayoutPanel5.Controls.Add(this.label6);
            this.flowLayoutPanel5.Controls.Add(this.label13);
            this.flowLayoutPanel5.Controls.Add(this.label17);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 36);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(1012, 34);
            this.flowLayoutPanel5.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Goldenrod;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(8, 14);
            this.label15.Margin = new System.Windows.Forms.Padding(8, 14, 3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(64, 14);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 14, 8, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 32;
            this.label16.Text = "诊疗项目";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightGreen;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(133, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 14, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 14, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "甲类";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightCoral;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(234, 14);
            this.label10.Margin = new System.Windows.Forms.Padding(8, 14, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(290, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 14, 8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "乙类";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.LightYellow;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(335, 14);
            this.label12.Margin = new System.Windows.Forms.Padding(8, 14, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(391, 14);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 14, 8, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "全自费";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(455, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(15, 14, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(511, 14);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 14, 8, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 29;
            this.label13.Text = "无定义";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.OrangeRed;
            this.label17.Location = new System.Drawing.Point(570, 14);
            this.label17.Margin = new System.Windows.Forms.Padding(10, 14, 8, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(226, 12);
            this.label17.TabIndex = 33;
            this.label17.Text = "注意：不匹配已上传或者已对照的信息";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnInitDir);
            this.flowLayoutPanel3.Controls.Add(this.btnInitAddMatch);
            this.flowLayoutPanel3.Controls.Add(this.splitter1);
            this.flowLayoutPanel3.Controls.Add(this.btnAutoMatch);
            this.flowLayoutPanel3.Controls.Add(this.btnUpload);
            this.flowLayoutPanel3.Controls.Add(this.btnDownload);
            this.flowLayoutPanel3.Controls.Add(this.btnExcel);
            this.flowLayoutPanel3.Controls.Add(this.splitter2);
            this.flowLayoutPanel3.Controls.Add(this.btnClearCompare);
            this.flowLayoutPanel3.Controls.Add(this.btnQueryCenterMatchedInfo);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(1012, 70);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnInitDir
            // 
            this.btnInitDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInitDir.Image = global::Windows.ResImage.anchor;
            this.btnInitDir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInitDir.Location = new System.Drawing.Point(3, 8);
            this.btnInitDir.Margin = new System.Windows.Forms.Padding(3, 8, 8, 3);
            this.btnInitDir.Name = "btnInitDir";
            this.btnInitDir.Size = new System.Drawing.Size(122, 23);
            this.btnInitDir.TabIndex = 31;
            this.btnInitDir.Text = "   初始化中心字典";
            this.btnInitDir.UseVisualStyleBackColor = true;
            this.btnInitDir.Click += new System.EventHandler(this.btnInitDir_Click);
            // 
            // btnInitAddMatch
            // 
            this.btnInitAddMatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInitAddMatch.Image = global::Windows.ResImage.rosette;
            this.btnInitAddMatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInitAddMatch.Location = new System.Drawing.Point(136, 8);
            this.btnInitAddMatch.Margin = new System.Windows.Forms.Padding(3, 8, 8, 3);
            this.btnInitAddMatch.Name = "btnInitAddMatch";
            this.btnInitAddMatch.Size = new System.Drawing.Size(170, 23);
            this.btnInitAddMatch.TabIndex = 19;
            this.btnInitAddMatch.Text = "   初始化新增医院目录匹配";
            this.btnInitAddMatch.UseVisualStyleBackColor = true;
            this.btnInitAddMatch.Click += new System.EventHandler(this.btnInitAddMatch_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Brown;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(317, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 28);
            this.splitter1.TabIndex = 32;
            this.splitter1.TabStop = false;
            // 
            // btnAutoMatch
            // 
            this.btnAutoMatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoMatch.Image = global::Windows.ResImage.arrow_in;
            this.btnAutoMatch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoMatch.Location = new System.Drawing.Point(326, 8);
            this.btnAutoMatch.Margin = new System.Windows.Forms.Padding(3, 8, 8, 3);
            this.btnAutoMatch.Name = "btnAutoMatch";
            this.btnAutoMatch.Size = new System.Drawing.Size(87, 23);
            this.btnAutoMatch.TabIndex = 30;
            this.btnAutoMatch.Text = "   自动匹配";
            this.btnAutoMatch.UseVisualStyleBackColor = true;
            this.btnAutoMatch.Click += new System.EventHandler(this.btnAutoMatch_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Image = global::Windows.ResImage.arrow_join;
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(424, 8);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 8, 8, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(118, 23);
            this.btnUpload.TabIndex = 20;
            this.btnUpload.Text = "   上传未匹配目录";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Image = global::Windows.ResImage.arrow_down;
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(553, 8);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(3, 8, 8, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(130, 23);
            this.btnDownload.TabIndex = 21;
            this.btnDownload.Text = "   下载中心目录匹配";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::Windows.ResImage.sum;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(694, 8);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(57, 23);
            this.btnExcel.TabIndex = 36;
            this.btnExcel.Text = "   导出";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Brown;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(762, 3);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 28);
            this.splitter2.TabIndex = 33;
            this.splitter2.TabStop = false;
            // 
            // btnClearCompare
            // 
            this.btnClearCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCompare.Image = global::Windows.ResImage.cancel1;
            this.btnClearCompare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearCompare.Location = new System.Drawing.Point(771, 8);
            this.btnClearCompare.Margin = new System.Windows.Forms.Padding(3, 8, 8, 3);
            this.btnClearCompare.Name = "btnClearCompare";
            this.btnClearCompare.Size = new System.Drawing.Size(108, 23);
            this.btnClearCompare.TabIndex = 34;
            this.btnClearCompare.Text = "   清除对照标志";
            this.btnClearCompare.UseVisualStyleBackColor = true;
            this.btnClearCompare.Click += new System.EventHandler(this.btnClearCompare_Click);
            // 
            // c1FlexGridAddMatch
            // 
            this.c1FlexGridAddMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c1FlexGridAddMatch.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridAddMatch.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGridAddMatch.Name = "c1FlexGridAddMatch";
            this.c1FlexGridAddMatch.Rows.DefaultSize = 20;
            this.c1FlexGridAddMatch.Size = new System.Drawing.Size(1012, 427);
            this.c1FlexGridAddMatch.TabIndex = 1;
            this.c1FlexGridAddMatch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.c1FlexGridAddMatch_MouseClick);
            this.c1FlexGridAddMatch.SelChange += new System.EventHandler(this.c1FlexGridAddMatch_SelChange);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.lblCenterID);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.lblHospitalID);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1012, 26);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "中心编码：";
            // 
            // lblCenterID
            // 
            this.lblCenterID.AutoSize = true;
            this.lblCenterID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCenterID.ForeColor = System.Drawing.Color.Red;
            this.lblCenterID.Location = new System.Drawing.Point(78, 5);
            this.lblCenterID.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblCenterID.Name = "lblCenterID";
            this.lblCenterID.Size = new System.Drawing.Size(47, 12);
            this.lblCenterID.TabIndex = 6;
            this.lblCenterID.Text = "632802";
            this.lblCenterID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "医院编码：";
            // 
            // lblHospitalID
            // 
            this.lblHospitalID.AutoSize = true;
            this.lblHospitalID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHospitalID.ForeColor = System.Drawing.Color.Red;
            this.lblHospitalID.Location = new System.Drawing.Point(206, 5);
            this.lblHospitalID.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblHospitalID.Name = "lblHospitalID";
            this.lblHospitalID.Size = new System.Drawing.Size(68, 12);
            this.lblHospitalID.TabIndex = 8;
            this.lblHospitalID.Text = "632802002";
            this.lblHospitalID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1348, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询参数";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cBoxMatchType);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cBoxAuditFlag);
            this.flowLayoutPanel1.Controls.Add(this.label18);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxAddMatchItemName);
            this.flowLayoutPanel1.Controls.Add(this.btnQueryData);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(26, 21);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1110, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "匹配类型：";
            // 
            // cBoxMatchType
            // 
            this.cBoxMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxMatchType.FormattingEnabled = true;
            this.cBoxMatchType.Location = new System.Drawing.Point(76, 3);
            this.cBoxMatchType.Name = "cBoxMatchType";
            this.cBoxMatchType.Size = new System.Drawing.Size(121, 20);
            this.cBoxMatchType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "审核标志：";
            // 
            // cBoxAuditFlag
            // 
            this.cBoxAuditFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxAuditFlag.FormattingEnabled = true;
            this.cBoxAuditFlag.Location = new System.Drawing.Point(276, 3);
            this.cBoxAuditFlag.Name = "cBoxAuditFlag";
            this.cBoxAuditFlag.Size = new System.Drawing.Size(121, 20);
            this.cBoxAuditFlag.TabIndex = 3;
            this.cBoxAuditFlag.SelectedIndexChanged += new System.EventHandler(this.cBoxAuditFlag_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(405, 5);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 7;
            this.label18.Text = "名称：";
            // 
            // txtBoxAddMatchItemName
            // 
            this.txtBoxAddMatchItemName.Location = new System.Drawing.Point(452, 3);
            this.txtBoxAddMatchItemName.Name = "txtBoxAddMatchItemName";
            this.txtBoxAddMatchItemName.Size = new System.Drawing.Size(227, 21);
            this.txtBoxAddMatchItemName.TabIndex = 8;
            this.txtBoxAddMatchItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxAddMatchItemName_KeyDown);
            // 
            // btnQueryData
            // 
            this.btnQueryData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryData.Image = global::Windows.ResImage.tick;
            this.btnQueryData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQueryData.Location = new System.Drawing.Point(697, 3);
            this.btnQueryData.Margin = new System.Windows.Forms.Padding(15, 3, 8, 3);
            this.btnQueryData.Name = "btnQueryData";
            this.btnQueryData.Size = new System.Drawing.Size(81, 23);
            this.btnQueryData.TabIndex = 4;
            this.btnQueryData.Text = "   检索数据";
            this.btnQueryData.UseVisualStyleBackColor = true;
            this.btnQueryData.Click += new System.EventHandler(this.btnQueryData_Click);
            // 
            // btnQueryCenterMatchedInfo
            // 
            this.btnQueryCenterMatchedInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryCenterMatchedInfo.Image = global::Windows.ResImage.application_form;
            this.btnQueryCenterMatchedInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQueryCenterMatchedInfo.Location = new System.Drawing.Point(890, 8);
            this.btnQueryCenterMatchedInfo.Margin = new System.Windows.Forms.Padding(3, 8, 8, 3);
            this.btnQueryCenterMatchedInfo.Name = "btnQueryCenterMatchedInfo";
            this.btnQueryCenterMatchedInfo.Size = new System.Drawing.Size(108, 23);
            this.btnQueryCenterMatchedInfo.TabIndex = 35;
            this.btnQueryCenterMatchedInfo.Text = "   中心匹配信息";
            this.btnQueryCenterMatchedInfo.UseVisualStyleBackColor = true;
            // 
            // Frm_DirCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 625);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_DirCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "目录对照";
            this.Load += new System.EventHandler(this.Frm_DirCompare_Load);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridInterfaceJC)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridAddMatch)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxMatchType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxAuditFlag;
        private System.Windows.Forms.Button btnQueryData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCenterID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHospitalID;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridAddMatch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxKeyWords;
        private System.Windows.Forms.Button btnQueryJC;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridInterfaceJC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnInitAddMatch;
        private System.Windows.Forms.Button btnAutoMatch;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnInitDir;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button btnClearCompare;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBoxAddMatchItemName;
        private System.Windows.Forms.Button btnQueryCenterMatchedInfo;
    }
}