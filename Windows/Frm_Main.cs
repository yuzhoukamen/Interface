using InterfaceClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class Frm_Main : Form
    {
        /// <summary>
        /// 湖南创智接口
        /// </summary>
        private InterfaceClass.InterfaceHN interfaceHN = new InterfaceHN();

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
                MessageBox.Show("初始化参数错误，错误原因：" + ee.Message);
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

        }


    }
}