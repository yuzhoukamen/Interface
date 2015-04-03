﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceClass;

namespace Windows
{
    public partial class Frm_FuncTest : BaseForm
    {
        private DataTable interfacHNDataset = new DataTable();

        public Frm_FuncTest()
        {
            InitializeComponent();


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_FuncTest_Load(object sender, EventArgs e)
        {
            QueryFunc(string.Empty);

            SetC1FlexGridAttribute(this.c1FlexGridFunc, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridFunc, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridFunc);

            SetC1FlexGridSelectionMode(this.c1FlexGridPara, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridPara);

            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridDataset);
            SetC1FlexGridNullDataTable(this.c1FlexGridDataset);

            InitBind();
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryFunc(string id)
        {
            try
            {
                DataSet ds = InterfaceClass.Func.Func.Functions(id);

                this.c1FlexGridFunc.DataSource = ds.Tables[0];

                this.c1FlexGridFunc.Cols["ID"].Visible = false;
                this.c1FlexGridFunc.Cols["FuncID"].Caption = "编码";
                this.c1FlexGridFunc.Cols["Name"].Caption = "名称";

                this.c1FlexGridFunc.Cols["Name"].Width = 210;
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError(e.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string id = this.txtBoxID.Text.Trim();

            QueryFunc(id);
        }

        private void InitBind()
        {
            this.c1FlexGridFunc.SelChange += new EventHandler(delegate(object sender, EventArgs e)
            {
                int rowIndex = this.c1FlexGridFunc.MouseRow;

                if (rowIndex < 0)
                {
                    return;
                }

                string id = this.c1FlexGridFunc.Rows[rowIndex]["ID"].ToString().Trim();

                QueryFuncDetail(id);
            });
        }

        private void QueryFuncDetail(string id)
        {
            try
            {
                DataSet ds = InterfaceFunc.GetInstance().GetInterfaceFuncDetails(id);

                this.lblNameID.Text = string.Format("{0}({1})", ds.Tables[0].Rows[0]["Name"].ToString().Trim(), ds.Tables[0].Rows[0]["FuncID"].ToString().Trim());
                this.lblID.Tag = ds.Tables[0].Rows[0]["ID"].ToString().Trim();
                this.lblID.Text = ds.Tables[0].Rows[0]["FuncID"].ToString().Trim();
                this.richTxtBoxDetails.Text = ds.Tables[0].Rows[0]["Details"].ToString().Trim();

                this.richTextBoxReturnValue.Clear();

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    this.richTextBoxReturnValue.AppendText(dr["返回值说明"].ToString().Trim() + "\n");
                }

                this.c1FlexGridPara.DataSource = ds.Tables[2];

                this.c1FlexGridPara.Cols["ID"].Visible = false;
                this.c1FlexGridPara.Cols["参数说明"].Visible = false;
                this.c1FlexGridPara.Cols["最大长度"].Visible = false;
                this.c1FlexGridPara.Cols["是否为空"].Visible = false;
                this.c1FlexGridPara.Cols["备注"].Visible = false;

                this.interfacHNDataset.Clear();
                this.cBoxDataset.DataSource = null;
                this.c1FlexGridDataset.DataSource = null;

                if (ds.Tables.Count > 3)
                {
                    if (this.interfacHNDataset.Rows.Count > 0)
                    {
                        this.interfacHNDataset.Clear();
                    }
                    this.interfacHNDataset = ds.Tables[3];
                }

                if (ds.Tables.Count > 4)
                {
                    this.cBoxDataset.DataSource = ds.Tables[4];

                    this.cBoxDataset.DisplayMember = "Name";
                    this.cBoxDataset.ValueMember = "Name";
                }
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExec_Click(object sender, EventArgs e)
        {
            try
            {
                SetC1FlexGridNullDataTable(this.c1FlexGridDataset);

                InterfaceClass.Interface inter = new InterfaceClass.Interface(baseInterfaceHN);

                List<Parameter> listPara = new List<Parameter>();

                foreach (C1.Win.C1FlexGrid.Row row in this.c1FlexGridPara.Rows)
                {
                    if (row.Index > 0)
                    {
                        listPara.Add(new Parameter(row["入参"].ToString().Trim(), row["默认值"].ToString().Trim()));
                    }
                }

                long value = inter.ExecInterface(this.lblID.Text.Trim(), listPara);

                this.lblReturnValue.Text = string.Format(@"返回值：{0}", value.ToString());

                inter.SetResultset(this.cBoxDataset.Text.Trim());

                DataTable dt = new DataTable();

                string p_name = string.Empty;
                string p_value = string.Empty;

                foreach (DataRow dr in this.interfacHNDataset.Rows)
                {
                    DataColumn dc = new DataColumn();

                    dc.ColumnName = dr["字段"].ToString().Trim();
                    dc.Caption = dr["字段说明"].ToString().Trim();

                    dt.Columns.Add(dc);
                }

                string str = string.Empty;
                int temp = 0;

                do
                {
                    DataRow dataRow = dt.NewRow();

                    foreach (DataColumn dc in dt.Columns)
                    {
                        temp++;

                        str = string.Empty;

                        inter.GetByName(dc.ColumnName, ref str);
                        dataRow[dc.ColumnName] = str;
                    }
                    dt.Rows.Add(dataRow);
                } while (0 < inter.NextRow());

                this.c1FlexGridDataset.DataSource = dt;
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel文件|*.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DisplayTips("正在导出数据集......");

                    string fileName = sfd.FileName;

                    if (!fileName.EndsWith(".xls"))
                    {
                        fileName += ".xls";
                    }

                    this.c1FlexGridDataset.SaveExcel(fileName);

                    CloseTips();

                    CommonFunctions.MsgInfo("文件" + fileName + "保存成功！！！");
                }
                catch (Exception ex)
                {
                    CloseTips();
                    CommonFunctions.MsgError("导出数据集失败，失败原因：" + ex.Message);
                }
            }
        }
    }
}
