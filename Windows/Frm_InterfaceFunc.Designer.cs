namespace Windows
{
    partial class Frm_InterfaceFunc
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.chBoxFuzzy = new System.Windows.Forms.CheckBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnToClass = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.c1FlexGridPara = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStripPara = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddPara = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddParaDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemDelPara = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.c1FlexGridDataset = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStripDataset = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddDataset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxReturnValue = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richTxtBoxDetails = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNameID = new System.Windows.Forms.Label();
            this.c1FlexGridFunc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnParameterToClass = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPara)).BeginInit();
            this.contextMenuStripPara.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDataset)).BeginInit();
            this.contextMenuStripDataset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridFunc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1116, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxID);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxName);
            this.flowLayoutPanel1.Controls.Add(this.chBoxFuzzy);
            this.flowLayoutPanel1.Controls.Add(this.btnQuery);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1110, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "编码：";
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(52, 3);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(152, 21);
            this.txtBoxID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称：";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(259, 3);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(174, 21);
            this.txtBoxName.TabIndex = 3;
            // 
            // chBoxFuzzy
            // 
            this.chBoxFuzzy.AutoSize = true;
            this.chBoxFuzzy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chBoxFuzzy.ForeColor = System.Drawing.Color.Red;
            this.chBoxFuzzy.Location = new System.Drawing.Point(439, 8);
            this.chBoxFuzzy.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.chBoxFuzzy.Name = "chBoxFuzzy";
            this.chBoxFuzzy.Size = new System.Drawing.Size(76, 16);
            this.chBoxFuzzy.TabIndex = 5;
            this.chBoxFuzzy.Text = "模糊查询";
            this.chBoxFuzzy.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Location = new System.Drawing.Point(521, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(42, 23);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "检索";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(569, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.c1FlexGridFunc);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1116, 642);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnParameterToClass);
            this.groupBox3.Controls.Add(this.btnToClass);
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Controls.Add(this.richTextBoxReturnValue);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.richTxtBoxDetails);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblID);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lblNameID);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(408, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(705, 622);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接口功能编码详细信息";
            // 
            // btnToClass
            // 
            this.btnToClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToClass.Image = global::Windows.ResImage.accept;
            this.btnToClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToClass.Location = new System.Drawing.Point(368, 20);
            this.btnToClass.Name = "btnToClass";
            this.btnToClass.Size = new System.Drawing.Size(145, 23);
            this.btnToClass.TabIndex = 13;
            this.btnToClass.Text = "   生成数据集对应的类";
            this.btnToClass.UseVisualStyleBackColor = true;
            this.btnToClass.Click += new System.EventHandler(this.btnToClass_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 248);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 374);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.c1FlexGridPara);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(688, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "入参定义";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // c1FlexGridPara
            // 
            this.c1FlexGridPara.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            this.c1FlexGridPara.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.c1FlexGridPara.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridPara.ContextMenuStrip = this.contextMenuStripPara;
            this.c1FlexGridPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridPara.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.c1FlexGridPara.Location = new System.Drawing.Point(3, 3);
            this.c1FlexGridPara.Name = "c1FlexGridPara";
            this.c1FlexGridPara.Rows.DefaultSize = 20;
            this.c1FlexGridPara.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.c1FlexGridPara.Size = new System.Drawing.Size(682, 342);
            this.c1FlexGridPara.TabIndex = 9;
            this.c1FlexGridPara.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.c1FlexGridPara_AfterSelChange);
            this.c1FlexGridPara.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(this.c1FlexGridPara_OwnerDrawCell);
            this.c1FlexGridPara.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGridPara_AfterEdit);
            // 
            // contextMenuStripPara
            // 
            this.contextMenuStripPara.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddPara,
            this.toolStripMenuItemAddParaDesc,
            this.toolStripSeparator1,
            this.ToolStripMenuItemDelPara});
            this.contextMenuStripPara.Name = "contextMenuStripPara";
            this.contextMenuStripPara.Size = new System.Drawing.Size(181, 76);
            // 
            // ToolStripMenuItemAddPara
            // 
            this.ToolStripMenuItemAddPara.Name = "ToolStripMenuItemAddPara";
            this.ToolStripMenuItemAddPara.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemAddPara.Text = "添加入参";
            this.ToolStripMenuItemAddPara.Click += new System.EventHandler(this.ToolStripMenuItemAddPara_Click);
            // 
            // toolStripMenuItemAddParaDesc
            // 
            this.toolStripMenuItemAddParaDesc.Name = "toolStripMenuItemAddParaDesc";
            this.toolStripMenuItemAddParaDesc.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemAddParaDesc.Text = "添加入参(参数说明)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // ToolStripMenuItemDelPara
            // 
            this.ToolStripMenuItemDelPara.Name = "ToolStripMenuItemDelPara";
            this.ToolStripMenuItemDelPara.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItemDelPara.Text = "删除入参";
            this.ToolStripMenuItemDelPara.Click += new System.EventHandler(this.ToolStripMenuItemDelPara_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.c1FlexGridDataset);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(688, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "返回数据集名称及其内容";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // c1FlexGridDataset
            // 
            this.c1FlexGridDataset.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.c1FlexGridDataset.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridDataset.ContextMenuStrip = this.contextMenuStripDataset;
            this.c1FlexGridDataset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGridDataset.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.c1FlexGridDataset.Location = new System.Drawing.Point(3, 3);
            this.c1FlexGridDataset.Name = "c1FlexGridDataset";
            this.c1FlexGridDataset.Rows.DefaultSize = 20;
            this.c1FlexGridDataset.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.c1FlexGridDataset.Size = new System.Drawing.Size(682, 342);
            this.c1FlexGridDataset.TabIndex = 11;
            this.c1FlexGridDataset.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.c1FlexGridDataset_AfterSelChange);
            this.c1FlexGridDataset.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(this.c1FlexGridDataset_OwnerDrawCell);
            this.c1FlexGridDataset.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGridDataset_AfterEdit);
            // 
            // contextMenuStripDataset
            // 
            this.contextMenuStripDataset.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAdd,
            this.toolStripMenuItemAddDataset,
            this.toolStripSeparator2,
            this.toolStripMenuItemDel});
            this.contextMenuStripDataset.Name = "contextMenuStripDataset";
            this.contextMenuStripDataset.Size = new System.Drawing.Size(193, 76);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItemAdd.Text = "添加出参字段";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripMenuItemAdd_Click);
            // 
            // toolStripMenuItemAddDataset
            // 
            this.toolStripMenuItemAddDataset.Name = "toolStripMenuItemAddDataset";
            this.toolStripMenuItemAddDataset.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItemAddDataset.Text = "添加出参字段(数据集)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // toolStripMenuItemDel
            // 
            this.toolStripMenuItemDel.Name = "toolStripMenuItemDel";
            this.toolStripMenuItemDel.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItemDel.Text = "删除出参字段";
            this.toolStripMenuItemDel.Click += new System.EventHandler(this.toolStripMenuItemDel_Click);
            // 
            // richTextBoxReturnValue
            // 
            this.richTextBoxReturnValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxReturnValue.Location = new System.Drawing.Point(9, 178);
            this.richTextBoxReturnValue.Name = "richTextBoxReturnValue";
            this.richTextBoxReturnValue.Size = new System.Drawing.Size(687, 64);
            this.richTextBoxReturnValue.TabIndex = 9;
            this.richTextBoxReturnValue.Text = "返回值≥0,执行成功,返回值为记录数；";
            this.richTextBoxReturnValue.Validated += new System.EventHandler(this.richTextBoxReturnValue_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "返回值说明：";
            // 
            // richTxtBoxDetails
            // 
            this.richTxtBoxDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTxtBoxDetails.Location = new System.Drawing.Point(94, 73);
            this.richTxtBoxDetails.Name = "richTxtBoxDetails";
            this.richTxtBoxDetails.Size = new System.Drawing.Size(602, 74);
            this.richTxtBoxDetails.TabIndex = 5;
            this.richTxtBoxDetails.Text = "根据查询条件，取医保中心针对本单位有多少条未读消息。";
            this.richTxtBoxDetails.Validated += new System.EventHandler(this.richTxtBoxDetails_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(9, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "功能描述：";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblID.ForeColor = System.Drawing.Color.Red;
            this.lblID.Location = new System.Drawing.Point(93, 49);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(98, 16);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "SYSC980003";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(9, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "功能编码：";
            // 
            // lblNameID
            // 
            this.lblNameID.AutoSize = true;
            this.lblNameID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNameID.ForeColor = System.Drawing.Color.Green;
            this.lblNameID.Location = new System.Drawing.Point(9, 22);
            this.lblNameID.Margin = new System.Windows.Forms.Padding(5, 5, 3, 0);
            this.lblNameID.Name = "lblNameID";
            this.lblNameID.Size = new System.Drawing.Size(353, 16);
            this.lblNameID.TabIndex = 1;
            this.lblNameID.Text = "取中心针对本单位消息记录数（SYSC980003）";
            // 
            // c1FlexGridFunc
            // 
            this.c1FlexGridFunc.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.c1FlexGridFunc.ColumnInfo = "10,1,0,0,0,100,Columns:";
            this.c1FlexGridFunc.Dock = System.Windows.Forms.DockStyle.Left;
            this.c1FlexGridFunc.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.c1FlexGridFunc.Location = new System.Drawing.Point(3, 17);
            this.c1FlexGridFunc.Name = "c1FlexGridFunc";
            this.c1FlexGridFunc.Rows.DefaultSize = 20;
            this.c1FlexGridFunc.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.c1FlexGridFunc.Size = new System.Drawing.Size(405, 622);
            this.c1FlexGridFunc.TabIndex = 1;
            this.c1FlexGridFunc.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(this.c1FlexGridFunc_OwnerDrawCell);
            this.c1FlexGridFunc.SelChange += new System.EventHandler(this.c1FlexGridFunc_SelChange);
            this.c1FlexGridFunc.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGridFunc_AfterEdit);
            // 
            // btnParameterToClass
            // 
            this.btnParameterToClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParameterToClass.Image = global::Windows.ResImage.anchor;
            this.btnParameterToClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParameterToClass.Location = new System.Drawing.Point(528, 21);
            this.btnParameterToClass.Name = "btnParameterToClass";
            this.btnParameterToClass.Size = new System.Drawing.Size(145, 23);
            this.btnParameterToClass.TabIndex = 14;
            this.btnParameterToClass.Text = "   生成参数对应的类";
            this.btnParameterToClass.UseVisualStyleBackColor = true;
            this.btnParameterToClass.Click += new System.EventHandler(this.btnParameterToClass_Click);
            // 
            // Frm_InterfaceFunc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 689);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_InterfaceFunc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "湖南创智接口编码维护";
            this.Load += new System.EventHandler(this.Frm_InterfaceFunc_Load);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridPara)).EndInit();
            this.contextMenuStripPara.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridDataset)).EndInit();
            this.contextMenuStripDataset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGridFunc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridFunc;
        private System.Windows.Forms.CheckBox chBoxFuzzy;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNameID;
        private System.Windows.Forms.RichTextBox richTxtBoxDetails;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblID;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridDataset;
        private System.Windows.Forms.RichTextBox richTextBoxReturnValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGridPara;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPara;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddPara;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelPara;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDataset;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddParaDesc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddDataset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnToClass;
        private System.Windows.Forms.Button btnParameterToClass;

    }
}