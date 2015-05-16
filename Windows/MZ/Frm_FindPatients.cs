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

namespace Windows.MZ
{
    public partial class Frm_FindPatients : BaseForm
    {
        private Thread _thread = null;

        private string _startTime = string.Empty;
        private string _endTime = string.Empty;
        private string _patientName = string.Empty;
        private string _cardNumbers = string.Empty;
        private string _kpPerson = string.Empty;
        private int _selectedRowIndex = 0;

        /// <summary>
        /// 默认发票类别为门诊
        /// </summary>
        private int _fpType = 0;

        private List<Parameter> _listPrameter = null;

        public List<Parameter> ListReturnParameter
        {
            get { return this._listPrameter; }
            set { this._listPrameter = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fpType">发票类别</param>
        public Frm_FindPatients(int fpType)
        {
            InitializeComponent();

            this._fpType = fpType;
            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindPatients_Click(object sender, EventArgs e)
        {
            this._startTime = this.dateTimePickerStartTime.Text;
            this._endTime = this.dateTimePickerEndTime.Text;
            this._patientName = this.txtBoxPatientName.Text.Trim();
            this._cardNumbers = this.txtBoxCardNumbers.Text.Trim();
            this._kpPerson = this.txtBoxKPPerson.Text.Trim();

            CreateAndStartThread(this._thread, ThreadFindPatients);
        }

        #region 线程

        private void ThreadFindPatients()
        {
            SendUIMsg(FindPatientsUIMsg.DisabledFindPatientsButton);

            FindPatients();

            SendUIMsg(FindPatientsUIMsg.EnableFindPatientsButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void FindPatients()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在努力查找患者，请稍后......");

                IDataParameter[] parameters = new IDataParameter[6];

                parameters[0] = new SqlParameter("@StartTime", this._startTime);
                parameters[1] = new SqlParameter("@EndTime", this._endTime);
                parameters[2] = new SqlParameter("@CardNumbers", this._cardNumbers);
                parameters[3] = new SqlParameter("@PatientName", this._patientName);
                parameters[4] = new SqlParameter("@KPPerson", this._kpPerson);
                parameters[5] = new SqlParameter("@FPType", this._fpType);

                DataSet ds = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_FindPatient", parameters, "P_FindPatient");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dr["年龄"] = Function.DealAgeResult(double.Parse(dr["年龄"].ToString()));
                }

                SendUIMsg(FindPatientsUIMsg.BindFindPatientsDataTable, ds.Tables[0]);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitUI()
        {
            this.txtBoxPatientName.Clear();
            this.txtBoxCardNumbers.Clear();
            this.txtBoxKPPerson.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_FindPatients_Load(object sender, EventArgs e)
        {
            InitUI();

            SetC1FlexGridAttribute(this.c1FlexGridPatients, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridPatients, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridPatients);
            SetC1FlexGridNullDataTable(this.c1FlexGridPatients);

            this.btnFindPatients.PerformClick();
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
                    case FindPatientsUIMsg.DisabledFindPatientsButton:
                        this.btnFindPatients.Enabled = false;
                        break;
                    case FindPatientsUIMsg.EnableFindPatientsButton:
                        this.btnFindPatients.Enabled = true;
                        break;
                    case FindPatientsUIMsg.BindFindPatientsDataTable:
                        BindFindPatientsDataTable(parameter.Object);
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
        private void BindFindPatientsDataTable(object p)
        {
            this.c1FlexGridPatients.DataSource = (DataTable)p;

            this.c1FlexGridPatients.Cols["发票号"].Width = 45;
            this.c1FlexGridPatients.Cols["发票流水号"].Width = 70;
            this.c1FlexGridPatients.Cols["金额"].Width = 75;
            this.c1FlexGridPatients.Cols["卡号"].Width = 170;
            this.c1FlexGridPatients.Cols["性别"].Width = 50;
            this.c1FlexGridPatients.Cols["患者姓名"].Width = 80;
            this.c1FlexGridPatients.Cols["年龄"].Width = 50;
            this.c1FlexGridPatients.Cols["开票时间"].Width = 135;

            this.c1FlexGridPatients.Cols["患者流水号"].Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public class FindPatientsUIMsg
        {
            public const string DisabledFindPatientsButton = "DisabledFindPatientsButton";
            public const string EnableFindPatientsButton = "EnableFindPatientsButton";
            public const string BindFindPatientsDataTable = "BindFindPatientsDataTable";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxCardNumbers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cardNumbers = this.txtBoxCardNumbers.Text.Trim();

                if (cardNumbers != string.Empty)
                {
                    cardNumbers = CardInfo.GetInstance().DealInputCardNumber(cardNumbers);

                    this.txtBoxCardNumbers.Text = cardNumbers;

                    this.btnFindPatients.Focus();
                    this.btnFindPatients.PerformClick();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridPatients_SelChange(object sender, EventArgs e)
        {
            this._selectedRowIndex = this.c1FlexGridPatients.MouseRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridPatients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this._selectedRowIndex > 0)
                {
                    string name = string.Empty;
                    string value = string.Empty;

                    List<Parameter> listPrameters = new List<Parameter>();
                    Parameter parameter = new Parameter();

                    name = "发票流水号";
                    value = this.c1FlexGridPatients.Rows[this._selectedRowIndex]["发票流水号"].ToString().Trim();
                    listPrameters.Add(GetParameter(name, value));

                    name = "卡号";
                    value = this.c1FlexGridPatients.Rows[this._selectedRowIndex]["卡号"].ToString().Trim();
                    listPrameters.Add(GetParameter(name, value));

                    name = "患者姓名";
                    value = this.c1FlexGridPatients.Rows[this._selectedRowIndex]["患者姓名"].ToString().Trim();
                    listPrameters.Add(GetParameter(name, value));

                    name = "性别";
                    value = this.c1FlexGridPatients.Rows[this._selectedRowIndex]["性别"].ToString().Trim();
                    listPrameters.Add(GetParameter(name, value));

                    name = "年龄";
                    value = this.c1FlexGridPatients.Rows[this._selectedRowIndex]["年龄"].ToString().Trim();
                    listPrameters.Add(GetParameter(name, value));

                    name = "患者流水号";
                    value = this.c1FlexGridPatients.Rows[this._selectedRowIndex]["患者流水号"].ToString().Trim();
                    listPrameters.Add(GetParameter(name, value));

                    this.ListReturnParameter = listPrameters;

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("设置选择的患者信息发生错误，请联系管理员，错误原因：" + ex.Message);
            }
        }
    }
}