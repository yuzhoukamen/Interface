namespace Windows
{
    partial class Frm_Fund
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
            this.c1FlexGridFund = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridFund)).BeginInit();
            this.SuspendLayout();
            // 
            // c1FlexGridFund
            // 
            this.c1FlexGridFund.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridFund.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridFund.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGridFund.Name = "c1FlexGridFund";
            this.c1FlexGridFund.Rows.DefaultSize = 20;
            this.c1FlexGridFund.Size = new System.Drawing.Size(364, 279);
            this.c1FlexGridFund.TabIndex = 0;
            // 
            // Frm_Fund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 279);
            this.Controls.Add(this.c1FlexGridFund);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Fund";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基金信息";
            this.Load += new System.EventHandler(this.Frm_Fund_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridFund)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridFund;
    }
}