using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceClass;
using System.Threading;
using Windows.Class;

namespace Windows.Report
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_Report_AllInfo : BaseForm
    {
        private Thread _thread = null;

        #region 触发事件

        /// <summary>
        /// 
        /// </summary>
        public Frm_Report_AllInfo(long userID)
        {
            InitializeComponent();

            this._SynchronizationContext = SynchronizationContext.Current;

            BindStatusChangeEvents();

            this._userID = userID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="indi_id"></param>
        public Frm_Report_AllInfo(long userID, string indi_id)
        {
            InitializeComponent();

            this._SynchronizationContext = SynchronizationContext.Current;

            BindStatusChangeEvents();

            this.Indi_id = indi_id;
            this._userID = userID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCard_Click(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusChange.ReadCard_ing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Report_AllInfo_Shown(object sender, EventArgs e)
        {
            this._statusEvent.Status = StatusChange.FormShown;

            if (this.Indi_id != null && this.Indi_id != string.Empty)
            {
                JustToLoadPatientInfo();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Report_AllInfo_Load(object sender, EventArgs e)
        {
            QueryAndSetUserInfo();
        }

        #endregion

        /// <summary>
        /// 状态改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void StatusEvent_OnStatusChange(object sender, EventArgs e)
        {
            switch (this._statusEvent.Status)
            {
                case StatusChange.ReadCard_ing:
                    ReadCard_ing();
                    break;
                case StatusChange.ReadCard_success:
                    ReadCard_success();
                    break;
                case StatusChange.ReadCard_failure:
                    ReadCard_failure();
                    break;
                case StatusChange.Click_freezeinfo:
                    FreezeInfo();
                    break;
                case StatusChange.Click_lastbizinfo:
                    LastBizInfo();
                    break;
                case StatusChange.Click_spinfo:
                    SpInfo();
                    break;
                case StatusChange.Click_totalbizinfo:
                    TotalBizInfo();
                    break;
                case StatusChange.FormShown:
                    FormShown();
                    break;
                case StatusChange.Click_elseInfo:
                    Click_elseInfo();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Click_elseInfo()
        {
            CreateAndStartThread(this._thread, ThreadElseInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadElseInfo()
        {
            SendUIMsg(Report_AllInfoUIMsg.DisabledReadCardButton);

            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器通过个人标识取人员信息(BIZC131201)，请稍后......");

                InterfaceClass.HN.ZY.GetPersonInfo.Function function = new InterfaceClass.HN.ZY.GetPersonInfo.Function(baseInterfaceHN);

                InterfaceClass.HN.ZY.GetPersonInfo.Elseinfo elseInfo = function.GetElseinfoBy_indi_id(this.Indi_id, baseInterfaceHN.Oper_hospitalid, "12", baseInterfaceHN.Oper_centerid);

                SendUIMsg(Report_AllInfoUIMsg.SetElseInfo, elseInfo);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "从中心服务器通过个人标识取人员信息(BIZC131201)发生错误，错误原因：" + ex.Message);
            }

            SendUIMsg(Report_AllInfoUIMsg.EnabledReadCardButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void FormShown()
        {
            this.txtBox_CardNumbers.Enabled = false;

            SetTextBoxReadonly(this.groupBoxPersonInfo, "");
            SetTextBoxReadonly(this.tabPage_lastbizinfo, "txtBox_");
            SetTextBoxReadonly(this.tabPage_totalbizinfo, "");

            SetC1FlexGridDefaultAttribute(this.c1FlexGridspinfo);
            SetC1FlexGridDefaultAttribute(this.c1FlexGridfreezeinfo);

            this.txtBox_CardNumbers.Clear();
            ClearTextBoxValue(this.groupBoxPersonInfo);
            ClearTextBoxValue(this.tabPage_lastbizinfo);
            ClearTextBoxValue(this.tabPage_totalbizinfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadCard_failure()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadCard_success()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadCard_ing()
        {
            this._statusEvent.Status = StatusChange.FormShown;

            Frm_ReadCard frm = new Frm_ReadCard(this._userID);

            frm.ShowDialog();

            this.Indi_id = frm.CardNumbers;//获取个人电脑号

            frm = null;

            if (this.Indi_id != string.Empty)
            {
                CreateAndStartThread(this._thread, ThreadReadCard);
            }
        }

        /// <summary>
        /// 直接加载患者信息
        /// </summary>
        private void JustToLoadPatientInfo()
        {
            CreateAndStartThread(this._thread, ThreadReadCard);
        }

        /// <summary>
        /// 读卡线程
        /// </summary>
        private void ThreadReadCard()
        {
            SendUIMsg(Report_AllInfoUIMsg.DisabledReadCardButton);

            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器通过个人标识取人员信息(BIZC131201)，请稍后......");

                InterfaceClass.HN.ZY.GetPersonInfo.Function function = new InterfaceClass.HN.ZY.GetPersonInfo.Function(baseInterfaceHN);

                InterfaceClass.HN.ZY.GetPersonInfo.PersonInfo personInfo = function.GetPersonInfoBy_indi_id(this.Indi_id, baseInterfaceHN.Oper_hospitalid, "12", baseInterfaceHN.Oper_centerid);

                SendUIMsg(Report_AllInfoUIMsg.SetPersonInfo, personInfo);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "从中心服务器通过个人标识取人员信息(BIZC131201)发生错误，错误原因：" + ex.Message);
            }

            SendUIMsg(Report_AllInfoUIMsg.EnabledReadCardButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void FreezeInfo()
        {
            CreateAndStartThread(this._thread, ThreadFreezeInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadFreezeInfo()
        {
            SendUIMsg(Report_AllInfoUIMsg.DisabledReadCardButton);

            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器通过个人标识取人员信息(BIZC131201)，请稍后......");

                InterfaceClass.HN.ZY.GetPersonInfo.Function func = new InterfaceClass.HN.ZY.GetPersonInfo.Function(baseInterfaceHN);

                List<InterfaceClass.HN.ZY.GetPersonInfo.FreezeInfo> listFreezeInfo = func.GetFreezeInfoBy_indi_id(this.Indi_id, baseInterfaceHN.Oper_hospitalid, "12", baseInterfaceHN.Oper_centerid);

                SendUIMsg(Report_AllInfoUIMsg.SetFreezeInfo, listFreezeInfo);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "从中心服务器通过个人标识取人员信息(BIZC131201)发生错误，错误原因：" + ex.Message);
            }

            SendUIMsg(Report_AllInfoUIMsg.EnabledReadCardButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void LastBizInfo()
        {
            CreateAndStartThread(this._thread, ThreadLastBizInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadLastBizInfo() {
            SendUIMsg(Report_AllInfoUIMsg.DisabledReadCardButton);

            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器通过个人标识取人员信息(BIZC131201)，请稍后......");

                InterfaceClass.HN.ZY.GetPersonInfo.Function func = new InterfaceClass.HN.ZY.GetPersonInfo.Function(baseInterfaceHN);

                InterfaceClass.HN.ZY.GetPersonInfo.Lastbizinfo lastbizinfo = func.GetLastbizinfoBy_indi_id(this.Indi_id, baseInterfaceHN.Oper_hospitalid, "12", baseInterfaceHN.Oper_centerid);

                SendUIMsg(Report_AllInfoUIMsg.SetLastbizinfo, lastbizinfo);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "从中心服务器通过个人标识取人员信息(BIZC131201)发生错误，错误原因：" + ex.Message);
            }

            SendUIMsg(Report_AllInfoUIMsg.EnabledReadCardButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SpInfo()
        {
            CreateAndStartThread(this._thread, ThreadSpInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadSpInfo()
        {
            SendUIMsg(Report_AllInfoUIMsg.DisabledReadCardButton);

            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器通过个人标识取人员信息(BIZC131201)，请稍后......");

                InterfaceClass.HN.ZY.GetPersonInfo.Function func = new InterfaceClass.HN.ZY.GetPersonInfo.Function(baseInterfaceHN);

                List<InterfaceClass.HN.ZY.GetPersonInfo.SPInfo> listSPInfo = func.GetSPInfoBy_indi_id(this.Indi_id, baseInterfaceHN.Oper_hospitalid, "12", baseInterfaceHN.Oper_centerid);

                SendUIMsg(Report_AllInfoUIMsg.SetSPInfo, listSPInfo);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "从中心服务器通过个人标识取人员信息(BIZC131201)发生错误，错误原因：" + ex.Message);
            }

            SendUIMsg(Report_AllInfoUIMsg.EnabledReadCardButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void TotalBizInfo()
        {
            CreateAndStartThread(this._thread, ThreadTotalBizInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadTotalBizInfo()
        {
            SendUIMsg(Report_AllInfoUIMsg.DisabledReadCardButton);

            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器通过个人标识取人员信息(BIZC131201)，请稍后......");

                InterfaceClass.HN.ZY.GetPersonInfo.Function func = new InterfaceClass.HN.ZY.GetPersonInfo.Function(baseInterfaceHN);

                InterfaceClass.HN.ZY.GetPersonInfo.Totalbizinfo totalBizInfo = func.GetTotalbizinfoBy_indi_id(this.Indi_id, baseInterfaceHN.Oper_hospitalid, "12", baseInterfaceHN.Oper_centerid);

                SendUIMsg(Report_AllInfoUIMsg.SetTotalBizInfo, totalBizInfo);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "从中心服务器通过个人标识取人员信息(BIZC131201)发生错误，错误原因：" + ex.Message);
            }

            SendUIMsg(Report_AllInfoUIMsg.EnabledReadCardButton);
        }

        /// <summary>
        /// 
        /// </summary>
        public class StatusChange
        {
            /// <summary>
            /// 正在读卡
            /// </summary>
            public const string ReadCard_ing = "ReadCard_ing";

            /// <summary>
            /// 读卡成功
            /// </summary>
            public const string ReadCard_success = "ReadCard_success";

            /// <summary>
            /// 读卡失败
            /// </summary>
            public const string ReadCard_failure = "ReadCard_failure";

            /// <summary>
            /// 上次住院业务信息
            /// </summary>
            public const string Click_lastbizinfo = "Click_lastbizinfo";

            /// <summary>
            /// 业务申请信息
            /// </summary>
            public const string Click_spinfo = "Click_spinfo";

            /// <summary>
            /// 个人基金冻结信息
            /// </summary>
            public const string Click_freezeinfo = "Click_freezeinfo";

            /// <summary>
            /// 个人业务累计信息
            /// </summary>
            public const string Click_totalbizinfo = "Click_totalbizinfo";

            public const string Click_elseInfo = "Click_elseInfo";

            public const string FormShown = "FormShown";
        }

        /// <summary>
        /// 
        /// </summary>
        public class Report_AllInfoUIMsg
        {
            public const string DisabledReadCardButton = "DisabledReadCardButton";
            public const string EnabledReadCardButton = "EnabledReadCardButton";
            public const string SetPersonInfo = "SetPersonInfo";
            public const string SetFreezeInfo = "SetFreezeInfo";
            public const string SetLastbizinfo = "SetLastbizinfo";
            public const string SetSPInfo = "SetSPInfo";
            public const string SetTotalBizInfo = "SetTotalBizInfo";
            public const string SetElseInfo = "SetElseInfo";
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
                    case Report_AllInfoUIMsg.DisabledReadCardButton:
                        this.btnReadCard.Enabled = false;
                        break;
                    case Report_AllInfoUIMsg.EnabledReadCardButton:
                        this.btnReadCard.Enabled = true;
                        break;
                    case Report_AllInfoUIMsg.SetPersonInfo:
                        SetPersonInfo(parameter.Object);
                        break;
                    case Report_AllInfoUIMsg.SetFreezeInfo:
                        SetFreezeInfo(parameter.Object);
                        break;
                    case Report_AllInfoUIMsg.SetLastbizinfo:
                        SetLastbizinfo(parameter.Object);
                        break;
                    case Report_AllInfoUIMsg.SetSPInfo:
                        SetSPInfo(parameter.Object);
                        break;
                    case Report_AllInfoUIMsg.SetTotalBizInfo:
                        SetTotalBizInfo(parameter.Object);
                        break;
                    case Report_AllInfoUIMsg.SetElseInfo:
                        SetElseInfo(parameter.Object);
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
        private void SetElseInfo(object p)
        {
            InterfaceClass.HN.ZY.GetPersonInfo.Elseinfo elseInfo = (InterfaceClass.HN.ZY.GetPersonInfo.Elseinfo)p;

            this.biz_times.Text = elseInfo.biz_times;
            this.txtBox_declare_year.Text = elseInfo.declare_year;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void SetTotalBizInfo(object p)
        {
            InterfaceClass.HN.ZY.GetPersonInfo.Totalbizinfo totalBizInfo = (InterfaceClass.HN.ZY.GetPersonInfo.Totalbizinfo)p;

            List<Parameter> listParameter = GetProperties<InterfaceClass.HN.ZY.GetPersonInfo.Totalbizinfo>(totalBizInfo);

            SetTextBoxText(this.tabPage_totalbizinfo, "", listParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void SetSPInfo(object p)
        {
            List<InterfaceClass.HN.ZY.GetPersonInfo.SPInfo> listSPInfo = (List<InterfaceClass.HN.ZY.GetPersonInfo.SPInfo>)p;

            DataTable dt = TToDataTable<InterfaceClass.HN.ZY.GetPersonInfo.SPInfo>(listSPInfo);

            this.c1FlexGridspinfo.DataSource = dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void SetLastbizinfo(object p)
        {
            InterfaceClass.HN.ZY.GetPersonInfo.Lastbizinfo lastbizinfo = (InterfaceClass.HN.ZY.GetPersonInfo.Lastbizinfo)p;

            List<Parameter> listParameter = GetProperties<InterfaceClass.HN.ZY.GetPersonInfo.Lastbizinfo>(lastbizinfo);

            SetTextBoxText(this.tabPage_lastbizinfo, listParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void SetFreezeInfo(object p)
        {
            List<InterfaceClass.HN.ZY.GetPersonInfo.FreezeInfo> listFreezeInfo = (List<InterfaceClass.HN.ZY.GetPersonInfo.FreezeInfo>)p;

            DataTable dt = TToDataTable<InterfaceClass.HN.ZY.GetPersonInfo.FreezeInfo>(listFreezeInfo);

            this.c1FlexGridfreezeinfo.DataSource = dt;

            this.c1FlexGridfreezeinfo.Cols["fund_id"].Width = 80;
            this.c1FlexGridfreezeinfo.Cols["fund_name"].Width = 180;
            this.c1FlexGridfreezeinfo.Cols["indi_freeze_status"].Width = 80;

            for (int i = 1; i < this.c1FlexGridfreezeinfo.Rows.Count; i++)
            {
                string status = this.c1FlexGridfreezeinfo.Rows[i]["indi_freeze_status"].ToString().Trim();

                switch (status)
                { 
                    case "0":
                        this.c1FlexGridfreezeinfo.Rows[i]["indi_freeze_status"] = "正常";
                        break;
                    case "1":
                        this.c1FlexGridfreezeinfo.Rows[i]["indi_freeze_status"] = "冻结";
                        break;
                    case "2":
                        this.c1FlexGridfreezeinfo.Rows[i]["indi_freeze_status"] = "暂停参保";
                        break;
                    case "3":
                        this.c1FlexGridfreezeinfo.Rows[i]["indi_freeze_status"] = "中止参保";
                        break;
                    case "9":
                        this.c1FlexGridfreezeinfo.Rows[i]["indi_freeze_status"] = "未参保";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void SetPersonInfo(object p)
        {
            InterfaceClass.HN.ZY.GetPersonInfo.PersonInfo personInfo = (InterfaceClass.HN.ZY.GetPersonInfo.PersonInfo)p;

            List<Parameter> listParameter = GetProperties<InterfaceClass.HN.ZY.GetPersonInfo.PersonInfo>(personInfo);

            SetTextBoxText(this.groupBoxPersonInfo, "", listParameter);

            this._statusEvent.Status = StatusChange.Click_elseInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = this.tabControl.SelectedTab.Text;

            if (this.Indi_id != null && this.Indi_id != string.Empty)
            {
                switch (text)
                {
                    case "上次住院业务信息":
                        this._statusEvent.Status = StatusChange.Click_lastbizinfo;
                        break;
                    case "业务申请信息":
                        this._statusEvent.Status = StatusChange.Click_spinfo;
                        break;
                    case "个人基金冻结信息":
                        this._statusEvent.Status = StatusChange.Click_freezeinfo;
                        break;
                    case "个人业务累计信息":
                        this._statusEvent.Status = StatusChange.Click_totalbizinfo;
                        break;
                    case "生育门诊业务信息":
                        break;
                    case "工伤门诊业务信息":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}