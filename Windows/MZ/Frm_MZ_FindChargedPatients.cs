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
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_MZ_FindChargedPatients : BaseForm
    {
        private string _StartTime = string.Empty;
        private string _EndTime = string.Empty;
        private string _ICCard = string.Empty;
        private string _PatientName = string.Empty;
        private int _selectedRowIndex = 0;

        private string _mzRegID = string.Empty;

        public string MZRegID
        {
            get { return this._mzRegID; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Thread _thead = null;

        /// <summary>
        /// 
        /// </summary>
        public Frm_MZ_FindChargedPatients()
        {
            InitializeComponent();

            this._SynchronizationContext = SynchronizationContext.Current;
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
                    case FindChargedPatientsUIMsg.DisabledFindPatientsButton:
                        this.btnFindPatients.Enabled = false;
                        break;
                    case FindChargedPatientsUIMsg.EnabledSFindPatientsButton:
                        this.btnFindPatients.Enabled = true;
                        break;
                    case FindChargedPatientsUIMsg.BindC1FlexGridFindPatients:
                        BindC1FlexGridFindPatients(parameter.Object);
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
        private void BindC1FlexGridFindPatients(object p)
        {
            DataTable dt = (DataTable)p;

            if (dt == null || dt.Rows.Count == 0)
            {
                SetC1FlexGridNullDataTable(this.c1FlexGridChargedPatients);
                return;
            }

            this.c1FlexGridChargedPatients.DataSource = (DataTable)p;

            this.c1FlexGridChargedPatients.Cols["MZRegID"].Visible = false;

            this.c1FlexGridChargedPatients.Cols["center_name"].Caption = "分级统筹中心名称";
            this.c1FlexGridChargedPatients.Cols["center_name"].Width = 120;

            this.c1FlexGridChargedPatients.Cols["card_no"].Caption = "医保卡号";
            this.c1FlexGridChargedPatients.Cols["card_no"].Width = 80;

            this.c1FlexGridChargedPatients.Cols["indi_id"].Caption = "个人电脑号";
            this.c1FlexGridChargedPatients.Cols["indi_id"].Width = 80;

            this.c1FlexGridChargedPatients.Cols["name"].Caption = "姓名";
            this.c1FlexGridChargedPatients.Cols["name"].Width = 80;

            this.c1FlexGridChargedPatients.Cols["sex"].Caption = "性别";
            this.c1FlexGridChargedPatients.Cols["sex"].Width = 40;

            this.c1FlexGridChargedPatients.Cols["birthday"].Caption = "出生日期";
            this.c1FlexGridChargedPatients.Cols["birthday"].Width = 70;

            this.c1FlexGridChargedPatients.Cols["totalMoney"].Caption = "总金额";
            this.c1FlexGridChargedPatients.Cols["totalMoney"].Width = 80;

            this.c1FlexGridChargedPatients.Cols["LoginTime"].Caption = "收费时间";
            this.c1FlexGridChargedPatients.Cols["LoginTime"].Width = 130;

            this.c1FlexGridChargedPatients.Cols["LoginUser"].Caption = "收费人";
            this.c1FlexGridChargedPatients.Cols["LoginUser"].Width = 80;

            this.c1FlexGridChargedPatients.Cols["serial_no"].Caption = "就医登记号";
            this.c1FlexGridChargedPatients.Cols["serial_no"].Width = 80;
        }

        /// <summary>
        /// 
        /// </summary>
        public class FindChargedPatientsUIMsg
        {
            public const string DisabledFindPatientsButton = "DisabledFindPatientsButton";
            public const string EnabledSFindPatientsButton = "EnabledSFindPatientsButton";
            public const string BindC1FlexGridFindPatients = "BindC1FlexGridFindPatients";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MZ_FindChargedPatients_Load(object sender, EventArgs e)
        {
            SetC1FlexGridAttribute(this.c1FlexGridChargedPatients, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridChargedPatients, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridChargedPatients);
            SetC1FlexGridNullDataTable(this.c1FlexGridChargedPatients);

            InitControls();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindPatients_Click(object sender, EventArgs e)
        {
            SetControlsValue();

            SendUIMsg(FindChargedPatientsUIMsg.DisabledFindPatientsButton);

            FindPatients();

            SendUIMsg(FindChargedPatientsUIMsg.EnabledSFindPatientsButton);
        }

        /// <summary>
        /// 查找患者
        /// </summary>
        private void FindPatients()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在努力查找患者，请稍后......");

                IDataParameter[] parameter = new IDataParameter[4];

                parameter[0] = new SqlParameter("@ICCardNumbers", this._ICCard);
                parameter[1] = new SqlParameter("@PatientName", this._PatientName);
                parameter[2] = new SqlParameter("@StartTime", this._StartTime);
                parameter[3] = new SqlParameter("@EndTime", this._EndTime);

                DataSet ds = Alif.DBUtility.DbHelperSQL.RunProcedure("HIS_InterfaceHN.dbo.P_FindChargedPatients", parameter, "P_FindChargedPatients");

                SendUIMsg(FindChargedPatientsUIMsg.BindC1FlexGridFindPatients, ds.Tables[0]);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);

                SendUIMsg(UIMsg.MsgError, ex.Message);
            }
        }

        /// <summary>
        /// 设置控件值
        /// </summary>
        private void SetControlsValue()
        {
            this._StartTime = this.dateTimePickerStartTime.Text.Trim();
            this._EndTime = this.dateTimePickerEndTime.Text.Trim();
            this._ICCard = this.txtBoxICCard.Text.Trim();
            this._PatientName = this.txtBoxPatientName.Text.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnFindPatients.PerformClick();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxICCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnFindPatients.PerformClick();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MZ_FindChargedPatients_Shown(object sender, EventArgs e)
        {
            this.btnFindPatients.PerformClick();
        }

        /// <summary>
        /// 初始化窗体控件
        /// </summary>
        private void InitControls()
        {
            this.dateTimePickerStartTime.Text = string.Format("{0}-{1}-01 00:00:00", DateTime.Now.Year, DateTime.Now.Month);

            this.txtBoxICCard.Clear();
            this.txtBoxPatientName.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridChargedPatients_SelChange(object sender, EventArgs e)
        {
            this._selectedRowIndex = this.c1FlexGridChargedPatients.MouseRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridChargedPatients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this._selectedRowIndex > 0)
            {
                this.Indi_id = this.c1FlexGridChargedPatients.Rows[this._selectedRowIndex]["indi_id"].ToString().Trim();
                this._mzRegID = this.c1FlexGridChargedPatients.Rows[this._selectedRowIndex]["MZRegID"].ToString().Trim();

                this.Close();
            }
        }
    }
}