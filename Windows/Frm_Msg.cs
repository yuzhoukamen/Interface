using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceClass.HN.HealthNews;

namespace Windows
{
    public partial class Frm_Msg : BaseForm
    {
        public Frm_Msg()
        {
            InitializeComponent();
        }

        private void Frm_Msg_Load(object sender, EventArgs e)
        {
            SetApplicationIco(this);

            SetC1FlexGridAttribute(this.c1FlexGridMsg, false);
            SetC1FlexGridSelectionMode(this.c1FlexGridMsg, C1.Win.C1FlexGrid.SelectionModeEnum.Row);
            BindC1FlexGridDisplayLineNumbers(this.c1FlexGridMsg);

            InitMsgUrl();
           // InitInterfaceMsg();
        }

        /// <summary>
        /// 初始化社保消息
        /// </summary>
        private void InitInterfaceMsg()
        {
            try
            {
                List<InterfaceClass.HN.HealthNews.Message> listMsg = new List<InterfaceClass.HN.HealthNews.Message>();

                string name = string.Empty;

                HealthMessage healthMessage = new HealthMessage(baseInterfaceHN);

                listMsg = healthMessage.GetMessage(name);

                if (listMsg.Count <= 0)
                {
                    SetC1FlexGridNullDataTable(this.c1FlexGridMsg, "记录为空，没有医保中心消息......");
                    return;
                }

                DataTable dt = new DataTable();

                dt.Columns.Add(AddDataColumn("ms_id", "消息编号"));
                dt.Columns.Add(AddDataColumn("ms_type", "消息类型"));
                dt.Columns.Add(AddDataColumn("ms_title", "消息标题"));
                dt.Columns.Add(AddDataColumn("ms_content", "消息内容"));
                dt.Columns.Add(AddDataColumn("center_id", "发件人中心"));
                dt.Columns.Add(AddDataColumn("sender_org", "发件人组织编号"));
                dt.Columns.Add(AddDataColumn("sender_man", "发件人名称"));
                dt.Columns.Add(AddDataColumn("send_date", "发件时间"));

                foreach (InterfaceClass.HN.HealthNews.Message msg in listMsg)
                {
                    DataRow dr = dt.NewRow();

                    dr["ms_id"] = msg.ms_id;
                    dr["ms_type"] = msg.ms_type;
                    dr["ms_title"] = msg.ms_title;
                    dr["ms_content"] = msg.ms_content;
                    dr["center_id"] = msg.center_id;
                    dr["sender_org"] = msg.sender_org;
                    dr["sender_man"] = msg.sender_man;
                    dr["send_date"] = msg.send_date;

                    dt.Rows.Add(dr);
                }

                this.c1FlexGridMsg.DataSource = dt;
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError("获取医保中心消息发生错误，错误原因：" + e.Message);
            }
        }

        /// <summary>
        /// 初始化通知地址
        /// </summary>
        private void InitMsgUrl()
        {
            try
            {
                string SQLString = string.Format(@"SELECT  CodeValue
                                                    FROM    his.dbo.setup
                                                    WHERE   Code = '000001005001'");
                DataSet ds = Alif.DBUtility.DbHelperSQL.Query(SQLString);

                string url = ds.Tables[0].Rows[0]["CodeValue"].ToString().Trim();

                this.webBrowserMsg.Url = new Uri(url);
            }
            catch (Exception e)
            {
                CommonFunctions.MsgError("初始化通知地址出错，错误原因：" + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGridMsg_AfterSelChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            int rowIndex = this.c1FlexGridMsg.MouseRow;

            if (rowIndex < 0)
            {
                return;
            }

            if (this.c1FlexGridMsg.Cols.Contains("ms_content"))
            {
                string msg = this.c1FlexGridMsg.Rows[rowIndex]["ms_content"].ToString().Trim();

                this.rTxtBoxMsg.Clear();
                this.rTxtBoxMsg.AppendText(msg);
            }
        }
    }
}