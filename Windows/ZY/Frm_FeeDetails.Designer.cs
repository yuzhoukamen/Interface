namespace Windows.ZY
{
    partial class Frm_FeeDetails
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblICCard = new System.Windows.Forms.Label();
            this.btnReadCard = new System.Windows.Forms.Button();
            this.btnFindPatient = new System.Windows.Forms.Button();
            this.groupBoxPersonInfo = new System.Windows.Forms.GroupBox();
            this.fee_date = new System.Windows.Forms.DateTimePicker();
            this.sex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pers_name = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.serial_no = new System.Windows.Forms.TextBox();
            this.begin_date = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.corp_name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.in_disease_name = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.treatment_type = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.idcard = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.patient_id = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.in_dept = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.c1FlexGridUploadedFeeDetails = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.c1FlexGridFeeDetails = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStripFeeDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddFeeDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelFeeDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.c1FlexGridPayInfo = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.lblTotalFee = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxPersonInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridUploadedFeeDetails)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridFeeDetails)).BeginInit();
            this.contextMenuStripFeeDetails.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPayInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblICCard);
            this.groupBox1.Controls.Add(this.btnReadCard);
            this.groupBox1.Controls.Add(this.btnFindPatient);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1294, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "医保卡号：";
            // 
            // lblICCard
            // 
            this.lblICCard.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblICCard.ForeColor = System.Drawing.Color.Red;
            this.lblICCard.Location = new System.Drawing.Point(77, 20);
            this.lblICCard.Margin = new System.Windows.Forms.Padding(3, 5, 10, 0);
            this.lblICCard.Name = "lblICCard";
            this.lblICCard.Size = new System.Drawing.Size(88, 14);
            this.lblICCard.TabIndex = 32;
            this.lblICCard.Text = "10006136";
            // 
            // btnReadCard
            // 
            this.btnReadCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadCard.Image = global::Windows.ResImage.connect;
            this.btnReadCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReadCard.Location = new System.Drawing.Point(178, 15);
            this.btnReadCard.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(66, 23);
            this.btnReadCard.TabIndex = 31;
            this.btnReadCard.Text = "   读卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // btnFindPatient
            // 
            this.btnFindPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPatient.Image = global::Windows.ResImage.user_go;
            this.btnFindPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindPatient.Location = new System.Drawing.Point(257, 15);
            this.btnFindPatient.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnFindPatient.Name = "btnFindPatient";
            this.btnFindPatient.Size = new System.Drawing.Size(86, 23);
            this.btnFindPatient.TabIndex = 33;
            this.btnFindPatient.Text = "   查找患者";
            this.btnFindPatient.UseVisualStyleBackColor = true;
            this.btnFindPatient.Click += new System.EventHandler(this.btnFindPatient_Click);
            // 
            // groupBoxPersonInfo
            // 
            this.groupBoxPersonInfo.Controls.Add(this.fee_date);
            this.groupBoxPersonInfo.Controls.Add(this.sex);
            this.groupBoxPersonInfo.Controls.Add(this.label2);
            this.groupBoxPersonInfo.Controls.Add(this.pers_name);
            this.groupBoxPersonInfo.Controls.Add(this.label14);
            this.groupBoxPersonInfo.Controls.Add(this.label10);
            this.groupBoxPersonInfo.Controls.Add(this.label5);
            this.groupBoxPersonInfo.Controls.Add(this.serial_no);
            this.groupBoxPersonInfo.Controls.Add(this.begin_date);
            this.groupBoxPersonInfo.Controls.Add(this.label13);
            this.groupBoxPersonInfo.Controls.Add(this.corp_name);
            this.groupBoxPersonInfo.Controls.Add(this.label9);
            this.groupBoxPersonInfo.Controls.Add(this.in_disease_name);
            this.groupBoxPersonInfo.Controls.Add(this.label12);
            this.groupBoxPersonInfo.Controls.Add(this.treatment_type);
            this.groupBoxPersonInfo.Controls.Add(this.label8);
            this.groupBoxPersonInfo.Controls.Add(this.idcard);
            this.groupBoxPersonInfo.Controls.Add(this.label3);
            this.groupBoxPersonInfo.Controls.Add(this.patient_id);
            this.groupBoxPersonInfo.Controls.Add(this.label11);
            this.groupBoxPersonInfo.Controls.Add(this.in_dept);
            this.groupBoxPersonInfo.Controls.Add(this.label7);
            this.groupBoxPersonInfo.Controls.Add(this.name);
            this.groupBoxPersonInfo.Controls.Add(this.label1);
            this.groupBoxPersonInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxPersonInfo.Location = new System.Drawing.Point(0, 48);
            this.groupBoxPersonInfo.Name = "groupBoxPersonInfo";
            this.groupBoxPersonInfo.Size = new System.Drawing.Size(1294, 87);
            this.groupBoxPersonInfo.TabIndex = 1;
            this.groupBoxPersonInfo.TabStop = false;
            this.groupBoxPersonInfo.Text = "人员信息";
            // 
            // fee_date
            // 
            this.fee_date.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.fee_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fee_date.Location = new System.Drawing.Point(1140, 53);
            this.fee_date.Name = "fee_date";
            this.fee_date.ShowUpDown = true;
            this.fee_date.Size = new System.Drawing.Size(137, 21);
            this.fee_date.TabIndex = 11;
            // 
            // sex
            // 
            this.sex.Location = new System.Drawing.Point(258, 23);
            this.sex.Name = "sex";
            this.sex.Size = new System.Drawing.Size(37, 21);
            this.sex.TabIndex = 1;
            this.sex.Text = "男";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "性别";
            // 
            // pers_name
            // 
            this.pers_name.Location = new System.Drawing.Point(558, 23);
            this.pers_name.Name = "pers_name";
            this.pers_name.Size = new System.Drawing.Size(141, 21);
            this.pers_name.TabIndex = 1;
            this.pers_name.Text = "中";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1081, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "费用时间";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(705, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "就医登记号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "人员类别";
            // 
            // serial_no
            // 
            this.serial_no.Location = new System.Drawing.Point(776, 20);
            this.serial_no.Name = "serial_no";
            this.serial_no.Size = new System.Drawing.Size(85, 21);
            this.serial_no.TabIndex = 1;
            // 
            // begin_date
            // 
            this.begin_date.Location = new System.Drawing.Point(930, 53);
            this.begin_date.Name = "begin_date";
            this.begin_date.Size = new System.Drawing.Size(132, 21);
            this.begin_date.TabIndex = 1;
            this.begin_date.Text = "2015-05-21 10:45:33";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(871, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "入院日期";
            // 
            // corp_name
            // 
            this.corp_name.Location = new System.Drawing.Point(558, 53);
            this.corp_name.Name = "corp_name";
            this.corp_name.Size = new System.Drawing.Size(303, 21);
            this.corp_name.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(501, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "所在单位";
            // 
            // in_disease_name
            // 
            this.in_disease_name.Location = new System.Drawing.Point(258, 53);
            this.in_disease_name.Name = "in_disease_name";
            this.in_disease_name.Size = new System.Drawing.Size(233, 21);
            this.in_disease_name.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(215, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "诊断";
            // 
            // treatment_type
            // 
            this.treatment_type.Location = new System.Drawing.Point(65, 53);
            this.treatment_type.Name = "treatment_type";
            this.treatment_type.Size = new System.Drawing.Size(134, 21);
            this.treatment_type.TabIndex = 1;
            this.treatment_type.Text = "普通住院";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "待遇类型";
            // 
            // idcard
            // 
            this.idcard.Location = new System.Drawing.Point(360, 23);
            this.idcard.Name = "idcard";
            this.idcard.Size = new System.Drawing.Size(131, 21);
            this.idcard.TabIndex = 1;
            this.idcard.Text = "632122198804046119";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "身份证号";
            // 
            // patient_id
            // 
            this.patient_id.Location = new System.Drawing.Point(1140, 20);
            this.patient_id.Name = "patient_id";
            this.patient_id.Size = new System.Drawing.Size(137, 21);
            this.patient_id.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1093, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "住院号";
            // 
            // in_dept
            // 
            this.in_dept.Location = new System.Drawing.Point(902, 20);
            this.in_dept.Name = "in_dept";
            this.in_dept.Size = new System.Drawing.Size(185, 21);
            this.in_dept.TabIndex = 1;
            this.in_dept.Text = "治未病中心";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(867, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "科室";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(68, 20);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(131, 21);
            this.name.TabIndex = 1;
            this.name.Text = "马在乃白";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.c1FlexGridUploadedFeeDetails);
            this.groupBox3.Location = new System.Drawing.Point(5, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(682, 371);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "已上传费用明细";
            // 
            // c1FlexGridUploadedFeeDetails
            // 
            this.c1FlexGridUploadedFeeDetails.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridUploadedFeeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridUploadedFeeDetails.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridUploadedFeeDetails.Name = "c1FlexGridUploadedFeeDetails";
            this.c1FlexGridUploadedFeeDetails.Rows.DefaultSize = 20;
            this.c1FlexGridUploadedFeeDetails.Size = new System.Drawing.Size(676, 351);
            this.c1FlexGridUploadedFeeDetails.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.c1FlexGridFeeDetails);
            this.groupBox4.Location = new System.Drawing.Point(693, 141);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(601, 371);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "已录入费用明细";
            // 
            // c1FlexGridFeeDetails
            // 
            this.c1FlexGridFeeDetails.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridFeeDetails.ContextMenuStrip = this.contextMenuStripFeeDetails;
            this.c1FlexGridFeeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridFeeDetails.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridFeeDetails.Name = "c1FlexGridFeeDetails";
            this.c1FlexGridFeeDetails.Rows.DefaultSize = 20;
            this.c1FlexGridFeeDetails.Size = new System.Drawing.Size(595, 351);
            this.c1FlexGridFeeDetails.TabIndex = 1;
            this.c1FlexGridFeeDetails.ValidateEdit += new C1.Win.C1FlexGrid.ValidateEditEventHandler(this.c1FlexGridFeeDetails_ValidateEdit);
            this.c1FlexGridFeeDetails.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.c1FlexGridFeeDetails_AfterSelChange);
            this.c1FlexGridFeeDetails.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGridFeeDetails_AfterEdit);
            // 
            // contextMenuStripFeeDetails
            // 
            this.contextMenuStripFeeDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddFeeDetails,
            this.ToolStripMenuItemDelFeeDetails,
            this.ToolStripMenuItemClear});
            this.contextMenuStripFeeDetails.Name = "contextMenuStripFeeDetails";
            this.contextMenuStripFeeDetails.Size = new System.Drawing.Size(179, 92);
            // 
            // ToolStripMenuItemAddFeeDetails
            // 
            this.ToolStripMenuItemAddFeeDetails.Image = global::Windows.ResImage.add;
            this.ToolStripMenuItemAddFeeDetails.Name = "ToolStripMenuItemAddFeeDetails";
            this.ToolStripMenuItemAddFeeDetails.Size = new System.Drawing.Size(178, 22);
            this.ToolStripMenuItemAddFeeDetails.Text = "添加费用明细";
            this.ToolStripMenuItemAddFeeDetails.Click += new System.EventHandler(this.ToolStripMenuItemAddFeeDetails_Click);
            // 
            // ToolStripMenuItemDelFeeDetails
            // 
            this.ToolStripMenuItemDelFeeDetails.Image = global::Windows.ResImage.cancel;
            this.ToolStripMenuItemDelFeeDetails.Name = "ToolStripMenuItemDelFeeDetails";
            this.ToolStripMenuItemDelFeeDetails.Size = new System.Drawing.Size(178, 22);
            this.ToolStripMenuItemDelFeeDetails.Text = "删除费用明细";
            this.ToolStripMenuItemDelFeeDetails.Click += new System.EventHandler(this.ToolStripMenuItemDelFeeDetails_Click);
            // 
            // ToolStripMenuItemClear
            // 
            this.ToolStripMenuItemClear.Image = global::Windows.ResImage.rosette;
            this.ToolStripMenuItemClear.Name = "ToolStripMenuItemClear";
            this.ToolStripMenuItemClear.Size = new System.Drawing.Size(178, 22);
            this.ToolStripMenuItemClear.Text = "清空已录入费用明细";
            this.ToolStripMenuItemClear.Click += new System.EventHandler(this.ToolStripMenuItemClear_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDelete);
            this.groupBox5.Controls.Add(this.c1FlexGridPayInfo);
            this.groupBox5.Controls.Add(this.lblTotalFee);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(8, 518);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(750, 116);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "所有费用信息(单位：元)";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::Windows.ResImage.application_delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(382, 20);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(178, 23);
            this.btnDelete.TabIndex = 38;
            this.btnDelete.Text = "   删除全部已上传费用明细";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // c1FlexGridPayInfo
            // 
            this.c1FlexGridPayInfo.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridPayInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.c1FlexGridPayInfo.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridPayInfo.Name = "c1FlexGridPayInfo";
            this.c1FlexGridPayInfo.Rows.DefaultSize = 20;
            this.c1FlexGridPayInfo.Size = new System.Drawing.Size(360, 96);
            this.c1FlexGridPayInfo.TabIndex = 4;
            // 
            // lblTotalFee
            // 
            this.lblTotalFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalFee.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalFee.ForeColor = System.Drawing.Color.Red;
            this.lblTotalFee.Location = new System.Drawing.Point(424, 90);
            this.lblTotalFee.Name = "lblTotalFee";
            this.lblTotalFee.Size = new System.Drawing.Size(84, 18);
            this.lblTotalFee.TabIndex = 3;
            this.lblTotalFee.Text = "0.00";
            this.lblTotalFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "总费用";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::Windows.ResImage.accept;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1034, 529);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 23);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "   校验保存录入的费用明细";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalc.Image = global::Windows.ResImage.anchor;
            this.btnCalc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalc.Location = new System.Drawing.Point(915, 529);
            this.btnCalc.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(108, 23);
            this.btnCalc.TabIndex = 33;
            this.btnCalc.Text = "   住院费用计算";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Windows.ResImage.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1225, 529);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 23);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "   退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.Red;
            this.label40.Location = new System.Drawing.Point(864, 589);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(41, 12);
            this.label40.TabIndex = 4;
            this.label40.Text = "注意：";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.Red;
            this.label42.Location = new System.Drawing.Point(867, 611);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(299, 12);
            this.label42.TabIndex = 35;
            this.label42.Text = "1、右键已录入费用明细，进行【添加】和【删除】操作";
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Image = global::Windows.ResImage.wand;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(760, 529);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(144, 23);
            this.btnQuery.TabIndex = 37;
            this.btnQuery.Text = "   查询已保存费用明细";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // Frm_FeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 635);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxPersonInfo);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCalc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_FeeDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "普通住院费用记帐";
            this.Load += new System.EventHandler(this.Frm_FeeDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxPersonInfo.ResumeLayout(false);
            this.groupBoxPersonInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridUploadedFeeDetails)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridFeeDetails)).EndInit();
            this.contextMenuStripFeeDetails.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPayInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblICCard;
        private System.Windows.Forms.Button btnReadCard;
        private System.Windows.Forms.Button btnFindPatient;
        private System.Windows.Forms.GroupBox groupBoxPersonInfo;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idcard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pers_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox serial_no;
        private System.Windows.Forms.TextBox corp_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox treatment_type;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox in_dept;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox begin_date;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox in_disease_name;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox patient_id;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker fee_date;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridUploadedFeeDetails;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridFeeDetails;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalFee;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFeeDetails;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddFeeDetails;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelFeeDetails;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClear;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridPayInfo;
        private System.Windows.Forms.Button btnDelete;
    }
}