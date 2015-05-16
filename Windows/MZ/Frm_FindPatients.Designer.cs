namespace Windows.MZ
{
    partial class Frm_FindPatients
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
            this.txtBoxKPPerson = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFindPatients = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxCardNumbers = new System.Windows.Forms.TextBox();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxPatientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c1FlexGridPatients = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxKPPerson);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnFindPatients);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxCardNumbers);
            this.groupBox1.Controls.Add(this.dateTimePickerStartTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBoxPatientName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerEndTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询参数";
            // 
            // txtBoxKPPerson
            // 
            this.txtBoxKPPerson.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxKPPerson.Location = new System.Drawing.Point(560, 49);
            this.txtBoxKPPerson.Name = "txtBoxKPPerson";
            this.txtBoxKPPerson.Size = new System.Drawing.Size(140, 21);
            this.txtBoxKPPerson.TabIndex = 12;
            this.txtBoxKPPerson.Text = "张文远";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(510, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "开票人：";
            // 
            // btnFindPatients
            // 
            this.btnFindPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPatients.Image = global::Windows.ResImage.tick;
            this.btnFindPatients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindPatients.Location = new System.Drawing.Point(715, 22);
            this.btnFindPatients.Name = "btnFindPatients";
            this.btnFindPatients.Size = new System.Drawing.Size(93, 42);
            this.btnFindPatients.TabIndex = 10;
            this.btnFindPatients.Text = "  查找患者";
            this.btnFindPatients.UseVisualStyleBackColor = true;
            this.btnFindPatients.Click += new System.EventHandler(this.btnFindPatients_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "一卡通号：";
            // 
            // txtBoxCardNumbers
            // 
            this.txtBoxCardNumbers.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxCardNumbers.ForeColor = System.Drawing.Color.Red;
            this.txtBoxCardNumbers.Location = new System.Drawing.Point(71, 45);
            this.txtBoxCardNumbers.Name = "txtBoxCardNumbers";
            this.txtBoxCardNumbers.Size = new System.Drawing.Size(409, 26);
            this.txtBoxCardNumbers.TabIndex = 1;
            this.txtBoxCardNumbers.Text = "63212200010000000012=122";
            this.txtBoxCardNumbers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxCardNumbers_KeyDown);
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(71, 16);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.ShowUpDown = true;
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(204, 21);
            this.dateTimePickerStartTime.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(7, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "开票时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(281, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "到";
            // 
            // txtBoxPatientName
            // 
            this.txtBoxPatientName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxPatientName.Location = new System.Drawing.Point(560, 19);
            this.txtBoxPatientName.Name = "txtBoxPatientName";
            this.txtBoxPatientName.Size = new System.Drawing.Size(140, 21);
            this.txtBoxPatientName.TabIndex = 3;
            this.txtBoxPatientName.Text = "张文远";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(498, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "患者姓名：";
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(302, 16);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.ShowUpDown = true;
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(178, 21);
            this.dateTimePickerEndTime.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.c1FlexGridPatients);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(835, 356);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查找结果";
            // 
            // c1FlexGridPatients
            // 
            this.c1FlexGridPatients.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            this.c1FlexGridPatients.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridPatients.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.c1FlexGridPatients.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridPatients.Name = "c1FlexGridPatients";
            this.c1FlexGridPatients.Rows.DefaultSize = 20;
            this.c1FlexGridPatients.Size = new System.Drawing.Size(829, 336);
            this.c1FlexGridPatients.TabIndex = 2;
            this.c1FlexGridPatients.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.c1FlexGridPatients_MouseDoubleClick);
            this.c1FlexGridPatients.SelChange += new System.EventHandler(this.c1FlexGridPatients_SelChange);
            // 
            // Frm_FindPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_FindPatients";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找患者";
            this.Load += new System.EventHandler(this.Frm_FindPatients_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPatients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxCardNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxPatientName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.Button btnFindPatients;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridPatients;
        private System.Windows.Forms.TextBox txtBoxKPPerson;
        private System.Windows.Forms.Label label3;
    }
}