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
    public partial class Frm_Interface : BaseForm
    {
        private Thread _thread = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        public Frm_Interface(long userID)
        {
            this._userID = userID;

            InitializeComponent();

            baseInterfaceHN = new InterfaceClass.InterfaceHN();

            this._SynchronizationContext = SynchronizationContext.Current;

            SetDebug();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Interface_Load(object sender, EventArgs e)
        {
            InitFormInfo(this);

            this.menuStripInterface.Renderer = new Class.MyMenuRender();
            UserInfo();

            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;

            Frm_Flow frm = new Frm_Flow();

            AddFormToPanelInterface(frm);

            //DisaplayMsg();

            this.btnLogin.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        private void DisaplayMsg()
        {
            Frm_Msg frm = new Frm_Msg();

            frm.ShowDialog();

            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemInterfaceFunc_Click(object sender, EventArgs e)
        {
            Frm_InterfaceFunc frm = new Frm_InterfaceFunc();

            frm.ShowDialog();

            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemTest_Click(object sender, EventArgs e)
        {
            Frm_Main frm = new Frm_Main(71);

            frm.ShowDialog();

            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            this.lblCurrentTime.Text = string.Format("当前时间：{0}", dateTime.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm"></param>
        private void AddFormToPanelInterface(Form frm)
        {
            Frm_Tips frm_tips = new Frm_Tips();

            frm_tips.Show();
            Application.DoEvents();

            this.panelInterface.Controls.Clear();

            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;

            frm.Dock = DockStyle.Fill;

            //this.Width = frm.Width;
            //this.Height = this.Height + frm.Height - this.panelInterface.Height;

            //this.panelInterface.Height = frm.Height;

            this.panelInterface.Controls.Add(frm);
            this.lblFrmTitle.Text = string.Format("当前操作窗体：{0}", frm.Text.Trim());
            this.StartPosition = FormStartPosition.CenterScreen;

            frm.Show();

            frm_tips.Close();
        }

        /// <summary>
        /// 查询和设置用户信息
        /// </summary>
        private void UserInfo()
        {

            QueryAndSetUserInfo();

            this.lblUnitName.Text = string.Format("单位：{0}", this._unitName);

            this.lblUserName.Text = string.Format("操作人员：{0}", this._userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemFuncTest_Click(object sender, EventArgs e)
        {
            Frm_FuncTest frm = new Frm_FuncTest();

            frm.ShowDialog();

            frm = null;
        }

        /// <summary>
        /// 接口字典维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemInterfaceDic_Click(object sender, EventArgs e)
        {
            Frm_Dictionary frm = new Frm_Dictionary();

            frm.ShowDialog();

            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemJCType_Click(object sender, EventArgs e)
        {
            Frm_JCType frm = new Frm_JCType();

            frm.ShowDialog();

            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFlow_Click(object sender, EventArgs e)
        {
            Frm_Flow frm = new Frm_Flow();

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMsg_Click(object sender, EventArgs e)
        {
            Frm_Msg frm = new Frm_Msg();

            frm.ShowDialog();
            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblSetup_Click(object sender, EventArgs e)
        {
            Frm_Validata frmValidata = new Frm_Validata();

            frmValidata.ShowDialog();

            bool isValidata = frmValidata._isValidata;

            frmValidata = null;

            if (isValidata)
            {
                Frm_Setup frm = new Frm_Setup();

                frm.ShowDialog();

                frm = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDirCompare_Click(object sender, EventArgs e)
        {
            Frm_Validata frmValidata = new Frm_Validata();

            frmValidata.ShowDialog();

            bool isValidata = frmValidata._isValidata;

            frmValidata = null;

            if (isValidata)
            {
                Frm_DirCompare frm = new Frm_DirCompare(this._userID);

                frm.ShowDialog();

                frm = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemMZReg_Click(object sender, EventArgs e)
        {
            MZ.Frm_MZ_Change frm = new Windows.MZ.Frm_MZ_Change(this._userID);

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemMZCharge_Click(object sender, EventArgs e)
        {
            MZ.Frm_MZ_Charge frm = new Windows.MZ.Frm_MZ_Charge(this._userID);

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemMZRefund_Click(object sender, EventArgs e)
        {
            MZ.Frm_MZ_Change frm = new Windows.MZ.Frm_MZ_Change(this._userID);

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemMZCancel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblReadCard_Click(object sender, EventArgs e)
        {
            Frm_ReadCard frm = new Frm_ReadCard(this._userID);

            frm.ShowDialog();

            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMZCharge_Click(object sender, EventArgs e)
        {
            MZ.Frm_MZ_Charge frm = new Windows.MZ.Frm_MZ_Charge(this._userID);

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemMZQuery_Click(object sender, EventArgs e)
        {
            MZ.Frm_MZ_InfoQuery frm = new Windows.MZ.Frm_MZ_InfoQuery(this._userID);

            frm.ShowDialog();

            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            CreateAndStartThread(this._thread, ThreadLogin);
        }

        /// <summary>
        /// 登陆线程
        /// </summary>
        private void ThreadLogin()
        {
            SendUIMsg(InterfaceUIMsg.DisabledLoginButton);

            LoginInterface();

            SendUIMsg(InterfaceUIMsg.EnabledLoginButton);
        }

        /// <summary>
        /// 登陆中心
        /// </summary>
        private void LoginInterface()
        {
            try
            {
                string SQLString = string.Format(@"SELECT  [ID] ,
                                                        [Account] ,
                                                        [Passwd] ,
                                                        [HIS_UserID]
                                                FROM    [HIS_InterfaceHN].[dbo].[JC_UserInfo]
                                                WHERE   HIS_UserID = {0}", this._userID);
                SendUIMsg(UIMsg.Display, "正在登陆中心，请稍后......");
                SendUIMsg(InterfaceUIMsg.SetLoginStatus, "正在登陆......");

                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                string account = ds.Tables[0].Rows[0]["Account"].ToString().Trim();
                string passwd = ds.Tables[0].Rows[0]["Passwd"].ToString().Trim();

                InterfaceClass.HN.System.System system = new InterfaceClass.HN.System.System(baseInterfaceHN);

                string value = system.Login(account, passwd);

                SendUIMsg(InterfaceUIMsg.SetLoginStatus, value);

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
        /// <param name="p"></param>
        private void SetLoginStatus(object p)
        {
            this.lblLoginStatus.Text = "登陆状态：" + p.ToString();
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
                    case InterfaceUIMsg.DisabledLoginButton:
                        this.btnLogin.Enabled = false;
                        break;
                    case InterfaceUIMsg.EnabledLoginButton:
                        this.btnLogin.Enabled = true;
                        break;
                    case InterfaceUIMsg.SetLoginStatus:
                        SetLoginStatus(parameter.Value);
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
        public class InterfaceUIMsg
        {
            public const string DisabledLoginButton = "DisabledLoginButton";
            public const string EnabledLoginButton = "EnabledLoginButton";
            public const string SetLoginStatus = "SetLoginStatus";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemMZSpecial_Click(object sender, EventArgs e)
        {
            MZ.Frm_MZSpecialDisease frm = new Windows.MZ.Frm_MZSpecialDisease(this._userID);

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 普通门诊收费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemMZ_Click(object sender, EventArgs e)
        {
            MZ.Frm_MZ_Charge frm = new Windows.MZ.Frm_MZ_Charge(this._userID);

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemMZAllOrders_Click(object sender, EventArgs e)
        {
            Report.Frm_Report_MZ_AllBusiness frm = new Windows.Report.Frm_Report_MZ_AllBusiness(this._userID);

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemZYRegister_Click(object sender, EventArgs e)
        {
            ZY.Frm_Register frm = new Windows.ZY.Frm_Register(this._userID);

            frm.ShowDialog();

            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemZYAllOrders_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemRegisterUpdate_Click(object sender, EventArgs e)
        {
            ZY.Frm_RegisterUpdate frm = new Windows.ZY.Frm_RegisterUpdate(this._userID);

            frm.ShowDialog();
            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPersonInfo_Click(object sender, EventArgs e)
        {
            Report.Frm_Report_AllInfo frm = new Windows.Report.Frm_Report_AllInfo(this._userID);

            frm.ShowDialog();

            frm = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemZYDetails_Click(object sender, EventArgs e)
        {
            Report.Frm_Report_ZY_AllBusiness frm = new Windows.Report.Frm_Report_ZY_AllBusiness(this._userID);

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemFeeDetails_Click(object sender, EventArgs e)
        {
            ZY.Frm_FeeDetails frm = new Windows.ZY.Frm_FeeDetails(this._userID);

            frm.ShowDialog();

            frm = null;
        }
    }
}