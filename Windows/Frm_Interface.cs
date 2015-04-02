using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows
{
    public partial class Frm_Interface : BaseForm
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        private long userID = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        public Frm_Interface(long userID)
        {
            this.userID = userID;

            InitializeComponent();

            baseInterfaceHN = new InterfaceClass.InterfaceHN();

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
            QueryAndSetUserInfo();

            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;

            Frm_Flow frm = new Frm_Flow();

            AddFormToPanelInterface(frm);

            DisaplayMsg();
        }

        /// <summary>
        /// 
        /// </summary>
        private void DisaplayMsg()
        {
            Frm_Msg frm = new Frm_Msg();

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemInterfaceFunc_Click(object sender, EventArgs e)
        {
            Frm_InterfaceFunc frm = new Frm_InterfaceFunc();

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemTest_Click(object sender, EventArgs e)
        {
            Frm_Main frm = new Frm_Main(71);

            AddFormToPanelInterface(frm);
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

            this.panelInterface.Controls.Add(frm);
            this.lblFrmTitle.Text = string.Format("当前操作窗体：{0}", frm.Text.Trim());

            frm.Show();

            frm_tips.Close();
        }

        /// <summary>
        /// 查询和设置用户信息
        /// </summary>
        private void QueryAndSetUserInfo()
        {
            string SQLString = string.Format(@"SELECT  UnitName ,
                                                        UserName
                                                FROM    alfHospital.dbo.TbMedicalPersonInfo
                                                        INNER JOIN alfHospital.dbo.TbUnitInfo ON alfHospital.dbo.TbUnitInfo.UnitID = alfHospital.dbo.TbMedicalPersonInfo.UnitID
                                                WHERE   ID = {0}", this.userID);

            try
            {
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                this.lblUnitName.Text = string.Format("单位：{0}", ds.Tables[0].Rows[0]["UnitName"].ToString().Trim());

                this.lblUserName.Text = string.Format("操作人员：{0}", ds.Tables[0].Rows[0]["UserName"].ToString().Trim());
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError("获取用户信息失败，失败原因：" + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemFuncTest_Click(object sender, EventArgs e)
        {
            Frm_FuncTest frm = new Frm_FuncTest();

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 接口字典维护
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemInterfaceDic_Click(object sender, EventArgs e)
        {
            Frm_Dictionary frm = new Frm_Dictionary();

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemJCType_Click(object sender, EventArgs e)
        {
            Frm_JCType frm = new Frm_JCType();

            AddFormToPanelInterface(frm);
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

            AddFormToPanelInterface(frm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblSetup_Click(object sender, EventArgs e)
        {
            Frm_Setup frm = new Frm_Setup();

            frm.ShowDialog();

            frm = null;
        }

        private void labelDirCompare_Click(object sender, EventArgs e)
        {
            Frm_DirCompare frm = new Frm_DirCompare();

            AddFormToPanelInterface(frm);
        }

    }
}