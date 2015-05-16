using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using InterfaceClass;
using Windows.Class;

namespace Windows.MZ
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_AddFeeDetails : BaseForm
    {
        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// 类别
        /// </summary>
        private string _medi_item_type = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private string _name = "";

        /// <summary>
        /// 编号
        /// </summary>
        private string _id = string.Empty;

        /// <summary>
        /// 编号
        /// </summary>
        public string ID
        {
            get { return this._id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Frm_AddFeeDetails()
        {
            InitializeComponent();

            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_AddFeeDetails_Load(object sender, EventArgs e)
        {
            SetC1FlexGridDefaultAttribute(this.c1FlexGridFeeDetails);

            InitType();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_AddFeeDetails_Shown(object sender, EventArgs e)
        {
            this.txtBox_Name.Focus();

            this.btnQuery.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitType() {
            string sql = string.Format(@"SELECT  Name ,
                                                Value
                                        FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                        WHERE   TypeID = 4");

            InitComboBox(this.cBoxType, "Value", "Name", sql, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this._name = this.txtBox_Name.Text.Trim();
            this._medi_item_type = this.cBoxType.SelectedValue.ToString().Trim();

            CreateAndStartThread(this._thread, ThreadQuery);
        }

        /// <summary>
        /// 查询线程
        /// </summary>
        private void ThreadQuery() {
            try
            {
                SendUIMsg(UIMsg.Display, "正在努力查询，请稍后.....");

                StringBuilder sb = new StringBuilder();

                sb.AppendFormat(@"SELECT  ID ,
                                        CASE match_type
                                          WHEN 0 THEN '诊疗项目'
                                          WHEN 1 THEN '西药'
                                          WHEN 2 THEN '中成药'
                                          WHEN 3 THEN '中草药'
                                        END match_type ,
                                        hosp_code ,
                                        hosp_name ,
                                        item_code ,
                                        item_name
                                FROM    HIS_InterfaceHN.dbo.Interface_AddMatch
                                WHERE   match_type LIKE '%{0}%'
                                        AND CompareStatus = 3
                                        AND center_id = N'632802'
                                        AND hospital_id = N'632802002'
                                        AND hosp_name LIKE '%{1}%'
                                        OR hosp_jpm like '%{1}%'
                                ORDER BY hosp_name ", this._medi_item_type, this._name);

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(sb.ToString());

                SendUIMsg(AddFeeDetailsUIMsg.BindFeeDetails, ds.Tables[0]);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "查询费用明细发生错误，错误原因：" + ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnQuery.PerformClick();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnQuery.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFeeDetails_DoubleClick(object sender, EventArgs e)
        {
            int selectedRowIndex = this.c1FlexGridFeeDetails.MouseRow;

            if (selectedRowIndex > 0 && this.c1FlexGridFeeDetails.Cols.Contains("match_type"))
            {
                this._id = this.c1FlexGridFeeDetails.Rows[selectedRowIndex]["ID"].ToString().Trim();

                this.Close();
            }
            else
            {
                CommonFunctions.MsgError("请先选择一行数据！！！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void BindFeeDetails(object p)
        {
            this.c1FlexGridFeeDetails.DataSource = (DataTable)p;

            this.c1FlexGridFeeDetails.Cols["ID"].Visible = false;

            this.c1FlexGridFeeDetails.Cols["match_type"].Caption = "类型";
            this.c1FlexGridFeeDetails.Cols["match_type"].Width = 70;

            this.c1FlexGridFeeDetails.Cols["hosp_code"].Caption = "医院药品项目编码";
            this.c1FlexGridFeeDetails.Cols["hosp_code"].Width = 90;

            this.c1FlexGridFeeDetails.Cols["hosp_name"].Caption = "医院药品项目名称";
            this.c1FlexGridFeeDetails.Cols["hosp_name"].Width = 220;

            this.c1FlexGridFeeDetails.Cols["item_code"].Caption = "中心药品项目编码";
            this.c1FlexGridFeeDetails.Cols["item_code"].Width = 110;

            this.c1FlexGridFeeDetails.Cols["item_name"].Caption = "中心药品项目名称";
            this.c1FlexGridFeeDetails.Cols["item_name"].Width = 180;
        }

        /// <summary>
        /// 
        /// </summary>
        public class AddFeeDetailsUIMsg {
            public const string DisabledQueryButton = "DisabledQueryButton";
            public const string EnabledQueryButton = "EnabledQueryButton";
            public const string BindFeeDetails = "BindFeeDetails";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void UpdateUIControlContext(object context)
        {
            try
            {
                base.UpdateUIControlContext(context);

                Parameter parameter = (Parameter)context;

                switch (parameter.Name)
                { 
                    case AddFeeDetailsUIMsg.DisabledQueryButton:
                        this.btnQuery.Enabled = false;
                        break;
                    case AddFeeDetailsUIMsg.EnabledQueryButton:
                        this.btnQuery.Enabled = true;
                        break;
                    case AddFeeDetailsUIMsg.BindFeeDetails:
                        BindFeeDetails(parameter.Object);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError(ex.Message);
            }
        }
    }
}