namespace Windows
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageIDCard = new System.Windows.Forms.TabPage();
            this.pictureBoxPerson = new System.Windows.Forms.PictureBox();
            this.richBoxResult = new System.Windows.Forms.RichTextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.tabPageInterface = new System.Windows.Forms.TabPage();
            this.panelParameter = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxServlet = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageIDCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerson)).BeginInit();
            this.tabPageInterface.SuspendLayout();
            this.panelParameter.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageIDCard);
            this.tabControl1.Controls.Add(this.tabPageInterface);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 438);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageIDCard
            // 
            this.tabPageIDCard.Controls.Add(this.pictureBoxPerson);
            this.tabPageIDCard.Controls.Add(this.richBoxResult);
            this.tabPageIDCard.Controls.Add(this.txtBoxName);
            this.tabPageIDCard.Controls.Add(this.label1);
            this.tabPageIDCard.Controls.Add(this.btnCheck);
            this.tabPageIDCard.Location = new System.Drawing.Point(4, 22);
            this.tabPageIDCard.Name = "tabPageIDCard";
            this.tabPageIDCard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIDCard.Size = new System.Drawing.Size(683, 412);
            this.tabPageIDCard.TabIndex = 0;
            this.tabPageIDCard.Text = "身份证验证";
            this.tabPageIDCard.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPerson
            // 
            this.pictureBoxPerson.Location = new System.Drawing.Point(24, 65);
            this.pictureBoxPerson.Name = "pictureBoxPerson";
            this.pictureBoxPerson.Size = new System.Drawing.Size(172, 165);
            this.pictureBoxPerson.TabIndex = 4;
            this.pictureBoxPerson.TabStop = false;
            // 
            // richBoxResult
            // 
            this.richBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richBoxResult.Location = new System.Drawing.Point(202, 54);
            this.richBoxResult.Name = "richBoxResult";
            this.richBoxResult.Size = new System.Drawing.Size(473, 352);
            this.richBoxResult.TabIndex = 3;
            this.richBoxResult.Text = "";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(65, 23);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(131, 21);
            this.txtBoxName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名:";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(215, 21);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(54, 23);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "校验";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // tabPageInterface
            // 
            this.tabPageInterface.Controls.Add(this.panelParameter);
            this.tabPageInterface.Location = new System.Drawing.Point(4, 22);
            this.tabPageInterface.Name = "tabPageInterface";
            this.tabPageInterface.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInterface.Size = new System.Drawing.Size(683, 412);
            this.tabPageInterface.TabIndex = 1;
            this.tabPageInterface.Text = "湖南创智接口访问";
            this.tabPageInterface.UseVisualStyleBackColor = true;
            // 
            // panelParameter
            // 
            this.panelParameter.Controls.Add(this.flowLayoutPanel1);
            this.panelParameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelParameter.Location = new System.Drawing.Point(3, 3);
            this.panelParameter.Name = "panelParameter";
            this.panelParameter.Size = new System.Drawing.Size(677, 100);
            this.panelParameter.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxServer);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxPort);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxServlet);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(677, 83);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "服务器地址：";
            // 
            // txtBoxServer
            // 
            this.txtBoxServer.Location = new System.Drawing.Point(80, 3);
            this.txtBoxServer.Name = "txtBoxServer";
            this.txtBoxServer.Size = new System.Drawing.Size(97, 21);
            this.txtBoxServer.TabIndex = 1;
            this.txtBoxServer.Text = "192.168.1.254";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口号：";
            // 
            // txtBoxPort
            // 
            this.txtBoxPort.Location = new System.Drawing.Point(241, 3);
            this.txtBoxPort.Name = "txtBoxPort";
            this.txtBoxPort.Size = new System.Drawing.Size(44, 21);
            this.txtBoxPort.TabIndex = 3;
            this.txtBoxPort.Text = "7001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 7, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "入口Servlet名称：";
            // 
            // txtBoxServlet
            // 
            this.txtBoxServlet.Location = new System.Drawing.Point(403, 3);
            this.txtBoxServlet.Name = "txtBoxServlet";
            this.txtBoxServlet.Size = new System.Drawing.Size(100, 21);
            this.txtBoxServlet.TabIndex = 5;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 438);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用湖南创智医保接口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPageIDCard.ResumeLayout(false);
            this.tabPageIDCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerson)).EndInit();
            this.tabPageInterface.ResumeLayout(false);
            this.panelParameter.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageIDCard;
        private System.Windows.Forms.RichTextBox richBoxResult;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TabPage tabPageInterface;
        private System.Windows.Forms.PictureBox pictureBoxPerson;
        private System.Windows.Forms.Panel panelParameter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxServlet;
    }
}

