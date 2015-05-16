namespace Windows.MZ
{
    partial class Frm_MZ_FindChargedPatients
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxICCard = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxPatientName = new System.Windows.Forms.TextBox();
            this.btnFindPatients = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c1FlexGridChargedPatients = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridChargedPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(894, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePickerStartTime);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePickerEndTime);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxICCard);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxPatientName);
            this.flowLayoutPanel1.Controls.Add(this.btnFindPatients);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(888, 40);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "收费时间：";
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(79, 3);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.ShowUpDown = true;
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(144, 21);
            this.dateTimePickerStartTime.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(229, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "到";
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(257, 3);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.ShowUpDown = true;
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(139, 21);
            this.dateTimePickerEndTime.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(402, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "医保卡号：";
            // 
            // txtBoxICCard
            // 
            this.txtBoxICCard.Location = new System.Drawing.Point(478, 3);
            this.txtBoxICCard.Name = "txtBoxICCard";
            this.txtBoxICCard.Size = new System.Drawing.Size(113, 21);
            this.txtBoxICCard.TabIndex = 15;
            this.txtBoxICCard.Text = "145629875";
            this.txtBoxICCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxICCard_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(597, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "患者姓名：";
            // 
            // txtBoxPatientName
            // 
            this.txtBoxPatientName.Location = new System.Drawing.Point(673, 3);
            this.txtBoxPatientName.Name = "txtBoxPatientName";
            this.txtBoxPatientName.Size = new System.Drawing.Size(115, 21);
            this.txtBoxPatientName.TabIndex = 17;
            this.txtBoxPatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxPatientName_KeyDown);
            // 
            // btnFindPatients
            // 
            this.btnFindPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPatients.Image = global::Windows.ResImage.tick;
            this.btnFindPatients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFindPatients.Location = new System.Drawing.Point(794, 3);
            this.btnFindPatients.Name = "btnFindPatients";
            this.btnFindPatients.Size = new System.Drawing.Size(84, 31);
            this.btnFindPatients.TabIndex = 18;
            this.btnFindPatients.Text = "  查找患者";
            this.btnFindPatients.UseVisualStyleBackColor = true;
            this.btnFindPatients.Click += new System.EventHandler(this.btnFindPatients_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.c1FlexGridChargedPatients);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(894, 341);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "患者信息";
            // 
            // c1FlexGridChargedPatients
            // 
            this.c1FlexGridChargedPatients.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridChargedPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridChargedPatients.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridChargedPatients.Name = "c1FlexGridChargedPatients";
            this.c1FlexGridChargedPatients.Rows.DefaultSize = 20;
            this.c1FlexGridChargedPatients.Size = new System.Drawing.Size(888, 321);
            this.c1FlexGridChargedPatients.TabIndex = 0;
            this.c1FlexGridChargedPatients.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.c1FlexGridChargedPatients_MouseDoubleClick);
            this.c1FlexGridChargedPatients.SelChange += new System.EventHandler(this.c1FlexGridChargedPatients_SelChange);
            // 
            // Frm_MZ_FindChargedPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 401);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_MZ_FindChargedPatients";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找已收费患者";
            this.Load += new System.EventHandler(this.Frm_MZ_FindChargedPatients_Load);
            this.Shown += new System.EventHandler(this.Frm_MZ_FindChargedPatients_Shown);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridChargedPatients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxICCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxPatientName;
        private System.Windows.Forms.Button btnFindPatients;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridChargedPatients;
    }
}