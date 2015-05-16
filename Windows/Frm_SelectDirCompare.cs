using System;
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
    public partial class Frm_SelectDirCompare : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        private string _AddMatchID = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private string _medi_item_type = string.Empty;

        private int _selectedRowIndex = 0;

        public Parameter SelectValueParemeter = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public Frm_SelectDirCompare(string id, string medi_item_type)
        {
            InitializeComponent();

            this._AddMatchID = id;
            this._medi_item_type = medi_item_type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_SelectDirCompare_Load(object sender, EventArgs e)
        {
            SetC1FlexGridAttribute(this.c1FlexGridSelectDirCompare, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridSelectDirCompare, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridSelectDirCompare);
            SetC1FlexGridNullDataTable(this.c1FlexGridSelectDirCompare);

            QueryResult();
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryResult()
        {
            string SQLString = string.Empty;

            SQLString = string.Format(@"SELECT  center_id ,
                                                    hosp_code ,
                                                    ( SELECT    Value
                                                      FROM      HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                                      WHERE     TypeID = 4
                                                                AND Name = HIS_InterfaceHN.dbo.Interface_AddMatch.match_type
                                                    ) AS 'match_type' ,
                                                    hosp_code ,
                                                    hosp_name
                                            FROM    HIS_InterfaceHN.dbo.Interface_AddMatch
                                            WHERE   HIS_InterfaceHN.dbo.Interface_AddMatch.ID = {0};

                                            SELECT  HIS_InterfaceHN.dbo.JC_Interface_CenterDir.ID ,
                                                    HIS_InterfaceHN.dbo.JC_Interface_CenterDir.medi_item_type ,
                                                    HIS_InterfaceHN.dbo.JC_Interface_CenterDir.item_code ,
                                                    HIS_InterfaceHN.dbo.JC_Interface_CenterDir.item_name ,
                                                    HIS_InterfaceHN.dbo.JC_Interface_CenterDir.modelID ,
                                                    ( SELECT    Name
                                                      FROM      HIS_InterfaceHN.dbo.JC_Model
                                                      WHERE     Code = HIS_InterfaceHN.dbo.JC_Interface_CenterDir.modelID
                                                    ) AS 'model' ,
                                                    HIS_InterfaceHN.dbo.JC_Interface_CenterDir.price
                                            FROM    HIS_InterfaceHN.dbo.Interface_AddMatch
                                                    LEFT OUTER JOIN HIS_InterfaceHN.dbo.JC_Interface_CenterDir ON HIS_InterfaceHN.dbo.Interface_AddMatch.hosp_name = HIS_InterfaceHN.dbo.JC_Interface_CenterDir.item_name
                                            WHERE   ( HIS_InterfaceHN.dbo.Interface_AddMatch.ID = {0} )
                                            ORDER BY HIS_InterfaceHN.dbo.Interface_AddMatch.price;", this._AddMatchID);

            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                this.lblCenterID.Text = string.Format("中心编码：{0}", ds.Tables[0].Rows[0]["center_id"].ToString().Trim());
                this.lblHospitalID.Text = string.Format("医院编码：{0}", ds.Tables[0].Rows[0]["hosp_code"].ToString().Trim());
                this.lblMatchType.Text = string.Format("匹配类型：{0}", ds.Tables[0].Rows[0]["match_type"].ToString().Trim());
                this.lblHosp_code.Text = string.Format("医院目录编码：{0}", ds.Tables[0].Rows[0]["hosp_code"].ToString().Trim());
                this.lblHosp_name.Text = string.Format("医院目录名称：{0}", ds.Tables[0].Rows[0]["hosp_name"].ToString().Trim());

                this.c1FlexGridSelectDirCompare.DataSource = ds.Tables[1];

                this.c1FlexGridSelectDirCompare.Cols["ID"].Visible = false;
                this.c1FlexGridSelectDirCompare.Cols["modelID"].Visible = false;

               if (!this.c1FlexGridSelectDirCompare.Cols.Contains("model"))
                {
                    this.c1FlexGridSelectDirCompare.Cols["item_code"].Caption = "中心项目编码";
                    this.c1FlexGridSelectDirCompare.Cols["item_code"].Width = 110;
                    this.c1FlexGridSelectDirCompare.Cols["item_name"].Caption = "中心项目名称";
                    this.c1FlexGridSelectDirCompare.Cols["item_name"].Width = 270;
                }
                else
                {
                    this.c1FlexGridSelectDirCompare.Cols["item_code"].Caption = "中心药品编码";
                    this.c1FlexGridSelectDirCompare.Cols["item_code"].Width = 110;
                    this.c1FlexGridSelectDirCompare.Cols["item_name"].Caption = "中心药品名称";
                    this.c1FlexGridSelectDirCompare.Cols["item_name"].Width = 160;
                    this.c1FlexGridSelectDirCompare.Cols["model"].Caption = "剂型";
                    this.c1FlexGridSelectDirCompare.Cols["model"].Width = 110;
                }

                this.c1FlexGridSelectDirCompare.Cols["price"].Caption = "价格";
                this.c1FlexGridSelectDirCompare.Cols["price"].Width = 80;

                this.c1FlexGridSelectDirCompare.Cols["medi_item_type"].Caption = "匹配类型";
                this.c1FlexGridSelectDirCompare.Cols["medi_item_type"].Width = 60;
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("查询医院目录编号对应的信息发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridSelectDirCompare_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this._selectedRowIndex > 0)
            {
                string name = this.c1FlexGridSelectDirCompare.Rows[this._selectedRowIndex]["item_code"].ToString().Trim();
                string value = this.c1FlexGridSelectDirCompare.Rows[this._selectedRowIndex]["item_name"].ToString().Trim();
                string matchType = this.c1FlexGridSelectDirCompare.Rows[this._selectedRowIndex]["medi_item_type"].ToString().Trim();

                this.SelectValueParemeter = new Parameter(name, value);
                this.SelectValueParemeter.Object = matchType;

                this.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridSelectDirCompare_SelChange(object sender, EventArgs e)
        {
            this._selectedRowIndex = this.c1FlexGridSelectDirCompare.MouseRow;
        }
    }
}