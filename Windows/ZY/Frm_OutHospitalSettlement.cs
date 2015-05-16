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
using System.Reflection;

namespace Windows.ZY
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_OutHospitalSettlement : BaseForm
    {
        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// 就医登记号
        /// </summary>
        private string _serial_no = string.Empty;

        /// <summary>
        /// 出院结算入参
        /// </summary>
        private InterfaceClass.HN.ZY.OutHospitalSettlement.InParameter _inParameter = null;

        private InterfaceClass.HN.ZY.OutHospitalSettlement.OutParameter _outParameter = null;

        /// <summary>
        /// 
        /// </summary>
        public Frm_OutHospitalSettlement(long userID, string serial_no, string indi_id)
        {
            InitializeComponent();

            this._userID = userID;
            this._serial_no = serial_no;
            this.Indi_id = indi_id;

            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_OutHospitalSettlement_Load(object sender, EventArgs e)
        {
            this.serial_no.Text = this._serial_no;
            this.indi_id.Text = this.Indi_id;

            InitDropList();

            QueryAndSetUserInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (InitParameter())
            {
                CreateAndStartThread(this._thread, ThreadSave);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool InitParameter()
        {
            this._inParameter = new InterfaceClass.HN.ZY.OutHospitalSettlement.InParameter();

            List<Parameter> listParameter = GetProperties<InterfaceClass.HN.ZY.OutHospitalSettlement.InParameter>(this._inParameter);

            foreach (System.Windows.Forms.Control control in this.groupBoxMain.Controls)
            {
                if (control is TextBox)
                {
                    foreach (Parameter p in listParameter)
                    {
                        if (p.Name == control.Name)
                        {
                            this._inParameter.SetAttributeValue(p.Name, control.Text.Trim());
                        }
                    }
                }
            }

            if (this.end_disease_name.Tag == null || this.end_disease_name.Tag.ToString().Trim() == string.Empty)
            {
                CommonFunctions.MsgError("【出院诊断】不能为空！！！");

                this.btn_end_disease.PerformClick();
                return false;
            }

            this._inParameter.save_flag = "3";
            this._inParameter.hospital_id = baseInterfaceHN.Oper_hospitalid;
            this._inParameter.last_balance = "";
            this._inParameter.end_disease = this.end_disease_name.Tag.ToString().Trim();
            this._inParameter.end_date = this.txtBox_end_date.Text.Trim();
            this._inParameter.fin_disease1 = (this.fin_disease1.Tag == null ? "" : this.fin_disease1.Tag.ToString().Trim());
            this._inParameter.fin_disease2 = (this.fin_disease2.Tag == null ? "" : this.fin_disease2.Tag.ToString().Trim());
            this._inParameter.fin_info = this.cBox_fin_info.SelectedValue.ToString().Trim();
            this._inParameter.staff_id = this._userID.ToString();
            this._inParameter.staff_name = this._userName;
            this._inParameter.treatment_type = this.cBox_treatment_type.SelectedValue.ToString().Trim();
            this._inParameter.bill_no = "";
            this._inParameter.reg_flag = (this.cBox_reg_flag.SelectedValue.ToString().Trim() == "-1" ? "" : this.cBox_reg_flag.SelectedValue.ToString().Trim());
            this._inParameter.reg_info = (this.cBox_reg_info.SelectedValue == null ? "" : this.cBox_reg_info.SelectedValue.ToString().Trim());
            this._inParameter.serial_apply = "";
            this._inParameter.fetus = "";//(this.radioButton_fetus1.Checked ? "1" : "2");
            this._inParameter.fact_idcard = "";

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadSave()
        {
            try
            {
                SendUIMsg(OutHospitalSettlementUIMsg.DisabledPrintButton);
                SendUIMsg(OutHospitalSettlementUIMsg.DisabledSaveButton);

                SendUIMsg(UIMsg.Display, "正在办理出院结算，请稍后......");

                InterfaceClass.HN.ZY.OutHospitalSettlement.Function func = new InterfaceClass.HN.ZY.OutHospitalSettlement.Function(baseInterfaceHN);

                this._outParameter = func.PatientOutHospitalSettlement(this._inParameter);

                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgInfo, string.Format("办理出院结算成功(业务序列号：{0})！！！", this._outParameter.BizInfo.serial_no));

                if (this._outParameter.BizInfo.serial_no == string.Empty)
                {
                    SendUIMsg(OutHospitalSettlementUIMsg.EnabledSaveButton);
                    SendUIMsg(OutHospitalSettlementUIMsg.DisabledPrintButton);
                }
                else
                {
                    SendUIMsg(OutHospitalSettlementUIMsg.DisabledSaveButton);
                    SendUIMsg(OutHospitalSettlementUIMsg.EnabledPrintButton);
                }
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(OutHospitalSettlementUIMsg.EnabledSaveButton);
                SendUIMsg(UIMsg.MsgError, "住院出院结算(BIZC131256)发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 默认TextBox不可编辑
        /// </summary>
        private void DefaultTextBoxDisabled()
        {
            this.serial_no.Enabled = false;
            this.indi_id.Enabled = false;
            this.cBox_treatment_type.Enabled = false;
            this.btnPrint.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_OutHospitalSettlement_Shown(object sender, EventArgs e)
        {
            DefaultTextBoxDisabled();
        }

        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        private void InitDropList()
        {
            InitComboBox(this.cBox_treatment_type, "Value", "Name", @"SELECT  ID ,
                                                            TypeID ,
                                                            Name ,
                                                            Value ,
                                                            Length ,
                                                            Details
                                                    FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                                    WHERE   TypeID = 2", true);

            this.cBox_treatment_type.SelectedValue = "120";

            InitComboBox(this.cBox_fin_info, "Name", "Value", @"SELECT  ID as Value,Name as 'Name'
                                                            FROM    HIS_InterfaceHN.dbo.JC_InHospitalStatus
                                                            ORDER BY Value", true);

            InitComboBox(this.cBox_reg_flag, "Name", "Value", @"SELECT  ID AS 'Value' ,
                                                                        Name AS 'Name'
                                                                FROM    HIS_InterfaceHN.dbo.JC_BirthType
                                                                UNION ALL
                                                                SELECT  '-1' ,
                                                                        ' '
                                                                ORDER BY Value", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBox_reg_flag_SelectedValueChanged(object sender, EventArgs e)
        {
            string value = this.cBox_reg_flag.SelectedValue.ToString().Trim();

            string str = string.Empty;

            switch (value)
            {
                case "D":
                    str = "(5004,5005,9999)";
                    break;
                case "P":
                    str = "(0,5007)";
                    break;
                case "T":
                    str = "(5001,5002,5003,5008)";
                    break;
                default:
                    str = "('')";
                    break;
            }

            InitComboBox(this.cBox_reg_info, "Value", "Name", string.Format(@"SELECT  *
                                                                            FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                                                            WHERE   TypeID = 13
                                                                                    AND name IN {0}", str), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadPrint()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器获取结算单信息，请稍后。。。");

                InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders.Function func = new InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders.Function(baseInterfaceHN);

                InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders.OutParameter outParameter = func.GetOutHospitalSettlementOrder(baseInterfaceHN.Oper_hospitalid, this._outParameter.BizInfo.serial_no);

                DataSet ds = new DataSet();

                ds.Tables.Add(TToDataTable<InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders.Info>(outParameter.Info));
                ds.Tables.Add(TToDataTable<InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders.Fee>(outParameter.ListFee));
                ds.Tables.Add(TToDataTable<InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders.Seg>(outParameter.ListSeg));
                ds.Tables.Add(TToDataTable<InterfaceClass.HN.ZY.GetOutHospitalSettlementOrders.Fund>(outParameter.Fund));

                SendUIMsg(OutHospitalSettlementUIMsg.OrderDataSet, ds);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "打印出院结算单发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_end_disease_Click(object sender, EventArgs e)
        {
            Frm_Diagnoise frm = new Frm_Diagnoise();

            frm.ShowDialog();

            Parameter parameter = frm.ReturnParameter;

            frm = null;

            if (parameter != null)
            {
                this.end_disease_name.Tag = parameter.Name;
                this.end_disease_name.Text = parameter.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fin_disease1_Click(object sender, EventArgs e)
        {
            Frm_Diagnoise frm = new Frm_Diagnoise();

            frm.ShowDialog();

            Parameter parameter = frm.ReturnParameter;

            frm = null;

            if (parameter != null)
            {
                this.fin_disease1.Tag = parameter.Name;
                this.fin_disease1.Text = parameter.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fin_disease2_Click(object sender, EventArgs e)
        {
            Frm_Diagnoise frm = new Frm_Diagnoise();

            frm.ShowDialog();

            Parameter parameter = frm.ReturnParameter;

            frm = null;

            if (parameter != null)
            {
                this.fin_disease2.Tag = parameter.Name;
                this.fin_disease2.Text = parameter.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class OutHospitalSettlementUIMsg
        {
            public const string DisabledSaveButton = "DisabledSaveButton";
            public const string EnabledSaveButton = "EnabledSaveButton";
            public const string DisabledPrintButton = "DisabledPrintButton";
            public const string EnabledPrintButton = "EnabledPrintButton";
            public const string OrderDataSet = "OrderDataSet";
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

                MethodInfo methodInfo = this.GetType().GetMethod(parameter.Name);
                if (methodInfo == null)
                {
                    throw new Exception(string.Format("没有方法【{0}】", methodInfo));
                }
                else
                {
                    if (parameter.Object != null)
                    {
                        methodInfo.Invoke(this, new object[1] { parameter.Object });
                    }
                    else
                    {
                        methodInfo.Invoke(this, null);
                    }
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
        private void OrderDataSet(object p)
        {
            DataSet ds = (DataSet)p;


        }
    }
}