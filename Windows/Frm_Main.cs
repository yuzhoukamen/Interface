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
    /// 主窗口
    /// </summary>
    public partial class Frm_Main : BaseForm
    {
        /// <summary>
        /// 湖南创智接口
        /// </summary>
        private InterfaceHN interfaceHN = new InterfaceHN();

        /// <summary>
        /// 构造函数
        /// </summary>
        public Frm_Main(long userID)
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
                this.interfaceHN.Oper_centerid = "632802";
                this.interfaceHN.Oper_hospitalid = "632802002";
                this.interfaceHN.Oper_staffid = "000";

                this.interfaceHN.NewInterfaceWithInit();
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            InitFormInfo(this);

            this.txtBoxServer.Text = "200.100.1.20";
            this.txtBoxPort.Text = "7001";
            this.txtBoxServlet.Text = "Insur_HXZTEST/ProcessAll";
            this.txtBoxLoginID.Text = "632802002";
            this.txtBoxLoginPasswd.Text = "632802002";

            this.txtBoxCenterID.Text = "632802";
            this.txtBoxHospitalID.Text = "632802002";

            this.dateTimeDisQueryDate.CustomFormat = "yyyy-MM-dd";
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
                CommonFunctions.MsgError(ee.Message);
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
                    CommonFunctions.MsgError("修改成功！！！");
                }
                else
                {
                    CommonFunctions.MsgError("没有修改任何记录！！！");
                }
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
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

                this.interfaceHN.AddParameter("login_id", this.txtBoxLoginID.Text.Trim());
                this.interfaceHN.AddParameter("login_password", this.txtBoxLoginPasswd.Text.Trim());

                this.interfaceHN.PutCols();

                long value = this.interfaceHN.Run();

                if (value == 0)
                {
                    CommonFunctions.MsgError("登陆成功！！！");
                }
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
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

                this.interfaceHN.PutCols();

                this.interfaceHN.Run();

                this.interfaceHN.SetResultset("personinfo");

                List<string> listName = new List<string>();

                this.interfaceHN.GetsByName("name", ref listName);

                foreach (string str in listName)
                {
                    this.richTxtBoxPersonInfo.AppendText(str);
                }
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.interfaceHN.Func_ID = this.lblDisID.Text.Trim();

                this.interfaceHN.Start();

                this.interfaceHN.ClearParameterList();

                this.interfaceHN.AddParameter("center_id", this.txtBoxDisCenter_id.Text.Trim());
                this.interfaceHN.AddParameter("code_py", this.txtBoxDisCode_py.Text.Trim());
                this.interfaceHN.AddParameter("querydate", this.dateTimeDisQueryDate.Text.Trim());

                this.interfaceHN.PutCols();

                this.interfaceHN.Run();

                this.interfaceHN.SetResultset("diseaseinfo");

                string value = string.Empty;

                this.interfaceHN.GetByName("icd", ref value);

                richBoxDisResult.AppendText("疾病编码:" + value + "\n");

                this.interfaceHN.GetByName("disease", ref value);

                richBoxDisResult.AppendText("疾病名称:" + value + "\n");

                this.interfaceHN.GetByName("code_wb", ref value);

                richBoxDisResult.AppendText("五笔码:" + value + "\n");

                this.interfaceHN.GetByName("code_py", ref value);

                richBoxDisResult.AppendText("首拼码:" + value + "\n");
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
            }
        }

        private void btnMedicalQuery_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder(100 * 1024 * 1024);

                this.interfaceHN.Func_ID = this.lblMedicalID.Text.Trim();

                this.interfaceHN.Start();

                this.interfaceHN.ClearParameterList();

                this.interfaceHN.AddParameter("center_id", this.txtBoxMedicalCenterid.Text.Trim());
                this.interfaceHN.AddParameter("type", this.txtBoxMedicalType.Text.Trim());
                this.interfaceHN.AddParameter("condition", this.txtBoxMedicalcondition.Text.Trim());
                this.interfaceHN.AddParameter("once_find", this.txtBoxMedicalOnceFind.Text.Trim());
                this.interfaceHN.AddParameter("first_row", this.txtBoxfirst_row.Text.Trim());
                this.interfaceHN.AddParameter("last_row", this.txtBoxlast_row.Text.Trim());
                this.interfaceHN.AddParameter("first_version_id", this.txtBoxfirst_version_id.Text.Trim());
                this.interfaceHN.AddParameter("last_version_id", this.txtBoxlast_version_id.Text.Trim());

                this.interfaceHN.PutCols();

                this.interfaceHN.Run();

                this.interfaceHN.SetResultset("count");
                string value = string.Empty;
                this.interfaceHN.GetByName("count", ref value);
                sb.Append(value + "\n");

                this.interfaceHN.SetResultset("pageinfo");

                string table = string.Format(@"INSERT INTO [HN_ChuangZhi_HIS_Interface].[dbo].[Center_Medical]([ID], [medi_code], [medi_name], [english_name], [model], [medi_item_type], [stat_type], [code_wb], [code_py], [price], [staple_flag], [effect_date], [expire_date], [otc], [mt_flag], [wl_flag], [bo_flag], [sp_flag])");

                do
                {
                    string str = string.Empty;

                    sb.AppendLine(table);

                    sb.Append("select ");

                    this.interfaceHN.GetByName("medi_code", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("medi_name", ref str);
                    sb.Append("'" + str + "'" + " ,");

                    this.interfaceHN.GetByName("english_name", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("model", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("medi_item_type", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("stat_type", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("code_wb", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("code_py", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("price", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("staple_flag", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("effect_date", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("expire_date", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("otc", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("mt_flag", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("wl_flag", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("bo_flag", ref str);
                    sb.Append("'" + str + "'" + ",");

                    this.interfaceHN.GetByName("sp_flag", ref str);
                    sb.AppendLine("'" + str + "'");
                }
                while (0 < this.interfaceHN.NextRow());

                string path = System.IO.Path.Combine(Application.StartupPath, "sql");

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                path = System.IO.Path.Combine(path, "sql.txt");

                System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true);
                sw.WriteLine(sb.ToString());
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ee)
            {
                CommonFunctions.MsgError(ee.Message);
            }
        }
    }
}