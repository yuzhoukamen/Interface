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
    public partial class Frm_JCType : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        public Frm_JCType()
        {
            InitializeComponent();
        }

        private void Frm_JCType_Load(object sender, EventArgs e)
        {
            SetC1FlexGridAttribute(this.c1FlexGridType, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridType, C1.Win.C1FlexGrid.SelectionModeEnum.Row);

            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridType);

            QueryJCType();

            BindEvents();

            SetApplicationIco(this);
        }

        private void BindEvents()
        {
            this.c1FlexGridType.SelChange += new EventHandler(delegate(object sender, EventArgs e)
            {
                int rowIndex = this.c1FlexGridType.MouseRow;

                if (rowIndex < 0)
                {
                    return;
                }

                string id = this.c1FlexGridType.Rows[rowIndex]["ID"].ToString().Trim();

                QueryCompareTable(id);
            });
        }

        /// <summary>
        /// 查询对照表
        /// </summary>
        /// <param name="id">类型编号</param>
        private void QueryCompareTable(string id)
        {
            try
            {
                string SQLString = string.Format(@"SELECT  HIS_InterfaceHN.dbo.JC_Type.Name AS 对照类型 ,
                                                            HIS_InterfaceHN.dbo.JC_TypeCompareTable.Name AS 数值 ,
                                                            HIS_InterfaceHN.dbo.JC_TypeCompareTable.Value AS 说明 ,
                                                            HIS_InterfaceHN.dbo.JC_TypeCompareTable.Length AS 长度 ,
                                                            HIS_InterfaceHN.dbo.JC_TypeCompareTable.Details AS 备注
                                                    FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                                            INNER JOIN HIS_InterfaceHN.dbo.JC_Type ON HIS_InterfaceHN.dbo.JC_Type.ID = HIS_InterfaceHN.dbo.JC_TypeCompareTable.TypeID
                                                    WHERE   HIS_InterfaceHN.dbo.JC_Type.ID = {0}", id);

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                this.c1FlexGridCompareTable.DataSource = ds.Tables[0];

                this.c1FlexGridCompareTable.Cols["长度"].Width = 70;
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError("查询对照表信息失败，失败原因：" + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryJCType()
        {
            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(string.Format(@"SELECT  [ID] ,
                                                                                    [Name] ,
                                                                                    [TableID] ,
                                                                                    [Details]
                                                                            FROM    [HIS_InterfaceHN].[dbo].[JC_Type]
                                                                            ORDER BY ID"));

                this.c1FlexGridType.DataSource = ds.Tables[0];

                this.c1FlexGridType.Cols["ID"].Visible = false;
                this.c1FlexGridType.Cols["Name"].Caption = "对照类别";
                this.c1FlexGridType.Cols["TableID"].Visible = false;
                this.c1FlexGridType.Cols["Details"].Caption = "说明";
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError("查询基础对照类型发生错误，错误原因：" + e.Message);
            }
        }
    }
}
