namespace Windows
{
    partial class Frm_SelectDirCompare
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCenterID = new System.Windows.Forms.Label();
            this.lblHospitalID = new System.Windows.Forms.Label();
            this.lblMatchType = new System.Windows.Forms.Label();
            this.lblHosp_code = new System.Windows.Forms.Label();
            this.lblHosp_name = new System.Windows.Forms.Label();
            this.c1FlexGridSelectDirCompare = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridSelectDirCompare)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCenterID);
            this.panel1.Controls.Add(this.lblHospitalID);
            this.panel1.Controls.Add(this.lblMatchType);
            this.panel1.Controls.Add(this.lblHosp_code);
            this.panel1.Controls.Add(this.lblHosp_name);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 55);
            this.panel1.TabIndex = 0;
            // 
            // lblCenterID
            // 
            this.lblCenterID.AutoSize = true;
            this.lblCenterID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCenterID.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCenterID.Location = new System.Drawing.Point(147, 13);
            this.lblCenterID.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblCenterID.Name = "lblCenterID";
            this.lblCenterID.Size = new System.Drawing.Size(105, 12);
            this.lblCenterID.TabIndex = 5;
            this.lblCenterID.Text = "中心编码：15487";
            // 
            // lblHospitalID
            // 
            this.lblHospitalID.AutoSize = true;
            this.lblHospitalID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHospitalID.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblHospitalID.Location = new System.Drawing.Point(317, 13);
            this.lblHospitalID.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblHospitalID.Name = "lblHospitalID";
            this.lblHospitalID.Size = new System.Drawing.Size(112, 12);
            this.lblHospitalID.TabIndex = 6;
            this.lblHospitalID.Text = "医院编码：252353";
            // 
            // lblMatchType
            // 
            this.lblMatchType.AutoSize = true;
            this.lblMatchType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMatchType.ForeColor = System.Drawing.Color.LightCoral;
            this.lblMatchType.Location = new System.Drawing.Point(5, 30);
            this.lblMatchType.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblMatchType.Name = "lblMatchType";
            this.lblMatchType.Size = new System.Drawing.Size(122, 12);
            this.lblMatchType.TabIndex = 7;
            this.lblMatchType.Text = "匹配类型：诊疗项目";
            // 
            // lblHosp_code
            // 
            this.lblHosp_code.AutoSize = true;
            this.lblHosp_code.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHosp_code.ForeColor = System.Drawing.Color.LightCoral;
            this.lblHosp_code.Location = new System.Drawing.Point(147, 30);
            this.lblHosp_code.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblHosp_code.Name = "lblHosp_code";
            this.lblHosp_code.Size = new System.Drawing.Size(131, 12);
            this.lblHosp_code.TabIndex = 8;
            this.lblHosp_code.Text = "医院目录编码：45789";
            // 
            // lblHosp_name
            // 
            this.lblHosp_name.AutoSize = true;
            this.lblHosp_name.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHosp_name.ForeColor = System.Drawing.Color.LightCoral;
            this.lblHosp_name.Location = new System.Drawing.Point(317, 30);
            this.lblHosp_name.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblHosp_name.Name = "lblHosp_name";
            this.lblHosp_name.Size = new System.Drawing.Size(187, 12);
            this.lblHosp_name.TabIndex = 9;
            this.lblHosp_name.Text = "医院目录名称：药浴床位四人间";
            // 
            // c1FlexGridSelectDirCompare
            // 
            this.c1FlexGridSelectDirCompare.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridSelectDirCompare.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1FlexGridSelectDirCompare.Location = new System.Drawing.Point(0, 55);
            this.c1FlexGridSelectDirCompare.Name = "c1FlexGridSelectDirCompare";
            this.c1FlexGridSelectDirCompare.Rows.DefaultSize = 20;
            this.c1FlexGridSelectDirCompare.Size = new System.Drawing.Size(577, 246);
            this.c1FlexGridSelectDirCompare.TabIndex = 1;
            this.c1FlexGridSelectDirCompare.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.c1FlexGridSelectDirCompare_MouseDoubleClick);
            this.c1FlexGridSelectDirCompare.SelChange += new System.EventHandler(this.c1FlexGridSelectDirCompare_SelChange);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 307);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 32);
            this.panel2.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Windows.ResImage.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(488, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "   取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Image = global::Windows.ResImage.tick;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(384, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "   确认";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // Frm_SelectDirCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(577, 339);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.c1FlexGridSelectDirCompare);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_SelectDirCompare";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择医院目录对照字典";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_SelectDirCompare_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridSelectDirCompare)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridSelectDirCompare;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCenterID;
        private System.Windows.Forms.Label lblHospitalID;
        private System.Windows.Forms.Label lblMatchType;
        private System.Windows.Forms.Label lblHosp_code;
        private System.Windows.Forms.Label lblHosp_name;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}