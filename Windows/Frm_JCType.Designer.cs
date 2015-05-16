namespace Windows
{
    partial class Frm_JCType
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
            this.c1FlexGridType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.c1FlexGridCompareTable = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridCompareTable)).BeginInit();
            this.SuspendLayout();
            // 
            // c1FlexGridType
            // 
            this.c1FlexGridType.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridType.Dock = System.Windows.Forms.DockStyle.Left;
            this.c1FlexGridType.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGridType.Name = "c1FlexGridType";
            this.c1FlexGridType.Rows.DefaultSize = 20;
            this.c1FlexGridType.Size = new System.Drawing.Size(242, 507);
            this.c1FlexGridType.TabIndex = 0;
            // 
            // c1FlexGridCompareTable
            // 
            this.c1FlexGridCompareTable.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridCompareTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridCompareTable.Location = new System.Drawing.Point(242, 0);
            this.c1FlexGridCompareTable.Name = "c1FlexGridCompareTable";
            this.c1FlexGridCompareTable.Rows.DefaultSize = 20;
            this.c1FlexGridCompareTable.Size = new System.Drawing.Size(525, 507);
            this.c1FlexGridCompareTable.TabIndex = 1;
            // 
            // Frm_JCType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 507);
            this.Controls.Add(this.c1FlexGridCompareTable);
            this.Controls.Add(this.c1FlexGridType);
            this.Name = "Frm_JCType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基础类别";
            this.Load += new System.EventHandler(this.Frm_JCType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridCompareTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridType;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridCompareTable;
    }
}