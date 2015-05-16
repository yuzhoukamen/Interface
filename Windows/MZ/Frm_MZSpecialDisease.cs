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

namespace Windows.MZ
{
    /// <summary>
    /// 门诊特殊病窗体
    /// </summary>
    public partial class Frm_MZSpecialDisease : BaseForm
    {
        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        private string _indi_id = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Frm_MZSpecialDisease(long userID)
        {
            InitializeComponent();

            this._SynchronizationContext = SynchronizationContext.Current;
            this._userID = userID;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_MZSpecialDisease_Load(object sender, EventArgs e)
        {
            SetC1FlexGridDefaultAttribute(this.c1FlexGridFeeDetails);
            SetC1FlexGridDefaultAttribute(this.c1FlexGridJJ);
        }

        /// <summary>
        /// 情况费用结算信息
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
        /// 更新UI控件内容
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
                    case MZSpecialDiseaseUIMsg.DisabledChangeOrChargeButton:
                        this.btnChangeOrCharge.Enabled = false;
                        break;
                    case MZSpecialDiseaseUIMsg.EnabledChangeOrChargeButton:
                        this.btnChangeOrCharge.Enabled = true;
                        break;
                    case MZSpecialDiseaseUIMsg.DisabledTryButton:
                        this.btnTry.Enabled = false;
                        break;
                    case MZSpecialDiseaseUIMsg.EnabledTryButton:
                        this.btnTry.Enabled = true;
                        break;
                    case MZSpecialDiseaseUIMsg.DisabledFindPatientsButton:
                        this.btnFindPatient.Enabled = false;
                        break;
                    case MZSpecialDiseaseUIMsg.EnabledFindPatientsButton:
                        this.btnFindPatient.Enabled = true;
                        break;
                    case MZSpecialDiseaseUIMsg.EnabledReadCardButton:
                        this.btnReadCard.Enabled = true;
                        break;
                    case MZSpecialDiseaseUIMsg.DisabledReadCardButton:
                        this.btnReadCard.Enabled = false;
                        break;
                    case MZSpecialDiseaseUIMsg.DisabledPrintButton:
                        this.btnPrint.Enabled = false;
                        break;
                    case MZSpecialDiseaseUIMsg.EnabledPrintButton:
                        this.btnPrint.Enabled = true;
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
        /// 门诊特殊病消息
        /// </summary>
        public class MZSpecialDiseaseUIMsg
        {
            /// <summary>
            /// 禁用读卡按钮
            /// </summary>
            public const string DisabledReadCardButton = "DisabledReadCardButton";

            /// <summary>
            /// 启用读卡按钮
            /// </summary>
            public const string EnabledReadCardButton = "EnabledReadCardButton";

            /// <summary>
            /// 禁用查找患者按钮
            /// </summary>
            public const string DisabledFindPatientsButton = "DisabledFindPatientsButton";

            /// <summary>
            /// 启用查找患者按钮
            /// </summary>
            public const string EnabledFindPatientsButton = "EnabledFindPatientsButton";

            /// <summary>
            /// 禁用试算按钮
            /// </summary>
            public const string DisabledTryButton = "DisabledTryButton";

            /// <summary>
            /// 启用试算按钮
            /// </summary>
            public const string EnabledTryButton = "EnabledTryButton";

            /// <summary>
            /// 禁用改费或收费按钮
            /// </summary>
            public const string DisabledChangeOrChargeButton = "DisabledChangeOrChargeButton";

            /// <summary>
            /// 启用改费或收费按钮
            /// </summary>
            public const string EnabledChangeOrChargeButton = "EnabledChangeOrChargeButton";

            /// <summary>
            /// 禁用打印按钮
            /// </summary>
            public const string DisabledPrintButton = "DisabledPrintButton";

            /// <summary>
            /// 启用打印按钮
            /// </summary>
            public const string EnabledPrintButton = "EnabledPrintButton";
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            Frm_ReadCard frm = new Frm_ReadCard(this._userID);

            frm.ShowDialog();

            this._indi_id = frm.CardNumbers;//个人电脑号
            //this._indi_id = "11027437";

            frm = null;

            ClearPersonInfo();

            if (this._indi_id == string.Empty)
            {
                return;
            }

            this.txtBoxindi_id.Text = this._indi_id;

            EnabledOperButton(false);

            CreateAndStartThread(this._thread, ThreadQueryPersonInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearPersonInfo() { }

        private void EnabledOperButton(bool flag) { }

        private void ThreadQueryPersonInfo() { }

        private void c1FlexGridFeeDetails_ValidateEdit(object sender, C1.Win.C1FlexGrid.ValidateEditEventArgs e)
        {

        }
    }
}