using InterfaceClass;
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
    public partial class Frm_Main : Form
    {
        /// <summary>
        /// 湖南创智接口
        /// </summary>
        private InterfaceHN interfaceHN = new InterfaceHN();

        /// <summary>
        /// 构造函数
        /// </summary>
        public Frm_Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.btnCheck.Enabled = false;

            string name = this.txtBoxName.Text.Trim();

            this.richBoxResult.AppendText(IDCard.GetInstance(name).AllInfo() + "\n");
            this.pictureBoxPerson.ImageLocation = System.IO.Path.Combine(Application.StartupPath, "idc_ph.bmp");

            this.richBoxResult.Focus();
            this.richBoxResult.Select(this.richBoxResult.TextLength, 0);

            this.btnCheck.Enabled = true;
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = Alif.DBUtility.DbHelperSQL.Query(string.Format(@"SELECT  *
                                                                            FROM    Setup
                                                                            WHERE   Serial = '{0}'", "001001001001"));

                string interfaceConnectString = ds.Tables[0].Rows[0]["Value"].ToString().Trim();

                this.txtBoxServer.Text = interfaceHN.Addr = interfaceConnectString.Split(';')[0].Split('=')[1].Trim();

                interfaceHN.Port = int.Parse(interfaceConnectString.Split(';')[1].Split('=')[1].Trim());
                this.txtBoxPort.Text = interfaceHN.Port.ToString();

                this.txtBoxServlet.Text = interfaceHN.Servlet = interfaceConnectString.Split(';')[2].Split('=')[1].Trim();

            }
            catch (Exception ee)
            {
                MessageBox.Show("初始化参数错误，错误原因：" + ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ds.Clear();
                ds.Dispose();
            }
        }

        /// <summary>
        /// 修改参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.interfaceHN.Addr = this.txtBoxServer.Text.Trim();
                this.interfaceHN.Port = int.Parse(this.txtBoxPort.Text.Trim());
                this.interfaceHN.Servlet = this.txtBoxServlet.Text.Trim();

                int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(string.Format(@"UPDATE  dbo.Setup
                                                                                SET     Value = 'Server={0};Port={1};Servlet={2}'
                                                                                WHERE   Serial = '001001001001'",
                                                                            this.interfaceHN.Addr,
                                                                            this.interfaceHN.Port,
                                                                            this.interfaceHN.Servlet));

                if (temp > 0)
                {
                    MessageBox.Show("修改成功！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("没有修改任何数据！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("修改服务器信息失败，失败原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInterfaceInit_Click(object sender, EventArgs e)
        {
            try
            {
                this.interfaceHN.Addr = this.txtBoxServer.Text.Trim();
                this.interfaceHN.Port = int.Parse(this.txtBoxPort.Text.Trim());
                this.interfaceHN.Servlet = this.txtBoxServlet.Text.Trim();

                //this.interfaceHN.NewInterfaceWithInit();

                this.interfaceHN.NewInterfaceAfterInit();
            }
            catch (Exception ee)
            {
                MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void MsgError(string msg)
        {
            MessageBox.Show(msg.Trim(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        private void MsgInfo(string msg)
        {
            MessageBox.Show(msg.Trim(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Shown(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginGet_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = Alif.DBUtility.DbHelperSQL.Query(string.Format(@"SELECT  *
                                                                            FROM    Setup
                                                                            WHERE   Serial = '{0}'", "001001001002"));

                string interfaceConnectString = ds.Tables[0].Rows[0]["Value"].ToString().Trim();

                this.txtBoxLoginID.Text = interfaceConnectString.Split(';')[0].Split('=')[1].Trim();
                this.txtBoxLoginPasswd.Text = interfaceConnectString.Split(';')[1].Split('=')[1].Trim();
            }
            catch (Exception ee)
            {
                MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int temp = Alif.DBUtility.DbHelperSQL.ExecuteSql(string.Format(@"UPDATE  dbo.Setup
                                                                                SET     Value = 'login_id={0};login_password={1}'
                                                                                WHERE   Serial = '001001001002'",
                                                                            this.txtBoxLoginID.Text.Trim(),
                                                                            this.txtBoxLoginPasswd.Text.Trim()));
                if (temp > 0)
                {
                    MsgInfo("修改成功！！！");
                }
                else
                {
                    MsgError("没有修改任何记录！！！");
                }
            }
            catch (Exception ee)
            {
                MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.interfaceHN.Func_ID = "0";

                this.interfaceHN.Start();

                this.interfaceHN.ClearParameterList();

                this.interfaceHN.AddParameter("login_id","hexu");
                this.interfaceHN.AddParameter("login_password", "hexu");

                this.interfaceHN.Puts(0);

               // this.interfaceHN.PutCol("login_id", "hexu");
               // this.interfaceHN.PutCol("login_password", "hexu");

                this.interfaceHN.Run();

                MsgInfo("登陆成功！！！");

            }
            catch (Exception ee)
            {
                MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBIZC131101_Click(object sender, EventArgs e)
        {
            try
            {
                this.interfaceHN.Func_ID = this.txtBoxFuncID.Text.Trim();

                this.interfaceHN.Start();

                this.interfaceHN.ClearParameterList();

                this.interfaceHN.AddParameter("idcard", this.txtBoxIDCard.Text.Trim());
                this.interfaceHN.AddParameter("hospital_id", this.txtBoxHospitalID.Text.Trim());
                this.interfaceHN.AddParameter("biz_type", this.txtBoxBiz.Text.Trim());
                this.interfaceHN.AddParameter("center_id", this.txtBoxCenterID.Text.Trim());

                //this.interfaceHN.Puts(1);

                this.interfaceHN.PutCol("idcard", this.txtBoxIDCard.Text.Trim());
                this.interfaceHN.PutCol("hospital_id", this.txtBoxHospitalID.Text.Trim());
                this.interfaceHN.PutCol("biz_type", this.txtBoxBiz.Text.Trim());
                this.interfaceHN.PutCol("center_id", this.txtBoxCenterID.Text.Trim());

                this.interfaceHN.Run();

                this.interfaceHN.SetResultset("personinfo");

                List<string> listName = new List<string>();

                this.interfaceHN.GetsByName("name", ref listName);
            }
            catch (Exception ee)
            {
                MsgError(ee.Message);
            }
        }
    }
}