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
    public partial class Frm_InterfaceFunc : BaseForm
    {
        private int _paraSelectRowIndex = 0;
        private int _paraSelectColIndex = 0;
        private int _datasetSelectRowIndex = 0;
        private int _datasetSelectColIndex = 0;

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

            SetApplicationIco(this);
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

                    this.c1FlexGridDataset.Cols["ID"].Visible = false;
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
                                                        [DefaultValue] = N'{7}'--<DefaultValue, nvarchar(512),>
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
                                                                 this.c1FlexGridPara.Rows[rowIndex]["参数说明"].ToString().Trim(),
                                                                 this.c1FlexGridPara.Rows[rowIndex]["默认值"].ToString().Trim());

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
            if (this._paraSelectColIndex < 0 || this._paraSelectRowIndex < 0)
            {
                return;
            }

            string FuncID = this.lblID.Tag.ToString().Trim();
            string paraID = this.c1FlexGridPara.Rows[this._paraSelectRowIndex]["ID"].ToString().Trim();

            string SQLString = "delete HIS_InterfaceHN.dbo.FuncParaList where ID = " + paraID;

            try
            {
                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                QueryInterfaceDetailInfo(FuncID);
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(string.Format("删除编号为{0}的参数失败，失败原因：{1}", paraID, ee.Message));
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
            string id = this.lblID.Tag.ToString().Trim();
            string name = string.Empty;
            string details = string.Empty;

            string SQLString = String.Format(@"IF NOT EXISTS ( SELECT  *
                                                                FROM    HIS_InterfaceHN.dbo.FuncDataset
                                                                WHERE   FuncID = {0} )
                                                    BEGIN
                                                        INSERT  INTO HIS_InterfaceHN.dbo.FuncDataset
                                                                ( FuncID, Name, Details )
                                                        VALUES  ( N'{0}', -- FuncID - nvarchar(50)
                                                                  N'{1}', -- Name - nchar(20)
                                                                  N'{2}'  -- Details - nvarchar(512)
                                                                  )
                                                    END

                                                INSERT  INTO HIS_InterfaceHN.dbo.FuncDatasetList
                                                            ( DatasetID
                                                            )
                                                            SELECT  ID
                                                            FROM    HIS_InterfaceHN.dbo.FuncDataset
                                                            WHERE   FuncID = {0}", id, name, details);

            try
            {
                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                QueryInterfaceDetailInfo(id);
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError("添加数据集字段发生错误，错误原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            if (this._datasetSelectRowIndex < 0 || this._datasetSelectColIndex < 0)
            {
                return;
            }

            string funcID = this.lblID.Tag.ToString().Trim();
            string datasetListID = this.c1FlexGridDataset.Rows[this._datasetSelectRowIndex]["ID"].ToString().Trim();

            string SQLString = "delete HIS_InterfaceHN.dbo.FuncDatasetList where ID = " + datasetListID;

            try
            {
                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                QueryInterfaceDetailInfo(funcID);
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(string.Format("删除编号为{0}的数据字段失败，失败原因：{1}", datasetListID, ee.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridDataset_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            string id = this.lblID.Tag.ToString().Trim();

            int rowIndex = e.Row;
            int colIndex = e.Col;

            string SQLString = string.Format(@"UPDATE  A
                                                SET     Name = N'{5}'
                                                FROM    HIS_InterfaceHN.dbo.FuncDataset A
                                                        INNER JOIN HIS_InterfaceHN.dbo.FuncDatasetList B ON B.DatasetID = A.ID
                                                WHERE   B.ID = {4};

                                                UPDATE  [HIS_InterfaceHN].[dbo].[FuncDatasetList]
                                                SET     [Name] = N'{0}' --<Name, nchar(20),>
                                                        ,
                                                        [NameDesc] = N'{1}' --<NameDesc, nvarchar(50),>
                                                        ,
                                                        [MaxLength] = N'{2}'-- <MaxLength, int,>
                                                        ,
                                                        [Details] = N'{3}'--<Details, nvarchar(512),>
                                                WHERE   ID = {4}", this.c1FlexGridDataset.Rows[rowIndex]["字段"].ToString().Trim(),
                                                                 this.c1FlexGridDataset.Rows[rowIndex]["字段说明"].ToString().Trim(),
                                                                 this.c1FlexGridDataset.Rows[rowIndex]["最大长度"].ToString().Trim(),
                                                                 this.c1FlexGridDataset.Rows[rowIndex]["备注"].ToString().Trim(),
                                                                 this.c1FlexGridDataset.Rows[rowIndex]["ID"].ToString().Trim(),
                                                                 this.c1FlexGridDataset.Rows[rowIndex]["数据集"].ToString().Trim());

            try
            {
                Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                QueryInterfaceDetailInfo(id);
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(string.Format("修改编号{0}的数据集字段失败，失败原因：{1}",
                    this.c1FlexGridPara.Rows[rowIndex]["ID"].ToString().Trim(), ee.Message));
            }
        }

        private void c1FlexGridDataset_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            this._datasetSelectRowIndex = this.c1FlexGridDataset.MouseRow;
            this._datasetSelectColIndex = this.c1FlexGridDataset.MouseCol;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToClass_Click(object sender, EventArgs e)
        {
            List<string> listDatasetName = new List<string>();

            string datasetName = string.Empty;

            if (!this.c1FlexGridDataset.Cols.Contains("数据集"))
            {
                CommonFunctions.MsgError("没有任何数据集，不能生成类！！！");
            }

            for (int i = 1; i < this.c1FlexGridDataset.Rows.Count; i++)
            {
                string temp = this.c1FlexGridDataset.Rows[i]["数据集"].ToString().Trim();

                if (temp != string.Empty && temp != datasetName)
                {
                    datasetName = temp;

                    listDatasetName.Add(datasetName);
                }
            }

            if (listDatasetName.Count <= 0)
            {
                CommonFunctions.MsgError("没有任何数据集，将不生成任何数据集对应的类！！！");
                return;
            }

            foreach (string dataset in listDatasetName)
            {
                StringBuilder sb = new StringBuilder();

                string tempDatasetName = dataset;

                tempDatasetName = dataset.Substring(0, 1).ToUpper() + dataset.Substring(1, dataset.Length - 1);

                sb.AppendLine("public class " + tempDatasetName);
                sb.AppendLine("{");
                sb.AppendLine("#region 属性");
                sb.AppendLine();

                for (int i = 1; i < this.c1FlexGridDataset.Rows.Count; i++)
                {
                    string temp = this.c1FlexGridDataset.Rows[i]["数据集"].ToString().Trim();

                    if (dataset == temp)
                    {

                        string des = this.c1FlexGridDataset.Rows[i]["字段说明"].ToString().Trim();
                        string name = this.c1FlexGridDataset.Rows[i]["字段"].ToString().Trim();

                        sb.AppendLine(string.Format("[Description(\"{0}\")]", des));
                        sb.AppendLine("public string " + name + " { get; set; }");
                        sb.AppendLine();
                    }
                }

                sb.AppendLine("#endregion");
                sb.AppendLine();

                sb.AppendLine("/// <summary>");
                sb.AppendLine("/// 设置属性值");
                sb.AppendLine("/// </summary>");
                sb.AppendLine("/// <param name=\"name\">名称</param>");
                sb.AppendLine("/// <param name=\"value\">值</param>");
                sb.AppendLine("public void SetAttributeValue(string name, string value)");
                sb.AppendLine("{");
                sb.AppendLine("switch (name)");
                sb.AppendLine("{");

                for (int i = 1; i < this.c1FlexGridDataset.Rows.Count; i++)
                {
                    string temp = this.c1FlexGridDataset.Rows[i]["数据集"].ToString().Trim();

                    if (dataset == temp)
                    {
                        string name = this.c1FlexGridDataset.Rows[i]["字段"].ToString().Trim();
                        string des = this.c1FlexGridDataset.Rows[i]["字段说明"].ToString().Trim();

                        sb.AppendLine(string.Format("case \"{0}\"://{1}", name, des));
                        sb.AppendLine(string.Format("this.{0} = value;", name));
                        sb.AppendLine("break;");
                    }
                }

                sb.AppendLine("default:");
                sb.AppendLine("break;");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("}");

                string filePath = Application.StartupPath + "\\ToClass";

                if (!System.IO.Directory.Exists(filePath))
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }

                filePath = System.IO.Path.Combine(filePath, tempDatasetName + ".cs");

                System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true);
                sw.WriteLine(sb.ToString());
                sw.Close();
                sw.Dispose();
            }

            CommonFunctions.MsgInfo("生成数据集对应的类成功，一共生成了" + listDatasetName.Count + "个文件！！！");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParameterToClass_Click(object sender, EventArgs e)
        {
            List<string> listParameterName = new List<string>();

            string datasetName = "入参";

            if (!this.c1FlexGridPara.Cols.Contains("参数说明"))
            {
                CommonFunctions.MsgError("没有任何入参，不能生成类！！！");
            }

            for (int i = 1; i < this.c1FlexGridPara.Rows.Count; i++)
            {
                string temp = this.c1FlexGridPara.Rows[i]["参数说明"].ToString().Trim();

                if (temp != datasetName)
                {
                    datasetName = temp;

                    listParameterName.Add(datasetName);
                }
            }

            if (listParameterName.Count <= 0)
            {
                CommonFunctions.MsgError("没有任何参数，将不生成任何参数对应的类！！！");
                return;
            }

            foreach (string dataset in listParameterName)
            {
                StringBuilder sb = new StringBuilder();

                string tempParameterName = dataset;

                tempParameterName = this.lblID.Text.Trim() + "_Parameter" + "_" + tempParameterName;

                sb.AppendLine("public class " + tempParameterName);
                sb.AppendLine("{");
                sb.AppendLine("#region 属性");
                sb.AppendLine();

                for (int i = 1; i < this.c1FlexGridPara.Rows.Count; i++)
                {
                    string temp = this.c1FlexGridPara.Rows[i]["参数说明"].ToString().Trim();

                    if (dataset == temp)
                    {
                        string des = this.c1FlexGridPara.Rows[i]["入参说明"].ToString().Trim();
                        string name = this.c1FlexGridPara.Rows[i]["入参"].ToString().Trim();

                        sb.AppendLine(string.Format("[Description(\"{0}\")]", des));
                        sb.AppendLine("public string " + name + " { get; set; }");
                        sb.AppendLine();
                    }
                }

                sb.AppendLine("#endregion");
                sb.AppendLine();

                sb.AppendLine("/// <summary>");
                sb.AppendLine("/// 设置属性值");
                sb.AppendLine("/// </summary>");
                sb.AppendLine("/// <param name=\"name\">名称</param>");
                sb.AppendLine("/// <param name=\"value\">值</param>");
                sb.AppendLine("public void SetAttributeValue(string name, string value)");
                sb.AppendLine("{");
                sb.AppendLine("switch (name)");
                sb.AppendLine("{");

                for (int i = 1; i < this.c1FlexGridPara.Rows.Count; i++)
                {
                    string temp = this.c1FlexGridPara.Rows[i]["参数说明"].ToString().Trim();

                    if (dataset == temp)
                    {
                        string name = this.c1FlexGridPara.Rows[i]["入参"].ToString().Trim();
                        string des = this.c1FlexGridPara.Rows[i]["入参说明"].ToString().Trim();

                        sb.AppendLine(string.Format("case \"{0}\"://{1}", name, des));
                        sb.AppendLine(string.Format("this.{0} = value;", name));
                        sb.AppendLine("break;");
                    }
                }

                sb.AppendLine("default:");
                sb.AppendLine("break;");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("}");

                string filePath = Application.StartupPath + "\\ToClass";

                if (!System.IO.Directory.Exists(filePath))
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }

                filePath = System.IO.Path.Combine(filePath, tempParameterName + ".cs");

                System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true);
                sw.WriteLine(sb.ToString());
                sw.Close();
                sw.Dispose();
            }

            CommonFunctions.MsgInfo("生成参数对应的类成功，一共生成了" + listParameterName.Count + "个文件！！！");
        }
    }
}