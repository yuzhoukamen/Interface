namespace Windows.ZY
{
    partial class Frm_RegisterUpdate
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBox_ic_no = new System.Windows.Forms.TextBox();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.btnQueryFund = new System.Windows.Forms.Button();
            this.groupBoxRegisterInfo = new System.Windows.Forms.GroupBox();
            this.txtBox_patient_id = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBox_in_bed = new System.Windows.Forms.TextBox();
            this.txtBox_remark = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cBox_in_dept_name = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cBox_in_area_name = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDiagnose = new System.Windows.Forms.Label();
            this.txtBox_disease = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbox_treatment_type = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBox_old_patient_id = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBox_begin_date = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBox_corp_name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBox_in_days = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBox_official_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBox_birthday = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBox_pers_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBox_idcard = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBox_sex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c1FlexGridDisease = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStripDiagnose = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.label23 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBox_serial_no = new System.Windows.Forms.TextBox();
            this.btnQuerySerial_no = new System.Windows.Forms.Button();
            this.cBox_diagnose_code = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxRegisterInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDisease)).BeginInit();
            this.contextMenuStripDiagnose.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtBox_ic_no);
            this.flowLayoutPanel1.Controls.Add(this.btnReadCard);
            this.flowLayoutPanel1.Controls.Add(this.btnQueryFund);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(744, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "医保卡号：";
            // 
            // txtBox_ic_no
            // 
            this.txtBox_ic_no.Enabled = false;
            this.txtBox_ic_no.Location = new System.Drawing.Point(84, 3);
            this.txtBox_ic_no.Name = "txtBox_ic_no";
            this.txtBox_ic_no.Size = new System.Drawing.Size(156, 21);
            this.txtBox_ic_no.TabIndex = 1;
            this.txtBox_ic_no.Text = "10006136";
            // 
            // btnReadCard
            // 
            this.btnReadCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadCard.Image = global::Windows.ResImage.connect;
            this.btnReadCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReadCard.Location = new System.Drawing.Point(246, 3);
            this.btnReadCard.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(66, 23);
            this.btnReadCard.TabIndex = 13;
            this.btnReadCard.Text = "   读卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // btnQueryFund
            // 
            this.btnQueryFund.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryFund.Image = global::Windows.ResImage.user_go;
            this.btnQueryFund.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQueryFund.Location = new System.Drawing.Point(323, 3);
            this.btnQueryFund.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnQueryFund.Name = "btnQueryFund";
            this.btnQueryFund.Size = new System.Drawing.Size(109, 23);
            this.btnQueryFund.TabIndex = 30;
            this.btnQueryFund.Text = "   基金状态查询";
            this.btnQueryFund.UseVisualStyleBackColor = true;
            this.btnQueryFund.Visible = false;
            this.btnQueryFund.Click += new System.EventHandler(this.btnQueryFund_Click);
            // 
            // groupBoxRegisterInfo
            // 
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_patient_id);
            this.groupBoxRegisterInfo.Controls.Add(this.label15);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_in_bed);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_remark);
            this.groupBoxRegisterInfo.Controls.Add(this.label22);
            this.groupBoxRegisterInfo.Controls.Add(this.label18);
            this.groupBoxRegisterInfo.Controls.Add(this.cBox_in_dept_name);
            this.groupBoxRegisterInfo.Controls.Add(this.label17);
            this.groupBoxRegisterInfo.Controls.Add(this.cBox_in_area_name);
            this.groupBoxRegisterInfo.Controls.Add(this.label16);
            this.groupBoxRegisterInfo.Controls.Add(this.lblDiagnose);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_disease);
            this.groupBoxRegisterInfo.Controls.Add(this.label14);
            this.groupBoxRegisterInfo.Controls.Add(this.cbox_treatment_type);
            this.groupBoxRegisterInfo.Controls.Add(this.label13);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_old_patient_id);
            this.groupBoxRegisterInfo.Controls.Add(this.label12);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_begin_date);
            this.groupBoxRegisterInfo.Controls.Add(this.label11);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_corp_name);
            this.groupBoxRegisterInfo.Controls.Add(this.label9);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_in_days);
            this.groupBoxRegisterInfo.Controls.Add(this.label8);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_official_name);
            this.groupBoxRegisterInfo.Controls.Add(this.label7);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_birthday);
            this.groupBoxRegisterInfo.Controls.Add(this.label6);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_pers_name);
            this.groupBoxRegisterInfo.Controls.Add(this.label5);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_idcard);
            this.groupBoxRegisterInfo.Controls.Add(this.label4);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_sex);
            this.groupBoxRegisterInfo.Controls.Add(this.label3);
            this.groupBoxRegisterInfo.Controls.Add(this.txtBox_name);
            this.groupBoxRegisterInfo.Controls.Add(this.label2);
            this.groupBoxRegisterInfo.Location = new System.Drawing.Point(0, 37);
            this.groupBoxRegisterInfo.Name = "groupBoxRegisterInfo";
            this.groupBoxRegisterInfo.Size = new System.Drawing.Size(744, 269);
            this.groupBoxRegisterInfo.TabIndex = 1;
            this.groupBoxRegisterInfo.TabStop = false;
            this.groupBoxRegisterInfo.Text = "本次登记信息";
            // 
            // txtBox_patient_id
            // 
            this.txtBox_patient_id.Location = new System.Drawing.Point(562, 127);
            this.txtBox_patient_id.Name = "txtBox_patient_id";
            this.txtBox_patient_id.Size = new System.Drawing.Size(114, 21);
            this.txtBox_patient_id.TabIndex = 43;
            this.txtBox_patient_id.Text = "20150002";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(503, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 42;
            this.label15.Text = "住院号：";
            // 
            // txtBox_in_bed
            // 
            this.txtBox_in_bed.Location = new System.Drawing.Point(562, 198);
            this.txtBox_in_bed.Name = "txtBox_in_bed";
            this.txtBox_in_bed.Size = new System.Drawing.Size(71, 21);
            this.txtBox_in_bed.TabIndex = 41;
            this.txtBox_in_bed.Text = "20150002";
            // 
            // txtBox_remark
            // 
            this.txtBox_remark.Location = new System.Drawing.Point(76, 237);
            this.txtBox_remark.Name = "txtBox_remark";
            this.txtBox_remark.Size = new System.Drawing.Size(647, 21);
            this.txtBox_remark.TabIndex = 38;
            this.txtBox_remark.Text = "好好观看";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 240);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 37;
            this.label22.Text = "病情备注：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(503, 202);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "床位号：";
            // 
            // cBox_in_dept_name
            // 
            this.cBox_in_dept_name.FormattingEnabled = true;
            this.cBox_in_dept_name.Location = new System.Drawing.Point(377, 199);
            this.cBox_in_dept_name.Name = "cBox_in_dept_name";
            this.cBox_in_dept_name.Size = new System.Drawing.Size(111, 20);
            this.cBox_in_dept_name.TabIndex = 30;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(306, 202);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 29;
            this.label17.Text = "入院科室：";
            // 
            // cBox_in_area_name
            // 
            this.cBox_in_area_name.FormattingEnabled = true;
            this.cBox_in_area_name.Location = new System.Drawing.Point(76, 199);
            this.cBox_in_area_name.Name = "cBox_in_area_name";
            this.cBox_in_area_name.Size = new System.Drawing.Size(150, 20);
            this.cBox_in_area_name.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 202);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 27;
            this.label16.Text = "入院病区：";
            // 
            // lblDiagnose
            // 
            this.lblDiagnose.AutoSize = true;
            this.lblDiagnose.Location = new System.Drawing.Point(682, 167);
            this.lblDiagnose.Name = "lblDiagnose";
            this.lblDiagnose.Size = new System.Drawing.Size(41, 12);
            this.lblDiagnose.TabIndex = 26;
            this.lblDiagnose.Text = "......";
            this.lblDiagnose.Click += new System.EventHandler(this.lblDiagnose_Click);
            // 
            // txtBox_disease
            // 
            this.txtBox_disease.Location = new System.Drawing.Point(377, 164);
            this.txtBox_disease.Name = "txtBox_disease";
            this.txtBox_disease.Size = new System.Drawing.Size(299, 21);
            this.txtBox_disease.TabIndex = 25;
            this.txtBox_disease.Text = "20150002";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(282, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 24;
            this.label14.Text = "入院第一诊断：";
            // 
            // cbox_treatment_type
            // 
            this.cbox_treatment_type.FormattingEnabled = true;
            this.cbox_treatment_type.Location = new System.Drawing.Point(76, 164);
            this.cbox_treatment_type.Name = "cbox_treatment_type";
            this.cbox_treatment_type.Size = new System.Drawing.Size(150, 20);
            this.cbox_treatment_type.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 22;
            this.label13.Text = "待遇类别：";
            // 
            // txtBox_old_patient_id
            // 
            this.txtBox_old_patient_id.Enabled = false;
            this.txtBox_old_patient_id.Location = new System.Drawing.Point(377, 127);
            this.txtBox_old_patient_id.Name = "txtBox_old_patient_id";
            this.txtBox_old_patient_id.Size = new System.Drawing.Size(92, 21);
            this.txtBox_old_patient_id.TabIndex = 21;
            this.txtBox_old_patient_id.Text = "20150002";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(306, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "原住院号：";
            // 
            // txtBox_begin_date
            // 
            this.txtBox_begin_date.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.txtBox_begin_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtBox_begin_date.Location = new System.Drawing.Point(76, 126);
            this.txtBox_begin_date.Name = "txtBox_begin_date";
            this.txtBox_begin_date.ShowUpDown = true;
            this.txtBox_begin_date.Size = new System.Drawing.Size(150, 21);
            this.txtBox_begin_date.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "入院日期：";
            // 
            // txtBox_corp_name
            // 
            this.txtBox_corp_name.Location = new System.Drawing.Point(76, 93);
            this.txtBox_corp_name.Name = "txtBox_corp_name";
            this.txtBox_corp_name.Size = new System.Drawing.Size(640, 21);
            this.txtBox_corp_name.TabIndex = 16;
            this.txtBox_corp_name.Text = "海西州蒙藏医院";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "所属单位：";
            // 
            // txtBox_in_days
            // 
            this.txtBox_in_days.Enabled = false;
            this.txtBox_in_days.Location = new System.Drawing.Point(608, 54);
            this.txtBox_in_days.Name = "txtBox_in_days";
            this.txtBox_in_days.Size = new System.Drawing.Size(108, 21);
            this.txtBox_in_days.TabIndex = 14;
            this.txtBox_in_days.Text = "2";
            this.txtBox_in_days.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_biz_times_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(539, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "住院天数：";
            // 
            // txtBox_official_name
            // 
            this.txtBox_official_name.Location = new System.Drawing.Point(377, 54);
            this.txtBox_official_name.Name = "txtBox_official_name";
            this.txtBox_official_name.Size = new System.Drawing.Size(147, 21);
            this.txtBox_official_name.TabIndex = 12;
            this.txtBox_official_name.Text = "县正处级干部";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "公务员级别：";
            // 
            // txtBox_birthday
            // 
            this.txtBox_birthday.Location = new System.Drawing.Point(76, 54);
            this.txtBox_birthday.Name = "txtBox_birthday";
            this.txtBox_birthday.Size = new System.Drawing.Size(207, 21);
            this.txtBox_birthday.TabIndex = 10;
            this.txtBox_birthday.Text = "1969-12-01";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "出生日期：";
            // 
            // txtBox_pers_name
            // 
            this.txtBox_pers_name.Location = new System.Drawing.Point(608, 18);
            this.txtBox_pers_name.Name = "txtBox_pers_name";
            this.txtBox_pers_name.Size = new System.Drawing.Size(108, 21);
            this.txtBox_pers_name.TabIndex = 8;
            this.txtBox_pers_name.Text = "在职";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(539, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "人员类别：";
            // 
            // txtBox_idcard
            // 
            this.txtBox_idcard.Location = new System.Drawing.Point(377, 18);
            this.txtBox_idcard.Name = "txtBox_idcard";
            this.txtBox_idcard.Size = new System.Drawing.Size(147, 21);
            this.txtBox_idcard.TabIndex = 6;
            this.txtBox_idcard.Text = "632802197805149876";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "身份证号码：";
            // 
            // txtBox_sex
            // 
            this.txtBox_sex.Location = new System.Drawing.Point(246, 18);
            this.txtBox_sex.Name = "txtBox_sex";
            this.txtBox_sex.Size = new System.Drawing.Size(37, 21);
            this.txtBox_sex.TabIndex = 4;
            this.txtBox_sex.Text = "女";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "性别：";
            // 
            // txtBox_name
            // 
            this.txtBox_name.Location = new System.Drawing.Point(76, 18);
            this.txtBox_name.Name = "txtBox_name";
            this.txtBox_name.Size = new System.Drawing.Size(117, 21);
            this.txtBox_name.TabIndex = 2;
            this.txtBox_name.Text = "王玉珍";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "姓名：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.c1FlexGridDisease);
            this.groupBox2.Location = new System.Drawing.Point(8, 312);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 174);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "其他诊断信息";
            // 
            // c1FlexGridDisease
            // 
            this.c1FlexGridDisease.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridDisease.ContextMenuStrip = this.contextMenuStripDiagnose;
            this.c1FlexGridDisease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridDisease.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridDisease.Name = "c1FlexGridDisease";
            this.c1FlexGridDisease.Rows.DefaultSize = 20;
            this.c1FlexGridDisease.Size = new System.Drawing.Size(340, 154);
            this.c1FlexGridDisease.TabIndex = 0;
            this.c1FlexGridDisease.RowColChange += new System.EventHandler(this.c1FlexGridDisease_RowColChange);
            // 
            // contextMenuStripDiagnose
            // 
            this.contextMenuStripDiagnose.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAdd,
            this.ToolStripMenuItemDel});
            this.contextMenuStripDiagnose.Name = "contextMenuStrip1";
            this.contextMenuStripDiagnose.Size = new System.Drawing.Size(185, 48);
            // 
            // ToolStripMenuItemAdd
            // 
            this.ToolStripMenuItemAdd.Image = global::Windows.ResImage.add;
            this.ToolStripMenuItemAdd.Name = "ToolStripMenuItemAdd";
            this.ToolStripMenuItemAdd.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItemAdd.Text = "添加诊断信息";
            this.ToolStripMenuItemAdd.Click += new System.EventHandler(this.ToolStripMenuItemAdd_Click);
            // 
            // ToolStripMenuItemDel
            // 
            this.ToolStripMenuItemDel.Image = global::Windows.ResImage.cancel1;
            this.ToolStripMenuItemDel.Name = "ToolStripMenuItemDel";
            this.ToolStripMenuItemDel.Size = new System.Drawing.Size(184, 22);
            this.ToolStripMenuItemDel.Text = "删除选择的诊断信息";
            this.ToolStripMenuItemDel.Click += new System.EventHandler(this.ToolStripMenuItemDel_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(8, 498);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(149, 12);
            this.label23.TabIndex = 16;
            this.label23.Text = "注意：右键新增或删除操作";
            // 
            // btnRegister
            // 
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Image = global::Windows.ResImage.accept;
            this.btnRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegister.Location = new System.Drawing.Point(405, 492);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(64, 23);
            this.btnRegister.TabIndex = 41;
            this.btnRegister.Text = "   保存";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::Windows.ResImage.star;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(598, 492);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 23);
            this.btnClear.TabIndex = 40;
            this.btnClear.Text = "   清屏";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Windows.ResImage.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(673, 491);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 24);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "   退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::Windows.ResImage.printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(480, 492);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(107, 23);
            this.btnPrint.TabIndex = 35;
            this.btnPrint.Text = "   重新打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(365, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 20);
            this.label10.TabIndex = 42;
            this.label10.Text = "就医登记号";
            // 
            // txtBox_serial_no
            // 
            this.txtBox_serial_no.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBox_serial_no.Location = new System.Drawing.Point(480, 326);
            this.txtBox_serial_no.Name = "txtBox_serial_no";
            this.txtBox_serial_no.Size = new System.Drawing.Size(168, 30);
            this.txtBox_serial_no.TabIndex = 43;
            this.txtBox_serial_no.Text = "1125648967";
            // 
            // btnQuerySerial_no
            // 
            this.btnQuerySerial_no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuerySerial_no.Location = new System.Drawing.Point(654, 331);
            this.btnQuerySerial_no.Name = "btnQuerySerial_no";
            this.btnQuerySerial_no.Size = new System.Drawing.Size(35, 23);
            this.btnQuerySerial_no.TabIndex = 44;
            this.btnQuerySerial_no.Text = "...";
            this.btnQuerySerial_no.UseVisualStyleBackColor = true;
            this.btnQuerySerial_no.Click += new System.EventHandler(this.btnQuerySerial_no_Click);
            // 
            // cBox_diagnose_code
            // 
            this.cBox_diagnose_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_diagnose_code.FormattingEnabled = true;
            this.cBox_diagnose_code.Location = new System.Drawing.Point(431, 407);
            this.cBox_diagnose_code.Name = "cBox_diagnose_code";
            this.cBox_diagnose_code.Size = new System.Drawing.Size(111, 20);
            this.cBox_diagnose_code.TabIndex = 46;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(360, 410);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 45;
            this.label19.Text = "诊断类型：";
            // 
            // Frm_RegisterUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 519);
            this.Controls.Add(this.cBox_diagnose_code);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnQuerySerial_no);
            this.Controls.Add(this.txtBox_serial_no);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxRegisterInfo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_RegisterUpdate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入院登记";
            this.Load += new System.EventHandler(this.Frm_RegisterUpdate_Load);
            this.Shown += new System.EventHandler(this.Frm_RegisterUpdate_Shown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBoxRegisterInfo.ResumeLayout(false);
            this.groupBoxRegisterInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDisease)).EndInit();
            this.contextMenuStripDiagnose.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBox_ic_no;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.Button btnQueryFund;
        private System.Windows.Forms.GroupBox groupBoxRegisterInfo;
        private System.Windows.Forms.TextBox txtBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_sex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBox_idcard;
        private System.Windows.Forms.TextBox txtBox_pers_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBox_birthday;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBox_official_name;
        private System.Windows.Forms.TextBox txtBox_in_days;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBox_corp_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker txtBox_begin_date;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBox_old_patient_id;
        private System.Windows.Forms.ComboBox cbox_treatment_type;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBox_disease;
        private System.Windows.Forms.Label lblDiagnose;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cBox_in_area_name;
        private System.Windows.Forms.ComboBox cBox_in_dept_name;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBox_remark;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label23;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridDisease;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDiagnose;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDel;
        private System.Windows.Forms.TextBox txtBox_in_bed;
        private System.Windows.Forms.TextBox txtBox_patient_id;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBox_serial_no;
        private System.Windows.Forms.Button btnQuerySerial_no;
        private System.Windows.Forms.ComboBox cBox_diagnose_code;
        private System.Windows.Forms.Label label19;
    }
}