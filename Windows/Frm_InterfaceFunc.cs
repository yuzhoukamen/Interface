using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows
{
    public partial class Frm_InterfaceFunc : Form
    {
        public Frm_InterfaceFunc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_InterfaceFunc_Load(object sender, EventArgs e)
        {
            /*
            this.Top = 0;
            this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            */

            QueryInterfaceFunc(string.Empty, string.Empty, true);
        }

        /// <summary>
        /// 查询接口功能
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="name">名称</param>
        /// <param name="fuzzy">是否模糊查询</param>
        private void QueryInterfaceFunc(string id, string name, bool fuzzy)
        {
            try
            {
                this.c1FlexGridFunc.DataSource = InterfaceFunc.GetInstance().GetInterfaceFunc(id, name, fuzzy).Tables[0];

                this.c1FlexGridFunc.Cols[1].Width = 100;
                this.c1FlexGridFunc.Cols[2].Width = 240;
            }
            catch (Exception e)
            {
                MsgError(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void MsgError(string msg)
        {
            MessageBox.Show(msg.Trim(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void MsgInfo(string msg)
        {
            MessageBox.Show(msg.Trim(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string id = this.txtBoxID.Text.Trim();
            string name = this.txtBoxName.Text.Trim();
            bool fuzzy = this.chBoxFuzzy.Checked;

            QueryInterfaceFunc(id, name, fuzzy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFunc_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
        {
            if (e.Row >= this.c1FlexGridFunc.Rows.Fixed)
            {
                // 添加行号
                this.c1FlexGridFunc.Rows[e.Row][0] = e.Row - this.c1FlexGridFunc.Rows.Fixed + 1;
            }
        }

        private void c1FlexGridFunc_SelChange(object sender, EventArgs e)
        {
            int rowIndex = this.c1FlexGridFunc.MouseRow;

            if (rowIndex < 0)
            {
                return;
            }

            string id = this.c1FlexGridFunc.Rows[rowIndex][1].ToString().Trim();

            QueryInterfaceDetailInfo(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void QueryInterfaceDetailInfo(string id)
        {
            try
            {
                DataSet ds = InterfaceFunc.GetInstance().GetInterfaceFuncDetails(id);

                this.lblNameID.Text = string.Format("{0}({1})", ds.Tables[0].Rows[0]["Name"].ToString().Trim(), ds.Tables[0].Rows[0]["ID"].ToString().Trim());
                this.lblID.Text = ds.Tables[0].Rows[0]["ID"].ToString().Trim();
                this.richTxtBoxDetails.Text = ds.Tables[0].Rows[0]["Details"].ToString().Trim();

                this.richTextBoxReturnValue.Clear();

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    this.richTextBoxReturnValue.AppendText(dr["返回值说明"].ToString().Trim() + "\n");
                }

                this.c1FlexGridPara.DataSource = ds.Tables[2];

                for (int i = 0; i < this.c1FlexGridPara.Rows.Count; i++)
                {
                    this.c1FlexGridPara.Rows[i].AllowMerging = true;
                }

                this.c1FlexGridPara.Cols["最大长度"].Width = 60;
                this.c1FlexGridPara.Cols["是否为空"].Width = 60;
                this.c1FlexGridPara.Cols["备注"].Width = 220;

                if (ds.Tables.Count > 3)
                {
                    this.c1FlexGridDataset.DataSource = ds.Tables[3];

                    this.c1FlexGridDataset.Cols["数据集"].Width = 60;
                    this.c1FlexGridDataset.Cols["最大长度"].Width = 60;
                    this.c1FlexGridDataset.Cols["备注"].Width = 320;
                }
            }
            catch (Exception e)
            {
                MsgError(e.Message);
            }
        }

        private void c1FlexGridDataset_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
        {
            if (e.Row >= this.c1FlexGridDataset.Rows.Fixed)
            {
                // 添加行号
                this.c1FlexGridDataset.Rows[e.Row][0] = e.Row - this.c1FlexGridDataset.Rows.Fixed + 1;
            }
        }

        private void c1FlexGridPara_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
        {
            if (e.Row >= this.c1FlexGridPara.Rows.Fixed)
            {
                // 添加行号
                this.c1FlexGridPara.Rows[e.Row][0] = e.Row - this.c1FlexGridPara.Rows.Fixed + 1;
            }
        }
    }
}