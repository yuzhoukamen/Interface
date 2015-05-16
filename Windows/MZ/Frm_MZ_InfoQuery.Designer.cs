namespace Windows.MZ
{
    partial class Frm_MZ_InfoQuery
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtBoxCenter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxHospital = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxQueryType = new System.Windows.Forms.TextBox();
            this.lblQueryType = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonByindi_id = new System.Windows.Forms.RadioButton();
            this.radioButtonByname = new System.Windows.Forms.RadioButton();
            this.radioButtonByidcard = new System.Windows.Forms.RadioButton();
            this.radioButtonByiccardno = new System.Windows.Forms.RadioButton();
            this.radioButtonByinsr_code = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c1FlexGridPersonInfo = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.c1FlexGridFreezeInfo = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.c1FlexGridTotalBizInfo = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cBoxBiz_Type = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPersonInfo)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridFreezeInfo)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridTotalBizInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxBiz_Type);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.txtBoxCenter);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBoxHospital);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxQueryType);
            this.groupBox1.Controls.Add(this.lblQueryType);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询参数";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::Windows.ResImage.application_add;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(857, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 34);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "   保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Image = global::Windows.ResImage.tick;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(767, 55);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(63, 34);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "   检索";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtBoxCenter
            // 
            this.txtBoxCenter.Location = new System.Drawing.Point(554, 86);
            this.txtBoxCenter.Name = "txtBoxCenter";
            this.txtBoxCenter.ReadOnly = true;
            this.txtBoxCenter.Size = new System.Drawing.Size(170, 21);
            this.txtBoxCenter.TabIndex = 8;
            this.txtBoxCenter.Text = "德令哈市医疗保险中心";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(469, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "医保中心编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "业务类型：";
            // 
            // txtBoxHospital
            // 
            this.txtBoxHospital.Location = new System.Drawing.Point(554, 37);
            this.txtBoxHospital.Name = "txtBoxHospital";
            this.txtBoxHospital.ReadOnly = true;
            this.txtBoxHospital.Size = new System.Drawing.Size(170, 21);
            this.txtBoxHospital.TabIndex = 4;
            this.txtBoxHospital.Text = "海西州蒙藏医院";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "医疗机构：";
            // 
            // txtBoxQueryType
            // 
            this.txtBoxQueryType.Location = new System.Drawing.Point(268, 36);
            this.txtBoxQueryType.Name = "txtBoxQueryType";
            this.txtBoxQueryType.Size = new System.Drawing.Size(170, 21);
            this.txtBoxQueryType.TabIndex = 2;
            this.txtBoxQueryType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxQueryType_KeyDown);
            // 
            // lblQueryType
            // 
            this.lblQueryType.AutoSize = true;
            this.lblQueryType.Location = new System.Drawing.Point(196, 40);
            this.lblQueryType.Name = "lblQueryType";
            this.lblQueryType.Size = new System.Drawing.Size(77, 12);
            this.lblQueryType.TabIndex = 1;
            this.lblQueryType.Tag = "1";
            this.lblQueryType.Text = "个人电脑号：";
            this.lblQueryType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButtonByindi_id);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonByname);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonByidcard);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonByiccardno);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonByinsr_code);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(174, 111);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // radioButtonByindi_id
            // 
            this.radioButtonByindi_id.AutoSize = true;
            this.radioButtonByindi_id.Location = new System.Drawing.Point(3, 3);
            this.radioButtonByindi_id.Name = "radioButtonByindi_id";
            this.radioButtonByindi_id.Size = new System.Drawing.Size(119, 16);
            this.radioButtonByindi_id.TabIndex = 0;
            this.radioButtonByindi_id.TabStop = true;
            this.radioButtonByindi_id.Text = "通过参保人电脑号";
            this.radioButtonByindi_id.UseVisualStyleBackColor = true;
            this.radioButtonByindi_id.CheckedChanged += new System.EventHandler(this.radioButtonByindi_id_CheckedChanged);
            // 
            // radioButtonByname
            // 
            this.radioButtonByname.AutoSize = true;
            this.radioButtonByname.Location = new System.Drawing.Point(3, 25);
            this.radioButtonByname.Name = "radioButtonByname";
            this.radioButtonByname.Size = new System.Drawing.Size(119, 16);
            this.radioButtonByname.TabIndex = 1;
            this.radioButtonByname.TabStop = true;
            this.radioButtonByname.Text = "通过参保人的姓名";
            this.radioButtonByname.UseVisualStyleBackColor = true;
            this.radioButtonByname.CheckedChanged += new System.EventHandler(this.radioButtonByname_CheckedChanged);
            // 
            // radioButtonByidcard
            // 
            this.radioButtonByidcard.AutoSize = true;
            this.radioButtonByidcard.Location = new System.Drawing.Point(3, 47);
            this.radioButtonByidcard.Name = "radioButtonByidcard";
            this.radioButtonByidcard.Size = new System.Drawing.Size(167, 16);
            this.radioButtonByidcard.TabIndex = 2;
            this.radioButtonByidcard.TabStop = true;
            this.radioButtonByidcard.Text = "通过参保人的公民身份号码";
            this.radioButtonByidcard.UseVisualStyleBackColor = true;
            this.radioButtonByidcard.CheckedChanged += new System.EventHandler(this.radioButtonByidcard_CheckedChanged);
            // 
            // radioButtonByiccardno
            // 
            this.radioButtonByiccardno.AutoSize = true;
            this.radioButtonByiccardno.Location = new System.Drawing.Point(3, 69);
            this.radioButtonByiccardno.Name = "radioButtonByiccardno";
            this.radioButtonByiccardno.Size = new System.Drawing.Size(131, 16);
            this.radioButtonByiccardno.TabIndex = 3;
            this.radioButtonByiccardno.TabStop = true;
            this.radioButtonByiccardno.Text = "通过参保人的IC卡号";
            this.radioButtonByiccardno.UseVisualStyleBackColor = true;
            this.radioButtonByiccardno.CheckedChanged += new System.EventHandler(this.radioButtonByiccardno_CheckedChanged);
            // 
            // radioButtonByinsr_code
            // 
            this.radioButtonByinsr_code.AutoSize = true;
            this.radioButtonByinsr_code.Location = new System.Drawing.Point(3, 91);
            this.radioButtonByinsr_code.Name = "radioButtonByinsr_code";
            this.radioButtonByinsr_code.Size = new System.Drawing.Size(131, 16);
            this.radioButtonByinsr_code.TabIndex = 4;
            this.radioButtonByinsr_code.TabStop = true;
            this.radioButtonByinsr_code.Text = "通过参保人的保险号";
            this.radioButtonByinsr_code.UseVisualStyleBackColor = true;
            this.radioButtonByinsr_code.CheckedChanged += new System.EventHandler(this.radioButtonByinsr_code_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.c1FlexGridPersonInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(953, 186);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "个人基本信息";
            // 
            // c1FlexGridPersonInfo
            // 
            this.c1FlexGridPersonInfo.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridPersonInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridPersonInfo.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridPersonInfo.Name = "c1FlexGridPersonInfo";
            this.c1FlexGridPersonInfo.Rows.DefaultSize = 20;
            this.c1FlexGridPersonInfo.Size = new System.Drawing.Size(947, 166);
            this.c1FlexGridPersonInfo.TabIndex = 0;
            this.c1FlexGridPersonInfo.SelChange += new System.EventHandler(this.c1FlexGridPersonInfo_SelChange);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.c1FlexGridFreezeInfo);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 317);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(306, 279);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "个人基金冻结信息";
            // 
            // c1FlexGridFreezeInfo
            // 
            this.c1FlexGridFreezeInfo.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridFreezeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridFreezeInfo.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridFreezeInfo.Name = "c1FlexGridFreezeInfo";
            this.c1FlexGridFreezeInfo.Rows.DefaultSize = 20;
            this.c1FlexGridFreezeInfo.Size = new System.Drawing.Size(300, 259);
            this.c1FlexGridFreezeInfo.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.c1FlexGridTotalBizInfo);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(306, 317);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(647, 279);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "个人业务累计信息";
            // 
            // c1FlexGridTotalBizInfo
            // 
            this.c1FlexGridTotalBizInfo.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridTotalBizInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridTotalBizInfo.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridTotalBizInfo.Name = "c1FlexGridTotalBizInfo";
            this.c1FlexGridTotalBizInfo.Rows.DefaultSize = 20;
            this.c1FlexGridTotalBizInfo.Size = new System.Drawing.Size(641, 259);
            this.c1FlexGridTotalBizInfo.TabIndex = 0;
            // 
            // cBoxBiz_Type
            // 
            this.cBoxBiz_Type.FormattingEnabled = true;
            this.cBoxBiz_Type.Location = new System.Drawing.Point(268, 85);
            this.cBoxBiz_Type.Name = "cBoxBiz_Type";
            this.cBoxBiz_Type.Size = new System.Drawing.Size(170, 20);
            this.cBoxBiz_Type.TabIndex = 11;
            // 
            // Frm_MZ_InfoQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 596);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_MZ_InfoQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门诊信息查询";
            this.Load += new System.EventHandler(this.Frm_MZ_InfoQuery_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPersonInfo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridFreezeInfo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridTotalBizInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonByindi_id;
        private System.Windows.Forms.RadioButton radioButtonByname;
        private System.Windows.Forms.RadioButton radioButtonByidcard;
        private System.Windows.Forms.RadioButton radioButtonByiccardno;
        private System.Windows.Forms.RadioButton radioButtonByinsr_code;
        private System.Windows.Forms.TextBox txtBoxQueryType;
        private System.Windows.Forms.Label lblQueryType;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtBoxCenter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxHospital;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridPersonInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridFreezeInfo;
        private System.Windows.Forms.GroupBox groupBox4;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridTotalBizInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cBoxBiz_Type;
    }
}