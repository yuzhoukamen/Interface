namespace Windows.Report
{
    partial class Frm_Report_ZY_AllBusiness
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
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalFee = new System.Windows.Forms.Label();
            this.c1FlexGridInfo = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOutHospitalSettlement = new System.Windows.Forms.Button();
            this.btnFeeDetails = new System.Windows.Forms.Button();
            this.buttonUpdate_foregift = new System.Windows.Forms.Button();
            this.btnCancelInHospitalRegister = new System.Windows.Forms.Button();
            this.btnCancelInHospitalSettlement = new System.Windows.Forms.Button();
            this.btnAllInfo = new System.Windows.Forms.Button();
            this.btnPatientInfo = new System.Windows.Forms.Button();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnOutExcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.radioButtonYes = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Brown;
            this.label7.Location = new System.Drawing.Point(864, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 8, 200, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "注意：双击业务信息记录，查看明细";
            // 
            // lblTotalFee
            // 
            this.lblTotalFee.AutoSize = true;
            this.lblTotalFee.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalFee.ForeColor = System.Drawing.Color.Red;
            this.lblTotalFee.Location = new System.Drawing.Point(683, 54);
            this.lblTotalFee.Margin = new System.Windows.Forms.Padding(3, 8, 30, 0);
            this.lblTotalFee.Name = "lblTotalFee";
            this.lblTotalFee.Size = new System.Drawing.Size(98, 12);
            this.lblTotalFee.TabIndex = 39;
            this.lblTotalFee.Text = "总金额：1200元";
            // 
            // c1FlexGridInfo
            // 
            this.c1FlexGridInfo.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridInfo.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridInfo.Name = "c1FlexGridInfo";
            this.c1FlexGridInfo.Rows.DefaultSize = 20;
            this.c1FlexGridInfo.Size = new System.Drawing.Size(1080, 364);
            this.c1FlexGridInfo.TabIndex = 37;
            this.c1FlexGridInfo.DoubleClick += new System.EventHandler(this.c1FlexGridInfo_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.c1FlexGridInfo);
            this.groupBox2.Location = new System.Drawing.Point(0, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1086, 384);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "业务信息";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOutHospitalSettlement);
            this.groupBox3.Controls.Add(this.btnFeeDetails);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.buttonUpdate_foregift);
            this.groupBox3.Controls.Add(this.btnCancelInHospitalRegister);
            this.groupBox3.Controls.Add(this.btnCancelInHospitalSettlement);
            this.groupBox3.Controls.Add(this.btnAllInfo);
            this.groupBox3.Controls.Add(this.btnPatientInfo);
            this.groupBox3.Controls.Add(this.lblTotalFee);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1086, 76);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            // 
            // btnOutHospitalSettlement
            // 
            this.btnOutHospitalSettlement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutHospitalSettlement.Image = global::Windows.ResImage.money_yen;
            this.btnOutHospitalSettlement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOutHospitalSettlement.Location = new System.Drawing.Point(691, 20);
            this.btnOutHospitalSettlement.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnOutHospitalSettlement.Name = "btnOutHospitalSettlement";
            this.btnOutHospitalSettlement.Size = new System.Drawing.Size(88, 23);
            this.btnOutHospitalSettlement.TabIndex = 45;
            this.btnOutHospitalSettlement.Text = "   出院结算";
            this.btnOutHospitalSettlement.UseVisualStyleBackColor = true;
            this.btnOutHospitalSettlement.Click += new System.EventHandler(this.btnOutHospitalSettlement_Click);
            // 
            // btnFeeDetails
            // 
            this.btnFeeDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeeDetails.Image = global::Windows.ResImage.money;
            this.btnFeeDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFeeDetails.Location = new System.Drawing.Point(586, 20);
            this.btnFeeDetails.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnFeeDetails.Name = "btnFeeDetails";
            this.btnFeeDetails.Size = new System.Drawing.Size(88, 23);
            this.btnFeeDetails.TabIndex = 44;
            this.btnFeeDetails.Text = "   费用明细";
            this.btnFeeDetails.UseVisualStyleBackColor = true;
            this.btnFeeDetails.Click += new System.EventHandler(this.btnFeeDetails_Click);
            // 
            // buttonUpdate_foregift
            // 
            this.buttonUpdate_foregift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate_foregift.Image = global::Windows.ResImage.money;
            this.buttonUpdate_foregift.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate_foregift.Location = new System.Drawing.Point(445, 20);
            this.buttonUpdate_foregift.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.buttonUpdate_foregift.Name = "buttonUpdate_foregift";
            this.buttonUpdate_foregift.Size = new System.Drawing.Size(130, 23);
            this.buttonUpdate_foregift.TabIndex = 43;
            this.buttonUpdate_foregift.Text = "   修改预付款信息";
            this.buttonUpdate_foregift.UseVisualStyleBackColor = true;
            this.buttonUpdate_foregift.Click += new System.EventHandler(this.buttonUpdate_foregift_Click);
            // 
            // btnCancelInHospitalRegister
            // 
            this.btnCancelInHospitalRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelInHospitalRegister.Image = global::Windows.ResImage.cancel1;
            this.btnCancelInHospitalRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelInHospitalRegister.Location = new System.Drawing.Point(6, 20);
            this.btnCancelInHospitalRegister.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnCancelInHospitalRegister.Name = "btnCancelInHospitalRegister";
            this.btnCancelInHospitalRegister.Size = new System.Drawing.Size(107, 23);
            this.btnCancelInHospitalRegister.TabIndex = 39;
            this.btnCancelInHospitalRegister.Text = "   取消入院登记";
            this.btnCancelInHospitalRegister.UseVisualStyleBackColor = true;
            this.btnCancelInHospitalRegister.Click += new System.EventHandler(this.btnCancelInHospitalRegister_Click);
            // 
            // btnCancelInHospitalSettlement
            // 
            this.btnCancelInHospitalSettlement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelInHospitalSettlement.Image = global::Windows.ResImage.compress;
            this.btnCancelInHospitalSettlement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelInHospitalSettlement.Location = new System.Drawing.Point(790, 20);
            this.btnCancelInHospitalSettlement.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnCancelInHospitalSettlement.Name = "btnCancelInHospitalSettlement";
            this.btnCancelInHospitalSettlement.Size = new System.Drawing.Size(107, 23);
            this.btnCancelInHospitalSettlement.TabIndex = 40;
            this.btnCancelInHospitalSettlement.Text = "   取消出院结算";
            this.btnCancelInHospitalSettlement.UseVisualStyleBackColor = true;
            this.btnCancelInHospitalSettlement.Click += new System.EventHandler(this.btnCancelInHospitalSettlement_Click);
            // 
            // btnAllInfo
            // 
            this.btnAllInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllInfo.Image = global::Windows.ResImage.application_form;
            this.btnAllInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllInfo.Location = new System.Drawing.Point(304, 20);
            this.btnAllInfo.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnAllInfo.Name = "btnAllInfo";
            this.btnAllInfo.Size = new System.Drawing.Size(130, 23);
            this.btnAllInfo.TabIndex = 42;
            this.btnAllInfo.Text = "   查看病人详细信息";
            this.btnAllInfo.UseVisualStyleBackColor = true;
            this.btnAllInfo.Click += new System.EventHandler(this.btnAllInfo_Click);
            // 
            // btnPatientInfo
            // 
            this.btnPatientInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientInfo.Image = global::Windows.ResImage.application_double;
            this.btnPatientInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatientInfo.Location = new System.Drawing.Point(124, 20);
            this.btnPatientInfo.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnPatientInfo.Name = "btnPatientInfo";
            this.btnPatientInfo.Size = new System.Drawing.Size(169, 23);
            this.btnPatientInfo.TabIndex = 41;
            this.btnPatientInfo.Text = "   查看病人信息和业务信息";
            this.btnPatientInfo.UseVisualStyleBackColor = true;
            this.btnPatientInfo.Click += new System.EventHandler(this.btnPatientInfo_Click);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(84, 20);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.ShowUpDown = true;
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(85, 21);
            this.dateTimePickerStartDate.TabIndex = 8;
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Image = global::Windows.ResImage.money_yen;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(476, 19);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(20, 3, 8, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 23);
            this.btnQuery.TabIndex = 40;
            this.btnQuery.Text = "   检索数据";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "起始时间：";
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(213, 20);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.ShowUpDown = true;
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(85, 21);
            this.dateTimePickerEndDate.TabIndex = 10;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::Windows.ResImage.printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(586, 19);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(107, 23);
            this.btnPrint.TabIndex = 34;
            this.btnPrint.Text = "   打印结算单";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOutExcel
            // 
            this.btnOutExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutExcel.Image = global::Windows.ResImage.wand;
            this.btnOutExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOutExcel.Location = new System.Drawing.Point(720, 19);
            this.btnOutExcel.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnOutExcel.Name = "btnOutExcel";
            this.btnOutExcel.Size = new System.Drawing.Size(85, 23);
            this.btnOutExcel.TabIndex = 35;
            this.btnOutExcel.Text = "   导出数据";
            this.btnOutExcel.UseVisualStyleBackColor = true;
            this.btnOutExcel.Click += new System.EventHandler(this.btnOutExcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnOutExcel);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.dateTimePickerEndDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.dateTimePickerStartDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1086, 51);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "---";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonNo);
            this.groupBox4.Controls.Add(this.radioButtonYes);
            this.groupBox4.Location = new System.Drawing.Point(304, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(152, 34);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Checked = true;
            this.radioButtonNo.Location = new System.Drawing.Point(6, 12);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(59, 16);
            this.radioButtonNo.TabIndex = 1;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "未结算";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            this.radioButtonNo.Click += new System.EventHandler(this.radioButtonNo_Click);
            // 
            // radioButtonYes
            // 
            this.radioButtonYes.AutoSize = true;
            this.radioButtonYes.Location = new System.Drawing.Point(84, 12);
            this.radioButtonYes.Name = "radioButtonYes";
            this.radioButtonYes.Size = new System.Drawing.Size(59, 16);
            this.radioButtonYes.TabIndex = 0;
            this.radioButtonYes.Text = "已结算";
            this.radioButtonYes.UseVisualStyleBackColor = true;
            this.radioButtonYes.Click += new System.EventHandler(this.radioButtonYes_Click);
            // 
            // Frm_Report_ZY_AllBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 515);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Report_ZY_AllBusiness";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提取所有的业务信息";
            this.Load += new System.EventHandler(this.Frm_Report_ZY_AllBusiness_Load);
            this.Shown += new System.EventHandler(this.Frm_Report_ZY_AllBusiness_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Report_ZY_AllBusiness_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalFee;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridInfo;
        private System.Windows.Forms.Button btnCancelInHospitalRegister;
        private System.Windows.Forms.Button btnCancelInHospitalSettlement;
        private System.Windows.Forms.Button btnPatientInfo;
        private System.Windows.Forms.Button btnAllInfo;
        private System.Windows.Forms.Button buttonUpdate_foregift;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFeeDetails;
        private System.Windows.Forms.Button btnOutHospitalSettlement;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnOutExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonNo;
        private System.Windows.Forms.RadioButton radioButtonYes;
        private System.Windows.Forms.Label label1;
    }
}