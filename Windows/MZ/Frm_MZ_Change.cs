using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using C1.Win.C1FlexGrid;
using InterfaceClass;
using Windows.Class;
using System.Data.SqlClient;

namespace Windows.MZ
{
    /// <summary>
    /// 门诊改费类
    /// </summary>
    public partial class Frm_MZ_Change : BaseForm
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

        /// <summary>
        /// 疾病诊断编码
        /// </summary>
        private string _diseaseicd = string.Empty;

        /// <summary>
        /// 疾病诊断名称
        /// </summary>
        private string _diseasename = string.Empty;

        /// <summary>
        /// 费用明细参数
        /// </summary>
        private List<InterfaceClass.HN.MZ.FeeInfo> _listMZRegFeeInfoParameter = null;

        /// <summary>
        /// 
        /// </summary>
        private InterfaceClass.HN.MZ.MZ_ChangeParameter _mz_ChangeParameter = null;

        /// <summary>
        /// 
        /// </summary>
        private int _selectedFeeInfoRowIndex = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userID"></param>
        public Frm_MZ_Change(long userID)
        {
            InitializeComponent();

            this._userID = userID;

            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 窗体初始化函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MZ_Change_Load(object sender, EventArgs e)
        {
            QueryAndSetUserInfo();

            ClearPersonInfo();
            SetPersonInfoReadOnly(true);

            ClearPatientInfo();
            SetPatientInfoReadOnly(true);

            ClearFeeInfo();

            SetC1FlexGridAttribute(this.c1FlexGridFeeList, true);
            SetC1FlexGridSelectionMode(this.c1FlexGridFeeList, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridFeeList);
            SetC1FlexGridNullDataTable(this.c1FlexGridFeeList);

            SetC1FlexGridRowBackGroundColor();

            EnabledOperButton(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        private void EnabledOperButton(bool flag)
        {
            this.btnTryChange.Enabled = flag;
            this.btnChange.Enabled = flag;
            this.btnPrint.Enabled = flag;
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
                        SetRowBackground(e.Row);

                        CalcTotalFee();
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            bool flag = this.chBoxPrintView.Checked;

            List<Parameter> listParameter = new List<Parameter>();

            Print(flag, "100001003", listParameter, null, "请在HIS_InterfaceHN.dbo.Setup表中配置Code为100001003的普通门诊收费打印结算单编号！！！");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            this._mz_ChangeParameter.MZRegChange.save_flag = "1";//改费收费
            this._mz_ChangeParameter.MZRegChange.query_flag = "1";//改费

            if (GetListFeeInfoParameter())
            {
                CreateAndStartThread(this._thread, ThreadMZRegChangeAndTryChange);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTryChange_Click(object sender, EventArgs e)
        {
            this._mz_ChangeParameter.MZRegChange.save_flag = "0";//改费实现
            this._mz_ChangeParameter.MZRegChange.query_flag = "1";//退费

            if (GetListFeeInfoParameter())
            {
                CreateAndStartThread(this._thread, ThreadMZRegChangeAndTryChange);
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
        private void SaveMZRegChangeMainParameter()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat(@"INSERT INTO [HIS_InterfaceHN].[dbo].[MZRegChange]
                                               ([center_id]
                                               ,[hospital_id]
                                               ,[serial_no]
                                               ,[indi_id]
                                               ,[biz_type]
                                               ,[treatment_type]
                                               ,[reg_staff]
                                               ,[reg_man]
                                               ,[save_flag]
                                               ,[bill_no]
                                               ,[trade_no]
                                               ,[diagnose]
                                               ,[diagnose_date]
                                               ,[query_flag]
                                               ,[LoginUser]
                                               ,[LoginTime])
                                         VALUES
                                               (N'{0}',--<center_id, nvarchar(10),>
                                               N'{1}',--<hospital_id, nvarchar(20),>
                                               N'{2}',--<serial_no, nvarchar(20),>
                                               N'{3}',--<indi_id, nvarchar(12),>
                                               N'{4}',--<biz_type, nvarchar(2),>
                                               N'{5}',--<treatment_type, nvarchar(3),>
                                               N'{6}',--<reg_staff, nvarchar(5),>
                                               N'{7}',--<reg_man, nvarchar(10),>
                                               N'{8}',--<save_flag, char(1),>
                                               N'{9}',--<bill_no, nvarchar(18),>
                                               N'{10}',--<trade_no, nvarchar(30),>
                                               N'{11}',--<diagnose, nvarchar(30),>
                                               N'{12}',--<diagnose_date, datetime,>
                                               N'{13}',--<query_flag, char(1),>
		                                       N'{14}',--<LoginUser, nvarchar(50)>
		                                       GETDATE())--<LoginTime, datetime>", this._mz_ChangeParameter.MZRegChange.center_id, this._mz_ChangeParameter.MZRegChange.hospital_id
                                                      , this._mz_ChangeParameter.MZRegChange.serial_no, this._mz_ChangeParameter.MZRegChange.indi_id,
                                                      this._mz_ChangeParameter.MZRegChange.biz_type, this._mz_ChangeParameter.MZRegChange.treatment_type,
                                                      this._mz_ChangeParameter.MZRegChange.reg_staff, this._mz_ChangeParameter.MZRegChange.reg_man,
                                                      this._mz_ChangeParameter.MZRegChange.save_flag, this._mz_ChangeParameter.MZRegChange.bill_no,
                                                      this._mz_ChangeParameter.MZRegChange.trade_no, this._mz_ChangeParameter.MZRegChange.diagnose,
                                                      this._mz_ChangeParameter.MZRegChange.diagnose_date, this._mz_ChangeParameter.MZRegChange.query_flag, this._userName);
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

        /// <summary>
        /// 
        /// </summary>
        private void ThreadMZRegChangeAndTryChange()
        {
            SendUIMsg(MZ_ChangeUIMsg.DisabledTryChange);
            SendUIMsg(MZ_ChangeUIMsg.DisabledChange);

            try
            {
                SaveMZRegChangeMainParameter();
                SaveMZRegFeeInfoParameter(2);

                SendUIMsg(UIMsg.Display, "正在努力往中心上传改费数据，请稍后......");

                InterfaceClass.HN.MZ.CheckAndSaveFeeDetails checkAndSaveFeeDetails = new InterfaceClass.HN.MZ.CheckAndSaveFeeDetails(baseInterfaceHN);

                InterfaceClass.HN.MZ.MZRegOutParameter mz_ChangeOutParameter = checkAndSaveFeeDetails.CheckCalcAndSaveWrittenFeeDetails(this._mz_ChangeParameter);

                SaveMZRegBizInfo(0, mz_ChangeOutParameter.BizInfo);
                SaveMZRegPayInfo(0, mz_ChangeOutParameter.ListPayInfo);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }

            SendUIMsg(MZ_ChangeUIMsg.EnableTryChange);
            SendUIMsg(MZ_ChangeUIMsg.EnableChange);
        }

        /// <summary>
        /// 获取费用明细参数
        /// </summary>
        private bool GetListFeeInfoParameter()
        {
            if (this.c1FlexGridFeeList.Cols.Count == 2)
            {
                this._mz_ChangeParameter._listFeeInfo = new List<InterfaceClass.HN.MZ.FeeInfo>();

                return true;
            }

            try
            {
                for (int i = 0; i < this.c1FlexGridFeeList.Rows.Count; i++)
                {
                    switch (this.c1FlexGridFeeList.Rows[i]["medi_item_type"].ToString().Trim())
                    {
                        case "诊疗项目":
                            this.c1FlexGridFeeList.Rows[i]["medi_item_type"] = "0";
                            break;
                        case "西药":
                            this.c1FlexGridFeeList.Rows[i]["medi_item_type"] = "1";
                            break;
                        case "中成药":
                            this.c1FlexGridFeeList.Rows[i]["medi_item_type"] = "2";
                            break;
                        case "中草药":
                            this.c1FlexGridFeeList.Rows[i]["medi_item_type"] = "3";
                            break;
                        default:
                            break;
                    }
                }

                this._listMZRegFeeInfoParameter = new List<InterfaceClass.HN.MZ.FeeInfo>();
                InterfaceClass.HN.MZ.FeeInfo feeInfo = new InterfaceClass.HN.MZ.FeeInfo();

                List<Parameter> listParameter = GetProperties<InterfaceClass.HN.MZ.FeeInfo>(feeInfo);

                for (int i = 1; i < this.c1FlexGridFeeList.Rows.Count; i++)
                {
                    feeInfo = new InterfaceClass.HN.MZ.FeeInfo();

                    foreach (Parameter p in listParameter)
                    {
                        string value = this.c1FlexGridFeeList.Rows[i][p.Name].ToString().Trim();

                        feeInfo.SetAttributeValue(p.Name, value);
                    }

                    this._listMZRegFeeInfoParameter.Add(feeInfo);
                }

                this._mz_ChangeParameter._listFeeInfo = this._listMZRegFeeInfoParameter;

                return true;
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("在改费过程中，获取费用明细参数发生错误，错误原因：" + ex.Message);
                return false;
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

            frm = null;

            ClearPersonInfo();
            ClearPatientInfo();
            ClearFeeInfo();
            SetC1FlexGridNullDataTable(this.c1FlexGridFeeList);

            if (this._indi_id == string.Empty)
            {
                return;
            }

            this.txtBoxindi_id.Text = this._indi_id;

            EnabledOperButton(false);

            CreateAndStartThread(this._thread, ThreadQueryPersonInfo);
        }

        /// <summary>
        /// 线程查询人员信息
        /// </summary>
        private void ThreadQueryPersonInfo()
        {
            SendUIMsg(MZ_ChangeUIMsg.DisabledReadCard);
            SendUIMsg(MZ_ChangeUIMsg.DisabledFindPatients);

            QueryPersonInfo();

            SendUIMsg(MZ_ChangeUIMsg.EnableReadCard);
            SendUIMsg(MZ_ChangeUIMsg.EnabledFindPatients);
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
                    SendUIMsg(MZ_ChangeUIMsg.SetPersonInfoObject, listPersonInfo[0]);

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

                QueryChargeInfo();
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("设置人员信息失败，失败原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 查询收费信息
        /// </summary>
        private void QueryChargeInfo()
        {
            CreateAndStartThread(this._thread, ThreadChargeInfo);
        }

        /// <summary>
        /// 线程查询收费信息
        /// </summary>
        private void ThreadChargeInfo()
        {
            SendUIMsg(MZ_ChangeUIMsg.DisabledReadCard);
            SendUIMsg(MZ_ChangeUIMsg.DisabledFindPatients);

            QueryChargePatientInfo();

            SendUIMsg(MZ_ChangeUIMsg.EnableReadCard);
            SendUIMsg(MZ_ChangeUIMsg.EnabledFindPatients);
        }

        /// <summary>
        /// 查询患者收费信息
        /// </summary>
        private void QueryChargePatientInfo()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在努力查询患者收费信息，请稍后......");

                IDataParameter[] parameter = new IDataParameter[2];

                parameter[0] = new SqlParameter("@mzRegID", this._mzRegID);
                parameter[1] = new SqlParameter("@indi_id", this._indi_id);

                DataSet ds = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_QueryChargedInfo", parameter, "P_QueryChargedInfo");

                SendUIMsg(MZ_ChangeUIMsg.SetChangedInfo, ds);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);

                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        /// <summary>
        /// 设置收费信息
        /// </summary>
        /// <param name="p"></param>
        private void SetChangedInfo(Object p)
        {
            DataSet ds = (DataSet)p;

            if (ds.Tables.Count != 3)
            {
                CommonFunctions.MsgError("通过存储过程P_QueryChargedInfo获取的数据集个数不为4，请联系管理员！！！");
                return;
            }

            InitMZ_ChangeParameter((DataSet)p);

            EnabledOperButton(true);
        }

        /// <summary>
        /// 初始化门诊改费参数
        /// </summary>
        private void InitMZ_ChangeParameter(DataSet ds)
        {
            InitMZ_ChangeMainParameter(ds);

            InitMZRegChangePatientInfo(ds);

            InitMZRegHISInfo(ds);

            InitFeeInfo(ds);
        }

        /// <summary>
        /// 初始化费用信息
        /// </summary>
        /// <param name="ds"></param>
        private void InitFeeInfo(DataSet ds)
        {
            this.c1FlexGridFeeList.DataSource = ds.Tables[2];

            if (ds.Tables[2].Rows.Count <= 0)
            {
                SetC1FlexGridNullDataTable(this.c1FlexGridFeeList, "现在进行【改费】操作，将取消此次业务的所有费用......");
                return;
            }

            this.c1FlexGridFeeList.Cols["stat_type"].Visible = false;
            this.c1FlexGridFeeList.Cols["item_code"].Visible = false;
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

            this.c1FlexGridFeeList.Cols["medi_item_type"].Caption = "项目药品类型";
            this.c1FlexGridFeeList.Cols["medi_item_type"].Width = 80;

            this.c1FlexGridFeeList.Cols["his_item_code"].Caption = "医院药品项目编码";
            this.c1FlexGridFeeList.Cols["his_item_code"].Width = 110;

            this.c1FlexGridFeeList.Cols["his_item_name"].Caption = "医院药品项目名称";
            this.c1FlexGridFeeList.Cols["his_item_name"].Width = 210;

            this.c1FlexGridFeeList.Cols["fee_date"].Caption = "费用发生时间";
            this.c1FlexGridFeeList.Cols["fee_date"].Width = 120;

            this.c1FlexGridFeeList.Cols["unit"].Caption = "计量单位";
            this.c1FlexGridFeeList.Cols["unit"].Width = 55;

            this.c1FlexGridFeeList.Cols["price"].Caption = "单价";
            this.c1FlexGridFeeList.Cols["price"].Width = 70;

            this.c1FlexGridFeeList.Cols["dosage"].Caption = "用量";
            this.c1FlexGridFeeList.Cols["dosage"].Width = 70;

            this.c1FlexGridFeeList.Cols["money"].Caption = "金额";
            this.c1FlexGridFeeList.Cols["money"].Width = 70;

            this.c1FlexGridFeeList.Cols["usage_flag"].Caption = "用药标志";
            this.c1FlexGridFeeList.Cols["usage_flag"].Width = 60;

            this.c1FlexGridFeeList.Cols["input_staff"].Caption = "录入工号";
            this.c1FlexGridFeeList.Cols["input_staff"].Width = 60;

            this.c1FlexGridFeeList.Cols["input_man"].Caption = "录入人";
            this.c1FlexGridFeeList.Cols["input_man"].Width = 80;

            this.c1FlexGridFeeList.Cols["input_date"].Caption = "录入日期";
            this.c1FlexGridFeeList.Cols["input_date"].Width = 120;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitMZRegChangePatientInfo(DataSet ds)
        {
            this.lblPatientreg_staff.Text = string.Format("录入人工号：{0} 录入人：{1} 录入日期：{2}",
                ds.Tables[0].Rows[0]["reg_staff"].ToString().Trim(),
                ds.Tables[0].Rows[0]["reg_man"].ToString().Trim(),
                ds.Tables[0].Rows[0]["LoginTime"].ToString().Trim());

            this.txtBoxin_disease_name.Tag = ds.Tables[0].Rows[0]["diagnose"].ToString().Trim();
            this.txtBoxin_disease_name.Text = this._mz_ChangeParameter.MZRegChange.diagnose = ds.Tables[0].Rows[0]["in_disease_name"].ToString().Trim();

            this.txtBoxserial_no.Text = this._mz_ChangeParameter.MZRegChange.serial_no;

            this.txtBoxdiagnose_date.Text = this._mz_ChangeParameter.MZRegChange.diagnose_date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        private void InitMZRegHISInfo(DataSet ds)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                this.lblPatientCardNumbers.Text = ds.Tables[1].Rows[0]["CardNumbers"].ToString().Trim();
                this.txtBoxPatientFPID.Text = ds.Tables[1].Rows[0]["FPID"].ToString().Trim();
                this.txtBoxPatientName.Text = ds.Tables[1].Rows[0]["PatientName"].ToString().Trim();
                this.txtBoxPatientSex.Text = ds.Tables[1].Rows[0]["Sex"].ToString().Trim();
                this.txtBoxPatientAge.Text = ds.Tables[1].Rows[0]["Age"].ToString().Trim();
            }
        }

        /// <summary>
        /// 初始化门诊改费主参数
        /// </summary>
        /// <param name="ds"></param>
        private void InitMZ_ChangeMainParameter(DataSet ds)
        {
            if (this._mz_ChangeParameter != null)
            {
                this._mz_ChangeParameter = null;
            }

            this._mz_ChangeParameter = new InterfaceClass.HN.MZ.MZ_ChangeParameter();

            InterfaceClass.HN.MZ.MZRegChange mzRegChange = new InterfaceClass.HN.MZ.MZRegChange();

            List<Parameter> listParameter = GetProperties<InterfaceClass.HN.MZ.MZRegChange>(mzRegChange);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                mzRegChange = null;
                mzRegChange = new InterfaceClass.HN.MZ.MZRegChange();

                foreach (Parameter p in listParameter)
                {
                    string value = ds.Tables[0].Rows[i][p.Name].ToString().Trim();

                    mzRegChange.SetAttributeValue(p.Name, value);
                }
            }

            this._mz_ChangeParameter.MZRegChange = mzRegChange;
        }

        /// <summary>
        /// 
        /// </summary>
        private void WriteDianoise()
        {
            this.btndiagnose.PerformClick();
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
            this.lblPatientreg_staff.Text = string.Empty;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindPatient_Click(object sender, EventArgs e)
        {
            MZ.Frm_MZ_FindChargedPatients frm = new Frm_MZ_FindChargedPatients();

            frm.ShowDialog();

            this._indi_id = frm.Indi_id;
            this._mzRegID = frm.MZRegID;

            frm = null;

            ClearPersonInfo();
            ClearPatientInfo();
            ClearFeeInfo();
            SetC1FlexGridNullDataTable(this.c1FlexGridFeeList);

            if (this._indi_id == string.Empty)
            {
                return;
            }

            this.txtBoxindi_id.Text = this._indi_id;

            EnabledOperButton(false);

            CreateAndStartThread(this._thread, ThreadQueryPersonInfo);
        }

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
                    case MZ_ChangeUIMsg.DisabledReadCard:
                        this.btnReadCard.Enabled = false;
                        break;
                    case MZ_ChangeUIMsg.EnableReadCard:
                        this.btnReadCard.Enabled = true;
                        break;
                    case MZ_ChangeUIMsg.SetPersonInfoObject:
                        SetPersonInfoObject(parameter.Object);
                        break;
                    case MZ_ChangeUIMsg.BindFeeDetails:
                        BindFeeDetails(parameter.Object);
                        break;
                    case MZ_ChangeUIMsg.DisabledTryChange:
                        this.btnTryChange.Enabled = false;
                        break;
                    case MZ_ChangeUIMsg.EnableTryChange:
                        this.btnTryChange.Enabled = true;
                        break;
                    case MZ_ChangeUIMsg.DisabledChange:
                        this.btnChange.Enabled = false;
                        break;
                    case MZ_ChangeUIMsg.EnableChange:
                        this.btnChange.Enabled = true;
                        break;
                    case MZ_ChangeUIMsg.DisabledFindPatients:
                        this.btnFindPatient.Enabled = false;
                        break;
                    case MZ_ChangeUIMsg.EnabledFindPatients:
                        this.btnFindPatient.Enabled = true;
                        break;
                    case MZ_ChangeUIMsg.SetChangedInfo:
                        SetChangedInfo(parameter.Object);
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
        /// <param name="p"></param>
        private void BindFeeDetails(object p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public class MZ_ChangeUIMsg
        {
            public const string DisabledReadCard = "DisabledReadCard";
            public const string EnableReadCard = "EnableReadCard";
            public const string SetPersonInfoObject = "SetPersonInfoObject";
            public const string BindFeeDetails = "BindFeeDetails";
            public const string DisabledTryChange = "DisabledTryChange";
            public const string EnableTryChange = "EnableTryChange";
            public const string DisabledChange = "DisabledChange";
            public const string EnableChange = "EnableChange";
            public const string DisabledFindPatients = "DisabledFindPatients";
            public const string EnabledFindPatients = "EnabledFindPatients";
            public const string SetChangedInfo = "SetChangedInfo";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridFeeList_SelChange(object sender, EventArgs e)
        {
            this._selectedFeeInfoRowIndex = this.c1FlexGridFeeList.MouseRow;

            if (this._selectedFeeInfoRowIndex > 0)
            {

            }
        }

        /// <summary>
        /// 计算总金额
        /// </summary>
        private void CalcTotalFee()
        {
            double sum = 0;

            if (this.c1FlexGridFeeList.Cols.Contains("money") && this.c1FlexGridFeeList.Rows.Count > 0)
            {

                for (int i = 1; i < this.c1FlexGridFeeList.Rows.Count; i++)
                {
                    sum += double.Parse(this.c1FlexGridFeeList.Rows[i]["money"].ToString().Trim());
                }

                SetTotalFee(sum);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sum"></param>
        private void SetTotalFee(double sum)
        {
            this.lblTotalFee.Text = sum.ToString();
            this.lblCurrentFee.Text = sum.ToString();
            this.lblJJFee.Text = "0";
            this.lblCashFee.Text = "0";
            this.lblGetFee.Text = "0";
            this.lblOutFee.Text = "0";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (this._selectedFeeInfoRowIndex > 0)
            {
                this.c1FlexGridFeeList.RemoveItem(this._selectedFeeInfoRowIndex);
            }
        }
    }
}