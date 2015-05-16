using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Windows.Class;
using InterfaceClass;

namespace Windows
{
    /// <summary>
    /// 基金信息
    /// </summary>
    public partial class Frm_Fund : BaseForm
    {
        /// <summary>
        /// 线程
        /// </summary>
        private Thread _thread = null;

        private string _indi_id = string.Empty;

        private string _biz_type = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public Frm_Fund(string indi_id, string biz_type)
        {
            InitializeComponent();

            this._indi_id = indi_id;
            this._biz_type = biz_type;

            this._SynchronizationContext = SynchronizationContext.Current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Fund_Load(object sender, EventArgs e)
        {
            if (this._indi_id == string.Empty || this._biz_type == string.Empty)
            {
                CommonFunctions.MsgError("个人电脑号或者业务类型为空，不能进行基金状态的查询，请联系管理员！！！");
                return;
            }

            CreateAndStartThread(this._thread, ThreadQueryPersonInfo);
        }

        /// <summary>
        /// 线程查询人员信息
        /// </summary>
        private void ThreadQueryPersonInfo()
        {
            try
            {
                SendUIMsg(UIMsg.Display, string.Format("正在查询个人电脑号{0}、业务类型{1}的基金信息，请稍后......", this._indi_id, this._biz_type));

                InterfaceClass.HN.MZ.GetPersonInfoByFlag info = new InterfaceClass.HN.MZ.GetPersonInfoByFlag(baseInterfaceHN);

                InterfaceClass.HN.MZ.PersonInfoDetail personInfoDetail = info.GetPersonInfoDetailByindi_id(this._indi_id, baseInterfaceHN.Oper_hospitalid, this._biz_type, baseInterfaceHN.Oper_centerid);

                SendUIMsg(UIMsg.WriteMsg, "获取基金信息成功，正在处理，请稍后......");

                if (personInfoDetail.ListPersonInfo.Count == 1)
                {
                    SendUIMsg(UIMsg.WriteMsg, "正在将获取的个人基金冻结信息转换成数据表，请稍后......");

                    FreezeInfoToDataTable(personInfoDetail.ListFreezeinfo);
                }
                else
                {
                    throw new Exception(string.Format("获取的人员信息记录数过多({0}条)，请重试！！！", personInfoDetail.ListPersonInfo.Count));
                }

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "基金状态查询发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        private void FreezeInfoToDataTable(List<InterfaceClass.HN.MZ.FreezeInfo> list)
        {
            DataTable dt = TToDataTable<InterfaceClass.HN.MZ.FreezeInfo>(list);

            SendUIMsg(FundUIMsg.BindFreezeInfo, dt);
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
                    case FundUIMsg.BindFreezeInfo:
                        BindFreezeInfo(parameter.Object);
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
        private void BindFreezeInfo(object p)
        {
            this.c1FlexGridFund.DataSource = (DataTable)p;

            this.c1FlexGridFund.Cols["fund_id"].Width = 40;
            this.c1FlexGridFund.Cols["fund_name"].Width = 180;
            this.c1FlexGridFund.Cols["indi_freeze_status"].Width = 70;


            for (int i = 1; i < this.c1FlexGridFund.Rows.Count; i++)
            {
                string fundStatus = this.c1FlexGridFund.Rows[i]["indi_freeze_status"].ToString().Trim();

                switch (fundStatus)
                {
                    case "0":
                        this.c1FlexGridFund.Rows[i]["indi_freeze_status"] = "正常";
                        break;
                    case "1":
                        this.c1FlexGridFund.Rows[i]["indi_freeze_status"] = "冻结";
                        break;
                    case "2":
                        this.c1FlexGridFund.Rows[i]["indi_freeze_status"] = "暂停参保";
                        break;
                    case "3":
                        this.c1FlexGridFund.Rows[i]["indi_freeze_status"] = "中止参保";
                        break;
                    case "9":
                        this.c1FlexGridFund.Rows[i]["indi_freeze_status"] = "未参保";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class FundUIMsg
        {
            public const string BindFreezeInfo = "BindFreezeInfo";
        }
    }
}