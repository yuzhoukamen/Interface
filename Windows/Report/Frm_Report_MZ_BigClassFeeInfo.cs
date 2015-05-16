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
using InterfaceClass.HN.BusCostInfo.MZBigClassFeeInfo;
using Windows.Class;

namespace Windows.Report
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_Report_MZ_BigClassFeeInfo : BaseForm
    {
        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        private InterfaceClass.HN.MZ.MZ_ChangeParameter parameter=null;

        /// <summary>
        /// 大类费用信息
        /// </summary>
        private InterfaceClass.HN.BusCostInfo.AllOrders.Info _info = null;

        /// <summary>
        /// 默认为普通门诊
        /// </summary>
        private string _biz_type = "11";

        /// <summary>
        /// 
        /// </summary>
        public Frm_Report_MZ_BigClassFeeInfo(InterfaceClass.HN.BusCostInfo.AllOrders.Info info, long userID)
        {
            InitializeComponent();

            this._info = info;
            this._userID = userID;
            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 
        /// </summary>
        public Frm_Report_MZ_BigClassFeeInfo(InterfaceClass.HN.BusCostInfo.AllOrders.Info info, long userID,string biz_type)
        {
            InitializeComponent();

            this._info = info;
            this._userID = userID;
            this._biz_type = biz_type;
            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Report_MZ_BigClassFeeInfo_Load(object sender, EventArgs e)
        {
            SetTextBoxReadonly(this.groupBoxOrdersInfo);

            SetC1FlexGridAttribute(this.c1FlexGridFeeInfo, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridFeeInfo, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridFeeInfo);
            SetC1FlexGridNullDataTable(this.c1FlexGridFeeInfo);

            SetC1FlexGridAttribute(this.c1FlexGridFeeDetails, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridFeeDetails, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridFeeDetails);
            SetC1FlexGridNullDataTable(this.c1FlexGridFeeDetails);

            FormatC1FlexGridFeeInfo();
            FormatC1FlexGridFeeDetails();

            SetOrderInfo();

            if (this.txtBox_fees.Text.Trim() == "0元")
            {
                this.btnCancel.Enabled = false;
            }

            QueryAndSetUserInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FormatC1FlexGridFeeInfo()
        {
            this.c1FlexGridFeeInfo.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;

            this.c1FlexGridFeeInfo.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(
                delegate(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
                {
                    if (e.Row >= this.c1FlexGridFeeInfo.Rows.Fixed)
                    {
                        Setstat_type(e.Row, this.c1FlexGridFeeInfo);
                    }
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void Setstat_type(int rowIndex, C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private void FormatC1FlexGridFeeDetails()
        {
            this.c1FlexGridFeeDetails.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;

            this.c1FlexGridFeeDetails.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(
                delegate(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
                {
                    if (e.Row >= this.c1FlexGridFeeDetails.Rows.Fixed)
                    {
                        Setstat_type(e.Row, this.c1FlexGridFeeDetails);
                    }
                });
        }

        /// <summary>
        /// 设置信息
        /// </summary>
        private void SetOrderInfo()
        {
            try
            {
                List<Parameter> listParameter = GetProperties<InterfaceClass.HN.BusCostInfo.AllOrders.Info>(this._info);

                foreach (Parameter p in listParameter)
                {
                    foreach (System.Windows.Forms.Control ctr in this.groupBoxOrdersInfo.Controls)
                    {
                        if (ctr is TextBox)
                        {
                            string controlName = "txtBox_" + p.Name;

                            if (ctr.Name == controlName)
                            {
                                if (controlName == "txtBox_fees")
                                {
                                    ctr.Text = string.Format("{0}元", p.Value);
                                }
                                else
                                {
                                    ctr.Text = p.Value;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("设置业务信息发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Report_MZ_BigClassFeeInfo_Shown(object sender, EventArgs e)
        {
            if (this._biz_type != "11")
            {
                this.btnCancel.Enabled = false;
                this.btnCancel.Visible = false;
            }

            CreateAndStartThread(this._thread, ThreadQueryFeeInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadQueryFeeInfo()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心提取大类费用信息(BIZC200301)，请稍后......");

                GetBigClassFeeInfo bigClassFeeInfo = new GetBigClassFeeInfo(baseInterfaceHN);

                List<Info> listInfo = bigClassFeeInfo.GetBigCassFeeInfoDesc(baseInterfaceHN.Oper_hospitalid, this._info.serial_no, "hospstatinfo", "0");

                DataTable dt = TToDataTable<Info>(listInfo);

                SendUIMsg(Report_MZ_BigClassFeeInfoUIMsg.BindFeeInfo, dt);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);

                SendUIMsg(UIMsg.MsgError, "提取大类费用信息(BIZC200301)发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadQueryFeeDetails()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心提取明细费用信息(BIZC200301)，请稍后......");

                InterfaceClass.HN.BusCostInfo.MZFeeDetailInfo.MZFeeDetailInfo mzFeeDetailInfo = new InterfaceClass.HN.BusCostInfo.MZFeeDetailInfo.MZFeeDetailInfo(baseInterfaceHN);

                List<InterfaceClass.HN.BusCostInfo.MZFeeDetailInfo.Info> listInfo = mzFeeDetailInfo.GetMZFeeDetailInfo(baseInterfaceHN.Oper_hospitalid,
                                                                                                           this._info.serial_no, "hospfeeiteminfo", "0", "");

                DataTable dt = TToDataTable<InterfaceClass.HN.BusCostInfo.MZFeeDetailInfo.Info>(listInfo);

                SendUIMsg(Report_MZ_BigClassFeeInfoUIMsg.BindFeeDetails, dt);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);

                SendUIMsg(UIMsg.MsgError, "提取明细费用信息(BIZC200301)发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void BindFeeInfo(object p)
        {
            DataTable dt = (DataTable)p;

            if (dt == null || dt.Rows.Count <= 0)
            {
                SetC1FlexGridNullDataTable(this.c1FlexGridFeeInfo);
                return;
            }

            this.c1FlexGridFeeInfo.DataSource = dt;

            this.c1FlexGridFeeInfo.Cols["stat_type"].Visible = false;

            CreateAndStartThread(this._thread, ThreadQueryFeeDetails);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void BindFeeDetails(object p)
        {
            this.c1FlexGridFeeDetails.DataSource = (DataTable)p;

            this.c1FlexGridFeeDetails.Cols["stat_type"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["factory"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["calc_flag"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["doctor_no"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["trans_date"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["usage_flag"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["doctor_name"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["recipe_no"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["serial_fee"].Visible = false;

            this.c1FlexGridFeeDetails.Cols["stat_name"].Width = 80;
            this.c1FlexGridFeeDetails.Cols["his_item_name"].Width = 165;
            this.c1FlexGridFeeDetails.Cols["item_code"].Width = 130;
            this.c1FlexGridFeeDetails.Cols["self_scale"].Width = 55;
            this.c1FlexGridFeeDetails.Cols["unit"].Width = 40;
            this.c1FlexGridFeeDetails.Cols["dosage"].Width = 40;
            this.c1FlexGridFeeDetails.Cols["fee_date"].Width = 80;
            this.c1FlexGridFeeDetails.Cols["money"].Width = 60;
            this.c1FlexGridFeeDetails.Cols["pay_first"].Width = 60;
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
                    case Report_MZ_BigClassFeeInfoUIMsg.BindFeeDetails:
                        BindFeeDetails(parameter.Object);
                        break;
                    case Report_MZ_BigClassFeeInfoUIMsg.BindFeeInfo:
                        BindFeeInfo(parameter.Object);
                        break;
                    case Report_MZ_BigClassFeeInfoUIMsg.DisabledCancelButton:
                        this.btnCancel.Enabled = false;
                        break;
                    case Report_MZ_BigClassFeeInfoUIMsg.EnabledCancelButton:
                        this.btnCancel.Enabled = true;
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

        /// <summary>
        /// 
        /// </summary>
        public class Report_MZ_BigClassFeeInfoUIMsg
        {
            public const string BindFeeInfo = "BindFeeInfo";
            public const string BindFeeDetails = "BindFeeDetails";
            public const string DisabledCancelButton = "DisabledCancelButton";
            public const string EnabledCancelButton = "EnabledCancelButton";
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadCancelOrder()
        {
            try
            {
                SendUIMsg(Report_MZ_BigClassFeeInfoUIMsg.DisabledCancelButton);
                SendUIMsg(UIMsg.Display, "正在取消结算单" + this._info.serial_no + "，请稍后......");

                InterfaceClass.HN.MZ.CheckAndSaveFeeDetails fee = new InterfaceClass.HN.MZ.CheckAndSaveFeeDetails(baseInterfaceHN);

                InterfaceClass.HN.MZ.MZRegOutParameter outParameter = fee.CheckCalcAndSaveWrittenFeeDetails(parameter);

                SendUIMsg(UIMsg.Close);

                SendUIMsg(UIMsg.MsgInfo, "成功取消结算单！！！");

            }
            catch (Exception ex)
            {
                SendUIMsg(Report_MZ_BigClassFeeInfoUIMsg.EnabledCancelButton);
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "撤销结算单发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("您真的要撤销【" + this.txtBox_serial_no.Text.Trim() + "】的结算单吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (DialogResult.Yes == dr)
            {
                CreateCancelOrderParameter();

                CreateAndStartThread(this._thread, ThreadCancelOrder);
            }
        }

        private void CreateCancelOrderParameter()
        {
            try
            {
                if (this.c1FlexGridFeeDetails.Cols.Contains("stat_type"))
                {
                    this.parameter = new InterfaceClass.HN.MZ.MZ_ChangeParameter();

                    parameter.MZRegChange.center_id = baseInterfaceHN.Oper_centerid;
                    parameter.MZRegChange.hospital_id = baseInterfaceHN.Oper_hospitalid;
                    parameter.MZRegChange.serial_no = this.txtBox_serial_no.Text.Trim();
                    parameter.MZRegChange.indi_id = this._info.indi_id;
                    parameter.MZRegChange.biz_type = this._info.biz_type;
                    parameter.MZRegChange.treatment_type = this._info.treatment_type;
                    parameter.MZRegChange.reg_staff = this._userID.ToString();
                    parameter.MZRegChange.reg_man = this._info.reg_man;
                    parameter.MZRegChange.save_flag = "1";//收费
                    parameter.MZRegChange.bill_no = string.Empty;
                    parameter.MZRegChange.trade_no = string.Empty;
                    parameter.MZRegChange.diagnose = this._info.disease;
                    parameter.MZRegChange.diagnose_date = this._info.fin_date;
                    parameter.MZRegChange.query_flag = "1";//退费

                    for (int i = 1; i < this.c1FlexGridFeeDetails.Rows.Count; i++)
                    {
                        InterfaceClass.HN.MZ.FeeInfo feeInfo = new InterfaceClass.HN.MZ.FeeInfo();

                        feeInfo.medi_item_type = GetMedi_Item_Type(this.c1FlexGridFeeDetails.Rows[i]["item_code"].ToString().Trim());
                        feeInfo.stat_type = this.c1FlexGridFeeDetails.Rows[i]["stat_type"].ToString().Trim();
                        feeInfo.his_item_code = this.c1FlexGridFeeDetails.Rows[i]["item_code"].ToString().Trim();
                        feeInfo.his_item_name = this.c1FlexGridFeeDetails.Rows[i]["his_item_name"].ToString().Trim();
                        feeInfo.model = string.Empty;
                        feeInfo.factory = string.Empty;
                        feeInfo.standard = string.Empty;
                        feeInfo.fee_date = this._info.fin_date;
                        feeInfo.unit = this.c1FlexGridFeeDetails.Rows[i]["unit"].ToString().Trim();
                        feeInfo.price = this.c1FlexGridFeeDetails.Rows[i]["price"].ToString().Trim();
                        feeInfo.dosage = (-double.Parse(this.c1FlexGridFeeDetails.Rows[i]["dosage"].ToString().Trim())).ToString();
                        feeInfo.money = (-double.Parse(this.c1FlexGridFeeDetails.Rows[i]["money"].ToString().Trim())).ToString();
                        feeInfo.usage_flag = "0";
                        feeInfo.usage_days = "";
                        feeInfo.opp_serial_fee = this.c1FlexGridFeeDetails.Rows[i]["serial_fee"].ToString().Trim();
                        feeInfo.hos_serial = "";
                        feeInfo.input_staff = this._userID.ToString();
                        feeInfo.input_man = this._userName;
                        feeInfo.input_date = this._info.fin_date;
                        feeInfo.recipe_no = "";
                        feeInfo.doctor_no = "";
                        feeInfo.doctor_name = "";

                        parameter.AddFeeInfo(feeInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("创建取消订单参数发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetMedi_Item_Type(string item_code)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"SELECT  CASE medi_item_type
                                          WHEN '诊疗项目' THEN '0'
                                          WHEN '西药' THEN '1'
                                          WHEN '中成药' THEN '2'
                                          WHEN '中草药' THEN '3'
                                        END AS value
                                FROM    HIS_InterfaceHN.dbo.JC_Interface_CenterDir
                                WHERE   item_code = '{0}'", item_code);

            try
            {
                return Alif.DBUtility.DbHelperSQL.Query(sb.ToString()).Tables[0].Rows[0]["value"].ToString().Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("获取对应的项目药品类型发生错误，错误原因：" + ex.Message);
            }
        }
    }
}