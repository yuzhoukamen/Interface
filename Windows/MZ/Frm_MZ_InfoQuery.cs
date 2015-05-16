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
    public partial class Frm_MZ_InfoQuery : BaseForm
    {
        private Thread _thread = null;

        private DataTable _dtPersonInfo = null;

        private int _flag = 0;

        private string _typeID = string.Empty;
        private string _typeValue = string.Empty;
        private string _hospitalID = string.Empty;
        private string _bizType = string.Empty;
        private string _centerID = string.Empty;
        private string _indi_id = string.Empty;

        public Frm_MZ_InfoQuery(long userID)
        {
            InitializeComponent();

            this._userID = userID;
            this._SynchronizationContext = SynchronizationContext.Current;
        }

        #region radioButton单击事件

        private void radioButtonByindi_id_CheckedChanged(object sender, EventArgs e)
        {
            this.lblQueryType.Text = "个人电脑号：";
            this.lblQueryType.Tag = 1;
            this.txtBoxQueryType.Text = string.Empty;
            this.txtBoxQueryType.Focus();
        }

        private void radioButtonByname_CheckedChanged(object sender, EventArgs e)
        {
            this.lblQueryType.Text = "参保人姓名：";
            this.lblQueryType.Tag = 2;
            this.txtBoxQueryType.Text = string.Empty;
            this.txtBoxQueryType.Focus();
        }

        private void radioButtonByidcard_CheckedChanged(object sender, EventArgs e)
        {
            this.lblQueryType.Text = "公民身份号：";
            this.lblQueryType.Tag = 3;
            this.txtBoxQueryType.Text = string.Empty;
            this.txtBoxQueryType.Focus();
        }

        private void radioButtonByiccardno_CheckedChanged(object sender, EventArgs e)
        {
            this.lblQueryType.Text = "参保人卡号：";
            this.lblQueryType.Tag = 4;
            this.txtBoxQueryType.Text = string.Empty;
            this.txtBoxQueryType.Focus();
        }

        private void radioButtonByinsr_code_CheckedChanged(object sender, EventArgs e)
        {
            this.lblQueryType.Text = "参保保险号：";
            this.lblQueryType.Tag = 5;
            this.txtBoxQueryType.Text = string.Empty;
            this.txtBoxQueryType.Focus();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this._flag = int.Parse(this.lblQueryType.Tag.ToString());
            this._bizType = this.cBoxBiz_Type.SelectedValue.ToString().Trim();

            GetTypeValueAndID();

            if (CheckQueryValue())
            {
                CreateAndStartThread(this._thread, ThreaQuery);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckQueryValue()
        {
            if (this._centerID == string.Empty)
            {
                CommonFunctions.MsgError("医保中心编码不能为空，请联系管理员！！！");
                return false;
            }

            if (this._hospitalID == string.Empty)
            {
                CommonFunctions.MsgError("医疗机构编码不能为空，请联系管理员！！！");
                return false;
            }
            if (this._bizType == string.Empty)
            {
                CommonFunctions.MsgError("业务类型不能为空，请联系管理员！！！");
                return false;
            }

            if (this._typeValue == string.Empty)
            {
                string str = string.Empty;
                switch (this._flag)
                {
                    case 1:
                        str = "个人电脑号";
                        break;
                    case 2:
                        str = "参保人姓名";
                        break;
                    case 3:
                        str = "公民身份号";
                        break;
                    case 4:
                        str = "参保人卡号";
                        break;
                    case 5:
                        str = "参保保险号";
                        break;
                    default:
                        break;
                }

                CommonFunctions.MsgError(str + "不能为空！！！");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取类型的编号和内容
        /// </summary>
        private void GetTypeValueAndID()
        {
            switch (this._flag)
            {
                case 1:
                    this._typeID = "indi_id";
                    break;
                case 2:
                    this._typeID = "name";
                    break;
                case 3:
                    this._typeID = "idcard";
                    break;
                case 4:
                    this._typeID = "iccardno";
                    break;
                case 5:
                    this._typeID = "insr_code";
                    break;
                default:
                    break;
            }

            this._typeValue = this.txtBoxQueryType.Text.Trim();
        }

        private void Frm_MZ_InfoQuery_Load(object sender, EventArgs e)
        {
            this._centerID = baseInterfaceHN.Oper_centerid;
            this._hospitalID = baseInterfaceHN.Oper_hospitalid;

            GetHospitalAndCenterName();

            SetC1FlexGridAttribute(this.c1FlexGridPersonInfo, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridPersonInfo, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridPersonInfo);
            SetC1FlexGridNullDataTable(this.c1FlexGridPersonInfo);

            SetC1FlexGridAttribute(this.c1FlexGridFreezeInfo, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridFreezeInfo, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridFreezeInfo);
            SetC1FlexGridNullDataTable(this.c1FlexGridFreezeInfo);

            SetC1FlexGridAttribute(this.c1FlexGridTotalBizInfo, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridTotalBizInfo, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridTotalBizInfo);
            SetC1FlexGridNullDataTable(this.c1FlexGridTotalBizInfo);

            SetApplicationIco(this);

            QueryAndSetUserInfo(ref this._unitName, ref this._userName);

            InitComboBox(this.cBoxBiz_Type, "Value", "Name", @"SELECT  ID ,
                                                        TypeID ,
                                                        Name ,
                                                        Value ,
                                                        Length ,
                                                        Details
                                                FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                                WHERE   TypeID = 1
                                                ORDER BY Name ", true);
        }

        #region 查询

        /// <summary>
        /// 查询线程
        /// </summary>
        public void ThreaQuery()
        {
            SendUIMsg(MZ_InfoQueryUIMsg.DisabledQueryButton);

            QueryPersonInfoDetail();

            SendUIMsg(MZ_InfoQueryUIMsg.EnableQueryButton);
        }

        /// <summary>
        /// 查询人员详细信息
        /// </summary>
        private void QueryPersonInfoDetail()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器通过个人标识取人员信息，请稍后......");

                InterfaceClass.HN.MZ.GetPersonInfoByFlag getPersonInfoByFlag = new InterfaceClass.HN.MZ.GetPersonInfoByFlag(baseInterfaceHN);

                InterfaceClass.HN.MZ.PersonInfoDetail personInfoDetail = null;

                switch (this._flag)
                {
                    case 1:
                        SendUIMsg(UIMsg.WriteMsg, "正在通过参保人电脑号取人员信息，请稍后......");
                        personInfoDetail = getPersonInfoByFlag.GetPersonInfoDetailByindi_id(this._typeValue, this._hospitalID, this._bizType, this._centerID);
                        break;
                    case 2:
                        SendUIMsg(UIMsg.WriteMsg, "正在通过参保人的姓名取人员信息，请稍后......");
                        personInfoDetail = getPersonInfoByFlag.GetPersonInfoDetailByname(this._typeValue, this._hospitalID, this._bizType, this._centerID);
                        break;
                    case 3:
                        SendUIMsg(UIMsg.WriteMsg, "正在通过参保人的公民身份号码取人员信息，请稍后......");
                        personInfoDetail = getPersonInfoByFlag.GetPersonInfoDetailByidcard(this._typeValue, this._hospitalID, this._bizType, this._centerID);
                        break;
                    case 4:
                        SendUIMsg(UIMsg.WriteMsg, "正在通过参保人的IC卡号取人员信息，请稍后......");
                        personInfoDetail = getPersonInfoByFlag.GetPersonInfoDetailByiccardno(this._typeValue, this._hospitalID, this._bizType, this._centerID);
                        break;
                    case 5:
                        SendUIMsg(UIMsg.WriteMsg, "正在通过参保人的保险号取人员信息，请稍后......");
                        personInfoDetail = getPersonInfoByFlag.GetPersonInfoDetailByinsr_code(this._typeValue, this._hospitalID, this._bizType, this._centerID);
                        break;
                    default:
                        break;
                }

                SendUIMsg(UIMsg.WriteMsg, "获取人员详细信息成功，正在处理，请稍后......");

                if (personInfoDetail == null)
                {
                    throw new Exception("获取的人员详细信息为null,请联系管理员！！！");
                }

                SendUIMsg(UIMsg.WriteMsg, "正在将获取的人员信息转换成数据表，请稍后......");

                PersonInfoListToDataTable(personInfoDetail.ListPersonInfo);

                SendUIMsg(UIMsg.WriteMsg, "将获取的人员信息转换成数据表成功，请稍后......");

                if (personInfoDetail.ListPersonInfo.Count == 1)
                {
                    SendUIMsg(UIMsg.WriteMsg, "正在将获取的个人基金冻结信息转换成数据表，请稍后......");

                    FreezeInfoToDataTable(personInfoDetail.ListFreezeinfo);

                    SendUIMsg(UIMsg.WriteMsg, "正在将获取的个人业务累计信息转换成数据表，请稍后......");

                    TotalBizInfoToDataTable(personInfoDetail.TotalbizInfo);
                }

                SendUIMsg(UIMsg.Close);
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
        /// <param name="totalbizInfo"></param>
        private void TotalBizInfoToDataTable(InterfaceClass.HN.MZ.TotalbizInfo totalbizInfo)
        {
            DataTable dt = TToDataTable<InterfaceClass.HN.MZ.TotalbizInfo>(totalbizInfo);

            SendUIMsg(MZ_InfoQueryUIMsg.BindTotalbizInfo, dt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        private void FreezeInfoToDataTable(List<InterfaceClass.HN.MZ.FreezeInfo> list)
        {
            DataTable dt = TToDataTable<InterfaceClass.HN.MZ.FreezeInfo>(list);

            SendUIMsg(MZ_InfoQueryUIMsg.BindFreezeInfo, dt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        private void PersonInfoListToDataTable(List<InterfaceClass.HN.MZ.PersonInfo> list)
        {
            DataTable dt = TToDataTable<InterfaceClass.HN.MZ.PersonInfo>(list);

            SendUIMsg(MZ_InfoQueryUIMsg.BindPersonInfo, dt);
        }

        /// <summary>
        /// 获取医保中心名称和医疗机构名称
        /// </summary>
        private void GetHospitalAndCenterName()
        {
            try
            {
                this.txtBoxCenter.Text = this.GetCenterName(this._centerID);
                this.txtBoxHospital.Text = this.GetHospitalName(this._hospitalID);
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError(ex.Message);
            }
        }

        private void BindTotalbizInfo(object p)
        {
            this.c1FlexGridTotalBizInfo.DataSource = (DataTable)p;
        }

        private void BindFreezeInfo(object p)
        {
            this.c1FlexGridFreezeInfo.DataSource = (DataTable)p;

            this.c1FlexGridFreezeInfo.Cols["fund_id"].Width = 40;
            this.c1FlexGridFreezeInfo.Cols["fund_name"].Width = 180;
            this.c1FlexGridFreezeInfo.Cols["indi_freeze_status"].Width = 40;
        }

        private void BindPersonInfo(object p)
        {
            this.c1FlexGridPersonInfo.DataSource = (DataTable)p;

            this.c1FlexGridPersonInfo.Cols["indi_id"].Width = 70;
            this.c1FlexGridPersonInfo.Cols["center_id"].Width = 110;
            this.c1FlexGridPersonInfo.Cols["center_name"].Width = 110;
            this.c1FlexGridPersonInfo.Cols["name"].Width = 70;
            this.c1FlexGridPersonInfo.Cols["sex"].Width = 37;
            this.c1FlexGridPersonInfo.Cols["pers_type"].Width = 80;
            this.c1FlexGridPersonInfo.Cols["pers_name"].Width = 80;
            this.c1FlexGridPersonInfo.Cols["indi_join_sta"].Width = 80;
            this.c1FlexGridPersonInfo.Cols["indi_sta_name"].Width = 80;
            this.c1FlexGridPersonInfo.Cols["official_code"].Width = 95;
            this.c1FlexGridPersonInfo.Cols["official_name"].Width = 95;
            this.c1FlexGridPersonInfo.Cols["hire_type"].Width = 80;
            this.c1FlexGridPersonInfo.Cols["hire_name"].Width = 80;
            this.c1FlexGridPersonInfo.Cols["idcard"].Width = 125;
            this.c1FlexGridPersonInfo.Cols["insr_code"].Width = 125;
            this.c1FlexGridPersonInfo.Cols["telephone"].Width = 70;
            this.c1FlexGridPersonInfo.Cols["birthday"].Width = 70;
            this.c1FlexGridPersonInfo.Cols["post_code"].Width = 70;
            this.c1FlexGridPersonInfo.Cols["corp_id"].Width = 70;
            this.c1FlexGridPersonInfo.Cols["corp_name"].Width = 130;
            this.c1FlexGridPersonInfo.Cols["freeze_sta"].Width = 90;
            this.c1FlexGridPersonInfo.Cols["freeze_sta"].Width = 85;
        }

        #endregion

        #region 单击人员信息查询个人基金冻结信息和个人业务累计信息

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridPersonInfo_SelChange(object sender, EventArgs e)
        {
            int rowIndex = this.c1FlexGridPersonInfo.MouseRow;

            if (rowIndex > 0)
            {
                string indi_id = this.c1FlexGridPersonInfo.Rows[rowIndex]["indi_id"].ToString().Trim();

                QueryFreezeInfoAndTotalbizInfo(indi_id);
            }
        }

        /// <summary>
        /// 通过个人电脑号查询个人基金冻结信息和个人业务累计信息
        /// </summary>
        /// <param name="indi_id">个人电脑号</param>
        private void QueryFreezeInfoAndTotalbizInfo(string indi_id)
        {
            this._indi_id = indi_id;

            CreateAndStartThread(this._thread, ThreadQueryFreezeInfoAndTotalbizInfo);
        }

        /// <summary>
        /// 线程通过个人电脑号查询个人基金冻结信息和个人业务累计信息
        /// </summary>
        private void ThreadQueryFreezeInfoAndTotalbizInfo()
        {
            SendUIMsg(MZ_InfoQueryUIMsg.DisabledQueryButton);

            QueryFreezeInfoAndTotalbizInfoDetail();

            SendUIMsg(MZ_InfoQueryUIMsg.EnableQueryButton);
        }

        /// <summary>
        /// 查询个人基金冻结信息和个人业务累计信息
        /// </summary>
        private void QueryFreezeInfoAndTotalbizInfoDetail()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在查询个人基金冻结信息和个人业务累计信息，请稍后......");

                InterfaceClass.HN.MZ.GetPersonInfoByFlag getPersonInfoByFlag = new InterfaceClass.HN.MZ.GetPersonInfoByFlag(baseInterfaceHN);

                InterfaceClass.HN.MZ.PersonInfoDetail personInfoDetail = getPersonInfoByFlag.GetPersonInfoDetailByindi_id(this._indi_id, this._hospitalID, this._bizType, this._centerID);

                SendUIMsg(UIMsg.WriteMsg, "获取人员详细信息成功，正在处理，请稍后......");

                if (personInfoDetail == null)
                {
                    throw new Exception("获取的人员详细信息为null,请联系管理员！！！");
                }

                SendUIMsg(UIMsg.WriteMsg, "将获取的人员信息转换成数据表成功，请稍后......");

                if (personInfoDetail.ListPersonInfo.Count == 1)
                {
                    SendUIMsg(UIMsg.WriteMsg, "正在将获取的个人基金冻结信息转换成数据表，请稍后......");

                    FreezeInfoToDataTable(personInfoDetail.ListFreezeinfo);

                    SendUIMsg(UIMsg.WriteMsg, "正在将获取的个人业务累计信息转换成数据表，请稍后......");

                    TotalBizInfoToDataTable(personInfoDetail.TotalbizInfo);
                }

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);

                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }
        #endregion

        #region 保存人员信息

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.c1FlexGridPersonInfo.DataSource;

            if (dt.Rows.Count == 1 && dt.Columns.Count == 1 && dt.Columns.Contains("内容"))
            {
                CommonFunctions.MsgError("没有任何人员信息，不能进行保存！！！");
                return;
            }

            SavePersonInfo(dt);
        }

        /// <summary>
        /// 保存人员信息
        /// </summary>
        /// <param name="dt"></param>
        private void SavePersonInfo(DataTable dt)
        {
            this._dtPersonInfo = dt;

            CreateAndStartThread(this._thread, ThreadSavePersonInfo);
        }

        /// <summary>
        /// 保存人员信息线程
        /// </summary>
        private void ThreadSavePersonInfo()
        {
            SendUIMsg(MZ_InfoQueryUIMsg.DisabledSaveButton);

            SavePersonInfoToDB();

            SendUIMsg(MZ_InfoQueryUIMsg.EnableSaveButton);
        }

        /// <summary>
        /// 保存人员信息到数据库
        /// </summary>
        private void SavePersonInfoToDB()
        {
            foreach (DataRow dr in this._dtPersonInfo.Rows)
            {
                try
                {
                    string indi_id = dr["indi_id"].ToString();
                    string name = dr["name"].ToString();

                    SendUIMsg(UIMsg.Display, string.Format("正在保存【个人电脑号：{0} 姓名：{1}】的信息,请稍后......", indi_id, name));

                    string SQLString = string.Format(@"IF NOT EXISTS ( SELECT  *
                                                                        FROM    HIS_InterfaceHN.dbo.PersonInfo
                                                                        WHERE   indi_id = N'{0}' )
                                                            BEGIN
                                                                INSERT  INTO [HIS_InterfaceHN].[dbo].[PersonInfo]
                                                                        ( [indi_id] ,
                                                                          [center_id] ,
                                                                          [center_name] ,
                                                                          [name] ,
                                                                          [sex] ,
                                                                          [pers_type] ,
                                                                          [pers_name] ,
                                                                          [indi_join_sta] ,
                                                                          [indi_sta_name] ,
                                                                          [official_code] ,
                                                                          [official_name] ,
                                                                          [hire_type] ,
                                                                          [hire_name] ,
                                                                          [idcard] ,
                                                                          [insr_code] ,
                                                                          [telephone] ,
                                                                          [birthday] ,
                                                                          [post_code] ,
                                                                          [corp_id] ,
                                                                          [corp_name] ,
                                                                          [freeze_sta] ,
                                                                          [last_balance] ,
                                                                          [LoginUser] ,
                                                                          [LoginTime]
                                                                        )
                                                                        SELECT  N'{0}' ,--<indi_id, nvarchar(20),>
                                                                                N'{1}' ,--<center_id, nvarchar(10),>
                                                                                N'{2}' ,--<center_name, nvarchar(50),>
                                                                                N'{3}' ,--<name, nvarchar(20),>
                                                                                N'{4}' ,--<sex, nvarchar(10),>
                                                                                N'{5}' ,--<pers_type, nvarchar(10),>
                                                                                N'{6}' ,--<pers_name, nvarchar(30),>
                                                                                N'{7}' ,--<indi_join_sta, char(1),>
                                                                                N'{8}' ,--<indi_sta_name, nvarchar(20),>
                                                                                N'{9}' ,--<official_code, nvarchar(3),>
                                                                                N'{10}' ,--<official_name, nvarchar(20),>
                                                                                N'{11}' ,--<hire_type, nvarchar(2),>
                                                                                N'{12}' ,--<hire_name, nvarchar(20),>
                                                                                N'{13}' ,--<idcard, nvarchar(25),>
                                                                                N'{14}' ,--<insr_code, nvarchar(30),>
                                                                                N'{15}' ,--<telephone, nvarchar(25),>
                                                                                N'{16}' ,--<birthday, datetime,>
                                                                                N'{17}' ,--<post_code, nvarchar(10),>
                                                                                N'{18}' ,--<corp_id, nvarchar(20),>
                                                                                N'{19}' ,--<corp_name, nvarchar(100),>
                                                                                N'{20}' ,--<freeze_sta, nvarchar(100),>
                                                                                N'{21}' ,--<last_balance, numeric(20,4),>
                                                                                N'{22}' ,--<LoginUser, nvarchar(50),>
                                                                                GETDATE() --<LoginTime, datetime,> 
                                                            END", dr["indi_id"].ToString(), dr["center_id"].ToString(), dr["center_name"].ToString(), dr["name"].ToString()
                                                                        , dr["sex"].ToString(), dr["pers_type"].ToString(), dr["pers_name"].ToString(), dr["indi_join_sta"].ToString()
                                                                        , dr["indi_sta_name"].ToString(), dr["official_code"].ToString(), dr["official_name"].ToString(), dr["hire_type"].ToString()
                                                                        , dr["hire_name"].ToString(), dr["idcard"].ToString(), dr["insr_code"].ToString(), dr["telephone"].ToString()
                                                                        , dr["birthday"].ToString(), dr["post_code"].ToString(), dr["corp_id"].ToString(), dr["corp_name"].ToString()
                                                                        , dr["freeze_sta"].ToString(), dr["last_balance"].ToString(), this._userName);
                    int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(SQLString);

                    if (temp == 1)
                    {
                        SendUIMsg(UIMsg.WriteMsg, string.Format("成功保存【个人电脑号：{0} 姓名：{1}】的信息！！！", indi_id, name));
                    }
                    else
                    {
                        SendUIMsg(UIMsg.WriteMsg, string.Format("【个人电脑号：{0} 姓名：{1}】的信息已存在，放弃保存！！！", indi_id, name));
                    }

                    SendUIMsg(UIMsg.Close);
                }
                catch (Exception ex)
                {
                    SendUIMsg(UIMsg.Close);
                    SendUIMsg(UIMsg.MsgError, ex.Message);
                }
            }
        }

        #endregion

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
                    case MZ_InfoQueryUIMsg.DisabledQueryButton:
                        this.btnQuery.Enabled = false;
                        break;
                    case MZ_InfoQueryUIMsg.EnableQueryButton:
                        this.btnQuery.Enabled = true;
                        break;
                    case MZ_InfoQueryUIMsg.BindPersonInfo:
                        BindPersonInfo(parameter.Object);
                        break;
                    case MZ_InfoQueryUIMsg.BindFreezeInfo:
                        BindFreezeInfo(parameter.Object);
                        break;
                    case MZ_InfoQueryUIMsg.BindTotalbizInfo:
                        BindTotalbizInfo(parameter.Object);
                        break;
                    case MZ_InfoQueryUIMsg.DisabledSaveButton:
                        this.btnSave.Enabled = false;
                        break;
                    case MZ_InfoQueryUIMsg.EnableSaveButton:
                        this.btnSave.Enabled = true;
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
        public class MZ_InfoQueryUIMsg
        {
            public const string BindPersonInfo = "BindPersonInfo";
            public const string BindFreezeInfo = "BindFreezeInfo";
            public const string BindTotalbizInfo = "BindTotalbizInfo";
            public const string DisabledQueryButton = "DisabledQueryButton";
            public const string EnableQueryButton = "EnableQueryButton";
            public const string DisabledSaveButton = "DisabledSaveButton";
            public const string EnableSaveButton = "EnableSaveButton";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxQueryType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnQuery.PerformClick();
            }
        }
    }
}