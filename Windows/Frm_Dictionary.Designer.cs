﻿namespace Windows
{
    partial class Frm_Dictionary
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMedical = new System.Windows.Forms.TabPage();
            this.c1FlexGridMedical = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pagerControlMedical = new Windows.Control.PagerControl();
            this.btnMedicalQuery = new System.Windows.Forms.Button();
            this.btnMedicalDown = new System.Windows.Forms.Button();
            this.tabPageProject = new System.Windows.Forms.TabPage();
            this.c1FlexGridProject = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pagerControlProject = new Windows.Control.PagerControl();
            this.btnProjectQuery = new System.Windows.Forms.Button();
            this.btnProjectDown = new System.Windows.Forms.Button();
            this.tabPageDisease = new System.Windows.Forms.TabPage();
            this.c1FlexGridDisease = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.pagerControlDisease = new Windows.Control.PagerControl();
            this.btnDiseaseQuery = new System.Windows.Forms.Button();
            this.btnDiseaseDown = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageMedical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridMedical)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPageProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridProject)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPageDisease.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDisease)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMedical);
            this.tabControl1.Controls.Add(this.tabPageProject);
            this.tabControl1.Controls.Add(this.tabPageDisease);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(973, 604);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageMedical
            // 
            this.tabPageMedical.Controls.Add(this.c1FlexGridMedical);
            this.tabPageMedical.Controls.Add(this.flowLayoutPanel1);
            this.tabPageMedical.Location = new System.Drawing.Point(4, 22);
            this.tabPageMedical.Name = "tabPageMedical";
            this.tabPageMedical.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMedical.Size = new System.Drawing.Size(965, 578);
            this.tabPageMedical.TabIndex = 0;
            this.tabPageMedical.Text = "中心药品目录";
            this.tabPageMedical.UseVisualStyleBackColor = true;
            // 
            // c1FlexGridMedical
            // 
            this.c1FlexGridMedical.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridMedical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridMedical.Location = new System.Drawing.Point(3, 3);
            this.c1FlexGridMedical.Name = "c1FlexGridMedical";
            this.c1FlexGridMedical.Rows.DefaultSize = 20;
            this.c1FlexGridMedical.Size = new System.Drawing.Size(959, 541);
            this.c1FlexGridMedical.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pagerControlMedical);
            this.flowLayoutPanel1.Controls.Add(this.btnMedicalQuery);
            this.flowLayoutPanel1.Controls.Add(this.btnMedicalDown);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 544);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(959, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pagerControlMedical
            // 
            this.pagerControlMedical.BackColor = System.Drawing.Color.Gainsboro;
            this.pagerControlMedical.JumpText = "Go";
            this.pagerControlMedical.Location = new System.Drawing.Point(3, 3);
            this.pagerControlMedical.Name = "pagerControlMedical";
            this.pagerControlMedical.PageIndex = 1;
            this.pagerControlMedical.PageSize = 100;
            this.pagerControlMedical.RecordCount = 0;
            this.pagerControlMedical.Size = new System.Drawing.Size(569, 30);
            this.pagerControlMedical.TabIndex = 2;
            this.pagerControlMedical.OnPageChanged += new System.EventHandler(this.pagerControlMedical_OnPageChanged);
            // 
            // btnMedicalQuery
            // 
            this.btnMedicalQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicalQuery.Image = global::Windows.ResImage.tick;
            this.btnMedicalQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedicalQuery.Location = new System.Drawing.Point(578, 3);
            this.btnMedicalQuery.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnMedicalQuery.Name = "btnMedicalQuery";
            this.btnMedicalQuery.Size = new System.Drawing.Size(81, 23);
            this.btnMedicalQuery.TabIndex = 0;
            this.btnMedicalQuery.Text = "   数据检索";
            this.btnMedicalQuery.UseVisualStyleBackColor = true;
            this.btnMedicalQuery.Click += new System.EventHandler(this.btnMedicalQuery_Click);
            // 
            // btnMedicalDown
            // 
            this.btnMedicalDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicalDown.Image = global::Windows.ResImage.arrow_down;
            this.btnMedicalDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedicalDown.Location = new System.Drawing.Point(670, 3);
            this.btnMedicalDown.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnMedicalDown.Name = "btnMedicalDown";
            this.btnMedicalDown.Size = new System.Drawing.Size(184, 23);
            this.btnMedicalDown.TabIndex = 1;
            this.btnMedicalDown.Text = "   下载数据并提交到HIS数据库";
            this.btnMedicalDown.UseVisualStyleBackColor = true;
            // 
            // tabPageProject
            // 
            this.tabPageProject.Controls.Add(this.c1FlexGridProject);
            this.tabPageProject.Controls.Add(this.flowLayoutPanel2);
            this.tabPageProject.Location = new System.Drawing.Point(4, 22);
            this.tabPageProject.Name = "tabPageProject";
            this.tabPageProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProject.Size = new System.Drawing.Size(965, 578);
            this.tabPageProject.TabIndex = 1;
            this.tabPageProject.Text = "中心项目目录";
            this.tabPageProject.UseVisualStyleBackColor = true;
            // 
            // c1FlexGridProject
            // 
            this.c1FlexGridProject.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridProject.Location = new System.Drawing.Point(3, 3);
            this.c1FlexGridProject.Name = "c1FlexGridProject";
            this.c1FlexGridProject.Rows.DefaultSize = 20;
            this.c1FlexGridProject.Size = new System.Drawing.Size(959, 541);
            this.c1FlexGridProject.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.pagerControlProject);
            this.flowLayoutPanel2.Controls.Add(this.btnProjectQuery);
            this.flowLayoutPanel2.Controls.Add(this.btnProjectDown);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 544);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(959, 31);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // pagerControlProject
            // 
            this.pagerControlProject.BackColor = System.Drawing.Color.Gainsboro;
            this.pagerControlProject.JumpText = "Go";
            this.pagerControlProject.Location = new System.Drawing.Point(3, 3);
            this.pagerControlProject.Name = "pagerControlProject";
            this.pagerControlProject.PageIndex = 1;
            this.pagerControlProject.PageSize = 100;
            this.pagerControlProject.RecordCount = 0;
            this.pagerControlProject.Size = new System.Drawing.Size(569, 30);
            this.pagerControlProject.TabIndex = 2;
            this.pagerControlProject.OnPageChanged += new System.EventHandler(this.pagerControlProject_OnPageChanged);
            // 
            // btnProjectQuery
            // 
            this.btnProjectQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectQuery.Image = global::Windows.ResImage.tick;
            this.btnProjectQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjectQuery.Location = new System.Drawing.Point(578, 3);
            this.btnProjectQuery.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnProjectQuery.Name = "btnProjectQuery";
            this.btnProjectQuery.Size = new System.Drawing.Size(81, 23);
            this.btnProjectQuery.TabIndex = 0;
            this.btnProjectQuery.Text = "   数据检索";
            this.btnProjectQuery.UseVisualStyleBackColor = true;
            this.btnProjectQuery.Click += new System.EventHandler(this.btnProjectQuery_Click);
            // 
            // btnProjectDown
            // 
            this.btnProjectDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectDown.Image = global::Windows.ResImage.arrow_down;
            this.btnProjectDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjectDown.Location = new System.Drawing.Point(670, 3);
            this.btnProjectDown.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnProjectDown.Name = "btnProjectDown";
            this.btnProjectDown.Size = new System.Drawing.Size(184, 23);
            this.btnProjectDown.TabIndex = 1;
            this.btnProjectDown.Text = "   下载数据并提交到HIS数据库";
            this.btnProjectDown.UseVisualStyleBackColor = true;
            // 
            // tabPageDisease
            // 
            this.tabPageDisease.Controls.Add(this.c1FlexGridDisease);
            this.tabPageDisease.Controls.Add(this.flowLayoutPanel3);
            this.tabPageDisease.Location = new System.Drawing.Point(4, 22);
            this.tabPageDisease.Name = "tabPageDisease";
            this.tabPageDisease.Size = new System.Drawing.Size(965, 578);
            this.tabPageDisease.TabIndex = 2;
            this.tabPageDisease.Text = "中心疾病目录";
            this.tabPageDisease.UseVisualStyleBackColor = true;
            // 
            // c1FlexGridDisease
            // 
            this.c1FlexGridDisease.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridDisease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridDisease.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGridDisease.Name = "c1FlexGridDisease";
            this.c1FlexGridDisease.Rows.DefaultSize = 20;
            this.c1FlexGridDisease.Size = new System.Drawing.Size(965, 547);
            this.c1FlexGridDisease.TabIndex = 3;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.pagerControlDisease);
            this.flowLayoutPanel3.Controls.Add(this.btnDiseaseQuery);
            this.flowLayoutPanel3.Controls.Add(this.btnDiseaseDown);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 547);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(965, 31);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // pagerControlDisease
            // 
            this.pagerControlDisease.BackColor = System.Drawing.Color.Gainsboro;
            this.pagerControlDisease.JumpText = "Go";
            this.pagerControlDisease.Location = new System.Drawing.Point(3, 3);
            this.pagerControlDisease.Name = "pagerControlDisease";
            this.pagerControlDisease.PageIndex = 1;
            this.pagerControlDisease.PageSize = 100;
            this.pagerControlDisease.RecordCount = 0;
            this.pagerControlDisease.Size = new System.Drawing.Size(569, 30);
            this.pagerControlDisease.TabIndex = 2;
            this.pagerControlDisease.OnPageChanged += new System.EventHandler(this.pagerControlDisease_OnPageChanged);
            // 
            // btnDiseaseQuery
            // 
            this.btnDiseaseQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiseaseQuery.Image = global::Windows.ResImage.tick;
            this.btnDiseaseQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiseaseQuery.Location = new System.Drawing.Point(578, 3);
            this.btnDiseaseQuery.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnDiseaseQuery.Name = "btnDiseaseQuery";
            this.btnDiseaseQuery.Size = new System.Drawing.Size(81, 23);
            this.btnDiseaseQuery.TabIndex = 0;
            this.btnDiseaseQuery.Text = "   数据检索";
            this.btnDiseaseQuery.UseVisualStyleBackColor = true;
            this.btnDiseaseQuery.Click += new System.EventHandler(this.btnDiseaseQuery_Click);
            // 
            // btnDiseaseDown
            // 
            this.btnDiseaseDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiseaseDown.Image = global::Windows.ResImage.arrow_down;
            this.btnDiseaseDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiseaseDown.Location = new System.Drawing.Point(670, 3);
            this.btnDiseaseDown.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnDiseaseDown.Name = "btnDiseaseDown";
            this.btnDiseaseDown.Size = new System.Drawing.Size(184, 23);
            this.btnDiseaseDown.TabIndex = 1;
            this.btnDiseaseDown.Text = "   下载数据并提交到HIS数据库";
            this.btnDiseaseDown.UseVisualStyleBackColor = true;
            // 
            // Frm_Dictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 604);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_Dictionary";
            this.Text = "接口字典维护";
            this.Load += new System.EventHandler(this.Frm_Dictionary_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageMedical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridMedical)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabPageProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridProject)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabPageDisease.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDisease)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMedical;
        private System.Windows.Forms.TabPage tabPageProject;
        private System.Windows.Forms.TabPage tabPageDisease;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridMedical;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMedicalQuery;
        private System.Windows.Forms.Button btnMedicalDown;
        private Control.PagerControl pagerControlMedical;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridProject;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Control.PagerControl pagerControlProject;
        private System.Windows.Forms.Button btnProjectQuery;
        private System.Windows.Forms.Button btnProjectDown;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridDisease;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Control.PagerControl pagerControlDisease;
        private System.Windows.Forms.Button btnDiseaseQuery;
        private System.Windows.Forms.Button btnDiseaseDown;
    }
}