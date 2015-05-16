using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Windows.MZ;
using InterfaceClass;
using System.Threading;
using Windows.Class;
using System.Data.SqlClient;
using C1.Win.C1FlexGrid;

namespace Windows.ZY
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_FeeDetails : BaseForm
    {
        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// 业务序列号
        /// </summary>
        private string _serial_no = string.Empty;

        /// <summary>
        /// 查找患者获取的患者信息
        /// </summary>
        private List<Parameter> _listPatientInfo = null;

        /// <summary>
        /// 费用列表
        /// </summary>
        private List<InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo> _listFeeInfo = null;

        /// <summary>
        /// 发票编号
        /// </summary>
        private string _fpID = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.InParameter _inParameter = null;

        /// <summary>
        /// 
        /// </summary>
        private List<InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo> _listFeeInfoSave_ing = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="indi_id"></param>
        public Frm_FeeDetails(long userID, string indi_id, string serial_no)
        {
            InitializeComponent();

            this._userID = userID;
            this.Indi_id = indi_id;
            this._serial_no = serial_no;

            this._SynchronizationContext = SynchronizationContext.Current;

            BindStatusChangeEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        public Frm_FeeDetails(long userID)
        {
            InitializeComponent();

            this._userID = userID;

            this._SynchronizationContext = SynchronizationContext.Current;

            BindStatusChangeEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        public class FeeDetailsUIMsg
        {
            public const string SetPersonInfo = "SetPersonInfo";
            public const string BindFeeDetails = "BindFeeDDetails";
            public const string BindUploadedFeeDetails = "BindUploadedFeeDetails";
            public const string FindPatientsSuccess = "FindPatientsSuccess";
            public const string QueryPersonInfo_Success = "QueryPersonInfo_Success";
            public const string SaveFeeDetails_success = "SaveFeeDetails_success";
            public const string SaveFeeDetails_failure = "SaveFeeDetails_failure";
            public const string QueryUploadedFeeDetails_ing = "QueryUploadedFeeDetails_ing";
            public const string QueryUploadedFeeDetails_success = "QueryUploadedFeeDetails_success";
            public const string QueryUploadedFeeDetails_failure = "QueryUploadedFeeDetails_failure";
            public const string CalcFeeDetails_ing = "CalcFeeDetails_ing";
            public const string CalcFeeDetails_success = "CalcFeeDetails_success";
            public const string CalcFeeDetails_failure = "CalcFeeDetails_failure";
            public const string SetPayInfo = "SetPayInfo";
            public const string ClearFeeDetails = "ClearFeeDetails";
            public const string ClearPayInfo = "ClearPayInfo";
            public const string DeleteUploadedFeeDetails_ing = "DeleteUploadedFeeDetails_ing";
            public const string DeleteUploadedFeeDetails_success = "DeleteUploadedFeeDetails_success";
            public const string DeleteUploadedFeeDetails_failure = "DeleteUploadedFeeDetails_failure";
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
                    case FeeDetailsUIMsg.SetPersonInfo:
                        SetPersonInfo(parameter.Object);
                        break;
                    case FeeDetailsUIMsg.BindFeeDetails:
                        BindFeeDetails(parameter.Object);
                        break;
                    case FeeDetailsUIMsg.FindPatientsSuccess:
                        this._statusEvent.Status = StatusString.FindPatients_Success;
                        break;
                    case FeeDetailsUIMsg.QueryPersonInfo_Success:
                        QueryPersonInfo_Success();
                        break;
                    case FeeDetailsUIMsg.BindUploadedFeeDetails:
                        BindUploadedFeeDetails(parameter.Object);
                        break;
                    case FeeDetailsUIMsg.SaveFeeDetails_success:
                        SaveFeeDetails_success();
                        break;
                    case FeeDetailsUIMsg.SaveFeeDetails_failure:
                        SaveFeeDetails_failure();
                        break;
                    case FeeDetailsUIMsg.QueryUploadedFeeDetails_ing:
                        QueryUploadedFeeDetails_ing();
                        break;
                    case FeeDetailsUIMsg.QueryUploadedFeeDetails_success:
                        QueryUploadedFeeDetails_success();
                        break;
                    case FeeDetailsUIMsg.QueryUploadedFeeDetails_failure:
                        QueryUploadedFeeDetails_failure();
                        break;
                    case FeeDetailsUIMsg.CalcFeeDetails_ing:
                        CalcFeeDetails_ing();
                        break;
                    case FeeDetailsUIMsg.CalcFeeDetails_success:
                        CalcFeeDetails_success();
                        break;
                    case FeeDetailsUIMsg.CalcFeeDetails_failure:
                        CalcFeeDetails_failure();
                        break;
                    case FeeDetailsUIMsg.SetPayInfo:
                        SetPayInfo(parameter.Object);
                        break;
                    case FeeDetailsUIMsg.ClearFeeDetails:
                        ClearFeeDetails();
                        break;
                    case FeeDetailsUIMsg.ClearPayInfo:
                        ClearPayInfo();
                        break;
                    case FeeDetailsUIMsg.DeleteUploadedFeeDetails_ing:
                        DeleteUploadedFeeDetails_ing();
                        break;
                    case FeeDetailsUIMsg.DeleteUploadedFeeDetails_success:
                        DeleteUploadedFeeDetails_success();
                        break;
                    case FeeDetailsUIMsg.DeleteUploadedFeeDetails_failure:
                        DeleteUploadedFeeDetails_failure();
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
        /// 设置费用信息
        /// </summary>
        /// <param name="p"></param>
        private void SetPayInfo(object p)
        {
            DataTable dt = (DataTable)p;

            if (dt == null || dt.Rows.Count == 0)
            {
                SetC1FlexGridNullDataTable(this.c1FlexGridPayInfo);
                return;
            }

            this.c1FlexGridPayInfo.DataSource = dt;

            this.c1FlexGridPayInfo.Cols["fund_id"].Visible = false;
            this.c1FlexGridPayInfo.Cols["fund_name"].Width = 180;
            this.c1FlexGridPayInfo.Cols["real_pay"].Width = 120;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void BindUploadedFeeDetails(object p)
        {
            DataTable dt = (DataTable)p;

            if (dt == null || dt.Rows.Count == 0)
            {
                SetC1FlexGridNullDataTable(this.c1FlexGridUploadedFeeDetails);
                return;
            }

            this.c1FlexGridUploadedFeeDetails.DataSource = dt;

            this.c1FlexGridUploadedFeeDetails.Cols["hospital_id"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["serial_fee"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["serial_apply"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["serial_no"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["recipe_no"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["doctor_no"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["doctor_name"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["stat_type"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["medi_item_type"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["defray_type"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["his_item_code"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["his_item_name"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["item_code"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["item_code"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["factory"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["standard"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["usage_flag"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["usage_days"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["input_staff"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["input_man"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["hos_serial"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["trans_date"].Visible = false;
            this.c1FlexGridUploadedFeeDetails.Cols["input_date"].Visible = false;

            this.c1FlexGridUploadedFeeDetails.Cols["item_name"].Width = 220;
            this.c1FlexGridUploadedFeeDetails.Cols["model"].Width = 50;
            this.c1FlexGridUploadedFeeDetails.Cols["unit"].Width = 65;
            this.c1FlexGridUploadedFeeDetails.Cols["money"].Width = 70;
            this.c1FlexGridUploadedFeeDetails.Cols["reduce_money"].Width = 90;
            this.c1FlexGridUploadedFeeDetails.Cols["fee_date"].Width = 125;

            if (dt.Rows.Count > 0)
            {
                double sum = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    sum += double.Parse(dr["money"].ToString().Trim());
                }

                this.lblTotalFee.Text = sum.ToString("0.00") + "元";

                this._statusEvent.Status = StatusString.CalcFeeDetails_ing;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryPersonInfo_Success()
        {
            this.btnFindPatient.Enabled = true;

            QueryUploadedFeeDetails();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void BindFeeDetails(object p)
        {
            List<InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo> listFeeInfo = (List<InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo>)p;

            if (listFeeInfo.Count <= 0)
            {
                return;
            }

            foreach (InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo feeInfo in listFeeInfo)
            {
                switch (feeInfo.medi_item_type)
                {
                    case "0":
                        feeInfo.medi_item_type = "诊疗项目";
                        break;
                    case "1":
                        feeInfo.medi_item_type = "西药";
                        break;
                    case "2":
                        feeInfo.medi_item_type = "中成药";
                        break;
                    case "3":
                        feeInfo.medi_item_type = "中草药";
                        break;
                    default: break;
                }
            }

            DataTable dt = TToDataTable<InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo>(listFeeInfo);

            this.c1FlexGridFeeDetails.DataSource = dt;

            this.c1FlexGridFeeDetails.Cols["medi_item_type"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["his_item_code"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["item_code"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["stat_type"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["model"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["factory"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["standard"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["usage_days"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["opp_serial_fee"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["hos_serial"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["usage_flag"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["remark"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["serial_apply"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["make_flag"].Visible = false;
            this.c1FlexGridFeeDetails.Cols["fee_date"].Visible = false;

            this.c1FlexGridFeeDetails.Cols["his_item_name"].Width = 230;
            this.c1FlexGridFeeDetails.Cols["unit"].Width = 75;
            this.c1FlexGridFeeDetails.Cols["price"].Width = 95;
            this.c1FlexGridFeeDetails.Cols["dosage"].Width = 70;
            this.c1FlexGridFeeDetails.Cols["money"].Width = 70;
            this.c1FlexGridFeeDetails.Cols["usage_flag"].Width = 60;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void SetPersonInfo(object p)
        {
            InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo bizInfo = (InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo)p;

            List<Parameter> listParameter = GetProperties<InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo>(bizInfo);

            SetTextBoxText(this.groupBoxPersonInfo, "", listParameter);

            this.lblICCard.Text = bizInfo.ic_no;
            this.serial_no.Text = this._serial_no;
            this.sex.Text = (this.sex.Text.Trim() == "1" ? "男" : "女");

            SetTreatment(this.treatment_type.Text.Trim());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void SetTreatment(string value)
        {
            try
            {
                this.treatment_type.Text = Alif.DBUtility.DbHelperSQL.Query(string.Format(@"SELECT  Value
                                                                            FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                                                            WHERE   TypeID = 2
                                                                                    AND Name = '{0}'", value)).Tables[0].Rows[0]["Value"].ToString().Trim();
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("设置待遇类别发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 状态改变时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void StatusEvent_OnStatusChange(object sender, EventArgs e)
        {
            string value = this._statusEvent.Status;

            switch (value)
            {
                case StatusString.LoadPage:
                    LoadPage();
                    break;
                case StatusString.FindPatients:
                    FindPatients();
                    break;
                case StatusString.FindPatients_Success:
                    FindPatients_Success();
                    break;
                case StatusString.QueryUploadedFeeDetails_ing:
                    QueryUploadedFeeDetails_ing();
                    break;
                case StatusString.QueryUploadedFeeDetails_success:
                    QueryUploadedFeeDetails_success();
                    break;
                case StatusString.QueryUploadedFeeDetails_failure:
                    QueryUploadedFeeDetails_failure();
                    break;
                case StatusString.CalcFeeDetails_ing:
                    CalcFeeDetails_ing();
                    break;
                case StatusString.CalcFeeDetails_success:
                    CalcFeeDetails_success();
                    break;
                case StatusString.CalcFeeDetails_failure:
                    CalcFeeDetails_failure();
                    break;
                case StatusString.SaveFeeDetails_ing:
                    SaveFeeDetails_ing();
                    break;
                case StatusString.SaveFeeDetails_success:
                    SaveFeeDetails_success();
                    break;
                case StatusString.SaveFeeDetails_failure:
                    SaveFeeDetails_failure();
                    break;
                case StatusString.QueryPersonInfo:
                    QueryPersonInfo();
                    break;
                case StatusString.ReadCard_ing:
                    ReadCard_ing();
                    break;
                case StatusString.ClearFeeDetails:
                    ClearFeeDetails();
                    break;
                case StatusString.DeleteUploadedFeeDetails:
                    DeleteUploadedFeeDetails();
                    break;
                case StatusString.CheckAndSaveUploadedFeeDetails:
                    CheckAndSaveUploadedInHospitalFeeDetails();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearPayInfo()
        {
            this.lblTotalFee.Text = string.Empty;
            SetC1FlexGridNullDataTable(this.c1FlexGridPayInfo);
        }

        #region 删除住院费用信息

        /// <summary>
        /// 
        /// </summary>
        private void DeleteUploadedFeeDetails_failure()
        {
            this.btnReadCard.Enabled = true;
            this.btnFindPatient.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnQuery.Enabled = true;
            this.btnCalc.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteUploadedFeeDetails_success()
        {
            this.btnReadCard.Enabled = true;
            this.btnFindPatient.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnQuery.Enabled = true;
            this.btnCalc.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteUploadedFeeDetails_ing()
        {
            this.btnReadCard.Enabled = false;
            this.btnFindPatient.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnQuery.Enabled = false;
            this.btnCalc.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
        }

        /// <summary>
        /// 删除全部已经上传的住院费用
        /// </summary>
        private void DeleteUploadedFeeDetails()
        {
            DialogResult dr = MessageBox.Show("您真的要删除全部已经上传的住院费用吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (DialogResult.Yes == dr)
            {
                CreateAndStartThread(this._thread, ThreadDeleteUploadedFeeDetails);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadDeleteUploadedFeeDetails()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器删除全部已经上传的住院费用，请稍后。。。");
                SendUIMsg(FeeDetailsUIMsg.DeleteUploadedFeeDetails_ing);

                InterfaceClass.HN.ZY.DeleteInHospitalFeeDetails.Function function = new InterfaceClass.HN.ZY.DeleteInHospitalFeeDetails.Function(baseInterfaceHN);

                string msg = function.DeleteUploadedInHospitalFeeDetails(baseInterfaceHN.Oper_hospitalid, this._serial_no, this._userID.ToString(), this._userName);

                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgInfo, msg == "" ? "删除全部已上传住院费用成功！！！" : msg);
                SendUIMsg(FeeDetailsUIMsg.ClearPayInfo);
                SendUIMsg(FeeDetailsUIMsg.DeleteUploadedFeeDetails_success);
                SendUIMsg(FeeDetailsUIMsg.QueryUploadedFeeDetails_ing);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(FeeDetailsUIMsg.DeleteUploadedFeeDetails_failure);
                SendUIMsg(UIMsg.MsgError, "删除全部已经上传的住院费用发生错误，错误原因：" + ex.Message);
            }
        }

        #endregion

        #region 查询已经保存费用信息

        /// <summary>
        /// 查询已经保存费用信息
        /// </summary>
        private void QueryUploadedFeeDetails()
        {
            this._serial_no = this.serial_no.Text.Trim();

            if (this._serial_no == string.Empty)
            {
                CommonFunctions.MsgError("没有就医登记号，不能进行【已保存的费用明细信息】查询！！！");
                return;
            }
            CreateAndStartThread(this._thread, ThreadQueryUploadedFeeDetails);
        }

        /// <summary>
        /// 线程查询已上传费用信息
        /// </summary>
        private void ThreadQueryUploadedFeeDetails()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器提取已保存的费用明细信息(BIZC131253)，请稍后。。。");

                InterfaceClass.HN.ZY.GetUploadedFeeDetails.Function function = new InterfaceClass.HN.ZY.GetUploadedFeeDetails.Function(baseInterfaceHN);

                List<InterfaceClass.HN.ZY.GetUploadedFeeDetails.FeeInfo> listFeeInfo = function.GetUploadedFeeInfo(baseInterfaceHN.Oper_hospitalid, this._serial_no);

                DataTable dt = TToDataTable<InterfaceClass.HN.ZY.GetUploadedFeeDetails.FeeInfo>(listFeeInfo);

                SendUIMsg(FeeDetailsUIMsg.BindUploadedFeeDetails, dt);
                SendUIMsg(UIMsg.Close);
                SendUIMsg(FeeDetailsUIMsg.QueryUploadedFeeDetails_success);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(FeeDetailsUIMsg.QueryUploadedFeeDetails_failure);
                SendUIMsg(UIMsg.MsgError, "提取已保存的费用明细信息(BIZC131253)发生错误，错误原因：" + ex.Message);
            }
        }

        #endregion

        #region 查询人员信息

        /// <summary>
        /// 查询人员信息
        /// </summary>
        private void QueryPersonInfo()
        {
            CreateAndStartThread(this._thread, ThreadQueryPersonInfo);
        }

        /// <summary>
        /// 查询人员信息线程
        /// </summary>
        private void ThreadQueryPersonInfo()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在查询人员信息，请稍后......");

                InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.Function func = new InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.Function(baseInterfaceHN);

                InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo bizInfo = func.GetPersonInfoAndInHospitalBizInfoBy_indi_id(this.Indi_id, baseInterfaceHN.Oper_hospitalid, "12");

                SendUIMsg(FeeDetailsUIMsg.SetPersonInfo, bizInfo);

                SendUIMsg(UIMsg.Close);

                SendUIMsg(FeeDetailsUIMsg.QueryPersonInfo_Success);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "查询人员信息发生错误，错误原因：" + ex.Message);
            }
        }

        #endregion

        #region 查找患者

        /// <summary>
        /// 
        /// </summary>
        private void FindPatients()
        {
            Frm_FindPatients frm = new Frm_FindPatients(1);

            frm.ShowDialog();

            this._listPatientInfo = frm.ListReturnParameter;

            frm = null;

            if (this._listPatientInfo != null)
            {
                SetFPInfo();
                GetFeeDetails();
            }
        }

        /// <summary>
        /// 设置发票流水号
        /// </summary>
        private void SetFPInfo()
        {
            foreach (Parameter parameter in this._listPatientInfo)
            {
                if (parameter.Name == "发票流水号")
                {
                    this._fpID = parameter.Value;
                }
            }
        }

        /// <summary>
        /// 获取费用明细信息（通过线程）
        /// </summary>
        private void GetFeeDetails()
        {
            if (this._fpID != string.Empty)
            {
                CreateAndStartThread(this._thread, ThreadGetFeeDetails);
            }
        }

        /// <summary>
        /// 线程获取费用明细信息
        /// </summary>
        private void ThreadGetFeeDetails()
        {
            DataSet ds = GetHospitalFeeDetailsByFPID();

            if (ds == null)
            {
                return;
            }

            if (ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                SendUIMsg(UIMsg.MsgError, "通过发票流水号获取医院费用明细信息失败，没有任何记录，请联系管理员！！！");
            }

            CompareHospitalFeeDetails(ds);

            ds.Clear();
            ds.Dispose();

            SendUIMsg(FeeDetailsUIMsg.BindFeeDetails, this._listFeeInfo);

            SendUIMsg(FeeDetailsUIMsg.FindPatientsSuccess);
        }

        /// <summary>
        /// 对照获取的门诊费用明细信息
        /// </summary>
        /// <param name="ds">要对照的门诊费用明细</param>
        private void CompareHospitalFeeDetails(DataSet ds)
        {
            try
            {
                if (this._listFeeInfo != null)
                {
                    this._listFeeInfo.Clear();
                    this._listFeeInfo = null;
                }

                this._listFeeInfo = new List<InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo>();

                SendUIMsg(UIMsg.Display, "正在查询项目编号对应的医院项目编码，请稍后......");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    string id = dr["项目编号"].ToString().Trim();

                    SendUIMsg(UIMsg.WriteMsg, string.Format("正在查询项目编号：{0}的医院项目编码，请稍后......", id));

                    string his_item_code = GetHISItemCode(id);
                    string name = dr["医院药品项目名称"].ToString().Trim();

                    if (his_item_code == string.Empty)
                    {
                        throw new Exception(string.Format("项目编号{0}对应的医院项目编码{1}({2})不能为空！！！", id, his_item_code, name));
                    }

                    SendUIMsg(UIMsg.WriteMsg, string.Format("成功获取项目编号：{0}的医院项目编码：{1}！！！", id, his_item_code));

                    InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo feeInfo = GetFeeDetailBy_his_item_code(his_item_code, name);

                    feeInfo.fee_date = dr["费用发生时间"].ToString();
                    feeInfo.price = dr["单价"].ToString();
                    feeInfo.dosage = dr["用量"].ToString();
                    feeInfo.money = dr["金额"].ToString();

                    this._listFeeInfo.Add(feeInfo);

                }

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "查询项目编号对应的医院项目编码发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="his_item_code"></param>
        /// <returns></returns>
        private InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo GetFeeDetailBy_his_item_code(string his_item_code, string name)
        {
            try
            {
                InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo feeInfo = new InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo();

                IDataParameter[] parameter = new IDataParameter[3];

                parameter[0] = new SqlParameter("@centerID", baseInterfaceHN.Oper_centerid);
                parameter[1] = new SqlParameter("@hospitalID", baseInterfaceHN.Oper_hospitalid);
                parameter[2] = new SqlParameter("@hosp_code", his_item_code);

                DataSet ds = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_GetFeeDetailBy_his_item_code", parameter, "P_GetFeeDetailBy_his_item_code");

                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 1)
                {

                    feeInfo.medi_item_type = ds.Tables[0].Rows[0]["medi_item_type"].ToString().Trim();
                    feeInfo.stat_type = ds.Tables[0].Rows[0]["stat_type"].ToString().Trim();
                    feeInfo.his_item_code = ds.Tables[0].Rows[0]["his_item_code"].ToString().Trim();
                    feeInfo.item_code = ds.Tables[0].Rows[0]["item_code"].ToString().Trim();
                    feeInfo.his_item_name = ds.Tables[0].Rows[0]["his_item_name"].ToString().Trim();
                    feeInfo.model = ds.Tables[0].Rows[0]["model"].ToString().Trim();
                    feeInfo.factory = ds.Tables[0].Rows[0]["factory"].ToString().Trim();
                    feeInfo.standard = ds.Tables[0].Rows[0]["standard"].ToString().Trim();
                    feeInfo.unit = ds.Tables[0].Rows[0]["unit"].ToString().Trim();
                    feeInfo.usage_flag = ds.Tables[0].Rows[0]["usage_flag"].ToString().Trim();
                    feeInfo.usage_days = ds.Tables[0].Rows[0]["usage_days"].ToString().Trim();
                    feeInfo.opp_serial_fee = ds.Tables[0].Rows[0]["opp_serial_fee"].ToString().Trim();
                    feeInfo.hos_serial = ds.Tables[0].Rows[0]["hos_serial"].ToString().Trim();
                    feeInfo.remark = "";
                    feeInfo.serial_apply = "";
                    feeInfo.make_flag = "";
                }
                else
                {
                    throw new Exception(string.Format(@"通过HIS数据库中的医院项目编码获取中心的对照信息发生错误，请对照HIS医院项目编码：{0}、名称：{1}", his_item_code, name));
                }

                return feeInfo;

            }
            catch (Exception ex)
            {
                throw new Exception("通过HIS数据库中的医院项目编码获取中心的对照信息发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 通过发票流水号获取医院费用明细
        /// </summary>
        /// <returns></returns>
        private DataSet GetHospitalFeeDetailsByFPID()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在通过发票流水号获取医院费用明细信息，请稍后......");

                IDataParameter[] parameters = new IDataParameter[1];

                parameters[0] = new SqlParameter("@FPID", this._fpID);

                DataSet ds = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_MZFeeDetails", parameters, "P_MZFeeDetails");

                SendUIMsg(UIMsg.Close);

                return ds;
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "通过发票流水号获取医院费用明细信息发生错误，错误原因：" + ex.Message);

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetHISItemCode(string id)
        {
            IDataParameter[] parameter = new IDataParameter[1];

            parameter[0] = new SqlParameter("@ID", id);

            DataSet dsTemp = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_GetHospitalItemCode", parameter, "P_GetHospitalItemCode");

            return dsTemp.Tables[0].Rows[0]["his_item_code"].ToString().Trim();
        }

        #endregion

        #region 住院费用计算

        /// <summary>
        /// 
        /// </summary>
        private void CalcInHospitalFeeDetails()
        {
            CreateAndStartThread(this._thread, ThreadCalcInHospitalFeeDetails);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadCalcInHospitalFeeDetails()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在从服务器获取住院费用计算(BIZC131255)数据，请稍后。。。");

                InterfaceClass.HN.ZY.InHospitalFeeCalc.Function function = new InterfaceClass.HN.ZY.InHospitalFeeCalc.Function(baseInterfaceHN);

                InterfaceClass.HN.ZY.InHospitalFeeCalc.InParameter inParameter = new InterfaceClass.HN.ZY.InHospitalFeeCalc.InParameter();

                inParameter.hospital_id = baseInterfaceHN.Oper_hospitalid;
                inParameter.serial_no = this._serial_no;
                inParameter.last_balance = "";
                inParameter.save_flag = "0";
                inParameter.treatment_type = "120";
                inParameter.end_disease = "";
                inParameter.reg_flag = "";
                inParameter.end_date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

                List<InterfaceClass.HN.ZY.InHospitalFeeCalc.PayInfo> listPayInfo = function.InHospitalFeeDetailsCalc(inParameter);

                DataTable dt = TToDataTable<InterfaceClass.HN.ZY.InHospitalFeeCalc.PayInfo>(listPayInfo);

                SendUIMsg(FeeDetailsUIMsg.SetPayInfo, dt);
                SendUIMsg(UIMsg.Close);
                SendUIMsg(FeeDetailsUIMsg.CalcFeeDetails_success);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(FeeDetailsUIMsg.CalcFeeDetails_failure);
                SendUIMsg(UIMsg.MsgError, "住院费用计算(BIZC131255)发生错误，错误原因：" + ex.Message);
            }
        }

        #endregion

        #region 检验保存住院费用明细

        /// <summary>
        /// 检验和保存住院费用明细
        /// </summary>
        private void CheckAndSaveUploadedInHospitalFeeDetails()
        {
            try
            {
                if (!this.c1FlexGridUploadedFeeDetails.Cols.Contains("his_item_name"))
                {
                    CommonFunctions.MsgError("请先录入住院费用明细！！！");
                    this._statusEvent.Status = StatusString.SaveFeeDetails_failure;
                    return;
                }

                this._listFeeInfoSave_ing = new List<InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo>();


                this._inParameter = new InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.InParameter();

                this._inParameter.hospital_id = baseInterfaceHN.Oper_hospitalid;
                this._inParameter.indi_id = this.Indi_id;
                this._inParameter.biz_type = "12";
                this._inParameter.serial_no = this._serial_no;
                this._inParameter.input_staff = this._userID.ToString();
                this._inParameter.input_man = this._userName;
                this._inParameter.recipe_no = "";
                this._inParameter.doctor_no = "";
                this._inParameter.doctor_name = "";

                List<Parameter> listParameter = GetProperties<InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo>(new InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo());

                for (int i = 1; i < this.c1FlexGridUploadedFeeDetails.Rows.Count; i++)
                {
                    InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo feeInfo = new InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo();

                    for (int j = 1; j < this.c1FlexGridUploadedFeeDetails.Cols.Count; j++)
                    {
                        string columnName = this.c1FlexGridUploadedFeeDetails.Cols[j].Name.ToString().Trim();

                        if (columnName == "item_code" && this.c1FlexGridUploadedFeeDetails.Rows[i][columnName].ToString().Trim() == string.Empty)
                        {
                            throw new Exception(string.Format("医院药品项目名称【{0}】没有进行对照，请对照！！！", this.c1FlexGridUploadedFeeDetails.Rows[i]["his_item_name"].ToString().Trim()));
                        }

                        foreach (Parameter parameter in listParameter)
                        {
                            if (columnName == parameter.Name)
                            {
                                string value = this.c1FlexGridUploadedFeeDetails.Rows[i][columnName].ToString().Trim();

                                feeInfo.SetAttributeValue(parameter.Name, value);
                            }
                        }
                    }

                    feeInfo.fee_date = this.fee_date.Text.Trim();

                    switch (feeInfo.medi_item_type)
                    {
                        case "诊疗项目":
                            feeInfo.medi_item_type = "0";
                            break;
                        case "西药":
                            feeInfo.medi_item_type = "1";
                            break;
                        case "中成药":
                            feeInfo.medi_item_type = "2";
                            break;
                        case "中草药":
                            feeInfo.medi_item_type = "3";
                            break;
                    }

                    this._listFeeInfoSave_ing.Add(feeInfo);
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError(ex.Message);
                this._statusEvent.Status = StatusString.SaveFeeDetails_failure;
                return;
            }

            CreateAndStartThread(this._thread, ThreadCheckAndSaveInHospitalFeeDetails);
        }

        /// <summary>
        /// 检验和保存住院费用明细
        /// </summary>
        private void CheckAndSaveInHospitalFeeDetails()
        {
            try
            {
                if (!this.c1FlexGridFeeDetails.Cols.Contains("his_item_name"))
                {
                    CommonFunctions.MsgError("请先录入住院费用明细！！！");
                    this._statusEvent.Status = StatusString.SaveFeeDetails_failure;
                    return;
                }

                this._listFeeInfoSave_ing = new List<InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo>();


                this._inParameter = new InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.InParameter();

                this._inParameter.hospital_id = baseInterfaceHN.Oper_hospitalid;
                this._inParameter.indi_id = this.Indi_id;
                this._inParameter.biz_type = "12";
                this._inParameter.serial_no = this._serial_no;
                this._inParameter.input_staff = this._userID.ToString();
                this._inParameter.input_man = this._userName;
                this._inParameter.recipe_no = "";
                this._inParameter.doctor_no = "";
                this._inParameter.doctor_name = "";

                List<Parameter> listParameter = GetProperties<InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo>(new InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo());

                for (int i = 1; i < this.c1FlexGridFeeDetails.Rows.Count; i++)
                {
                    InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo feeInfo = new InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.FeeInfo();

                    for (int j = 1; j < this.c1FlexGridFeeDetails.Cols.Count; j++)
                    {
                        string columnName = this.c1FlexGridFeeDetails.Cols[j].Name.ToString().Trim();

                        if (columnName == "item_code" && this.c1FlexGridFeeDetails.Rows[i][columnName].ToString().Trim() == string.Empty)
                        {
                            throw new Exception(string.Format("医院药品项目名称【{0}】没有进行对照，请对照！！！", this.c1FlexGridFeeDetails.Rows[i]["his_item_name"].ToString().Trim()));
                        }

                        foreach (Parameter parameter in listParameter)
                        {
                            if (columnName == parameter.Name)
                            {
                                string value = this.c1FlexGridFeeDetails.Rows[i][columnName].ToString().Trim();

                                feeInfo.SetAttributeValue(parameter.Name, value);
                            }
                        }
                    }

                    feeInfo.his_item_code = feeInfo.item_code;
                    feeInfo.fee_date = this.fee_date.Text.Trim();

                    switch (feeInfo.medi_item_type)
                    {
                        case "诊疗项目":
                            feeInfo.medi_item_type = "0";
                            break;
                        case "西药":
                            feeInfo.medi_item_type = "1";
                            break;
                        case "中成药":
                            feeInfo.medi_item_type = "2";
                            break;
                        case "中草药":
                            feeInfo.medi_item_type = "3";
                            break;
                    }

                    this._listFeeInfoSave_ing.Add(feeInfo);
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError(ex.Message);
                this._statusEvent.Status = StatusString.SaveFeeDetails_failure;
                return;
            }

            CreateAndStartThread(this._thread, ThreadCheckAndSaveInHospitalFeeDetails);
        }

        /// <summary>
        /// 检验和保存住院费用明细线程
        /// </summary>
        private void ThreadCheckAndSaveInHospitalFeeDetails()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在往中心服务器保存住院费用明细，请稍后。。。");

                InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.Function function = new InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.Function(baseInterfaceHN);

                string msg = function.CheckAndSaveFeeDetails(this._inParameter, this._listFeeInfoSave_ing);

                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgInfo, msg);
                SendUIMsg(FeeDetailsUIMsg.QueryUploadedFeeDetails_ing);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "【检验保存已录入费用明细】发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 检验和保存住院费用明细线程
        /// </summary>
        private void ThreadCheckAndSaveUploadedInHospitalFeeDetails()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在往中心服务器保存住院费用明细，请稍后。。。");

                InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.Function function = new InterfaceClass.HN.ZY.CheckAndSaveFeeDetails.Function(baseInterfaceHN);

                string msg = function.CheckAndSaveUploadedFeeDetails(this._inParameter, this._listFeeInfoSave_ing);

                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgInfo, msg);
                SendUIMsg(FeeDetailsUIMsg.QueryUploadedFeeDetails_ing);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "【检验保存住院费用明细】发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearFeeDetails()
        {
            SetC1FlexGridNullDataTable(this.c1FlexGridFeeDetails);
        }

        #endregion

        #region 触发事件

        /// <summary>
        /// 读卡
        /// </summary>
        private void ReadCard_ing()
        {
            Frm_ReadCard frm = new Frm_ReadCard(this._userID);

            frm.ShowDialog();

            this.Indi_id = frm.CardNumbers;//个人电脑号

            frm = null;

            if (this.Indi_id != null && this.Indi_id != string.Empty)
            {
                this._statusEvent.Status = StatusString.QueryPersonInfo;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void FindPatients_Success()
        {
            this.btnQuery.Enabled = true;
            this.btnCalc.Enabled = true;
            this.btnSave.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveFeeDetails_failure()
        {
            this.btnReadCard.Enabled = true;
            this.btnFindPatient.Enabled = true;
            this.btnQuery.Enabled = true;
            this.btnCalc.Enabled = true;
            this.btnSave.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveFeeDetails_success()
        {
            this.btnReadCard.Enabled = true;
            this.btnFindPatient.Enabled = true;
            this.btnQuery.Enabled = true;
            this.btnCalc.Enabled = true;
            this.btnSave.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveFeeDetails_ing()
        {
            this.btnReadCard.Enabled = false;
            this.btnFindPatient.Enabled = false;
            this.btnQuery.Enabled = false;
            this.btnCalc.Enabled = false;
            this.btnSave.Enabled = false;

            CheckAndSaveInHospitalFeeDetails();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CalcFeeDetails_failure()
        {
            this.btnReadCard.Enabled = true;
            this.btnFindPatient.Enabled = true;
            this.btnQuery.Enabled = true;
            this.btnCalc.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnDelete.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void CalcFeeDetails_success()
        {
            this.btnReadCard.Enabled = true;
            this.btnFindPatient.Enabled = true;
            this.btnQuery.Enabled = true;
            this.btnCalc.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnDelete.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void CalcFeeDetails_ing()
        {
            this.btnReadCard.Enabled = false;
            this.btnFindPatient.Enabled = false;
            this.btnQuery.Enabled = false;
            this.btnCalc.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnDelete.Enabled = false;

            CalcInHospitalFeeDetails();
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryUploadedFeeDetails_failure()
        {
            this.btnReadCard.Enabled = true;
            this.btnFindPatient.Enabled = true;
            this.btnQuery.Enabled = true;
            this.btnCalc.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnDelete.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryUploadedFeeDetails_success()
        {
            this.btnReadCard.Enabled = true;
            this.btnFindPatient.Enabled = true;
            this.btnQuery.Enabled = true;
            this.btnCalc.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnDelete.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryUploadedFeeDetails_ing()
        {
            this.btnReadCard.Enabled = false;
            this.btnFindPatient.Enabled = false;
            this.btnQuery.Enabled = false;
            this.btnCalc.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnDelete.Enabled = false;

            QueryUploadedFeeDetails();
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        private void LoadPage()
        {
            this.btnQuery.Enabled = false;
            this.btnCalc.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnFindPatient.Enabled = false;

            this.lblICCard.Text = string.Empty;

            QueryAndSetUserInfo();

            SetC1FlexGridDefaultAttribute(this.c1FlexGridUploadedFeeDetails);
            SetC1FlexGridDefaultAttribute(this.c1FlexGridFeeDetails);
            SetC1FlexGridDefaultAttribute(this.c1FlexGridPayInfo);

            SetTextBoxReadonly(this.groupBoxPersonInfo);
            ClearTextBoxValue(this.groupBoxPersonInfo);

            if (this.Indi_id != null && this.Indi_id != string.Empty)
            {
                this.btnReadCard.Enabled = false;
                this.btnFindPatient.Enabled = true;
                this.btnQuery.Enabled = true;

                this._statusEvent.Status = StatusString.QueryPersonInfo;
            }

            SetC1FlexGridRowBackGroundColor();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetC1FlexGridRowBackGroundColor()
        {
            this.c1FlexGridFeeDetails.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;

            this.c1FlexGridFeeDetails.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(
                delegate(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
                {
                    if (e.Row >= this.c1FlexGridFeeDetails.Rows.Fixed)
                    {
                        SetRowBackground(e.Row);
                    }
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex"></param>
        private void SetRowBackground(int rowIndex)
        {
            try
            {
                if (this.c1FlexGridFeeDetails.Cols.Contains("item_code"))
                {

                    string item_code = this.c1FlexGridFeeDetails.Rows[rowIndex]["item_code"].ToString().Trim();

                    Color color;
                    CellStyle mystyle;
                    string name = string.Empty;

                    switch (item_code)
                    {
                        case "":
                            color = Color.OrangeRed;
                            name = "MyStyleOrangeRed";
                            break;
                        default:
                            color = Color.White;
                            name = "MyStyleWhite";
                            break;
                    }

                    if (name != string.Empty)
                    {
                        mystyle = this.c1FlexGridFeeDetails.Styles.Add(name);
                        mystyle.BackColor = color;
                        this.c1FlexGridFeeDetails.Rows[rowIndex].Style = mystyle;
                    }
                }
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError(e.Message);
            }
        }

        #endregion

        #region 事件状态

        /// <summary>
        /// 状态字符串
        /// </summary>
        public class StatusString
        {
            /// <summary>
            /// 页面加载
            /// </summary>
            public const string LoadPage = "LoadPage";

            /// <summary>
            /// 查找患者
            /// </summary>
            public const string FindPatients = "FindPatients";
            public const string FindPatients_Success = "FindPatients_Success";

            /// <summary>
            /// 查询人员信息
            /// </summary>
            public const string QueryPersonInfo = "QueryPersonInfo";

            /// <summary>
            /// 正在读卡
            /// </summary>
            public const string ReadCard_ing = "ReadCard_ing";

            /// <summary>
            /// 正在查询已上传费用明细
            /// </summary>
            public const string QueryUploadedFeeDetails_ing = "QueryUploadedFeeDetails_ing";

            /// <summary>
            /// 查询成功已上传费用明细
            /// </summary>
            public const string QueryUploadedFeeDetails_success = "QueryUploadedFeeDetails_success";

            /// <summary>
            /// 查询失败已上传费用明细
            /// </summary>
            public const string QueryUploadedFeeDetails_failure = "QueryUploadedFeeDetails_failure";

            /// <summary>
            /// 正在计算住院费用
            /// </summary>
            public const string CalcFeeDetails_ing = "CalcFeeDetails_ing";

            /// <summary>
            /// 计算住院费用信息成功
            /// </summary>
            public const string CalcFeeDetails_success = "CalcFeeDetails_success";

            /// <summary>
            /// 计算住院费用信息失败
            /// </summary>
            public const string CalcFeeDetails_failure = "CalcFeeDetails_failure";

            /// <summary>
            /// 正在保存住院费用信息
            /// </summary>
            public const string SaveFeeDetails_ing = "SaveFeeDetails_ing";

            /// <summary>
            /// 保存住院费用信息成功
            /// </summary>
            public const string SaveFeeDetails_success = "SaveFeeDetails_success";

            /// <summary>
            /// 保存住院费用信息失败
            /// </summary>
            public const string SaveFeeDetails_failure = "SaveFeeDetails_failure";

            /// <summary>
            /// 清空费用明细
            /// </summary>
            public const string ClearFeeDetails = "ClearFeeDetails";

            /// <summary>
            /// 删除已上传费用明细
            /// </summary>
            public const string DeleteUploadedFeeDetails = "DeleteUploadedFeeDetails";

            /// <summary>
            /// 
            /// </summary>
            public const string CheckAndSaveUploadedFeeDetails = "CheckAndSaveUploadedFeeDetails";
        }

        #endregion

        #region 事件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindPatient_Click(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusString.FindPatients;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_FeeDetails_Load(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusString.LoadPage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCard_Click(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusString.ReadCard_ing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusString.QueryUploadedFeeDetails_ing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusString.CalcFeeDetails_ing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusString.SaveFeeDetails_ing;
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
        private void ToolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusString.ClearFeeDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusString.DeleteUploadedFeeDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusString.CheckAndSaveUploadedFeeDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFeeDetails_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.c1 == e.NewRange.c2 && e.NewRange.c1 == 11 || e.NewRange.c1 == 12)
            {
                this.c1FlexGridFeeDetails.AllowEditing = true;
            }
            else
            {
                this.c1FlexGridFeeDetails.AllowEditing = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFeeDetails_ValidateEdit(object sender, ValidateEditEventArgs e)
        {
            int rowIndex = e.Row;
            int colIndex = e.Col;

            if (colIndex == 11 || colIndex == 12)
            {
                double result = 0;

                bool value = double.TryParse(this.c1FlexGridFeeDetails.Editor.Text.Trim(), out result);

                if (!value)
                {
                    e.Cancel = !value;
                    CommonFunctions.MsgError("输入的内容不能是除数字之外的其他字符！！！");
                }
                else
                {
                    this.c1FlexGridFeeDetails.Editor.Text = double.Parse(this.c1FlexGridFeeDetails.Editor.Text.Trim()).ToString("0.0000");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFeeDetails_AfterEdit(object sender, RowColEventArgs e)
        {
            int rowIndex = e.Row;
            int colIndex = e.Col;

            if (this.c1FlexGridFeeDetails.Cols.Contains("medi_item_type"))
            {
                double dosage = double.Parse(this.c1FlexGridFeeDetails.Rows[rowIndex]["dosage"].ToString().Trim());//用量
                double price = double.Parse(this.c1FlexGridFeeDetails.Rows[rowIndex]["price"].ToString().Trim());//单价

                this.c1FlexGridFeeDetails.Rows[rowIndex]["dosage"] = dosage.ToString("0.0000");
                this.c1FlexGridFeeDetails.Rows[rowIndex]["price"] = price.ToString("0.0000");

                this.c1FlexGridFeeDetails.Rows[rowIndex]["money"] = (dosage * price).ToString("0.00");//金额
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDelFeeDetails_Click(object sender, EventArgs e)
        {
            int rowIndex = this.c1FlexGridFeeDetails.RowSel;

            if (rowIndex > 0 && this.c1FlexGridFeeDetails.Cols.Contains("medi_item_type"))
            {
                this.c1FlexGridFeeDetails.RemoveItem(rowIndex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemAddFeeDetails_Click(object sender, EventArgs e)
        {
            if (!this.c1FlexGridFeeDetails.Cols.Contains("medi_item_type"))
            {
                CommonFunctions.MsgError("请先读卡！！！");
                return;
            }

            Frm_AddFeeDetails frm = new Frm_AddFeeDetails();

            frm.ShowDialog();

            string ID = frm.ID;

            frm = null;

            if (ID == string.Empty)
            {
                return;
            }

            DataTable dt = GetMatchInfo(ID);

            if (dt != null)
            {

                List<Parameter> listParameter = new List<Parameter>();

                foreach (DataColumn dc in dt.Columns)
                {
                    listParameter.Add(new Parameter(dc.ColumnName, dt.Rows[0][dc.ColumnName].ToString().Trim()));
                }

                this.c1FlexGridFeeDetails.Rows.Add();

                foreach (Parameter p in listParameter)
                {
                    this.c1FlexGridFeeDetails.Rows[this.c1FlexGridFeeDetails.Rows.Count - 1][p.Name] = p.Value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private DataTable GetMatchInfo(string ID)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat(@"SELECT  CASE match_type
                                              WHEN 0 THEN '诊疗项目'
                                              WHEN 1 THEN '西药'
                                              WHEN 2 THEN '中成药'
                                              WHEN 3 THEN '中草药'
                                            END 'medi_item_type' ,
                                        '' AS 'stat_type' ,
                                        hosp_code AS 'his_item_code' ,
                                        item_code AS 'item_code' ,
                                        hosp_name AS 'his_item_name' ,
                                        hosp_model AS 'model' ,
                                        '' AS 'factory' ,
                                        '' AS 'standard' ,
                                        CONVERT(CHAR(20), GETDATE(), 120) AS 'fee_date' ,
                                        '' AS 'unit' ,
                                        '0.0000' AS 'price' ,
                                        '0.0000' AS 'dosage' ,
                                        '0.00' AS 'money' ,
                                        '0' AS 'usage_flag' ,
                                        '' AS 'usage_days' ,
                                        '' AS 'opp_serial_fee' ,
                                        '' AS 'hos_serial' ,
                                        '' AS 'remark' ,
                                        '' AS 'serial_apply' ,
                                        '' AS 'make_flag'
                                FROM    HIS_InterfaceHN.dbo.Interface_AddMatch
                                WHERE   id = N'{0}'", ID);

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(sb.ToString());

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("通过编号" + ID + "获取匹配信息发生错误，错误原因：" + ex.Message);
                return null;
            }
        }

        #endregion
    }
}