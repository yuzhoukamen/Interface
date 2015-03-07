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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.richBoxResult = new System.Windows.Forms.RichTextBox();
            this.pictureBoxPerson = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPageIDCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageIDCard);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(683, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名:";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(65, 23);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(131, 21);
            this.txtBoxName.TabIndex = 2;
            // 
            // richBoxResult
            // 
            this.richBoxResult.Location = new System.Drawing.Point(26, 54);
            this.richBoxResult.Name = "richBoxResult";
            this.richBoxResult.Size = new System.Drawing.Size(473, 352);
            this.richBoxResult.TabIndex = 3;
            this.richBoxResult.Text = "";
            // 
            // pictureBoxPerson
            // 
            this.pictureBoxPerson.Location = new System.Drawing.Point(505, 54);
            this.pictureBoxPerson.Name = "pictureBoxPerson";
            this.pictureBoxPerson.Size = new System.Drawing.Size(172, 165);
            this.pictureBoxPerson.TabIndex = 4;
            this.pictureBoxPerson.TabStop = false;
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
            this.tabControl1.ResumeLayout(false);
            this.tabPageIDCard.ResumeLayout(false);
            this.tabPageIDCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageIDCard;
        private System.Windows.Forms.RichTextBox richBoxResult;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBoxPerson;
    }
}

