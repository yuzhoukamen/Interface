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

namespace Windows.ZY
{
    public partial class Frm_PatientInfo : BaseForm
    {
        private Thread _thread = null;

        private string _serial_no = string.Empty;

        public Frm_PatientInfo(long userID, string serial_no)
        {
            InitializeComponent();

            this._userID = userID;
            this._serial_no = serial_no;

            this._SynchronizationContext = SynchronizationContext.Current;
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
        private void Frm_PatientInfo_Load(object sender, EventArgs e)
        {
            SetTextBoxReadonly(this.groupBoxPersonInfo);

            ClearTextBoxValue(this.groupBoxPersonInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_PatientInfo_Shown(object sender, EventArgs e)
        {
            CreateAndStartThread(this._thread, ThreadQueryPersonInfo);
        }

        /// <summary>
        /// 线程查询人员信息
        /// </summary>
        private void ThreadQueryPersonInfo()
        {
            try
            {
                SendUIMsg(UIMsg.Display, "正在从中心服务器通过就医登记号提取病人个人信息、业务信息 (BIZC131251)，请稍后......");

                InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.Function func = new InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.Function(baseInterfaceHN);

                InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo bizInfo = func.GetPersonInfoAndInHospitalBizInfoBy_serial_no(this._serial_no, baseInterfaceHN.Oper_hospitalid, "12");

                SendUIMsg(PatientInfoUIMsg.SetPersonInfo, bizInfo);

                SendUIMsg(UIMsg.Close);
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "通过就医登记号提取病人个人信息、业务信息 (BIZC131251)发生错误，错误原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class PatientInfoUIMsg
        {
            public const string SetPersonInfo = "SetPersonInfo";
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
                    case PatientInfoUIMsg.SetPersonInfo:
                        SetPersonInfo(parameter.Object);
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
        private void SetPersonInfo(object p)
        {
            InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo bizInfo = (InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo)p;

            List<Parameter> listParameter = GetProperties<InterfaceClass.HN.ZY.GetPersonInfoAndBizInfo.BizInfo>(bizInfo);

            SetTextBoxText(this.groupBoxPersonInfo, string.Empty, listParameter);

            this.finish_flag.Text = (this.finish_flag.Text.Trim() == "0" ? "在院" : "出院");

            this.treatment_type.Text = GetTreatmentType(this.treatment_type.Text.Trim());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetTreatmentType(string name)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(@"SELECT  *
                                FROM    HIS_InterfaceHN.dbo.JC_TypeCompareTable
                                WHERE   TypeID = 2
                                        AND name = '{0}'", name));
            try
            {
                return Alif.DBUtility.DbHelperSQL.Query(sb.ToString()).Tables[0].Rows[0]["Value"].ToString().Trim();
            }
            catch (Exception ex)
            {
                CommonFunctions.MsgError("通过查询待遇类别发生错误，请联系管理员（错误原因：" + ex.Message + "）！！！");
                return string.Empty;
            }
        }
    }
}