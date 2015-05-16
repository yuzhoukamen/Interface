﻿using System;
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

namespace Windows.ZY
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_RegisterUpdate : BaseForm
    {
        #region 属性

        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// 入院保存入参
        /// </summary>
        private InterfaceClass.HN.ZY.RegisterUpdate.InParameter _inParameter = null;

        /// <summary>
        /// 诊断信息
        /// </summary>
        private List<InterfaceClass.HN.ZY.SaveDiagnoseInfo.DiagnoseInfo> _listDiagnose = null;

        private string _pers_type = string.Empty;

        #endregion

        #region 窗体方法和事件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        public Frm_RegisterUpdate(long userID)
        {
            InitializeComponent();

            this._userID = userID;

            this._SynchronizationContext = SynchronizationContext.Current;

            BindStatusChangeEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="indi_id"></param>
        public Frm_RegisterUpdate(long userID, string indi_id)
        {
            InitializeComponent();

            this._userID = userID;
            this.Indi_id = indi_id;

            this._SynchronizationContext = SynchronizationContext.Current;

            BindStatusChangeEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_RegisterUpdate_Load(object sender, EventArgs e)
        {
            InitComboBox();

            ClearRegisterInfo();

            SetPersonInfoTextBoxReadonly();

            SetC1FlexGridDefaultAttribute(this.c1FlexGridDisease, "请添加诊断信息......");

            QueryAndSetUserInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_RegisterUpdate_Shown(object sender, EventArgs e)
        {
            if (this.Indi_id != null && this.Indi_id != string.Empty)
            {

            }
            else
            {
                this.btnReadCard.PerformClick();

                this._statusEvent.Status = "000";
            }
        }

        #endregion

        #region 初始化和通用方法

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        private void InitComboBox()
        {
            InitTreatmentType();

            InitComboBox(this.cBox_diagnose_code, "Name", "Value", @"SELECT  '入院诊断' AS 'Name' ,
                                                                            '1' AS 'Value'
                                                                    UNION ALL
                                                                    SELECT  '出院诊断' AS 'Name' ,
                                                                            '2' AS 'Value'
                                                                    ORDER BY Value", true);
        }

        /// <summary>
        /// 初始化待遇类别
        /// </summary>
        private void InitTreatmentType()
        {
            InitComboBox(this.cbox_treatment_type, "Name", "Value", @"SELECT  RTRIM(Name) AS 'Value' ,
                                                                            RTRIM(Value) AS 'Name'
                                                                    FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                                                    WHERE   TypeID = 2
                                                                    UNION ALL
                                                                    SELECT  '-1' ,
                                                                            ''
                                                                    ORDER BY Value", true);

            this.cbox_treatment_type.SelectedValue = "120";
            this.cbox_treatment_type.Enabled = false;
        }

        /// <summary>
        /// 清空人员信息
        /// </summary>
        private void ClearRegisterInfo()
        {
            List<List<Parameter>> listListParameter = new List<List<Parameter>>();

            listListParameter.Add(GetProperties<InterfaceClass.HN.MZ.PersonInfo>(new InterfaceClass.HN.MZ.PersonInfo()));
            listListParameter.Add(GetProperties<InterfaceClass.HN.ZY.BIZC131204.InParameter>(new InterfaceClass.HN.ZY.BIZC131204.InParameter()));

            SetTextBoxText(this.groupBoxRegisterInfo, listListParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPersonInfoTextBoxReadonly()
        {
            List<List<Parameter>> lisListParameter = new List<List<Parameter>>();

            lisListParameter.Add(GetProperties<InterfaceClass.HN.MZ.PersonInfo>(new InterfaceClass.HN.MZ.PersonInfo()));

            SetTextBoxReadonly(this.groupBoxRegisterInfo, lisListParameter);
        }

        #endregion

        #region 控件方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCard_Click(object sender, EventArgs e)
        {
            this.btnClear.PerformClick();

            this._statusEvent.Status = "100";

            Frm_ReadCard frm = new Frm_ReadCard(this._userID);

            frm.ShowDialog();

            this._pers_type = string.Empty;
            this.Indi_id = frm.CardNumbers;

            frm = null;

            if (this.Indi_id != string.Empty)
            {
                CreateAndStartThread(this._thread, ThreadReadPersonInfoAndInHospitalBizInfo);
            }
            else
            {
                this._statusEvent.Status = "102";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxValue(this.groupBoxRegisterInfo);
            this.txtBox_ic_no.Clear();
            this.c1FlexGridDisease.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_biz_times_Validating(object sender, CancelEventArgs e)
        {
            string value = this.txtBox_in_days.Text.Trim();

            if (value != string.Empty)
            {
                int result = 0;

                if (!int.TryParse(value, out result))
                {
                    CommonFunctions.MsgError("住院次数不能是除整数以外的其他非法字符！！！");
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryFund_Click(object sender, EventArgs e)
        {
            Frm_Fund frm = new Frm_Fund(this.Indi_id, "12");

            frm.ShowDialog();

            frm = null;
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
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (this.txtBox_serial_no.Text.Trim() == string.Empty)
            {
                CommonFunctions.MsgInfo("就医保存号不能为空！！！");

                return;
            }

            try
            {
                this._inParameter = new InterfaceClass.HN.ZY.RegisterUpdate.InParameter();

                if (!CheckAndSetValue())
                {
                    return;
                }

                List<List<Parameter>> listListParameter = new List<List<Parameter>>();

                listListParameter.Add(GetProperties<InterfaceClass.HN.ZY.RegisterUpdate.InParameter>(this._inParameter));

                GetTextBoxText(this.groupBoxRegisterInfo, ref listListParameter);

                foreach (List<Parameter> listParameter in listListParameter)
                {
                    foreach (Parameter p in listParameter)
                    {
                        List<Parameter> listInParameterArributes = GetProperties<InterfaceClass.HN.ZY.RegisterUpdate.InParameter>(this._inParameter);

                        foreach (Parameter pInParameterAttribute in listInParameterArributes)
                        {
                            if (p.Name == pInParameterAttribute.Name)
                            {
                                this._inParameter.SetAttributeValue(p.Name, p.Value);
                            }
                        }
                    }
                }

                List<InterfaceClass.HN.ZY.SaveDiagnoseInfo.DiagnoseInfo> listDiagnose = new List<InterfaceClass.HN.ZY.SaveDiagnoseInfo.DiagnoseInfo>();

                if (this.c1FlexGridDisease.Cols.Contains("诊断编号"))
                {
                    for (int i = 1; i < this.c1FlexGridDisease.Rows.Count; i++)
                    {
                        string icd = this.c1FlexGridDisease.Rows[i]["诊断编号"].ToString().Trim();
                        string diagnose_code = this.cBox_diagnose_code.SelectedValue.ToString().Trim();


                        InterfaceClass.HN.ZY.SaveDiagnoseInfo.DiagnoseInfo diagnoseInfo = new InterfaceClass.HN.ZY.SaveDiagnoseInfo.DiagnoseInfo();

                        diagnoseInfo.SetAttributeValue("diagnose_sn", i.ToString());
                        diagnoseInfo.SetAttributeValue("diagnose_code", diagnose_code);
                        diagnoseInfo.SetAttributeValue("icd", icd);

                        listDiagnose.Add(diagnoseInfo);
                    }
                }

                this._listDiagnose = listDiagnose;
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("入院保存生成参数失败，请联系管理员！！！");
                return;
            }
            this._statusEvent.Status = "200";

            this._inParameter.serial_no = this.txtBox_serial_no.Text.Trim();

            CreateAndStartThread(this._thread, ThreadSave);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuerySerial_no_Click(object sender, EventArgs e)
        {
            Report.Frm_Report_ZY_AllBusiness frm = new Windows.Report.Frm_Report_ZY_AllBusiness(this._userID, "1");

            frm.ShowDialog();

            if (frm.Info != null)
            {
                this.txtBox_serial_no.Text = frm.Info.serial_no;
            }

            frm = null;
        }

        /// <summary>
        /// 保存线程
        /// </summary>
        private void ThreadSave()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在努力往中心服务器上传校验保存住院信息修改数据，请稍后......");

                InterfaceClass.HN.ZY.RegisterUpdate.Function function = new InterfaceClass.HN.ZY.RegisterUpdate.Function(baseInterfaceHN);

                function.CheckAndSaveInHospitalInfoUpdate(this._inParameter);

                SendUIMsg(UIMsg.Close);

                SendUIMsg(RegisterUpdateUIMsg.SaveSuccess);
                //SendUIMsg(UIMsg.MsgInfo, "校验保存住院信息修改成功！！！");
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(RegisterUpdateUIMsg.SaveFailure);
                SendUIMsg(UIMsg.MsgError, "校验保存住院信息修改发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadSaveDiagnoseInfo()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在努力往中心服务器上传住院诊断信息，请稍后......");

                InterfaceClass.HN.ZY.SaveDiagnoseInfo.Function function = new InterfaceClass.HN.ZY.SaveDiagnoseInfo.Function(baseInterfaceHN);

                InterfaceClass.HN.ZY.SaveDiagnoseInfo.InParameter inParameter = new InterfaceClass.HN.ZY.SaveDiagnoseInfo.InParameter();

                inParameter.hospital_id = baseInterfaceHN.Oper_hospitalid;
                inParameter.serial_no = this._inParameter.serial_no;
                inParameter.biz_type = "12";
                inParameter.input_staff = this._userID.ToString();
                inParameter.input_man = this._userName;

                function.CheckAndSaveDiagnoseInfo(inParameter, this._listDiagnose);

                SendUIMsg(UIMsg.Close);

                SendUIMsg(RegisterUpdateUIMsg.SaveDiagnoseInfoSuccess);
                SendUIMsg(UIMsg.MsgInfo, "住院诊断信息保存成功！！！");
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(RegisterUpdateUIMsg.SaveDiagnoseInfoFailure);
                SendUIMsg(UIMsg.MsgError, "住院诊断信息保存发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 检查和设置值
        /// </summary>
        /// <returns></returns>
        private bool CheckAndSetValue()
        {
            if (this.txtBox_ic_no.Text.Trim() == string.Empty)
            {
                CommonFunctions.MsgError("请读卡！！！");
                return false;
            }
            if (this.Indi_id == string.Empty)
            {
                CommonFunctions.MsgError("请读卡，获取个人电脑号！！！");
                return false;
            }
            if (this._pers_type == string.Empty)
            {
                CommonFunctions.MsgError("请读卡，获取个人电脑号！！！");
                return false;
            }
            if (this.txtBox_disease.Tag == null || this.txtBox_disease.Tag.ToString().Trim() == string.Empty)
            {
                CommonFunctions.MsgError("请填写第一入院诊断！！！");
                return false;
            }

            this._inParameter.indi_id = this.Indi_id;
            this._inParameter.hospital_id = baseInterfaceHN.Oper_hospitalid;
            this._inParameter.biz_type = "12";
            this._inParameter.treatment_type = this.cbox_treatment_type.SelectedValue.ToString().Trim();
            this._inParameter.reg_staff = this._userID.ToString();
            this._inParameter.reg_man = this._userName;
            this._inParameter.begin_date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this._inParameter.in_dept = string.Empty;
            this._inParameter.in_dept_name = string.Empty;
            this._inParameter.in_area = string.Empty;
            this._inParameter.bed_type = "0";
            this._inParameter.in_disease = this.txtBox_disease.Tag.ToString().Trim();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containControl"></param>
        /// <param name="inParameter"></param>
        private void GetTextBoxText(System.Windows.Forms.Control containControl, string prefix)
        {
            List<Parameter> listParameter = GetProperties<InterfaceClass.HN.ZY.RegisterUpdate.InParameter>(this._inParameter);

            foreach (System.Windows.Forms.Control control in containControl.Controls)
            {
                if (control is TextBox && control.Name.Contains(prefix))
                {
                    foreach (Parameter p in listParameter)
                    {
                        if (control.Name == string.Format(prefix + p.Name))
                        {
                            this._inParameter.SetAttributeValue(p.Name, control.Text);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDiagnose_Click(object sender, EventArgs e)
        {
            Frm_Diagnoise frm = new Frm_Diagnoise();

            frm.ShowDialog();

            Parameter parameter = frm.ReturnParameter;

            frm = null;

            if (parameter != null)
            {
                this.txtBox_disease.Tag = parameter.Name;
                this.txtBox_disease.Text = parameter.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            Frm_Diagnoise frm = new Frm_Diagnoise();

            frm.ShowDialog();

            Parameter parameterDiagnose = frm.ReturnParameter;

            frm = null;

            DataTable dt = new DataTable();

            dt.Columns.Add("诊断编号");
            dt.Columns.Add("诊断名称");

            if (this.c1FlexGridDisease.Cols.Contains("诊断编号"))
            {
                for (int i = 1; i < this.c1FlexGridDisease.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();

                    dr["诊断编号"] = this.c1FlexGridDisease.Rows[i]["诊断编号"].ToString().Trim();
                    dr["诊断名称"] = this.c1FlexGridDisease.Rows[i]["诊断名称"].ToString().Trim();

                    dt.Rows.Add(dr);
                }
            }

            if (parameterDiagnose != null)
            {
                DataRow dataRow = dt.NewRow();

                dataRow["诊断编号"] = parameterDiagnose.Name;
                dataRow["诊断名称"] = parameterDiagnose.Value;

                dt.Rows.Add(dataRow);
            }

            this.c1FlexGridDisease.DataSource = dt;

            this.c1FlexGridDisease.Cols["诊断编号"].Width = 105;
            this.c1FlexGridDisease.Cols["诊断名称"].Width = 180;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = this.c1FlexGridDisease.RowSel;

            if (selectedRowIndex > 0)
            {
                this.c1FlexGridDisease.RemoveItem(selectedRowIndex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridDisease_RowColChange(object sender, EventArgs e)
        {
        }

        #endregion

        #region 通过个人电脑号获取人员信息

        /// <summary>
        /// 
        /// </summary>
        private void ThreadReadPersonInfoAndInHospitalBizInfo()
        {
            SendUIMsg(RegisterUpdateUIMsg.DisabledReadCardButton);

            QueryPersonInfoAndInHospitalBizInfo();

            SendUIMsg(RegisterUpdateUIMsg.EnabledReadCardButton);
        }

        /// <summary>
        /// 查询人员信息
        /// </summary>
        private void QueryPersonInfoAndInHospitalBizInfo()
        {
            try
            {
                SendUIMsg(UIMsg.Display, string.Format("正在从中心服务器获取个人电脑号{0}的病人个人信息、业务信息，请稍后。。。。。。", this.Indi_id));

                InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.Function function = new InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.Function(baseInterfaceHN);

                InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo bizInfo = function.GetPersonInfoAndInHospitalBizInfoBy_indi_id(this.Indi_id, baseInterfaceHN.Oper_hospitalid, "12");

                SendUIMsg(RegisterUpdateUIMsg.SetPersonInfo, bizInfo);
                SendUIMsg(RegisterUpdateUIMsg.ReadCardSuccess);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(RegisterUpdateUIMsg.ReadCardFailure);
                SendUIMsg(UIMsg.MsgError, string.Format("从中心服务器获取个人电脑号{0}的人员信息发生错误，错误原因：" + ex.Message, this.Indi_id));
            }
        }

        #endregion

        #region 消息处理

        /// <summary>
        /// 
        /// </summary>
        public class RegisterUpdateUIMsg
        {
            public const string DisabledReadCardButton = "DisabledReadCardButton";
            public const string EnabledReadCardButton = "EnabledReadCardButton";
            public const string DisabledRegisterButton = "DisabledRegisterButton";
            public const string EnabledRegisterButton = "EnabledRegisterButton";
            public const string DisabledPrintButton = "DisabledPrintButton";
            public const string EnabledPrintButton = "EnabledPrintButton";
            public const string DisabledClearButton = "DisabledClearButton";
            public const string EnabledClearButton = "EnabledClearButton";
            public const string ReadCardSuccess = "ReadCardSuccess";
            public const string ReadCardFailure = "ReadCardFailure";
            public const string SaveSuccess = "SaveSuccess";
            public const string SaveFailure = "SaveFailure";
            public const string SaveDiagnoseInfoSuccess = "SaveDiagnoseInfoSuccess";
            public const string SaveDiagnoseInfoFailure = "SaveDiagnoseInfoFailure";

            public const string SetPersonInfo = "SetPersonInfo";
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
                    case RegisterUpdateUIMsg.DisabledReadCardButton:
                        this.btnReadCard.Enabled = false;
                        break;
                    case RegisterUpdateUIMsg.EnabledReadCardButton:
                        this.btnReadCard.Enabled = true;
                        break;
                    case RegisterUpdateUIMsg.EnabledRegisterButton:
                        this.btnReadCard.Enabled = true;
                        break;
                    case RegisterUpdateUIMsg.DisabledRegisterButton:
                        this.btnReadCard.Enabled = false;
                        break;
                    case RegisterUpdateUIMsg.DisabledPrintButton:
                        this.btnPrint.Enabled = false;
                        break;
                    case RegisterUpdateUIMsg.EnabledPrintButton:
                        this.btnPrint.Enabled = true;
                        break;
                    case RegisterUpdateUIMsg.DisabledClearButton:
                        this.btnClear.Enabled = false;
                        break;
                    case RegisterUpdateUIMsg.EnabledClearButton:
                        this.btnClear.Enabled = true;
                        break;
                    case RegisterUpdateUIMsg.SetPersonInfo:
                        SetPersonInfo(parameter.Object);
                        break;
                    case RegisterUpdateUIMsg.ReadCardSuccess:
                        this._statusEvent.Status = "101";
                        break;
                    case RegisterUpdateUIMsg.ReadCardFailure:
                        this._statusEvent.Status = "102";
                        break;
                    case RegisterUpdateUIMsg.SaveSuccess:
                        this._statusEvent.Status = "201";
                        this._statusEvent.Status = "300";
                        CreateAndStartThread(this._thread, ThreadSaveDiagnoseInfo);
                        break;
                    case RegisterUpdateUIMsg.SaveDiagnoseInfoSuccess:
                        this._statusEvent.Status="301";
                        break;
                    case RegisterUpdateUIMsg.SaveDiagnoseInfoFailure:
                        this._statusEvent.Status = "302";
                        break;
                    case RegisterUpdateUIMsg.SaveFailure:
                        this._statusEvent.Status = "202";
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
        /// 设置人员信息
        /// </summary>
        /// <param name="p"></param>
        private void SetPersonInfo(object p)
        {
            List<List<Parameter>> listListParameter = new List<List<Parameter>>();

            InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo bizInfo = (InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo)p;

            listListParameter.Add(GetProperties<InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo>(bizInfo));

            SetTextBoxText(this.groupBoxRegisterInfo, listListParameter);

            this.txtBox_ic_no.Text = bizInfo.ic_no;
            this._pers_type = ((InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo)p).pers_type;
            this.txtBox_sex.Text = (this.txtBox_sex.Text.Trim() == "1" ? "男" : "女");
            this.txtBox_old_patient_id.Text = bizInfo.patient_id;
            this.txtBox_disease.Tag = bizInfo.in_disease;
            this.txtBox_disease.Text = bizInfo.in_disease_name;
            this.txtBox_begin_date.Text = bizInfo.begin_date;
        }

        #endregion

        #region 重新状态改变事件

        /// <summary>
        /// 重新状态改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void StatusEvent_OnStatusChange(object sender, EventArgs e)
        {
            switch (this._statusEvent.Status)
            {
                case "000"://窗体加载完成之后
                    this.btnReadCard.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnQueryFund.Enabled = false;
                    this.btnRegister.Enabled = false;
                    this.btnPrint.Enabled = false;
                    this.btnClear.Enabled = false;
                    break;
                case "100"://读卡的时候
                    this.txtBox_serial_no.Clear();
                    this.btnReadCard.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.btnQueryFund.Enabled = false;
                    this.btnRegister.Enabled = false;
                    this.btnPrint.Enabled = false;
                    this.btnClear.Enabled = false;
                    break;
                case "101"://读卡成功
                    this.btnReadCard.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnQueryFund.Enabled = true;
                    this.btnRegister.Enabled = true;
                    this.btnPrint.Enabled = false;
                    this.btnClear.Enabled = false;
                    break;
                case "102"://读卡失败
                    this.btnReadCard.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnQueryFund.Enabled = false;
                    this.btnRegister.Enabled = false;
                    this.btnPrint.Enabled = false;
                    this.btnClear.Enabled = false;
                    break;
                case "300":
                case "200"://保存的时候
                    this.btnReadCard.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.btnQueryFund.Enabled = false;
                    this.btnRegister.Enabled = false;
                    this.btnPrint.Enabled = false;
                    this.btnClear.Enabled = false;
                    break;
                case "301":
                case "201"://保存成功
                    this.btnReadCard.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnQueryFund.Enabled = true;
                    this.btnRegister.Enabled = false;
                    this.btnPrint.Enabled = true;
                    this.btnClear.Enabled = true;
                    break;
                case "202"://保存失败
                case "302":
                    this.btnReadCard.Enabled = true;
                    this.btnCancel.Enabled = true;
                    this.btnQueryFund.Enabled = true;
                    this.btnRegister.Enabled = true;
                    this.btnPrint.Enabled = false;
                    this.btnClear.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}