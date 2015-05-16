﻿namespace Windows
{
    partial class Frm_FuncTest
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
            this.cBoxDataset = new System.Windows.Forms.ComboBox();
            this.lblReturnValue = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExec = new System.Windows.Forms.Button();
            this.c1FlexGridDataset = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.c1FlexGridPara = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnQuery = new System.Windows.Forms.Button();
            this.richTextBoxReturnValue = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richTxtBoxDetails = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNameID = new System.Windows.Forms.Label();
            this.c1FlexGridFunc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridFunc)).BeginInit();
            this.SuspendLayout();
            // 
            // cBoxDataset
            // 
            this.cBoxDataset.FormattingEnabled = true;
            this.cBoxDataset.Location = new System.Drawing.Point(476, 242);
            this.cBoxDataset.Name = "cBoxDataset";
            this.cBoxDataset.Size = new System.Drawing.Size(137, 20);
            this.cBoxDataset.TabIndex = 27;
            // 
            // lblReturnValue
            // 
            this.lblReturnValue.AutoSize = true;
            this.lblReturnValue.ForeColor = System.Drawing.Color.Red;
            this.lblReturnValue.Location = new System.Drawing.Point(820, 245);
            this.lblReturnValue.Name = "lblReturnValue";
            this.lblReturnValue.Size = new System.Drawing.Size(59, 12);
            this.lblReturnValue.TabIndex = 26;
            this.lblReturnValue.Text = "返回值：0";
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(50, 10);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(174, 21);
            this.txtBoxID.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "编码：";
            // 
            // btnExec
            // 
            this.btnExec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExec.Location = new System.Drawing.Point(681, 242);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 23;
            this.btnExec.Text = "执行";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // c1FlexGridDataset
            // 
            this.c1FlexGridDataset.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            this.c1FlexGridDataset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c1FlexGridDataset.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.c1FlexGridDataset.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridDataset.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.c1FlexGridDataset.Location = new System.Drawing.Point(476, 266);
            this.c1FlexGridDataset.Name = "c1FlexGridDataset";
            this.c1FlexGridDataset.Rows.DefaultSize = 20;
            this.c1FlexGridDataset.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.c1FlexGridDataset.Size = new System.Drawing.Size(644, 396);
            this.c1FlexGridDataset.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "数据集：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "入参：";
            // 
            // c1FlexGridPara
            // 
            this.c1FlexGridPara.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            this.c1FlexGridPara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.c1FlexGridPara.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.c1FlexGridPara.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridPara.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.c1FlexGridPara.Location = new System.Drawing.Point(12, 391);
            this.c1FlexGridPara.Name = "c1FlexGridPara";
            this.c1FlexGridPara.Rows.DefaultSize = 20;
            this.c1FlexGridPara.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.c1FlexGridPara.Size = new System.Drawing.Size(458, 271);
            this.c1FlexGridPara.TabIndex = 18;
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Location = new System.Drawing.Point(279, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 17;
            this.btnQuery.Text = "重新加载";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // richTextBoxReturnValue
            // 
            this.richTextBoxReturnValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxReturnValue.Location = new System.Drawing.Point(421, 172);
            this.richTextBoxReturnValue.Name = "richTextBoxReturnValue";
            this.richTextBoxReturnValue.Size = new System.Drawing.Size(687, 64);
            this.richTextBoxReturnValue.TabIndex = 16;
            this.richTextBoxReturnValue.Text = "返回值≥0,执行成功,返回值为记录数；";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(418, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "返回值说明：";
            // 
            // richTxtBoxDetails
            // 
            this.richTxtBoxDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTxtBoxDetails.Location = new System.Drawing.Point(506, 97);
            this.richTxtBoxDetails.Name = "richTxtBoxDetails";
            this.richTxtBoxDetails.Size = new System.Drawing.Size(602, 53);
            this.richTxtBoxDetails.TabIndex = 14;
            this.richTxtBoxDetails.Text = "根据查询条件，取医保中心针对本单位有多少条未读消息。";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(421, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "功能描述：";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblID.ForeColor = System.Drawing.Color.Red;
            this.lblID.Location = new System.Drawing.Point(505, 73);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(98, 16);
            this.lblID.TabIndex = 12;
            this.lblID.Text = "SYSC980003";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(421, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "功能编码：";
            // 
            // lblNameID
            // 
            this.lblNameID.AutoSize = true;
            this.lblNameID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNameID.ForeColor = System.Drawing.Color.Green;
            this.lblNameID.Location = new System.Drawing.Point(421, 46);
            this.lblNameID.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblNameID.Name = "lblNameID";
            this.lblNameID.Size = new System.Drawing.Size(353, 16);
            this.lblNameID.TabIndex = 10;
            this.lblNameID.Text = "取中心针对本单位消息记录数（SYSC980003）";
            // 
            // c1FlexGridFunc
            // 
            this.c1FlexGridFunc.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridFunc.Location = new System.Drawing.Point(-6, 46);
            this.c1FlexGridFunc.Name = "c1FlexGridFunc";
            this.c1FlexGridFunc.Rows.DefaultSize = 20;
            this.c1FlexGridFunc.Size = new System.Drawing.Size(419, 318);
            this.c1FlexGridFunc.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(923, 242);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 28;
            this.btnExcel.Text = "导出";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // Frm_FuncTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 662);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.cBoxDataset);
            this.Controls.Add(this.lblReturnValue);
            this.Controls.Add(this.txtBoxID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.c1FlexGridDataset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c1FlexGridPara);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.richTextBoxReturnValue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.richTxtBoxDetails);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblNameID);
            this.Controls.Add(this.c1FlexGridFunc);
            this.Name = "Frm_FuncTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "功能编码测试";
            this.Load += new System.EventHandler(this.Frm_FuncTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridFunc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridFunc;
        private System.Windows.Forms.RichTextBox richTextBoxReturnValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTxtBoxDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNameID;
        private System.Windows.Forms.Button btnQuery;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridPara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridDataset;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Label lblReturnValue;
        private System.Windows.Forms.ComboBox cBoxDataset;
        private System.Windows.Forms.Button btnExcel;
    }
}