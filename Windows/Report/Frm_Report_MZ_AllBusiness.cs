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
using C1.Win.C1FlexGrid;

namespace Windows.Report
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_Report_MZ_AllBusiness : BaseForm
    {
        /// <summary>
        /// 选择列索引
        /// </summary>
        private int _selectedRowIndex = 0;

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
        /// 线程
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Frm_Report_MZ_AllBusiness(long userID)
        {
            InitializeComponent();

            this._SynchronizationContext = SynchronizationContext.Current;
            this._userID = userID;
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Report_MZ_AllBusiness_Load(object sender, EventArgs e)
        {
            SetC1FlexGridAttribute(this.c1FlexGridInfo, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridInfo, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridInfo);
            SetC1FlexGridNullDataTable(this.c1FlexGridInfo);

            FormatC1FlexGridInfo();

            this.dateTimePickerStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.dateTimePickerEndDate.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            this.lblTotalFee.Text = string.Empty;


            QueryAndSetUserInfo();

            SetC1FlexGridRowBackGroundColor();
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this._startDate = this.dateTimePickerStartDate.Text;
            this._endDate = this.dateTimePickerEndDate.Text;

            CreateAndStartThread(this._thread, ThreadQuery);
        }

        /// <summary>
        /// 查询线程
        /// </summary>
        private void ThreadQuery()
        {
            SendUIMsg(Report_MZ_AllBusinessUIMsg.DisabledQueryButton);

            Query();

            SendUIMsg(Report_MZ_AllBusinessUIMsg.EnabledQueryButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Query()
        {
            try
            {
                SendUIMsg(UIMsg.Display, string.Format("正在从中心服务器提取从{0}到{1}时间段的业务信息，请稍后......", this._startDate, this._endDate));

                InterfaceClass.HN.BusCostInfo.AllOrders.GetAllOrdersParameters parameter = new InterfaceClass.HN.BusCostInfo.AllOrders.GetAllOrdersParameters();

                parameter.center_id = baseInterfaceHN.Oper_centerid;
                parameter.hospital_id = baseInterfaceHN.Oper_hospitalid;
                parameter.biz_type = "11";
                parameter.center_flag = "0";
                parameter.fin_flag = "1";
                parameter.exec_flag = "outhospinfo";
                parameter.in_flag = "1";
                parameter.outhosp_flag = "1";
                parameter.reimburse_flag = "0";
                parameter.query_row_sum = "0";
                parameter.viewrows = "0";
                parameter.page = "0";
                parameter.from_date = this._startDate;
                parameter.to_date = this._endDate;

                InterfaceClass.HN.BusCostInfo.AllOrders.AllOrders allOrders = new InterfaceClass.HN.BusCostInfo.AllOrders.AllOrders(baseInterfaceHN);

                List<InterfaceClass.HN.BusCostInfo.AllOrders.Info> listInfo = allOrders.GetAllOrders(parameter);

                DataTable dt = TToDataTable<InterfaceClass.HN.BusCostInfo.AllOrders.Info>(listInfo);

                SendUIMsg(Report_MZ_AllBusinessUIMsg.DisplayInfo, dt);

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

            this.c1FlexGridInfo.DataSource = dt;

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
            this.c1FlexGridInfo.Cols["disease"].Width = 180;
            this.c1FlexGridInfo.Cols["reg_man"].Width = 70;
            this.c1FlexGridInfo.Cols["begin_date"].Width = 80;
            this.c1FlexGridInfo.Cols["end_date"].Width = 80;
            this.c1FlexGridInfo.Cols["name"].Width = 60;
            this.c1FlexGridInfo.Cols["sex"].Width = 35;
            this.c1FlexGridInfo.Cols["idcard"].Width = 120;
            this.c1FlexGridInfo.Cols["corp_name"].Width = 285;
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
                    case Report_MZ_AllBusinessUIMsg.DisabledQueryButton:
                        this.btnQuery.Enabled = false;
                        break;
                    case Report_MZ_AllBusinessUIMsg.EnabledQueryButton:
                        this.btnQuery.Enabled = true;
                        break;
                    case Report_MZ_AllBusinessUIMsg.DisplayInfo:
                        DisplayInfo(paremeter.Object);
                        break;
                    case Report_MZ_AllBusinessUIMsg.DisabledPrintButton:
                        this.btnPrint.Enabled = false;
                        break;
                    case Report_MZ_AllBusinessUIMsg.EnabledPrintButton:
                        this.btnPrint.Enabled = true;
                        break;
                    case Report_MZ_AllBusinessUIMsg.PrintOrder:
                        PrintOrder(paremeter.Object);
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

           string value=Rmb.CmycurD(this._totalFee);

           listParameter.Add(new Parameter("moneyUpper", value));

           Print("100001003", listParameter, (DataSet)p);
        }

        /// <summary>
        /// 
        /// </summary>
        public class Report_MZ_AllBusinessUIMsg
        {
            public const string DisabledQueryButton = "DisabledQueryButton";
            public const string EnabledQueryButton = "EnabledQueryButton";
            public const string DisplayInfo = "DisplayInfo";
            public const string DisabledPrintButton = "DisabledPrintButton";
            public const string EnabledPrintButton = "EnabledPrintButton";
            public const string PrintOrder = "PrintOrder";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Report_MZ_AllBusiness_Shown(object sender, EventArgs e)
        {
            this.btnQuery.PerformClick();
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
            if (this.c1FlexGridInfo.Cols.Contains("serial_no") && this._selectedRowIndex > 0)
            {
                this._serial_no = this.c1FlexGridInfo.Rows[this._selectedRowIndex]["serial_no"].ToString().Trim();

                CreateAndStartThread(this._thread, ThreadPrintOrder);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serial_no"></param>
        private void ThreadPrintOrder()
        {
            SendUIMsg(Report_MZ_AllBusinessUIMsg.DisabledPrintButton);
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
                SendUIMsg(Report_MZ_AllBusinessUIMsg.PrintOrder, ds);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
            SendUIMsg(Report_MZ_AllBusinessUIMsg.EnabledPrintButton);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.c1FlexGridInfo.Cols.Contains("serial_no"))
            {
                this._serial_no = this.c1FlexGridInfo.Rows[this._selectedRowIndex]["serial_no"].ToString().Trim();

                if (this._selectedRowIndex > 0)
                {
                    DialogResult dr = MessageBox.Show(string.Format("你真的要撤销这笔结算单【{0}】吗?", this._serial_no), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                    if (dr == DialogResult.Yes)
                    {
                        CancelOrders();
                    }

                }
                else
                {
                    CommonFunctions.MsgError("请先选择业务信息之后，在进行此操作！！！");
                }
            }
            else
            {
                CommonFunctions.MsgError("请先检索数据！！！");
            }
        }

        /// <summary>
        /// 撤销订单
        /// </summary>
        private void CancelOrders()
        {
            CreateAndStartThread(this._thread, ThreadCancelOrders);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadCancelOrders()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在撤销结算单【" + this._serial_no + "】，请稍后......");

                DataTable dt = GetSerial_no_MZRegChargeInfo();

                InterfaceClass.HN.MZ.MZ_ChangeParameter mz_changeParameter = new InterfaceClass.HN.MZ.MZ_ChangeParameter();

                InterfaceClass.HN.MZ.MZRegChange mzRegChange = new InterfaceClass.HN.MZ.MZRegChange();

                List<Parameter> listParameter = GetProperties<InterfaceClass.HN.MZ.MZRegChange>(mzRegChange);

                foreach (Parameter p in listParameter)
                {
                    string value = dt.Rows[0][p.Name].ToString().Trim();

                    mzRegChange.SetAttributeValue(p.Name, value);
                }
                mzRegChange.save_flag = "1";//改费
                mzRegChange.query_flag = "1";//退费

                mz_changeParameter.MZRegChange = mzRegChange;
                mz_changeParameter.ListFeeInfo = new List<InterfaceClass.HN.MZ.FeeInfo>();

                InterfaceClass.HN.MZ.CheckAndSaveFeeDetails inter = new InterfaceClass.HN.MZ.CheckAndSaveFeeDetails(baseInterfaceHN);

                inter.CheckCalcAndSaveWrittenFeeDetails(mz_changeParameter);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "撤销订单【" + this._serial_no + "】发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataTable GetSerial_no_MZRegChargeInfo()
        {
            string SQLString = string.Format(@"SELECT  HIS_InterfaceHN.dbo.MZRegCharge.*,
                                                       HIS_InterfaceHN.dbo.MZRegBizInfo.serial_no,
                                                       HIS_InterfaceHN.dbo.MZRegBizInfo.trade_no,
                                                       HIS_InterfaceHN.dbo.MZRegBizInfo.bill_no
                                                    FROM    HIS_InterfaceHN.dbo.MZRegCharge
                                                            INNER JOIN HIS_InterfaceHN.dbo.MZRegBizInfo ON HIS_InterfaceHN.dbo.MZRegBizInfo.MZRegID = HIS_InterfaceHN.dbo.MZRegCharge.ID
                                                    WHERE   HIS_InterfaceHN.dbo.MZRegBizInfo.serial_no = N'{0}'", this._serial_no);

            DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

            if (ds.Tables.Count != 1 && ds.Tables[0].Rows.Count != 1)
            {
                throw new Exception("通过就【医登记号：" + this._serial_no + "】从HIS服务器获取的结算信息发生错误，请联系管理员！！！");
            }

            return ds.Tables[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetails_Click(object sender, EventArgs e)
        {

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
                int mouseRowIndex = this.c1FlexGridInfo.MouseRow;

                if (mouseRowIndex > 0)
                {
                    InterfaceClass.HN.BusCostInfo.AllOrders.Info info = new InterfaceClass.HN.BusCostInfo.AllOrders.Info();

                    List<Parameter> listParameter = GetProperties<InterfaceClass.HN.BusCostInfo.AllOrders.Info>(info);

                    foreach (Parameter p in listParameter)
                    {
                        string value = this.c1FlexGridInfo.Rows[mouseRowIndex][p.Name].ToString().Trim();

                        info.SetAttributeValue(p.Name, value);
                    }

                    Report.Frm_Report_MZ_BigClassFeeInfo frm = new Frm_Report_MZ_BigClassFeeInfo(info, this._userID);

                    frm.ShowDialog();
                    frm = null;

                    this.btnQuery.PerformClick();
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
        private void c1FlexGridInfo_SelChange(object sender, EventArgs e)
        {
            this._selectedRowIndex = this.c1FlexGridInfo.MouseRow;
        }
    }
}