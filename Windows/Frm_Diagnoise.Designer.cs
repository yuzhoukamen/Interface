namespace Windows
{
    partial class Frm_Diagnoise
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtBoxICDName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblICDID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.c1FlexGridDiagnoise = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDiagnoise)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.txtBoxICDName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblICDID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HIS疾病诊断信息";
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Image = global::Windows.ResImage.tick;
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(724, 19);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 38);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "   检索";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtBoxICDName
            // 
            this.txtBoxICDName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxICDName.ForeColor = System.Drawing.Color.LightCoral;
            this.txtBoxICDName.Location = new System.Drawing.Point(268, 25);
            this.txtBoxICDName.Name = "txtBoxICDName";
            this.txtBoxICDName.Size = new System.Drawing.Size(433, 26);
            this.txtBoxICDName.TabIndex = 3;
            this.txtBoxICDName.Text = "脊椎关节强硬伴有神经根病(神经根型颈椎病)";
            this.txtBoxICDName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxICDName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(219, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "名称：";
            // 
            // lblICDID
            // 
            this.lblICDID.AutoSize = true;
            this.lblICDID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblICDID.Location = new System.Drawing.Point(104, 28);
            this.lblICDID.Name = "lblICDID";
            this.lblICDID.Size = new System.Drawing.Size(98, 16);
            this.lblICDID.TabIndex = 1;
            this.lblICDID.Text = "G54.251   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ICD编码：";
            // 
            // c1FlexGridDiagnoise
            // 
            this.c1FlexGridDiagnoise.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridDiagnoise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridDiagnoise.Location = new System.Drawing.Point(0, 83);
            this.c1FlexGridDiagnoise.Name = "c1FlexGridDiagnoise";
            this.c1FlexGridDiagnoise.Rows.DefaultSize = 20;
            this.c1FlexGridDiagnoise.Size = new System.Drawing.Size(814, 317);
            this.c1FlexGridDiagnoise.TabIndex = 1;
            this.c1FlexGridDiagnoise.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.c1FlexGridDiagnoise_MouseDoubleClick);
            this.c1FlexGridDiagnoise.SelChange += new System.EventHandler(this.c1FlexGridDiagnoise_SelChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "注意：双击选择【疾病诊断】";
            // 
            // Frm_Diagnoise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 400);
            this.Controls.Add(this.c1FlexGridDiagnoise);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Diagnoise";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "疾病诊断";
            this.Load += new System.EventHandler(this.Frm_Diagnoise_Load);
            this.Shown += new System.EventHandler(this.Frm_Diagnoise_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDiagnoise)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblICDID;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridDiagnoise;
        private System.Windows.Forms.TextBox txtBoxICDName;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label5;
    }
}