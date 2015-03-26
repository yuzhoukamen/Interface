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
        private int _paraSelectRowIndex = 0;
        private int _paraSelectColIndex = 0;

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

            int count = this.c1FlexGridFunc.Rows.Count;

            if (count > 0)
            {
                QueryInterfaceDetailInfo(this.c1FlexGridFunc.Rows[1]["ID"].ToString().Trim());
            }
        }

        /// <summary>
        /// 查询接口功能
        /// </summary>
        /// <param name="id">编码</param>
        /// <param name="name">名称</param>
        /// <param name="fuzzy">是否模糊查询</param>
        private void QueryInterfaceFunc(string funcID, string name, bool fuzzy)
        {
            try
            {
                this.c1FlexGridFunc.DataSource = InterfaceFunc.GetInstance().GetInterfaceFunc(funcID, name, fuzzy).Tables[0];

                this.c1FlexGridFunc.Cols[1].Visible = false;
                this.c1FlexGridFunc.Cols[2].Width = 100;
                this.c1FlexGridFunc.Cols[3].Width = 240;
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError(e.Message);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string funcID = this.txtBoxID.Text.Trim();
            string name = this.txtBoxName.Text.Trim();
            bool fuzzy = this.chBoxFuzzy.Checked;

            QueryInterfaceFunc(funcID, name, fuzzy);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                this.c1FlexGridPara.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;

                for (int i = this.c1FlexGridPara.Cols.Fixed; i <= this.c1FlexGridPara.Cols.Count - 1; i++)
                {
                    this.c1FlexGridPara.Cols[i].AllowMerging = true;
                }

                this.c1FlexGridPara.Cols["最大长度"].Width = 60;
                this.c1FlexGridPara.Cols["是否为空"].Width = 60;
                this.c1FlexGridPara.Cols["备注"].Width = 220;

                if (ds.Tables.Count > 3)
                {
                    this.c1FlexGridDataset.DataSource = ds.Tables[3];

                    this.c1FlexGridDataset.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;

                    for (int i = this.c1FlexGridDataset.Cols.Fixed; i <= this.c1FlexGridDataset.Cols.Count - 1; i++)
                    {
                        this.c1FlexGridDataset.Cols[i].AllowMerging = true;
                    }

                    this.c1FlexGridDataset.Cols["数据集"].Width = 60;
                    this.c1FlexGridDataset.Cols["最大长度"].Width = 60;
                    this.c1FlexGridDataset.Cols["备注"].Width = 320;
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
        private void c1FlexGridDataset_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
        {
            if (e.Row >= this.c1FlexGridDataset.Rows.Fixed)
            {
                // 添加行号
                this.c1FlexGridDataset.Rows[e.Row][0] = e.Row - this.c1FlexGridDataset.Rows.Fixed + 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridPara_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
        {
            if (e.Row >= this.c1FlexGridPara.Rows.Fixed)
            {
                // 添加行号
                this.c1FlexGridPara.Rows[e.Row][0] = e.Row - this.c1FlexGridPara.Rows.Fixed + 1;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Frm_InterfaceFuncAdd frm = new Frm_InterfaceFuncAdd();

            frm.ShowDialog();

            frm = null;

            this.btnQuery.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTxtBoxDetails_Validated(object sender, EventArgs e)
        {
            string id = this.lblID.Tag.ToString().Trim();

            string details = this.richTxtBoxDetails.Text.Trim();

            try
            {
                string SQLString = string.Format(@"update HIS_InterfaceHN.dbo.Func set Details=N'{0}' where ID = {1}", details, id);

                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError("修改功能描述失败，失败原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBoxReturnValue_Validated(object sender, EventArgs e)
        {
            string id = this.lblID.Tag.ToString().Trim();

            string returnValue = this.richTextBoxReturnValue.Text.Trim();

            string[] strArray = returnValue.Split('\n');
            string selectSQL = string.Empty;

            foreach (string str in strArray)
            {
                selectSQL += string.Format(@"select {0},N'{1}' union all ", id, str);
            }

            selectSQL = selectSQL.Substring(0, selectSQL.Length - @"union all ".Length);

            try
            {
                string SQLString = string.Format(@"DELETE  HIS_InterfaceHN.dbo.FuncReturnValue
                                                    WHERE   FuncID = {0};

                                                    INSERT  INTO HIS_InterfaceHN.dbo.FuncReturnValue
                                                            ( FuncID, ReturnValueDesc )
                                                            {1}", id, selectSQL);

                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError("修改返回值说明失败，失败原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemAddPara_Click(object sender, EventArgs e)
        {
            string id = this.lblID.Tag.ToString().Trim();
            string name = string.Empty;
            string details = string.Empty;

            string SQLString = String.Format(@"IF NOT EXISTS ( SELECT  *
                                                                FROM    HIS_InterfaceHN.dbo.FuncPara
                                                                WHERE   FuncID = {0} )
                                                    BEGIN
                                                        INSERT  INTO HIS_InterfaceHN.dbo.FuncPara
                                                                ( FuncID, Name, Details )
                                                        VALUES  ( N'{0}', -- FuncID - nvarchar(50)
                                                                  N'{1}', -- Name - nchar(20)
                                                                  N'{2}'  -- Details - nvarchar(512)
                                                                  )
                                                    END

                                                INSERT  INTO HIS_InterfaceHN.dbo.FuncParaList
                                                            ( ParaID
                                                            )
                                                            SELECT  ID
                                                            FROM    HIS_InterfaceHN.dbo.FuncPara
                                                            WHERE   FuncID = {0}", id, name, details);

            try
            {
                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                QueryInterfaceDetailInfo(id);
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError("添加参数发生错误，错误原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridPara_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            string id = this.lblID.Tag.ToString().Trim();

            int rowIndex = e.Row;
            int colIndex = e.Col;

            string SQLString = string.Format(@"UPDATE  A
                                                SET     Name = N'{6}'
                                                FROM    HIS_InterfaceHN.dbo.FuncPara A
                                                        INNER JOIN HIS_InterfaceHN.dbo.FuncParaList B ON B.ParaID = A.ID
                                                WHERE   B.ID = {5};

                                                UPDATE  [HIS_InterfaceHN].[dbo].[FuncParaList]
                                                SET     [Name] = N'{0}' --<Name, nchar(20),>
                                                        ,
                                                        [NameDesc] = N'{1}' --<NameDesc, nvarchar(50),>
                                                        ,
                                                        [MaxLength] = N'{2}'-- <MaxLength, int,>
                                                        ,
                                                        [IsNull] = N'{3}'--<IsNull, tinyint,>
                                                        ,
                                                        [Details] = N'{4}'--<Details, nvarchar(512),>
                                                WHERE   ID = {5}", this.c1FlexGridPara.Rows[rowIndex]["入参"].ToString().Trim(),
                                                                 this.c1FlexGridPara.Rows[rowIndex]["入参说明"].ToString().Trim(),
                                                                 this.c1FlexGridPara.Rows[rowIndex]["最大长度"].ToString().Trim(),
                                                                 this.c1FlexGridPara.Rows[rowIndex]["是否为空"].ToString().Trim(),
                                                                 this.c1FlexGridPara.Rows[rowIndex]["备注"].ToString().Trim(),
                                                                 this.c1FlexGridPara.Rows[rowIndex]["ID"].ToString().Trim(),
                                                                 this.c1FlexGridPara.Rows[rowIndex]["参数说明"].ToString().Trim());

            try
            {
                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                QueryInterfaceDetailInfo(id);
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(string.Format("修改编号{0}的参数失败，失败原因：{1}",
                    this.c1FlexGridPara.Rows[rowIndex]["ID"].ToString().Trim(), ee.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDelPara_Click(object sender, EventArgs e)
        {
            string id = this.lblID.Tag.ToString().Trim();

            if (this._paraSelectColIndex < 0 || this._paraSelectRowIndex < 0)
            {
                return;
            }

            string SQLString = "delete HIS_InterfaceHN.dbo.FuncParaList where ID = " + this.c1FlexGridPara.Rows[this._paraSelectRowIndex]["ID"].ToString().Trim();

            try
            {
                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                QueryInterfaceDetailInfo(id);
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(string.Format("删除编号为{0}的参数失败，失败原因：{1}", id, ee.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridPara_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            this._paraSelectRowIndex = this.c1FlexGridPara.MouseRow;
            this._paraSelectColIndex = this.c1FlexGridPara.MouseCol;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFunc_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            int rowIndex = e.Row;

            string id = this.c1FlexGridFunc.Rows[rowIndex]["ID"].ToString().Trim();

            string SQLString = string.Format(@"UPDATE  [HIS_InterfaceHN].[dbo].[Func]
                                                SET     [FuncID] = N'{0}'--<FuncID, nvarchar(50),>
                                                        ,
                                                        [Name] = N'{1}'--<Name, nvarchar(50),>
                                                        ,
                                                        [Details] = N'{2}'--<Details, nvarchar(512),>
                                                WHERE   ID = {3}",
                                                                 this.c1FlexGridFunc.Rows[rowIndex]["编码"].ToString().Trim(),
                                                                 this.c1FlexGridFunc.Rows[rowIndex]["名称"].ToString().Trim(),
                                                                 string.Empty,
                                                                 id);
            try
            {
                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError("修改接口函数信息失败，失败原因：" + ee.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemDel_Click(object sender, EventArgs e)
        {

        }
    }
}