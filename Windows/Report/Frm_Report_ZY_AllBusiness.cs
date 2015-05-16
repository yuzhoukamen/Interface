using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Windows.Class;
using InterfaceClass;
using C1.Win.C1FlexGrid;

namespace Windows.Report
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_Report_ZY_AllBusiness : BaseForm
    {
        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// 就医登记号
        /// </summary>
        private string _serial_no = "";

        /// <summary>
        /// 总费用
        /// </summary>
        private string _totalFee = "";

        /// <summary>
        /// 开始日期
        /// </summary>
        private string _startDate = string.Empty;

        /// <summary>
        /// 截至日期
        /// </summary>
        private string _endDate = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private string _fin_flag = "0";

        /// <summary>
        /// 
        /// </summary>
        private string _exec_flag = "inhospinfo";

        /// <summary>
        /// 
        /// </summary>
        private string _in_flag = "0";

        /// <summary>
        /// 
        /// </summary>
        private string _outhosp_flag = "0";

        /// <summary>
        /// 是否选择就医登记号（1为选择，其他都不选择）
        /// </summary>
        private string _selectedFlag = "";

        /// <summary>
        /// 
        /// </summary>
        private InterfaceClass.HN.BusCostInfo.AllOrders.Info _info = null;

        public InterfaceClass.HN.BusCostInfo.AllOrders.Info Info
        {
            get { return this._info; }
            set { this._info = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Frm_Report_ZY_AllBusiness(long userID)
        {
            InitializeComponent();

            this._userID = userID;
            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 
        /// </summary>
        public Frm_Report_ZY_AllBusiness(long userID, string flag)
        {
            InitializeComponent();

            this._userID = userID;
            this._selectedFlag = flag;
            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Report_ZY_AllBusiness_Load(object sender, EventArgs e)
        {
            InitComboBox();

            QueryAndSetUserInfo();

            SetC1FlexGridDefaultAttribute(this.c1FlexGridInfo);

            FormatC1FlexGridInfo();

            this.dateTimePickerStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.dateTimePickerEndDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            this.lblTotalFee.Text = string.Empty;

            SetC1FlexGridRowBackGroundColor();

            this.radioButtonNo.PerformClick();
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        private void SetC1FlexGridRowBackGroundColor()
        {
            this.c1FlexGridInfo.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;

            this.c1FlexGridInfo.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(
                delegate(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
                {
                    if (e.Row >= this.c1FlexGridInfo.Rows.Fixed)
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
                if (this.c1FlexGridInfo.Cols.Contains("fees"))
                {

                    string fees = this.c1FlexGridInfo.Rows[rowIndex]["fees"].ToString().Trim();

                    Color color;
                    CellStyle mystyle;
                    string name = string.Empty;

                    switch (fees)
                    {
                        case "0":
                            color = Color.OrangeRed;
                            name = "MyStyleOrangeRed";
                            break;
                        default:
                            color = Color.White;
                            break;
                    }

                    if (name != string.Empty)
                    {
                        mystyle = this.c1FlexGridInfo.Styles.Add(name);
                        mystyle.BackColor = color;
                        this.c1FlexGridInfo.Rows[rowIndex].Style = mystyle;
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
        private void FormatC1FlexGridInfo()
        {
            this.c1FlexGridInfo.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;

            this.c1FlexGridInfo.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(
                delegate(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
                {
                    if (e.Row >= this.c1FlexGridInfo.Rows.Fixed)
                    {
                        SetSex(e.Row);
                    }
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex"></param>
        private void SetSex(int rowIndex)
        {
            if (this.c1FlexGridInfo.Cols.Contains("sex"))
            {
                string value = this.c1FlexGridInfo.Rows[rowIndex]["sex"].ToString().Trim();

                if (value == "0" || value == "1")
                {
                    this.c1FlexGridInfo.Rows[rowIndex]["sex"] = (value == "1" ? "男" : "女");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitComboBox()
        {
            /*
            InitComboBox(this.cBox_fin_flag, "Name", "Value", string.Format(@"SELECT  '0' AS 'Value' ,
                                                                                    '未结算' AS 'Name'
                                                                            UNION ALL
                                                                            SELECT  '1' ,
                                                                                    '已结算'
                                                                            UNION ALL
                                                                            SELECT  'all' ,
                                                                                    '全部'
                                                                            ORDER BY Value"), true);

            InitComboBox(this.cBox_exec_flag, "Name", "Value", string.Format(@"SELECT  'all' AS 'Value' ,
                                                                                        '所有业务' AS 'Name'
                                                                                UNION ALL
                                                                                SELECT  'inhospinfo' ,
                                                                                        '在院业务'
                                                                                UNION ALL
                                                                                SELECT  'outhospinfo' ,
                                                                                        '出院业务'
                                                                                ORDER BY value"), true);

            InitComboBox(this.cBox_in_flag, "Name", "Value", string.Format(@"SELECT  '0' AS 'Value' ,
                                                                                    '业务未结束' AS 'Name'
                                                                            UNION ALL
                                                                            SELECT  '1' ,
                                                                                    '业务已结束'
                                                                            ORDER BY value"), true);

            InitComboBox(this.cBox_outhosp_flag, "Name", "Value", string.Format(@"SELECT  '0' AS 'Value' ,
                                                                                        '未出院' AS 'Name'
                                                                                UNION ALL
                                                                                SELECT  '1' ,
                                                                                        '已出院'
                                                                              ORDER BY value"), true);
             **/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this._startDate = this.dateTimePickerStartDate.Text;
            this._endDate = this.dateTimePickerEndDate.Text;

            SetC1FlexGridNullDataTable(this.c1FlexGridInfo);


            CreateAndStartThread(this._thread, ThreadQuery);
        }

        /// <summary>
        /// 查询线程
        /// </summary>
        private void ThreadQuery()
        {
            SendUIMsg(Report_ZY_AllBusinessUIMsg.DisabledQueryButton);

            Query();

            SendUIMsg(Report_ZY_AllBusinessUIMsg.EnabledQueryButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Query()
        {
            try
            {
                SendUIMsg(UIMsg.Display, string.Format("正在从中心服务器提取从{0}到{1}时间段的住院业务信息，请稍后......", this._startDate, this._endDate));

                InterfaceClass.HN.BusCostInfo.AllOrders.GetAllOrdersParameters parameter = new InterfaceClass.HN.BusCostInfo.AllOrders.GetAllOrdersParameters();

                parameter.center_id = baseInterfaceHN.Oper_centerid;
                parameter.hospital_id = baseInterfaceHN.Oper_hospitalid;
                parameter.biz_type = "12";
                parameter.center_flag = "0";
                parameter.fin_flag = this._fin_flag;
                parameter.exec_flag = this._exec_flag;
                parameter.in_flag = this._in_flag;
                parameter.outhosp_flag = this._outhosp_flag;
                parameter.reimburse_flag = "0";
                parameter.query_row_sum = "0";
                parameter.viewrows = "0";
                parameter.page = "0";
                parameter.from_date = this._startDate;
                parameter.to_date = this._endDate;

                InterfaceClass.HN.BusCostInfo.AllOrders.AllOrders allOrders = new InterfaceClass.HN.BusCostInfo.AllOrders.AllOrders(baseInterfaceHN);

                List<InterfaceClass.HN.BusCostInfo.AllOrders.Info> listInfo = allOrders.GetAllOrders(parameter);

                DataTable dt = TToDataTable<InterfaceClass.HN.BusCostInfo.AllOrders.Info>(listInfo);

                SendUIMsg(Report_ZY_AllBusinessUIMsg.DisplayInfo, dt);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(ex.Message);
            }
        }

        /// <summary>
        /// 显示结果信息
        /// </summary>
        /// <param name="p"></param>
        private void DisplayInfo(object p)
        {
            DataTable dt = (DataTable)p;

            if (dt == null || dt.Rows.Count == 0)
            {
                SetC1FlexGridNullDataTable(this.c1FlexGridInfo);
                return;
            }

            this.c1FlexGridInfo.DataSource = (DataTable)p;

            this.c1FlexGridInfo.Cols["hospital_id"].Visible = false;
            this.c1FlexGridInfo.Cols["hospital_name"].Visible = false;
            this.c1FlexGridInfo.Cols["biz_type"].Visible = false;
            this.c1FlexGridInfo.Cols["pers_type"].Visible = false;
            this.c1FlexGridInfo.Cols["office_grade"].Visible = false;
            this.c1FlexGridInfo.Cols["in_area_name"].Visible = false;
            this.c1FlexGridInfo.Cols["in_dept_name"].Visible = false;
            this.c1FlexGridInfo.Cols["in_bed"].Visible = false;
            this.c1FlexGridInfo.Cols["bed_type"].Visible = false;
            this.c1FlexGridInfo.Cols["fin_disease"].Visible = false;
            this.c1FlexGridInfo.Cols["reimburse_flag"].Visible = false;
            this.c1FlexGridInfo.Cols["patient_id"].Visible = false;
            this.c1FlexGridInfo.Cols["district_code"].Visible = false;
            this.c1FlexGridInfo.Cols["case_id"].Visible = false;
            this.c1FlexGridInfo.Cols["treatment_type"].Visible = false;

            this.c1FlexGridInfo.Cols["indi_id"].Width = 75;
            this.c1FlexGridInfo.Cols["serial_no"].Width = 75;
            this.c1FlexGridInfo.Cols["disease"].Width = 230;
            this.c1FlexGridInfo.Cols["reg_man"].Width = 70;
            this.c1FlexGridInfo.Cols["begin_date"].Width = 80;
            this.c1FlexGridInfo.Cols["end_date"].Width = 80;
            this.c1FlexGridInfo.Cols["name"].Width = 60;
            this.c1FlexGridInfo.Cols["sex"].Width = 35;
            this.c1FlexGridInfo.Cols["idcard"].Width = 120;
            this.c1FlexGridInfo.Cols["corp_name"].Width = 235;
            this.c1FlexGridInfo.Cols["fin_date"].Width = 130;

            if (this.c1FlexGridInfo.Cols.Contains("indi_id"))
            {
                double sum = 0;

                for (int i = 1; i < this.c1FlexGridInfo.Rows.Count; i++)
                {
                    sum += double.Parse(this.c1FlexGridInfo.Rows[i]["fees"].ToString().Trim());
                }

                this.lblTotalFee.Text = string.Format(@"总金额：{0}元", sum.ToString("0.00"));
            }
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

                Parameter paremeter = (Parameter)context;

                switch (paremeter.Name)
                {
                    case Report_ZY_AllBusinessUIMsg.DisabledQueryButton:
                        this.btnQuery.Enabled = false;
                        break;
                    case Report_ZY_AllBusinessUIMsg.EnabledQueryButton:
                        this.btnQuery.Enabled = true;
                        break;
                    case Report_ZY_AllBusinessUIMsg.DisplayInfo:
                        DisplayInfo(paremeter.Object);
                        break;
                    case Report_ZY_AllBusinessUIMsg.DisabledPrintButton:
                        this.btnPrint.Enabled = false;
                        break;
                    case Report_ZY_AllBusinessUIMsg.EnabledPrintButton:
                        this.btnPrint.Enabled = true;
                        break;
                    case Report_ZY_AllBusinessUIMsg.PrintOrder:
                        PrintOrder(paremeter.Object);
                        break;
                    case Report_ZY_AllBusinessUIMsg.DisabledCancelInHospitalRegisterButton:
                        this.btnCancelInHospitalRegister.Enabled = false;
                        break;
                    case Report_ZY_AllBusinessUIMsg.EnabledCancelInHospitalRegisterButton:
                        this.btnCancelInHospitalRegister.Enabled = true;
                        break;
                    case Report_ZY_AllBusinessUIMsg.QueryData:
                        this.btnQuery.PerformClick();
                        break;
                    case Report_ZY_AllBusinessUIMsg.DisabledCancelInHospitalSettlement:
                        this.btnCancelInHospitalSettlement.Enabled = false;
                        break;
                    case Report_ZY_AllBusinessUIMsg.EnabledCancelInHospitalSettlement:
                        this.btnCancelInHospitalSettlement.Enabled = true;
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
        private void PrintOrder(object p)
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
        public class Report_ZY_AllBusinessUIMsg
        {
            public const string DisabledQueryButton = "DisabledQueryButton";
            public const string EnabledQueryButton = "EnabledQueryButton";
            public const string DisplayInfo = "DisplayInfo";
            public const string DisabledPrintButton = "DisabledPrintButton";
            public const string EnabledPrintButton = "EnabledPrintButton";
            public const string DisabledCancelInHospitalRegisterButton = "DisabledCancelInHospitalRegisterButton";
            public const string EnabledCancelInHospitalRegisterButton = "EnabledCancelInHospitalRegisterButton";
            public const string DisabledCancelInHospitalSettlement = "DisabledCancelInHospitalSettlement";
            public const string EnabledCancelInHospitalSettlement = "EnabledCancelInHospitalSettlement";
            public const string PrintOrder = "PrintOrder";
            public const string QueryData = "QueryData";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Report_ZY_AllBusiness_Shown(object sender, EventArgs e)
        {
            this.btnQuery.PerformClick();

            this.btnAllInfo.Enabled = false;
            this.btnCancelInHospitalSettlement.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Excel文件|*.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DisplayTips("正在导出业务信息......");

                    string fileName = sfd.FileName;

                    if (!fileName.EndsWith(".xls"))
                    {
                        fileName += ".xls";
                    }

                    this.c1FlexGridInfo.SaveGrid(fileName, FileFormatEnum.Excel, FileFlags.IncludeFixedCells);

                    CloseTips();

                    CommonFunctions.MsgInfo("文件" + fileName + "保存成功！！！");
                }
                catch (Exception ex)
                {
                    CloseTips();
                    CommonFunctions.MsgError("导出业务信息失败，失败原因：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.c1FlexGridInfo.Cols.Contains("serial_no") && this.c1FlexGridInfo.RowSel > 0)
            {
                this._serial_no = this.c1FlexGridInfo.Rows[this.c1FlexGridInfo.RowSel]["serial_no"].ToString().Trim();

                CreateAndStartThread(this._thread, ThreadPrintOrder);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial_no"></param>
        private void ThreadPrintOrder()
        {
            SendUIMsg(Report_ZY_AllBusinessUIMsg.DisabledPrintButton);
            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器获取【就医登记号为：" + this._serial_no + "】的住院结算单，请稍后......");

                InterfaceClass.HN.BusCostInfo.MZOrders.MZOrders mzOrders = new InterfaceClass.HN.BusCostInfo.MZOrders.MZOrders(baseInterfaceHN);

                InterfaceClass.HN.BusCostInfo.MZOrders.GetMZOrdersOutParameters outParameter = mzOrders.GetMZOrders(baseInterfaceHN.Oper_hospitalid, this._serial_no, "dw_yd_print_xn");

                DataSet ds = new DataSet();

                this._totalFee = outParameter.fund.total_pay;

                ds.Tables.Add(TToDataTable<InterfaceClass.HN.BusCostInfo.MZOrders.Fund>(outParameter.fund));
                ds.Tables.Add(TToDataTable<InterfaceClass.HN.BusCostInfo.MZOrders.Info>(outParameter.ListInfo));

                SendUIMsg(UIMsg.Close);
                SendUIMsg(Report_ZY_AllBusinessUIMsg.PrintOrder, ds);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
            SendUIMsg(Report_ZY_AllBusinessUIMsg.EnabledPrintButton);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int RowIndex = this.c1FlexGridInfo.RowSel;

                if (RowIndex > 0)
                {
                    InterfaceClass.HN.BusCostInfo.AllOrders.Info info = new InterfaceClass.HN.BusCostInfo.AllOrders.Info();

                    List<Parameter> listParameter = GetProperties<InterfaceClass.HN.BusCostInfo.AllOrders.Info>(info);

                    foreach (Parameter p in listParameter)
                    {
                        string value = this.c1FlexGridInfo.Rows[RowIndex][p.Name].ToString().Trim();

                        info.SetAttributeValue(p.Name, value);
                    }

                    this._info = info;

                    if (this._selectedFlag == "1")
                    {
                        this.Close();
                    }
                    else
                    {
                        Report.Frm_Report_MZ_BigClassFeeInfo frm = new Frm_Report_MZ_BigClassFeeInfo(info, this._userID, "12");

                        frm.ShowDialog();
                        frm = null;
                        this.btnQuery.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("显示项目明细发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelInHospitalRegister_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = this.c1FlexGridInfo.RowSel;

            if (selectedRowIndex > 0 && this.c1FlexGridInfo.Cols.Contains("serial_no"))
            {
                this._serial_no = this.c1FlexGridInfo.Rows[selectedRowIndex]["serial_no"].ToString().Trim();

                DialogResult dr = MessageBox.Show(string.Format("您真的要取消入院登记(就医登记号：{0})？", this._serial_no), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (DialogResult.Yes == dr)
                {
                    CreateAndStartThread(this._thread, ThreadCancelInHospitalRegister);
                }
            }
            else
            {
                CommonFunctions.MsgError("没有任何选中的记录，请选择一条记录之后重试！！！");
            }
        }

        /// <summary>
        /// 取消入院登记
        /// </summary>
        public void ThreadCancelInHospitalRegister()
        {
            SendUIMsg(Report_ZY_AllBusinessUIMsg.DisabledCancelInHospitalRegisterButton);

            try
            {
                SendUIMsg(UIMsg.Display, string.Format("正在从中心服务器取消【就医登记号为：{0}】的入院登记，请稍后......", this._serial_no));

                InterfaceClass.HN.ZY.CancelInHopitalRegister.Function function = new InterfaceClass.HN.ZY.CancelInHopitalRegister.Function(baseInterfaceHN);

                string msg = function.CancelInHospitalRegister(baseInterfaceHN.Oper_hospitalid, this._serial_no, this._userID.ToString(), this._userName, string.Empty);

                SendUIMsg(UIMsg.Close);

                SendUIMsg(UIMsg.MsgInfo, string.Format("【就医登记号：{0}】，{1}！！！", this._serial_no, msg == string.Empty ? "取消入院登记成功" : msg));
                SendUIMsg(Report_ZY_AllBusinessUIMsg.QueryData);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "取消入院登记发生错误，错误原因：" + ex.Message);
            }

            SendUIMsg(Report_ZY_AllBusinessUIMsg.EnabledCancelInHospitalRegisterButton);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelInHospitalSettlement_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = this.c1FlexGridInfo.RowSel;

            if (selectedRowIndex > 0 && this.c1FlexGridInfo.Cols.Contains("serial_no"))
            {
                this._serial_no = this.c1FlexGridInfo.Rows[selectedRowIndex]["serial_no"].ToString().Trim();
                this.Indi_id = this.c1FlexGridInfo.Rows[selectedRowIndex]["indi_id"].ToString().Trim();

                DialogResult dr = MessageBox.Show(string.Format("您真的要取消出院结算(就医登记号：{0})？", this._serial_no), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (DialogResult.Yes == dr)
                {
                    CreateAndStartThread(this._thread, ThreadCancelInHopitalSettlement);
                }
            }
            else
            {
                CommonFunctions.MsgError("没有任何选中的记录，请选择一条记录之后重试！！！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadCancelInHopitalSettlement()
        {
            SendUIMsg(Report_ZY_AllBusinessUIMsg.DisabledCancelInHospitalSettlement);

            try
            {
                SendUIMsg(UIMsg.Display, string.Format("正在从中心服务器取消【就医登记号为：{0}】的出院结算，请稍后......", this._serial_no));

                InterfaceClass.HN.ZY.CancelInHospitalSettlement.Function function = new InterfaceClass.HN.ZY.CancelInHospitalSettlement.Function(baseInterfaceHN);

                string msg = function.CancelInHospitalSettlement("1", baseInterfaceHN.Oper_hospitalid, this._serial_no, "120", this.Indi_id);

                SendUIMsg(UIMsg.Close);

                SendUIMsg(UIMsg.MsgInfo, string.Format("【就医登记号：{0}】，{1}！！！", this._serial_no, msg));
                SendUIMsg(Report_ZY_AllBusinessUIMsg.QueryData);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "取消出院结算发生错误，错误原因：" + ex.Message);
            }

            SendUIMsg(Report_ZY_AllBusinessUIMsg.EnabledCancelInHospitalSettlement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPatientInfo_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = this.c1FlexGridInfo.RowSel;

            if (selectedRowIndex > 0 && this.c1FlexGridInfo.Cols.Contains("serial_no"))
            {
                this._serial_no = this.c1FlexGridInfo.Rows[selectedRowIndex]["serial_no"].ToString().Trim();

                ZY.Frm_PatientInfo frm = new Windows.ZY.Frm_PatientInfo(this._userID, this._serial_no);

                frm.ShowDialog();

                frm = null;
            }
            else
            {
                CommonFunctions.MsgError("没有任何选中的记录，请选择一条记录之后重试！！！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllInfo_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = this.c1FlexGridInfo.RowSel;

            if (selectedRowIndex > 0 && this.c1FlexGridInfo.Cols.Contains("serial_no"))
            {
                string indi_id = this.c1FlexGridInfo.Rows[selectedRowIndex]["indi_id"].ToString().Trim();

                Report.Frm_Report_AllInfo frm = new Frm_Report_AllInfo(this._userID, indi_id);

                frm.ShowDialog();

                frm = null;
            }
            else
            {
                CommonFunctions.MsgError("没有任何选中的记录，请选择一条记录之后重试！！！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Report_ZY_AllBusiness_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_foregift_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = this.c1FlexGridInfo.RowSel;

            if (selectedRowIndex > 0 && this.c1FlexGridInfo.Cols.Contains("serial_no"))
            {
                this._serial_no = this.c1FlexGridInfo.Rows[selectedRowIndex]["serial_no"].ToString().Trim();

                ZY.Frm_UpdateForegift frm = new Windows.ZY.Frm_UpdateForegift(this._userID, this._serial_no);

                frm.ShowDialog();

                frm = null;
            }
            else
            {
                CommonFunctions.MsgError("没有任何选中的记录，请选择一条记录之后重试！！！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutHospitalSettlement_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = this.c1FlexGridInfo.RowSel;

            if (selectedRowIndex > 0 && this.c1FlexGridInfo.Cols.Contains("serial_no"))
            {
                this._serial_no = this.c1FlexGridInfo.Rows[selectedRowIndex]["serial_no"].ToString().Trim();
                this.Indi_id = this.c1FlexGridInfo.Rows[selectedRowIndex]["indi_id"].ToString().Trim();

                ZY.Frm_OutHospitalSettlement frm = new Windows.ZY.Frm_OutHospitalSettlement(this._userID, this._serial_no, this.Indi_id);

                frm.ShowDialog();

                frm = null;

                this.btnQuery.PerformClick();
            }
            else
            {
                CommonFunctions.MsgError("没有任何选中的记录，请选择一条记录之后重试！！！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFeeDetails_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = this.c1FlexGridInfo.RowSel;

            if (selectedRowIndex > 0 && this.c1FlexGridInfo.Cols.Contains("serial_no"))
            {
                this._serial_no = this.c1FlexGridInfo.Rows[selectedRowIndex]["serial_no"].ToString().Trim();
                this.Indi_id = this.c1FlexGridInfo.Rows[selectedRowIndex]["indi_id"].ToString().Trim();

                ZY.Frm_FeeDetails frm = new Windows.ZY.Frm_FeeDetails(this._userID, this.Indi_id, this._serial_no);

                frm.ShowDialog();

                frm = null;

                this.btnQuery.PerformClick();
            }
            else
            {
                CommonFunctions.MsgError("没有任何选中的记录，请选择一条记录之后重试！！！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonNo_Click(object sender, EventArgs e)
        {
            this._fin_flag = "0";//未结算
            this._exec_flag = "inhospinfo";
            this._in_flag = "0";
            this._outhosp_flag = "0";

            this.btnAllInfo.Enabled = false;
            this.btnCancelInHospitalSettlement.Enabled = false;

            this.btnCancelInHospitalRegister.Enabled = true;
            this.btnPatientInfo.Enabled = true;
            this.buttonUpdate_foregift.Enabled = true;
            this.btnFeeDetails.Enabled = true;
            this.btnOutHospitalSettlement.Enabled = true;

            this.btnQuery.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonYes_Click(object sender, EventArgs e)
        {
            this._fin_flag = "1";//已结算
            this._exec_flag = "outhospinfo";
            this._in_flag = "1";
            this._outhosp_flag = "1";

            this.btnAllInfo.Enabled = true;
            this.btnCancelInHospitalSettlement.Enabled = true;

            this.btnCancelInHospitalRegister.Enabled = false;
            this.btnPatientInfo.Enabled = false;
            this.buttonUpdate_foregift.Enabled = false;
            this.btnFeeDetails.Enabled = false;
            this.btnOutHospitalSettlement.Enabled = false;

            this.btnQuery.PerformClick();
        }
    }
}