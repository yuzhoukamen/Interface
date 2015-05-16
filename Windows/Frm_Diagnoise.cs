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

namespace Windows
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_Diagnoise : BaseForm
    {
        /// <summary>
        /// 疾病编码
        /// </summary>
        private string _icdID = string.Empty;

        /// <summary>
        /// 疾病名称
        /// </summary>
        private string _icdName = string.Empty;

        /// <summary>
        /// 返回参数（name代表疾病编码 value代表疾病名称）
        /// </summary>
        public Parameter ReturnParameter { get; set; }

        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// 选择的行号
        /// </summary>
        private int _selectedRowIndex = 0;

        /// <summary>
        /// 
        /// </summary>
        public Frm_Diagnoise(string icdID, string icdName)
        {
            InitializeComponent();

            this._SynchronizationContext = SynchronizationContext.Current;

            this._icdID = icdID.Trim();
            this._icdName = icdName.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        public Frm_Diagnoise()
        {
            InitializeComponent();

            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Diagnoise_Load(object sender, EventArgs e)
        {
            SetC1FlexGridAttribute(this.c1FlexGridDiagnoise, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridDiagnoise, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridDiagnoise);
            SetC1FlexGridNullDataTable(this.c1FlexGridDiagnoise);

            this.lblICDID.Text = this._icdID.Trim();
            this.txtBoxICDName.Text = this._icdName.Trim();
        }

        /// <summary>
        /// 线程查询疾病信息
        /// </summary>
        private void ThreadInitICDInfo()
        {
            SendUIMsg(Diagnoise_UIMsg.DisabledQueryButton);

            InitICDInfo();

            SendUIMsg(Diagnoise_UIMsg.EnabledQueryButton);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitICDInfo()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在查询中心疾病，请稍后......");

                string SQLString = string.Format(@"SELECT  icd,disease
                                                        FROM    [HIS_InterfaceHN].[dbo].[JC_Interface_Disease]
                                                        WHERE   disease LIKE '%{0}%'
                                                                OR code_py LIKE '%{0}%'
                                                        ORDER BY disease", this._icdName);

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                SendUIMsg(Diagnoise_UIMsg.BindC1FlexGridDiagnoise, ds.Tables[0]);

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this._icdName = this.txtBoxICDName.Text.Trim();

            CreateAndStartThread(this._thread, ThreadInitICDInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void BindC1FlexGridDiagnoise(object p)
        {
            this.c1FlexGridDiagnoise.DataSource = (DataTable)p;

            this.c1FlexGridDiagnoise.Cols["icd"].Width = 160;
            this.c1FlexGridDiagnoise.Cols["icd"].Caption = "中心疾病编码";

            this.c1FlexGridDiagnoise.Cols["disease"].Width = 600;
            this.c1FlexGridDiagnoise.Cols["disease"].Caption = "中心疾病名称";
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
                    case Diagnoise_UIMsg.DisabledQueryButton:
                        this.btnQuery.Enabled = false;
                        break;
                    case Diagnoise_UIMsg.EnabledQueryButton:
                        this.btnQuery.Enabled = true;
                        break;
                    case Diagnoise_UIMsg.BindC1FlexGridDiagnoise:
                        BindC1FlexGridDiagnoise(parameter.Object);
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
        public class Diagnoise_UIMsg {
            public const string DisabledQueryButton = "DisabledQueryButton";
            public const string EnabledQueryButton = "EnabledQueryButton";
            public const string BindC1FlexGridDiagnoise = "BindC1FlexGridDiagnoise";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Diagnoise_Shown(object sender, EventArgs e)
        {
            this.btnQuery.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxICDName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnQuery.PerformClick();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridDiagnoise_SelChange(object sender, EventArgs e)
        {
            this._selectedRowIndex = this.c1FlexGridDiagnoise.MouseRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridDiagnoise_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this._selectedRowIndex > 0)
            {
                string name = this.c1FlexGridDiagnoise.Rows[this._selectedRowIndex]["icd"].ToString().Trim();
                string value = this.c1FlexGridDiagnoise.Rows[this._selectedRowIndex]["disease"].ToString().Trim();

                this.ReturnParameter = new Parameter(name, value);

                this.Close();
            }
        }
    }
}