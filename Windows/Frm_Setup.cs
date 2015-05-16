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
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_Setup : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        public Frm_Setup()
        {
            InitializeComponent();
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
        private void Frm_Setup_Load(object sender, EventArgs e)
        {
            SetApplicationIco(this);
            QueryParaInfo();
        }

        /// <summary>
        /// 
        /// </summary>
        private void QueryParaInfo()
        {
            string connectionString = Alif.DBUtility.PubConstant.GetKeyValue("ConnectionString");
            string appInfo = Alif.DBUtility.PubConstant.GetKeyValue("AppInfo");
            string appTitle = Alif.DBUtility.PubConstant.GetKeyValue("AppTitle");
            string commPort = Alif.DBUtility.PubConstant.GetKeyValue("CommPort");

            string[] strSplit = connectionString.Split(';');

            this.txtBoxUrl.Text = strSplit[0].Trim().Split('=')[1].Trim();
            this.txtBoxDataBase.Text = strSplit[1].Trim().Split('=')[1].Trim();
            this.txtBoxUserName.Text = strSplit[2].Trim().Split('=')[1].Trim();
            this.txtBoxPasswd.Text = strSplit[3].Trim().Split('=')[1].Trim();
            this.txtBoxAppTitle.Text = appTitle;
            this.txtBoxAppInfo.Text = appInfo;
            this.txtBoxCommPort.Text = commPort;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string configPath = Application.StartupPath + "\\" + Application.ProductName + ".exe";
                string appInfo = this.txtBoxAppInfo.Text.Trim();
                string appTitle = this.txtBoxAppTitle.Text.Trim();
                string url = this.txtBoxUrl.Text.Trim();
                string dataBase = this.txtBoxDataBase.Text.Trim();
                string userName = this.txtBoxUserName.Text.Trim();
                string passwd = this.txtBoxPasswd.Text.Trim();
                string commPort=this.txtBoxCommPort.Text.Trim();

                Alif.DBUtility.PubConstant.UpdateConfig(configPath, "AppInfo", appInfo);
                Alif.DBUtility.PubConstant.UpdateConfig(configPath, "AppTitle", appTitle);
                Alif.DBUtility.PubConstant.UpdateConfig(configPath, "ConnectionString", string.Format("server={0};database={1};uid={2};pwd={3}", url, dataBase, userName, passwd));
                Alif.DBUtility.PubConstant.UpdateConfig(configPath, "CommPort", commPort);

                this.lblTips.Text = "参数修改成功！！！";
                this.lblTips.ForeColor = Color.Green;
            }
            catch (Exception ee)
            {
                this.lblTips.Text = string.Empty;

                CommonFunctions.MsgError("参数修改失败，失败原因：" + ee.Message);
            }
        }
    }
}
