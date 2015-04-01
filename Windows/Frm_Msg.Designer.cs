namespace Windows
{
    partial class Frm_Msg
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
            this.webBrowserMsg = new System.Windows.Forms.WebBrowser();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rTxtBoxMsg = new System.Windows.Forms.RichTextBox();
            this.c1FlexGridMsg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridMsg)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webBrowserMsg);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 377);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "院内通知";
            // 
            // webBrowserMsg
            // 
            this.webBrowserMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserMsg.Location = new System.Drawing.Point(3, 17);
            this.webBrowserMsg.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMsg.Name = "webBrowserMsg";
            this.webBrowserMsg.Size = new System.Drawing.Size(422, 357);
            this.webBrowserMsg.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rTxtBoxMsg);
            this.groupBox2.Controls.Add(this.c1FlexGridMsg);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(428, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 377);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "社保通知";
            // 
            // rTxtBoxMsg
            // 
            this.rTxtBoxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtBoxMsg.Location = new System.Drawing.Point(3, 185);
            this.rTxtBoxMsg.Name = "rTxtBoxMsg";
            this.rTxtBoxMsg.Size = new System.Drawing.Size(480, 189);
            this.rTxtBoxMsg.TabIndex = 1;
            this.rTxtBoxMsg.Text = "";
            // 
            // c1FlexGridMsg
            // 
            this.c1FlexGridMsg.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1FlexGridMsg.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridMsg.Name = "c1FlexGridMsg";
            this.c1FlexGridMsg.Rows.DefaultSize = 20;
            this.c1FlexGridMsg.Size = new System.Drawing.Size(480, 168);
            this.c1FlexGridMsg.TabIndex = 0;
            this.c1FlexGridMsg.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.c1FlexGridMsg_AfterSelChange);
            // 
            // Frm_Msg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 377);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Msg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通知管理";
            this.Load += new System.EventHandler(this.Frm_Msg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridMsg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rTxtBoxMsg;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridMsg;
        private System.Windows.Forms.WebBrowser webBrowserMsg;
    }
}