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
    /// <summary>
    /// 
    /// </summary>
    public partial class Frm_UpdateForegift : BaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        private Thread _thread = null;

        /// <summary>
        /// 就医序列号
        /// </summary>
        private string _serial_no = string.Empty;

        private string _foregift_remain = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public Frm_UpdateForegift(long userID, string serial_no)
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
        private void Frm_UpdateForegift_Load(object sender, EventArgs e)
        {
            QueryAndSetUserInfo();

            this.txtBox_serial_no.Text = this._serial_no;
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            this._foregift_remain = this.txtBox_foregift_remain.Text.Trim();

            if (this._foregift_remain == string.Empty)
            {
                CommonFunctions.MsgError("【预付款余额】不能为空！！！");

                this.txtBox_foregift_remain.Focus();

                return;
            }

            CreateAndStartThread(this._thread, ThreadSave);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadSave()
        {
            SendUIMsg(UpdateForegiftUIMsg.DisabledSaveButton);

            try
            {
                SendUIMsg(UIMsg.Display, "正在往中心服务器保存预付款信息(BIZC131203)，请稍后......");

                InterfaceClass.HN.ZY.UpdateForegift.Function func = new InterfaceClass.HN.ZY.UpdateForegift.Function(baseInterfaceHN);

                func.SaveForegift(baseInterfaceHN.Oper_hospitalid, this._serial_no, this._foregift_remain);

                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgInfo, "保存预付款信息成功！！！");
            }
            catch (Exception ex)
            {
                SendUIMsg(UIMsg.Close);
                SendUIMsg(UIMsg.MsgError, "保存预付款信息(BIZC131203)发生错误，错误原因：" + ex.Message);
            }

            SendUIMsg(UpdateForegiftUIMsg.EnabledSaveButton);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_foregift_remain_Validating(object sender, CancelEventArgs e)
        {
            string value = this.txtBox_foregift_remain.Text.Trim();

            double result = 0;

            if (double.TryParse(value, out result))
            {
                this.txtBox_foregift_remain.Text = double.Parse(value).ToString("0.00");
            }
            else
            {
                CommonFunctions.MsgError("【预付款余额】只能是数字，不能是其他非法字符！！！");

                this.txtBox_foregift_remain.Clear();
                this.txtBox_foregift_remain.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class UpdateForegiftUIMsg
        {
            public const string DisabledSaveButton = "DisabledSaveButton";
            public const string EnabledSaveButton = "EnabledSaveButton";
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
                    case UpdateForegiftUIMsg.DisabledSaveButton:
                        this.btnSave.Enabled = false;
                        break;
                    case UpdateForegiftUIMsg.EnabledSaveButton:
                        this.btnSave.Enabled = true;
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
    }
}