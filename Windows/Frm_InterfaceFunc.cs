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
            this.Top = 0;
            this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

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
    }
}