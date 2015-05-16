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
using System.Data.SqlClient;
using C1.Win.C1FlexGrid;

namespace Windows.MZ
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_MZ_Charge : BaseForm
    {
        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        private string _mzRegID = string.Empty;

        /// <summary>
        /// 社保卡号
        /// </summary>
        private string _indi_id = string.Empty;

        /// <summary>
        /// 发票编号
        /// </summary>
        private string _fpID = string.Empty;

        /// <summary>
        /// 患者一卡通号
        /// </summary>
        private string _patientCardNumbers = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private string _patientLSH = string.Empty;

        private string _patientName = string.Empty;
        private string _patientSex = string.Empty;
        private string _patientAge = string.Empty;

        /// <summary>
        /// 疾病诊断编码
        /// </summary>
        private string _diseaseicd = string.Empty;

        /// <summary>
        /// 疾病诊断名称
        /// </summary>
        private string _diseasename = string.Empty;

        /// <summary>
        /// 查找患者获取的患者信息
        /// </summary>
        private List<Parameter> _listPatientInfo = null;

        /// <summary>
        /// 鼠标选择的行号
        /// </summary>
        private int _mouseSelectedRowIndex = 0;
        private int _selectedFeeDetailsRowIndex = 0;

        /// <summary>
        /// 
        /// </summary>
        private InterfaceClass.HN.MZ.MZRegCharge _mzRegChargeMainParameter = null;

        /// <summary>
        /// 费用明细参数
        /// </summary>
        private List<InterfaceClass.HN.MZ.FeeInfo> _listMZRegFeeInfoParameter = null;

        /// <summary>
        /// 
        /// </summary>
        private List<InterfaceClass.HN.MZ.FeeInfo> _listFeeInfo = null;

        /// <summary>
        /// 就医登记号
        /// </summary>
        private string _serial_no = string.Empty;

        /// <summary>
        /// 总费用
        /// </summary>
        private string _totalFee = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userID"></param>
        public Frm_MZ_Charge(long userID)
        {
            InitializeComponent();

            this._userID = userID;

            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MZ_Charge_Load(object sender, EventArgs e)
        {
            QueryAndSetUserInfo();

            ClearPersonInfo();
            SetPersonInfoReadOnly(true);

            ClearPatientInfo();
            SetPatientInfoReadOnly(true);

            ClearFeeInfo();

            SetC1FlexGridDefaultAttribute(this.c1FlexGridFeeList);
            SetC1FlexGridDefaultAttribute(this.c1FlexGridJJ);

            SetC1FlexGridRowBackGroundColor();

            EnabledOperButton(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        private void EnabledOperButton(bool flag)
        {
            this.btnTryCharge.Enabled = flag;
            this.btnCharge.Enabled = flag;
            this.btnPrint.Enabled = false;
            this.btndiagnose.Enabled = flag;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetC1FlexGridRowBackGroundColor()
        {
            this.c1FlexGridFeeList.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;

            this.c1FlexGridFeeList.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(
                delegate(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
                {
                    if (e.Row >= this.c1FlexGridFeeList.Rows.Fixed)
                    {
                        //SetRowBackground(e.Row);
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
                if (this.c1FlexGridFeeList.Cols.Contains("item_code"))
                {

                    string item_code = this.c1FlexGridFeeList.Rows[rowIndex]["item_code"].ToString().Trim();

                    Color color;
                    CellStyle mystyle;
                    string name = string.Empty;

                    switch (item_code)
                    {
                        //甲类
                        case "":
                            color = Color.OrangeRed;
                            name = "MyStyleOrangeRed";
                            break;
                        default:
                            color = Color.White;
                            //name = "MyStyleWhite";
                            break;
                    }

                    if (name != string.Empty)
                    {
                        mystyle = this.c1FlexGridFeeList.Styles.Add(name);
                        mystyle.BackColor = color;
                        this.c1FlexGridFeeList.Rows[rowIndex].Style = mystyle;
                    }
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
        private void btnReadCard_Click(object sender, EventArgs e)
        {
            Frm_ReadCard frm = new Frm_ReadCard(this._userID);

            frm.ShowDialog();

            this._indi_id = frm.CardNumbers;//个人电脑号
            //this._indi_id = "11027437";

            frm = null;

            ClearPersonInfo();

            if (this._indi_id == string.Empty)
            {
                return;
            }

            this.txtBoxindi_id.Text = this._indi_id;

            EnabledOperButton(false);

            CreateAndStartThread(this._thread, ThreadQueryPersonInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindPatient_Click(object sender, EventArgs e)
        {
            EnabledOperButton(false);

            Frm_FindPatients frm = new Frm_FindPatients(0);

            frm.ShowDialog();

            this._listPatientInfo = frm.ListReturnParameter;

            frm = null;

            CheckAndSetPatientInfo();

            GetFeeDetails();
        }

        /// <summary>
        /// 获取费用明细信息
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

            SendUIMsg(MZ_ChargeUIMsg.BindFeeDetails, this._listFeeInfo);
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

                this._listFeeInfo = new List<InterfaceClass.HN.MZ.FeeInfo>();

                SendUIMsg(UIMsg.Display, "正在查询项目编号对应的医院项目编码，请稍后......");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    string id = dr["项目编号"].ToString().Trim();

                    SendUIMsg(UIMsg.WriteMsg, string.Format("正在查询项目编号：{0}的医院项目编码，请稍后......", id));

                    string his_item_code = GetHISItemCode(id);

                    if (his_item_code == string.Empty)
                    {
                        throw new Exception(string.Format("项目编号{0}对应的医院项目编码{1}不能为空！！！", id, his_item_code));
                    }

                    SendUIMsg(UIMsg.WriteMsg, string.Format("成功获取项目编号：{0}的医院项目编码：{1}！！！", id, his_item_code));

                    string name = dr["医院药品项目名称"].ToString().Trim();

                    InterfaceClass.HN.MZ.FeeInfo feeInfo = GetFeeDetailBy_his_item_code(his_item_code, name);

                    feeInfo.fee_date = dr["费用发生时间"].ToString();
                    feeInfo.price = dr["单价"].ToString();
                    feeInfo.dosage = dr["用量"].ToString();
                    feeInfo.money = dr["金额"].ToString();
                    feeInfo.input_staff = this._userID.ToString();
                    feeInfo.input_man = this._userName;
                    feeInfo.input_date = dr["费用发生时间"].ToString();

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
        private InterfaceClass.HN.MZ.FeeInfo GetFeeDetailBy_his_item_code(string his_item_code, string name)
        {
            try
            {
                InterfaceClass.HN.MZ.FeeInfo feeInfo = new InterfaceClass.HN.MZ.FeeInfo();

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
                    feeInfo.recipe_no = ds.Tables[0].Rows[0]["recipe_no"].ToString().Trim();
                    feeInfo.doctor_no = ds.Tables[0].Rows[0]["doctor_no"].ToString().Trim();
                    feeInfo.doctor_name = ds.Tables[0].Rows[0]["doctor_name"].ToString().Trim();
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
        /// <param name="p"></param>
        private void BindFeeDetails(object p)
        {
            if (((List<InterfaceClass.HN.MZ.FeeInfo>)p).Count <= 0)
            {
                return;
            }

            foreach (InterfaceClass.HN.MZ.FeeInfo feeInfo in (List<InterfaceClass.HN.MZ.FeeInfo>)p)
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

            DataTable dt = TToDataTable<InterfaceClass.HN.MZ.FeeInfo>((List<InterfaceClass.HN.MZ.FeeInfo>)p);

            this.c1FlexGridFeeList.DataSource = dt;

            this.c1FlexGridFeeList.Cols["stat_type"].Visible = false;
            this.c1FlexGridFeeList.Cols["model"].Visible = false;
            this.c1FlexGridFeeList.Cols["factory"].Visible = false;
            this.c1FlexGridFeeList.Cols["standard"].Visible = false;
            this.c1FlexGridFeeList.Cols["usage_days"].Visible = false;
            this.c1FlexGridFeeList.Cols["opp_serial_fee"].Visible = false;
            this.c1FlexGridFeeList.Cols["hos_serial"].Visible = false;
            this.c1FlexGridFeeList.Cols["recipe_no"].Visible = false;
            this.c1FlexGridFeeList.Cols["doctor_no"].Visible = false;
            this.c1FlexGridFeeList.Cols["doctor_name"].Visible = false;
            this.c1FlexGridFeeList.Cols["usage_flag"].Visible = false;
            this.c1FlexGridFeeList.Cols["input_staff"].Visible = false;
            this.c1FlexGridFeeList.Cols["input_man"].Visible = false;
            this.c1FlexGridFeeList.Cols["input_date"].Visible = false;

            this.c1FlexGridFeeList.Cols["medi_item_type"].Width = 80;
            this.c1FlexGridFeeList.Cols["his_item_code"].Width = 110;
            this.c1FlexGridFeeList.Cols["item_code"].Width = 110;
            this.c1FlexGridFeeList.Cols["his_item_name"].Width = 210;
            this.c1FlexGridFeeList.Cols["fee_date"].Width = 120;
            this.c1FlexGridFeeList.Cols["unit"].Width = 55;
            this.c1FlexGridFeeList.Cols["price"].Width = 70;
            this.c1FlexGridFeeList.Cols["dosage"].Width = 70;
            this.c1FlexGridFeeList.Cols["money"].Width = 70;
            this.c1FlexGridFeeList.Cols["usage_flag"].Width = 60;
            this.c1FlexGridFeeList.Cols["input_staff"].Width = 60;
            this.c1FlexGridFeeList.Cols["input_man"].Width = 80;
            this.c1FlexGridFeeList.Cols["input_date"].Width = 120;

            WriteDianoise();
        }

        /// <summary>
        /// 
        /// </summary>
        private void WriteDianoise()
        {
            this.btndiagnose.Enabled = true;
            this.btndiagnose.PerformClick();
        }

        /// <summary>
        /// 检查和设置查找患者获取的患者信息
        /// </summary>
        private void CheckAndSetPatientInfo()
        {
            ClearFeeInfo();
            ClearPatientInfo();
            SetC1FlexGridNullDataTable(this.c1FlexGridFeeList);

            if (this._listPatientInfo == null)
            {
                this._fpID = string.Empty;
                this._patientCardNumbers = string.Empty;
                this._patientLSH = string.Empty;

                //CommonFunctions.MsgError("通过查找患者获取的患者信息为空，请重新查找患者！！！");
                return;
            }

            try
            {
                foreach (Parameter parameter in this._listPatientInfo)
                {
                    switch (parameter.Name)
                    {
                        case "发票流水号":
                            this.txtBoxPatientFPID.Text = this._fpID = parameter.Value;
                            break;
                        case "卡号":
                            this.lblPatientCardNumbers.Text = this._patientCardNumbers = parameter.Value;
                            break;
                        case "患者姓名":
                            this.txtBoxPatientName.Text = parameter.Value;
                            break;
                        case "性别":
                            this.txtBoxPatientSex.Text = parameter.Value;
                            break;
                        case "年龄":
                            this.txtBoxPatientAge.Text = parameter.Value;
                            break;
                        case "患者流水号":
                            this._patientLSH = parameter.Value;
                            break;
                        default:
                            break;
                    }
                }

                GetDiagnose();
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("检查和设置查找患者获取的患者信息发生错误，请联系管理员，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 获取诊断信息
        /// </summary>
        private void GetDiagnose()
        {
            try
            {
                IDataParameter[] parameter = new IDataParameter[3];

                parameter[0] = new SqlParameter("@PatientCardNumbers", this._patientCardNumbers);
                parameter[1] = new SqlParameter("@FPID", this._fpID);
                parameter[2] = new SqlParameter("@PatientLSH", this._patientLSH);

                DataSet ds = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_GetPatientDiagnose", parameter, "P_GetPatientDiagnose");

                if (ds.Tables.Count != 4)
                {
                    throw new Exception(string.Format(@"通过一卡通号：{0}、发票流水号：{1}和患者流水号：{2}获取的诊断信息错误", this._patientCardNumbers, this._fpID, this._patientLSH));
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.txtBoxdiagnose_date.Text = ds.Tables[0].Rows[0]["录入时间"].ToString().Trim();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    this.txtBoxdoctor_no.Text = ds.Tables[1].Rows[0]["医生编号"].ToString().Trim();
                    this.txtBoxdoctor_name.Text = ds.Tables[1].Rows[0]["医生姓名"].ToString().Trim();
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    this._diseaseicd = ds.Tables[2].Rows[0]["ICD"].ToString().Trim();
                    this._diseasename = ds.Tables[2].Rows[0]["诊断"].ToString().Trim();
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    this.lblCurrentFee.Text = this.lblTotalFee.Text = ds.Tables[3].Rows[0]["金额"].ToString().Trim();
                    this.lblJJFee.Text = "0";
                    this.lblCashFee.Text = "0";
                    this.lblGetFee.Text = "0";
                    this.lblOutFee.Text = "0";
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("获取诊断信息发生错误，请联系管理员，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 线程查询人员信息
        /// </summary>
        private void ThreadQueryPersonInfo()
        {
            SendUIMsg(MZ_ChargeUIMsg.DisabledReadCard);

            QueryPersonInfo();

            SendUIMsg(MZ_ChargeUIMsg.EnableReadCard);
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryPersonInfo()
        {
            try
            {
                SendUIMsg(UIMsg.Display, string.Format("正在查询个人电脑号：{0}的人员信息，请稍后......", this._indi_id));

                InterfaceClass.HN.MZ.GetPersonInfoByFlag getPersonInfoByFlag = new InterfaceClass.HN.MZ.GetPersonInfoByFlag(baseInterfaceHN);

                List<InterfaceClass.HN.MZ.PersonInfo> listPersonInfo = getPersonInfoByFlag.GetPersonInfoByindi_id(this._indi_id, baseInterfaceHN.Oper_hospitalid, "11", baseInterfaceHN.Oper_centerid);

                if (listPersonInfo.Count == 1)
                {
                    SendUIMsg(MZ_ChargeUIMsg.SetPersonInfoObject, listPersonInfo[0]);

                    SendUIMsg(UIMsg.Close);
                    return;
                }

                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, string.Format("个人电脑号：{0}获取的人员信息含有{1}条记录，请联系管理员！！！", this._indi_id, listPersonInfo.Count));
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void SetPersonInfoObject(object p)
        {
            try
            {
                InterfaceClass.HN.MZ.PersonInfo personInfo = (InterfaceClass.HN.MZ.PersonInfo)p;

                this.txtBoxindi_id.Text = personInfo.indi_id;
                this.txtBoxname.Text = personInfo.name;
                this.txtBoxsex.Text = personInfo.sex;
                this.txtBoxidcard.Text = personInfo.idcard;
                this.txtBoxbirthday.Text = personInfo.birthday;
                this.txtBoxpers_name.Text = personInfo.pers_name;
                this.txtBoxofficial_name.Text = personInfo.official_name;
                this.txtBoxindi_sta_name.Text = personInfo.indi_sta_name;
                this.txtBoxtelephone.Text = personInfo.telephone;
                this.txtBoxcorp_name.Text = personInfo.corp_name;
                this.txtBoxcenter_name.Text = personInfo.center_name;
                this.lbllast_balance.Text = personInfo.last_balance;
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("设置人员信息失败，失败原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 设置人员信息只读
        /// </summary>
        /// <param name="flag"></param>
        private void SetPersonInfoReadOnly(bool flag)
        {
            this.txtBoxin_disease_name.ReadOnly = flag;
            this.txtBoxname.ReadOnly = flag;
            this.txtBoxsex.ReadOnly = flag;
            this.txtBoxidcard.ReadOnly = flag;
            this.txtBoxbirthday.ReadOnly = flag;
            this.txtBoxpers_name.ReadOnly = flag;
            this.txtBoxofficial_name.ReadOnly = flag;
            this.txtBoxindi_sta_name.ReadOnly = flag;
            this.txtBoxtelephone.ReadOnly = flag;
            this.txtBoxcorp_name.ReadOnly = flag;
            this.txtBoxcenter_name.ReadOnly = flag;
            this.txtBoxindi_id.ReadOnly = flag;
        }

        /// <summary>
        /// 设置患者信息只读
        /// </summary>
        /// <param name="flag"></param>
        private void SetPatientInfoReadOnly(bool flag)
        {
            this.txtBoxrecipe_no.ReadOnly = flag;
            this.txtBoxdoctor_name.ReadOnly = flag;
            this.txtBoxdoctor_no.ReadOnly = flag;
            this.txtBoxdiagnose_date.ReadOnly = flag;
            this.txtBoxserial_no.ReadOnly = flag;
            this.txtBoxPatientFPID.ReadOnly = flag;
            this.txtBoxPatientName.ReadOnly = flag;
            this.txtBoxPatientSex.ReadOnly = flag;
            this.txtBoxPatientAge.ReadOnly = flag;
        }

        /// <summary>
        /// 清空患者信息
        /// </summary>
        private void ClearPatientInfo()
        {
            this.txtBoxin_disease_name.Tag = "";
            this.txtBoxin_disease_name.Clear();
            this.txtBoxrecipe_no.Clear();
            this.txtBoxdoctor_name.Clear();
            this.txtBoxdoctor_no.Clear();
            this.txtBoxdiagnose_date.Clear();
            this.txtBoxserial_no.Clear();
            this.txtBoxPatientFPID.Clear();
            this.txtBoxPatientName.Clear();
            this.txtBoxPatientSex.Clear();
            this.txtBoxPatientAge.Clear();
            this.lblPatientCardNumbers.Text = string.Empty;
        }

        /// <summary>
        /// 清空人员信息
        /// </summary>
        private void ClearPersonInfo()
        {
            this.txtBoxindi_id.Text = string.Empty;
            this.txtBoxname.Text = string.Empty;
            this.txtBoxsex.Text = string.Empty;
            this.txtBoxidcard.Text = string.Empty;
            this.txtBoxbirthday.Text = string.Empty;
            this.txtBoxpers_name.Text = string.Empty;
            this.txtBoxofficial_name.Text = string.Empty;
            this.txtBoxindi_sta_name.Text = string.Empty;
            this.txtBoxtelephone.Text = string.Empty;
            this.txtBoxcorp_name.Text = string.Empty;
            this.txtBoxcenter_name.Text = string.Empty;
            this.lblICCard.Text = string.Empty;
            this.lbllast_balance.Text = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearFeeInfo()
        {
            this.lblTotalFee.Text = string.Empty;
            this.lblCurrentFee.Text = string.Empty;
            this.lblJJFee.Text = string.Empty;
            this.lblCashFee.Text = string.Empty;
            this.lblGetFee.Text = string.Empty;
            this.lblOutFee.Text = string.Empty;
        }

        #region 试算与收费

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTryCharge_Click(object sender, EventArgs e)
        {
            this._patientName = this.txtBoxPatientName.Text.Trim();
            this._patientSex = this.txtBoxPatientSex.Text.Trim();
            this._patientAge = this.txtBoxPatientAge.Text.Trim();

            if (InitMZRegChargeMainParameters() && InitFeeDetailsParameters())
            {
                CreateAndStartThread(this._thread, ThreadTryCharge);
            }
        }

        /// <summary>
        /// 初始化费用明细参数
        /// </summary>
        /// <returns></returns>
        private bool InitFeeDetailsParameters()
        {
            try
            {
                DataTable dt = (DataTable)this.c1FlexGridFeeList.DataSource;
                if (this._listMZRegFeeInfoParameter != null)
                {
                    this._listMZRegFeeInfoParameter.Clear();
                    this._listMZRegFeeInfoParameter = null;
                }

                foreach (DataRow dr in dt.Rows)
                {
                    InterfaceClass.HN.MZ.FeeInfo feeInfo = new InterfaceClass.HN.MZ.FeeInfo();

                    feeInfo.medi_item_type = dr["medi_item_type"].ToString().Trim();

                    if (feeInfo.medi_item_type == string.Empty)
                    {
                        CommonFunctions.MsgError("【项目药品类型】不能为空！！！");
                        return false;
                    }

                    feeInfo.stat_type = dr["stat_type"].ToString().Trim();

                    feeInfo.his_item_code = feeInfo.item_code = dr["item_code"].ToString().Trim();

                    if (feeInfo.item_code == string.Empty)
                    {
                        CommonFunctions.MsgError("【中心药品项目编码】不能为空！！！");
                        return false;
                    }

                    feeInfo.his_item_name = feeInfo.his_item_name = dr["his_item_name"].ToString().Trim();

                    feeInfo.model = dr["model"].ToString().Trim();
                    feeInfo.factory = dr["factory"].ToString().Trim();
                    feeInfo.standard = dr["standard"].ToString().Trim();
                    feeInfo.fee_date = dr["fee_date"].ToString().Trim();

                    if (feeInfo.fee_date == string.Empty)
                    {
                        CommonFunctions.MsgError("【费用发生时间】不能为空！！！");
                        return false;
                    }

                    feeInfo.unit = dr["unit"].ToString().Trim();
                    feeInfo.price = dr["price"].ToString().Trim();

                    if (feeInfo.price == string.Empty)
                    {
                        CommonFunctions.MsgError("【单价】不能为空！！！");
                        return false;
                    }

                    feeInfo.dosage = dr["dosage"].ToString().Trim();

                    if (feeInfo.dosage == string.Empty)
                    {
                        CommonFunctions.MsgError("【用量】不能为空！！！");
                        return false;
                    }

                    feeInfo.money = dr["money"].ToString().Trim();

                    if (feeInfo.money == string.Empty)
                    {
                        CommonFunctions.MsgError("【金额】不能为空！！！");
                        return false;
                    }

                    feeInfo.usage_flag = dr["usage_flag"].ToString().Trim();
                    feeInfo.usage_days = dr["usage_days"].ToString().Trim();
                    feeInfo.opp_serial_fee = dr["opp_serial_fee"].ToString().Trim();
                    feeInfo.hos_serial = dr["hos_serial"].ToString().Trim();
                    feeInfo.input_staff = dr["input_staff"].ToString().Trim();

                    if (feeInfo.input_staff == string.Empty)
                    {
                        CommonFunctions.MsgError("【录入人工号】不能为空！！！");
                        return false;
                    }

                    feeInfo.input_man = dr["input_man"].ToString().Trim();

                    if (feeInfo.input_man == string.Empty)
                    {
                        CommonFunctions.MsgError("【录入人】不能为空！！！");
                        return false;
                    }

                    feeInfo.input_date = dr["input_date"].ToString().Trim();

                    if (feeInfo.input_date == string.Empty)
                    {
                        CommonFunctions.MsgError("【录入日期】不能为空！！！");
                        return false;
                    }

                    feeInfo.recipe_no = dr["recipe_no"].ToString().Trim();
                    feeInfo.doctor_no = dr["doctor_no"].ToString().Trim();
                    feeInfo.doctor_name = dr["doctor_name"].ToString().Trim();

                    switch (feeInfo.medi_item_type.Trim())
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
                        default:
                            throw new Exception(string.Format("请将【医院项目编码：{0}、医院药品项目名称：{1}】进行目录对照之后再进行此操作！！！",
                                dr["his_item_code"].ToString().Trim(), dr["his_item_name"].ToString().Trim()));
                    }

                    if (this._listMZRegFeeInfoParameter == null)
                    {
                        this._listMZRegFeeInfoParameter = new List<InterfaceClass.HN.MZ.FeeInfo>();
                    }

                    this._listMZRegFeeInfoParameter.Add(feeInfo);
                }

                return true;
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 初始化主参数
        /// </summary>
        private bool InitMZRegChargeMainParameters()
        {
            try
            {
                this._mzRegChargeMainParameter = null;

                this._mzRegChargeMainParameter = new InterfaceClass.HN.MZ.MZRegCharge();

                this._mzRegChargeMainParameter.center_id = baseInterfaceHN.Oper_centerid;
                this._mzRegChargeMainParameter.hospital_id = baseInterfaceHN.Oper_hospitalid;
                this._mzRegChargeMainParameter.indi_id = this._indi_id;

                if (this._indi_id == string.Empty)
                {
                    CommonFunctions.MsgError("没有获取到患者个人电脑号，请重新读卡！！！");
                    return false;
                }

                this._mzRegChargeMainParameter.biz_type = "11";
                this._mzRegChargeMainParameter.treatment_type = "110";
                this._mzRegChargeMainParameter.reg_staff = this._userID.ToString();
                this._mzRegChargeMainParameter.reg_man = this._userName;
                this._mzRegChargeMainParameter.diagnose_date = this.txtBoxdiagnose_date.Text.Trim();

                this._mzRegChargeMainParameter.diagnose = this.txtBoxin_disease_name.Tag.ToString().Trim();
                if (this._mzRegChargeMainParameter.diagnose == string.Empty)
                {
                    CommonFunctions.MsgError("登记诊断不能为空！！！");
                    this.btndiagnose.PerformClick();
                    return false;
                }

                this._mzRegChargeMainParameter.in_disease_name = this.txtBoxin_disease_name.Text.Trim();
                if (this._mzRegChargeMainParameter.in_disease_name == string.Empty)
                {
                    CommonFunctions.MsgError("登记诊断名称不能为空！！！");
                    this.btndiagnose.PerformClick();
                    return false;
                }

                this._mzRegChargeMainParameter.last_balance = this.lblTotalFee.Text.Trim();
                if (this._mzRegChargeMainParameter.last_balance == string.Empty)
                {
                    CommonFunctions.MsgError("个人帐户支付金额不能为空！！！");
                    return false;
                }

                this._mzRegChargeMainParameter.injury_borth_sn = "";
                this._mzRegChargeMainParameter.recipe_no = "";
                this._mzRegChargeMainParameter.doctor_no = "";
                this._mzRegChargeMainParameter.doctor_name = "";
                this._mzRegChargeMainParameter.note = "";
                this._mzRegChargeMainParameter.serial_apply = "";
                this._mzRegChargeMainParameter.bill_no = "";
                this._mzRegChargeMainParameter.fact_idcard = "";
                this._mzRegChargeMainParameter.query_flag = "0";

                return true;
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("初始化普通门诊正常收费主参数失败，失败原因：" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 线程试算
        /// </summary>
        private void ThreadTryCharge()
        {
            SendUIMsg(MZ_ChargeUIMsg.DisabledTryCharge);

            try
            {
                SendUIMsg(UIMsg.Display, "正在努力进行普通门诊试算操作，请稍后......");

                SaveMZRegChargeMainParameter();
                SaveMZRegFeeInfoParameter(0);
                SaveMZRegHISInfo();

                SendUIMsg(UIMsg.WriteMsg, "正在往中心努力上传数据，请稍后......");

                InterfaceClass.HN.MZ.CheckAndSaveFeeDetails checkAndSaveFeeDetails = new InterfaceClass.HN.MZ.CheckAndSaveFeeDetails(baseInterfaceHN);

                InterfaceClass.HN.MZ.MZ_ChargeParameter parameter = new InterfaceClass.HN.MZ.MZ_ChargeParameter(this._mzRegChargeMainParameter, this._listMZRegFeeInfoParameter);

                this._mzRegChargeMainParameter.save_flag = "0";//试算

                InterfaceClass.HN.MZ.MZRegOutParameter mz_ChargeOutParameter = checkAndSaveFeeDetails.CheckCalcAndSaveWrittenFeeDetails(parameter);

                SaveMZRegBizInfo(0, mz_ChargeOutParameter.BizInfo);
                SaveMZRegPayInfo(0, mz_ChargeOutParameter.ListPayInfo);

                DataTable dt = TToDataTable<InterfaceClass.HN.MZ.PayInfo>(mz_ChargeOutParameter.ListPayInfo);
                SendUIMsg(MZ_ChargeUIMsg.BindPayInfo, dt);

                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgInfo, "试算成功！！！");
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "普通门诊试算发生错误，错误原因：" + ex.Message);
            }

            SendUIMsg(MZ_ChargeUIMsg.EnableTryCharge);
        }

        /// <summary>
        /// 保存普通门诊收费对应的HIS信息
        /// </summary>
        private void SaveMZRegHISInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"INSERT  INTO [HIS_InterfaceHN].[dbo].[MZRegHISInfo]
                                                ( [MZRegID] ,
                                                  [CardNumbers] ,
                                                  [FPID] ,
                                                  [PatientLSH] ,
                                                  [PatientName] ,
                                                  [Sex] ,
                                                  [Age]
                                                )
                                        VALUES  ( N'{0}' ,--<MZRegID, bigint,>
                                                  N'{1}' ,--<CardNumbers, nvarchar(50),>
                                                  N'{2}' ,--<FPID, bigint,>
                                                  N'{3}' ,--<PatientLSH, nvarchar(50),>
                                                  N'{4}' ,--<PatientName, nvarchar(50),>
                                                  N'{5}' ,--<Sex, nvarchar(2),>
                                                  N'{6}'--<Age, nvarchar(10),>
                                                )", this._mzRegID, this._patientCardNumbers, this._fpID, this._patientLSH, this._patientName, this._patientSex, this._patientAge);

            Alif.DBUtility.DbHelperSQL.ExecuteSql(sb.ToString());
        }

        /// <summary>
        /// 收费
        /// </summary>
        private void ThreadCharge()
        {
            try
            {
                SendUIMsg(MZ_ChargeUIMsg.DisabledCharge);

                SendUIMsg(UIMsg.Display, "正在努力进行普通门诊收费操作，请稍后......");

                SaveMZRegChargeMainParameter();
                SaveMZRegFeeInfoParameter(1);
                SaveMZRegHISInfo();

                SendUIMsg(UIMsg.WriteMsg, "正在往中心努力上传数据，请稍后......");

                InterfaceClass.HN.MZ.CheckAndSaveFeeDetails checkAndSaveFeeDetails = new InterfaceClass.HN.MZ.CheckAndSaveFeeDetails(baseInterfaceHN);

                InterfaceClass.HN.MZ.MZ_ChargeParameter parameter = new InterfaceClass.HN.MZ.MZ_ChargeParameter(this._mzRegChargeMainParameter, this._listMZRegFeeInfoParameter);

                this._mzRegChargeMainParameter.save_flag = "1";//收费

                InterfaceClass.HN.MZ.MZRegOutParameter mz_ChargeOutParameter = checkAndSaveFeeDetails.CheckCalcAndSaveWrittenFeeDetails(parameter);

                SaveMZRegBizInfo(1, mz_ChargeOutParameter.BizInfo);
                SaveMZRegPayInfo(1, mz_ChargeOutParameter.ListPayInfo);

                this._serial_no = mz_ChargeOutParameter.BizInfo.serial_no.ToString().Trim();

                DataTable dt = TToDataTable<InterfaceClass.HN.MZ.PayInfo>(mz_ChargeOutParameter.ListPayInfo);
                SendUIMsg(MZ_ChargeUIMsg.BindPayInfo, dt);

                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgInfo, "收费成功！！！");
                SendUIMsg(MZ_ChargeUIMsg.PrintOrder, mz_ChargeOutParameter.BizInfo);
            }
            catch (Exception ex)
            {
                SendUIMsg(MZ_ChargeUIMsg.EnableCharge);
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "普通门诊收费发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCharge_Click(object sender, EventArgs e)
        {
            this._patientName = this.txtBoxPatientName.Text.Trim();
            this._patientSex = this.txtBoxPatientSex.Text.Trim();
            this._patientAge = this.txtBoxPatientAge.Text.Trim();
            this._serial_no = string.Empty;

            if (InitMZRegChargeMainParameters() && InitFeeDetailsParameters())
            {
                CreateAndStartThread(this._thread, ThreadCharge);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="list"></param>
        private void SaveMZRegPayInfo(int flag, List<InterfaceClass.HN.MZ.PayInfo> list)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                foreach (InterfaceClass.HN.MZ.PayInfo payInfo in list)
                {
                    sb.AppendFormat(@"INSERT  INTO [HIS_InterfaceHN].[dbo].[MZRegPayInfo]
                                        ( [Type] ,
                                          [MZRegID] ,
                                          [fund_name] ,
                                          [real_pay]
                                        )
                                VALUES  ( N'{0}' ,--<Type, tinyint,>
                                          N'{1}' ,--<MZRegID, bigint,>
                                          N'{2}' ,--<fund_name, nvarchar(50),>
                                          N'{3}'--<real_pay, numeric(18,2),>
                                        )", flag, this._mzRegID, payInfo.fund_name, payInfo.real_pay);
                    sb.AppendLine();
                }

                Alif.DBUtility.DbHelperSQL.ExecuteSql(sb.ToString());
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="bizInfo"></param>
        private void SaveMZRegBizInfo(int flag, InterfaceClass.HN.MZ.BizInfo bizInfo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat(@"INSERT  INTO [HIS_InterfaceHN].[dbo].[MZRegBizInfo]
                                        ( [Type] ,
                                          [MZRegID] ,
                                          [serial_no]
                                        )
                                VALUES  ( N'{0}' ,--<Type, tinyint,>
                                          N'{1}' ,--<MZRegID, bigint,>
                                          N'{2}' --<serial_no, nvarchar(20),>
                                        )", flag, this._mzRegID, bizInfo.serial_no);

                Alif.DBUtility.DbHelperSQL.ExecuteSql(sb.ToString());
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveMZRegFeeInfoParameter(int flag)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                foreach (InterfaceClass.HN.MZ.FeeInfo feeInfo in this._listMZRegFeeInfoParameter)
                {
                    sb.AppendFormat(@"INSERT INTO [HIS_InterfaceHN].[dbo].[MZRegFeeInfo]
                                   ([Type]
                                   ,[MZRegChargeID]
                                   ,[medi_item_type]
                                   ,[stat_type]
                                   ,[his_item_code]
                                   ,[item_code]
                                   ,[his_item_name]
                                   ,[model]
                                   ,[factory]
                                   ,[standard]
                                   ,[fee_date]
                                   ,[unit]
                                   ,[price]
                                   ,[dosage]
                                   ,[money]
                                   ,[usage_flag]
                                   ,[usage_days]
                                   ,[opp_serial_fee]
                                   ,[hos_serial]
                                   ,[input_staff]
                                   ,[input_man]
                                   ,[input_date]
                                   ,[recipe_no]
                                   ,[doctor_no]
                                   ,[doctor_name])
                             VALUES
                                   (N'{0}',--<Type, tinyint,>
                                   N'{1}',--<MZRegChargeID, bigint,>
                                   N'{2}',--<medi_item_type, char(1),>
                                   N'{3}',--<stat_type, nvarchar(3),>
                                   N'{4}',--<his_item_code, nvarchar(20),>
                                   N'{5}',--<item_code, nvarchar(20),>
                                   N'{6}',--<his_item_name, nvarchar(50),>
                                   N'{7}',--<model, nvarchar(30),>
                                   N'{8}',--<factory, nvarchar(50),>
                                   N'{9}',--<standard, nvarchar(30),>
                                   N'{10}',--<fee_date, datetime,>
                                   N'{11}',--<unit, nvarchar(10),>
                                   N'{12}',--<price, numeric(18,4),>
                                   N'{13}',--<dosage, numeric(18,4),>
                                   N'{14}',--<money, numeric(18,2),>
                                   N'{15}',--<usage_flag, char(1),>
                                   N'{16}',--<usage_days, nvarchar(3),>
                                   N'{17}',--<opp_serial_fee, nvarchar(12),>
                                   N'{18}',--<hos_serial, nvarchar(20),>
                                   N'{19}',--<input_staff, nvarchar(20),>
                                   N'{20}',--<input_man, nvarchar(30),>
                                   N'{21}',--<input_date, datetime,>
                                   N'{22}',--<recipe_no, nvarchar(20),>
                                   N'{23}',--<doctor_no, nvarchar(8),>
                                   N'{24}')--<doctor_name, nvarchar(10),>", flag, this._mzRegID, feeInfo.medi_item_type, feeInfo.stat_type, feeInfo.his_item_code,
                                                                    feeInfo.item_code, feeInfo.his_item_name, feeInfo.model, feeInfo.factory,
                                                                    feeInfo.standard, feeInfo.fee_date, feeInfo.unit, feeInfo.price, feeInfo.dosage,
                                                                    feeInfo.money, feeInfo.usage_flag, feeInfo.usage_days, feeInfo.opp_serial_fee,
                                                                    feeInfo.hos_serial, feeInfo.input_staff, feeInfo.input_man, feeInfo.input_date,
                                                                    feeInfo.recipe_no, feeInfo.doctor_no, feeInfo.doctor_name);
                    sb.AppendLine();
                }

                int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(sb.ToString());

                SendUIMsg("成功插入" + temp + "条数据！！！");
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        private void SaveMZRegChargeMainParameter()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat(@"INSERT INTO [HIS_InterfaceHN].[dbo].[MZRegCharge]
                               ([center_id]
                               ,[hospital_id]
                               ,[indi_id]
                               ,[biz_type]
                               ,[treatment_type]
                               ,[reg_staff]
                               ,[reg_man]
                               ,[diagnose_date]
                               ,[diagnose]
                               ,[in_disease_name]
                               ,[save_flag]
                               ,[last_balance]
                               ,[injury_borth_sn]
                               ,[recipe_no]
                               ,[doctor_no]
                               ,[doctor_name]
                               ,[note]
                               ,[serial_apply]
                               ,[bill_no]
                               ,[fact_idcard]
                               ,[query_flag]
                               ,[LoginUser]
                               ,[LoginTime])
                         VALUES
                               (N'{0}',--<center_id, nvarchar(10),>
                               N'{1}',--<hospital_id, nvarchar(20),>
                               N'{2}',--<indi_id, nvarchar(12),>
                               N'{3}',--<biz_type, nvarchar(2),>
                               N'{4}',--<treatment_type, nvarchar(3),>
                               N'{5}',--<reg_staff, nvarchar(5),>
                               N'{6}',--<reg_man, nvarchar(10),>
                               N'{7}',--<diagnose_date, datetime,>
                               N'{8}',--<diagnose, nvarchar(20),>
                               N'{9}',--<in_disease_name, nvarchar(50),>
                               N'{10}',--<save_flag, char(1),>
                               N'{11}',--<last_balance, nvarchar(50),>
                               N'{12}',--<injury_borth_sn, nvarchar(18),>
                               N'{13}',--<recipe_no, nvarchar(20),>
                               N'{14}',--<doctor_no, nvarchar(12),>
                               N'{15}',--<doctor_name, nvarchar(10),>
                               N'{16}',--<note, nvarchar(100),>
                               N'{17}',--<serial_apply, nvarchar(12),>
                               N'{18}',--<bill_no, nvarchar(18),>
                               N'{19}',--<fact_idcard, nvarchar(20),>
                               N'{20}',--<query_flag, char(1),>
                               N'{21}',--<LoginUser, nvarchar(50),>
                               GETDATE())--<LoginTime, datetime,>", this._mzRegChargeMainParameter.center_id, this._mzRegChargeMainParameter.hospital_id
                                                      , this._mzRegChargeMainParameter.indi_id, this._mzRegChargeMainParameter.biz_type
                                                      , this._mzRegChargeMainParameter.treatment_type, this._mzRegChargeMainParameter.reg_staff
                                                      , this._mzRegChargeMainParameter.reg_man, this._mzRegChargeMainParameter.diagnose_date
                                                      , this._mzRegChargeMainParameter.diagnose, this._mzRegChargeMainParameter.in_disease_name
                                                      , this._mzRegChargeMainParameter.save_flag, this._mzRegChargeMainParameter.last_balance
                                                      , this._mzRegChargeMainParameter.injury_borth_sn, this._mzRegChargeMainParameter.recipe_no
                                                      , this._mzRegChargeMainParameter.doctor_no, this._mzRegChargeMainParameter.doctor_name
                                                      , this._mzRegChargeMainParameter.note, this._mzRegChargeMainParameter.serial_apply
                                                      , this._mzRegChargeMainParameter.bill_no, this._mzRegChargeMainParameter.fact_idcard
                                                      , this._mzRegChargeMainParameter.query_flag, this._userName);
                sb.AppendLine();
                sb.AppendLine("select SCOPE_IDENTITY();");

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(sb.ToString());

                this._mzRegID = ds.Tables[0].Rows[0][0].ToString().Trim();
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// 更新UI控件内容
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
                    case MZ_ChargeUIMsg.DisabledReadCard:
                        this.btnReadCard.Enabled = false;
                        break;
                    case MZ_ChargeUIMsg.EnableReadCard:
                        this.btnReadCard.Enabled = true;
                        break;
                    case MZ_ChargeUIMsg.SetPersonInfoObject:
                        SetPersonInfoObject(parameter.Object);
                        break;
                    case MZ_ChargeUIMsg.BindFeeDetails:
                        BindFeeDetails(parameter.Object);
                        break;
                    case MZ_ChargeUIMsg.DisabledTryCharge:
                        this.btnTryCharge.Enabled = false;
                        break;
                    case MZ_ChargeUIMsg.EnableTryCharge:
                        this.btnTryCharge.Enabled = true;
                        break;
                    case MZ_ChargeUIMsg.DisabledCharge:
                        this.btnCharge.Enabled = false;
                        break;
                    case MZ_ChargeUIMsg.EnableCharge:
                        this.btnCharge.Enabled = true;
                        break;
                    case MZ_ChargeUIMsg.BindPayInfo:
                        BindPayInfo(parameter.Object);
                        break;
                    case MZ_ChargeUIMsg.PrintOrder:
                        PrintOrder(parameter.Object);
                        break;
                    case MZ_ChargeUIMsg.DisabledPrintButton:
                        this.btnPrint.Enabled = false;
                        break;
                    case MZ_ChargeUIMsg.EnabledPrintButton:
                        this.btnPrint.Enabled = true;
                        break;
                    case MZ_ChargeUIMsg.PrintOrderDataSet:
                        PrintOrderDataSet(parameter.Object);
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
        /// 打印单据
        /// </summary>
        /// <param name="p"></param>
        private void PrintOrder(object p)
        {
            this.btnPrint.Enabled = true;

            InterfaceClass.HN.MZ.BizInfo bizInfo = (InterfaceClass.HN.MZ.BizInfo)p;

            this._serial_no = bizInfo.serial_no;

            if (this.chBoxPrint.Checked)
            {
                CreateAndStartThread(this._thread, ThreadPrintOrder);
            }
        }

        /// <summary>
        /// 打印订单
        /// </summary>
        /// <param name="p"></param>
        private void PrintOrderDataSet(object p)
        {
            List<Parameter> listParameter = new List<Parameter>();

            listParameter.Add(new Parameter("userName", this._userName));

            string value = Rmb.CmycurD(this._totalFee);

            listParameter.Add(new Parameter("moneyUpper", value));

            Print("100001003", listParameter, (DataSet)p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial_no"></param>
        private void ThreadPrintOrder()
        {
            SendUIMsg(MZ_ChargeUIMsg.DisabledPrintButton);
            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器获取【" + this._serial_no + "】门诊结算单，请稍后......");

                InterfaceClass.HN.BusCostInfo.MZOrders.MZOrders mzOrders = new InterfaceClass.HN.BusCostInfo.MZOrders.MZOrders(baseInterfaceHN);

                InterfaceClass.HN.BusCostInfo.MZOrders.GetMZOrdersOutParameters outParameter = mzOrders.GetMZOrders(baseInterfaceHN.Oper_hospitalid, this._serial_no, "dw_yd_print_xn");

                DataSet ds = new DataSet();

                this._totalFee = outParameter.fund.total_pay;

                ds.Tables.Add(TToDataTable<InterfaceClass.HN.BusCostInfo.MZOrders.Fund>(outParameter.fund));
                ds.Tables.Add(TToDataTable<InterfaceClass.HN.BusCostInfo.MZOrders.Info>(outParameter.ListInfo));

                SendUIMsg(UIMsg.Close);
                SendUIMsg(MZ_ChargeUIMsg.PrintOrderDataSet, ds);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
            SendUIMsg(MZ_ChargeUIMsg.EnabledPrintButton);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void BindPayInfo(object p)
        {
            this.c1FlexGridJJ.DataSource = (DataTable)p;

            this.c1FlexGridJJ.Cols["fund_name"].Width = 260;

            if (this.c1FlexGridJJ.Cols.Contains("fund_name"))
            {
                for (int i = 1; i < this.c1FlexGridJJ.Rows.Count; i++)
                {
                    string name = this.c1FlexGridJJ.Rows[i]["fund_name"].ToString().Trim();

                    switch (name)
                    {
                        case "fund_pay":
                            this.c1FlexGridJJ.Rows[i]["fund_name"] = "基金支付金额";
                            break;
                        case "cash_pay_com":
                            this.c1FlexGridJJ.Rows[i]["fund_name"] = "个人自付现金部分";
                            break;
                        case "acct_pay_com":
                            this.c1FlexGridJJ.Rows[i]["fund_name"] = "个人自付个人帐户部分";
                            break;
                        case "cash_pay_own":
                            this.c1FlexGridJJ.Rows[i]["fund_name"] = "个人自费现金部分";
                            break;
                        case "acct_pay_own":
                            this.c1FlexGridJJ.Rows[i]["fund_name"] = "个人自费个人帐户部分";
                            break;
                        case "hosp_pay":
                            this.c1FlexGridJJ.Rows[i]["fund_name"] = "医院分担费用";
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class MZ_ChargeUIMsg
        {
            public const string DisabledReadCard = "DisabledReadCard";
            public const string EnableReadCard = "EnableReadCard";
            public const string SetPersonInfoObject = "SetPersonInfoObject";
            public const string BindFeeDetails = "BindFeeDetails";
            public const string DisabledTryCharge = "DisabledTryCharge";
            public const string EnableTryCharge = "EnableTryCharge";
            public const string DisabledCharge = "DisabledCharge";
            public const string EnableCharge = "EnableCharge";
            public const string BindPayInfo = "BindPayInfo";
            public const string PrintOrder = "PrintOrder";
            public const string PrintOrderDataSet = "PrintOrderDataSet";
            public const string DisabledPrintButton = "DisabledPrintButton";
            public const string EnabledPrintButton = "EnabledPrintButton";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndiagnose_Click(object sender, EventArgs e)
        {
            Frm_Diagnoise frm = new Frm_Diagnoise(this._diseaseicd, this._diseasename);

            frm.ShowDialog();

            Parameter parameter = frm.ReturnParameter;

            if (parameter != null)
            {
                this.txtBoxin_disease_name.Tag = parameter.Name;
                this.txtBoxin_disease_name.Text = parameter.Value;

                EnabledOperButton(true);
            }

            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            CreateAndStartThread(this._thread, ThreadPrintOrder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearPersonInfo();
            ClearPatientInfo();
            ClearFeeInfo();
            SetC1FlexGridNullDataTable(this.c1FlexGridFeeList);
            SetC1FlexGridNullDataTable(this.c1FlexGridJJ);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFeeList_DoubleClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemFeeDetailsDelete_Click(object sender, EventArgs e)
        {
            if (this._selectedFeeDetailsRowIndex > 0)
            {
                if (this.c1FlexGridFeeList.Cols.Contains("medi_item_type"))
                {
                    this.c1FlexGridFeeList.RemoveItem(this._selectedFeeDetailsRowIndex);

                    CalcTotalFee();
                }
            }
        }

        /// <summary>
        /// z
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFeeList_SelChange(object sender, EventArgs e)
        {
            this._selectedFeeDetailsRowIndex = this.c1FlexGridFeeList.MouseRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFeeList_AfterEdit(object sender, RowColEventArgs e)
        {
            if (this.c1FlexGridFeeList.Cols.Contains("medi_item_type"))
            {
                double dosage = double.Parse(this.c1FlexGridFeeList.Rows[this._selectedFeeDetailsRowIndex]["dosage"].ToString().Trim());//用量
                double price = double.Parse(this.c1FlexGridFeeList.Rows[this._selectedFeeDetailsRowIndex]["price"].ToString().Trim());//单价

                this.c1FlexGridFeeList.Rows[this._selectedFeeDetailsRowIndex]["dosage"] = dosage.ToString("0.0000");
                this.c1FlexGridFeeList.Rows[this._selectedFeeDetailsRowIndex]["price"] = price.ToString("0.0000");

                this.c1FlexGridFeeList.Rows[this._selectedFeeDetailsRowIndex]["money"] = (dosage * price).ToString("0.00");//金额

                CalcTotalFee();
            }
        }

        /// <summary>
        /// 计算总金额
        /// </summary>
        private void CalcTotalFee()
        {
            if (this.c1FlexGridFeeList.Cols.Contains("medi_item_type"))
            {
                try
                {
                    double money = 0;

                    for (int i = 1; i < this.c1FlexGridFeeList.Rows.Count; i++)
                    {
                        double dosage = double.Parse(this.c1FlexGridFeeList.Rows[i]["dosage"].ToString().Trim());//用量
                        double price = double.Parse(this.c1FlexGridFeeList.Rows[i]["price"].ToString().Trim());//单价

                        money += Convert.ToDouble((dosage * price).ToString("0.00"));//金额
                    }

                    this.lblTotalFee.Text = money.ToString();
                    this.lblCurrentFee.Text = money.ToString();

                    double cash = Convert.ToDouble(this.lbllast_balance.Text.Trim());

                    if (cash >= money)
                    {
                        this.lblCashFee.Text = string.Empty;
                    }
                    else
                    {
                        this.lblCashFee.Text = (money - cash).ToString("0.00");
                    }
                }
                catch (Exception ex)
                {
                    CommonFunctions.MsgError("计算总费用发生错误，错误原因：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFeeDetails_Click(object sender, EventArgs e)
        {
            if (!this.c1FlexGridFeeList.Cols.Contains("medi_item_type"))
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

                this.c1FlexGridFeeList.Rows.Add();

                foreach (Parameter p in listParameter)
                {
                    this.c1FlexGridFeeList.Rows[this.c1FlexGridFeeList.Rows.Count - 1][p.Name] = p.Value;
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
                                        '{0}' AS 'input_staff' ,
                                        '{1}' AS 'input_man' ,
                                        CONVERT(CHAR(20), GETDATE(), 120) AS 'input_date' ,
                                        '' AS 'recipe_no' ,
                                        '' AS 'doctor_no' ,
                                        '' AS 'doctor_name'
                                FROM    HIS_InterfaceHN.dbo.Interface_AddMatch
                                WHERE   id = N'{2}'", this._userID.ToString(), this._userName, ID);

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(sb.ToString());

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("通过编号" + ID + "获取匹配信息发生错误，错误原因：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFeeList_ValidateEdit(object sender, ValidateEditEventArgs e)
        {
            if (this._selectedFeeDetailsRowIndex > 0)
            {
                int rowIndex = e.Row;
                int colIndex = e.Col;

                if (colIndex == 11 || colIndex == 12)
                {
                    double result = 0;

                    bool value = double.TryParse(this.c1FlexGridFeeList.Editor.Text.Trim(), out result);

                    if (!value)
                    {
                        e.Cancel = !value;
                        CommonFunctions.MsgError("输入的内容不能是除数字之外的其他字符！！！");
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFeeList_AfterSelChange(object sender, RangeEventArgs e)
        {
            if (e.NewRange.c1 == e.NewRange.c2 && e.NewRange.c1 == 11 || e.NewRange.c1 == 12)
            {
                this.c1FlexGridFeeList.AllowEditing = true;
            }
            else
            {
                this.c1FlexGridFeeList.AllowEditing = false;
            }
        }
    }
}